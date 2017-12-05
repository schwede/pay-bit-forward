using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PayBitForward.Models;
using PayBitForward.Messaging;
using System.Net;
using System.Collections.Generic;

namespace PayBitForwardGui
{
    public partial class Form1 : Form
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Form1));
        private PersistenceManager persistenceManager;
        private JsonMessageConverter converter;
        private UdpCommunicator comm;
        private MessageRouter router;
        private IPEndPoint RegistryEndpoint;

        public Form1()
        {
            InitializeComponent();
            seederDataGridView.CellFormatting += formatBytes;

            this.FormClosing += CleanUp;

            persistenceManager = new PersistenceManager();
            seederDataGridView.DataSource = persistenceManager.ReadContent().LocalContent;
            searchDataGridView.DataSource = persistenceManager.ReadContent().RemoteContent;

            converter = new JsonMessageConverter();
            comm = new UdpCommunicator(new IPEndPoint(IPAddress.Any, 4000), converter);
            comm.Start();
            router = new MessageRouter(comm);

            router.OnConversationRequest += HandleNewConversation;

            RegistryEndpoint = new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.HostAddress), Properties.Settings.Default.HostPort);
        }

        private void CleanUp(object sender, FormClosingEventArgs args)
        {
            comm.Stop();
            // Clean up message router
        }

        private IConverser HandleNewConversation(PayBitForward.Messaging.Message mesg)
        {
            if (mesg.MessageId == MessageType.CHUNK_REQUEST)
            {
                ChunkRequest chunkReq = mesg as ChunkRequest;
                foreach(Content content in persistenceManager.ReadContent().LocalContent)
                {
                    if (content.ContentHash == chunkReq.ContentHash)
                    {
                        return new ChunkSender(content, mesg.ConversationId);
                    }
                }
            }

            throw new Exception("Not found..");
        }

        private void formatBytes(object sender, DataGridViewCellFormattingEventArgs args)
        {
            if(args == null || args.Value == null)
            {
                return;
            }

            if(args.Value.GetType() == typeof(byte[]))
            {
                var bytes = (byte[])args.Value;
                args.Value = Convert.ToBase64String(bytes);
            }
        }

        private void searchBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                saveTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void seedBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                seedTextBox.Text = openFileDialog.FileName;
            }
        }

        private void addSeedButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(seedTextBox.Text))
            {
                if (File.Exists(seedTextBox.Text))
                {
                    using (var sha2 = new System.Security.Cryptography.SHA256Managed())
                    {
                        FileInfo file = new FileInfo(seedTextBox.Text);
                        Content newContent = new Content()
                        {
                            FileName = file.Name,
                            LocalPath = seedTextBox.Text,
                            Description = descriptionTextBox.Text,
                            ByteSize = (int)file.Length,
                            ContentHash = sha2.ComputeHash(File.ReadAllBytes(file.FullName)),
                            Host = Properties.Settings.Default.HostAddress,
                            Port = Properties.Settings.Default.HostPort
                        };
                        
                        persistenceManager.WriteContent(newContent, PersistenceManager.StorageType.Local);
                        seederDataGridView.DataSource = persistenceManager.ReadContent().LocalContent;
                        RegisterContentRequest request = new RegisterContentRequest(Guid.NewGuid(), Guid.NewGuid(), 0, newContent);
                        RegisterContentSender contentSender = new RegisterContentSender(request.ConversationId, request);
                        router.AddConversation(contentSender, RegistryEndpoint);
                    }
                }
                else
                {
                    MessageBox.Show("That file does not exist", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You must specify a filename", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
           
            if (!string.IsNullOrWhiteSpace(saveTextBox.Text))
            {
                if (Directory.Exists(saveTextBox.Text))
                {
                    if (searchDataGridView.SelectedRows.Count > 0)
                    {
                        List<Content> selectedContent = new List<Content>();
                        foreach (DataGridViewRow row in searchDataGridView.SelectedRows)
                        {
                            selectedContent.Add(row.DataBoundItem as Content);
                        }
                        foreach (Content file in selectedContent)
                        {

                            Console.WriteLine(file.FileName);

                            // Read local content and search for the selected hash
                            var contentList = persistenceManager.ReadContent();

                            foreach(var toRequest in contentList.RemoteContent.Where(content => content.ContentHash == file.ContentHash))
                            {

                            }
                        }
                        // start a download conversation for each of the selected content in selectedContent
                    }
                    else
                    {
                        Console.WriteLine("Failed");
                    }
                }
                else
                {
                    MessageBox.Show("The save location provided does not exist", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You must specify a save location", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var convo = new ContentListSender(Guid.NewGuid(), searchTextBox.Text);
            convo.OnSearchResults += handleSearchResults;
            router.AddConversation(convo, RegistryEndpoint);            
        }

        private void handleSearchResults(List<Content> list)
        {
            if (InvokeRequired)
            {
                this.Invoke(new ContentListSender.SearchResults(this.handleSearchResults));
            }
            else
            {
                searchDataGridView.DataSource = list;
            }

        }

    }
}
