using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FTPWinform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FTPController.FTPHelper.Instance.Download("ftp_user", "iwehave2305!", "118.186.246.162:2121", @"D:\", "GAIA_WEB_RETAIL_CJ_backup_2016_02_18_000001_1453809.bak");
            //FTPController.FTPHelper ftp = new FTPController.FTPHelper("118.186.246.162",2121,"ftp_user","iwehave2305!");
            //ftp.OpenDownload("GAIA_WEB_RETAIL_CJ_backup_2016_02_18_000001_1453809.bak");
            FTPController.FTP ftp = new FTPController.FTP(new Uri(FTPController.Auth.Url), FTPController.Auth.User, FTPController.Auth.Password);
            ftp.DownloadFile("memcached.rar", @"D:\");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //System.Net.Ftp.clsFTP ftp = new System.Net.Ftp.clsFTP(new Uri("ftp://118.186.246.162:2121"), "ftp_admin", "iwehave2305!");
            //ftp.DeleteFile("GAIA_WEB_RETAIL_CJ_backup_2016_02_18_000001_1453809.bak");
        }
    }
}
