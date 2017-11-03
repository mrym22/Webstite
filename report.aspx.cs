using Microsoft.Reporting.WebForms;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class report : System.Web.UI.Page
{
    string selectedId;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void search_btn(object sender, EventArgs e)
    {
        
        string value = Text1.Value;
        //Response.Write("not null" + ViewState["selection"]);
        string stateValue = (string)ViewState["selection"];

        if (stateValue != null)
        {
           
            //// id parameter 

            if (stateValue == "0")
            {
                ReportParameter[] Params = new ReportParameter[1];
                Params[0] = new ReportParameter("id", value);

                //ReportViewer1.LocalReport.ReportPath = "Report_design.rdlc";

                ReportViewer1.ServerReport.SetParameters(Params);
                ReportViewer1.ServerReport.Refresh();


            }
            ///// name parameter 
            else
            {
                ReportParameter[] Params = new ReportParameter[1];
                Params[0] = new ReportParameter("name", value);

                ReportViewer1.LocalReport.ReportPath = "@Report_design.rdlc";

                ReportViewer1.LocalReport.SetParameters(Params);
                ReportViewer1.LocalReport.Refresh();


            }

    }
            




        }
    

    protected void radio_selection(object sender, EventArgs e)
    {

        selectedId = RadioButtonList1.SelectedItem.Value;
        ViewState["selection"] = selectedId;

       
    }


}