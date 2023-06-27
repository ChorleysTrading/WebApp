using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLDV_POE_Part_3
{
    public partial class home : System.Web.UI.Page
    {
        // Connect to DB
        public string connString = "Server=tcp:st10063915.database.windows.net,1433;Initial Catalog=The_Ride_You_Rent;Persist Security Info=False;User ID=st10063915;Password=Ryan1209;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {

        }

        // Logout button
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Show popup message
            string script = "if (confirm('Are you sure you want to logout?')) window.location.href = 'index.aspx';";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "logoutConfirmation", script, true);
        }

        protected void btnRent_Click(object sender, EventArgs e)
        {
            Response.Redirect("rentals.aspx");
        }
        protected void btnManage_Click(object sender, EventArgs e)
        {
            Response.Redirect("management.aspx");
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("search.aspx");
        }
    }
}
