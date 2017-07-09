<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Gridview1.aspx.cs" Inherits="Gridview1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        	<asp:UpdatePanel ID="UpdatePanel3" runat="server">
              <ContentTemplate>
                    <asp:GridView ID="GridView2" runat="server" Height="133px" Width="584px"
                  AutoGenerateColumns="False" DataKeyNames="id"  align="center"
                  OnRowEditing="GridView1_RowEditing" BackColor="White" BorderColor="White"   
                  BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"  CellSpacing="1"   
                  GridLines="None"
                  OnRowUpdating="GridView1_RowUpdating"   
                  OnRowCancelingEdit="GridView1_RowCancelingEdit"   
                  OnRowDeleting="GridView1_RowDeleting" HorizontalAlign="Center"
                
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
                    <asp:BoundField DataField="password" HeaderText="密码" DataFormatString="{0:000#}" /> 
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
                    <asp:CommandField HeaderText="编辑" ShowEditButton="True" />    
                    <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />    
               </Columns>    
               <RowStyle BackColor="#DEDFDE" ForeColor="Black" />    
               <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />    
               <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />    
               <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />    
               <HeaderStyle BackColor="#003532" Font-Bold="True" ForeColor=" #FFFFFF" />             
           </asp:GridView>   
                 </ContentTemplate>         
    </asp:UpdatePanel>
                    <p style="font-weight: 300; width: 579px; ">
                        <asp:Button ID="Button1" runat="server" Font-Size="12pt" OnClick="Button1_Click" style="width: 100px;height: 30px" Text="取消全选"  />
                        &nbsp; &nbsp;
                        <asp:Button ID="Button2" runat="server" Font-Size="12pt" OnClick="Button2_Click" style="width: 100px;height: 30px" Text="删除" />
                        &nbsp; &nbsp;
                        <asp:Button ID="excel" runat="server" OnClick="Excel_Click" style="width: 100px;height: 30px" Text="导出excel" />
                    </p>
        
       </div>		
   <div style="vertical-align:central;">
    </div>
    </form>
</body>
</html>
