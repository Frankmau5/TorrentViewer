using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TorrentEdtior
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void openBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Please select a torrent file to open.";
            ofd.Filter = "Torrent files (*.torrent) | *.torrent; ";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string torrentFilePath = ofd.FileName;
                // thread needed
                myTorrent mt = new myTorrent(torrentFilePath);
                var dataFromTorrent = mt.getTorrentFileInfo();

                if (dataFromTorrent != null)
                {
                    this.DisplayView.Text = dataFromTorrent; // displays info
                }
                mt = null;
            }
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            AboutBox1 box = new AboutBox1();
            box.ShowDialog();
        }
    }
}
