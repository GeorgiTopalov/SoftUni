﻿using System;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Commands
{
    internal class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Hello, {args[0]}";
        }
    }
}
