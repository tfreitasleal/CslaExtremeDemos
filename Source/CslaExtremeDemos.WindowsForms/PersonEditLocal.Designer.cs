namespace CslaExtremeDemos.WindowsForms
{
    partial class PersonEditLocal
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
            System.Windows.Forms.Label personIdLabel;
            System.Windows.Forms.Label firstNameLabel;
            System.Windows.Forms.Label middleNameLabel;
            System.Windows.Forms.Label lastNameLabel;
            System.Windows.Forms.Label roleLabel;
            System.Windows.Forms.Label deptIdLabel;
            this.maritalStatusLabel = new System.Windows.Forms.Label();
            this.errorWarnInfoProvider = new CslaContrib.Windows.ErrorWarnInfoProvider(this.components);
            this.personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceRefresh = new Csla.Windows.BindingSourceRefresh(this.components);
            this.deptNVLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.maritalStatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rolesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.personId = new System.Windows.Forms.Label();
            this.firstName = new System.Windows.Forms.TextBox();
            this.middleName = new System.Windows.Forms.TextBox();
            this.lastName = new System.Windows.Forms.TextBox();
            this.maritalStatus = new System.Windows.Forms.ComboBox();
            this.role = new System.Windows.Forms.ComboBox();
            this.deptId = new System.Windows.Forms.ComboBox();
            this.undo = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            personIdLabel = new System.Windows.Forms.Label();
            firstNameLabel = new System.Windows.Forms.Label();
            middleNameLabel = new System.Windows.Forms.Label();
            lastNameLabel = new System.Windows.Forms.Label();
            roleLabel = new System.Windows.Forms.Label();
            deptIdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorWarnInfoProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptNVLBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maritalStatusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // personIdLabel
            // 
            personIdLabel.AutoSize = true;
            personIdLabel.Location = new System.Drawing.Point(27, 18);
            personIdLabel.Name = "personIdLabel";
            personIdLabel.Size = new System.Drawing.Size(55, 13);
            personIdLabel.TabIndex = 0;
            personIdLabel.Text = "Person Id:";
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new System.Drawing.Point(27, 43);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new System.Drawing.Size(60, 13);
            firstNameLabel.TabIndex = 2;
            firstNameLabel.Text = "First Name:";
            // 
            // middleNameLabel
            // 
            middleNameLabel.AutoSize = true;
            middleNameLabel.Location = new System.Drawing.Point(27, 68);
            middleNameLabel.Name = "middleNameLabel";
            middleNameLabel.Size = new System.Drawing.Size(72, 13);
            middleNameLabel.TabIndex = 4;
            middleNameLabel.Text = "Middle Name:";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new System.Drawing.Point(27, 93);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new System.Drawing.Size(61, 13);
            lastNameLabel.TabIndex = 6;
            lastNameLabel.Text = "Last Name:";
            // 
            // roleLabel
            // 
            roleLabel.AutoSize = true;
            roleLabel.Location = new System.Drawing.Point(27, 143);
            roleLabel.Name = "roleLabel";
            roleLabel.Size = new System.Drawing.Size(32, 13);
            roleLabel.TabIndex = 10;
            roleLabel.Text = "Role:";
            // 
            // deptIdLabel
            // 
            deptIdLabel.AutoSize = true;
            deptIdLabel.Location = new System.Drawing.Point(27, 168);
            deptIdLabel.Name = "deptIdLabel";
            deptIdLabel.Size = new System.Drawing.Size(33, 13);
            deptIdLabel.TabIndex = 12;
            deptIdLabel.Text = "Dept:";
            // 
            // maritalStatusLabel
            // 
            this.maritalStatusLabel.AutoSize = true;
            this.maritalStatusLabel.Location = new System.Drawing.Point(27, 118);
            this.maritalStatusLabel.Name = "maritalStatusLabel";
            this.maritalStatusLabel.Size = new System.Drawing.Size(74, 13);
            this.maritalStatusLabel.TabIndex = 8;
            this.maritalStatusLabel.Text = "Marital Status:";
            // 
            // errorWarnInfoProvider
            // 
            this.errorWarnInfoProvider.ContainerControl = this;
            this.errorWarnInfoProvider.DataSource = this.personBindingSource;
            // 
            // personBindingSource
            // 
            this.personBindingSource.AllowNew = false;
            this.personBindingSource.DataSource = typeof(CslaExtremeDemos.Business.Person);
            this.bindingSourceRefresh.SetReadValuesOnChange(this.personBindingSource, true);
            // 
            // deptNVLBindingSource
            // 
            this.deptNVLBindingSource.DataSource = typeof(CslaExtremeDemos.Business.DeptNVL);
            this.bindingSourceRefresh.SetReadValuesOnChange(this.deptNVLBindingSource, true);
            // 
            // maritalStatusBindingSource
            // 
            this.maritalStatusBindingSource.AllowNew = false;
            this.maritalStatusBindingSource.DataSource = typeof(CslaExtremeDemos.Business.Roles);
            this.bindingSourceRefresh.SetReadValuesOnChange(this.maritalStatusBindingSource, true);
            // 
            // rolesBindingSource
            // 
            this.rolesBindingSource.AllowNew = false;
            this.rolesBindingSource.DataSource = typeof(CslaExtremeDemos.Business.Roles);
            this.bindingSourceRefresh.SetReadValuesOnChange(this.rolesBindingSource, true);
            // 
            // personId
            // 
            this.personId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.personBindingSource, "PersonId", true));
            this.personId.Location = new System.Drawing.Point(115, 18);
            this.personId.Name = "personId";
            this.personId.Size = new System.Drawing.Size(87, 13);
            this.personId.TabIndex = 1;
            this.personId.Text = "label1";
            // 
            // firstName
            // 
            this.firstName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.personBindingSource, "FirstName", true));
            this.firstName.Location = new System.Drawing.Point(115, 40);
            this.firstName.MaxLength = 50;
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(350, 20);
            this.firstName.TabIndex = 3;
            // 
            // middleName
            // 
            this.middleName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.personBindingSource, "MiddleName", true));
            this.middleName.Location = new System.Drawing.Point(115, 65);
            this.middleName.MaxLength = 50;
            this.middleName.Name = "middleName";
            this.middleName.Size = new System.Drawing.Size(350, 20);
            this.middleName.TabIndex = 5;
            // 
            // lastName
            // 
            this.lastName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.personBindingSource, "LastName", true));
            this.lastName.Location = new System.Drawing.Point(115, 90);
            this.lastName.MaxLength = 50;
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(350, 20);
            this.lastName.TabIndex = 7;
            // 
            // maritalStatus
            // 
            this.maritalStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.maritalStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.maritalStatus.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.personBindingSource, "MaritalStatus", true));
            this.maritalStatus.FormattingEnabled = true;
            this.maritalStatus.Location = new System.Drawing.Point(115, 114);
            this.maritalStatus.Name = "maritalStatus";
            this.maritalStatus.Size = new System.Drawing.Size(200, 21);
            this.maritalStatus.TabIndex = 9;
            this.maritalStatus.Validated += new System.EventHandler(this.maritalStatus_Validated);
            // 
            // role
            // 
            this.role.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.role.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.role.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.personBindingSource, "Role", true));
            this.role.FormattingEnabled = true;
            this.role.Location = new System.Drawing.Point(115, 139);
            this.role.Name = "role";
            this.role.Size = new System.Drawing.Size(200, 21);
            this.role.TabIndex = 11;
            this.role.Validated += new System.EventHandler(this.role_Validated);
            // 
            // deptId
            // 
            this.deptId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.deptId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.deptId.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.personBindingSource, "DeptId", true));
            this.deptId.DisplayMember = "Value";
            this.deptId.FormattingEnabled = true;
            this.deptId.Location = new System.Drawing.Point(115, 164);
            this.deptId.Name = "deptId";
            this.deptId.Size = new System.Drawing.Size(200, 21);
            this.deptId.TabIndex = 13;
            this.deptId.ValueMember = "Key";
            this.deptId.Validated += new System.EventHandler(this.deptId_Validated);
            // 
            // undo
            // 
            this.undo.Location = new System.Drawing.Point(30, 229);
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(75, 23);
            this.undo.TabIndex = 14;
            this.undo.Text = "Undo";
            this.undo.UseVisualStyleBackColor = true;
            this.undo.Click += new System.EventHandler(this.undo_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(686, 229);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 15;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // PersonEditLocal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.save);
            this.Controls.Add(this.undo);
            this.Controls.Add(deptIdLabel);
            this.Controls.Add(this.deptId);
            this.Controls.Add(this.maritalStatusLabel);
            this.Controls.Add(this.maritalStatus);
            this.Controls.Add(roleLabel);
            this.Controls.Add(this.role);
            this.Controls.Add(lastNameLabel);
            this.Controls.Add(this.lastName);
            this.Controls.Add(middleNameLabel);
            this.Controls.Add(this.middleName);
            this.Controls.Add(firstNameLabel);
            this.Controls.Add(this.firstName);
            this.Controls.Add(personIdLabel);
            this.Controls.Add(this.personId);
            this.Name = "PersonEditLocal";
            this.Size = new System.Drawing.Size(778, 259);
            ((System.ComponentModel.ISupportInitialize)(this.errorWarnInfoProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptNVLBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maritalStatusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Csla.Windows.BindingSourceRefresh bindingSourceRefresh;
        private System.Windows.Forms.BindingSource personBindingSource;
        private System.Windows.Forms.Label personId;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.TextBox middleName;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.ComboBox maritalStatus;
        private System.Windows.Forms.ComboBox role;
        private System.Windows.Forms.ComboBox deptId;
        private System.Windows.Forms.Button undo;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.BindingSource deptNVLBindingSource;
        private System.Windows.Forms.BindingSource maritalStatusBindingSource;
        private System.Windows.Forms.BindingSource rolesBindingSource;
        private System.Windows.Forms.Label maritalStatusLabel;
        private CslaContrib.Windows.ErrorWarnInfoProvider errorWarnInfoProvider;
    }
}
