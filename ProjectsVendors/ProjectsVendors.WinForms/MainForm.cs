using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectsVendors.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void editProject_Click(object sender, EventArgs e)
        {
            var project = Convert.ToInt32(projectId.Text);
            workspace.Controls.Clear();
            workspace.Controls.Add(new ProjectEditor(project));
        }
    }
}
