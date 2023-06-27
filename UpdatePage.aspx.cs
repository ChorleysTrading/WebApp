using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLDV_POE_Part_3
{
    public partial class UpdatePage : System.Web.UI.Page
    {
        // Connect to DB
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
                    string selectedTableNo = Request.QueryString["no"];

                    // Store the selected table and unique identifier value in session variables
                    Session["SelectedTable"] = selectedTable;
                    Session["UniqueIdentifierValue"] = uniqueIdentifierValue;

                    // Populate the GridView with the selected row details
                    BindGridView(selectedTable, uniqueIdentifierValue);
                }
                else
                {
                    // Redirect to the management page if the query string parameters are not present
                    Response.Redirect("management.aspx");
                }
            }
            btnUpdate.Click += btnUpdate_Click; // Assign the event handler programmatically
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get the selected table and unique identifier value from session variables
            string selectedTable = Session["SelectedTable"] as string;
            string uniqueIdentifierValue = Session["UniqueIdentifierValue"] as string;

            // Redirect to the updatecar.aspx page with query string parameters
            if(selectedTable == "Car")
            {
                Response.Redirect("updatecar.aspx?table=" + selectedTable + "&no=" + selectedTable + "_no&id=" + uniqueIdentifierValue);
            }
            if (selectedTable == "Driver")
            {
                Response.Redirect("updatedriver.aspx?table=" + selectedTable + "&no=" + selectedTable + "_no&id=" + uniqueIdentifierValue);
            }
            if (selectedTable == "Inspector")
            {
                Response.Redirect("updateinspector.aspx?table=" + selectedTable + "&no=" + selectedTable + "_no&id=" + uniqueIdentifierValue);
            }

        }

        
        

        

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // Get the selected table and unique identifier value from session variables
            string selectedTable = Session["SelectedTable"] as string;
            string uniqueIdentifierValue = Session["UniqueIdentifierValue"] as string;

            // Delete the record with the specified {selectedTable}_no
            string deleteQuery = $"DELETE FROM {selectedTable} WHERE {selectedTable}_no = @uniqueIdentifierValue";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(deleteQuery, conn);
                command.Parameters.AddWithValue("@uniqueIdentifierValue", uniqueIdentifierValue);

                conn.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Deletion successful, redirect to success page
                    Response.Redirect("SuccessPage.aspx");
                }
                else
                {
                    // Deletion unsuccessful, handle the error or display a message
                    // Redirect back to the management page or show an error message
                    Response.Redirect("management.aspx"); //DELETE PAGE then redirect to home????
                }
            }
        }

        protected void gridViewDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}