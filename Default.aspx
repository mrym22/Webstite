<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Button1 {
            width: 114px;
        }
        
        table {
            border:3px green dashed;
        }

        tr {
            background-color: pink;
        }

        tr:nth-child(even) {background-color: #f2f2f2} 
      
        .auto-style1 {
            width: 53px;
        }
        .auto-style2 {
            width: 94px;
        }
        #Text1 {
            margin-left: 33px;
        }
        #Text2 {
            margin-left: 18px;
            width: 120px;
        }
      
        </style>
</head>
<body>
    <form id="form1" runat="server">
  

        <table>
            <tr>
                <td class="auto-style1">ID</td>
                <td class="auto-style2">Name</td>
            </tr><%=getData()%>
        </table>
  
        <asp:LoginName ID="LoginName1" runat="server" OnDataBinding="Page_Load" />
  
        <br />
        <asp:Label ID="Label3" runat="server" Text="Name"></asp:Label>
    <input id="Text1" type="text" runat="server" />

    &nbsp;<p>
        <asp:Label ID="Label4" runat="server" Text="Number"></asp:Label>
        <input id="Text2" type="text" runat="server" />
        <br />
        <br />

            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rd_changed" Width="187px">
                <asp:ListItem>female</asp:ListItem>
                <asp:ListItem>male</asp:ListItem>
            </asp:RadioButtonList>
    </p>

    <p>
        <asp:button 
           ID="Button1"
           Text="Greeting"
           runat="server"
           onclick="GreetingBtn_Click" />  

         <asp:button 
           ID="Buttonupdate"
           Text="Update"
           runat="server"
           onclick="UpdateBtn_Click" style="margin-left: 22px" Width="110px" />  


         <asp:button 
           ID="Buttondelete"
           Text="delete"
           runat="server"
           onclick="DltBtn_Click" style="margin-left: 22px" Width="110px" />  


    </p>
        
   <label id="GreetingLabel" runat="server"></label>

  

        <p>
           <label id="lb2" runat="server">Please choose your order bellow :</label>
            <asp:Button ID="Button4" runat="server" OnClick="test_clickbtn" Text="testdelete" />
        </p>
   
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True">
            <asp:ListItem>Pizza</asp:ListItem>
            <asp:ListItem>pasta</asp:ListItem>
            <asp:ListItem>soup</asp:ListItem>
        </asp:CheckBoxList>


        <asp:SqlDataSource ID="SqlDataSource1"  runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [customer]"></asp:SqlDataSource>


        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="delete frrom customer where id=@idval" InsertCommand="insert into customer(name,password) values (@nameval,@idvalue)" OnSelecting="SqlDataSource2_Selecting" SelectCommand="select * from customer" UpdateCommand="update customer set name =@nameval where id=@idval">
            <DeleteParameters>
                <asp:Parameter Name="idval" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="nameval" Type="String" />
                <asp:Parameter Name="idvalue" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="nameval" />
                <asp:Parameter Name="idval" />
            </UpdateParameters>
        </asp:SqlDataSource>


    <br />
    <asp:button 
           ID="Button2"
           Text="Submit"
           runat="server"
           onclick="subBtn_Click" />
    <br />
     <label id="Label2" runat="server"></label>

    <% for (int i = 0; i < 3; i++)
       {%>
        <h2>Hello it's me</h2>
        <% }
         %>
<asp:Button ID="Button3" runat="server" OnClick="go_button" Text="go to" />


        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
            <HeaderTemplate>
                 <table>
                    <tr>
                        <th class="auto-style1">
                            ID
                        </th>
                        <th class="auto-style2">
                            Name
                        </th>
                    </tr>

            </HeaderTemplate>
            <ItemTemplate>

                    <tr>
                        <th>
                       <%#Eval("id")%>
                        </th>
                        <th>
                           <%#Eval("name")%>
                        </th>
                    </tr>
               

            </ItemTemplate> 

            <FooterTemplate>
                </table>
            </FooterTemplate>
           
        </asp:Repeater>
        </form>

    
              
</body>
</html>
