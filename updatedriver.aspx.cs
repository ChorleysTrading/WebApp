using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLDV_POE_Part_3
{
    public partial class updatedriver : System.Web.UI.Page
    {
        public string connString = "Server=tcp:st10063915.database.windows.net,1433;Initial Catalog=The_Ride_You_Rent;Persist Security Info=False;User ID=st10063915;Password=Ryan1209;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the necessary query string parameters are present
                if (Request.QueryString["table"] != null && Request.QueryString["id"] != null && Request.QueryString["no"] != null)
                {
                    string selectedTable = Request.QueryString["table"];
                    string uniqueIdentifierValue = Request.QueryString["id"];

                    // Store the selected table and unique identifier value in session variables
                    Session["SelectedTable"] = selectedTable;
                    Session["UniqueIdentifierValue"] = uniqueIdentifierValue;

                    // Bind the GridView with the selected row details
                    BindGridView(selectedTable, uniqueIdentifierValue);
                }
                else
                {
                    // Redirect to the management page if the query string parameters are not present
                    Response.Redirect("management.aspx");
                }
            }
        }

        protected void BindGridView(string selectedTable, string uniqueIdentifierValue)
        {
            string query = $"SELECT * FROM {selectedTable} WHERE {selectedTable}_no = @uniqueIdentifierValue";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@uniqueIdentifierValue", uniqueIdentifierValue);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                // Bind the DataTable to the GridView
                gridViewDetails.DataSource = dataTable;
                gridViewDetails.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Get the values from the inputs
            string driverNo = txtDriverNo.Value;
            string name = txtName.Value;
            string address = txtAddress.Value;
            string email = txtEmail.Value;
            string mobile = txtMobile.Value;

            // Validate inputs
            if (string.IsNullOrEmpty(driverNo) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(mobile))
            {
                Error.Visible = true;
                Error.Text = "Please fill in all the fields.";
                return;
            }

            // Update the record in the database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string updateQuery = "UPDATE driver SET name = @Name, address = @Address, email = @Email, " +
                    "mobile = @Mobile WHERE driver_no = @DriverNo";
                using (SqlCommand command = new SqlCommand(updateQuery, conn))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Mobile", mobile);
                    command.Parameters.AddWithValue("@DriverNo", driverNo);

                    conn.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Data updated successfully
                        Response.Redirect("SuccessPage.aspx");
                    }
                    else
                    {
                        Error.Visible = true;
                        Error.Text = "Failed to update the record.";
                    }
                }
            }
        }
    }
}
