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
            FTPController.MessageConsole._onLogger = (obj, level) =>
            {
                if (obj != null)
                {
                    this.OutputLog(obj.ToString(), level);
                }
            };
        }
        FTPController.Timing _timing = null;
        private bool isRunning = false;
        private void btnStart_Click(object sender, EventArgs e)
        {
            this._timing.Start();

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this._timing.Stop();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DateTime startTime = DateTime.Now;
            startTime.AddMinutes(1);
            this._timing = new FTPController.Timing(1000, startTime);
            this._timing._onTimingStart = () =>
            {
                if (!this.isRunning)
                {
                    this.isRunning = true;
                    FTPController.FTP ftp = new FTPController.FTP(new Uri(FTPController.Auth.Url + "/DBBackUp"), FTPController.Auth.User, FTPController.Auth.Password);
                    //  ftp.DownloadFile("memcached.rar", @"D:\");
                    FTPController.FileStruct[] files = ftp.ListFiles();
                    foreach (var file in files)
                    {
                        if (ftp.DownloadFile(file.Name, @"D:\test"))
                        {
                            ftp.DeleteFile(file.Name);
                        }
                    }
                    FTPController.MessageConsole.WriteConsole("下载文件 完成。");
                    this.isRunning = false;
                }

            };
        }
        public void OutputLog(string msg, FTPModel.LogModel.LogLevel level)
        {
            if (this.IsHandleCreated)
            {
                this.tbMsg.Invoke((MethodInvoker)delegate()
                {
                    lock (this.tbMsg)
                    {
                        DateTime dtime = DateTime.Now;
                        this.tbMsg.AppendText("[" + dtime + "] " + msg + "\r\n");
                    }
                });
            }
        }
    }
}
