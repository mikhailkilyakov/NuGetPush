namespace NuGetPush
{
    partial class PushForm
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
            this.packageLabel = new System.Windows.Forms.Label();
            this.packageFilePathTextBox = new System.Windows.Forms.TextBox();
            this.nuGetSourceLabel = new System.Windows.Forms.Label();
            this.nuGetSourcesComboBox = new System.Windows.Forms.ComboBox();
            this.pushButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // packageLabel
            // 
            this.packageLabel.AutoSize = true;
            this.packageLabel.Location = new System.Drawing.Point(12, 9);
            this.packageLabel.Name = "packageLabel";
            this.packageLabel.Size = new System.Drawing.Size(93, 13);
            this.packageLabel.TabIndex = 0;
            this.packageLabel.Text = "Package file path:";
            // 
            // packageFilePathTextBox
            // 
            this.packageFilePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.packageFilePathTextBox.Location = new System.Drawing.Point(12, 25);
            this.packageFilePathTextBox.Name = "packageFilePathTextBox";
            this.packageFilePathTextBox.ReadOnly = true;
            this.packageFilePathTextBox.Size = new System.Drawing.Size(524, 20);
            this.packageFilePathTextBox.TabIndex = 2;
            // 
            // nuGetSourceLabel
            // 
            this.nuGetSourceLabel.AutoSize = true;
            this.nuGetSourceLabel.Location = new System.Drawing.Point(12, 48);
            this.nuGetSourceLabel.Name = "nuGetSourceLabel";
            this.nuGetSourceLabel.Size = new System.Drawing.Size(76, 13);
            this.nuGetSourceLabel.TabIndex = 2;
            this.nuGetSourceLabel.Text = "NuGet source:";
            // 
            // nuGetSourcesComboBox
            // 
            this.nuGetSourcesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nuGetSourcesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nuGetSourcesComboBox.FormattingEnabled = true;
            this.nuGetSourcesComboBox.Location = new System.Drawing.Point(12, 64);
            this.nuGetSourcesComboBox.Name = "nuGetSourcesComboBox";
            this.nuGetSourcesComboBox.Size = new System.Drawing.Size(492, 21);
            this.nuGetSourcesComboBox.TabIndex = 3;
            this.nuGetSourcesComboBox.SelectedIndexChanged += new System.EventHandler(this.nuGetSourcesComboBox_SelectedIndexChanged);
            // 
            // pushButton
            // 
            this.pushButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pushButton.Enabled = false;
            this.pushButton.Location = new System.Drawing.Point(380, 100);
            this.pushButton.Name = "pushButton";
            this.pushButton.Size = new System.Drawing.Size(75, 23);
            this.pushButton.TabIndex = 1;
            this.pushButton.Text = "Push";
            this.pushButton.UseVisualStyleBackColor = true;
            this.pushButton.Click += new System.EventHandler(this.pushButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(461, 100);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsButton.Location = new System.Drawing.Point(510, 64);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(26, 21);
            this.settingsButton.TabIndex = 4;
            this.settingsButton.Text = "...";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // PushForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(548, 135);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.pushButton);
            this.Controls.Add(this.nuGetSourcesComboBox);
            this.Controls.Add(this.nuGetSourceLabel);
            this.Controls.Add(this.packageFilePathTextBox);
            this.Controls.Add(this.packageLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PushForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Push package to...";
            this.Load += new System.EventHandler(this.PushForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label packageLabel;
        private System.Windows.Forms.TextBox packageFilePathTextBox;
        private System.Windows.Forms.Label nuGetSourceLabel;
        private System.Windows.Forms.ComboBox nuGetSourcesComboBox;
        private System.Windows.Forms.Button pushButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button settingsButton;
    }
}