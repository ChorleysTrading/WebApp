using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLDV_POE_Part_3
{
    public partial class index : System.Web.UI.Page
    {
        public SqlConnection conn = new SqlConnection(@"Server=tcp:st10063915.database.windows.net,1433;Initial Catalog=The_Ride_You_Rent;Persist Security Info=False;User ID=st10063915;Password=Ryan1209;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30"); //Connect to the database 
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check for username and password cookies, set login details accordingly
            if (!IsPostBack)
            {
                if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
                {
                    tbEmail.Text = Request.Cookies["Email"].Value;
                    tbCell.Text = Request.Cookies["Cellphone"].Value;
                }
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
            String inspector_no;
            if (ValidateCredentials(tbEmail.Text, tbCell.Text))
            {
                
                //set cookie data if remember me is checked
                if (cbRememberMe.Checked)
                {
                    Response.Cookies["Email"].Value = tbEmail.Text;
                    Response.Cookies["Cellphone"].Value = tbCell.Text;
                    Response.Cookies["Email"].Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies["Cellphone"].Expires = DateTime.Now.AddMinutes(30);

                }
                else
                {
                    Response.Cookies["Email"].Expires = DateTime.Now.AddMinutes(-1);
                    Response.Cookies["Cellphone"].Expires = DateTime.Now.AddMinutes(-1);
                }
                //set the client_id cookie
                try
                {
                    
                    conn.Open();
                    SqlCommand com = new SqlCommand(@"SELECT inspector_no FROM inspector WHERE email LIKE('" + tbEmail.Text + "') AND (mobile = '" + tbCell.Text + "')", conn);
                    inspector_no = com.ExecuteScalar().ToString();
                    Response.Cookies["inspector_no"].Value = inspector_no;
                    Response.Redirect("home.aspx");
                    

                    conn.Close();
                }
                catch (SqlException error)
                {
                    string script = "alert('" + error.Message + "');";
                    
                }
            }
        }
        //validate the login details
        protected void validateLoginDetail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ValidateCredentials(tbEmail.Text, tbCell.Text))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }

        }
        private bool ValidateCredentials(string username, string password)
        {
            try
            {   //Check if the Username and Passwords values match a record in the client table 
                conn.Open();
                SqlCommand com = new SqlCommand(@"SELECT count(*) FROM inspector WHERE email LIKE('" + tbEmail.Text + "') AND (mobile = '" + tbCell.Text + "')", conn);
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                conn.Close();

                if (temp == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (SqlException error)
            {
                string script = "alert('" + error.Message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SQLERROR", script, true);
                return false;
            }
        }
        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("createAccount.aspx");
        }

    }
}