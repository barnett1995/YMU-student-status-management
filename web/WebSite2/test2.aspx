<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test2.aspx.cs" Inherits="test2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
    </div>
    </form>
</body>
</html>
