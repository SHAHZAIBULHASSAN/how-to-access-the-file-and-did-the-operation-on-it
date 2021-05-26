using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcedureGet
{
    public partial class Form1 : Form
    {
        string connetionString = @"Data Source=SHAHZAIBHASSAN-;Initial Catalog=CRUDDB;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    cnn.Open();
                    SqlDataAdapter sqlData = new SqlDataAdapter("spGetEmployee", cnn);
                    DataTable dataTable = new DataTable();
                    sqlData.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;

                    //dataGridView1.DataSource = dataTable;MessageBox.Show("Connection Open  !");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void FillDataGridView()
        {
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spgetEmployeeByName", cnn);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("@Name", textBox1.Text.Trim());
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
              //  dgvContacts.Columns[0].Visible = false;
                cnn.Close();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnc_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(connetionString))
            { cnn.Open();

                SqlCommand sqlCmd = new SqlCommand("spcreateEmployee", cnn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
               
                //  sqlCmd.Parameters.AddWithValue("@mode", "Add");
             //   sqlCmd.Parameters.AddWithValue("@EmployeeID", txti.Text.Trim());
               
                sqlCmd.Parameters.AddWithValue("@Age", txta.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Name", txtn.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Salary", txts.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Position", txtp.Text.Trim());
              int result=  sqlCmd.ExecuteNonQuery();
                if (result>0)
                {
           MessageBox.Show("Saved successfully ID" + result);
                }
               
                
            }

           }

        private void btnd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connetionString))
                {

                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("spEmployeeDelete", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@EmployeeID", textBox1.Text.Trim());
                    var result = sqlCmd.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Deleted successfully");
                    //  Reset();
                    FillDataGridView();
                } }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROr Message");
            }
        }
    }
}

        

