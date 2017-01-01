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
    }
}