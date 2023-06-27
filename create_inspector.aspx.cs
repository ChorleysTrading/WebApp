using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLDV_POE_Part_3
{
    public partial class create_inspector : System.Web.UI.Page
    {
        public string connString = "Server=tcp:st10063915.database.windows.net,1433;Initial Catalog=The_Ride_You_Rent;Persist Security Info=False;User ID=st10063915;Password=Ryan1209;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string inspectorNo = txtInspectorNo.Value;
            string name = txtName.Value;
            string email = txtEmail.Value;
            string mobile = txtMobile.Value;

            if (string.IsNullOrWhiteSpace(inspectorNo) || string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(mobile))
            {
                // At least one required field is empty, show error message
                Error.Text = "Please fill in all the required fields.";
                Error.Visible = true;
                return;
            }

            // Check if the inspector_no already exists
            string checkQuery = "SELECT COUNT(*) FROM inspector WHERE inspector_no = @InspectorNo";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand checkCommand = new SqlCommand(checkQuery, conn);
                checkCommand.Parameters.AddWithValue("@InspectorNo", inspectorNo);

                conn.Open();
                int existingInspectorCount = (int)checkCommand.ExecuteScalar();

                if (existingInspectorCount > 0)
                {
                    // Inspector already exists, show error message
                    Error.Text = "The inspector number already exists. Please enter a unique inspector number.";
                    Error.Visible = true;
                }
                else
                {
                    // Inspector does not exist, perform the insert operation
                    string insertQuery = "INSERT INTO inspector (inspector_no, name, email, mobile) " +
                                         "VALUES (@InspectorNo, @Name, @Email, @Mobile)";

                    SqlCommand insertCommand = new SqlCommand(insertQuery, conn);
                    insertCommand.Parameters.AddWithValue("@InspectorNo", inspectorNo);
                    insertCommand.Parameters.AddWithValue("@Name", name);
                    insertCommand.Parameters.AddWithValue("@Email", email);
                    insertCommand.Parameters.AddWithValue("@Mobile", mobile);

                    insertCommand.ExecuteNonQuery();

                    // Redirect to a success page or display a success message
                    Response.Redirect("SuccessPage.aspx");
                }
            }
        }
    }
}