﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navislamia.Game
{
    public interface IGameModule
    {
        Task Start(string ip, int port, int backlog);
    }
}