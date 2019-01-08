using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepublicServicesApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void employeeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.republicServicesDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try { 
            // TODO: This line of code loads data into the 'republicServicesDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.republicServicesDataSet.Employee);
            }
            catch (Exception ex)
            {
                //Handle exception by showing an error message to the user
                string errorMessage = "An error occured when populating the data from the database. \n" + "Error: " + ex.Message;

                //show message in dialog box
                MessageBox.Show(errorMessage, "Database Error");
            }
        }
        //opens customer form
        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmCustomer = new Customer();

            frmCustomer.MdiParent = this;

            frmCustomer.Show();

            frmCustomer.Location = new Point(9, 170);
        }
        //opens employee form
        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmEmployee = new Employee();

            frmEmployee.MdiParent = this;

            frmEmployee.Show();

            frmEmployee.Location = new Point(9, 170);
        }
        //opens location form
        private void locationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmLocation = new Location();

            frmLocation.MdiParent = this;

            frmLocation.Show();

            frmLocation.Location = new Point(9, 170);
        }
        //opens frontLoad form
        private void frontLoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmFrontLoad = new FrontLoad();

            frmFrontLoad.MdiParent = this;

            frmFrontLoad.Show();

            frmFrontLoad.Location = new Point(9, 170);
        }
        //opens roll off form
        private void rollOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmRollOff = new RollOff();

            frmRollOff.MdiParent = this;

            frmRollOff.Show();

            frmRollOff.Location = new Point(9, 170);
        }
        //closes active form
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form activeForm = this.ActiveMdiChild;

            if (activeForm != null)
            {
                activeForm.Close();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
