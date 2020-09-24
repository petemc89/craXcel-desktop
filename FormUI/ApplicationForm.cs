using CraxcelLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormUI
{
    public partial class ApplicationForm : Form
    {
        public ApplicationForm()
        {
            InitializeComponent();
        }

        private void addFilesButton_Click(object sender, EventArgs e)
        {
            ToggleAllButtons(false);

            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = ApplicationSettings.CRAXCEL_DIR.FullName,
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

                foreach (var extension in ApplicationSettings.SUPPORTED_APPLICATIONS.Keys)
                {
                    sb.Append($"*{extension};");
                }

                return sb.ToString();
            }

            ToggleAllButtons(true);
        }

        private void removeSelectedButton_Click(object sender, EventArgs e)
        {
            ToggleAllButtons(false);

            var selectedItems = fileListBox.SelectedItems;

            for (int i = selectedItems.Count - 1; i >= 0; i--)
            {
                fileListBox.Items.Remove(selectedItems[i]);
            }                

            ToggleAllButtons(true);
        }

        private void clearAllFilesButton_Click(object sender, EventArgs e)
        {
            ToggleAllButtons(false);

            fileListBox.Items.Clear();

            ToggleAllButtons(true);
        }

        private void unlockFilesButton_Click(object sender, EventArgs e)
        {
            ToggleAllButtons(false);

            var confirmation = MessageBox.Show("Ready to start craXcel?", "Confirm", MessageBoxButtons.YesNo);

            if (confirmation == DialogResult.No || fileListBox.Items.Count == 0)
            {
                ToggleAllButtons(true);

                return;
            }

            List<string> filePaths = fileListBox.Items.OfType<string>().ToList();

            var logger = new TextFileLogger();

            int filesUnlocked = CraxcelProcessor.UnlockFiles(filePaths, logger);

            MessageBox.Show($"{filesUnlocked}/{filePaths.Count} files unlocked.", "Complete");

            // TO-DO - Possibly only works on Windows?           
            try
            {
                var craxcelDir = new ProcessStartInfo(ApplicationSettings.CRAXCEL_DIR.FullName)
                {
                    UseShellExecute = true,
                    Verb = "open"
                };

                var logFile = new ProcessStartInfo(logger.LogFile.FullName)
                {
                    UseShellExecute = true,
                    Verb = "open"
                };

                Process.Start(craxcelDir);
                Process.Start(logFile);
            }
            catch
            {
               
            }

            ResetForm();

            ToggleAllButtons(true);
        }

        private void openOptionsFormButton_Click(object sender, EventArgs e)
        {
            var optionsForm = new UserOptionsForm();

            optionsForm.ShowDialog();
        }

        private void ResetForm()
        {
            fileListBox.Items.Clear();
        }

        private void ToggleAllButtons(bool enableButtons)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    var btn = (Button)control;
                    btn.Enabled = enableButtons;
                }
            }
        }

        private void githubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var info = new ProcessStartInfo("https://github.com/petemc89/craXcel-desktop")
            {
                UseShellExecute = true,
                Verb = "open"
            };

            Process.Start(info);

            //Process.Start("https://github.com/petemc89/craXcel-desktop");
        }
    }
}
