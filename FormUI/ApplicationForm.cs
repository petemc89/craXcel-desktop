using craXcel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FormUI
{
    public partial class ApplicationForm : Form
    {
        private List<ILockedFile> LockedFiles { get; set; } = new List<ILockedFile>();

        public ApplicationForm()
        {
            InitializeComponent();
        }

        private void addFilesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = "c:\\",
                RestoreDirectory = true,
                Multiselect = true
            };

            openFileDialog.ShowDialog();

            fileListBox.Items.AddRange(openFileDialog.FileNames);

            foreach (var fileName in openFileDialog.FileNames)
            {
                LockedFiles.Add(new Excel(fileName));
            }
        }

        private void removeSelectedButton_Click(object sender, EventArgs e)
        {

        }

        private void clearAllFilesButton_Click(object sender, EventArgs e)
        {

        }

        private void runButton_Click(object sender, EventArgs e)
        {
            foreach (var file in LockedFiles)
            {
                file.Unlock();
            }
        }
    }
}
