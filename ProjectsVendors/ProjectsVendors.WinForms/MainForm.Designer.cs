namespace ProjectsVendors.WinForms
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
            this.projectIdLabel = new System.Windows.Forms.Label();
            this.projectId = new System.Windows.Forms.TextBox();
            this.editProject = new System.Windows.Forms.Button();
            this.workspace = new System.Windows.Forms.Panel();
            this.newProject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // projectIdLabel
            // 
            this.projectIdLabel.AutoSize = true;
            this.projectIdLabel.Location = new System.Drawing.Point(12, 15);
            this.projectIdLabel.Name = "projectIdLabel";
            this.projectIdLabel.Size = new System.Drawing.Size(52, 13);
            this.projectIdLabel.TabIndex = 0;
            this.projectIdLabel.Text = "Project Id";
            // 
            // projectId
            // 
            this.projectId.Location = new System.Drawing.Point(73, 12);
            this.projectId.Name = "projectId";
            this.projectId.Size = new System.Drawing.Size(100, 20);
            this.projectId.TabIndex = 1;
            // 
            // editProject
            // 
            this.editProject.Location = new System.Drawing.Point(195, 10);
            this.editProject.Name = "editProject";
            this.editProject.Size = new System.Drawing.Size(116, 23);
            this.editProject.TabIndex = 2;
            this.editProject.Text = "Edit Project";
            this.editProject.UseVisualStyleBackColor = true;
            this.editProject.Click += new System.EventHandler(this.editProject_Click);
            // 
            // workspace
            // 
            this.workspace.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.workspace.Location = new System.Drawing.Point(0, 44);
            this.workspace.Name = "workspace";
            this.workspace.Size = new System.Drawing.Size(914, 350);
            this.workspace.TabIndex = 3;
            // 
            // newProject
            // 
            this.newProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newProject.Location = new System.Drawing.Point(786, 10);
            this.newProject.Name = "newProject";
            this.newProject.Size = new System.Drawing.Size(116, 23);
            this.newProject.TabIndex = 4;
            this.newProject.Text = "New Project";
            this.newProject.UseVisualStyleBackColor = true;
            this.newProject.Click += new System.EventHandler(this.newProject_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 394);
            this.Controls.Add(this.newProject);
            this.Controls.Add(this.workspace);
            this.Controls.Add(this.editProject);
            this.Controls.Add(this.projectId);
            this.Controls.Add(this.projectIdLabel);
            this.MaximumSize = new System.Drawing.Size(930, 433);
            this.MinimumSize = new System.Drawing.Size(930, 433);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label projectIdLabel;
        private System.Windows.Forms.TextBox projectId;
        private System.Windows.Forms.Button editProject;
        private System.Windows.Forms.Panel workspace;
        private System.Windows.Forms.Button newProject;
    }
}

