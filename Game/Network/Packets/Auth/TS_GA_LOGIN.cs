﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Navislamia.Network.Enums;
using System.Threading;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Navislamia.Network.Packets.Auth
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TS_GA_LOGIN
    {
        public ushort ServerIndex;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ServerName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string ServerScreenshotURL;
        public byte IsAdultServer;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string ServerIP;
        public int ServerPort;

        public TS_GA_LOGIN(ushort serverIndex, string serverName, string serverScreenshotURL, byte isAdultServer, string serverIP, int serverPort)
        {
            ServerIndex = serverIndex;
            ServerName = serverName;
            ServerScreenshotURL = serverScreenshotURL;
            IsAdultServer = isAdultServer;
            ServerIP = serverIP;
            ServerPort = serverPort;
        }
    }
}
