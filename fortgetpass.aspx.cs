using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class fortgetpass : System.Web.UI.Page
{

    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Buttonsend_Click(object sender, EventArgs e)
    {
        
        SqlCommand comd = new SqlCommand();

        try 
        {
            connection.Open();
            comd.Connection = connection; //Pass the connection object to Command

            comd.CommandType = CommandType.StoredProcedure; 
            comd.CommandText = "resetpassword_proc";

            comd.Parameters.AddWithValue("@username",Textreqname.Value);


            SqlDataReader drd= comd.ExecuteReader();

            while (drd.Read())
              {
               if (Convert.ToBoolean(drd["ReturnCode"]))
                 {
                  
                   sendResetEmail(drd["Email"].ToString(), Textreqname.Value, drd["UniqueId"].ToString()); 
                   Labelmsg.Text= "an email has been sent to your indox . please check";
                }

               else 

               {
                   Labelmsg.Text= "sorry user dose not exsit";
               }


            }
            connection.Close();

        }

        catch (Exception ex)
        {
            Labelmsg.Text= "\n"+ex.Message;
        }
        


    }


    public void sendResetEmail(string toEmail, string toUser, string uniqId)
    {
        MailMessage mailmsg = new MailMessage("meemz9202@gmail.com",toEmail);

        StringBuilder strEmailBody = new StringBuilder();

        strEmailBody.Append("Dear " + toUser + ",<br/><br/>");
        strEmailBody.Append("We have Received a request for restting your account for username "+ "<b>"+ toUser +"<b/>");
        strEmailBody.Append("Please click on the following link to reset your password");
        strEmailBody.Append("<br/><br/>");
        strEmailBody.Append("http://localhost:1668/changepass.aspx?uid=" + uniqId);

        strEmailBody.Append("<br/>");

        strEmailBody.Append("If you did not request your password to be reset,please ignor this email");
        strEmailBody.Append("Best Regards,");

        mailmsg.IsBodyHtml = true;
        mailmsg.Body = strEmailBody.ToString();

        mailmsg.Subject = "Reset Your Password";

        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

        smtpClient.Credentials = new System.Net.NetworkCredential()
         {
             UserName = "meemz9202@gmail.com",
             Password = "getmemeemz92"
         };

        smtpClient.EnableSsl = true;
        smtpClient.Send(mailmsg);
    }



}