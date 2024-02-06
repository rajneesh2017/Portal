using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Portal
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Click(object sender, EventArgs e)
        {



            SqlConnection dbConnection = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=LocalDB;Integrated Security=true");

            try
            {
                dbConnection.Open();


                try
                {
                    string fName = "SELECT firstname FROM dbo.usercred WHERE email= '" + email.Text + "'";
                    SqlCommand checkTable1 = new SqlCommand(fName, dbConnection);
                    SqlDataReader record1 = checkTable1.ExecuteReader();

                    if (record1.Read())
                    {
                        Label l1 = (Label)Master.FindControl("LoggedInNameId");
                        l1.Text = "Welcome " + record1["firstname"] + "!";
                        Session["LoggedInNameId"] = l1.Text;
                        record1.Close();
                    }
                    record1.Close();
                }
                catch (SqlException exception)
                {
                    Response.Write("<p>Error code " + exception.Number
                            + ": " + exception.Message + "</p>");
                }

                string databaseUserID = "SELECT * FROM dbo.usercred WHERE email= '" + email.Text + " 'and password='" + password.Text + "'";


                SqlCommand checkTable = new SqlCommand(databaseUserID, dbConnection);
                SqlDataReader record = checkTable.ExecuteReader();
                

                if (record.Read())
                {
                    // Label1.Text = "Successfully signed in";
                    //Response.Write("Successfully signed in");
                    record.Close();
                    Session["loginEmail"] = email.Text;
                    Response.Redirect("Welcome.aspx");
                    //record.Close();
                    
                }
                else
                {

                    //Label1.Text = "**Invalid user ID or Password**";
                    //Response.Write("**Invalid user ID or Password**");
                    Label1.Text = @"<div style='margin-top:20px' class='form - group alert alert-danger fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Invalid user ID or Password </div>";


                }

                

                record.Close();
            }



            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                        + ": " + exception.Message + "</p>");
            }

        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["forgotemail"] = TextBox1.Text;

            if (Session["forgotemail"] != null)
            {
                SqlConnection dbConnection = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=LocalDB;Integrated Security=true");
                try
                {
                    dbConnection.Open();
                    dbConnection.ChangeDatabase("LocalDB");

                    string databaseUserID = "SELECT password FROM usercred WHERE email= '" + TextBox1.Text + "'";


                    SqlCommand checkTable = new SqlCommand(databaseUserID, dbConnection);
                    SqlDataReader record = checkTable.ExecuteReader();
                    if (record.Read())
                    {

                        //MailMessage mail = new MailMessage();
                        //string subject = "Password recovery";
                        //string to = TextBox1.Text;

                        //string body = @"Your password is " + record["password"].ToString() + "";

                        //mail.To.Add(to);
                        //mail.From = new MailAddress("rkpande@ilstu.edu");
                        //mail.Body = body;
                        //mail.Subject = subject;

                        //SmtpClient mailClient = new SmtpClient("smtp.ilstu.edu");
                        //// Credentials are necessary if the server requires the client 
                        //// to authenticate before it will send e-mail on the client's behalf.
                        //// Do this in the web.config file

                        //mailClient.UseDefaultCredentials = false;
                        //mailClient.Send(mail);

                        ////ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password has been sent to your email')", true);
                        //Response.Redirect(Request.RawUrl + "#success");

                        ////MailMessage mail = new MailMessage("rkpande@ilstu.edu", TextBox1.Text);
                        ////SmtpClient client = new SmtpClient();
                        ////client.Port = 25;
                        ////client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        ////client.UseDefaultCredentials = false;
                        ////client.Host = "smtp.ilstu.edu";
                        ////mail.Subject = "Password recovery";
                        ////mail.Body = @"Your password is " + record["password"].ToString() + "";
                        ////client.Send(mail);


                        record.Close();

                    }
                    else
                    {

                        //Label1.Text = "**Invalid user ID or Password**";
                        //Response.Write("**Invalid email**");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid email')", true);


                    }
                }

                catch (SqlException exception)
                {
                    Response.Write("<p>Error code " + exception.Number
                            + ": " + exception.Message + "</p>");
                }


            }


        }
        

    }
}