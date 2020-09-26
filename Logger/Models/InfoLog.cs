using System;
using Logger.Contracts;
using Logger.Generics;


namespace Logger.Models
{
    public class InfoLog : TFileLog, ILogLevel
    {
        protected override string filePath { get => Environment.GetEnvironmentVariable("INFO_LOG_PATH"); }

    }
}
