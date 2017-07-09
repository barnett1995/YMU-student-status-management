<%@  Page Language="C#" AutoEventWireup="true" CodeFile="demo.aspx.cs" Inherits="demo"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    			<asp:UpdatePanel ID="UpdatePanel3" runat="server">
              <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" Height="133px" Width="584px"
                  AutoGenerateColumns="False" DataKeyNames="ID"  align="center"
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
                    <asp:BoundField DataField="ID" HeaderText="工号" ReadOnly="True"/>    
                    <asp:BoundField DataField="TeacheName" HeaderText="姓名" DataFormatString="{0:000#}" /> 
                    <asp:BoundField DataField="Password" HeaderText="密码" DataFormatString="{0:000#}" /> 
                    <asp:BoundField DataField="XM" HeaderText="所属系" DataFormatString="{0:000#}"  ReadOnly="True"/>  
                        <asp:TemplateField>
                        <HeaderTemplate>
                           查看学生信息
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:UpdatePanel UpdateMode="Conditional" ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                      <asp:Button ID="chakan" runat="server" Text="Button" AutoPostBack="True" OnClick="chakan_Click" />
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
          <p style="font-weight: 300">
       </div>		
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
