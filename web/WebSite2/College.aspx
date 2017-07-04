<%@ Page Language="C#" AutoEventWireup="true" CodeFile="College.aspx.cs" Inherits="College" %>

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
								<li><a href="login.html"><i class="halflings-icon off"></i> 登出</a></li>
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
						<li><a href="index.html"><i class="icon-bar-chart"></i><span class="hidden-tablet"> 系管理</span></a></li>	
						<li><a href="application2.html"><i class="icon-envelope"></i><span class="hidden-tablet"> 系主任&辅导员管理</span></a></li>
						<li><a href="application3.html"><i class="icon-tasks"></i><span class="hidden-tablet"> 班级管理</span></a></li>
						<li><a href="application4.html"><i class="icon-eye-open"></i><span class="hidden-tablet">班主任管理</span></a></li>
						<li><a href="application5.html"><i class="icon-dashboard"></i><span class="hidden-tablet"> 学生管理</span></a></li>
					
					</ul>
				</div>
			</div>
			<div id="content" class="span10">
			<ul class="breadcrumb">
				<li>
					<i class="icon-home"></i>
					<a href="index.html">菜单</a> 
					<i class="icon-angle-right"></i>
				</li>
				<li><a href="#">系管理</a></li>
			</ul>
			<div class="row-fluid"  style="text-align: center"> 
				<a style="font-weight: 300;">系信息Excel上传：</a>
                <p style="font-weight: 600">
				 <asp:FileUpload ID="FileUpload1" runat="server" />
                </p>
                 <p style="font-weight: 600">
                 <input id="up" Value="上传" style="width: 180px;height: 30px" type="submit" runat="server" onserverclick="shangchuan_Click" />
				
				
			</div>		
			</div>
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
			<span style="text-align:left;float:left">云南民族大学 &copy; 2017.职业技术学院 &copy; 版权所有.</span>
		</p>
	</footer>
		
    </form>
</body>
</html>
