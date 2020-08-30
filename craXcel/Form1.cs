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

namespace craXcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTest1_Click(object sender, EventArgs e)
        {
            var excel = new Excel("C:\\Users\\PeteM\\Desktop\\craXcel\\locked.xlsm");
            var isInterface = excel is ILockedFile;
        }
        private void btnTest2_Click(object sender, EventArgs e)
        {
            var fileBrowser = new OpenFileDialog()
            {
                Multiselect = true,
                InitialDirectory = "C:\\Users\\PeteM\\Desktop\\craXcel\\"
            };

            fileBrowser.ShowDialog();

            var files = fileBrowser.FileNames;

            List<ILockedFile> lockedFiles = new List<ILockedFile>();

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                if (fileInfo.Extension == ".xlsx")
                {
                    lockedFiles.Add(new Excel(file));
                }                    
            }

            foreach (var file in lockedFiles)
            {
                file.Unlock();
            }
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            string filepath = "C:\\Users\\PeteM\\Desktop\\craXcel\\locked.xlsm";
            var lockedFile = new Excel(filepath);
            lockedFile.Unlock();

            MessageBox.Show("Completed");
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            string filepath = "C:\\Users\\PeteM\\Desktop\\craXcel\\locked.docm";
            var lockedFile = new Word(filepath);
            lockedFile.Unlock();

            MessageBox.Show("Completed");
        }

        private void btnPowerpoint_Click(object sender, EventArgs e)
        {
            string filepath = "C:\\Users\\PeteM\\Desktop\\craXcel\\locked.pptm";
            var lockedFile = new Powerpoint(filepath);
            lockedFile.Unlock();

            MessageBox.Show("Completed");
        }


    }
}
