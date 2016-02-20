using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTPController
{
    public class MessageConsole
    {
        public static FTPModel.Delegate.OnConsoleLogger _onLogger = null;
        public static void WriteConsole(string msg, FTPModel.LogModel.LogLevel level = FTPModel.LogModel.LogLevel.Common)
        {
            if (MessageConsole._onLogger != null)
            {
                MessageConsole._onLogger(msg, level);
            }
            DateTime dtime = DateTime.Now;
            string txt = "[" + dtime + "] " + msg;
            Log.WriteLog(txt, level);
        }
        public static void WriteConsole(string msg)
        {
            if (MessageConsole._onLogger != null)
            {
                MessageConsole._onLogger(msg, FTPModel.LogModel.LogLevel.Common);
            }

            DateTime dtime = DateTime.Now;
            string txt = "[" + dtime + "] " + msg;
            Log.WriteLog(txt, FTPModel.LogModel.LogLevel.Common);
        }
        public static void WriteConsole(Exception ex)
        {
            if (MessageConsole._onLogger != null)
            {
                MessageConsole._onLogger(ex.Message + "\r\n\t" + ex.StackTrace, FTPModel.LogModel.LogLevel.Error);// + "\r\n\t系统信息：\r\n\t" + getSystermInfo()
            }
            Log.WriteLog(ex.Message + "\r\n\t" + ex.StackTrace, FTPModel.LogModel.LogLevel.Error);//+ "\r\n\t系统信息：\r\n\t" + getSystermInfo()

        }
    }
}
