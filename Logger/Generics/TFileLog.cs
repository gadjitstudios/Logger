using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logger.Generics
{
    public class TFileLog
    {
        private ReaderWriterLockSlim fileLock = new ReaderWriterLockSlim();
        protected virtual string filePath { get => @"C:\Users\Public\Logger\Log.txt"; }
        public virtual string LogLocation => filePath;

        private void checkPath()
        {
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }
        } 
        public virtual Task Write(string msg)
        {
            fileLock.EnterWriteLock();
            try
            {
                checkPath();
                return File.AppendAllTextAsync(filePath, $"{msg}\r\n");
            }
            finally
            {
                fileLock.ExitWriteLock();
            }
        }

        public virtual Task Write(List<string> msg)
        {
            fileLock.EnterWriteLock();
            try
            {
                checkPath();
                return File.AppendAllLinesAsync(filePath, msg);
            }
            finally
            {
                fileLock.ExitWriteLock();
            }
        }
    }
}
