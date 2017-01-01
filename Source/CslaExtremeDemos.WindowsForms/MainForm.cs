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

        private void personsMenuItem_Click(object sender, EventArgs e)
        {
            ClearWorkspace();
            var personList = new PersonListEdit();
            workspace.Controls.Add(personList);
        }

        private void personsLocalMenuItem_Click(object sender, EventArgs e)
        {
            ClearWorkspace();
            var personListLocal = new PersonListEditLocal();
            workspace.Controls.Add(personListLocal);
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
                var userControl = workspace.Controls[0] as UserControl;
                if (userControl != null)
                    userControl.Dispose();
            }

            workspace.Controls.Clear();
        }
    }
}