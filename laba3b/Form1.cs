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

            /*try
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
            }*/
            ThreadPool.QueueUserWorkItem(state => tmpfunc());
        }
        private void tmpfunc()
        {
            List<ManualResetEvent> ThreadsCompletion = new List<ManualResetEvent>();
            List<List<SyndicationItem>> filtereditems = new List<List<SyndicationItem>>();
            List<SyndicationItem> result = new List<SyndicationItem>();
            foreach(string url in ListBoxFeeds.Items)
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
            
            ThreadPool.QueueUserWorkItem(state => SendToRecipients(ListBoxRecipients.Items.Cast<string>().ToList(),result));
            ListBoxFeedItems.Invoke(new Action(() => ListBoxFeedItems.Items.AddRange(result.Select(foo => foo.Title.Text).ToArray())));
            Links.AddRange(result.Select(foo => foo.Links[0].Uri.ToString()).ToArray());
        }
        private MailMessage CreateMailMessage(string mailFrom, string mailTo, string message, string subject)
        {
            MailMessage mail=null;
            try
            {
                mail = new MailMessage();
                mail.From = new MailAddress(mailFrom);
                mail.To.Add(new MailAddress(mailTo));
                mail.Subject = subject;
                mail.Body = message;
            }
            catch (Exception ex)
            {
                MessageBox.Show("MailCreate: " + ex.Message);
            }
            return mail;
        }
        public bool Send(string mailFrom, string password, string mailTo, string message, string subject)
        {
            string username = mailFrom.Split('@')[0];
            MailMessage mailmessage = CreateMailMessage(mailFrom, mailTo, message, subject);
            bool returnValue=false;
            try
            {
                CreateSMTPClient(mailmessage, password, username);
                returnValue = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mail send: " + ex.Message);
            }
            return returnValue;
        }
        private void CreateSMTPClient(MailMessage mail, string password, string username)
        {

            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(username, password);
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Send(mail);
            mail.Dispose();
        }
        private string FormMessage(IEnumerable<SyndicationItem> feeds)
        {
            string message = String.Empty;
            foreach (var feed in feeds)
            {
                message += feed.Title.Text + " " + feed.Links.First().Uri +
                    Environment.NewLine;
            }
            return message;
        }
        public  void SendToRecipients(List<string> recipients, List<SyndicationItem> items)
        {
            string message = FormMessage(items);
            string subject = "You rss feeds by " + DateTime.Now;
            string sender = "phpmailerlaba@gmail.com";
            string password = "phplabapass";
            foreach (var recipient in recipients)
            {
                //тоже можно параллельно
                try
                {
                    Send(sender, password, recipient, message, subject);
                }
                catch { }
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
        private void SendMail()
        {
            MessageBox.Show("mail sent");
        }

        private void ButtonAddRecipient_Click(object sender, EventArgs e)
        {
            ListBoxRecipients.Items.Add(TextBoxNewRecipient.Text);
            TextBoxNewRecipient.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("phpmailerlaba@gmail.com");
                mail.To.Add("andy844551@gmail.com");
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";

                SmtpServer.Port = 587;
                //SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                //SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new NetworkCredential("phpmailerlaba", "phplabapass");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
