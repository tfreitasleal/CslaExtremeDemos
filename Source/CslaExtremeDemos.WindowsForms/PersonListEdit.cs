using System.Windows.Forms;
using CslaExtremeDemos.Business;

namespace CslaExtremeDemos.WindowsForms
{
    public partial class PersonListEdit : UserControl
    {
        public PersonListEdit()
        {
            InitializeComponent();
        }

        private void PersonListEdit_Load(object sender, System.EventArgs e)
        {
            personListBindingSource.DataSource = PersonList.GetPersonList();
        }

        private void personListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= -1)
            {
                return;
            }


            var editPersonId = (int) personListDataGridView.Rows[e.RowIndex].Cells[0].Value;

            ClearWorkspace();
            var personEdit = new PersonEdit(editPersonId);
            workspace.Controls.Add(personEdit);
        }

        private void ClearWorkspace()
        {
            if (workspace.Controls.Count != 0)
            {
                var userControl = workspace.Controls[0] as UserControl;
                if (userControl != null)
                    userControl.Dispose();
            }

            workspace.Controls.Clear();
        }
    }
}