<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="062_WebForm1.aspx.cs" Inherits="ASPNet_kudvenkat._062_WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>This is Webform1</td>
                </tr>
                <tr>
                    <td>Name</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Email</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSendData" runat="server" Text="Send Data" OnClick="btnSendData_Click1" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
