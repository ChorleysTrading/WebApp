using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLDV_POE_Part_3
{
    public partial class updatecar : System.Web.UI.Page
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
            string carNo = txtCarNo.Value;
            string carMake = ddlCarMake.Value;
            string model = txtModel.Value;
            string bodyType = ddlBodyType.Value;
            int kilometersTravelled = Convert.ToInt32(txtKilometeresTravelled.Value);
            int serviceKilometers = Convert.ToInt32(txtServiceKilometers.Value);
            string available = ddlAvailable.Value;

            // Validate inputs
            if (string.IsNullOrEmpty(carNo) || string.IsNullOrEmpty(carMake) || string.IsNullOrEmpty(model) ||
                string.IsNullOrEmpty(bodyType) || kilometersTravelled == 0 || serviceKilometers == 0)
            {
                Error.Visible = true;
                Error.Text = "Please fill in all the fields.";
                return;
            }

            // Update the record in the database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string updateQuery = "UPDATE car SET car_make = @CarMake, model = @Model, body_type = @BodyType, " +
                    "kilometeres_travelled = @KilometeresTravelled, service_kilometers = @ServiceKilometers, available = @Available WHERE car_no = @CarNo";
                using (SqlCommand command = new SqlCommand(updateQuery, conn))
                {
                    command.Parameters.AddWithValue("@CarMake", carMake);
                    command.Parameters.AddWithValue("@Model", model);
                    command.Parameters.AddWithValue("@BodyType", bodyType);
                    command.Parameters.AddWithValue("@KilometeresTravelled", kilometersTravelled);
                    command.Parameters.AddWithValue("@ServiceKilometers", serviceKilometers);
                    command.Parameters.AddWithValue("@Available", available);
                    command.Parameters.AddWithValue("@CarNo", carNo);

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
