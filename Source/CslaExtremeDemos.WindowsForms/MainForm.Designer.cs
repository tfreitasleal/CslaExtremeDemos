namespace CslaExtremeDemos.WindowsForms
{
    partial class MainForm
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.usersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersContribMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersLocalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departmentsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workspace = new System.Windows.Forms.Panel();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersMenuItem,
            this.usersContribMenuItem,
            this.usersLocalMenuItem,
            this.departmentsMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(784, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "mainMenu";
            // 
            // usersMenuItem
            // 
            this.usersMenuItem.Name = "usersMenuItem";
            this.usersMenuItem.Size = new System.Drawing.Size(47, 20);
            this.usersMenuItem.Text = "Users";
            this.usersMenuItem.Click += new System.EventHandler(this.usersMenuItem_Click);
            // 
            // usersContribMenuItem
            // 
            this.usersContribMenuItem.Name = "usersContribMenuItem";
            this.usersContribMenuItem.Size = new System.Drawing.Size(133, 20);
            this.usersContribMenuItem.Text = "Users (CslaContrib)";
            this.usersContribMenuItem.Click += new System.EventHandler(this.usersContribMenuItem_Click);
            // 
            // usersLocalMenuItem
            // 
            this.usersLocalMenuItem.Name = "usersLocalMenuItem";
            this.usersLocalMenuItem.Size = new System.Drawing.Size(96, 20);
            this.usersLocalMenuItem.Text = "Users (local)";
            this.usersLocalMenuItem.Click += new System.EventHandler(this.usersLocalMenuItem_Click);
            // 
            // departmentsMenuItem
            // 
            this.departmentsMenuItem.Name = "departmentsMenuItem";
            this.departmentsMenuItem.Size = new System.Drawing.Size(87, 20);
            this.departmentsMenuItem.Text = "Departments";
            this.departmentsMenuItem.Click += new System.EventHandler(this.departmentsMenuItem_Click);
            // 
            // workspace
            // 
            this.workspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workspace.Location = new System.Drawing.Point(0, 24);
            this.workspace.Name = "workspace";
            this.workspace.Size = new System.Drawing.Size(784, 537);
            this.workspace.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.workspace);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "CSLA .NET Tests";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem usersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersContribMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departmentsMenuItem;
        private System.Windows.Forms.Panel workspace;
        private System.Windows.Forms.ToolStripMenuItem usersLocalMenuItem;
    }
}

