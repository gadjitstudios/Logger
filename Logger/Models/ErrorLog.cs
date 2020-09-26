using Logger.Contracts;
using Logger.Generics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models
{
    public class ErrorLog : TFileLog, ILogLevel
    {
        protected override string filePath { get => Environment.GetEnvironmentVariable("ERROR_LOG_PATH"); }

    }
}
