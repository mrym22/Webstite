using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        /*if (Session["name"] == null)
        {
            Response.Write("Empty session");

        }

        else
        {
            Response.Write(Session["name"]);
        }*/


        try
        {
            if (Request.Cookies["username"].Value!=null)
            {
            Response.Redirect("/Default.aspx");
            }

        }

        catch (Exception ex)
        {
            Response.Write("Empty cookie");
        }
       
        
    }

    protected void login_btn(object sender, EventArgs e)
    {
        SqlCommand selection = new SqlCommand("select * from customer where password=@idvalue and name=@namevalue");

        try
        {
            con.Open();
            selection.Connection = con; //Pass the connection object to Command

            string hashedPass = FormsAuthentication.HashPasswordForStoringInConfigFile(Textpassword.Value,"SHA1");
            Response.Write(hashedPass);

            selection.Parameters.AddWithValue("@idvalue",hashedPass);
            selection.Parameters.AddWithValue("@namevalue", Textusername.Value);

            SqlDataAdapter adapter = new SqlDataAdapter(selection);

            DataTable dt= new DataTable();
            adapter.Fill(dt);

            if (dt.Rows.Count>0)
            {
                Response.Write("Connection successed");
                Session["name"] = Textusername.Value;

                if (CheckBox1.Checked==true)

                {
                    Response.Cookies["username"].Value = Textusername.Value;
                    Response.Cookies["pass"].Value = Textpassword.Value;

                    Response.Cookies["username"].Expires = DateTime.Now.AddMinutes(2);
                    Response.Cookies["pass"].Expires = DateTime.Now.AddMinutes(2);
                    
                }

                Response.Redirect("/Default.aspx");
            }

            else 
            {
                Response.Write("Sorry try again");
            }



        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }

    }



    
}