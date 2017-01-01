namespace CslaExtremeDemos.WindowsForms
{
    partial class PersonListEditLocal
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
            this.personListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.personListDataGridView = new System.Windows.Forms.DataGridView();
            this.personId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workspace = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // personListBindingSource
            // 
            this.personListBindingSource.AllowNew = false;
            this.personListBindingSource.DataSource = typeof(CslaExtremeDemos.Business.PersonInfo);
            this.bindingSourceRefresh.SetReadValuesOnChange(this.personListBindingSource, true);
            // 
            // personListDataGridView
            // 
            this.personListDataGridView.AllowUserToAddRows = false;
            this.personListDataGridView.AllowUserToDeleteRows = false;
            this.personListDataGridView.AllowUserToResizeRows = false;
            this.personListDataGridView.AutoGenerateColumns = false;
            this.personListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.personListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.personId,
            this.firstName,
            this.middleName,
            this.lastName});
            this.personListDataGridView.DataSource = this.personListBindingSource;
            this.personListDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.personListDataGridView.Location = new System.Drawing.Point(0, 0);
            this.personListDataGridView.MultiSelect = false;
            this.personListDataGridView.Name = "personListDataGridView";
            this.personListDataGridView.ReadOnly = true;
            this.personListDataGridView.RowHeadersVisible = false;
            this.personListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.personListDataGridView.ShowCellErrors = false;
            this.personListDataGridView.ShowEditingIcon = false;
            this.personListDataGridView.ShowRowErrors = false;
            this.personListDataGridView.Size = new System.Drawing.Size(781, 270);
            this.personListDataGridView.TabIndex = 1;
            this.personListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.personListDataGridView_CellDoubleClick);
            // 
            // personId
            // 
            this.personId.DataPropertyName = "PersonId";
            this.personId.Frozen = true;
            this.personId.HeaderText = "Person Id";
            this.personId.MinimumWidth = 75;
            this.personId.Name = "personId";
            this.personId.ReadOnly = true;
            this.personId.Width = 75;
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
            // PersonListEditLocal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.workspace);
            this.Controls.Add(this.personListDataGridView);
            this.Name = "PersonListEditLocal";
            this.Size = new System.Drawing.Size(781, 534);
            this.Load += new System.EventHandler(this.PersonListEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personListDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Csla.Windows.BindingSourceRefresh bindingSourceRefresh;
        private System.Windows.Forms.BindingSource personListBindingSource;
        private System.Windows.Forms.DataGridView personListDataGridView;
        private System.Windows.Forms.Panel workspace;
        private System.Windows.Forms.DataGridViewTextBoxColumn personId;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn middleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastName;
    }
}
