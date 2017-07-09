<%@ Page Language="C#" AutoEventWireup="true" CodeFile="demo2.aspx.cs" Inherits="demo2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
              <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="Button1"/>
            </Triggers>
        </asp:UpdatePanel>
        
       
    </div>
    </form>
</body>
</html>
