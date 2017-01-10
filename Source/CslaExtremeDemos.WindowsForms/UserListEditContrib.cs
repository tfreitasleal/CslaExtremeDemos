using System.Windows.Forms;
using CslaExtremeDemos.Business;

namespace CslaExtremeDemos.WindowsForms
{
    public partial class UserListEditContrib : UserControl, IClose
    {
        public UserListEditContrib()
        {
            InitializeComponent();
        }

        private void UserListEditContrib_Load(object sender, System.EventArgs e)
        {
            userListBindingSource.DataSource = UserList.GetUserList();
        }

        private void userListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= -1)
            {
                return;
            }

            var editUserId = (int) userListDataGridView.Rows[e.RowIndex].Cells[0].Value;

            ClearWorkspace();
            var userEdit = new UserEditContrib(editUserId);
            workspace.Controls.Add(userEdit);
        }

        private void ClearWorkspace()
        {
            if (workspace.Controls.Count != 0)
            {
                var userControl = workspace.Controls[0] as UserControl;
                if (userControl != null)
                    userControl.Dispose();

                workspace.Controls.Clear();
            }
        }

        #region Implement IClose member

        public void Close()
        {
            if (workspace.Controls.Count != 0)
            {
                var iClose = workspace.Controls[0] as IClose;
                if (iClose != null)
                    iClose.Close();

                ClearWorkspace();
            }
        }

        #endregion
    }
}