namespace WindowsFormsApp1
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPanel = new System.Windows.Forms.Panel();
            this.SettingsGroup = new System.Windows.Forms.GroupBox();
            this.BeforeButton = new System.Windows.Forms.Button();
            this.dataLabel = new System.Windows.Forms.Label();
            this.dataTextBox = new System.Windows.Forms.TextBox();
            this.AfterButton = new System.Windows.Forms.Button();
            this.insertTextBox = new System.Windows.Forms.TextBox();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsGroup.SuspendLayout();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Location = new System.Drawing.Point(21, 27);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(957, 579);
            this.MainPanel.TabIndex = 0;
            this.MainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanel_Paint);
            this.MainPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseClick);
            this.MainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseDown);
            this.MainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseMove);
            this.MainPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseUp);
            // 
            // SettingsGroup
            // 
            this.SettingsGroup.Controls.Add(this.BeforeButton);
            this.SettingsGroup.Controls.Add(this.dataLabel);
            this.SettingsGroup.Controls.Add(this.dataTextBox);
            this.SettingsGroup.Controls.Add(this.AfterButton);
            this.SettingsGroup.Controls.Add(this.insertTextBox);
            this.SettingsGroup.Location = new System.Drawing.Point(984, 27);
            this.SettingsGroup.Name = "SettingsGroup";
            this.SettingsGroup.Size = new System.Drawing.Size(140, 579);
            this.SettingsGroup.TabIndex = 1;
            this.SettingsGroup.TabStop = false;
            // 
            // BeforeButton
            // 
            this.BeforeButton.Location = new System.Drawing.Point(10, 102);
            this.BeforeButton.Name = "BeforeButton";
            this.BeforeButton.Size = new System.Drawing.Size(75, 23);
            this.BeforeButton.TabIndex = 4;
            this.BeforeButton.Text = "Before";
            this.BeforeButton.UseVisualStyleBackColor = true;
            this.BeforeButton.Click += new System.EventHandler(this.BeforeButton_Click);
            // 
            // dataLabel
            // 
            this.dataLabel.AutoSize = true;
            this.dataLabel.Location = new System.Drawing.Point(7, 14);
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.Size = new System.Drawing.Size(33, 13);
            this.dataLabel.TabIndex = 3;
            this.dataLabel.Text = "Data:";
            // 
            // dataTextBox
            // 
            this.dataTextBox.Location = new System.Drawing.Point(10, 30);
            this.dataTextBox.Name = "dataTextBox";
            this.dataTextBox.ReadOnly = true;
            this.dataTextBox.Size = new System.Drawing.Size(118, 20);
            this.dataTextBox.TabIndex = 2;
            // 
            // AfterButton
            // 
            this.AfterButton.Location = new System.Drawing.Point(10, 131);
            this.AfterButton.Name = "AfterButton";
            this.AfterButton.Size = new System.Drawing.Size(75, 23);
            this.AfterButton.TabIndex = 1;
            this.AfterButton.Text = "After";
            this.AfterButton.UseVisualStyleBackColor = true;
            this.AfterButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // insertTextBox
            // 
            this.insertTextBox.Location = new System.Drawing.Point(10, 76);
            this.insertTextBox.MaxLength = 10;
            this.insertTextBox.Name = "insertTextBox";
            this.insertTextBox.Size = new System.Drawing.Size(118, 20);
            this.insertTextBox.TabIndex = 0;
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.Filter = "\"Text files (*.txt)|*.txt|All files (*.*)|*.*\"";
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.Filter = "\"Text files (*.txt)|*.txt|All files (*.*)|*.*\"";
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(1136, 24);
            this.Menu.TabIndex = 2;
            this.Menu.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenMenuItem,
            this.SaveMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileMenuItem.Text = "File";
            // 
            // OpenMenuItem
            // 
            this.OpenMenuItem.Name = "OpenMenuItem";
            this.OpenMenuItem.Size = new System.Drawing.Size(180, 22);
            this.OpenMenuItem.Text = "Open";
            this.OpenMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.Name = "SaveMenuItem";
            this.SaveMenuItem.Size = new System.Drawing.Size(180, 22);
            this.SaveMenuItem.Text = "Save";
            this.SaveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 618);
            this.Controls.Add(this.SettingsGroup);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.Menu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MainMenuStrip = this.Menu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.SettingsGroup.ResumeLayout(false);
            this.SettingsGroup.PerformLayout();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.GroupBox SettingsGroup;
        private System.Windows.Forms.Button AfterButton;
        private System.Windows.Forms.Label dataLabel;
        private System.Windows.Forms.TextBox dataTextBox;
        private System.Windows.Forms.TextBox insertTextBox;
        private System.Windows.Forms.Button BeforeButton;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveMenuItem;
    }
}

