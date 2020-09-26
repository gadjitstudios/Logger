using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class Logger<T> where T : ILogLevel, new()
    {
        private static T _LogLevel;
        static Logger()
        {
            _LogLevel = new T();
        }

        public static Task Write(string msg)
        {
            return _LogLevel.Write(msg);

        }

        public static Task Write(List<string> msg)
        {
            return _LogLevel.Write(msg);
        }

        public static string getLogLocation()
        {
            return _LogLevel.LogLocation;
        }
    }
}
