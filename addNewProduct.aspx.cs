using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addNewProduct : System.Web.UI.Page
{

    static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
   
    {
        //TextJS.Attributes.Add("onblur", "return showResult()");
    }


    protected void savebtn_Click(object sender, EventArgs e)
    {
        msgError1.Visible = false;
        if (FileUpload1.HasFile && FileUpload2.HasFile)
        {

            try
            {
                string fileName = Path.GetFileName(FileUpload1.FileName);

                if (FileUpload1.PostedFile.ContentType=="image/jpeg")
                {

                   
                    if (FileUpload1.PostedFile.ContentLength <= 102400)  
                        //size less than or equals 100 KB
                    {

                        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/upload/") + fileName);

                        SqlCommand cmd = new SqlCommand("insert into products values (@name,@desc,@image)");

                        cmd.Parameters.Add("@name", TextProdName.Value);
                        cmd.Parameters.Add("@desc", TextProdDesc.Value);
                        cmd.Parameters.Add("@image",fileName);

                        con.Open();
                        cmd.Connection = con; /// passing connection 

                        int resultValue= cmd.ExecuteNonQuery();

                        msgError1.Visible = true;
                        msgError1.Text = "has been successfully added " +"("+"items "+resultValue+")";

                        TextProdName.Value = string.Empty;
                        TextProdDesc.Value = string.Empty;

                        // refreshing grideview
                        GridView1.DataBind();

                    }

                    else 
                    {
                       msgError1.Visible = true;
                       msgError1.Text = "image size bigger than the allowed size 100 KB";

                    }
               
                }

                else 
                {

                    msgError1.Visible = true;
                    msgError1.Text = "sorry this type not allowed"+FileUpload1.PostedFile.ContentType.ToString();

                }
                
                


            }
            catch (Exception ex)
            {
                msgError1.Visible = true;
                msgError1.Text = ex.Message;
            }

            finally
            {

                con.Close();
            }

        }

        else
        {
            string errormsg = "";
            msgError1.Visible = true;

            if (!FileUpload1.HasFile)
            {
                errormsg = "Please choose an image";
            }

            if (!FileUpload2.HasFile)
            {

                errormsg+= "\n Please choose an file";
            }

            msgError1.Text = errormsg;
        }
    }

    protected Boolean validateImage(FileUpload file ,Label lable)
    {

        Boolean isValid = false;

        if (file.HasFile)
        {

            if (file.PostedFile.ContentType == "image/jpeg")
            {

                if (file.PostedFile.ContentLength <= 102400)
                //size less than or equals 100 KB
                {
                    isValid = true;
                   
                }

                else
                {
                    isValid = false;

                    lable.Visible = true;
                    lable.Text = "image size bigger than the allowed size 100 KB";

                }


            }

            else
            {
                isValid = false;
                lable.Visible = true;
                lable.Text = "sorry this type not allowed" + FileUpload1.PostedFile.ContentType.ToString();
            }
        }


        else
        {
            isValid = false;
            lable.Visible = true;
            lable.Text = "sorry please choose iamge file";

        }
        return isValid;
    }


    protected Boolean validateFile(FileUpload file, Label lable)
    {

        Boolean isValidFile = false;
        Boolean isValidExtention = false;


        if (file.HasFile)
        {

            string filePath = Path.GetFileName(file.FileName);
            string fileExtention = filePath.Substring(filePath.LastIndexOf('.') + 1).ToLower();

            string[] validFilesExtensions = { "doc", "docx", "pdf" };

            for (int i = 0; i < validFilesExtensions.Length; i++)
            {

                if (fileExtention == validFilesExtensions[i])
                {

                    isValidExtention = true;
                    break;
                }
            }



            if (isValidExtention)
            {
                //Response.Write("extention valid");

                if (file.PostedFile.ContentLength <= 1024000)   // 1MB
                {

                    isValidFile = true;

                }

                else
                {

                    isValidFile = false;

                    lable.Visible = true;
                    lable.Text = "file size bigger than the allowed size 1000 KB";

                }



            }

            else
            {

                isValidFile = false;
                lable.Visible = true;
                lable.Text = "sorry only document file is allowed";
            }

              

                    
                
            }

        

        else
        {
            isValidFile = false;

            lable.Visible = true;
            lable.Text = "please choose document file";

        }

        return isValidFile;
    }


    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DataList1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }

    protected void testbtn_Click(object sender, EventArgs e)
    {
       
        msgError1.Visible = false;
        msgError2.Visible = false;

        Boolean isValidFile1 = validateImage(FileUpload1, msgError1);
        Boolean isValidFile2 = validateFile(FileUpload2, msgError2);

        if (isValidFile1 && isValidFile2)
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/upload/") + Path.GetFileName(FileUpload1.FileName));
           FileUpload2.PostedFile.SaveAs(Server.MapPath("~/upload/") + Path.GetFileName(FileUpload2.FileName));

           String fileFullPath = Server.MapPath("~/upload/") + Path.GetFileName(FileUpload2.FileName);

            SqlCommand cmd = new SqlCommand("insert into products values (@name,@desc,@image,@file)");
            
            cmd.Parameters.Add("@name", TextProdName.Value);
            cmd.Parameters.Add("@desc", TextProdDesc.Value);
            cmd.Parameters.Add("@image", FileUpload1.FileName);
            cmd.Parameters.Add("@file", FileUpload2.FileName);

            //fileFullPath
            con.Open();
            cmd.Connection = con; /// passing connection 

            int resultValue = cmd.ExecuteNonQuery();

            msgError1.Visible = true;
            msgError1.Text = "has been successfully added " + "(" + "items " + resultValue + ")";

            TextProdName.Value = string.Empty;
            TextProdDesc.Value = string.Empty;

            // refreshing grideview
            GridView1.DataBind();






        }

       
    }
    protected void bounddata(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Image currentimg = (Image)e.Row.FindControl("Image1");
            LinkButton link = (LinkButton)e.Row.FindControl("hLink");

            try
            {
                if (!File.Exists(Server.MapPath(currentimg.ImageUrl)))
                {
                    
                 currentimg.ImageUrl = "~/upload/nbb.jpg";
                }

                /*if (!File.Exists(Server.MapPath(link)) || link.NavigateUrl==null)
                {

                    link.NavigateUrl = "Default.aspx";
                }*/

            }

            catch (Exception exp)
            { 
                Response.Write(exp.Message);
            }
        }
    }
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }

    protected void downloadme(object sender, EventArgs e)
    {
        LinkButton link=(LinkButton)sender;

        string FileName = "";

        if (link.CommandArgument == null || link.CommandArgument=="")
        {

            Response.Redirect("Default.aspx");
        }

        else
        {
            FileName = link.CommandArgument;
            /*Response.ContentType = "application/octet-stream";
            Response.AppendHeader("content-disposition", "attachment;filename=" + FileName);
            Response.TransmitFile(Server.MapPath("~/upload/" + FileName));
            Response.End();*/


            string filename = Server.MapPath("~/upload/" + FileName);
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(filename);

            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + fileInfo.Name + "\"");
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.TransmitFile(fileInfo.FullName);
            Response.Flush();

        }
    }

    protected void testing(object sender, EventArgs e)
    {
        //System.Threading.Thread.Sleep(3000);
       // LabelUser.Text = "DONE";
    }

    [System.Web.Services.WebMethod]
    public static string checkAavilability2(String name)

    {
       
        string returnValue = "";

        try
        {

           SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "checkUserExist";
            command.Parameters.Add("@user",name);

            con.Open();
            command.Connection = con;

            returnValue=command.ExecuteScalar().ToString();
        }
        catch (Exception exp)

        {
            returnValue="error";
        }

        finally{

            con.Close();
        }


        //Response.Write(returnValue);

        return returnValue;

    }

    protected string checkUsernameDuplicate(string user)
    {
        string returnValue = "";

        try
        {

            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "checkUserExist";
            command.Parameters.Add("@user", user);

            con.Open();
            command.Connection = con;

            returnValue = command.ExecuteScalar().ToString();
        }
        catch (Exception exp)
        {
            returnValue = "error";
        }

        finally
        {

            con.Close();
        }


        Response.Write(" trinn "+returnValue);

        return returnValue;

    }

    protected void TextJS_TextChanged3(object sender, EventArgs e)
    {
        //checkUsernameDuplicate(TextJS.Text);

        ViewState["result"] = checkUsernameDuplicate(TextJS.Text).ToString();
    }
    protected void TextJS_TextChanged2(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(TextJS.Text))
        {
           ViewState["result"]=checkUsernameDuplicate(TextJS.Text).ToString();

            /*if (checkUsernameDuplicate(TextJS.Text) == "1")
            {
                //lableloading.Visible = true;
                LabelUser.ForeColor = System.Drawing.Color.Red;
                LabelUser.Text = "sorry this name already exist";
                System.Threading.Thread.Sleep(2000);
            }

            else if (checkUsernameDuplicate(TextJS.Text) == "0")
            {
                //lableloading.Visible = true;
                LabelUser.ForeColor = System.Drawing.Color.Green;
                LabelUser.Text = "Ok";
                System.Threading.Thread.Sleep(2000);

            }


            else
            {
                //lableloading.Visible = true;
                LabelUser.ForeColor = System.Drawing.Color.Red;
                LabelUser.Text = "something wet wrong";
                System.Threading.Thread.Sleep(2000);
            }*/




        }
        else
        {
            Response.Write("sonehitngh ");
            //in case error disable 
            lableloading.Visible = false;
        }


    }
}