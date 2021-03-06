﻿using System;
using Common.Logging;
using Lightstreamer.DotNet.Client.Log;

namespace StreamingClient.Lightstreamer
{
    internal class LSLoggerProvider : ILoggerProvider
    {
        public ILogger GetLogger(string category)
        {
            return new LSLogger(category, LogLevel.All, true, true, true, null);
        }
    }
}