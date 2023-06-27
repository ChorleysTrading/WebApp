using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLDV_POE_Part_3
{
    
    public partial class create_driver : System.Web.UI.Page
    {
        public string connString = "Server=tcp:st10063915.database.windows.net,1433;Initial Catalog=The_Ride_You_Rent;Persist Security Info=False;User ID=st10063915;Password=Ryan1209;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Value;
            string surname = txtSurname.Value;
            string address = txtAddress.Value;
            string email = txtEmail.Value;
            string mobile = txtMobile.Value;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) ||
                string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(mobile))
            {
                // At least one required field is empty, show error message
                Error.Text = "Please fill in all the required fields.";
                Error.Visible = true;
                return;
            }

            int driverNumber;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string getMaxDriverNoQuery = "SELECT MAX(driver_no) FROM driver";
                SqlCommand getMaxDriverNoCommand = new SqlCommand(getMaxDriverNoQuery, conn);
                object maxDriverNo = getMaxDriverNoCommand.ExecuteScalar();
                if (maxDriverNo != DBNull.Value)
                {
                    driverNumber = Convert.ToInt32(maxDriverNo) + 1;
                }
                else
                {
                    driverNumber = 1;
                }

                // Perform the insert operation
                string insertQuery = "INSERT INTO driver (driver_no, name, address, email, mobile) " +
                                     "VALUES (@DriverNo, @Name, @Address, @Email, @Mobile)";

                SqlCommand insertCommand = new SqlCommand(insertQuery, conn);
                insertCommand.Parameters.AddWithValue("@DriverNo", driverNumber);
                insertCommand.Parameters.AddWithValue("@Name", name);
                insertCommand.Parameters.AddWithValue("@Address", address);
                insertCommand.Parameters.AddWithValue("@Email", email);
                insertCommand.Parameters.AddWithValue("@Mobile", mobile);

                insertCommand.ExecuteNonQuery();

                // Redirect to a success page or display a success message
                Response.Redirect("SuccessPage.aspx");
            }
        }
    }
}
