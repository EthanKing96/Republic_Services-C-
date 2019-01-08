using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RepublicServicesApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //on Login click finds SQL connection string from the DataSet
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ethan\Desktop\CODING\Semester 3\Intermediate NET\CodingChallenge\RepublicServicesApp\RepublicServicesApp\RepublicServices.mdf;Integrated Security=True;Connect Timeout = 30;");
            //Checks the text box data with the data in the LoginData table in the DataSet
            SqlDataAdapter dataAdapter=new SqlDataAdapter("select count(*) from [LoginData] where USERNAME = '"+username.Text+"'and PASSWORD = '"+password.Text+"'", connection);
            //fills the data from the adapter into the table
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            //If data is not correct a message box will pop up telling user of error, instead of gaining access to the main form, if anything is wrong the count will be 0 from the D
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Form frmForm1 = new Form1();
                frmForm1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Username or Password incorrect. Please try again", "Login Error");
            }
            
        }
    }
}
