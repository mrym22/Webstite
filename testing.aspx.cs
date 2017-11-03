using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testing : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {


    }

    private Boolean loginValidation(string userName, String Password)
    {

        Boolean returnedValue = false;
        SqlCommand selection = new SqlCommand("select * from customer where password=@idvalue and name=@namevalue");

        try
        {
            con.Open();
            selection.Connection = con; //Pass the connection object to Command

            string hashedPass = FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "SHA1");
            Response.Write(hashedPass);

            selection.Parameters.AddWithValue("@idvalue", hashedPass);
            selection.Parameters.AddWithValue("@namevalue", userName);


            SqlDataReader dataread = selection.ExecuteReader();

            while (dataread.Read())
            {
                returnedValue = true;

            }


        }

        catch (Exception ex)
        {
            returnedValue = false;
            Response.Write("exception   "+ex.Message);
        }
        finally
        {
            con.Close();
        }
        return returnedValue;
    }



    protected void login_authenticate(object sender, AuthenticateEventArgs e)
    {
        if (loginValidation(Login1.UserName, Login1.Password))
        {

          //
          
         // Response.Redirect("fortgetpass.aspx");
          
            e.Authenticated = true;
        }


        else
        {

            e.Authenticated = false;


        }

        /*MembershipUser ship = Membership.GetUser(Login1.UserName);


        if (ship == null)
        {
            Response.Write("invalid user name");

        }


        else if (ship.IsLockedOut)
        {

            Response.Write("your account has been locked");
        }*/

        
    }
    //Response.Write("user name :" + Login1.UserName + user);
    protected void login_inError(object sender, EventArgs e)
    {

        MembershipUser user = Membership.GetUser(Login1.UserName);

       //Membership.Providers["SqlProvider"].GetUser(Login1.UserName, false);


        if (user == null)
        {
            Login1.FailureText = "sorry there is no such username";

        }


        else
        {

            if (!user.IsApproved)
            {

                Login1.FailureText = "your account has been approved yet!!";
            }


            else if (user.IsLockedOut)
            {

                Login1.FailureText = "your account has been blocked";
            }


            else
            {

                Login1.FailureText = "sorry your password in incorroect , try rest your password";
            }



        }

        /*Boolean isValidUser = Membership.ValidateUser(Login1.UserName, Login1.Password);

        if (!isValidUser)
        {

            MembershipUser user = Membership.GetUser(Login1.UserName);

            // user exists 
            if (user != null)
            {

                if (!user.IsApproved)
                {


                    Response.Write(" user msg : " + "user account has been approved yet");

                }



                else if (user.IsLockedOut)
                {


                    Response.Write(" user msg : " + "user account has been blocked !!!!!!!!");

                }

                else
                {

                    Response.Write(" user msg : " + "sorry invalid user or password");
                }



            }


            else
            {

                Response.Write("sorry this account not found");

            }

        }*/

    }
    protected void logged_in(object sender, EventArgs e)
    {
        Response.Write("curent is " + Membership.GetUser(User.Identity.Name));
    }
}
