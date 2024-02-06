using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void CheckUniqueEmail(Object Source, EventArgs E)
        {



            string connectionString = "Data Source=(localdb)\\Local;Initial Catalog=LocalDB;"
                                       + "Integrated Security=true";
            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * from dbo.usercred "
                                    + "WHERE email = @classFilter1";


            // Specify the parameter value.
            string paramValue1 = email.Text;


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
                        emailErrorId.Visible = true;
                        emailErrorId2.Visible = false;
                        Label4.Text = "EmailId Already Exists.";
                    }
                    else
                    {
                        Label5.Text = "";
                        emailErrorId2.Visible = true;
                        emailErrorId.Visible = false;
                        Label5.Text = "Available!";
                    }
                    reader.Close();
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                
            }

           

        }//end of CheckUniqueEmail method


        protected void signUp(object sender, EventArgs e)
        {



            if (Page.IsPostBack)
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    string first = first_name.Text;
                    string last = last_name.Text;
                    
                    string pass = password.Text;
                    string emailAddress = email.Text;

                    SqlConnection dbConnection = new SqlConnection("Data Source=(localdb)\\Local; Integrated Security=true");
                    try
                    {
                        dbConnection.Open();
                        dbConnection.ChangeDatabase("LocalDB");
                    }
                    catch (SqlException exception)
                    {
                        if (exception.Number == 911) // non-existent DB
                        {
                            SqlCommand sqlCommand = new SqlCommand("CREATE DATABASE LocalDB", dbConnection);
                            sqlCommand.ExecuteNonQuery();
                            dbConnection.ChangeDatabase("LocalDB");
                        }
                        else
                            Response.Write("<p>Error code " + exception.Number
                                + ": " + exception.Message + "</p>");
                    }
                    finally
                    {
                        Console.Write("Successfully selected the database");
                    }
                    try
                    {
                        string SQLString = "SELECT * FROM usercred";
                        SqlCommand checkIDTable = new SqlCommand(SQLString, dbConnection);
                        SqlDataReader idRecords = checkIDTable.ExecuteReader();


                        idRecords.Close();
                    }
                    catch (SqlException exception)
                    {
                        if (exception.Number == 208) // object/table does not exist
                        {
                            SqlCommand sqlCommand = new SqlCommand("CREATE TABLE usercred ( firstname VARCHAR(50), lastname VARCHAR(50),email VARCHAR(50),password VARCHAR(50))", dbConnection);
                            sqlCommand.ExecuteNonQuery();

                        
                            Console.Write("Successfully created the table");
                        }
                        else
                            Response.Write("<p>Error code " + exception.Number
                                + ": " + exception.Message + "</p>");
                    }
                    finally
                    {

                        string SQLString = "SELECT * FROM usercred WHERE (email='" + email.Text + "')";
                        SqlCommand checkIDTable = new SqlCommand(SQLString, dbConnection);
                        SqlDataReader idRecords = checkIDTable.ExecuteReader();

                        

                        if (!idRecords.Read()) {
                            string signUpDetails = "INSERT INTO usercred VALUES('"
                                + first + "', '"
                                + last + "', '"
                                     + emailAddress + "', '"
                                     + pass + "')";

                            idRecords.Close();
                            SqlCommand sqlCommand = new SqlCommand(signUpDetails, dbConnection);
                            sqlCommand.ExecuteNonQuery();


                            Label l1 = (Label)Master.FindControl("LoggedInNameId");
                            l1.Text = "Welcome " + first + "!";
                            Session["LoggedInNameId"] = l1.Text;

                            Session["loginEmail"] = email.Text;

                            Response.Redirect("Welcome.aspx");


                        }

                        idRecords.Close();


                    }




                    string connectionString = "Data Source=(localdb)\\Local;Initial Catalog=LocalDB;"
                                      + "Integrated Security=true";
                    // Provide the query string with a parameter placeholder.
                    string queryString = "SELECT * from dbo.usercred "
                                            + "WHERE email = @classFilter1";


                    // Specify the parameter value.
                    string paramValue1 = emailAddress;

                    // Create and open the connection in a using block. This
                    // ensures that all resources will be closed and disposed
                    // when the code exits.
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

                               
                                //string emailBody = @"First Name: " + reader["firstname"] + "<br/>Last Name: " + reader["lastname"] + "<br/>Email: " + reader["email"] + "<br/>Password: " + reader["password"]; 
                                
                                ////Sending Email
                                //string myEmail = "rkpande@ilstu.edu";
                                //string myName = "Rajneesh";
                                //MailAddress messageFrom = new MailAddress(myEmail, myName);

                                ////MailMessage mail = new MailMessage();
                                //MailMessage emailMessage = new MailMessage();
                                
                                //emailMessage.IsBodyHtml = true;

                                ////mail.From = new MailAddress("rkpande@ilstu.edu");
                                //emailMessage.From = messageFrom;
                                
                                //MailAddress messageTo = new MailAddress(emailAddress, first);

                                ////mail.To.Add(to);
                                //emailMessage.To.Add(messageTo.Address);

                                ////string subject = "Password recovery";
                                //string messageSubject = "Welcome to the world of Blogs";

                                ////mail.Subject = subject;
                                //emailMessage.Subject = messageSubject;

                                //string htmlBody = "<html><body><h3>Hello User,</h3><p>Please find below your infomation</br>" + emailBody + "</p><h3/><br/>Thanks,<br/>IT494 Team</h3><br></body></html>";
                                
                                ////mail.Body = body;
                                //emailMessage.Body = htmlBody;

                                //SmtpClient mailClient = new SmtpClient("smtp.ilstu.edu");
                                //mailClient.UseDefaultCredentials = true;// false;
                                //mailClient.Send(emailMessage);


                                



                            }
                            
                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.Message);
                        }
                    }
                    dbConnection.Close();
                }
            }


            

        }//end of create profile methode
    }
}