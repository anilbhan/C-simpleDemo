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
using System.Configuration;



namespace creditCalculation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateCombobox();

        }

        private void Update_Click(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand command = new SqlCommand("insert into CustomerDetails values('" + Name.Text + "', '" + Address.Text + "','" + CC.Text + "','" + Total.Text + "')", con);
                con.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Data inserted successfully");
                Name.Text = "";
                CC.Text = "";
                Address.Text = "";
                Total.Text = "";

            }
        }

        private void save_Click(object sender, EventArgs e)
        {

            string connection = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                string updateme = "update customerdetails set name='" + Name.Text + "', address='" + Address.Text + "',currentcredit='" + CC.Text + "',totalpayment='" + Total.Text + "' where customerid='" + comboBox1.SelectedItem.ToString() + "'";
                SqlCommand command = new SqlCommand(updateme, con);
                con.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Updated successfully");
                Name.Text = "";
                CC.Text = "";
                Address.Text = "";
                Total.Text = "";
                comboBox1.SelectedItem = "";

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateTextboxOnSelection();


        }
        public void PopulateTextboxOnSelection()
        {

            string connection = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                string s = comboBox1.SelectedItem.ToString();
                SqlCommand command = new SqlCommand("select* from CustomerDetails where customerid='" + s+"'", con);
                con.Open();
                SqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    Name.Text = rdr["Name"].ToString();

                    Address.Text = rdr["Address"].ToString();


                    CC.Text = rdr["CurrentCredit"].ToString();


                    Total.Text = rdr["TotalPayment"].ToString();



                }

            }
        }

        public void PopulateCombobox()
        {
            string connection = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand command = new SqlCommand("select Customerid from CustomerDetails", con);
                con.Open();
                SqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["Customerid"];
                    comboBox1.Items.Add(id);
                }

            }
        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            Name.Text = "";
            CC.Text = "";
            Address.Text = "";
            Total.Text = "";
            comboBox1.SelectedItem = "";
        }
    }
}
