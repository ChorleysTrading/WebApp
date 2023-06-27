using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace CLDV_POE_Part_3
{
    public partial class management : System.Web.UI.Page
    {
        // Connect to DB
        public string connString = "Server=tcp:st10063915.database.windows.net,1433;Initial Catalog=The_Ride_You_Rent;Persist Security Info=False;User ID=st10063915;Password=Ryan1209;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Populate the GridView initially
                BindGridView();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Re-populate the GridView based on the selected table and search value
            BindGridView();
        }

        protected void BindGridView()
        {
            string selectedTable = ddlDatabase.SelectedValue;

            string query = $"SELECT * FROM {selectedTable}";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                // Bind the DataTable to the GridView
                gridView.DataSource = dataTable;
                gridView.DataBind();
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (gridView.SelectedIndex >= 0 && gridView.SelectedIndex < gridView.Rows.Count)
            {
                // Get the selected row
                GridViewRow selectedRow = gridView.Rows[gridView.SelectedIndex];

                // Find the cell with the unique identifier value (first column)
                TableCell uniqueIdentifierCell = selectedRow.Cells[1];

                // Get the unique identifier value of the selected row
                string uniqueIdentifierValue = uniqueIdentifierCell.Text;

                // Determine the selected table
                string selectedTable = ddlDatabase.SelectedValue;

                // Store the selected row details in session variables
                Session["SelectedTable"] = selectedTable;
                Session["UniqueIdentifierValue"] = uniqueIdentifierValue;

                // Redirect to the update page
                Response.Redirect($"UpdatePage.aspx?table={selectedTable}&id={uniqueIdentifierValue}&no={selectedTable}_no");
            }
        }

        protected void ddlDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridView();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (ddlDatabase.SelectedValue == "Car")
            {
                Response.Redirect("create_car.aspx");
            }
            else if (ddlDatabase.SelectedValue == "Driver")
            {
                Response.Redirect("create_driver.aspx");
            }
            else if (ddlDatabase.SelectedValue == "Inspector")
            {
                Response.Redirect("create_inspector.aspx");
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}