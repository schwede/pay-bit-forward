using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PayBitForward.Models;
using PayBitForward.Messaging;

namespace PayBitForwardGui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PersistenceManager persistenceManager = new PersistenceManager();
            seederDataGridView.DataSource = persistenceManager.ReadContent();
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
                    FileInfo file = new FileInfo(seedTextBox.Text);
                    Content newContent = new Content()
                    {
                        FileName = file.Name,
                        LocalPath = seedTextBox.Text,
                        Description = descriptionTextBox.Text,
                        ByteSize = (int) file.Length,

                        // add files hash
                    };

                    PersistenceManager persistenceManager = new PersistenceManager();
                    persistenceManager.WriteContent(newContent);
                    seederDataGridView.DataSource = persistenceManager.ReadContent();

                    // Needs to start seeding the new content.
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
                    // Start downloading selected Content from seeders
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
            // use the searchTextBox.Text as the query in a get content list request
            // update the searchDataGridView with the list of Content objects recieved
        }
    }
}
