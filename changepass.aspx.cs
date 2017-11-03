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

public partial class changepass : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (!isValidLink())
            {

                Labelerror.Text = "Password rest link has been expired or invalid";
            }

        }

    }
    protected void save_btn(object sender, EventArgs e)
    {

       if (changeUserPass())
        {
            Labelerror.Text = "Your password has been change";
        }

        else
        {
            Labelerror.Text="sorry something went wrong";
        }
    }


    private Boolean executeProcedure(string procName, List<SqlParameter> sqlparam)
    {

        SqlCommand cmd = new SqlCommand(procName);

        try
        {
            connection.Open();
            cmd.Connection = connection; //Pass the connection object to Command

            cmd.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter parameter in sqlparam)
            {
                cmd.Parameters.Add(parameter);
            }

            return Convert.ToBoolean(cmd.ExecuteScalar());
        }

        catch (Exception ex)
        {

            Labelerror.Text = ex.Message;

            return false;
        }


    }


    private Boolean isValidLink()
    {

        List<SqlParameter> parameters = new List<SqlParameter>()
        {
            new SqlParameter()
            {
              ParameterName="@GUID",
              Value=Request.QueryString["uid"]
            }
        };

        return executeProcedure("pass_restLinkValid", parameters);
    }

    private Boolean changeUserPass()
    {
        List<SqlParameter> parmsList = new List<SqlParameter>()
        {
            new SqlParameter()
            {
              ParameterName="@GUID",
              Value=Request.QueryString["uid"]
            },
            new SqlParameter()
            {
              ParameterName="@pass",
              Value=FormsAuthentication.HashPasswordForStoringInConfigFile(Textpass.Value,"SHA1")
             
            }

        };

        //Labelerror.Text = Request.QueryString["uid"] + Textpass.Value;
        return executeProcedure("changepassword", parmsList);

    }

}