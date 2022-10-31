using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] url = File.ReadAllLines(@"C:\Users\S2 407\Desktop\WindowsFormsApp1\host.txt");

            for (int i = 0; i < url.Length; i++)
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url[i]);
                    request.Method = "GET";
                    request.Timeout = 30 * 1000;

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    textBox1.Text += "[" + i + "]" + url[i] + "\r\n";
                    if (Convert.ToString(response.StatusCode) == "OK")
                    {
                        textBox2.ForeColor = Color.Blue;
                        textBox2.Text += "[" + i + "]" + Convert.ToString(response.StatusCode) + "\r\n";
                    }
                }
                catch (WebException ex)
                {
                    textBox1.Text += "[" + i + "]" + url[i] + "\r\n";
                    textBox2.Text += "[" + i + "]" + ex.Message + "\r\n";
                }
            }
        }
    }
}
