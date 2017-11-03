using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page
{
    string message = "morning ";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        GreetingLabel.InnerHtml = message;

        try
        {

        Response.Write(Request.Cookies["username"].Value);

        }

        catch (Exception ex)
        {
         Response.Write("Empty cookie");
        }
       

    }
        public string getData()  
        {
            string data="";

           SqlCommand com2 = new SqlCommand("select * from customer",con);

           if (con.State == ConnectionState.Closed)
           {
               con.Open();
           }

           SqlDataReader reader = com2.ExecuteReader();
            try 
            {
               while (reader.Read())
              {
                  
                      data += "<tr><td>" + reader[0] + "</td><td>" + reader[1] + "</td></tr>";
                
              }


             con.Close();
         }

            catch (Exception ex)
            {
                GreetingLabel.InnerHtml = ex.Message;
            }
            return data;
        }
    

    public void GreetingBtn_Click(object sender, EventArgs e)
    {
        Button1.Text = "Clicked";
        GreetingLabel.InnerHtml = message + Text1.Value;

        string name = Text1.Value;
        //int ids = Convert.ToInt32(Text2.Value);


        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //new SqlConnection("Data Source=SONY\\QLEXPRESS;Initial Catalog=testdb;Integrated Security=SSPI;");
        SqlCommand cominsert = new SqlCommand("insert into customer(name,password) values (@strname,@ids);");

        try
        {
            con.Open();
            cominsert.Connection = con; //Pass the connection object to Command

            string hashedPass = FormsAuthentication.HashPasswordForStoringInConfigFile(Text2.Value,"SHA1");
            Response.Write(hashedPass);

            cominsert.Parameters.AddWithValue("@strname", name);
            cominsert.Parameters.AddWithValue("@ids",hashedPass);

            //com.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            //com.CommandText = "spInsertUser"; //Stored Procedure Name
            //SqlDbType.NVarChar).Value = name;

            cominsert.ExecuteNonQuery();
            con.Close();

            getData();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
       
        
    }

    public void subBtn_Click(object sender, EventArgs e)
    {
      string ordermsg = "your order is ";
      if (CheckBoxList1.Items[0].Selected == true)
      ordermsg= ordermsg + CheckBoxList1.Items[0].Text;


      if (CheckBoxList1.Items[1].Selected == true)
          ordermsg = ordermsg + " and " + CheckBoxList1.Items[1].Text;


      if (CheckBoxList1.Items[2].Selected == true)
          ordermsg = ordermsg + " and " + CheckBoxList1.Items[2].Text;

      
      Label2.InnerHtml = ordermsg;
        

    }

    public void rd_changed(object sender, EventArgs e)
    {
        GreetingLabel.InnerHtml = "your gender is " + RadioButtonList1.SelectedItem.Value;
    }

    protected void go_button(object sender, EventArgs e)
    {
        Response.Redirect("/home.aspx?hiddenstr="+"Welcome maryam");
        
    }
    protected void UpdateBtn_Click(object sender, EventArgs e)
    {

        SqlCommand comupd = new SqlCommand("update customer set name='" + Text1.Value + "' where id='"+Convert.ToInt32(Text2.Value)+"' ");

        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            comupd.Connection = con; //Pass the connection object to Command


            comupd.ExecuteNonQuery();
            Response.Write(comupd.ExecuteNonQuery());
            con.Close();

            getData();

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);

        }

    }
    protected void DltBtn_Click(object sender, EventArgs e)
    {

        SqlCommand comdelete = new SqlCommand("delete from customer where id='" + Convert.ToInt32(Text2.Value) + "' ");

        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            comdelete.Connection = con; //Pass the connection object to Command


            comdelete.ExecuteNonQuery();
            Response.Write(comdelete.ExecuteNonQuery());
            con.Close();
           
            
            getData();

           
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);

        }





    }
  
    protected void test_clickbtn(object sender, EventArgs e)
    {
        string name = Text1.Value;
        //int ids = Convert.ToInt32(Text2.Value);

        /*SqlDataSource2.UpdateParameters["nameval"].DefaultValue=name;
        SqlDataSource2.UpdateParameters["idval"].DefaultValue=Text2.Value;
        SqlDataSource2.Update();*/

        string hashedPass = FormsAuthentication.HashPasswordForStoringInConfigFile(Text2.Value, "SHA1");
        Response.Write(hashedPass);

        SqlDataSource2.InsertParameters["nameval"].DefaultValue = name;
        SqlDataSource2.InsertParameters["idvalue"].DefaultValue = hashedPass;
        SqlDataSource2.Insert();



    }

    protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
}