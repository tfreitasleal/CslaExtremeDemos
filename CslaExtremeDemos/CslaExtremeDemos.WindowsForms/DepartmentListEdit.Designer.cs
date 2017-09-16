namespace CslaExtremeDemos.WindowsForms
{
    partial class DepartmentListEdit
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepartmentListEdit));
            this.bindingSourceRefresh = new Csla.Windows.BindingSourceRefresh(this.components);
            this.deptCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.deptCollectionBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deptCollectionDataGridView = new System.Windows.Forms.DataGridView();
            this.deptId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptCollectionBindingNavigator)).BeginInit();
            this.deptCollectionBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deptCollectionDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // deptCollectionBindingSource
            // 
            this.deptCollectionBindingSource.DataSource = typeof(CslaExtremeDemos.Business.DeptItem);
            this.bindingSourceRefresh.SetReadValuesOnChange(this.deptCollectionBindingSource, true);
            // 
            // deptCollectionBindingNavigator
            // 
            this.deptCollectionBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.deptCollectionBindingNavigator.BindingSource = this.deptCollectionBindingSource;
            this.deptCollectionBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.deptCollectionBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.deptCollectionBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.deptCollectionBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.deptCollectionBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.deptCollectionBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.deptCollectionBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.deptCollectionBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.deptCollectionBindingNavigator.Name = "deptCollectionBindingNavigator";
            this.deptCollectionBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.deptCollectionBindingNavigator.Size = new System.Drawing.Size(407, 25);
            this.deptCollectionBindingNavigator.TabIndex = 0;
            this.deptCollectionBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // deptCollectionDataGridView
            // 
            this.deptCollectionDataGridView.AutoGenerateColumns = false;
            this.deptCollectionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deptCollectionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deptId,
            this.deptName,
            this.isActive});
            this.deptCollectionDataGridView.DataSource = this.deptCollectionBindingSource;
            this.deptCollectionDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deptCollectionDataGridView.Location = new System.Drawing.Point(0, 25);
            this.deptCollectionDataGridView.Name = "deptCollectionDataGridView";
            this.deptCollectionDataGridView.Size = new System.Drawing.Size(407, 245);
            this.deptCollectionDataGridView.TabIndex = 1;
            this.deptCollectionDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.deptCollectionDataGridView_DataError);
            // 
            // deptId
            // 
            this.deptId.DataPropertyName = "DeptId";
            this.deptId.HeaderText = "Dept. Id";
            this.deptId.MinimumWidth = 75;
            this.deptId.Name = "deptId";
            this.deptId.Width = 75;
            // 
            // deptName
            // 
            this.deptName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.deptName.DataPropertyName = "DeptName";
            this.deptName.HeaderText = "Department Name";
            this.deptName.Name = "deptName";
            // 
            // isActive
            // 
            this.isActive.DataPropertyName = "IsActive";
            this.isActive.HeaderText = "Is Active";
            this.isActive.MinimumWidth = 75;
            this.isActive.Name = "isActive";
            this.isActive.Width = 75;
            // 
            // DepartmentListEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 270);
            this.Controls.Add(this.deptCollectionDataGridView);
            this.Controls.Add(this.deptCollectionBindingNavigator);
            this.MaximumSize = new System.Drawing.Size(423, 309);
            this.MinimumSize = new System.Drawing.Size(423, 309);
            this.Name = "DepartmentListEdit";
            this.Text = "Departments";
            this.Load += new System.EventHandler(this.DepartmentListEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptCollectionBindingNavigator)).EndInit();
            this.deptCollectionBindingNavigator.ResumeLayout(false);
            this.deptCollectionBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deptCollectionDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Csla.Windows.BindingSourceRefresh bindingSourceRefresh;
        private System.Windows.Forms.BindingSource deptCollectionBindingSource;
        private System.Windows.Forms.BindingNavigator deptCollectionBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DataGridView deptCollectionDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn deptId;
        private System.Windows.Forms.DataGridViewTextBoxColumn deptName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isActive;
    }
}