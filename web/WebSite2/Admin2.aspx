<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin2.aspx.cs" Inherits="Admin2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta charset="utf-8">
	<title>云南民族大学学籍管理系统(学院端)</title>
	<meta name="description" content="Bootstrap Metro Dashboard">
	<meta name="author" content="">
	<meta name="keyword" content="">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link id="bootstrap-style" href="css/bootstrap.min.css" rel="stylesheet">
	<link href="css/bootstrap-responsive.min.css" rel="stylesheet">
	<link id="base-style" href="css/style.css" rel="stylesheet">
	<link id="base-style-responsive" href="css/style-responsive.css" rel="stylesheet">
	<link rel="shortcut icon" href="img/favicon.ico">
	<link rel="stylesheet" href="css/table.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
     </asp:ScriptManager>
	<div class="navbar">
		<div class="navbar-inner">
			<div class="container-fluid">
				<a class="btn btn-navbar" data-toggle="collapse" data-target=".top-nav.nav-collapse,.sidebar-nav.nav-collapse">
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
				</a>
				<a class="brand" href="index.html"><span><h2>云南民族大学学籍管理系统(学院端)</h2></span></a>
								
				<!-- start: Header Menu -->
				<div class="nav-no-collapse header-nav">
					<ul class="nav pull-right">
						<li class="dropdown hidden-phone">
                
						</li>
						<li class="dropdown">
							<a class="btn dropdown-toggle" data-toggle="dropdown" href="#">
								<i class="halflings-icon white user"></i> 
								<span class="caret"></span>
							</a>
							<ul class="dropdown-menu">
								<li class="dropdown-menu-title">
 									<span>账户设置</span>
								</li>
								<li><a href="login.aspx"><i class="halflings-icon off"></i> 登出</a></li>
							</ul>
						</li>
					</ul>
				</div>
			</div>
		</div>
	</div>
		<div class="container-fluid-full">
		<div class="row-fluid">
			<!-- 菜单部分 -->
			<div id="sidebar-left" class="span2">
				<div class="nav-collapse sidebar-nav">
					<ul class="nav nav-tabs nav-stacked main-menu">
				        <li><a href="Admin0.aspx"><span class="hidden-tablet"> 班级管理</span></a></li>
						<li><a href="Admin1.aspx"><span class="hidden-tablet">班主任管理</span></a></li>
						<li><a href="Admin2.aspx"><span class="hidden-tablet">学生管理</span></a></li>
					</ul>
				</div>
			</div>
			<noscript>
			</noscript>
			<div id="content" class="span10">
			<ul class="breadcrumb">
				<li>
					<i class="icon-home"></i>
					<a href="Admin2.aspx">菜单</a> 
					<i class="icon-angle-right"></i>
				</li>
				<li><a href="Admin0.apsx">学生信息管理</a></li>
			</ul>
			<div class="row-fluid"  style="text-align: center"> 
				 
				<h2 style="font-weight: 300;">学生信息Excel上传：</h2>
                 <p style="font-weight: 600">
				 <asp:FileUpload ID="FileUpload1" runat="server" />
                 </p>
                 <p style="font-weight: 600">
                 <input id="up" value="上传" style="width: 180px;height: 30px" type="submit" runat="server" onserverclick="shangchuan_Click" />
                 </p>
				
                        <h2 style="font-weight: 600;">单条添加学生信息：</h2>
                <p style="font-weight: 600">学号：<input id="upid" type="text" runat="server" /></p>
				<p style="font-weight: 600">姓名：<input id="upname" type="text" runat="server" /></p>
				<p style="font-weight: 600">密码：<input id="uppwd" type="text" runat="server" /></p>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <p style="font-weight: 600">选择学院:
                    <asp:DropDownList ID="xylist" runat="server" Width="206px" AutoPostBack="True" OnSelectedIndexChanged="xylist_SelectedIndexChanged"></asp:DropDownList>
                    </p>
                    <p style="font-weight: 600">选择系：
                    <asp:DropDownList ID="xilist" runat="server"  Width="206px" AutoPostBack="True" OnSelectedIndexChanged="xilist_SelectedIndexChanged"></asp:DropDownList>
                    </p>
                    <p style="font-weight: 600">选择班级:                                 
                    <asp:DropDownList ID="banjilist" runat="server" Width="206px"></asp:DropDownList>
                    </p>
                    <p style="font-weight: 600">选择年级：
                    <asp:DropDownList ID="nianjilist" runat="server" Width="206px" >
                                        <asp:ListItem>2014级</asp:ListItem>
                                        <asp:ListItem>2015级</asp:ListItem>
                                        <asp:ListItem>2016级</asp:ListItem>
                                        <asp:ListItem>2017级</asp:ListItem>
                                        <asp:ListItem>2018级</asp:ListItem>
                                        <asp:ListItem>2019级</asp:ListItem>
                                        <asp:ListItem>2020级</asp:ListItem>
                                           
                   </asp:DropDownList>
                   </p>
                </ContentTemplate>
                </asp:UpdatePanel>
                <p style="font-weight: 300">
                <input id="add" type="submit" value="保存" style="width: 180px;height: 30px" runat="server" onserverClick="add_ServerClick"
                    >
                </p>              
                <p style="font-weight: 800">
                    &nbsp; 
               
              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
              <ContentTemplate>
                
           
                <a style="font-weight: 600;">查询学生信息：</a>      
                <p style="font-weight: 600">选择系：
                </p>
                <p style="font-weight: 600">选择班级：
                <asp:DropDownList ID="selectbj" runat="server" Width="206px"></asp:DropDownList>
                </p>
                <p style="font-weight: 600">选择年级：
                <asp:DropDownList ID="selectnj" runat="server" Width="206px">
                    <asp:ListItem>2014级</asp:ListItem>
                    <asp:ListItem>2015级</asp:ListItem>
                    <asp:ListItem>2016级</asp:ListItem>
                    <asp:ListItem>2017级</asp:ListItem>
                    <asp:ListItem>2018级</asp:ListItem>
                    <asp:ListItem>2019级</asp:ListItem>
                    <asp:ListItem>2020级</asp:ListItem>
                </asp:DropDownList>
                </p >
                 </ContentTemplate>
                    </asp:UpdatePanel>
				    <p style="font-weight: 600">学号：<input id="xuehao" type="text" runat="server" >
				    </p>
                    <p style="font-weight: 600">
				    <input type="submit" value="查询" style="width: 180px;height: 30px" id="chaxun" runat="server" onserverclick="chaxun_ServerClick">
                    </p>
                    <input id="restart" type="submit" style="width: 180px;height: 30px" value="重置" runat="server" onserverclick="restart_ServerClick"/>
			 
			     <p style="font-weight: 600">
          
		</div>
		</div>
	<div class="modal hide fade" id="myModal">
		<div class="modal-header">
			<button type="button" class="close" data-dismiss="modal">×</button>
			<h3>Settings</h3>
		</div>
		<div class="modal-footer">
			<a href="#" class="btn" data-dismiss="modal">Close</a>
			<a href="#" class="btn btn-primary">Save changes</a>
		</div>
	</div>
	<div class="common-modal modal fade" id="common-Modal1" tabindex="-1" role="dialog" aria-hidden="true">
		<div class="modal-content">
			<ul class="list-inline item-details">
				<li><a href="http://sc.chinaz.com">Admin templates</a></li>
				<li><a href="http://sc.chinaz.com">Bootstrap themes</a></li>
			</ul>
		</div>
	</div>
	<div class="clearfix"></div>
	<footer>
		<p>
			<span style="text-align:left;float:left">云南民族大学 &copy; 2017.职业技术学院 &copy; 山沟猫版权所有.</span>
		</p>
	</footer>
		<script src="js/jquery-1.9.1.min.js"></script>
	    <script src="js/jquery-migrate-1.0.0.min.js"></script>
		<script src="js/jquery-ui-1.10.0.custom.min.js"></script>
		<script src="js/jquery.ui.touch-punch.js"></script>
		<script src="js/modernizr.js"></script>
		<script src="js/bootstrap.min.js"></script>
		<script src="js/jquery.cookie.js"></script>
		<script src='js/fullcalendar.min.js'></script>
		<script src='js/jquery.dataTables.min.js'></script>
		<script src="js/excanvas.js"></script>
	    <script src="js/jquery.flot.js"></script>
	    <script src="js/jquery.flot.pie.js"></script>
	    <script src="js/jquery.flot.stack.js"></script>
	    <script src="js/jquery.flot.resize.min.js"></script>
		<script src="js/jquery.chosen.min.js"></script>
		<script src="js/jquery.uniform.min.js"></script>
		<script src="js/jquery.cleditor.min.js"></script>
		<script src="js/jquery.noty.js"></script>
		<script src="js/jquery.elfinder.min.js"></script>
		<script src="js/jquery.raty.min.js"></script>
		<script src="js/jquery.iphone.toggle.js"></script>
		<script src="js/jquery.uploadify-3.1.min.js"></script>
		<script src="js/jquery.gritter.min.js"></script>
		<script src="js/jquery.imagesloaded.js"></script>
		<script src="js/jquery.masonry.min.js"></script>
		<script src="js/jquery.knob.modified.js"></script>
		<script src="js/jquery.sparkline.min.js"></script>
		<script src="js/counter.js"></script>
		<script src="js/retina.js"></script>
		<script src="js/custom.js"></script>
    </form>
</body>
</html>
