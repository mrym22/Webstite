<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fortgetpass.aspx.cs" Inherits="fortgetpass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Text1 {
            margin-left: 37px;
        }
        #Textreqname {
            width: 152px;
            margin-left: 21px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>

        <input id="Textreqname" type="text" runat="server" />
        <p>
            <asp:Button ID="Buttonsend" runat="server" style="margin-left: 76px" Text="Send" Width="124px" OnClick="Buttonsend_Click" />
        </p>
        <asp:Label ID="Labelmsg" runat="server" Text="Label" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
