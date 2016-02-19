using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTPController
{
    public class Auth
    {
        public static string IP
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["ip"];
            }
        }

        public static string Url
        {
            get
            {
                return "ftp://" + System.Configuration.ConfigurationManager.AppSettings["ip"];
            }
        }
        public static string User
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["user"];
            }
        }
        public static string Password
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["pwd"];
            }
        }
    }
}
