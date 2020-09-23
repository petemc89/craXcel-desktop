namespace FormUI
{
    partial class ApplicationForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationForm));
            this.fileListBox = new System.Windows.Forms.ListBox();
            this.addFilesButton = new System.Windows.Forms.Button();
            this.removeSelectedButton = new System.Windows.Forms.Button();
            this.clearAllFilesButton = new System.Windows.Forms.Button();
            this.unlockFilesButton = new System.Windows.Forms.Button();
            this.fileListLabel = new System.Windows.Forms.Label();
            this.openOptionsFormButton = new System.Windows.Forms.Button();
            this.craxcelNote = new System.Windows.Forms.Label();
            this.githubLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // fileListBox
            // 
            this.fileListBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.fileListBox.ItemHeight = 17;
            this.fileListBox.Location = new System.Drawing.Point(10, 65);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.fileListBox.Size = new System.Drawing.Size(609, 310);
            this.fileListBox.TabIndex = 0;
            // 
            // addFilesButton
            // 
            this.addFilesButton.BackColor = System.Drawing.Color.SteelBlue;
            this.addFilesButton.ForeColor = System.Drawing.Color.White;
            this.addFilesButton.Location = new System.Drawing.Point(9, 12);
            this.addFilesButton.Name = "addFilesButton";
            this.addFilesButton.Size = new System.Drawing.Size(150, 30);
            this.addFilesButton.TabIndex = 1;
            this.addFilesButton.Text = "Add Files";
            this.addFilesButton.UseVisualStyleBackColor = false;
            this.addFilesButton.Click += new System.EventHandler(this.addFilesButton_Click);
            // 
            // removeSelectedButton
            // 
            this.removeSelectedButton.BackColor = System.Drawing.Color.IndianRed;
            this.removeSelectedButton.ForeColor = System.Drawing.Color.White;
            this.removeSelectedButton.Location = new System.Drawing.Point(240, 12);
            this.removeSelectedButton.Name = "removeSelectedButton";
            this.removeSelectedButton.Size = new System.Drawing.Size(150, 30);
            this.removeSelectedButton.TabIndex = 1;
            this.removeSelectedButton.Text = "Remove Selected";
            this.removeSelectedButton.UseVisualStyleBackColor = false;
            this.removeSelectedButton.Click += new System.EventHandler(this.removeSelectedButton_Click);
            // 
            // clearAllFilesButton
            // 
            this.clearAllFilesButton.BackColor = System.Drawing.Color.Maroon;
            this.clearAllFilesButton.ForeColor = System.Drawing.Color.White;
            this.clearAllFilesButton.Location = new System.Drawing.Point(465, 12);
            this.clearAllFilesButton.Name = "clearAllFilesButton";
            this.clearAllFilesButton.Size = new System.Drawing.Size(150, 30);
            this.clearAllFilesButton.TabIndex = 1;
            this.clearAllFilesButton.Text = "Clear All Files";
            this.clearAllFilesButton.UseVisualStyleBackColor = false;
            this.clearAllFilesButton.Click += new System.EventHandler(this.clearAllFilesButton_Click);
            // 
            // unlockFilesButton
            // 
            this.unlockFilesButton.BackColor = System.Drawing.Color.Green;
            this.unlockFilesButton.ForeColor = System.Drawing.Color.White;
            this.unlockFilesButton.Location = new System.Drawing.Point(240, 400);
            this.unlockFilesButton.Name = "unlockFilesButton";
            this.unlockFilesButton.Size = new System.Drawing.Size(150, 29);
            this.unlockFilesButton.TabIndex = 1;
            this.unlockFilesButton.Text = "Unlock!";
            this.unlockFilesButton.UseVisualStyleBackColor = false;
            this.unlockFilesButton.Click += new System.EventHandler(this.unlockFilesButton_Click);
            // 
            // fileListLabel
            // 
            this.fileListLabel.AutoSize = true;
            this.fileListLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fileListLabel.Location = new System.Drawing.Point(9, 48);
            this.fileListLabel.Name = "fileListLabel";
            this.fileListLabel.Size = new System.Drawing.Size(36, 17);
            this.fileListLabel.TabIndex = 3;
            this.fileListLabel.Text = "Files:";
            // 
            // openOptionsFormButton
            // 
            this.openOptionsFormButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.openOptionsFormButton.ForeColor = System.Drawing.Color.DimGray;
            this.openOptionsFormButton.Location = new System.Drawing.Point(9, 400);
            this.openOptionsFormButton.Name = "openOptionsFormButton";
            this.openOptionsFormButton.Size = new System.Drawing.Size(75, 29);
            this.openOptionsFormButton.TabIndex = 1;
            this.openOptionsFormButton.Text = "Options";
            this.openOptionsFormButton.UseVisualStyleBackColor = false;
            this.openOptionsFormButton.Click += new System.EventHandler(this.openOptionsFormButton_Click);
            // 
            // craxcelNote
            // 
            this.craxcelNote.AutoSize = true;
            this.craxcelNote.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.craxcelNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.craxcelNote.Location = new System.Drawing.Point(79, 378);
            this.craxcelNote.Name = "craxcelNote";
            this.craxcelNote.Size = new System.Drawing.Size(474, 13);
            this.craxcelNote.TabIndex = 4;
            this.craxcelNote.Text = "craXcel will never overwrite your files, it will always create an unlocked copy o" +
    "f the original.";
            // 
            // githubLink
            // 
            this.githubLink.AutoSize = true;
            this.githubLink.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.githubLink.Location = new System.Drawing.Point(571, 407);
            this.githubLink.Name = "githubLink";
            this.githubLink.Size = new System.Drawing.Size(48, 17);
            this.githubLink.TabIndex = 5;
            this.githubLink.TabStop = true;
            this.githubLink.Text = "GitHub";
            this.githubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.githubLink_LinkClicked);
            // 
            // ApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.githubLink);
            this.Controls.Add(this.craxcelNote);
            this.Controls.Add(this.openOptionsFormButton);
            this.Controls.Add(this.fileListLabel);
            this.Controls.Add(this.unlockFilesButton);
            this.Controls.Add(this.clearAllFilesButton);
            this.Controls.Add(this.removeSelectedButton);
            this.Controls.Add(this.addFilesButton);
            this.Controls.Add(this.fileListBox);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ApplicationForm";
            this.Text = "craXcel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox fileListBox;
        private System.Windows.Forms.Button addFilesButton;
        private System.Windows.Forms.Button removeSelectedButton;
        private System.Windows.Forms.Button clearAllFilesButton;
        private System.Windows.Forms.Button unlockFilesButton;
        private System.Windows.Forms.Label fileListLabel;
        private System.Windows.Forms.Button openOptionsFormButton;
        private System.Windows.Forms.Label craxcelNote;
        private System.Windows.Forms.LinkLabel githubLink;
    }
}

