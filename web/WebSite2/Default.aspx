
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
      <a style="font-weight: 300;">系信息Excel上传：</a>
                <p style="font-weight: 600">
				 <asp:FileUpload ID="FileUpload1" runat="server" />
                </p>
                 <p style="font-weight: 600">
                 <input id="up" Value="上传" style="width: 180px;height: 30px" type="submit" runat="server" onserverclick="shangchuan_Click" />
                 </p>
    </form>
</body>
</html>
