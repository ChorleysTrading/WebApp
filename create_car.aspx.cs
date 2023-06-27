using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLDV_POE_Part_3
{
    public partial class create_car : System.Web.UI.Page
    {
        public string connString = "Server=tcp:st10063915.database.windows.net,1433;Initial Catalog=The_Ride_You_Rent;Persist Security Info=False;User ID=st10063915;Password=Ryan1209;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string carNo = txtCarNo.Value;
            string carMake = ddlCarMake.Value;
            string model = txtModel.Value;
            string bodyType = ddlBodyType.Value;
            int kilometeresTravelled;
            int serviceKilometers;
            bool isKilometeresTravelledValid = int.TryParse(txtKilometeresTravelled.Value, out kilometeresTravelled);
            bool isServiceKilometersValid = int.TryParse(txtServiceKilometers.Value, out serviceKilometers);
            string available = ddlAvailable.Value;

            if (string.IsNullOrWhiteSpace(carNo) || string.IsNullOrWhiteSpace(carMake) ||
                string.IsNullOrWhiteSpace(model) || string.IsNullOrWhiteSpace(bodyType) ||
                !isKilometeresTravelledValid || !isServiceKilometersValid)
            {
                // At least one required field is empty or invalid, show error message
                Error.Text = "Please fill in all the required fields and ensure valid numeric values for kilometers.";
                Error.Visible = true;
                return;
            }

            // Check if the car_no already exists
            string checkQuery = "SELECT COUNT(*) FROM car WHERE car_no = @CarNo";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand checkCommand = new SqlCommand(checkQuery, conn);
                checkCommand.Parameters.AddWithValue("@CarNo", carNo);

                conn.Open();
                int existingCarCount = (int)checkCommand.ExecuteScalar();

                if (existingCarCount > 0)
                {
                    // Car already exists, show error message
                    Error.Text = "The car number already exists. Please enter a unique car number.";
                    Error.Visible = true;
                }
                else
                {

                    string carMakeValue = ddlCarMake.Value;

                    // Convert the selected value to a number
                    int carMakeNumber;
                    if (!int.TryParse(carMakeValue, out carMakeNumber))
                    {
                        // Handle the case where the conversion fails
                        Error.Text = "Invalid car make selection.";
                        Error.Visible = true;
                        return;
                    }

                    string bodyTypeValue = ddlBodyType.Value;

                    // Convert the selected value to a number
                    int bodyTypeNumber;
                    if (!int.TryParse(bodyTypeValue, out bodyTypeNumber))
                    {
                        // Handle the case where the conversion fails
                        Error.Text = "Invalid body type selection.";
                        Error.Visible = true;
                        return;
                    }

                    // Car does not exist, perform the insert operation
                    string insertQuery = "INSERT INTO car (car_no, car_make, model, body_type, kilometeres_travelled, service_kilometers, available) " +
                                         "VALUES (@CarNo, @CarMake, @Model, @BodyType, @KilometeresTravelled, @ServiceKilometers, @Available)";

                    SqlCommand insertCommand = new SqlCommand(insertQuery, conn);
                    insertCommand.Parameters.AddWithValue("@CarNo", carNo);
                    insertCommand.Parameters.AddWithValue("@CarMake", carMakeNumber); // Use the converted car make number
                    insertCommand.Parameters.AddWithValue("@Model", model);
                    insertCommand.Parameters.AddWithValue("@BodyType", bodyTypeNumber); // Use the converted body type number
                    insertCommand.Parameters.AddWithValue("@KilometeresTravelled", kilometeresTravelled);
                    insertCommand.Parameters.AddWithValue("@ServiceKilometers", serviceKilometers);
                    insertCommand.Parameters.AddWithValue("@Available", available);

                    insertCommand.ExecuteNonQuery();

                    // Redirect to a success page or display a success message
                    Response.Redirect("SuccessPage.aspx");
                }
            }
        }

        protected void gridViewDetail_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}