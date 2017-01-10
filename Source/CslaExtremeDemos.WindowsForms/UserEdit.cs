using System;
using System.Windows.Forms;
using Csla.Windows;
using CslaExtremeDemos.Business;

namespace CslaExtremeDemos.WindowsForms
{
    public partial class UserEdit : UserControl, IClose
    {
        private BindingSourceNode _bindingTree;
        private User _user;

        private UserEdit()
        {
            InitializeComponent();
        }

        public UserEdit(int userId) : this()
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

            deptNVLBindingSource.DataSource = DeptNVL.GetDeptNVL();
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
            if (_bindingTree == null)
                _bindingTree = BindingSourceHelper.InitializeBindingSourceTree(components, userBindingSource);

            _bindingTree.Bind(_user);
        }

        private bool Save()
        {
            var result = false;
            _bindingTree.Apply();
            try
            {
                _user = _user.Save();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            BindUI();
            return result;
        }

        private void undo_Click(object sender, EventArgs e)
        {
            if (!_user.IsDirty)
                return;

            _bindingTree.Cancel(_user);
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (!_user.IsSavable)
                return;

            if (Save())
                MessageBox.Show("Order saved.");
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
            _bindingTree.Close();
        }

        #endregion
    }
}