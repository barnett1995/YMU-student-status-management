using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;

public partial class test1 : System.Web.UI.Page
{
    string connStr = "server=DESKTOP-RNBGQQS;uid=sa;pwd=123456;database=StudentsInfo";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
            selectbind();
            this.selectxi.Items.Insert(0, new ListItem("请选择系", "0"));
            this.selectbj.Items.Insert(0, new ListItem("请选择班级", "0"));

        }
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
        string id = xuehao.Value;

        if (id != "")
        {
            // 查询id
            string sqlStr = "SELECT ID,Name,password,banji.CLM FROM si,banji WHERE si.ID='" + id + "' AND banji.Class_ID=si.classid";
            searchBind(sqlStr);
        }
        else if (xi != "请选择系" && cl == "请选择班级")
        {
            //查询系
            string sqlStr1 = "SELECT ID,Name,password,banji.CLM FROM si,banji WHERE banji.Class_ID=si.classid AND si.xi_ID=(SELECT Xi_id FROM Xi WHERE XM='" + xi + "')";
            searchBind(sqlStr1);
        }
        else if (xi != "" && cl != "请选择班级")
        {
            //查询班级
            string sqlStr2 = "SELECT ID,Name,password,banji.CLM FROM si,banji WHERE banji.Class_ID=si.classid AND classid=(SELECT Class_ID FROM banji WHERE CLM='" + cl + "')";
            searchBind(sqlStr2);
        }
        else if(xi == "请选择系" && cl == "请选择班级")
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
        this.selectbj.Items.Insert(0, new ListItem("请选择班级", "0"));
        xuehao.Value = "";
        bind();
    }


    /// <summary>
    /// 全选gridveiw
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
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
        GridView1.PageIndex = e.NewPageIndex;
        bind();
    }
}