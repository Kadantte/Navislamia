using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using Navislamia.Network.Packets;

namespace Navislamia.Game.Network.Entities;

public interface IClientService<T>
{
    T GetEntity();
    void Initialize(INetworkModule networkModule, IConnection connection);
    void SendMessage(IPacket msg);
    void SendResult(ushort id, ushort result, int value = 0);

    void SendCharacterList(List<LobbyCharacterInfo> characterList);
}