<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addNewProduct.aspx.cs" Inherits="addNewProduct" %>

<%@ Register Src="~/WebUserControl.ascx" TagPrefix="uc1" TagName="WebUserControl" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"  TagPrefix="ajaxToolkit"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js" type="text/javascript"></script>
        <script type="text/javascript">

            function showResult() {
               
                alert("dfkdgh");

                PageMethods.checkAavilability2(document.getElementById("<%=TextJS.ClientID%>").value, onSuccess);
               
            }
            function onSuccess(response) {

               

                

                var msg = document.getElementById("LabelUser");

                msg.innerHTML = "";
                       
               
                switch (response) {
                    case "1":
                        msg.style.color = "red";
                        msg.innerHTML = "sorry this name already exist!!";
                        break;

                    case "0":
                        msg.style.color = "green";
                        msg.innerHTML = "Ok!!";
                        break;

                    case "error":
                        msg.style.color = "red";
                        msg.innerHTML = "an error has been occured";
                        break;
                }
            }
                

                /*function onChange(txt) {

                    document.getElementById("LabelUser").innerHTML = "";
                    
                }*/
   
   
    </script>

  
<link href="Content/bootstrap.css" rel="stylesheet" />


    <style type="text/css">

       #tablestyle {
            border: 2px yellow double;
        }
        .auto-style1 {
            width: 41%;
        }
        .auto-style2 {
        }
        .auto-style3 {
            width: 347px;
        }
        .auto-style4 {
            width: 316px;
            height: 26px;
        }
        .auto-style5 {
            width: 347px;
            height: 26px;
        }
        .auto-style6 {
            width: 100%;
        }

         .WordWrap {
            width: 100%;
            word-break: break-all;
        }
    </style>


</head>
<body>
    <form id="form1" runat="server">
    
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        
        <script type="text/javascript">
            var sys = Sys.WebForms.PageRequestManager.getInstance();

            sys.add_beginRequest(BeginRequestHandler);
            sys.add_endRequest(EndRequestHandler);
            
                
            function BeginRequestHandler(sender, args) {
                //var state = document.getElementById("userDiv").style.display;

                //alert("state " + state);

                var pop = $find('<%=modelpup.ClientID%>');
                if (pop != null) {
                    pop.show();
                }
                /*if (state == 'block') {
                    document.getElementById("userDiv").style.display = 'none';


                }

                else {
                    document.getElementById("userDiv").style.display = 'block';
                    
                }*/


                //args.get_postBackElement().disabled = true;
            }

            function EndRequestHandler(sender, args) {

                var pop = $find('<%=modelpup.ClientID%>');
                if (pop != null) {
                    pop.hide();
                }
                //document.getElementById("LabelUser").innerHTML = ViewState["result"];

                string king =ViewState["result"];

                alert("reultl "+king);
               /* var state = document.getElementById("userDiv").style.display;
                alert("state " + state);

                if (state == 'block') {
                    document.getElementById("userDiv").style.display = 'none';
                    

                }

                document.getElementById("LabelUser").innerHTML = "jdhfjdh";*/
            }

          
        </script>

  
        <div class="row">
            <div class="col-md-4">
                <div class="panel panel-info text-center">
                    <div class="panel-body">
                        <span class="glyphicon glyphicon-apple"></span>
                        <h4>This is panel 1</h4>
                        <p>
                            Nam velit est, tempor vel posuere et, auctor a lectus. Aenean gravida, est accumsan dictum rhoncus, lectus mi suscipit lacus, suscipit accumsan augue tellus vitae dolor. Morbi in euismod dui
                        </p>
                    </div>

                </div>

            </div>

             <div class="col-md-4">
                 <div class="panel panel-info text-center">
                    <div class="panel-body">
                        <span class="glyphicon glyphicon-pencil"></span>
                        <h4>This is panel 2</h4>
                        <p>
                            Nam velit est, tempor vel posuere et, auctor a lectus. Aenean gravida, est accumsan dictum rhoncus, lectus mi suscipit lacus, suscipit accumsan augue tellus vitae dolor. Morbi in euismod dui
                        </p>
                    </div>

                </div>


            </div>

             <div class="col-md-4">

                 <div class="panel panel-info text-center">
                    <div class="panel-body">
                        <span class="glyphicon glyphicon-apple"></span>
                        <h4>This is panel 3</h4>
                        <p>
                            Nam velit est, tempor vel posuere et, auctor a lectus. Aenean gravida, est accumsan dictum rhoncus, lectus mi suscipit lacus, suscipit accumsan augue tellus vitae dolor. Morbi in euismod dui
                        </p>
                    </div>

                </div>

            </div>

        </div>

      
        <div class="row">
            <div class="col-lg-4">
            <div class="form-horizontal">

                <div class="form-group">
                  <label class="col-lg-5 control-label">product Name</label>
                 
                    <div class="col-lg-7">

                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                         <ContentTemplate>

                             <div class="col-lg-5">
                                 <asp:textbox id="TextJS" type="text" runat="server" class="form-control"
                                     OnTextChanged="TextJS_TextChanged3" AutoPostBack="true" EnableViewState="true"></asp:textbox>
                                </div>

                            
                             <div class="col-lg-1" id="lableloading" runat="server">
                                 &nbsp;
                                  <asp:Label ID="LabelUser" runat="server" Text="rgrggrrg"></asp:Label>
                                  </div>

                              </ContentTemplate>
                             

                         </asp:UpdatePanel>

                       <asp:UpdateProgress ID="UpdateProgress22" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                        <ProgressTemplate>
                                 <div class="col-lg-1" id="userDiv"  runat="server" ><!--style="display:block"-->
                                     
                                 <img src="images/loading.png" id="imageLoading"/>
                                
                             </div>
                        </ProgressTemplate>
                        </asp:UpdateProgress>
                       
                        <ajaxToolkit:ModalPopupExtender ID="modelpup" runat="server" TargetControlID="UpdateProgress22" PopupControlID="UpdateProgress22"
                            ></ajaxToolkit:ModalPopupExtender>

                      </div>
   
                         
                      </div>


                 <div class="form-group">
                  <label class="col-lg-5 control-label">Product Description</label>
                    <div class="col-lg-7">
                        <textarea id="Textarea1" runat="server" class="form-control"></textarea>
                    </div>
                </div>

                 <div class="form-group">
                  <label class="col-lg-5 control-label">Photo Upload</label>
                    <div class="col-lg-7">
                        <asp:FileUpload ID="FileUpload3" runat="server" ViewStateMode="Enabled"/>
                    </div>
                </div>

                 <div class="form-group">
                  <label class="col-lg-5 control-label">File Uplaod</label>
                    <div class="col-lg-7">
                       <asp:FileUpload ID="FileUpload4" runat="server" ViewStateMode="Enabled"/>
                    </div>
                </div>

                <div class="form-group">

                    <div class="col-lg-7 col-lg-offset-5">

                        <asp:Button ID="Button1" runat="server" Text="Save" CssClass="btn btn-primary" 
                          />

                         <!-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                         <ContentTemplate>
                        <asp:Button ID="Button2" runat="server" Text="Save" CssClass="btn btn-primary" 
                          onclick="testing"/>
                             </ContentTemplate>
                              </asp:UpdatePanel>


                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                        <ProgressTemplate>
                                <img src="images/loading.png"/>
                        </ProgressTemplate>
                        </asp:UpdateProgress>-->
        
                </div>
                    </div>
                 

            </div>
               
    </div>
</div>

      

        <br />
        <br />
      

        <div class="table-responsive">
        <table class="auto-style1" id="tablestyle">
            <caption style="color: #FF0000; font-style: normal; font-size: medium" class="auto-style4">Add new Product detailsd
                </caption>
                  <tr>
                    <td class="auto-style5 col-lg-2">Product Name :</td>
                    <td><input id="TextProdName" type="text" runat="server" /></td>
             
            </tr>
            <tr>
                <td class="auto-style2">Product&nbsp; Description :</td>
                <td class="auto-style3">
                    <input id="TextProdDesc" type="text" runat="server"/></td>
            </tr>
            <tr>
                <td class="auto-style2">Product Photo :</td>
                <td class="auto-style3">
                    <asp:FileUpload ID="FileUpload1" runat="server" ViewStateMode="Enabled"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Upload File:&nbsp;</td>
                <td class="auto-style3">
                    <asp:FileUpload ID="FileUpload2" runat="server" ViewStateMode="Enabled"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Button ID="savebtn" runat="server" OnClick="savebtn_Click" Text="Save" Width="114px" />
                    <asp:Button ID="testbtn" runat="server" OnClick="testbtn_Click" style="margin-left: 26px" Text="Button" Width="135px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Label ID="msgError1" runat="server" ForeColor="#CC0000" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Label ID="msgError2" runat="server" ForeColor="#CC0000" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>

            </div>
        <br /><br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [products]"></asp:SqlDataSource>
        <br />
      

       <div class="WordWrap"> 
           <div id="row">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="proId" DataSourceID="SqlDataSource1" EnableModelValidation="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="bounddata"
          CssClass="table table-hover table-striped table-bordered" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
            <AlternatingRowStyle BackColor="White" />
           
            <Columns>
                <asp:BoundField DataField="proName" HeaderText="proName" SortExpression="proName" DataFormatString="{0}+TestTESTINGtestingtestingtestTestingTresingTesuting" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="col-xs-4" />
                  
                </asp:BoundField>

                <asp:BoundField DataField="proDescription" HeaderText="proDescription" SortExpression="proDescription" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="col-xs-4" />
                </asp:BoundField>

                <asp:TemplateField HeaderText="Img" >
                    <ItemTemplate>
                         <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/upload/"+Eval("proImage") %>'
                             Height="200px" Width="200px" />
                    </ItemTemplate>
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>

                </asp:TemplateField>
 
               
                <asp:TemplateField HeaderText="File">
                    <ItemTemplate>
           
                      <asp:LinkButton 
 ID="hLink" runat="server" Text="Link" Target="_blank"
                           CssClass="col-xs-4" OnClick="downloadme" 
                          CommandArgument='<%# Eval("proFile")%>'/>
                 </ItemTemplate>
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
               
                     
            </Columns>

           
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        </asp:GridView>
              </div> </div> 
        <br />
        <br />

   
        <asp:DataList ID="DataList1" runat="server" DataKeyField="proId" DataSourceID="SqlDataSource1" RepeatColumns="2" CellSpacing="20" OnSelectedIndexChanged="DataList1_SelectedIndexChanged1">
            <ItemTemplate>
        
                <table  class="auto-style6" style="border-spacing:10px">
                   
                    <tr>
                        <td style="color: #FF0000; font-weight: bold;">Product Name:</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="TextBox1" runat="server" Height="16px" Text='<%# Eval("proName") %>' Width="187px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="color: #FF0000; font-weight: bold;">product description :</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="TextBox2" runat="server" Height="16px" Text='<%# Eval("proDescription") %>' Width="192px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# "../upload/"+Eval("proImage") %>' Width="200px"
                                height="200px"/>
                        </td>
                    </tr>
                       
                </table>   
                <br />
                <br />
            </ItemTemplate>
        </asp:DataList>
     

    </form>
</body>
</html>
