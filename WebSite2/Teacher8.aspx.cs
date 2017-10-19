using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Teacher8 : System.Web.UI.Page
{
    string connStr = "server=1-PC;uid=sa;pwd=admin2017GAO;database=StudentsInfo";     //连接数据库
    protected void Page_Load(object sender, EventArgs e)
    {
        spTex();
        if (!IsPostBack)
        {


            listbind();


            this.xylist.Items.Insert(0, new ListItem("请选择学院", "0"));
            this.xilist.Items.Insert(0, new ListItem("请选择系", "0"));
            this.banjilist.Items.Insert(0, new ListItem("请选择班级 ", "0"));
            this.nianjilist.Items.Insert(0, new ListItem("请选择年级 ", "0"));


        }
    }

    /// <summary>
    /// 导航栏控制
    /// </summary>
    public void spTex()
    {
        string id = Session["ID"].ToString();
        string selStr = "SELECT banji.grade,ClM FROM banji,Teacher WHERE ID='" + id + "' AND banji.Class_ID=Teacher.Class_ID ";

        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter da = new SqlDataAdapter(selStr, conn);
        DataTable dt = new DataTable();
        conn.Open();                                                             //打开数据库
        da.Fill(dt);                                                            //将数据填充到DataTable（dt）
        conn.Close();
        int hang = dt.Rows.Count;                             //获取datatable的行数


        for (int i = 0; i < hang; i++)
        {
            /*
             Page.FindControl 方法:在页命名容器中搜索指定的服务器控件。html控件对应的服务端控件类 HtmlGenericControl	任何其它没有对应控件的标记，<span> <div>  
             为导航栏赋值，显示班级信息
             */

            ((HtmlGenericControl)Page.FindControl("T" + (i + 1))).InnerText = dt.Rows[i]["grade"].ToString() + dt.Rows[i]["CLM"].ToString();
        }



        for (int j = 10; j > hang + 1; j--)
        {
            ((HtmlAnchor)Page.FindControl("A" + j)).Attributes.Add("style", "display:none");
        }

    }
    //Excel操作部分

    /// <summary>
    /// excel批量上传
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void shangchuan_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
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

                Response.Redirect("Teacher.aspx");

            }
        }
        else
        {
            Response.Write(@"<script>alert('请选择文件！');</script>");
        }

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
            Response.Write("<script>alert('没有数据！')</script>");
            return;
        }
        try          //检测异常语句
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                string sqlStr = "insert into si(ID,Name,password,College_ID,Xi_id,classid,nianji,Authority,apply,overrule) values('" + ds.Tables[0].Rows[i][0].ToString() + "','" + ds.Tables[0].Rows[i][1].ToString() + "','" + ds.Tables[0].Rows[i][2].ToString() + "','" + ds.Tables[0].Rows[i][3].ToString() + "','" + ds.Tables[0].Rows[i][4].ToString() + "','" + ds.Tables[0].Rows[i][5].ToString() + "','" + ds.Tables[0].Rows[i][6].ToString() + "','true','false','false'); insert into Experience(ID) VALUES ('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "');  insert into marriage(ID) VALUES ('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'); insert into Relation(ID) VALUES ('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "');";
                SqlCommand cmd = new SqlCommand(sqlStr, conn, str);          //表示要对 SQL Server 数据库执行的一个 Transact-SQL 语句或存储过程
                cmd.Transaction = str;                                        //执行SqlCommand的SqlTransaction
                k += cmd.ExecuteNonQuery();                                  //返回受影响的行数

            }
            str.Commit();                                                   //提交数据库事务
        }
        catch (Exception ex)                                                //获取一场信息
        {
            Response.Write(@"<script>alert('发生异常,数据已回滚/n信息/n" + ex.Message + "');</ script > ");
            str.Rollback();
        }
        finally                                                             //finally 块释放资源，例如，关闭在 try 块中打开的任何流或文件。
        {
            //int a = Convert.ToInt32(k);
            int num = k / 19;
            Response.Write(@"<script>alert('上传成功" + num + " 条');</script>");
            //File.Delete(filePath);                                          //上传完成删除文件
            // bind();

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

    //学生信息单条添加


    /// <summary>
    /// 学院下拉列表事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void xylist_SelectedIndexChanged(object sender, EventArgs e)
    {
        string xl = xylist.SelectedItem.Text;
        listbind2(xl);
        this.xilist.Items.Insert(0, new ListItem("请选择系", "0"));
        this.banjilist.Items.Clear();//清除第三分类 
        this.banjilist.Items.Insert(0, new ListItem("请选择班级", "0"));
    }

    /// <summary>
    /// 系下拉列表事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void xilist_SelectedIndexChanged(object sender, EventArgs e)
    {
        string cl = xilist.SelectedItem.Text;
        listbind3(cl);
        this.banjilist.Items.Insert(0, new ListItem("请选择班级", "0"));
    }

    /// <summary>
    /// 单条添加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void add_ServerClick(object sender, EventArgs e)
    {
        string id = upid.Value;
        string nm = upname.Value;
        string pwd = uppwd.Value;
        string xy = xylist.SelectedItem.Text;
        string cls = banjilist.SelectedItem.Text;
        string xi = xilist.SelectedItem.Text;
        string nj = nianjilist.SelectedItem.Text;


        string sestr = "SELECT * FROM si WHERE ID='" + id + "' AND Name='" + nm + "' AND password='" + pwd + "' AND classid=(SELECT Class_ID FROM banji WHERE CLM='" + cls + "')";

        if (id == "" || nm == "")
        {
            Response.Write(@"<script>alert('增添的信息不能为空！');</script>");
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
                Response.Write(@"<script>alert('已有该条记录！');</script>");
            }
            else
            {
                string selectStr = "SELECT College.College_ID, Xi.Xi_id, banji.Class_ID FROM College,Xi,banji WHERE College.CM='" + xy + "' AND Xi.XM='" + xi + "' AND banji.CLM='" + cls + "'";


                SqlDataAdapter da2 = new SqlDataAdapter(selectStr, conn);
                DataTable dt2 = new DataTable();
                conn.Open();                                                             //打开数据库
                da2.Fill(dt2);                                                            //将数据填充到DataTable（dt）
                conn.Close();

                string xyid = dt2.Rows[0]["College_ID"].ToString();
                string xid = dt2.Rows[0]["Xi_id"].ToString();
                string cid = dt2.Rows[0]["Class_ID"].ToString();

                string instr = "INSERT INTO si(ID,Name,password,College_ID,Xi_id,classid,nianji,Authority,apply,overrule) VALUES('" + id + "','" + nm + "','" + pwd + "','" + xyid + "','" + xid + "','" + cid + "','" + nj + "','true','false','false'); insert into Experience(ID) VALUES ('" + id + "'),('" + id + "'),('" + id + "'),('" + id + "'),('" + id + "'),('" + id + "');  insert into marriage(ID) VALUES ('" + id + "'),('" + id + "'),('" + id + "'),('" + id + "'),('" + id + "'),('" + id + "'); insert into Relation(ID) VALUES ('" + id + "'),('" + id + "'),('" + id + "'),('" + id + "'),('" + id + "'),('" + id + "');";
                SqlDataAdapter da3 = new SqlDataAdapter(instr, conn);
                DataTable dt3 = new DataTable();
                conn.Open();                                                             //打开数据库
                da3.Fill(dt3);                                                            //将数据填充到DataTable（dt）
                conn.Close();

                Response.Write(@"<script>alert('上传成功！');</script>");

                Response.Redirect("Teacher.aspx");
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

    /// <summary>
    /// 系dropdownlist 的DataSource
    /// </summary>
    /// <param name="c"></param>
    public void listbind2(string c)
    {
        string sqlstr = "SELECT XM FROM Xi WHERE College_ID=(SELECT College_ID FROM College WHERE CM='" + c + "' )";

        SqlConnection sqlcon = new SqlConnection(connStr);
        SqlDataAdapter da = new SqlDataAdapter(sqlstr, sqlcon);
        DataSet ds = new DataSet();
        sqlcon.Open();
        da.Fill(ds);
        sqlcon.Close();
        xilist.DataSource = ds;
        xilist.DataTextField = "XM";
        xilist.DataBind();
    }

    /// <summary>
    /// 班级dropdownlist 的DataSource
    /// </summary>
    /// <param name="x"></param>
    public void listbind3(string x)
    {
        string sqlstr = "select CLM FROM banji WHERE xi_id=(SELECT Xi_id FROM Xi WHERE XM='" + x + "' )";
        SqlConnection sqlcon = new SqlConnection(connStr);
        SqlDataAdapter da = new SqlDataAdapter(sqlstr, sqlcon);
        DataSet ds = new DataSet();
        sqlcon.Open();
        da.Fill(ds);
        sqlcon.Close();
        banjilist.DataSource = ds;
        banjilist.DataTextField = "CLM";
        banjilist.DataBind();
    }


    //信息查询部分



    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chaxun_ServerClick(object sender, EventArgs e)
    {
        string cm1 = ((HtmlGenericControl)Page.FindControl("T9")).InnerText.ToString();
        string cm = cm1.Substring(5);
        Application["CM"] = cm;
       this.ClientScript.RegisterStartupScript(this.GetType(), "", "window.open('View3.aspx','','height=800,width=100,scrollbars=yes,status =yes')", true);


    }
}
