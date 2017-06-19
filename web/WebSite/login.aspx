<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>云南民族大学学籍管理系统</title>
	<link rel="stylesheet" type="text/css" href="/CSS/normalize.css" />
	<link rel="stylesheet" type="text/css" href="/CSS/default.css">
	<link rel="stylesheet" type="text/css" href="/CSS/styles.css">
</head>
<body>
    <form id="form1" runat="server">
    <div class="htmleaf-container">
		<header class="htmleaf-header">
			<h1>云南民族大学学籍管理系统<span></span></h1>
			
		</header>
		<div class="login-wrap">
			<div class="login-html">
				<input id="tab-1" type="radio" name="tab" class="sign-in" checked><label for="tab-1" class="tab">学生登录</label>
				<input id="tab-2" type="radio" name="tab" class="sign-up"><label for="tab-2" class="tab"></label>
				<div class="login-form">
					<div class="sign-in-htm">
						<div class="group">
							<label for="user" class="label">用户名</label>
		
                            <asp:TextBox ID="id" runat="server" CssClass="TextBoxStyle"></asp:TextBox>                          
						</div>
						<div class="group">
							&nbsp;
                            <asp:TextBox ID="pwd" runat="server" CssClass="TextBoxStyle" TextMode="Password"></asp:TextBox>
						</div>
						<div class="group">
						
                            <asp:Button ID="Denglu" runat="server" Text="登录" CssClass="ButtonStyle" OnClick="DengluClick"/>
						</div>
						<div class="hr"></div>			
					</div>
					<div class="sign-up-htm">
						
                        </div>																
					</div>
				</div>
			</div>
		</div>
		<div class="related">
		云南民族大学职业技术学院版权所有
		</div>
						
    </form>
</body>
</html>
