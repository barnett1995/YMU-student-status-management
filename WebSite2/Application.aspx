<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Application.aspx.cs" Inherits="_Default" %>

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
    <div class="navbar">>
		<div class="navbar-inner">
			<div class="container-fluid">
				<a class="btn btn-navbar" data-toggle="collapse" data-target=".top-nav.nav-collapse,.sidebar-nav.nav-collapse">
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
				</a>
				<a class="brand" href="College.aspx"><span><h2>云南民族大学学籍管理系统(学院端) 系管理 </h2></span></a>
								
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
						<li><a href="College.aspx"><span class="hidden-tablet"> 系管理</span></a></li>	
						<li><a href="College1.aspx"><span class="hidden-tablet"> 系主任&辅导员管理</span></a></li>
						<li><a href="College2.aspx"><span class="hidden-tablet"> 班级管理</span></a></li>
						<li><a href="College3.aspx"><span class="hidden-tablet">班主任管理</span></a></li>
						<li><a href="College4.aspx"><span class="hidden-tablet"> 学生管理</span></a></li>
                        <li><a href="Application.aspx"><span class="hidden-tablet"> 学生修改申请</span></a></li>
					
					</ul>
				</div>
			</div>
			<div id="content" class="span10">
			<ul class="breadcrumb">
				<li>
					<i class="icon-home"></i>
					<a href="College.aspx">菜单</a> 
					<i class="icon-angle-right"></i>
				</li>
				<li><a href="College.aspx">系管理</a></li>
			</ul>
			<div class="row-fluid"  style="text-align: center"> 

                     <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
        	<asp:UpdatePanel ID="UpdatePanel3" runat="server">
              <ContentTemplate>
                    <asp:GridView ID="GridView2" runat="server" Height="133px" Width="800px"
                  AutoGenerateColumns="False" DataKeyNames="id"  align="center"
                 BackColor="White" BorderColor="White"   
                  BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"  CellSpacing="1"   
                  GridLines="None"                  
                   HorizontalAlign="Center" AllowPaging="True" PageSize="15"
                
                 >   
              <Columns>    
                  
                     <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" Font-Sizep="9pt" OnCheckedChanged="CheckBox2_CheckedChanged" Text="全选" />
                        </HeaderTemplate>
                        <ItemTemplate>
                             <asp:CheckBox ID="CheckBox1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ID" HeaderText="学号" ReadOnly="True"/>    
                    <asp:BoundField DataField="Name" HeaderText="姓名" DataFormatString="{0:000#}" /> 
                    <asp:BoundField DataField="nianji" HeaderText="年级" DataFormatString="{0:000#}" /> 
                    <asp:BoundField DataField="CLM" HeaderText="班级" DataFormatString="{0:000#}" ReadOnly="True"  />  
                    <asp:TemplateField>
                        <HeaderTemplate>
                           查看学生信息
                        </HeaderTemplate>
                         <ItemTemplate>
                            <asp:UpdatePanel UpdateMode="Conditional" ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                      <asp:Button ID="chakan" runat="server" Text="查看信息" AutoPostBack="True" OnClick="chakan_Click" />
                                </ContentTemplate>
                                <Triggers>
                                   <asp:PostBackTrigger ControlID="chakan"  />
                                </Triggers>
                            </asp:UpdatePanel>
                        </ItemTemplate>
                    </asp:TemplateField> 
                      <asp:TemplateField>
                        <HeaderTemplate>
                           修改审核
                        </HeaderTemplate>
                         <ItemTemplate>
                            <asp:UpdatePanel UpdateMode="Conditional" ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                      <asp:Button ID="true" runat="server" Text="同意修改" AutoPostBack="True" OnClick="true_Click" />
                                </ContentTemplate>
                                <Triggers>
                                   <asp:PostBackTrigger ControlID="true"  />
                                </Triggers>
                            </asp:UpdatePanel>
                        </ItemTemplate>
                    </asp:TemplateField> 
 
                      <asp:TemplateField>
                        <HeaderTemplate>
                           修改审核
                        </HeaderTemplate>
                         <ItemTemplate>
                            <asp:UpdatePanel UpdateMode="Conditional" ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                      <asp:Button ID="false" runat="server" Text="不同意修改" AutoPostBack="True" OnClick="false_Click" />
                                </ContentTemplate>
                                <Triggers>
                                   <asp:PostBackTrigger ControlID="false"  />
                                </Triggers>
                            </asp:UpdatePanel>
                        </ItemTemplate>
                    </asp:TemplateField> 
                              
                   
               </Columns>    
               <RowStyle BackColor="#DEDFDE" ForeColor="Black" />    
               <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />    
               <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />    
               <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />    
               <HeaderStyle BackColor="#003532" Font-Bold="True" ForeColor=" #FFFFFF" />             
           </asp:GridView>   
                 </ContentTemplate>         
    </asp:UpdatePanel>
          <p style="font-weight: 300">	

        <p style="font-weight: 300; width: 579px;">
        <asp:Button ID="Button1" runat="server" style="width: 100px;height: 30px" Font-Size="12pt" Text="取消全选" OnClick="Button1_Click" />
        &nbsp; &nbsp;
        <asp:Button ID="Button2" runat="server" style="width: 100px;height: 30px" Font-Size="12pt" Text="全部同意" OnClick="Button2_Click" />
         &nbsp; &nbsp;
        <asp:Button ID="Button3" runat="server" style="width: 100px;height: 30px" Font-Size="12pt" Text="全部不同意" OnClick="Button3_Click" />

				
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
