using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tweetinvi;
using System.IO;
namespace ProiectNET
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            Auth.SetUserCredentials("FT8p9znqLRCkcUcADaDXDfwy9", "1xPPnG9URrZl6w2AWBmrcpxSwukbjipQrlMLtvxGoDCbwA6hs7", "1650674666-OI5J2lLU9NHFkbVyfctSgRYLaqNt4A7iD1cxIdx", "ZqzuU76Z2FsnC0JOkE1UCe3FofJfYlHpSY4PUGfnhtLic");
        }
        private void Form1_load(object sender, EventArgs e)
        {
            var user = User.GetAuthenticatedUser();
            pictureBox1.ImageLocation = user.ProfileImageUrl;
            label1.Text = user.Name;
            label2.Text = "@" + user.ScreenName;
        }
        private void btnTweet_Click(object sender, EventArgs e)
        {
            if (labelImage.Text != "")
            {
                byte[] file = File.ReadAllBytes(imgAttach.ImageLocation);
                Tweet.PublishTweetWithImage(txtTweet.Text, file);
            }
            else
            
            {
                var firstTweet = Tweet.PublishTweet(txtTweet.Text);
            }
            MessageBox.Show("Tweet sent!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            imgAttach.ImageLocation = ofd.FileName;
            labelImage.Text = ofd.FileName;
        }

        
    }
}
