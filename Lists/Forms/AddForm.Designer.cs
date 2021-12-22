
namespace WindowsFormsApp1
{
    partial class AddForm
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
            this.DataTextBox = new System.Windows.Forms.TextBox();
            this.IndexCounter = new System.Windows.Forms.NumericUpDown();
            this.BeforeButton = new System.Windows.Forms.Button();
            this.ReplaceButton = new System.Windows.Forms.Button();
            this.AfterButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.IndexCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTextBox
            // 
            this.DataTextBox.Location = new System.Drawing.Point(12, 12);
            this.DataTextBox.Name = "DataTextBox";
            this.DataTextBox.Size = new System.Drawing.Size(211, 20);
            this.DataTextBox.TabIndex = 0;
            // 
            // IndexCounter
            // 
            this.IndexCounter.Location = new System.Drawing.Point(64, 38);
            this.IndexCounter.Name = "IndexCounter";
            this.IndexCounter.Size = new System.Drawing.Size(95, 20);
            this.IndexCounter.TabIndex = 1;
            // 
            // BeforeButton
            // 
            this.BeforeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BeforeButton.Location = new System.Drawing.Point(5, 64);
            this.BeforeButton.Name = "BeforeButton";
            this.BeforeButton.Size = new System.Drawing.Size(75, 23);
            this.BeforeButton.TabIndex = 2;
            this.BeforeButton.Text = "Before";
            this.BeforeButton.UseVisualStyleBackColor = true;
            this.BeforeButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // ReplaceButton
            // 
            this.ReplaceButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ReplaceButton.Location = new System.Drawing.Point(167, 64);
            this.ReplaceButton.Name = "ReplaceButton";
            this.ReplaceButton.Size = new System.Drawing.Size(75, 23);
            this.ReplaceButton.TabIndex = 3;
            this.ReplaceButton.Text = "Replace";
            this.ReplaceButton.UseVisualStyleBackColor = true;
            this.ReplaceButton.Click += new System.EventHandler(this.ReplaceButton_Click);
            // 
            // AfterButton
            // 
            this.AfterButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AfterButton.Location = new System.Drawing.Point(86, 64);
            this.AfterButton.Name = "AfterButton";
            this.AfterButton.Size = new System.Drawing.Size(75, 23);
            this.AfterButton.TabIndex = 4;
            this.AfterButton.Text = "After";
            this.AfterButton.UseVisualStyleBackColor = true;
            this.AfterButton.Click += new System.EventHandler(this.AfterButton_Click);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 104);
            this.Controls.Add(this.AfterButton);
            this.Controls.Add(this.ReplaceButton);
            this.Controls.Add(this.BeforeButton);
            this.Controls.Add(this.IndexCounter);
            this.Controls.Add(this.DataTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AddForm";
            ((System.ComponentModel.ISupportInitialize)(this.IndexCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DataTextBox;
        private System.Windows.Forms.NumericUpDown IndexCounter;
        private System.Windows.Forms.Button BeforeButton;
        private System.Windows.Forms.Button ReplaceButton;
        private System.Windows.Forms.Button AfterButton;
    }
}