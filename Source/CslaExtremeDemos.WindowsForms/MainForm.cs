using System;
using System.Windows.Forms;

namespace CslaExtremeDemos.WindowsForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void usersMenuItem_Click(object sender, EventArgs e)
        {
            ClearWorkspace();
            var userList = new UserListEdit();
            workspace.Controls.Add(userList);
        }

        private void usersContribMenuItem_Click(object sender, EventArgs e)
        {
            ClearWorkspace();
            var userListContrib = new UserListEditContrib();
            workspace.Controls.Add(userListContrib);
        }

        private void usersLocalMenuItem_Click(object sender, EventArgs e)
        {
            ClearWorkspace();
            var userListLocal = new UserListEditLocal();
            workspace.Controls.Add(userListLocal);
        }

        private void departmentsMenuItem_Click(object sender, EventArgs e)
        {
            using (var depts = new DepartmentListEdit())
            {
                depts.ShowDialog(this);
            }
        }

        private void ClearWorkspace()
        {
            if (workspace.Controls.Count != 0)
            {
                var iClose = workspace.Controls[0] as IClose;
                if (iClose != null)
                    iClose.Close();

                var userControl = workspace.Controls[0] as UserControl;
                if (userControl != null)
                    userControl.Dispose();

                workspace.Controls.Clear();
            }
        }
    }
}