<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homework.aspx.cs" Inherits="OpenEvaluation.homework" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblUseranme" runat="server" Text="XXXX "></asp:Label>(<asp:Label ID="lblTrueName" runat="server" Text="XXXX "></asp:Label>)
        你好&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 你还有
    
        <asp:Label ID="lblCount" runat="server" Text="XXXX " ForeColor="Red"></asp:Label>
        &nbsp; 个作品未评分,总共有<asp:Label ID="lblTotal" runat="server" Text="XXXX " ForeColor="Red"></asp:Label>个作品<br />
        <br />
        作业：<asp:Label ID="lblHomework" runat="server" Text="Label"></asp:Label><asp:Label ID="lblHomeworkID" Visible="false" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
       
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="开始互评" />
    
    </div>
    </form>
</body>
</html>
