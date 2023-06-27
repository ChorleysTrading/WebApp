using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLDV_POE_Part_3
{
    public partial class search : System.Web.UI.Page
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
            // Get the selected row index
            int selectedIndex = gridView.SelectedIndex;

            // Make sure a row is selected
            if (selectedIndex >= 0)
            {
                // Get the primary key value of the selected row
                string primaryKeyValue = gridView.DataKeys[selectedIndex].Value.ToString();

                // Determine the selected table
                string selectedTable = ddlDatabase.SelectedValue;

                // Redirect to the update page with the necessary parameters
                Response.Redirect($"UpdatePage.aspx?table={selectedTable}&id={primaryKeyValue}");
            }
        }
        protected void ddlDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridView();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

        }
    }
}