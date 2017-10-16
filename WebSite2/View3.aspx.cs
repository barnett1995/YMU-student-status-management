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

public partial class View3 : System.Web.UI.Page
{
    string connStr = "server=1-PC;uid=sa;pwd=admin2017GAO;database=StudentsInfo";      //连接数据库  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }

    //GridView部分



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

                string delstr = "DELETE FROM Experience WHERE ID='" + GridView1.DataKeys[i].Value.ToString() + "';DELETE FROM marriage WHERE ID='" + GridView1.DataKeys[i].Value.ToString() + "';DELETE FROM Relation WHERE ID='" + GridView1.DataKeys[i].Value.ToString() + "';DELETE FROM si WHERE ID='" + GridView1.DataKeys[i].Value.ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(delstr, sqlcon);
                DataSet ds = new DataSet();
                sqlcon.Open();
                sda.Fill(ds);
                sqlcon.Close();
            }

        }
        Bind();

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
    /// 查询数据，重新进行gridview绑定
    /// </summary>
    /// <param name="sqlstr"></param>
   


    public void Bind()
    {
        Application.Lock();
        string cm = Application["CM"].ToString();
        Application.UnLock();
        string sqlstr = "SELECT si.ID,si.Name,si.password,banji.CLM FROM si, banji WHERE banji.Class_ID = si.classid AND  banji.CLM='"+cm+"'";
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
    /// <param name="e"></param>-
    /// <summary>
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        Bind();
    }


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
        Bind();


    }

    /// <summary>
    /// gridview 更新内取消功能
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;          //要编辑的行从0开始
        Bind();
    }

    /// <summary>
    /// gridview删除行功能
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string delstr = " DELETE FROM Experience WHERE ID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "';DELETE FROM marriage WHERE ID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "';DELETE FROM Relation WHERE ID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "' DELETE FROM si WHERE ID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
        SqlConnection sqlcon = new SqlConnection(connStr);
        SqlDataAdapter sda = new SqlDataAdapter(delstr, sqlcon);
        DataSet ds = new DataSet();
        sqlcon.Open();
        sda.Fill(ds);               //填充dataset
        sqlcon.Close();
        Bind();

    }

    /// <summary>
    /// gridview 内查看信息控件事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chakan_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        int rowindex = gvr.RowIndex;
        string id = GridView1.DataKeys[rowindex].Value.ToString();
        // ScriptManager1.RegisterAsyncPostBackControl(Button1);
        string url = "Stuinfo.aspx?id=" + id;
        Response.Write("<script language='javascript'>window.open('" + url + "','','height=600,width=810,scrollbars=yes,status =yes')</script>");
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

    /// <summary>
    /// 隐藏gridview操作控件
    /// </summary>

    public void hidden()
    {

        Button1.Style.Add("display", "None");
        Button2.Style.Add("display", "None");
        excel.Style.Add("display", "None");

    }

    /// <summary>
    /// 显示gridview操作控件
    /// </summary>
    public void show()
    {

        Button1.Style.Add("display", "Notset");
        Button2.Style.Add("display", "Notset");
        excel.Style.Add("display", "Notset");
    }




    //Excel操作

    /// <summary>
    /// Excel导出
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Excel_Click(object sender, EventArgs e)
    {
        string id = "学籍基本信息";
        if (System.IO.File.Exists(Server.MapPath("/Excel/" + id + ".xlsx")))
        {
            delExcel();
            copyExcel();
            ExcelDataOperator();
            string fileName = "" + id + ".xlsx";//客户端保存的文件名
            string filePath = Server.MapPath("/Excel/" + id + ".xlsx");//路径
            FileInfo fileInfo = new FileInfo(filePath);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            Response.WriteFile(fileInfo.FullName);
            Response.Flush();
            delExcel();
            Response.End();

        }
        else
        {
            copyExcel();
            ExcelDataOperator();
            string fileName = "" + id + ".xlsx";//客户端保存的文件名
            string filePath = Server.MapPath("/Excel/" + id + ".xlsx");//路径
            FileInfo fileInfo = new FileInfo(filePath);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            Response.WriteFile(fileInfo.FullName);
            Response.Flush();
            delExcel();
            Response.End();
        }
    }
    public void copyExcel()
    {
        string id = "学籍基本信息";
        string ExcelName = "" + id + ".xlsx";
        string Model = "C:/web/WebSite2/Excel/Model/1.xlsx";
        string excel = "C:/web/WebSite2/Excel/" + ExcelName + "";

        System.IO.File.Copy(Model, excel);

    }

    public void delExcel()
    {
        string id = "学籍基本信息";
        string ExcelName = "" + id + ".xlsx";
        System.IO.File.Delete(@"C:/web/WebSite2/Excel/" + ExcelName + "");
    }

    /// <summary>
    /// excel数据操作
    /// </summary>
    /// <param name="ds"></param>
    private void ExcelDataSetOperator(DataSet ds)
    {
        string id = "学籍基本信息";

        int a = ds.Tables[0].Rows.Count;
        String myString = "Provider = Microsoft.ACE.OLEDB.12.0 ;Data Source = C:/web/WebSite2/Excel/" + id + ".xlsx; Extended Properties='Excel 12.0;HDR = YES;'";

        OleDbConnection conn = new OleDbConnection(myString);
        OleDbCommand cmd = conn.CreateCommand();
        conn.Open();
        for (int i = 0; i < a; i++)
        {
            cmd.CommandText = "INSERT INTO [Sheet1$] (学号,姓名,密码,学院,系,班级,曾用名,年级,生日,性别,民族,健康状况,婚姻状况,手机号码,银行卡号,开户行,电子邮箱,身份证号码,生源地,家庭住址,家庭电话,邮政编码,什么时候受过什么奖励,什么时候入的党团,受过什么处分,家庭主要成员和主要关系中有无重大问题，与本人关系如何,其他需要向组织说明的问题,记事) VALUES('" + ds.Tables[0].Rows[i][0].ToString() + "', '" + ds.Tables[0].Rows[i][1].ToString() + "', '" + ds.Tables[0].Rows[i][2].ToString() + "','" + ds.Tables[1].Rows[i][0].ToString() + "','" + ds.Tables[1].Rows[i][1].ToString() + "','" + ds.Tables[1].Rows[i][2].ToString() + "','" + ds.Tables[0].Rows[i][3].ToString() + "', '" + ds.Tables[0].Rows[i][7].ToString() + "', '" + ds.Tables[0].Rows[i][8].ToString() + "', '" + ds.Tables[0].Rows[i][9].ToString() + "', '" + ds.Tables[0].Rows[i][10].ToString() + "', '" + ds.Tables[0].Rows[i][11].ToString() + "', '" + ds.Tables[0].Rows[i][12].ToString() + "', '" + ds.Tables[0].Rows[i][13].ToString() + "', '" + ds.Tables[0].Rows[i][14].ToString() + "', '" + ds.Tables[0].Rows[i][15].ToString() + "', '" + ds.Tables[0].Rows[i][16].ToString() + "', '" + ds.Tables[0].Rows[i][17].ToString() + "', '" + ds.Tables[0].Rows[i][18].ToString() + "', '" + ds.Tables[0].Rows[i][19].ToString() + "', '" + ds.Tables[0].Rows[i][20].ToString() + "', '" + ds.Tables[0].Rows[i][21].ToString() + "', '" + ds.Tables[0].Rows[i][22].ToString() + "', '" + ds.Tables[0].Rows[i][23].ToString() + "', '" + ds.Tables[0].Rows[i][24].ToString() + "', '" + ds.Tables[0].Rows[i][25].ToString() + "', '" + ds.Tables[0].Rows[i][26].ToString() + "', '" + ds.Tables[0].Rows[i][27].ToString() + "');";

            cmd.ExecuteNonQuery();


        }
        conn.Close();
    }

    /// <summary>
    /// excel数据集操作
    /// </summary>
    private void ExcelDataOperator()
    {

        DataSet ds = new DataSet();
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            if (cbox.Checked == true)
            {
                string id = GridView1.DataKeys[i].Value.ToString();
                string selstr = "SELECT * FROM si WHERE ID='" + id + "';SELECT College.CM,Xi.XM,banji.CLM FROM College,Xi,banji,si WHERE si.ID = '" + id + "' AND College.College_ID = si.College_ID AND Xi.Xi_id = si.xi_ID AND banji.Class_ID = si.classid";
                SqlConnection conn = new SqlConnection(connStr);
                SqlDataAdapter sda = new SqlDataAdapter(selstr, conn);
                conn.Open();
                sda.Fill(ds);
                conn.Close();
            }

        }
        ExcelDataSetOperator(ds);









    }
}