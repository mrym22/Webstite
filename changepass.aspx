<%@ Page Language="C#" AutoEventWireup="true" CodeFile="changepass.aspx.cs" Inherits="changepass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
            <td class="auto-style2">Password :</td>
            <td>
                <span>
                <input id="Textpass" type="text" runat="server" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Missing pass" ControlToValidate="Textpass" ></asp:RequiredFieldValidator>&nbsp;</span></td>
        </tr>
        <tr>
            <td class="auto-style2">Confirm Password :</td>
            <td><span>
                <input id="Textconfpass" type="text"  runat="server"/>
                </span></td>
        </tr>
        <tr>
            <td class="auto-style2" colspan="2">

                <asp:button 
           ID="Buttonlog"
           Text="Save"
           runat="server" OnClick="save_btn" style="margin-bottom: 1px" Width="134px"
           />
              </td>  
               
        </tr>
    </table>
        <p>
            &nbsp;</p>
        <asp:Label ID="Labelerror" runat="server" ForeColor="Red"></asp:Label>
    </form>
    </body>
</html>
