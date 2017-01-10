using System;
using System.Windows.Forms;
using Csla;
using CslaExtremeDemos.Business;

namespace CslaExtremeDemos.WindowsForms
{
    public partial class UserEditLocal : UserControl, IClose
    {
        private User _user;

        private UserEditLocal()
        {
            InitializeComponent();
        }

        public UserEditLocal(int userId) : this()
        {
            _user = User.GetUser(userId);

            // Bind ComboBox list datasources first
            maritalStatusBindingSource.EnumToDataSource(typeof(CivilStatus));
            maritalStatus.DataSource = maritalStatusBindingSource;
            maritalStatus.DisplayMember = "Description";
            maritalStatus.ValueMember = "Key";

            rolesBindingSource.EnumToDataSource(typeof(Roles));
            role.DataSource = rolesBindingSource;
            role.DisplayMember = "Description";
            role.ValueMember = "Key";

            deptNVLBindingSource.LocalRebind(DeptNVL.GetDeptNVL());
            deptId.DataSource = deptNVLBindingSource;
            deptId.DisplayMember = "Value";
            deptId.ValueMember = "Key";

            maritalStatus.AutoCompleteCustomSource.AddRange(EnumExtension.EnumToArray(typeof(CivilStatus)));
            role.AutoCompleteCustomSource.AddRange(EnumExtension.EnumToArray(typeof(Roles)));
            deptId.AutoCompleteCustomSource.AddRange(EnumExtension.NvlToArray(DeptNVL.GetDeptNVL()));

            BindUI();
        }

        private void BindUI()
        {
            // Bind dataobjects - starting with root object, child, grandchild and so on...
            userBindingSource.LocalRebind(_user, true);
        }

        private void UnbindUI(bool cancel)
        {
            // Unbind in the opposite sequence of BindUI
            userBindingSource.LocalUnbind(cancel, true);
        }

        private void undo_Click(object sender, EventArgs e)
        {
            if (!_user.IsDirty)
                return;

            UnbindUI(true);
            BindUI();
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (!_user.IsSavable)
                return;

            UnbindUI(false);
            try
            {
                _user = _user.Save();
                MessageBox.Show("Order saved.");
            }
            catch (DataPortalException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                BindUI();
            }
        }

        private void maritalStatus_Validated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex == -1)
                userBindingSource.ResetBindings(false);
        }

        private void role_Validated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex == -1)
                userBindingSource.ResetBindings(false);
        }

        private void deptId_Validated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex == -1)
            {
                (sender as ComboBox).Text = string.Empty;
                userBindingSource.ResetBindings(false);
            }
        }

        #region Implement IClose member

        public void Close()
        {
            userBindingSource.LocalUnbind(true, true);
        }

        #endregion
    }
}