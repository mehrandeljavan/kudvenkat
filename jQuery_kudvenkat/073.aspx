<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="073.aspx.cs" Inherits="jQuery_kudvenkat._073" %>

 <!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtName').autocomplete({
                minLength: 2,
                source: function (request, response) {
                    $.ajax({
                        url: '073_StudentService.asmx/GetStudentNames',
                        method: 'post',
                        contentType: 'application/json;charset=utf-8',
                        data: JSON.stringify({ term: request.term }),
                        dataType: 'json',
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (err) {
                            alert(err);
                        }
                    });
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        Student Name :
        <asp:TextBox ID="txtName" runat="server">
        </asp:TextBox>
    </form>
</body>
</html>
