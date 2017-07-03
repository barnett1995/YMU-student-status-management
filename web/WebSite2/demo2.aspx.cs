using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Collections;

public partial class demo2 : System.Web.UI.Page
{
    string connStr = "server=DESKTOP-RNBGQQS;uid=sa;pwd=123456;database=StudentsInfo";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
            listbind();
            selectbind();
            this.selectxi.Items.Insert(0, new ListItem("请选择系", "0"));
            this.selectbj.Items.Insert(0, new ListItem("请选择班级", "0"));
            this.xylist.Items.Insert(0, new ListItem("请选择学院", "0"));
            this.xilist.Items.Insert(0, new ListItem("请选择系", "0"));
            this.banjilist.Items.Insert(0, new ListItem("请选择班级 ", "0"));
            this.nianjilist.Items.Insert(0, new ListItem("请选择年级 ", "0"));


        }
    }

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
                bind();
            }
        }
        else
        {
        }

    }

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

                string instr = "INSERT INTO si(ID,Name,password,College_ID,Xi_id,classid,nianji) VALUES('" + id + "','" + nm + "','" + pwd + "','" + xyid + "','" + xid + "','" + cid + "','" + nj + "'); insert into Experience(ID) VALUES ('" + id + "'),('" + id + "'),('" + id + "'),('" + id + "'),('" + id + "'),('" + id + "');  insert into marriage(ID) VALUES ('" + id + "'),('" + id + "'),('" + id + "'),('" + id + "'),('" + id + "'),('" + id + "'); insert into Relation(ID) VALUES ('" + id + "'),('" + id + "'),('" + id + "'),('" + id + "'),('" + id + "'),('" + id + "');";


                Response.Write(@"<script>alert('上传成功！');</script>");
                //  bind();
            }
        }

    }


    //Excel操作部分

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

                string sqlStr = "insert into si(ID,Name,password,College_ID,Xi_id,classid,nianji) values('" + ds.Tables[0].Rows[i][0].ToString() + "','" + ds.Tables[0].Rows[i][1].ToString() + "','" + ds.Tables[0].Rows[i][2].ToString() + "','" + ds.Tables[0].Rows[i][3].ToString() + "','" + ds.Tables[0].Rows[i][4].ToString() + "','" + ds.Tables[0].Rows[i][5].ToString() + "','" + ds.Tables[0].Rows[i][6].ToString() + "'); insert into Experience(ID) VALUES ('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "');  insert into marriage(ID) VALUES ('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'); insert into Relation(ID) VALUES ('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "'),('" + ds.Tables[0].Rows[i][0].ToString() + "');";
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
        /*
             if (File.Exists(savePath + fileName))            //确定指定的文件是否存在。
             {
                 File.Delete(savePath + fileName);            //File.Delete 方法，删除指定文件
             }
             */

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

    //下拉列表绑定部分

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

    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chaxun_ServerClick(object sender, EventArgs e)
    {
        string xi = selectxi.SelectedItem.Text;
        string cl = selectbj.SelectedItem.Text;
        string nj = selectnj.SelectedItem.Text;
        string id = xuehao.Value;

        if (id != "")
        {
            // 查询id
            string sqlStr = "SELECT ID,Name,password,banji.CLM FROM si,banji WHERE si.ID='" + id + "' AND nianji='" + nj + "' AND banji.Class_ID=si.classid";
            searchBind(sqlStr);
        }
        else if (xi != "请选择系" && cl == "请选择班级")
        {
            //查询系
            string sqlStr1 = "SELECT ID,Name,password,banji.CLM FROM si,banji WHERE banji.Class_ID=si.classid AND nianji='" + nj + "' AND si.xi_ID=(SELECT Xi_id FROM Xi WHERE XM='" + xi + "')";
            searchBind(sqlStr1);
        }
        else if (xi != "" && cl != "请选择班级")
        {
            //查询班级
            string sqlStr2 = "SELECT ID,Name,password,banji.CLM FROM si,banji WHERE banji.Class_ID=si.classid AND nianji='" + nj + "' AND classid=(SELECT Class_ID FROM banji WHERE CLM='" + cl + "')";
            searchBind(sqlStr2);
        }
        else if (xi == "请选择系" && cl == "请选择班级")
        {
            //提示错误
            Response.Write(@"<script>alert('请正确选择或填写查询信息！');</script>");
        }
    }


    /// <summary>
    /// 重置查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void restart_ServerClick(object sender, EventArgs e)
    {
        this.selectxi.Items.Insert(0, new ListItem("请选择系", "0"));
        selectbind();
        xuehao.Value = "";
    }



    /// <summary>
    /// 全选gridveiw
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        //.BottomPagerRow ,取得 GridViewRow 物件，代表下方頁面巡覽區的資料列中 GridView 控制項
        
        GridViewRow pagerRow = GridView1.BottomPagerRow;
        Label lb = (Label)pagerRow.Cells[0].FindControl("lblPage");
     
       
        int num = 0;
        int x = GridView1.PageCount;            //获取当前页数
        for (int j = 0; j < x; j++)
        {
           
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                if (CheckBox2.Checked == true)
                {
                    cbox.Checked = true;
                }
                else
                {
                    cbox.Checked = false;
                }
            }
            num=GridView1.PageIndex+1;
            GridViewPageEventArgs ea = new GridViewPageEventArgs(num);
            PageIndexchange(null,ea);
            RememberOldValues();
            RePopulateValues();
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

                string delstr = "DELETE FROM Experience WHERE ID='" + GridView1.DataKeys[i].Value.ToString() + "';DELETE FROM marriage WHERE ID='" + GridView1.DataKeys[i].Value.ToString() + "';DELETE FROM Relation WHERE ID='" + GridView1.DataKeys[i].Value.ToString() + "';DELETE FROM si WHERE ID='" + GridView1.DataKeys[i].Value.ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(delstr, sqlcon);
                DataSet ds = new DataSet();
                sqlcon.Open();
                sda.Fill(ds);
                sqlcon.Close();
            }

        }
        bind();

    }

    /// <summary>
    /// 取消选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        CheckBox2.Checked = false;
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            cbox.Checked = false;
        }
    }

    /// <summary>
    /// 选择查询事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void selectxi_SelectedIndexChanged(object sender, EventArgs e)
    {
        string xl = selectxi.SelectedItem.Text;
        selectbind2(xl);
        this.selectbj.Items.Insert(0, new ListItem("请选择班级", "0"));
    }

    protected void Excel_Click(object sender, EventArgs e)
    {

    }


    /// <summary>
    /// 系dropdownlist 的DataSource 
    /// </summary>
    public void selectbind()
    {
        string ID = Request.QueryString["id"];
        string sqlstr = "SELECT XM FROM Xi where College_ID=(SELECT College_ID FROM Teacher WHERE id='" + ID + "')";
        SqlConnection sqlcon = new SqlConnection(connStr);
        SqlDataAdapter da = new SqlDataAdapter(sqlstr, sqlcon);
        DataSet ds = new DataSet();
        sqlcon.Open();
        da.Fill(ds);
        sqlcon.Close();
        selectxi.DataSource = ds;
        selectxi.DataTextField = "XM";
        selectxi.DataBind();
    }

    /// <summary>
    /// 班级dropdownlist 的DataSource
    /// </summary>
    /// <param name="x"></param>
    public void selectbind2(string x)
    {
        string sqlstr = "SELECT CLM FROM banji WHERE xi_id=(SELECT Xi_id FROM Xi WHERE XM='" + x + "' )";

        SqlConnection sqlcon = new SqlConnection(connStr);
        SqlDataAdapter da = new SqlDataAdapter(sqlstr, sqlcon);
        DataSet ds = new DataSet();
        sqlcon.Open();
        da.Fill(ds);
        sqlcon.Close();
        selectbj.DataSource = ds;
        selectbj.DataTextField = "CLM";
        selectbj.DataBind();
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
        GridView1.DataKeyNames = new string[] { "ID" };//主键
        GridView1.DataBind();
        sqlcon.Close();
    }


    /// <summary>
    /// gridview数据绑定
    /// </summary>
    public void bind()
    {


        string sqlstr = "select ID,Name,password,CLM from si,banji WHERE banji.Class_ID=si.classid";            //查询数据
        SqlConnection sqlcon = new SqlConnection(connStr);
        SqlDataAdapter da = new SqlDataAdapter(sqlstr, sqlcon);
        DataSet ds = new DataSet();
        sqlcon.Open();
        da.Fill(ds);
        GridView1.DataSource = ds;                                     //设定gridview的datasourse
        GridView1.DataKeyNames = new string[] { "ID" };//主键
        GridView1.DataBind();
        sqlcon.Close();


    }

    /// <summary>
    /// gridview修改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bind();
    }

    /// <summary>
    /// gridview更新
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // 将GridView1.Rows[e.RowIndex].Cells[1].Controls[0]强制转换类型成textbox，
        string nm = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text;
        string pwd = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text;
        string upstr = "UPDATE si SET Name='" + nm + "', password='" + pwd + "' WHERE ID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";

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
        string delstr = "DELETE FROM si WHERE ID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'; DELECT FROM Experience WHERE ID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "';DELECT FROM marriage WHERE ID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "';DELECT FROM Relation WHERE ID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
        SqlConnection sqlcon = new SqlConnection(connStr);
        SqlDataAdapter sda = new SqlDataAdapter(delstr, sqlcon);
        DataSet ds = new DataSet();
        sqlcon.Open();
        sda.Fill(ds);               //填充dataset
        sqlcon.Close();
        bind();

    }

    /// <summary>
    /// gridview分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Gridview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        RememberOldValues();
        this.GridView1.PageIndex = e.NewPageIndex;
        this.bind();
        RePopulateValues();
    }

    public void PageIndexchange(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bind();
    }

    /// <summary>
    /// 分页选择读取上一页选择内容
    /// </summary>
    private void RememberOldValues()
    {
        ArrayList cateList = new ArrayList();
        foreach (GridViewRow row in GridView1.Rows)                                     //遍历Gridview行数
        {
            string index = GridView1.DataKeys[row.RowIndex].Value.ToString();           //获得checkbox选中的Gridview.DataKeys
             
            bool result = ((CheckBox)row.FindControl("CheckBox1")).Checked;             //获得checkbox选中情况

            if (Session["CHECKED_ITEMS"] != null)                                       //检查Session是否为空
                cateList = (ArrayList)Session["CHECKED_ITEMS"];
            if (result)                                                                 //判断有没有checkbox选中列
            {
                if (!cateList.Contains(index))
                    cateList.Add(index);                                                 //if true，将index add到 list中                
            }
            else
                cateList.Remove(index);                                               //false ，移除index
        }
        if (cateList != null && cateList.Count > 0)
            Session["CHECKED_ITEMS"] = cateList;                                        //if list不为空，将list 加入到Session中
    }

    /// <summary>
    /// 分页选择读取所有页面选择内容
    /// </summary>
    private void RePopulateValues()
    {
        ArrayList cateList = (ArrayList)Session["CHECKED_ITEMS"];                   //将Session值赋值到list
        if (cateList != null && cateList.Count > 0)                                 //判断list是否为空
        {
            foreach (GridViewRow row in GridView1.Rows)                             //遍历Gridview rows
            {

                string index = GridView1.DataKeys[row.RowIndex].Value.ToString();
                if (cateList.Contains(index))                                              //判断有没有chenckbox选过
                {
                    CheckBox myCheckBox = (CheckBox)row.FindControl("CheckBox1");
                    myCheckBox.Checked = true;                                            //true，将checkbox勾选上
                }
            }
        }
    }

    protected void test_Click(object sender, EventArgs e)
    {
        int x = GridView1.PageCount;
        int y = GridView1.PageIndex;
        Response.Write(@"<script>alert('"+y+"');</script>");
    }
}