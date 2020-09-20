using CraxcelLibrary;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace FormUI
{
    public partial class ApplicationForm : Form
    {
        private DirectoryInfo UserHomeDirectory { get; }

        public ApplicationForm()
        {
            InitializeComponent();
            UserHomeDirectory = ApplicationSettings.CRAXCEL_DIR;
        }

        private void addFilesButton_Click(object sender, EventArgs e)
        {
            DisableAllButtons();

            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = UserHomeDirectory.FullName,
                Multiselect = true,
                Filter = SupportedApplicationsFileDialogFilter()
            };

            openFileDialog.ShowDialog();

            foreach (var item in openFileDialog.FileNames)
            {
                if (fileListBox.Items.Contains(item) == false)
                {
                    fileListBox.Items.Add(item);
                }
            }

            string SupportedApplicationsFileDialogFilter()
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("Supported Applications |");

                foreach (var extension in CraxcelLibrary.ApplicationSettings.SUPPORTED_APPLICATIONS.Keys)
                {
                    sb.Append($"*{extension};");
                }

                return sb.ToString();
            }

            EnableAllButtons();
        }

        private void removeSelectedButton_Click(object sender, EventArgs e)
        {
            DisableAllButtons();

            var selectedItems = fileListBox.SelectedItems;

            for (int i = selectedItems.Count - 1; i >= 0; i--)
            {
                fileListBox.Items.Remove(selectedItems[i]);
            }                

            EnableAllButtons();
        }

        private void clearAllFilesButton_Click(object sender, EventArgs e)
        {
            DisableAllButtons();

            fileListBox.Items.Clear();

            EnableAllButtons();
        }

        private void unlockFilesButton_Click(object sender, EventArgs e)
        {
            DisableAllButtons();

            var confirmation = MessageBox.Show("Ready to start craXcel?", "Confirm", MessageBoxButtons.YesNo);

            if (confirmation == DialogResult.No || fileListBox.Items.Count == 0)
            {
                EnableAllButtons();

                return;
            }

            progressBar.Maximum = fileListBox.Items.Count;

            var logger = new Logger();
            logger.Add($"craXcel started");
            logger.Add($"{fileListBox.Items.Count} files selected");

            var filesUnlocked = 0;

            foreach (var item in fileListBox.Items)
            {
                var filePath = item.ToString();
                var file = new FileInfo(filePath);

                var wasSuccessful = CraxcelProcessor.UnlockFile(filePath, logger);

                if (wasSuccessful)
                {
                    logger.Add($"Successfully unlocked: {file.Name} ({file.FullName})");
                    filesUnlocked++;
                }
                else
                {
                    logger.Add($"Failed to unlock: {file.Name} ({file.FullName})");
                }

                progressBar.Value++;
            }

            logger.Add("craXcel finished");

            logger.Save();

            MessageBox.Show($"{filesUnlocked}/{fileListBox.Items.Count} files unlocked.", "Complete");

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start("explorer.exe", ApplicationSettings.CRAXCEL_DIR.FullName);
            }

            ResetForm();

            EnableAllButtons();
        }

        private void openOptionsFormButton_Click(object sender, EventArgs e)
        {
            var optionsForm = new UserOptionsForm();

            optionsForm.Show();
        }

        private void ResetForm()
        {
            fileListBox.Items.Clear();
            progressBar.Value = 0;
        }

        private void DisableAllButtons()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    var btn = (Button)control;
                    btn.Enabled = false;
                }
            }
        }

        private void EnableAllButtons()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    var btn = (Button)control;
                    btn.Enabled = true;
                }
            }
        }
    }
}
