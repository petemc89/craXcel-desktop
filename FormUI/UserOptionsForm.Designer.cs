namespace FormUI
{
    partial class UserOptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserOptionsForm));
            this.unlockVBACheckbox = new System.Windows.Forms.CheckBox();
            this.resetToDefaultButton = new System.Windows.Forms.Button();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // unlockVBACheckbox
            // 
            this.unlockVBACheckbox.AutoSize = true;
            this.unlockVBACheckbox.Location = new System.Drawing.Point(17, 18);
            this.unlockVBACheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.unlockVBACheckbox.Name = "unlockVBACheckbox";
            this.unlockVBACheckbox.Size = new System.Drawing.Size(169, 25);
            this.unlockVBACheckbox.TabIndex = 0;
            this.unlockVBACheckbox.Text = "Unlock VBA Projects";
            this.unlockVBACheckbox.UseVisualStyleBackColor = true;
            // 
            // resetToDefaultButton
            // 
            this.resetToDefaultButton.Location = new System.Drawing.Point(17, 162);
            this.resetToDefaultButton.Name = "resetToDefaultButton";
            this.resetToDefaultButton.Size = new System.Drawing.Size(130, 35);
            this.resetToDefaultButton.TabIndex = 1;
            this.resetToDefaultButton.Text = "Reset To Default";
            this.resetToDefaultButton.UseVisualStyleBackColor = true;
            this.resetToDefaultButton.Click += new System.EventHandler(this.resetToDefaultButton_Click);
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.Location = new System.Drawing.Point(161, 162);
            this.saveChangesButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(130, 35);
            this.saveChangesButton.TabIndex = 1;
            this.saveChangesButton.Text = "Save Changes";
            this.saveChangesButton.UseVisualStyleBackColor = true;
            this.saveChangesButton.Click += new System.EventHandler(this.saveChangesButton_Click);
            // 
            // UserOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 209);
            this.Controls.Add(this.saveChangesButton);
            this.Controls.Add(this.resetToDefaultButton);
            this.Controls.Add(this.unlockVBACheckbox);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserOptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox unlockVBACheckbox;
        private System.Windows.Forms.Button resetToDefaultButton;
        private System.Windows.Forms.Button saveChangesButton;
    }
}