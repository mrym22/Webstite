<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Text1 {
            width: 169px;
            height: 28px;
        }
        #Textusername {
            width: 167px;
            height: 26px;
        }
        #Textusername0 {
            width: 167px;
            height: 26px;
        }
        #Button1 {
            width: 120px;
        }
        .auto-style2 {
            width: 125px;
        }
        #Textpassword {
            width: 167px;
            height: 26px;
        }
        #login {
            width: 94px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
    <table style="width: 45%; height: 111px;">
        <tr>
            <td class="auto-style2">username :</td>
            <td>
                <span>
                <input id="Textusername" type="text" runat="server" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Missing username" ControlToValidate="Textusername" ></asp:RequiredFieldValidator>&nbsp;</span></td>
        </tr>
        <tr>
            <td class="auto-style2">password :</td>
            <td><span>
                <input id="Textpassword" type="text"  runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Missing password" ControlToValidate="Textpassword"></asp:RequiredFieldValidator></span></td>
        </tr>
        <tr>
            <td class="auto-style2" colspan="2">
                <asp:CheckBox ID="CheckBox1"  runat="server" Text="remember me" />

                <asp:button 
           ID="Buttonlog"
           Text="Login"
           runat="server" OnClick="login_btn" style="margin-bottom: 1px" Width="134px"
           />
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/fortgetpass.aspx">reset password</asp:HyperLink>
               </td>
        </tr>
    </table>
        <p>
            &nbsp;</p>
        
    </form>
    </body>
</html>
