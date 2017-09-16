using System;
using System.Windows.Forms;
using CslaExtremeDemos.Business;

namespace CslaExtremeDemos.WindowsForms
{
    public partial class DepartmentListEdit : Form
    {
        public DepartmentListEdit()
        {
            InitializeComponent();
        }

        private void DepartmentListEdit_Load(object sender, EventArgs e)
        {
            deptCollectionBindingSource.DataSource = DeptCollection.GetDeptCollection();
        }

        private void deptCollectionDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var deptItem = ((DataGridView) sender).Rows[e.RowIndex].DataBoundItem as DeptItem;
            if (deptItem != null)
            {
                var message = deptItem.BrokenRulesCollection.ToString();
                MessageBox.Show(this, message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}