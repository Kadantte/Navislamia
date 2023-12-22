using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Navislamia.Configuration.Options;
using Navislamia.Game.Network.Entities;
using Navislamia.Game.Network.Enums;
using Navislamia.Game.Network.Packets.Auth;
using Navislamia.Game.Services;
using Navislamia.Network.Enums;
using Navislamia.Network.Packets;
using Navislamia.Network.Packets.Actions;
using Navislamia.Network.Packets.Auth;
using Navislamia.Network.Packets.Upload;
using Navislamia.Notification;
using Serilog.Core;

namespace Navislamia.Game.Network
{
    public class NetworkModule : INetworkModule
    {
        private Socket _clientListener;

        private readonly IClientService<AuthClientEntity> _authService;
        private readonly IClientService<UploadClientEntity> _uploadService;

        private readonly INotificationModule _notificationSvc;
        private readonly IOptions<NetworkOptions> _networkIOptions;
        private readonly NetworkOptions _networkOptions;
        private readonly ServerOptions _serverOptions;
        private readonly IOptions<LogOptions> _logOptions;

        private readonly AutoResetEvent authReset = new AutoResetEvent(false);

        private volatile int _readyFlag;

        private ILogger _logger;

        public Dictionary<string, ClientService<GameClientEntity>> UnauthorizedGameClients { get; set; } = new();
        public Dictionary<string, ClientService<GameClientEntity>> AuthorizedGameClients { get; set; } = new();

        public AuthActions AuthActions { get; }
        public GameActions GameActions { get; }
        public UploadActions UploadActions { get; }

        public NetworkModule(IClientService<AuthClientEntity> authService, IClientService<UploadClientEntity> uploadService,
            IOptions<NetworkOptions> networkOptions, INotificationModule notificationModule, IOptions<LogOptions> logOptions,
            IOptions<ServerOptions> serverOptions, ICharacterService characterService)
        {
            _notificationSvc = notificationModule;
            _authService = authService;
            _uploadService = uploadService;
            _networkIOptions = networkOptions;
            _networkOptions = networkOptions.Value;
            _serverOptions = serverOptions.Value;
            _logOptions = logOptions;

            AuthActions = new AuthActions(notificationModule, this);
            GameActions = new GameActions(notificationModule, this, _networkOptions, characterService);
            UploadActions = new UploadActions(notificationModule, this);
        }

        public IClientService<AuthClientEntity> GetAuthClient() => _authService;

        public IClientService<UploadClientEntity> GetUploadClient() => _uploadService;

        public void SetReadiness(NetworkReadiness readinessFlag)
        {
            _readyFlag |= (int)readinessFlag;
        }

        public bool IsReady
        {
            get
            {
                if ((_readyFlag & (int)NetworkReadiness.AuthReady) != 0 && (_readyFlag & (int)NetworkReadiness.UploadReady) != 0)
                {
                    return true;
                }

                return false;
            }
        }

        public int GetPlayerCount() => AuthorizedGameClients.Count;

        public bool Initialize()
        {
            ConnectToAuth();
            ConnectToUpload();
            SendGsInfoToAuth();
            SendInfoToUpload();

            while ((_readyFlag & (int)NetworkReadiness.AuthServerReady) == 0)
            {
                var maxTime = DateTime.UtcNow.AddSeconds(30);

                if (DateTime.UtcNow < maxTime)
                    continue;

                _notificationSvc.WriteError("Network service timed out!");

                return false;
            }

            return true;
        }

        public void Shutdown()
        {
            _notificationSvc.WriteString("NetworkModule is shutting down...\n");

            _authService.GetEntity().Connection.Disconnect();
            _uploadService.GetEntity().Connection.Disconnect();

            using (var clientEnumerator = UnauthorizedGameClients.GetEnumerator())
            {
                while (clientEnumerator.MoveNext())
                {
                    IClientService<GameClientEntity> client = clientEnumerator.Current.Value;

                    // TODO: send logout packet to client
                    client.GetEntity().Connection.Disconnect();
                }

                UnauthorizedGameClients.Clear();
            }

            using (var clientEnumerator = AuthorizedGameClients.GetEnumerator())
            {
                while (clientEnumerator.MoveNext())
                {
                    IClientService<GameClientEntity> client = clientEnumerator.Current.Value;

                    // TODO: send logout packet to client
                    client.GetEntity().Connection.Disconnect();
                }

                AuthorizedGameClients.Clear();
            }

            _notificationSvc.WriteSuccess("NetworkModule has successfully shutdown!");
        }

        private void ConnectToAuth()
        {
            string addrStr = _networkOptions.Auth.Ip;
            int port = _networkOptions.Auth.Port;

            if (string.IsNullOrEmpty(addrStr) || port == 0)
            {
                _notificationSvc.WriteError("Invalid network auth ip! Review your configuration!");
                throw new Exception();
            }

            IPAddress addr;

            if (!IPAddress.TryParse(addrStr, out addr))
            {
                _notificationSvc.WriteError($"Failed to parse auth ip: {addrStr}");
                throw new Exception();

            }

            IPEndPoint authEp = new IPEndPoint(addr, port);
            var authSock = new Socket(addr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                var _authConnection = new Connection(authSock);
                _authConnection.Connect(addrStr, port);

                _authService.Initialize(this, _authConnection);
            }
            catch (Exception ex)
            {
                _notificationSvc.WriteException(ex);
                _notificationSvc.WriteError("Failed to connect to the auth server!");
                throw new Exception();

            }

            _notificationSvc.WriteDebug(new[] { "Connected to Auth server successfully!" }, true);
            
        }

        private void SendGsInfoToAuth()
        {
            try
            {
                var index = _serverOptions.Index;
                var name = _serverOptions.Name;
                var screenshotUrl = _serverOptions.ScreenshotUrl;
                var isAdultServer = _serverOptions.IsAdultServer;
                var ip = _networkOptions.Game.Ip;
                var port = _networkOptions.Game.Port;

                var msg = new Packet<TS_GA_LOGIN>((ushort)AuthPackets.TS_GA_LOGIN, new(index, name, screenshotUrl, (byte)isAdultServer, ip, port));

                _authService.SendMessage(msg);
            }
            catch (Exception ex)
            {
                _notificationSvc.WriteError("Failed to send Game server info to the Auth Server!");
                _notificationSvc.WriteException(ex);

                throw new Exception("Failed sending message to Authservice");
            };
        }

        private void ConnectToUpload()
        {
            string addrStr = _networkOptions.Upload.Ip;
            int port = _networkOptions.Upload.Port;

            if (string.IsNullOrEmpty(addrStr) || port == 0)
            {
                _notificationSvc.WriteError("Invalid network io.upload.ip configuration! Review your Configuration.json!");
            }

            IPAddress addr;

            if (!IPAddress.TryParse(addrStr, out addr))
            {
                _notificationSvc.WriteError($"Failed to parse io.upload.ip: {addrStr}");
                throw new Exception("Could not read upload ip");
            }

            IPEndPoint uploadEp = new IPEndPoint(addr, port);
            var uploadSock = new Socket(addr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                var _uploadConnection = new Connection(uploadSock);
                _uploadConnection.Connect(addrStr, port);

                _uploadService.Initialize(this, _uploadConnection);
            }
            catch (Exception ex)
            {
                _notificationSvc.WriteException(ex);
                _notificationSvc.WriteError("Failed to connect to the upload server!");
                throw new Exception();
            }

            _notificationSvc.WriteDebug(new[] { "Connected to Upload server successfully!" }); ;
        }

        private void SendInfoToUpload()
        {
            try
            {
                var serverName = _serverOptions.Name;

                var msg = new Packet<TS_SU_LOGIN>((ushort)UploadPackets.TS_SU_LOGIN, new(serverName));

                _uploadService.SendMessage(msg);
            }
            catch (Exception ex)
            {
                _notificationSvc.WriteException(ex);
                throw new Exception();
            }
        }

        public void StartListener()
        {
            string _address = _networkOptions.Game.Ip;
            ushort _port = _networkOptions.Game.Port;
            int _backlog = _networkOptions.Backlog;

            IPAddress addr;

            if (!IPAddress.TryParse(_address, out addr))
            {
                _notificationSvc.WriteError($"Failed to parse io.ip: {_address}");
                return;
            }

            var _clientListenerEndPoint = new IPEndPoint(addr, _port);

            _clientListener = new(_clientListenerEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            _clientListener.Bind(_clientListenerEndPoint);
            _clientListener.Listen(_backlog);

            Task.Run(acceptClients);
        }

        private async void acceptClients()
        {
            while (true)
            {
                var _clientSocket = await _clientListener.AcceptAsync();
                _clientSocket.NoDelay = true;

                ClientService<GameClientEntity> client = new(_logOptions, _notificationSvc, _networkIOptions);
                client.Initialize(this, new CipherConnection(_clientSocket, _networkOptions.CipherKey));

                _notificationSvc.WriteDebug($"Game client connected @{client.Entity.Connection.RemoteIp}:{client.Entity.Connection.RemotePort}");
            }
        }

        public bool RegisterAccount(ClientService<GameClientEntity> client, string accountName)
        {
            if (AuthorizedGameClients.ContainsKey(accountName))
                return false;

            AuthorizedGameClients[accountName] = client;

            return true;
        }

        public void RemoveGameClient(ClientService<GameClientEntity> client)
        {
            var _clientEntity = client.GetEntity();
            var _clientInfo = _clientEntity.Info;
            var _msg = new Packet<TS_GA_CLIENT_LOGOUT>((ushort)AuthPackets.TS_GA_CLIENT_LOGOUT, new(_clientInfo.AccountName, (uint)_clientInfo.ContinuousPlayTime));

            _authService.SendMessage(_msg);

            AuthorizedGameClients.Remove(_clientInfo.AccountName);

            _notificationSvc.WriteDebug($"Game Client @{client.Entity.Connection.RemoteIp}:{client.Entity.Connection.RemotePort} disconnected!");

            client.Dispose();
            client = null;
        }

    }
}
