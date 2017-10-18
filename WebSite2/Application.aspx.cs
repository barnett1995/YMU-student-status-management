using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    string connStr = "server=1-PC;uid=sa;pwd=admin2017GAO;database=StudentsInfo";     //连接数据库
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    public void bind()
    {
        // 查询id
        // string sqlStr = "SELECT ID,Name,password,banji.CLM FROM si,banji WHERE si.ID='" + id + "'  AND banji.Class_ID=si.classid";
            string sqlStr = "SELECT ID,Name,nianji,CLM FROM si,banji WHERE apply='true' AND si.classid=banji.Class_ID ";
            SqlConnection sqlcon = new SqlConnection(connStr);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr, sqlcon);
            DataSet ds = new DataSet();
            sqlcon.Open();
            da.Fill(ds);
            GridView2.DataSource = ds;                                     //设定gridview的datasourse
            GridView2.DataKeyNames = new string[] { "ID" };//主键
            GridView2.DataBind();
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
    /// 同意所有全选
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
                string upStr = "update si SET Authority='true',apply='false' WHERE ID='" + GridView2.DataKeys[i].Value.ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(upStr, sqlcon);
                DataSet ds = new DataSet();
                sqlcon.Open();
                sda.Fill(ds);
                sqlcon.Close();
            }
        }
        bind();
    }

    /// <summary>
    /// 不同意所有全选
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection sqlcon = new SqlConnection(connStr);
        for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView2.Rows[i].FindControl("CheckBox1");
            if (cbox.Checked == true)
            {
                string upStr = "update si SET overrule='true',apply='false' WHERE ID='" + GridView2.DataKeys[i].Value.ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(upStr, sqlcon);
                DataSet ds = new DataSet();
                sqlcon.Open();
                sda.Fill(ds);
                sqlcon.Close();
            }
        }
        bind();
    }

    /// <summary>
    /// 查看信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chakan_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        int rowindex = gvr.RowIndex;
        string id = GridView2.DataKeys[rowindex].Value.ToString();
        // ScriptManager1.RegisterAsyncPostBackControl(Button1);
        string url = "Stuinfo.aspx?id=" + id;
        Response.Write("<script language='javascript'>window.open('" + url + "','','height=600,width=810,scrollbars=yes,status =yes')</script>");
    }


    /// <summary>
    /// 同意更改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void true_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        int rowindex = gvr.RowIndex;
        string id = GridView2.DataKeys[rowindex].Value.ToString();

         SqlConnection sqlcon = new SqlConnection(connStr);
        string upStr = "update si SET overrule='true',apply='false' WHERE ID='" +id+ "'";
        SqlDataAdapter sda = new SqlDataAdapter(upStr, connStr);
        DataSet ds = new DataSet();
        sqlcon.Open();
        sda.Fill(ds);
        sqlcon.Close();
        bind();
    }

    /// <summary>
    /// 不同意更改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void false_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        int rowindex = gvr.RowIndex;
        string id = GridView2.DataKeys[rowindex].Value.ToString();

        SqlConnection sqlcon = new SqlConnection(connStr);
        string upStr = "update si SET overrule='true',apply='false' WHERE ID='" +id+ "'";
        SqlDataAdapter sda = new SqlDataAdapter(upStr, connStr);
        DataSet ds = new DataSet();
        sqlcon.Open();
        sda.Fill(ds);
        sqlcon.Close();
        bind();
    }


}