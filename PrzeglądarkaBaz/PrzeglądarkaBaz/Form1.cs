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

namespace PrzeglądarkaBaz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ksiazkiDataSet.Książki' table. You can move, or remove it, as needed.
            this.książkiTableAdapter.Fill(this.ksiazkiDataSet.Książki);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bindingSource1.Position += 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.Position -= 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bindingSource1.EndEdit();
            try
            {
                książkiTableAdapter.Update(ksiazkiDataSet);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //książkiTableAdapter.Fill(ksiazkiDataSet.Książki);

        }

        public static SqlDataAdapter CreateCustomerAdapter(SqlConnection connection)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            // Create the SelectCommand.
            SqlCommand command = new SqlCommand("SELECT * FROM Customers " +
                "WHERE Country = @Country AND City = @City", connection);

            // Add the parameters for the SelectCommand.
            command.Parameters.Add("@Country", SqlDbType.NVarChar, 15);
            command.Parameters.Add("@City", SqlDbType.NVarChar, 15);

            adapter.SelectCommand = command;

            // Create the InsertCommand.
            command = new SqlCommand(
                "INSERT INTO Customers (CustomerID, CompanyName) " +
                "VALUES (@CustomerID, @CompanyName)", connection);

            // Add the parameters for the InsertCommand.
            command.Parameters.Add("@CustomerID", SqlDbType.NChar, 5, "CustomerID");
            command.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 40, "CompanyName");

            adapter.InsertCommand = command;

            // Create the UpdateCommand.
            command = new SqlCommand(
                "UPDATE Customers SET CustomerID = @CustomerID, CompanyName = @CompanyName " +
                "WHERE CustomerID = @oldCustomerID", connection);

            // Add the parameters for the UpdateCommand.
            command.Parameters.Add("@CustomerID", SqlDbType.NChar, 5, "CustomerID");
            command.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 40, "CompanyName");
            SqlParameter parameter = command.Parameters.Add(
                "@oldCustomerID", SqlDbType.NChar, 5, "CustomerID");
            parameter.SourceVersion = DataRowVersion.Original;

            adapter.UpdateCommand = command;

            // Create the DeleteCommand.
            command = new SqlCommand(
                "DELETE FROM Customers WHERE CustomerID = @CustomerID", connection);

            // Add the parameters for the DeleteCommand.
            parameter = command.Parameters.Add(
                "@CustomerID", SqlDbType.NChar, 5, "CustomerID");
            parameter.SourceVersion = DataRowVersion.Original;

            adapter.DeleteCommand = command;

            return adapter;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bindingSource1.EndEdit();
            try
            {
                bindingSource1.AddNew();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bindingSource1.Position = bindingSource1.Count;
        }
    }
}
