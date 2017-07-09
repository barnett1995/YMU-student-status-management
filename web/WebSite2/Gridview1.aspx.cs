﻿using System;
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

public partial class Gridview1 : System.Web.UI.Page
{
    string connStr = "server=DESKTOP-RNBGQQS;uid=sa;pwd=123456;database=StudentsInfo";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    public void bind()
    {
        Application.Lock();
        string xi = Application["xi"].ToString();
        string cl = Application["c1"].ToString();
        string nj = Application["nj"].ToString();
        string id = Application["id"].ToString();

        Application.UnLock();

        if (id != "")
        {
            // 查询id
            string sqlStr = "SELECT ID,Name,password,banji.CLM FROM si,banji WHERE si.ID='" + id + "'  AND banji.Class_ID=si.classid";
            SqlConnection sqlcon = new SqlConnection(connStr);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr, sqlcon);
            DataSet ds = new DataSet();
            sqlcon.Open();
            da.Fill(ds);
            GridView2.DataSource = ds;                                     //设定gridview的datasourse
            GridView2.DataKeyNames = new string[] { "ID" };//主键
            GridView2.DataBind();
            sqlcon.Close();
            show();
        }
        else if (xi != "请选择系" && cl == "请选择班级")
        {
            //查询系
            string sqlStr1 = "SELECT ID,Name,password,banji.CLM FROM si,banji WHERE banji.Class_ID=si.classid AND nianji='" + nj + "' AND si.xi_ID=(SELECT Xi_id FROM Xi WHERE XM='" + xi + "')";
            SqlConnection sqlcon = new SqlConnection(connStr);
            SqlDataAdapter da1 = new SqlDataAdapter(sqlStr1, sqlcon);
            DataSet ds1 = new DataSet();
            sqlcon.Open();
            da1.Fill(ds1);
            GridView2.DataSource = ds1;                                     //设定gridview的datasourse
            GridView2.DataKeyNames = new string[] { "ID" };//主键
            GridView2.DataBind();
            sqlcon.Close();
            show();
        }
        else if (xi != "" && cl != "请选择班级")
        {
            //查询班级
            string sqlStr2 = "SELECT ID,Name,password,banji.CLM FROM si,banji WHERE banji.Class_ID=si.classid AND nianji='" + nj + "' AND classid=(SELECT Class_ID FROM banji WHERE CLM='" + cl + "' AND grade='" + nj + "')";
            SqlConnection sqlcon = new SqlConnection(connStr);
            SqlDataAdapter da2 = new SqlDataAdapter(sqlStr2, sqlcon);
            DataSet ds2 = new DataSet();
            sqlcon.Open();
            da2.Fill(ds2);
            GridView2.DataSource = ds2;                                     //设定gridview的datasourse
            GridView2.DataKeyNames = new string[] { "ID" };//主键
            GridView2.DataBind();
            sqlcon.Close();
            show();
        }
        else if (xi == "请选择系" && cl == "请选择班级")
        {
            //提示错误
            Response.Write(@"<script>alert('请正确选择或填写查询信息！');</script>");
        }
    }


    /// <summary>
    /// 全选gridveiw
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        //.BottomPagerRow ,取得 GridViewRow 物件，代表下方頁面巡覽區的資料列中 GridView 控制  
        CheckBox cbxHead = (CheckBox)GridView2.HeaderRow.FindControl("CheckBox2");

        for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView2.Rows[i].FindControl("CheckBox1");
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
        for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView2.Rows[i].FindControl("CheckBox1");
            if (cbox.Checked == true)
            {

                string delstr = "DELETE FROM Experience WHERE ID='" + GridView2.DataKeys[i].Value.ToString() + "';DELETE FROM marriage WHERE ID='" + GridView2.DataKeys[i].Value.ToString() + "';DELETE FROM Relation WHERE ID='" + GridView2.DataKeys[i].Value.ToString() + "';DELETE FROM si WHERE ID='" + GridView2.DataKeys[i].Value.ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(delstr, sqlcon);
                DataSet ds = new DataSet();
                sqlcon.Open();
                sda.Fill(ds);
                sqlcon.Close();
                bind();
            }

        }


    }

    /// <summary>
    /// 取消选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        CheckBox cbxHead = (CheckBox)GridView2.Rows[0].FindControl("CheckBox2");

        for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView2.Rows[i].FindControl("CheckBox1");
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
        GridView2.EditIndex = e.NewEditIndex;
        bind();

    }


    /// gridview更新
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // 将GridView1.Rows[e.RowIndex].Cells[1].Controls[0]强制转换类型成textbox，
        string nm = ((TextBox)(GridView2.Rows[e.RowIndex].Cells[2].Controls[0])).Text;
        string pwd = ((TextBox)(GridView2.Rows[e.RowIndex].Cells[3].Controls[0])).Text;
        string upstr = "UPDATE si SET Name='" + nm + "', password='" + pwd + "' WHERE ID='" + GridView2.DataKeys[e.RowIndex].Value.ToString() + "'";

        SqlConnection sqlcon = new SqlConnection(connStr);
        SqlDataAdapter sda = new SqlDataAdapter(upstr, sqlcon);
        DataSet ds = new DataSet();
        sqlcon.Open();
        sda.Fill(ds);                   //填充dataset
        sqlcon.Close();
        GridView2.EditIndex = -1;      // EditIndex属性 要编辑的行从0开始 预设值为-1
        bind();



    }

    /// <summary>
    /// gridview 更新内取消功能
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView2.EditIndex = -1;          //要编辑的行从0开始
        bind();

    }

    /// <summary>
    /// gridview删除行功能
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string delstr = " DELETE FROM Experience WHERE ID='" + GridView2.DataKeys[e.RowIndex].Value.ToString() + "';DELETE FROM marriage WHERE ID='" + GridView2.DataKeys[e.RowIndex].Value.ToString() + "';DELETE FROM Relation WHERE ID='" + GridView2.DataKeys[e.RowIndex].Value.ToString() + "' DELETE FROM si WHERE ID='" + GridView2.DataKeys[e.RowIndex].Value.ToString() + "'";
        SqlConnection sqlcon = new SqlConnection(connStr);
        SqlDataAdapter sda = new SqlDataAdapter(delstr, sqlcon);
        DataSet ds = new DataSet();
        sqlcon.Open();
        sda.Fill(ds);               //填充dataset
        sqlcon.Close();
        bind();


    }



    protected void chakan_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        int rowindex = gvr.RowIndex;
        string id = GridView2.DataKeys[rowindex].Value.ToString();
        // ScriptManager1.RegisterAsyncPostBackControl(Button1);
        string url = "Stuinfo.aspx?id="+ id;
        Response.Write("<script language='javascript'>window.open('" + url + "','','height=600,width=800,scrollbars=yes,status =yes')</script>");
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

            //cmd.CommandText = "INSERT INTO stuInfo (学号,姓名,学院,系,班级,曾用名,生日,民族,政治面貌,健康状况,婚姻状况,电话号码,手机号码,电子邮箱,身份证号,生源地,家庭住址,家庭电话,邮政编码,备注,什么时候受过什么奖励,什么时候入的党团,受过什么处分,家庭主要成员和主要关系中有无重大问题与本人关系如何,其他需要向组织说明的问题, 记事) VALUES('" + ds.Tables[0].Rows[i][0].ToString() + "', '" + ds.Tables[0].Rows[i][1].ToString() + "', '" + ds.Tables[0].Rows[i][2].ToString() + "', '" + ds.Tables[0].Rows[i][3].ToString() + "', '" + ds.Tables[0].Rows[i][4].ToString() + "', '" + ds.Tables[0].Rows[i][5].ToString() + "', '" + ds.Tables[0].Rows[i][6].ToString() + "', '" + ds.Tables[0].Rows[i][7].ToString() + "', '" + ds.Tables[0].Rows[i][8].ToString() + "', '" + ds.Tables[0].Rows[i][9].ToString() + "', '" + ds.Tables[0].Rows[i][10].ToString() + "', '" + ds.Tables[0].Rows[i][11].ToString() + "', '" + ds.Tables[0].Rows[i][12].ToString() + "', '" + ds.Tables[0].Rows[i][13].ToString() + "', '" + ds.Tables[0].Rows[i][14].ToString() + "', '" + ds.Tables[0].Rows[i][15].ToString() + "', '" + ds.Tables[0].Rows[i][16].ToString() + "', '" + ds.Tables[0].Rows[i][17].ToString() + "', '" + ds.Tables[0].Rows[i][18].ToString() + "', '" + ds.Tables[0].Rows[i][19].ToString() + "', '" + ds.Tables[0].Rows[i][20].ToString() + "', '" + ds.Tables[0].Rows[i][21].ToString() + "', '" + ds.Tables[0].Rows[i][22].ToString() + "', '" + ds.Tables[0].Rows[i][23].ToString() + "', '" + ds.Tables[0].Rows[i][24].ToString() + "')";
        }
        conn.Close();
    }

    /// <summary>
    /// excel数据集操作
    /// </summary>
    private void ExcelDataOperator()
    {

        DataSet ds = new DataSet();
        for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView2.Rows[i].FindControl("CheckBox1");
            if (cbox.Checked == true)
            {
                string id = GridView2.DataKeys[i].Value.ToString();
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