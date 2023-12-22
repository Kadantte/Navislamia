﻿using Navislamia.Network.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Navislamia.Network.Packets.Upload
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TS_US_LOGIN_RESULT 
    {
        public ushort Result;
    }
}
