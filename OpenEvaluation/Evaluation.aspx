<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Evaluation.aspx.cs" Inherits="OpenEvaluation.Evaluation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblUseranme" runat="server" Text="XXXX "></asp:Label>(<asp:Label ID="lblTrueName" runat="server" Text="XXXX "></asp:Label>)
        你好<br />
        <asp:Label ID="lblTeam" runat="server" Text="txtTEAM1 (XXX,XXX,XXX)"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblTeamID" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;（<asp:Label ID="lblCurrentNo" runat="server" Text="1"></asp:Label>
        /<asp:Label ID="lblTotal" runat="server" Text="XXXX "></asp:Label>
        ）<br />
        <asp:TextBox ID="txtItem1" runat="server"></asp:TextBox>
        0-30&nbsp;&nbsp; <span style="color: rgb(17, 17, 17); font-family: &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; font-size: 13px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">切中主题(6分)，语言组织合理（6分），调研充分（6分），条理清晰（6分），视频流畅（6分）<br />
        <br />
        </span>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtItem1" ErrorMessage="输入有误" ForeColor="#FF3300" MaximumValue="30" MinimumValue="0" Type="Double"></asp:RangeValidator>
        <br />
        <asp:TextBox ID="txtItem2" runat="server"></asp:TextBox>
        0-20&nbsp;&nbsp; <span style="color: rgb(17, 17, 17); font-family: &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; font-size: 13px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(244, 244, 244, 0.59); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">模拟程序的合理性，规范性<br />
        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtItem2" ErrorMessage="输入有误" ForeColor="#FF3300" MaximumValue="20" MinimumValue="0" Type="Double"></asp:RangeValidator>
        </span><br />
        <asp:TextBox ID="txtItem3" runat="server"></asp:TextBox>
        0-20&nbsp;&nbsp; <span style="color: rgb(17, 17, 17); font-family: &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; font-size: 13px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(244, 244, 244); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">PPT制作是否精良，是否符合切中主题<br />
        <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtItem3" ErrorMessage="输入有误" ForeColor="#FF3300" MaximumValue="20" MinimumValue="0" Type="Double"></asp:RangeValidator>
        </span><br />
        <asp:TextBox ID="txtItem4" runat="server"></asp:TextBox>
        0-20&nbsp; <span style="color: rgb(17, 17, 17); font-family: &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; font-size: 13px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(244, 244, 244); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">&nbsp;&nbsp; 结论是否得到了足够的支撑</span>&nbsp;
        <br />
        <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txtItem4" ErrorMessage="输入有误" ForeColor="#FF3300" MaximumValue="20" MinimumValue="0" Type="Double"></asp:RangeValidator>
        <br />
        <asp:TextBox ID="txtItem5" runat="server"></asp:TextBox>
        0-10&nbsp; <span style="color: rgb(17, 17, 17); font-family: &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; font-size: 13px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">&nbsp;&nbsp; 细节分：视频有没有超过规定时长，有没有露脸<br />
        <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txtItem5" ErrorMessage="输入有误" ForeColor="#FF3300" MaximumValue="10" MinimumValue="0" Type="Double"></asp:RangeValidator>
        </span><br />
        <asp:Button ID="Button1" runat="server" Text="评分" OnClick="Button1_Click" />
    
    &nbsp;
        <asp:Button ID="Button2" runat="server" Text="返回主页" OnClick="Button2_Click" />
    
    </div>
    </form>
</body>
</html>
