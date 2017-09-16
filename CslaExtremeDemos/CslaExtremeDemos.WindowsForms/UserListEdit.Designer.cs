namespace CslaExtremeDemos.WindowsForms
{
    partial class UserListEdit
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bindingSourceRefresh = new Csla.Windows.BindingSourceRefresh(this.components);
            this.userListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userListDataGridView = new System.Windows.Forms.DataGridView();
            this.userId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workspace = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // userListBindingSource
            // 
            this.userListBindingSource.AllowNew = false;
            this.userListBindingSource.DataSource = typeof(CslaExtremeDemos.Business.UserInfo);
            this.bindingSourceRefresh.SetReadValuesOnChange(this.userListBindingSource, true);
            // 
            // userListDataGridView
            // 
            this.userListDataGridView.AllowUserToAddRows = false;
            this.userListDataGridView.AllowUserToDeleteRows = false;
            this.userListDataGridView.AllowUserToResizeRows = false;
            this.userListDataGridView.AutoGenerateColumns = false;
            this.userListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userId,
            this.firstName,
            this.middleName,
            this.lastName});
            this.userListDataGridView.DataSource = this.userListBindingSource;
            this.userListDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.userListDataGridView.Location = new System.Drawing.Point(0, 0);
            this.userListDataGridView.MultiSelect = false;
            this.userListDataGridView.Name = "userListDataGridView";
            this.userListDataGridView.ReadOnly = true;
            this.userListDataGridView.RowHeadersVisible = false;
            this.userListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.userListDataGridView.ShowCellErrors = false;
            this.userListDataGridView.ShowEditingIcon = false;
            this.userListDataGridView.ShowRowErrors = false;
            this.userListDataGridView.Size = new System.Drawing.Size(781, 270);
            this.userListDataGridView.TabIndex = 1;
            this.userListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userListDataGridView_CellDoubleClick);
            // 
            // userId
            // 
            this.userId.DataPropertyName = "UserId";
            this.userId.Frozen = true;
            this.userId.HeaderText = "User Id";
            this.userId.MinimumWidth = 75;
            this.userId.Name = "userId";
            this.userId.ReadOnly = true;
            this.userId.Width = 75;
            // 
            // firstName
            // 
            this.firstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.firstName.DataPropertyName = "FirstName";
            this.firstName.HeaderText = "First Name";
            this.firstName.MinimumWidth = 150;
            this.firstName.Name = "firstName";
            this.firstName.ReadOnly = true;
            this.firstName.Width = 150;
            // 
            // middleName
            // 
            this.middleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.middleName.DataPropertyName = "MiddleName";
            this.middleName.HeaderText = "Middle Name";
            this.middleName.MinimumWidth = 150;
            this.middleName.Name = "middleName";
            this.middleName.ReadOnly = true;
            this.middleName.Width = 150;
            // 
            // lastName
            // 
            this.lastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.lastName.DataPropertyName = "LastName";
            this.lastName.HeaderText = "Last Name";
            this.lastName.MinimumWidth = 150;
            this.lastName.Name = "lastName";
            this.lastName.ReadOnly = true;
            // 
            // workspace
            // 
            this.workspace.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.workspace.Location = new System.Drawing.Point(0, 272);
            this.workspace.Name = "workspace";
            this.workspace.Size = new System.Drawing.Size(781, 262);
            this.workspace.TabIndex = 2;
            // 
            // UserListEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.workspace);
            this.Controls.Add(this.userListDataGridView);
            this.Name = "UserListEdit";
            this.Size = new System.Drawing.Size(781, 534);
            this.Load += new System.EventHandler(this.UserListEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userListDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Csla.Windows.BindingSourceRefresh bindingSourceRefresh;
        private System.Windows.Forms.BindingSource userListBindingSource;
        private System.Windows.Forms.DataGridView userListDataGridView;
        private System.Windows.Forms.Panel workspace;
        private System.Windows.Forms.DataGridViewTextBoxColumn userId;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn middleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastName;
    }
}
