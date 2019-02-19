<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="musterigirisi.aspx.cs" Inherits="müsterimodülü.musterigirisi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 112px">
    
        <asp:Label ID="Label1" runat="server" Text="MÜŞTERİ E-MAİL:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 32px" Width="281px"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="ŞİFRE:"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" Width="195px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" ForeColor="#990099" Height="26px" OnClick="Button1_Click" style="margin-left: 541px" Text="OTURUM AÇ" Width="124px" />
    
    </div>
    </form>
</body>
</html>
