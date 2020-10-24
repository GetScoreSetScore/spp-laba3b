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




        private void ButtonAddFeed_Click(object sender, EventArgs e)
        {
            ListBoxFeeds.Items.Add(TextBoxNewLink.Text);
            TextBoxNewLink.Text = "";
        }

        private void ListBoxFeedItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            WebBrowserMain.Navigate(Links[ListBoxFeedItems.SelectedIndex]);
            LabelPageTitle.Text = ListBoxFeedItems.Items[ListBoxFeedItems.SelectedIndex].ToString();
        }

        private void ButtonBeginSending_Click(object sender, EventArgs e)
        {

            try
            {
                string url = TextBoxNewLink.Text;
                XmlReader reader = XmlReader.Create(url);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();
                WebBrowserMain.ScriptErrorsSuppressed = true;
                foreach (SyndicationItem item in feed.Items)
                {
                    //Summaries.Add(item.Summary?.Text??"");
                    Links.Add(item.Links[0].Uri.ToString());
                    ListBoxFeedItems.Items.Add(item.Title.Text);
                }
                ListBoxFeeds.Items.Add(url);
                TextBoxNewLink.Text = "";
            }
            catch (Exception err)
            {
                MessageBox.Show("Unable to load RSS feed from given adress : " + err.Message);
            }
        }

        private void ButtonAddRecipient_Click(object sender, EventArgs e)
        {
            ListBoxRecepients.Items.Add(TextBoxNewRecipient.Text);
            TextBoxNewRecipient.Text = "";
        }
    }
}
