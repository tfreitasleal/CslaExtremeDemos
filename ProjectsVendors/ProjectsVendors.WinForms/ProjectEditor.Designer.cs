namespace ProjectsVendors.WinForms
{
    partial class ProjectEditor
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
            System.Windows.Forms.Label projectIdLabel;
            System.Windows.Forms.Label projecNameLabel;
            System.Windows.Forms.Label startDateLabel;
            System.Windows.Forms.Label deliveryDateLabel;
            this.vendorsDataGridView = new System.Windows.Forms.DataGridView();
            this.projectEditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.projectIdTextBox = new System.Windows.Forms.TextBox();
            this.projecNameTextBox = new System.Windows.Forms.TextBox();
            this.startDateTextBox = new System.Windows.Forms.TextBox();
            this.deliveryDateTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.vendorIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorContactDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorPhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorEmailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isPrimaryVendorDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lastUpdatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            projectIdLabel = new System.Windows.Forms.Label();
            projecNameLabel = new System.Windows.Forms.Label();
            startDateLabel = new System.Windows.Forms.Label();
            deliveryDateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vendorsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectEditBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // projectIdLabel
            // 
            projectIdLabel.AutoSize = true;
            projectIdLabel.Location = new System.Drawing.Point(31, 21);
            projectIdLabel.Name = "projectIdLabel";
            projectIdLabel.Size = new System.Drawing.Size(55, 13);
            projectIdLabel.TabIndex = 1;
            projectIdLabel.Text = "Project Id:";
            // 
            // projecNameLabel
            // 
            projecNameLabel.AutoSize = true;
            projecNameLabel.Location = new System.Drawing.Point(211, 21);
            projecNameLabel.Name = "projecNameLabel";
            projecNameLabel.Size = new System.Drawing.Size(71, 13);
            projecNameLabel.TabIndex = 3;
            projecNameLabel.Text = "Projec Name:";
            // 
            // startDateLabel
            // 
            startDateLabel.AutoSize = true;
            startDateLabel.Location = new System.Drawing.Point(474, 21);
            startDateLabel.Name = "startDateLabel";
            startDateLabel.Size = new System.Drawing.Size(58, 13);
            startDateLabel.TabIndex = 5;
            startDateLabel.Text = "Start Date:";
            // 
            // deliveryDateLabel
            // 
            deliveryDateLabel.AutoSize = true;
            deliveryDateLabel.Location = new System.Drawing.Point(698, 21);
            deliveryDateLabel.Name = "deliveryDateLabel";
            deliveryDateLabel.Size = new System.Drawing.Size(74, 13);
            deliveryDateLabel.TabIndex = 7;
            deliveryDateLabel.Text = "Delivery Date:";
            // 
            // vendorsDataGridView
            // 
            this.vendorsDataGridView.AutoGenerateColumns = false;
            this.vendorsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vendorsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vendorIdDataGridViewTextBoxColumn,
            this.vendorNameDataGridViewTextBoxColumn,
            this.vendorContactDataGridViewTextBoxColumn,
            this.vendorPhoneDataGridViewTextBoxColumn,
            this.vendorEmailDataGridViewTextBoxColumn,
            this.isPrimaryVendorDataGridViewCheckBoxColumn,
            this.lastUpdatedDataGridViewTextBoxColumn});
            this.vendorsDataGridView.DataMember = "Vendors";
            this.vendorsDataGridView.DataSource = this.projectEditBindingSource;
            this.vendorsDataGridView.Location = new System.Drawing.Point(23, 58);
            this.vendorsDataGridView.Name = "vendorsDataGridView";
            this.vendorsDataGridView.Size = new System.Drawing.Size(855, 225);
            this.vendorsDataGridView.TabIndex = 1;
            // 
            // projectEditBindingSource
            // 
            this.projectEditBindingSource.DataSource = typeof(ProjectsVendors.Business.ProjectEdit);
            // 
            // projectIdTextBox
            // 
            this.projectIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectEditBindingSource, "ProjectId", true));
            this.projectIdTextBox.Location = new System.Drawing.Point(92, 18);
            this.projectIdTextBox.Name = "projectIdTextBox";
            this.projectIdTextBox.Size = new System.Drawing.Size(80, 20);
            this.projectIdTextBox.TabIndex = 2;
            // 
            // projecNameTextBox
            // 
            this.projecNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectEditBindingSource, "ProjecName", true));
            this.projecNameTextBox.Location = new System.Drawing.Point(288, 18);
            this.projecNameTextBox.Name = "projecNameTextBox";
            this.projecNameTextBox.Size = new System.Drawing.Size(120, 20);
            this.projecNameTextBox.TabIndex = 4;
            // 
            // startDateTextBox
            // 
            this.startDateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectEditBindingSource, "StartDate", true));
            this.startDateTextBox.Location = new System.Drawing.Point(538, 18);
            this.startDateTextBox.Name = "startDateTextBox";
            this.startDateTextBox.Size = new System.Drawing.Size(100, 20);
            this.startDateTextBox.TabIndex = 6;
            // 
            // deliveryDateTextBox
            // 
            this.deliveryDateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectEditBindingSource, "DeliveryDate", true));
            this.deliveryDateTextBox.Location = new System.Drawing.Point(778, 18);
            this.deliveryDateTextBox.Name = "deliveryDateTextBox";
            this.deliveryDateTextBox.Size = new System.Drawing.Size(100, 20);
            this.deliveryDateTextBox.TabIndex = 8;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(679, 302);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(803, 302);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 11;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // vendorIdDataGridViewTextBoxColumn
            // 
            this.vendorIdDataGridViewTextBoxColumn.DataPropertyName = "VendorId";
            this.vendorIdDataGridViewTextBoxColumn.HeaderText = "Vendor Id";
            this.vendorIdDataGridViewTextBoxColumn.Name = "vendorIdDataGridViewTextBoxColumn";
            this.vendorIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vendorNameDataGridViewTextBoxColumn
            // 
            this.vendorNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendorNameDataGridViewTextBoxColumn.DataPropertyName = "VendorName";
            this.vendorNameDataGridViewTextBoxColumn.FillWeight = 200F;
            this.vendorNameDataGridViewTextBoxColumn.HeaderText = "Vendor Name";
            this.vendorNameDataGridViewTextBoxColumn.Name = "vendorNameDataGridViewTextBoxColumn";
            this.vendorNameDataGridViewTextBoxColumn.Width = 97;
            // 
            // vendorContactDataGridViewTextBoxColumn
            // 
            this.vendorContactDataGridViewTextBoxColumn.DataPropertyName = "VendorContact";
            this.vendorContactDataGridViewTextBoxColumn.HeaderText = "Vendor Contact";
            this.vendorContactDataGridViewTextBoxColumn.Name = "vendorContactDataGridViewTextBoxColumn";
            // 
            // vendorPhoneDataGridViewTextBoxColumn
            // 
            this.vendorPhoneDataGridViewTextBoxColumn.DataPropertyName = "VendorPhone";
            this.vendorPhoneDataGridViewTextBoxColumn.HeaderText = "Vendor Phone";
            this.vendorPhoneDataGridViewTextBoxColumn.Name = "vendorPhoneDataGridViewTextBoxColumn";
            // 
            // vendorEmailDataGridViewTextBoxColumn
            // 
            this.vendorEmailDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendorEmailDataGridViewTextBoxColumn.DataPropertyName = "VendorEmail";
            this.vendorEmailDataGridViewTextBoxColumn.FillWeight = 200F;
            this.vendorEmailDataGridViewTextBoxColumn.HeaderText = "Vendor Email";
            this.vendorEmailDataGridViewTextBoxColumn.Name = "vendorEmailDataGridViewTextBoxColumn";
            this.vendorEmailDataGridViewTextBoxColumn.Width = 87;
            // 
            // isPrimaryVendorDataGridViewCheckBoxColumn
            // 
            this.isPrimaryVendorDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.isPrimaryVendorDataGridViewCheckBoxColumn.DataPropertyName = "IsPrimaryVendor";
            this.isPrimaryVendorDataGridViewCheckBoxColumn.HeaderText = "Is Primary Vendor";
            this.isPrimaryVendorDataGridViewCheckBoxColumn.Name = "isPrimaryVendorDataGridViewCheckBoxColumn";
            this.isPrimaryVendorDataGridViewCheckBoxColumn.Width = 86;
            // 
            // lastUpdatedDataGridViewTextBoxColumn
            // 
            this.lastUpdatedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.lastUpdatedDataGridViewTextBoxColumn.DataPropertyName = "LastUpdated";
            this.lastUpdatedDataGridViewTextBoxColumn.HeaderText = "Last Updated";
            this.lastUpdatedDataGridViewTextBoxColumn.Name = "lastUpdatedDataGridViewTextBoxColumn";
            this.lastUpdatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastUpdatedDataGridViewTextBoxColumn.Width = 88;
            // 
            // ProjectEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(deliveryDateLabel);
            this.Controls.Add(this.deliveryDateTextBox);
            this.Controls.Add(startDateLabel);
            this.Controls.Add(this.startDateTextBox);
            this.Controls.Add(projecNameLabel);
            this.Controls.Add(this.projecNameTextBox);
            this.Controls.Add(projectIdLabel);
            this.Controls.Add(this.projectIdTextBox);
            this.Controls.Add(this.vendorsDataGridView);
            this.Name = "ProjectEditor";
            this.Size = new System.Drawing.Size(890, 340);
            this.Load += new System.EventHandler(this.ProjectEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vendorsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectEditBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView vendorsDataGridView;
        private System.Windows.Forms.BindingSource projectEditBindingSource;
        private System.Windows.Forms.TextBox projectIdTextBox;
        private System.Windows.Forms.TextBox projecNameTextBox;
        private System.Windows.Forms.TextBox startDateTextBox;
        private System.Windows.Forms.TextBox deliveryDateTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectVendorIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorContactDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorPhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorEmailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isPrimaryVendorDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedDataGridViewTextBoxColumn;
    }
}
