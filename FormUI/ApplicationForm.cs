using craXcel;
using CraxcelLibrary.Applications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using static CraxcelLibrary.Enums;

namespace FormUI
{
    public partial class ApplicationForm : Form
    {
        private DirectoryInfo UserHomeDirectory {get;}

        public ApplicationForm()
        {
            InitializeComponent();

            var userProfileSpecialFolder = Environment.SpecialFolder.UserProfile;

            UserHomeDirectory = new DirectoryInfo(Environment.GetFolderPath(userProfileSpecialFolder));
        }

        private void CreateOutputFolderIfNotExists()
        {
            var outputFolder = new DirectoryInfo(Path.Combine(UserHomeDirectory.FullName, "craxcel"));
            if (outputFolder.Exists == false)
            {
                outputFolder.Create();
            }
        }

        private void addFilesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = UserHomeDirectory.FullName,
                Multiselect = true
            };

            openFileDialog.ShowDialog();

            fileListBox.Items.AddRange(openFileDialog.FileNames);
        }

        private void removeSelectedButton_Click(object sender, EventArgs e)
        {
            fileListBox.Items.Remove(fileListBox.SelectedItem);
        }

        private void clearAllFilesButton_Click(object sender, EventArgs e)
        {
            fileListBox.Items.Clear();
        }

        private void unlockFilesButton_Click(object sender, EventArgs e)
        {
            unlockFilesButton.Enabled = false;        
            
            progressBar.Maximum = fileListBox.Items.Count;

            var filesUnlocked = 0;

            foreach (var item in fileListBox.Items)
            {
                var filePath = item.ToString();
                var wasSuccessful = CraxcelLibrary.Program.Main(filePath, outputFolderLabel.Text);

                if (wasSuccessful)
                {
                    filesUnlocked++;
                }

                progressBar.Value++;
            }

            MessageBox.Show($"{filesUnlocked}/{fileListBox.Items.Count} files unlocked successfully.\nCheck the log for further details.", "Completed");

            fileListBox.Items.Clear();

            unlockFilesButton.Enabled = true;
        }

        private void changeOutputFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
            {
                RootFolder = Environment.SpecialFolder.UserProfile
            };

            folderBrowserDialog.ShowDialog();
        }
    }
}
