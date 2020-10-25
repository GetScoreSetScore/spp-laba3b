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
using System.Net.Mail;
using System.Net;
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



        public List<string> tags = new List<string>();
        public System.Timers.Timer MainTimer = new System.Timers.Timer();
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
            ThreadPool.QueueUserWorkItem(state => ReadFilterSendThreadMain());
        }
        private void ReadFilterSendThreadMain()
        {
            if (ListBoxFeeds.Items.Count > 0)
            {
                List<ManualResetEvent> ThreadsCompletion = new List<ManualResetEvent>();
                List<List<SyndicationItem>> filtereditems = new List<List<SyndicationItem>>();
                List<SyndicationItem> result = new List<SyndicationItem>();
                tags.Clear();
                tags = TextBoxTags.Text.Split(' ').ToList();
                Links.Clear();
                foreach (string url in ListBoxFeeds.Items)
                {
                    ManualResetEvent mre = new ManualResetEvent(false);
                    ThreadsCompletion.Add(mre);
                    List<SyndicationItem> filteredfeed = new List<SyndicationItem>();
                    filtereditems.Add(filteredfeed);
                    ThreadPool.QueueUserWorkItem((state) =>
                    {
                        filteredfeed.AddRange(LoadAndFilter(url));
                        mre.Set();
                    });
                }
                WaitHandle.WaitAll(ThreadsCompletion.ToArray());
                foreach (List<SyndicationItem> list in filtereditems)
                    result.AddRange(list);
                ListBoxFeedItems.Invoke(new Action(() => ListBoxFeedItems.Items.Clear()));
                ThreadPool.QueueUserWorkItem(state => SendToRecipients(ListBoxRecipients.Items.Cast<string>().ToList(), result));
                ListBoxFeedItems.Invoke(new Action(() => ListBoxFeedItems.Items.AddRange(result.Select(items => items.Title.Text).ToArray())));
                Links.AddRange(result.Select(items => items.Links[0].Uri.ToString()).ToArray());
                MainTimer.Stop();
                MainTimer.Interval = (double)(1000 * 60 * (NumericUpDownMinutes.Value + NumericUpDownHours.Value * 60 + NumericUpDownDays.Value * 60 * 24));
                MainTimer.Start();
                ActiveForm?.Invoke(new Action(() => ActiveForm.Text = "Mail sent at " + DateTime.Now)); 
            }
        }

        public void Send(string mailFrom, string password, string mailTo, string message, string subject)
        {
            string username = mailFrom.Split('@')[0];
            MailMessage mailmessage = new MailMessage(mailFrom, mailTo, subject, message);
            mailmessage.IsBodyHtml = true;
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(username, password)
                    
                };
                client.Send(mailmessage);
                client.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending mail: " + ex.Message);
            }
            mailmessage.Dispose();
        }
        public  void SendToRecipients(List<string> recipients, List<SyndicationItem> items)
        {
            string message = message = string.Join(string.Empty,
                items.Select(item => "<a href=\"" + item.Links.First().Uri + "\">" + item.Title.Text + "</a>" + "<br>").ToArray());
            
            string subject = "Selected RSS feed at " + DateTime.Now;
            string sender = "phpmailerlaba@gmail.com";
            string password = "phplabapass";
            foreach (var recipient in recipients)
            {
                ThreadPool.QueueUserWorkItem(state => Send(sender, password, recipient, message, subject));
            }
        }
        private List<SyndicationItem> LoadAndFilter(string url)
        {
            List<SyndicationItem> result = new List<SyndicationItem>();
            try
            {
                XmlReader reader = XmlReader.Create(url);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();
                foreach (SyndicationItem item in feed.Items)
                {
                    if (tags.Any())
                    {
                        foreach (string t in tags)
                        {
                            if (item.Summary?.Text.ToUpper().Contains(t.ToUpper()) ?? false)
                            {
                                result.Add(item);
                                break;
                            }
                        }
                    }
                    else
                        result.Add(item);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Unable to load RSS feed from "+url+" adress : " + err.Message);
            }
            return result;
        }

        private void ButtonAddRecipient_Click(object sender, EventArgs e)
        {
            ListBoxRecipients.Items.Add(TextBoxNewRecipient.Text);
            TextBoxNewRecipient.Text = "";
        }

        private void ButtonDeleteFeed_Click(object sender, EventArgs e)
        {
            if(ListBoxFeeds.Items.Count>0 && ListBoxFeeds.SelectedIndex != -1)
            {
                ListBoxFeeds.Items.RemoveAt(ListBoxFeeds.SelectedIndex);
            }
        }

        private void ButtonDeleteRecipient_Click(object sender, EventArgs e)
        {
            if (ListBoxRecipients.Items.Count > 0 && ListBoxRecipients.SelectedIndex != -1)
            {
                ListBoxRecipients.Items.RemoveAt(ListBoxRecipients.SelectedIndex);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MainTimer.Elapsed += (o, args) => ReadFilterSendThreadMain();
        }

        private void NumericUpDownTime_ValueChanged(object sender, EventArgs e)
        {
            if(NumericUpDownMinutes.Value==0&& NumericUpDownHours.Value == 0&& NumericUpDownDays.Value == 0)
            {
                NumericUpDownMinutes.Value = 1;
            }
        }
    }
}
