using System;
using Logger.Contracts;
using Logger.Generics;


namespace Logger.Models
{
    public class WarningLog : TFileLog, ILogLevel
    {
        protected override string filePath { get => Environment.GetEnvironmentVariable("WARNING_LOG_PATH"); }

    }
}
