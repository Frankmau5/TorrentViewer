using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonoTorrent;
// add msg box 

namespace TorrentEdtior
{
    class myTorrent
    {
        public String Path;

        public myTorrent() { }
        public myTorrent(String path) {
            Path = path;

        }


        private string _getTorrentData() {
            Torrent torrent = Torrent.Load(this.Path);
            string torrentMetaData = "Files:\n";
            foreach (var tFile in torrent.Files)
            {
                torrentMetaData = torrentMetaData + tFile.Path + "\n";
            }

            torrentMetaData = torrentMetaData + "\n" + "Other info\n";
            torrentMetaData = torrentMetaData + "Created by: " + torrent.CreatedBy + "\n";
            torrentMetaData = torrentMetaData + "Creation date: " + torrent.CreationDate + "\n";
            torrentMetaData = torrentMetaData + "Publisher: " + torrent.Publisher + "\n";
            torrentMetaData = torrentMetaData + "Publisher Url: " + torrent.PublisherUrl + "\n";
            torrentMetaData = torrentMetaData + "SHA1: " + torrent.SHA1 + "\n";
            torrentMetaData = torrentMetaData + "Size: " + torrent.Size.ToString() + "\n"; // display in right format (e.g kb or mb )
            torrentMetaData = torrentMetaData + "Source: " + torrent.Source + "\n";
            torrentMetaData = torrentMetaData + "Info Hash: " + torrent.InfoHash + "\n";
            torrentMetaData = torrentMetaData + "Is Private: " + torrent.IsPrivate + "\n";
            torrentMetaData = torrentMetaData + "Comment: " + torrent.Comment + "\n";
            return torrentMetaData;
        }
        public String getTorrentFileInfo() {


            if (!String.IsNullOrEmpty(this.Path)) {
                FileInfo f = new FileInfo(this.Path);
                if (f.Length < 1000000)
                {
                    return _getTorrentData();
                }
                else
                {
                    // display msg
                    string message = "This file is bigger then an 1MB. This may take sometime.";
                    string caption = "File may not be able to be open";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;

                    MessageBox.Show(message, caption, buttons);
                    return _getTorrentData();
                    
                }


                
            }
            else
            {
                return null;
            } 
        }

    }
}
