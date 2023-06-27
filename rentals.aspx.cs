using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CLDV_POE_Part_3
{
    public partial class rentals : System.Web.UI.Page
    {
        //Connect to DB
        public static string connString = "Server=tcp:st10063915.database.windows.net,1433;Initial Catalog=The_Ride_You_Rent;Persist Security Info=False;User ID=st10063915;Password=Ryan1209;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public SqlConnection conn = new SqlConnection(connString);

        SqlDataReader reader;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateReturnComboBox();
            }

        }

        //Create a rental request
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String vehicle_no;
            String driver_no;
            string inspector_no = Response.Cookies["inspector_no"].Value;
            string rental_fee = tbRentalFee.Text;

            try
            {
                conn.Open();

                // Find the vehicle reg for the combo box
                SqlCommand car_no = new SqlCommand("SELECT car_no FROM car_make cm, car c WHERE cm.car_make = c.car_make  WHERE CONCAT(cm.description, ' ', c.model) like('%" + cbVehicles.SelectedValue.ToString() + "%')", conn);
                vehicle_no = car_no.ExecuteScalar().ToString();

                SqlCommand driver_id = new SqlCommand("SELECT driver_no FROM driver WHERE name = like('" + cbDrivers.SelectedValue.ToString() + "')", conn);
                driver_no = driver_id.ExecuteScalar().ToString();

                //Insert a record into rental log
                SqlCommand sqlInsert = new SqlCommand($"INSERT INTO rental (car_no,inspector_no, driver_no, rental_fee,start_date,end_date) VALUES('{car_no}',{inspector_no}, {driver_no}, {rental_fee}, CONVERT(date,'" + tbFromDate.Text + "'), CONVERT(date,'" + tbToDate.Text + "'))", conn);
                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.InsertCommand = sqlInsert;
                adapter.InsertCommand.ExecuteNonQuery();

                conn.Close();

                //Display a message showing that the booking has been created

                Response.Redirect("SuccessPage.aspx");


            }
            catch (SqlException error)
            {
                string script1 = "alert('" + error.Message + "');";
            }
        }

        public void populateComboBox()  
        {
            try
            {
                cbVehicles.Items.Clear();
                cbVehicles.Items.Add("");

                conn.Open();

                SqlCommand command = new SqlCommand(@"SELECT CONCAT(cm.description, ' ', c.model) AS carName FROM car_make cm, car c WHERE cm.car_make = c.car_make AND c.car_no NOT IN (SELECT r.car_no FROM rental r LEFT JOIN returns ret ON r.car_no = ret.car_no WHERE CONVERT(date,'" + tbFromDate.Text + "') BETWEEN r.start_date AND ISNULL(ret.return_date, r.end_date) OR CONVERT(date,'" + tbToDate.Text + "') BETWEEN r.start_date AND ISNULL(ret.return_date, r.end_date))", conn);

                reader = command.ExecuteReader();
                while (reader.Read())
                {   

                    cbVehicles.Items.Add(reader.GetValue(0).ToString());
                }

                conn.Close();
            }
            catch (SqlException error)
            {
                string script = "alert('" + error.Message + "');";
            }

            try
            {
                cbDrivers.Items.Clear();
                cbDrivers.Items.Add("");
            
                conn.Open();
            
                SqlCommand command = new SqlCommand(@"SELECT distinct(name) FROM driver ", conn);
            
                reader = command.ExecuteReader();
                while (reader.Read())
                {
            
                    cbDrivers.Items.Add(reader.GetValue(0).ToString());
                }
            
                conn.Close();
            }
            catch (SqlException error)
            {
                string script = "alert('" + error.Message + "');";
            }
            
        }


        


        protected void tbToDate_TextChanged(object sender, EventArgs e)
        {
            populateComboBox();
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }


        public void populateReturnComboBox()
        {
            try
            {
                cbVehicleReturn.Items.Clear();
                cbVehicleReturn.Items.Add("");

                conn.Open();

                SqlCommand command = new SqlCommand(@"SELECT r.car_no, r.driver_no FROM rental r LEFT JOIN returns ret ON r.car_no = ret.car_no AND r.driver_no = ret.driver_no WHERE ret.car_no IS NULL", conn);

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cbVehicleReturn.Items.Add(reader.GetValue(0).ToString());
                }

                conn.Close();
            }
            catch (SqlException error)
            {
                string script = "alert('" + error.Message + "');";
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            string car_no = cbVehicleReturn.SelectedValue.ToString();
            string inspector_no = Response.Cookies["inspector_no"].Value;

            conn.Open();
            SqlCommand driverCommand = new SqlCommand("SELECT TOP 1 driver_no FROM rental WHERE car_no = @CarNo ORDER BY end_date DESC", conn);
            driverCommand.Parameters.AddWithValue("@CarNo", car_no);
            var driverNoResult = driverCommand.ExecuteScalar();
            int driver_no = (int)driverNoResult;

            conn.Close();

            DateTime returnDate = DateTime.Now;

            conn.Open();
            SqlCommand endDateCommand = new SqlCommand("SELECT TOP 1 end_date FROM rental WHERE car_no = @CarNo ORDER BY end_date DESC", conn);
            endDateCommand.Parameters.AddWithValue("@CarNo", car_no);
            var endDateResult = endDateCommand.ExecuteScalar();
            DateTime end_date = Convert.ToDateTime(endDateResult);

            conn.Close();


            int elapsed_date;
            int Fine;

            if (returnDate > end_date)
            {
                TimeSpan elapseddays = returnDate - end_date;
                elapsed_date = elapseddays.Days;
                Fine = elapsed_date * 500;
            }
            else
            {
                elapsed_date = 0;
                Fine = 0;
            }

            
            conn.Open();

            SqlCommand sqlInsert = new SqlCommand($"INSERT INTO returns (car_no, inspector_no, driver_no, return_date, elapsed_date, Fine) VALUES('{car_no}','{inspector_no}', {driver_no}, '{returnDate:yyyy-MM-dd}', {elapsed_date}, {Fine})", conn);
            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.InsertCommand = sqlInsert;
            adapter.InsertCommand.ExecuteNonQuery();

            conn.Close();

            Response.Redirect("SuccessPage.aspx");
        

        

        }
        
    }
}