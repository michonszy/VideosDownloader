using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.Net;
using System.IO;

namespace YouTube_Downloader
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        public void Pobieranie(string link, string name)
        {
            using(WebClient Client = new WebClient())
            {
                Client.DownloadFile(link, name);
            }
        }

        public void GetVideo_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            HttpWebRequest myHttpWebRequest1 = (HttpWebRequest)WebRequest.Create(url);
            
            if (url.Contains("youtube"))
            {
                string zmieniony = url.Replace(".com/watch?v=", ".com/embed/");
                
                zmieniony = zmieniony + "?autoplay=1";
                webBrowser1.Navigate(zmieniony);
                textBox1.Text = zmieniony;
            }
            else
            {
                webBrowser1.Navigate(textBox1.Text);
            }


        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Pobieranie(textBox1.Text, textBox2.Text);
                MessageBox.Show("Wszystko OK", "Plik został pobrany");
                string url = textBox1.Text;
                if (url.Contains("youtube"))
                {
                    url.Replace(".com/watch?v=", ".com/embed/");

                }

            }
            catch(Exception wyjatek)
            {
                MessageBox.Show("Błąd!", "Podany błąd to: " + wyjatek.ToString());
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


    }
}
