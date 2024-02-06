using System;
using System.Data;
using System.Data.SqlClient;
namespace Portal
{
    public partial class DisplayBlog : System.Web.UI.Page
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
                    this.PopulateBlog();
                }
            }
            

           

        }

        private void PopulateBlog()
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=LocalDB;Integrated Security=true");
        try {
                string semail = Session["loginEmail"].ToString();

            string blogId = this.Page.RouteData.Values["BlogId"].ToString();
            string query = "SELECT [Title], [Body] FROM [Blogs] WHERE [BlogId] = @BlogId AND email= '" + semail + "'";


            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Parameters.AddWithValue("@BlogId", blogId);
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        lblTitle.Text = dt.Rows[0]["Title"].ToString();
                        string bd = dt.Rows[0]["Body"].ToString();
                            string fst = bd.Replace("books" , "<a href='https://www.amazon.com/s/ref=nb_sb_noss_2?url=search-alias%3Daps&field-keywords=books' target='_blank' style='color:#7FFF00'>books</a>");
                            string thrd = fst.Replace("laptop", "<a href='https://www.amazon.com/s/ref=nb_sb_noss_2?url=search-alias%3Daps&field-keywords=laptop' target='_blank' style='color:#7FFF00' >laptop</a>");
                            lblBody.Text = thrd.Replace("movies", "<a href='https://www.amazon.com/s/ref=nb_sb_noss_2?url=search-alias%3Daps&field-keywords=movies' target='_blank' style='color:#7FFF00' >movies</a>");


                        }
                    }
            }
        }
            catch (SqlException ex)
            {
                Response.Write("Error is " + ex.Number + " and the message is-" + ex.Message);
            }
        }




    }
}