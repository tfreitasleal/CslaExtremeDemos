﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Csla.Windows;
using ProjectsVendors.Business;

namespace ProjectsVendors.WinForms
{
    public partial class ProjectEditor : UserControl
    {
        private BindingSourceNode _bindingTree;

        private ProjectEdit _projectEdit;

        private ProjectEditor()
        {
            InitializeComponent();
        }

        public ProjectEditor(int projectId) :
            this()
        {
            _projectEdit = ProjectEdit.GetProjectEdit(projectId);

        }

        private void ProjectEdit_Load(object sender, EventArgs e)
        {
            BindUI();
        }

        private void BindUI()
        {
            if (_bindingTree == null)
                _bindingTree = BindingSourceHelper.InitializeBindingSourceTree(components, projectEditBindingSource);

            _bindingTree.Bind(_projectEdit);
        }

        private bool Save()
        {
            var result = false;
            _bindingTree.Apply();
            try
            {
                _projectEdit = _projectEdit.Save();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            BindUI();
            return result;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (!_projectEdit.IsDirty)
                return;

            _bindingTree.Cancel(_projectEdit);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!_projectEdit.IsSavable)
                return;

            if (Save())
                MessageBox.Show("Project saved.");
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            MessageBox.Show("tab 2 selected");
        }
    }
}