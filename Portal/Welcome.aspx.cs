using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["loginEmail"] != null)
            {
                Master.FindControl("MainSignUpId").Visible = false;
                Master.FindControl("MainLoginId").Visible = false;
                Master.FindControl("UpdateProfileId").Visible = true;
                Master.FindControl("AddBlogId").Visible = true;
                Master.FindControl("MainLogoutId").Visible = true;
                Master.FindControl("HomeId").Visible = true;
                Master.FindControl("FOTId").Visible = false;
                if (!this.IsPostBack)
                {
                    this.PopulateBlogs();
                }
            }

            else
            {

                Response.Redirect("Default.aspx");
            }


            

        }

        private void PopulateBlogs()
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=LocalDB;Integrated Security=true");

            string semail = Session["loginEmail"].ToString();
            string query = "SELECT [BlogId], [Title], REPLACE([Title], ' ', '-') [SLUG], [Body] FROM [Blogs] WHERE email= '" + semail + "'";

            
            
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            rptPages.DataSource = dt;
                            rptPages.DataBind();
                        }
                    }
                }
            
        }




    }
}