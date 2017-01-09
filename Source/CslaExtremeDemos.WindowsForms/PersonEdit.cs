using System;
using System.Windows.Forms;
using Csla;
using CslaContrib.Windows;
using CslaExtremeDemos.Business;

namespace CslaExtremeDemos.WindowsForms
{
    public partial class PersonEdit : UserControl, IClose
    {
        private Person _person;

        private PersonEdit()
        {
            InitializeComponent();
        }

        public PersonEdit(int personId) : this()
        {
            _person = Person.GetPerson(personId);

            // Bind ComboBox list datasources first
            maritalStatusBindingSource.EnumToDataSource(typeof(CivilStatus));
            maritalStatus.DataSource = maritalStatusBindingSource;
            maritalStatus.DisplayMember = "Description";
            maritalStatus.ValueMember = "Key";

            rolesBindingSource.EnumToDataSource(typeof(Roles));
            role.DataSource = rolesBindingSource;
            role.DisplayMember = "Description";
            role.ValueMember = "Key";

            deptNVLBindingSource.Rebind(DeptNVL.GetDeptNVL());
            deptId.DataSource = deptNVLBindingSource;
            deptId.DisplayMember = "Value";
            deptId.ValueMember = "Key";

            BindUI();
        }

        private void BindUI()
        {
            // Bind dataobjects - starting with root object, child, grandchild and so on...
            personBindingSource.Rebind(_person, true);
        }

        private void UnbindUI(bool cancel)
        {
            // Unbind in the opposite sequence of BindUI
            personBindingSource.Unbind(cancel, true);
        }

        private void undo_Click(object sender, EventArgs e)
        {
            if (!_person.IsDirty)
                return;

            UnbindUI(true);
            BindUI();
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (!_person.IsSavable)
                return;

            UnbindUI(false);
            try
            {
                _person = _person.Save();
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

        #region Implement IClose member

        public void Close()
        {
            personBindingSource.Unbind(true, true);
        }

        #endregion
    }
}