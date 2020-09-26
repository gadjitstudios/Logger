using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Contracts
{
    public interface ILogLevel
    {
        public string LogLocation { get; }
        public Task Write(string msg);
        public Task Write(List<string> msg);

    }
}
