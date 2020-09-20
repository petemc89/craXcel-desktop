using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormUI
{
    public partial class UserOptionsForm : Form
    {
        public UserOptionsForm()
        {
            InitializeComponent();
            unlockVBACheckbox.Checked = CraxcelLibrary.UserOptions.UnlockVBA;
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            SetValues();

            this.Close();
        }

        private void resetToDefaultButton_Click(object sender, EventArgs e)
        {
            unlockVBACheckbox.Checked = true;

            SetValues();
        }

        private void SetValues()
        {
            CraxcelLibrary.UserOptions.UnlockVBA = unlockVBACheckbox.Checked;
        }
    }
}
