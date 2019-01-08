﻿using System;
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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void customerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.republicServicesDataSet);

        }

        private void Customer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'republicServicesDataSet.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.republicServicesDataSet.Customer);

        }

        private void customerDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //Show the user a nicely formatted message about the error

            //Get the row index for where teh error occured
            int row = e.RowIndex + 1;

            //Assemble an error message for the user
            string errorMessage = "A data error occured.\n" + "Row: " + row + "\n" + "Error: " + e.Exception.Message;

            //pop up a dialog box to show the message to the user
            MessageBox.Show(errorMessage, "Data Error");
        }
    }
}
