using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealisticLifeV2
{
    public partial class Form5 : Form
    {
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        public Form5()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form0 form0 = new Form0();
            form0.Show();
        }
        public class WebClientWithTimeout : WebClient
        {
            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest wc = base.GetWebRequest(address);
                wc.Timeout = 5000;
                return wc;
            }
        }
        public bool GetConnection()
        {
            try
            {
                using (WebClient wc = new WebClientWithTimeout())
                {
                    string json = wc.DownloadString($"http://185.185.134.10:30130/players.json");
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            label14.Hide();
            label15.Hide();
            label16.Hide();
            textBox3.Hide();
            button2.Hide();
            button4.Hide();
            webBrowser1.Hide();
            label19.Hide();

            if (GetConnection())
            {
                label22.Text = "ON";
                label22.ForeColor = Color.FromArgb(25, 200, 25);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            System.Diagnostics.Process.Start("https://realistic-life.co.il");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            System.Diagnostics.Process.Start("fivem://connect/176.31.248.216:30120");
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            System.Diagnostics.Process.Start("ts3server://188.40.166.148/?port=9997&nickname=FuckRealisticLife");
        }
        public int pCount()
        {
            try
            {
                using (WebClient wc = new WebClientWithTimeout())
                {
                    string json = wc.DownloadString($"http://185.185.134.10:30130/players.json");
                    int player = json.Length - json.Replace("{", "").Length;
                    return player;
                }
            }
            catch
            {
                return 0;
            }
        }
        private void label7_Click(object sender, EventArgs e)
        {
            label8.Show();
            label9.Show();
            label10.Show();
            label11.Show();
            label12.Show();

            label14.Hide();
            label15.Hide();
            label16.Hide();
            textBox3.Hide();
            button2.Hide();
            webBrowser1.Hide();
            button4.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();
            label16.Hide();
            textBox3.Hide();
            button2.Hide();
            button4.Hide();
            webBrowser1.Hide();

            label14.Show();
            label15.Show();

            int playerCount = pCount();
            string playerCountString = Convert.ToString(playerCount);
            label15.Text = $"{playerCountString} / 32";
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = Properties.Settings.Default["fivemdir"].ToString() + "\\cache";
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
                MessageBox.Show("Deleted your cache folder.");
            }
            else
            {
                MessageBox.Show("Cache folder not found.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["fivemdir"] = textBox3.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Setted FiveM Directory.");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();
            label14.Hide();
            label15.Hide();
            webBrowser1.Hide();

            label16.Show();
            textBox3.Show();
            button2.Show();
            button4.Show();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();
            label14.Hide();
            label15.Hide();
            label16.Hide();
            textBox3.Hide();
            button2.Hide();
            button4.Hide();

            webBrowser1.Show();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label19.Hide();
            label20.Show();
            label21.ForeColor = Color.FromArgb(255, 255, 255);
            this.BackgroundImage = Properties.Resources.kostanigger3;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label19.Show();
            label20.Hide();
            label21.ForeColor = Color.FromArgb(0, 0, 0);
            this.BackgroundImage = Properties.Resources.kostanigger1;
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }
    }
}
