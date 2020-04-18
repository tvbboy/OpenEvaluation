<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="OpenEvaluation.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        用户名：<asp:TextBox ID="txtUsername" runat="server" Width="162px"></asp:TextBox>
        <br />
        密 码：<asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="登录" />
         <br />
        THANKS:
        (1) 2020年4月13日  杨赟修复SQL注入BUG！
        <br />
        To be continue ...........
        <br />
        对以上同学所作贡献，表示感谢
    </div>
    </form>
</body>
</html>
