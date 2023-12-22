﻿using Spectre.Console.Cli;

namespace Navislamia.Command
{
    public interface ICommandModule
    {
        public string Input { get; set; }

        public int Init();

        public int Wait();

        public int Execute(string[] args);
    }
}
