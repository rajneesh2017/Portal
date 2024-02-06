using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class EditBlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginEmail"] != null)
            {
                Master.FindControl("MainSignUpId").Visible = false;
                Master.FindControl("MainLoginId").Visible = false;
                Master.FindControl("UpdateProfileId").Visible = true;
                Master.FindControl("MainLogoutId").Visible = true;
                Master.FindControl("HomeId").Visible = true;
                Master.FindControl("FOTId").Visible = false;
            }

            else
            {

                Response.Redirect("Default.aspx");
            }


            if (!IsPostBack)
            {


                blgID.ReadOnly = true;
                string myBlogID = this.Page.RouteData.Values["BlogId"].ToString(); 

                SqlConnection connection = new SqlConnection("Data Source = (localdb)\\Local; Integrated Security = true");
                try
                {
                    connection.Open();
                    connection.ChangeDatabase("LocalDB");

                    string str = "SELECT * FROM blogs WHERE (blogID='" + myBlogID + "')";
                    SqlCommand cmd = new SqlCommand(str, connection);
                    SqlDataReader record = cmd.ExecuteReader();

                    if (record.Read())
                    {
                        blgID.Text = record[0].ToString();
                        title.Text = record[1].ToString();
                        body.Text = record[2].ToString();
                        

                    }

                    /* else
                                           {

                                              // Label2.ForeColor = System.Drawing.Color.Red;
                                               //Label2.Text = "Email does not exist in the system!";
                                           }*/

                }
                catch (SqlException ex)
                {
                    Response.Write("Error is " + ex.Number + " and the message is-" + ex.Message);
                }

            }




        }//end of page load

        protected void Button2_Click(object sender, EventArgs e)
        {

            string first = title.Text;
            string last = body.Text;

            
            string myBlgID = blgID.Text;



            SqlConnection connection = new SqlConnection("Data Source = (localdb)\\Local; Integrated Security = true");
            try
            {
                connection.Open();
                connection.ChangeDatabase("LocalDB");

                string str = "UPDATE blogs SET title='" + first
                        + "',body='" + last + "'WHERE blogID='" + myBlgID + "';";


                SqlCommand checklogin = new SqlCommand(str, connection);

                checklogin.ExecuteNonQuery();

                connection.Close();
                Response.Redirect("~/Welcome.aspx");
            }

            catch (SqlException ex)
            {
                Response.Write("Error is " + ex.Number + " and the message is-" + ex.Message);
            }

        }

        protected void DeleteRow(object sender, EventArgs e)
        {
            string myBlgID = blgID.Text;



            SqlConnection connection = new SqlConnection("Data Source = (localdb)\\Local; Integrated Security = true");
            try
            {
                connection.Open();
                connection.ChangeDatabase("LocalDB");
                
               string str = "DELETE FROM blogs WHERE (blogID='" + myBlgID + "')";
                SqlCommand checklogin = new SqlCommand(str, connection);

                checklogin.ExecuteNonQuery();

                connection.Close();
                Response.Redirect("~/Welcome.aspx");
            }

            catch (SqlException ex)
            {
                Response.Write("Error is " + ex.Number + " and the message is-" + ex.Message);
            }
        }
    }
}