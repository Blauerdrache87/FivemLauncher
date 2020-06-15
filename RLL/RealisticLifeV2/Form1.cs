using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace RealisticLifeV2
{
    public partial class Form1 : Form
    {

        // BARBARONN LOSER! 
        // CRACKED BY KOSTA!
        // DO NOT COPY MY LAUNCHER AGAIN! _ IDIOT RETARD <3


        // THANKS FOR GETNEK DATABASE [BTW I DONT USING MYSQL]. https://www.youtube.com/watch?v=dRLMQZzu6jw

        // MESSAGE TO BARBARONN: I love u. retard!

        // Some systems will not work because I did not do the systems.

        //
        //
        /// <summary>
        ///  RealisticLife V2.0.0 Cracked by KOSTA !
        /// </summary>
        //



        string DATABASEIP = "localhost";
        string DATABASEUSER = "root";
        string DATABASEPASS = "";
        string DATABASENAME = "launcher";

        string externalip = new System.Net.WebClient().DownloadString("http://icanhazip.com");

        WebClient WebClient = new WebClient();
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.name != string.Empty)
            {
                textBox1.Text = Properties.Settings.Default.name;
                textBox2.Text = Properties.Settings.Default.password;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            string connstring = @"server=" + DATABASEIP + ";userid=" + DATABASEUSER + ";password=" + DATABASEPASS + ";database=" + DATABASENAME;
            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(connstring);
                conn.Open();

                string query = "SELECT * FROM loginlauncher_users WHERE username ='" + textBox1.Text + "'AND password ='" + textBox2.Text + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "table_name");
                DataTable dt = ds.Tables["table_name"];



                if (dt.Rows.Count >= 1)
                {


                    Console.WriteLine(dt.Rows[0][2].ToString());
                    if (dt.Rows[0][2].ToString() == "")
                    {
                        MySqlCommand comm = conn.CreateCommand();
                        comm.CommandText = "UPDATE loginlauncher_users SET" +  externalip + "= @ip WHERE username = @username;";
                        comm.Parameters.Add("ip", MySqlDbType.VarChar).Value = externalip;
                        comm.Parameters.Add("username", MySqlDbType.VarChar).Value = textBox1.Text;

                        comm.ExecuteNonQuery();

                    }
                    else
                    {


                    }

                    bool IsAllowed = false;

                    if (dt.Rows[0][2].ToString() == externalip.ToString())
                    {
                        IsAllowed = true;
                    }
                    else
                    {

                    }

                    MySqlCommand comm2 = conn.CreateCommand();
                    comm2.CommandText = "UPDATE loginlauncher_users SET IsAllowed = @IsAllowed WHERE username = @username;";
                    comm2.Parameters.Add("IsAllowed", MySqlDbType.Bit).Value = IsAllowed;
                    comm2.Parameters.Add("username", MySqlDbType.VarChar).Value = textBox1.Text;

                    comm2.ExecuteNonQuery();


                    foreach (DataRow row in dt.Rows)
                    {
                        RealisticLifeV2.Properties.Settings.Default.name = row[0].ToString();
                        this.Opacity = 0;
                        this.Visible = false;
                        this.ShowInTaskbar = false;
                        this.ShowIcon = false;

                        Properties.Settings.Default.name = textBox1.Text;
                        Properties.Settings.Default.password = textBox2.Text;
                        Properties.Settings.Default.Save();                        

                        Form5 f5 = new Form5();
                        f5.Show();
                    }
                }
                else {
                    MessageBox.Show("The username or password is incorrect.");
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Environment.Exit(0);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private bool mouseDown;
        private Point lastLocation;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form0 form0 = new Form0();
            form0.Show();
        }
    }
}
