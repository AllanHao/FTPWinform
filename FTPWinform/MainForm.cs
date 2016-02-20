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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FTPController.FTP ftp = new FTPController.FTP(new Uri(FTPController.Auth.Url+"/DBBackUp"), FTPController.Auth.User, FTPController.Auth.Password);
          //  ftp.DownloadFile("memcached.rar", @"D:\");
            FTPController.FileStruct[] files = ftp.ListFiles();
            foreach (var file in files)
            {
                if (ftp.DownloadFile(file.Name, @"D:\test")) {
                    ftp.DeleteFile(file.Name);
                }
            }
            FTPController.MessageConsole.WriteConsole("下载文件 完成。");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //System.Net.Ftp.clsFTP ftp = new System.Net.Ftp.clsFTP(new Uri("ftp://118.186.246.162:2121"), "ftp_admin", "iwehave2305!");
            //ftp.DeleteFile("GAIA_WEB_RETAIL_CJ_backup_2016_02_18_000001_1453809.bak");
        }
    }
}
