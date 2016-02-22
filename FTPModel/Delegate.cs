using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPModel
{
    public class Delegate
    {
        public delegate void OnConsoleLogger(object msg, FTPModel.LogModel.LogLevel level = FTPModel.LogModel.LogLevel.Common);
        public delegate void OnTimingStart();
    }
}
