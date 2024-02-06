using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class UpdateProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["loginEmail"] != null)
            {
                Master.FindControl("MainSignUpId").Visible = false;
                Master.FindControl("MainLoginId").Visible = false;
                
                Master.FindControl("AddBlogId").Visible = true;
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

                email.ReadOnly = true;
              
                string useremail = Session["loginEmail"].ToString();

                SqlConnection connection = new SqlConnection("Data Source = (localdb)\\Local; Integrated Security = true");
                try
                {
                    connection.Open();
                    connection.ChangeDatabase("LocalDB");

                    string str = "SELECT * FROM usercred WHERE (email='" + useremail + "')";
                    SqlCommand cmd = new SqlCommand(str, connection);
                    SqlDataReader record = cmd.ExecuteReader();

                    if (record.Read())
                    {
                        first_name.Text = record[0].ToString();
                        last_name.Text = record[1].ToString();
                        email.Text = record[2].ToString();
                        password.Text = record[3].ToString();
                        password_confirmation.Text = record[3].ToString();
                     
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

        }//end of Page Load

        protected void update(object sender, EventArgs e)
        {
            string first = first_name.Text;
            string last = last_name.Text;

            string pass = password.Text;
            string emailAddress = email.Text;
            
            

            SqlConnection connection = new SqlConnection("Data Source = (localdb)\\Local; Integrated Security = true");
            try
            {
                connection.Open();
                connection.ChangeDatabase("LocalDB");

                string str = "UPDATE usercred SET firstname='" + first
                        + "',lastname='" + last +
                       "',password='" + pass + "'WHERE email='" + emailAddress + "';";

                
                SqlCommand checklogin = new SqlCommand(str, connection);
                
                checklogin.ExecuteNonQuery();
                Label l1 = (Label)Master.FindControl("LoggedInNameId");
                l1.Text = "Welcome " + first + "!";
                Session["LoggedInNameId"] = l1.Text;

                Label1.Text = "Your profile has been saved succesfully";
            }

            catch (SqlException ex)
            {
                Response.Write("Error is " + ex.Number + " and the message is-" + ex.Message);
            }

        }



    }
}