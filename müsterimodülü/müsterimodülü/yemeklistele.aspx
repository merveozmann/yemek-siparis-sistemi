<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yemeklistele.aspx.cs" Inherits="müsterimodülü.yemeklistele" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 664px; margin-left: 5px">
    
        <asp:Label ID="Label1" runat="server" Text="RESTORAN İSİMİ:"></asp:Label>
&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" style="margin-left: 13px" Width="203px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        KATEGORİ İSİMİ:<asp:DropDownList ID="DropDownList2" runat="server" Height="17px" style="margin-left: 21px" Width="208px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        YEMEK LİSTESİ:<br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="176px" Width="522px" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>

                


                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("yemekismi") %>'></asp:Label>
                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("yemekaciklamasi") %>'></asp:Label>
                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("hazirlamasuresi") %>'></asp:Label>
                        <asp:Label ID="Label10" runat="server" Text='<%# Eval("fiyati") %>'></asp:Label> 
                       
                        <asp:Button ID="Button1" runat="server" Text="SEC" CommandName= "GOSTER" CommandArgument ='<%#Eval ("yemekid") %>'/>
                       
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <br />
        OPSİYON LİSTESİ:<br />
        <br />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="392px" OnRowCommand="GridView2_RowCommand">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="Label11" runat="server" Text='<%#Eval ("opsiyonadi") %>'></asp:Label>
                        <asp:Label ID="Label12" runat="server" Text='<%#Eval ("opsiyonfiyati") %>'></asp:Label>
                        <asp:Button ID="Button2" runat="server" Text="SEC" CommandName ="EKLE"  CommandArgument ='<%#Eval ("yemekopsiyonid") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Text="SEPETE EKLE" Width="157px" OnClick="Button3_Click" />
        <br />
    
    </div>
    </form>
</body>
</html>
