<%@ Page Language="C#" AutoEventWireup="true" CodeFile="demo2.aspx.cs" Inherits="demo2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
     </asp:ScriptManager>
    <div>
         <label class="label">Excel上传</label>
     
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <input id="up" type="submit" runat="server" onserverclick="shangchuan_Click">
        <p>
        
           <label class="label">信息单条上传</label>
            <p>   
           <label class="label">学号</label> <input id="upid" type="text" runat="server"/>
            <p>
           <label  class="label">姓名</label> <input id="upname" type="text" runat="server"/>
             <p>
           
           <label  class="label">密码</label> <input id="uppwd" type="text" runat="server"/>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <ContentTemplate>
            <label  class="label">选择学院</label>
            <asp:DropDownList ID="xylist" runat="server" Width="138px" AutoPostBack="True" OnSelectedIndexChanged="xylist_SelectedIndexChanged"></asp:DropDownList>
            <p>
            <label  class="label">选择系</label>
            <asp:DropDownList ID="xilist" runat="server"  Width="138px" AutoPostBack="True" OnSelectedIndexChanged="xilist_SelectedIndexChanged"></asp:DropDownList>
            <p>
            <label  class="label">选择班级</label>
            <asp:DropDownList ID="banjilist" runat="server" Width="138px"></asp:DropDownList>
            <p>
            <label  class="label">选择年级</label>
            <asp:DropDownList ID="nianjilist" runat="server" Width="138px" >
                                <asp:ListItem>2014级</asp:ListItem>
                                <asp:ListItem>2015级</asp:ListItem>
                                <asp:ListItem>2016级</asp:ListItem>
                                <asp:ListItem>2017级</asp:ListItem>
                                <asp:ListItem>2018级</asp:ListItem>
                                <asp:ListItem>2019级</asp:ListItem>
                                <asp:ListItem>2020级</asp:ListItem>
                                           
            </asp:DropDownList>
             </ContentTemplate>
              </asp:UpdatePanel>
             <p>
           <input id="add" type="submit" value="添加" runat="server" onserverClick="add_ServerClick"/>
    </div>
    </form>
</body>
</html>
