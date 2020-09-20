using System;
using System.Diagnostics;
using System.IO;
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
            UserHomeDirectory = CraxcelLibrary.ApplicationSettings.CRAXCEL_DIR;
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

            fileListBox.Items.Remove(fileListBox.SelectedItem);

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

            var confirmation = MessageBox.Show("Ready To Start Craxcel?", "Confirm", MessageBoxButtons.YesNo);

            if (confirmation == DialogResult.No || fileListBox.Items.Count == 0)
            {
                EnableAllButtons();

                return;
            }

            progressBar.Maximum = fileListBox.Items.Count;

            var filesUnlocked = 0;

            foreach (var item in fileListBox.Items)
            {
                var filePath = item.ToString();
                var wasSuccessful = CraxcelLibrary.CraxcelProcessor.UnlockFile(filePath);

                if (wasSuccessful)
                {
                    filesUnlocked++;
                }

                progressBar.Value++;
            }

            MessageBox.Show($"{filesUnlocked}/{fileListBox.Items.Count} files unlocked.", "Complete");

            Process.Start("explorer.exe", CraxcelLibrary.ApplicationSettings.CRAXCEL_DIR.FullName);

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

        private bool AreYouSureDialog()
        {
            var result = MessageBox.Show("Ready To Start Craxcel?", "Confirm", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

    }
}
