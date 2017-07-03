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
                 <P>
         
                <label  class="label">查询学生信息</label>
              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
              <ContentTemplate>
        <p>
           
            <p>
            <label  class="label">选择系</label>
            <asp:DropDownList ID="selectxi" runat="server"  Width="138px" AutoPostBack="True" OnSelectedIndexChanged="selectxi_SelectedIndexChanged"></asp:DropDownList>
            <p>
            <label  class="label">选择班级</label>
            <asp:DropDownList ID="selectbj" runat="server" Width="138px"></asp:DropDownList>
            <p>
            <label  class="label">选择年级</label>
            <asp:DropDownList ID="selectnj" runat="server" Width="138px">
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
            &nbsp; &nbsp; &nbsp; 
            <label  class="label">输入学号</label> 
             <input id="xuehao" type="text" runat="server"/>
            <input id="chaxun" type="submit" value="查询" runat="server" onserverclick="chaxun_ServerClick"/>
            &nbsp; &nbsp; &nbsp; 
            <input id="restart" type="submit" value="重置" runat="server" onserverclick="restart_ServerClick"/>
           
        <p>
          <asp:UpdatePanel ID="UpdatePanel3" runat="server">
              <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" Height="133px" Width="539px" AllowPaging="true" PageSize="10"
          AutoGenerateColumns="False" DataKeyNames="id"  
          OnPageindexChanging="Gridview1_PageIndexChanging" 
          OnRowEditing="GridView1_RowEditing" BackColor="White" BorderColor="White"   
          BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"  CellSpacing="1"   
          GridLines="None"
          OnRowUpdating="GridView1_RowUpdating"   
          OnRowCancelingEdit="GridView1_RowCancelingEdit"   
          OnRowDeleting="GridView1_RowDeleting"
         >   
      <Columns>    
             <asp:TemplateField>
                <HeaderTemplate>
                    选择
                </HeaderTemplate>
                <ItemTemplate>
                     <asp:CheckBox ID="CheckBox1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ID" HeaderText="学号" ReadOnly="True"/>    
            <asp:BoundField DataField="Name" HeaderText="姓名" DataFormatString="{0:000#}" /> 
            <asp:BoundField DataField="password" HeaderText="密码" DataFormatString="{0:000#}" /> 
            <asp:BoundField DataField="password" HeaderText="班级" DataFormatString="{0:000#}" ReadOnly="True"  />  
            <asp:TemplateField>
                <HeaderTemplate>
                   查看学生信息
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Button ID="chakan" runat="server" Text="查看信息" />
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:CommandField HeaderText="编辑" ShowEditButton="True" />    
            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />    
       </Columns>    
       <RowStyle BackColor="#DEDFDE" ForeColor="Black" />    
       <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />    
       <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />    
       <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />    
       <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />  
             
       <PagerTemplate>
        <br />
         <asp:Label ID="lblPage1" runat="server" Text='<%# "第" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "页" %> '></asp:Label>
          &nbsp; &nbsp;
       <asp:Label ID="lblPage" runat="server" Text='<%# "共" + (((GridView)Container.NamingContainer).PageCount) + "页" %> '></asp:Label>
          &nbsp; &nbsp;
         <asp:LinkButton ID="lbnFirst" runat="Server" Text="首页"  Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First" ></asp:LinkButton>
        <asp:LinkButton ID="lbnPrev" runat="server" Text="上一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev" ></asp:LinkButton>
        <asp:LinkButton ID="lbnNext" runat="Server" Text="下一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next" ></asp:LinkButton>
         <asp:LinkButton ID="lbnLast" runat="Server" Text="尾页"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last" ></asp:LinkButton>
         <br />
     </PagerTemplate>  
   </asp:GridView>  
    
       <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" Font-Sizep="9pt" OnCheckedChanged="CheckBox2_CheckedChanged" Text="全选" />
         &nbsp; &nbsp; 
       <asp:Button ID="Button1" runat="server" Font-Size="12pt" Text="取消" OnClick="Button1_Click" />
         &nbsp; &nbsp;
       <asp:Button ID="Button2" runat="server" Font-Size="12pt" Text="删除" OnClick="Button2_Click" />
          &nbsp; &nbsp;
       <asp:Button ID="excel" runat="server" Text="导出excel" OnClick="Excel_Click"  />
     
    </ContentTemplate>
    </asp:UpdatePanel>
         <asp:Button ID="test" runat="server" Text="test" OnClick="test_Click"  />
            
            </div>
   
    </form>
</body>
</html>
