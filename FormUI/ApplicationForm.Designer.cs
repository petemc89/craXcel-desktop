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
            this.fileListBox = new System.Windows.Forms.ListBox();
            this.addFilesButton = new System.Windows.Forms.Button();
            this.removeSelectedButton = new System.Windows.Forms.Button();
            this.clearAllFilesButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.runButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fileListBox
            // 
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.fileListBox.ItemHeight = 21;
            this.fileListBox.Location = new System.Drawing.Point(9, 87);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.fileListBox.Size = new System.Drawing.Size(606, 298);
            this.fileListBox.TabIndex = 0;
            // 
            // addFilesButton
            // 
            this.addFilesButton.BackColor = System.Drawing.Color.SteelBlue;
            this.addFilesButton.ForeColor = System.Drawing.Color.White;
            this.addFilesButton.Location = new System.Drawing.Point(9, 21);
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
            this.removeSelectedButton.Location = new System.Drawing.Point(240, 21);
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
            this.clearAllFilesButton.Location = new System.Drawing.Point(465, 21);
            this.clearAllFilesButton.Name = "clearAllFilesButton";
            this.clearAllFilesButton.Size = new System.Drawing.Size(150, 30);
            this.clearAllFilesButton.TabIndex = 1;
            this.clearAllFilesButton.Text = "Clear All Files";
            this.clearAllFilesButton.UseVisualStyleBackColor = false;
            this.clearAllFilesButton.Click += new System.EventHandler(this.clearAllFilesButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(9, 400);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(450, 29);
            this.progressBar.TabIndex = 2;
            // 
            // runButton
            // 
            this.runButton.BackColor = System.Drawing.Color.Green;
            this.runButton.ForeColor = System.Drawing.Color.White;
            this.runButton.Location = new System.Drawing.Point(465, 399);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(150, 30);
            this.runButton.TabIndex = 1;
            this.runButton.Text = "Run!";
            this.runButton.UseVisualStyleBackColor = false;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(9, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Files:";
            // 
            // ApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.clearAllFilesButton);
            this.Controls.Add(this.removeSelectedButton);
            this.Controls.Add(this.addFilesButton);
            this.Controls.Add(this.fileListBox);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Label label1;
    }
}

