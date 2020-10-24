using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Threading;

namespace laba3b
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> Links = new List<string>();
        List<string> Summaries = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string url = textBox1.Text;
                XmlReader reader = XmlReader.Create(url);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();
                webBrowser1.ScriptErrorsSuppressed = true;
                foreach (SyndicationItem item in feed.Items)
                {
                    //Summaries.Add(item.Summary?.Text??"");
                    Links.Add(item.Links[0].Uri.ToString());
                    listBox1.Items.Add(item.Title.Text);
                }
                listBox2.Items.Add(url);
                textBox1.Text = "";
            }
            catch (Exception err)
            {
                MessageBox.Show("Unable to load RSS feed from given adress : " + err.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            webBrowser1.Navigate(Links[listBox1.SelectedIndex]);

            label1.Text = listBox1.Items[listBox1.SelectedIndex].ToString();
        }
    }
}
