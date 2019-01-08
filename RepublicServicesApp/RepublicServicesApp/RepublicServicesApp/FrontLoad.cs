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
    public partial class FrontLoad : Form
    {
        public FrontLoad()
        {
            InitializeComponent();
        }

        private void frontLoadBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.frontLoadBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.republicServicesDataSet);

        }

        private void FrontLoad_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'republicServicesDataSet.FrontLoad' table. You can move, or remove it, as needed.
                this.frontLoadTableAdapter.Fill(this.republicServicesDataSet.FrontLoad);
            }
            catch (Exception ex)
            {
                //Handle exception by showing an error message to the user
                string errorMessage = "An error occured when populating the data from the database. \n" + "Error: " + ex.Message;

                //show message in dialog box
                MessageBox.Show(errorMessage, "Database Error");
            }
        }

        private void frontLoadDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
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