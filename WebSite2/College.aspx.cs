﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;

public partial class College : System.Web.UI.Page
{
    string connStr = "server=1-PC;uid=sa;pwd=admin2017GAO;database=StudentsInfo";      //连接数据库
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            listbind();
            bind();
        }
    }

    //Excel上传部分

    /// <summary>
    ///excel 上传按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void shangchuan_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFiles)
        {
            string fileName = FileUpload1.FileName;              //获得上传文件文件名
            int position = fileName.LastIndexOf("\\");           //截取.的位置
            string splitName = fileName.Substring(position + 1);       //截取后缀
            string newPath = filechick(splitName);                 //判断后缀名是否合法并赋予新的文件名
            if (!String.IsNullOrEmpty(newPath))                        //指示指定的字符串是 null 还是 Empty 字符串。
            {
                string savePath = Server.MapPath("Excel/");            //Server.MapPath方法返回与指定虚拟路径相对应的物理路径。
                FileOperatpr(fileName, savePath);                      // FileOperatpr类，用于文件操作
                FileUpload1.SaveAs(savePath + newPath);                //FileUpload1.SaveAs方法：将上载文件的内容保存到 Web 服务器上的指定路径。后面加上文件名
                DataOperator(fileName, savePath);                      // DataOperator类，用于数据操作
                bind();
       

            }
        }
        else
        {
            //Response.Write(@"<script>alert('请选择文件！');</script>");
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请选择文件！')", true);


        }
        // Response.Redirect("application0.aspx");

    }

    /// <summary>  
    /// 数据操作  
    /// </summary>  
    /// <param name="fileName"></param>  
    /// <param name="savePath"></param>  
    private void DataOperator(string fileName, string savePath)
    {
        /*
        Microsoft.ACE.OLEDB.12.0 基本操作
        Provider = Microsoft.ACE.OLEDB.12.0 链接驱动 需在服务器端下载  Microsoft.ACE.OLEDB.12.0，向下支持Microsoft Jet Database Engine 4.0
        Data Source=" + savePath + "; 数据库地址
        Extended Properties='Excel 12.0; 连接的是Exce 12.0
        HDR=YES;    有两个值:YES/ NO, 这2个值，说了你是否能直接读列名，NO，只可以读下标
        IMEX=1;     解决数字与字符混合时,识别不正常的情况. 
        */
        string myString = " Provider = Microsoft.ACE.OLEDB.12.0 ;Data Source =  " + savePath + fileName + ";Extended Properties='Excel 12.0;HDR = YES;'";
        OleDbConnection oconn = new OleDbConnection(myString);              //DbConnection是所有数据库连接类的基类 使用DbConnection连接数据库
        DataSet ds = new DataSet();                                         //创建DataSet缓存
        OleDbDataAdapter oda = new OleDbDataAdapter("select * from [Sheet1$]", oconn);   //将excel内容填充到dataSet
        oconn.Open();                                                       //打开数据库
        oda.Fill(ds);                                                       //将oda填充到dataset（ds）内
        DataSetOperator(ds, savePath + fileName);                           // DataSetOperator类，进行数据集操作
        oconn.Close();

    }

    /// <summary>  
    /// 数据集操作  
    /// </summary>  
    /// <param name="ds"></param>  
    private void DataSetOperator(DataSet ds, string filePath)
    {
        SqlConnection conn = new SqlConnection(connStr);    //创建数据库连接
        conn.Open();
        SqlTransaction str = conn.BeginTransaction();                                 //利用事务处理 防止中断  
        int k = 0;
        if (ds.Tables[0].Rows.Count < 1)                                              //判断是表内是否为空
        {
            // Response.Write("<script>alert('没有数据！')</script>");
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('没有数据！')", true);
            return;
        }
        try          //检测异常语句
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string sqlStr = "INSERT INTO Xi(College_ID,XM,Xi_id) VALUES('" + ds.Tables[0].Rows[i][0].ToString() + "','" + ds.Tables[0].Rows[i][1].ToString() + "','" + ds.Tables[0].Rows[i][2].ToString() + "')";
                SqlCommand cmd = new SqlCommand(sqlStr, conn, str);          //表示要对 SQL Server 数据库执行的一个 Transact-SQL 语句或存储过程
                cmd.Transaction = str;                                        //执行SqlCommand的SqlTransaction
                k += cmd.ExecuteNonQuery();                                  //返回受影响的行数

            }
            str.Commit();                                                   //提交数据库事务
        }
        catch (Exception ex)                                                //获取一场信息
        {
            //Response.Write(@"<script>alert('发生异常,数据已回滚/n信息/n" + ex.Message + "');</ script > ");
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('发生异常,数据已回滚/n信息/n" + ex.Message + "'')", true);
            str.Rollback();
        }
        finally                                                             //finally 块释放资源，例如，关闭在 try 块中打开的任何流或文件。
        {
            // Response.Write(@"<script>alert('上传成功" + k+ " 条');</script>");
            this.ClientScript.RegisterStartupScript(this.GetType(),"", "alert('上传成功" + k + " 条')",true);
        }
    }
    /// <summary>  
    /// 文件操作  
    /// </summary>  
    /// <param name="fileName"></param>  
    /// <param name="savePath"></param>  
    private void FileOperatpr(string fileName, string savePath)
    {
        if (!Directory.Exists(savePath))       //Directory.Exists方法，判断是否有该文件       
        {
            Directory.CreateDirectory(savePath);       // Directory.CreateDirectory方法，在路径创建所有目录
        }

        if (File.Exists(savePath + fileName))            //确定指定的文件是否存在。
        {
            System.IO.File.Delete(savePath + fileName);            //File.Delete 方法，删除指定文件
        }


    }

    /// <summary>  
    /// 文件检查
    /// </summary>  
    /// <param name="fileName"></param> 
    protected string filechick(string fileName)
    {
        //返回指定路径文件的扩展名 并转换成小写
        string fileType = Path.GetExtension(fileName).ToLower();
        //判断文件的后缀名
        if (fileType == ".xlsx")
        {
            //返回一个不具有文件扩展名的文件名
            string Name = Path.GetFileNameWithoutExtension(fileName);
            string NewName = Name + fileType;
            return NewName;
        }
        else
        {
            return null;
        }

    }

    //数据单条添加

    /// <summary>
    /// 单条添加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void add_ServerClick(object sender, EventArgs e)
    {
        string id = upid.Value;
        string nm = upname.Value;
        string xy = xylist.SelectedItem.Text;

        string sestr = "SELECT * FROM Xi WHERE Xi_id='" + id + "' OR XM='" + nm + "' AND College_ID=(SELECT College_ID FROM College WHERE CM='" + xy + "')";


        if (id == "" || nm == "")
        {
            //Response.Write(@"<script>alert('增添的信息不能为空！');</script>");
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('增添的信息不能为空！')", true);

        }
        else
        {
            SqlConnection conn = new SqlConnection(connStr);                         //连接的数据库名称
            SqlDataAdapter da = new SqlDataAdapter(sestr, conn);
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            conn.Open();                                                             //打开数据库
            da.Fill(dt);                                                            //将数据填充到DataTable（dt）         
            conn.Close();
            //string a = dt1.Rows[0]["classid"].ToString();
            //int cid = 0;
            //int.TryParse(a, out cid);                                             //强制类型转换，string转int
            if (dt.Rows.Count == 1)                                               //从登录表读取数据，如果已经有输入信息，页面提示
            {
                // Response.Write(@"<script>alert('已有该条记录！');</script>");
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('已有该条记录！')", true);
            }
            else
            {
                string selectStr = "SELECT College_ID FROM College WHERE CM='" + xy + "'";


                SqlDataAdapter da2 = new SqlDataAdapter(selectStr, conn);
                DataTable dt2 = new DataTable();
                conn.Open();                                                             //打开数据库
                da2.Fill(dt2);                                                            //将数据填充到DataTable（dt）
                conn.Close();

                string xyid = dt2.Rows[0]["College_ID"].ToString();
               
                string sqlStr = "INSERT INTO Xi(College_ID,XM,Xi_id) VALUES('" + xyid + "','" + nm + "','" + id + "')";
      
                SqlDataAdapter da3 = new SqlDataAdapter(sqlStr, conn);
                DataSet ds = new DataSet();
                conn.Open();                                                             //打开数据库
                da3.Fill(ds);                                                            //将数据填充到DataTable（dt）
                conn.Close();
                bind();
            

               
            }
            
        }

    }

    /// <summary>
    /// 学院dropdownlist 的DataSource 
    /// </summary>
    public void listbind()
    {
        string sqlstr = "select CM FROM College";
        SqlConnection sqlcon = new SqlConnection(connStr);
        SqlDataAdapter da = new SqlDataAdapter(sqlstr, sqlcon);
        DataSet ds = new DataSet();
        sqlcon.Open();
        da.Fill(ds);
        sqlcon.Close();
        xylist.DataSource = ds;
        xylist.DataTextField = "CM";
        xylist.DataBind();
    }

    //查询
    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chaxun_ServerClick(object sender, EventArgs e)
    {

        string id = xiid.Value;

        if (id != "")
        {
            // 查询id
            string sqlStr = "SELECT Xi.Xi_id,Xi.XM,College.CM FROM College,Xi WHERE Xi.Xi_id='" + id + "' AND College.College_ID=Xi.College_ID ";

            searchBind(sqlStr);
            show();
        }
        else
        {
            //提示错误
            // Response.Write(@"<script>alert('请正确选择或填写查询信息！');</script>");
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请正确选择或填写查询信息！')", true);
        }
    }

    /// <summary>
    /// 查询数据，重新进行gridview绑定
    /// </summary>
    /// <param name="sqlstr"></param>
    public void searchBind(string sqlstr)
    {
        SqlConnection sqlcon = new SqlConnection(connStr);
        SqlDataAdapter da = new SqlDataAdapter(sqlstr, sqlcon);
        DataSet ds = new DataSet();
        sqlcon.Open();
        da.Fill(ds);
        GridView1.DataSource = ds;                                     //设定gridview的datasourse
        GridView1.DataKeyNames = new string[] { "Xi_id" };//主键
        GridView1.DataBind();
        sqlcon.Close();
    }


    /// <summary>
    /// 重置查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void restart_ServerClick(object sender, EventArgs e)
    {
        xiid.Value = "";
        bind();
    }

    //gridview 部分

    /// <summary>
        /// 数据绑定
        /// </summary>
    public void bind()
    {
        //Application.Lock();
        //string ID = Application["ID"].ToString();
        //Application.UnLock();
        string ID = Session["ID"].ToString();
        string sqlstr = "SELECT Xi.Xi_id,Xi.XM,College.CM FROM College, Xi WHERE College.College_ID = Xi.College_ID AND College.College_ID = (SELECT College_ID FROM Teacher WHERE Teacher.ID = '" + ID + "')";
        SqlConnection sqlcon = new SqlConnection(connStr);
        SqlDataAdapter da = new SqlDataAdapter(sqlstr, sqlcon);
        DataSet ds = new DataSet();
        sqlcon.Open();
        da.Fill(ds);
        GridView1.DataSource = ds;                                     //设定gridview的datasourse
        GridView1.DataKeyNames = new string[] { "Xi_id" };//主键
        GridView1.DataBind();
        sqlcon.Close();
    }

    /// <summary>
    /// 全选gridveiw
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        //.BottomPagerRow ,取得 GridViewRow 物件，代表下方頁面巡覽區的資料列中 GridView 控制  
        CheckBox cbxHead = (CheckBox)GridView1.HeaderRow.FindControl("CheckBox2");

        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            if (cbxHead.Checked == true)
            {
                cbox.Checked = true;
            }
            else
            {
                cbox.Checked = false;
            }
        }
    }

    /// <summary>
    /// 删除全选
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection sqlcon = new SqlConnection(connStr);
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            if (cbox.Checked == true)
            {
                string delstr = "DELETE FROM Xi WHERE Xi_id='" + GridView1.DataKeys[i].Value.ToString() + "';DELETE FROM banji WHERE xi_id='" + GridView1.DataKeys[i].Value.ToString() + "'";

                SqlDataAdapter sda = new SqlDataAdapter(delstr, sqlcon);
                DataSet ds = new DataSet();
                sqlcon.Open();
                sda.Fill(ds);
                sqlcon.Close();
            }

        }
        bind();
      //  Response.Redirect("application0.aspx");

    }

    /// <summary>
    /// 取消选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        CheckBox cbxHead = (CheckBox)GridView1.Rows[0].FindControl("CheckBox2");

        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            cbox.Checked = false;
        }
    }



    /// <summary>
    /// gridview修改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>-
    /// <summary>
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bind();

    }


    /// gridview更新
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // 将GridView1.Rows[e.RowIndex].Cells[1].Controls[0]强制转换类型成textbox，
        string nm = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text;
        string upstr = "UPDATE Xi SET XM='" + nm + "' WHERE Xi_id='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";


        SqlConnection sqlcon = new SqlConnection(connStr);
        SqlDataAdapter sda = new SqlDataAdapter(upstr, sqlcon);
        DataSet ds = new DataSet();
        sqlcon.Open();
        sda.Fill(ds);                   //填充dataset
        sqlcon.Close();
        GridView1.EditIndex = -1;      // EditIndex属性 要编辑的行从0开始 预设值为-1
        bind();




    }

    /// <summary>
    /// gridview 更新内取消功能
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;          //要编辑的行从0开始
        bind();

    }

    /// <summary>
    /// gridview删除行功能
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string delstr = "DELETE FROM Xi WHERE Xi_id='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "';DELETE FROM banji WHERE xi_id='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
        SqlConnection sqlcon = new SqlConnection(connStr);
        SqlDataAdapter sda = new SqlDataAdapter(delstr, sqlcon);
        DataSet ds = new DataSet();
        sqlcon.Open();
        sda.Fill(ds);               //填充dataset
        sqlcon.Close();
        bind();


    }



    /// <summary>
    /// 隐藏gridview操作控件
    /// </summary>

    public void hidden()
    {

        Button1.Style.Add("display", "None");
        Button2.Style.Add("display", "None");


    }

    /// <summary>
    /// 显示gridview操作控件
    /// </summary>
    public void show()
    {

        Button1.Style.Add("display", "Notset");
        Button2.Style.Add("display", "Notset");

    }
}