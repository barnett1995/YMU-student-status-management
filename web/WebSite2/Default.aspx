
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>
<%@ Import Namespace="System.Data" %>
 
<script runat="server">
 
   
</script>
 
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
 
 
 
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;<asp:GridView ID="GridView1" runat="server" AllowPaging="True" DataKeyNames="ProductID" AutoGenerateColumns="False" Width="589px" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox  ID="checkD" runat="server"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="11" DataField="ProductID">
                    <ItemStyle Width="20%" />
                </asp:BoundField>
                <asp:BoundField HeaderText="22" DataField="ProductName">
                    <ItemStyle Width="20%" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" /></div>
    </form>
</body>
</html>
