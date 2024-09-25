using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EmployeeData
{
    public partial class Form1 : Form
    {
        string connectionString = "Server=localhost;Database=employeeData;Uid=root;Pwd=Zaheer@02;";

        //string connectionString = @"Server=localhost;Initial catalog=employeeData;Integrated security=true;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = $"INSERT INTO employees (Name, Id, Age, Mobile, City) " +
                                   $"VALUES ('{txtEmpName.Text}', {txtEmpID.Text}, '{txtEmpAge.Text}', '{txtEmpMobile.Text}','{txtEmpCity.Text}')";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Employee data inserted successfully!");
                        ClearFields();
                        LoadEmployeeData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        private void LoadEmployeeData()
        {
            selectFields();
        }



        // Fill the input fields when a row is selected in DataGridView
        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEmployees.Rows[e.RowIndex];
                txtEmpID.Text = row.Cells["Id"].Value.ToString();
                txtEmpName.Text = row.Cells["Name"].Value.ToString();
                txtEmpAge.Text = row.Cells["Age"].Value.ToString();
                txtEmpMobile.Text = row.Cells["Mobile"].Value.ToString();
                txtEmpCity.Text = row.Cells["City"].Value.ToString();
                //txtEmpPassword.Text = row.Cells["Password"].Value.ToString();

            }
        }

        private void ClearFields()
        {
            txtEmpName.Text = "";
            txtEmpID.Text = "";
            txtEmpAge.Text = "";
            txtEmpMobile.Text = "";
            txtEmpCity.Text = "";
            //txtEmpPassword.Text = "";
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            selectFields();
        }
        public void selectFields()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM employees";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvEmployees.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = $"DELETE FROM employees WHERE ID={txtEmpID.Text}";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Employee data deleted successfully!");
                        ClearFields();
                        LoadEmployeeData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = $"UPDATE employees SET Name='{txtEmpName.Text}', Age={txtEmpAge.Text}, Mobile='{txtEmpMobile.Text}', City='{txtEmpCity.Text}' WHERE Id='{txtEmpID.Text}'";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Employee data updated successfully!");
                        
                        LoadEmployeeData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadEmployeeData();

        }
    }
}
