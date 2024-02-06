using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class AddBlog : System.Web.UI.Page
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

        }


        public void CheckUniqueBlogID(Object Source, EventArgs E)
        {



            string connectionString = "Data Source=(localdb)\\Local;Initial Catalog=LocalDB;"
                                       + "Integrated Security=true";
            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * from dbo.blogs "
                                    + "WHERE blogID = @classFilter1";


            // Specify the parameter value.
            string paramValue1 = blgID.Text;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@classFilter1", paramValue1);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Label4.Text = "";
                        blogErrorId.Visible = true;
                        blogErrorId2.Visible = false;
                        Label4.Text = "ID already taken.";
                    }
                    else
                    {
                        Label5.Text = "";
                        blogErrorId2.Visible = true;
                        blogErrorId.Visible = false;
                        Label5.Text = "Available!";
                    }
                    reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }



        }//end of CheckUniqueBlogID method

        protected void Button2_Click(object sender, EventArgs e)
        {


            if (Page.IsPostBack)
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    string unqBlgID = blgID.Text;
                    string titleName = title.Text;
                    string bodyInfo = body.Text;
                    string email = Session["loginEmail"].ToString();



                    SqlConnection connection = new SqlConnection("Data Source = (localdb)\\Local; Integrated Security = true");
                    try
                    {
                        connection.Open();
                        connection.ChangeDatabase("LocalDB");


                        string SQLString = "SELECT * FROM blogs WHERE (blogID='" + blgID.Text + "')";
                        SqlCommand checkIDTable = new SqlCommand(SQLString, connection);
                        SqlDataReader idRecords = checkIDTable.ExecuteReader();



                        if (!idRecords.Read())
                        {

                            string blogDetail = "INSERT INTO blogs VALUES('"
                                    + @unqBlgID + "', '"
                                    + @titleName + "', '"
                                    + @bodyInfo + "', '"
                                         + email + "')";

                            idRecords.Close();

                            using (SqlCommand cmd = new SqlCommand(blogDetail, connection))
                            {
                                cmd.Parameters.AddWithValue("@unqBlgID", unqBlgID);
                                cmd.Parameters.AddWithValue("@titleName", titleName);
                                cmd.Parameters.AddWithValue("@bodyInfo", bodyInfo);

                                cmd.ExecuteNonQuery();


                                connection.Close();

                                Session["UniqueBlogID"] = blgID.Text;

                                Response.Redirect("~/Welcome.aspx");
                            }

                        }
                        idRecords.Close();
                        //SqlCommand checklogin = new SqlCommand(blogDetail, connection);

                        //checklogin.ExecuteNonQuery();



                    }

                    catch (SqlException ex)
                    {
                        Response.Write("Error is " + ex.Number + " and the message is-" + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}