using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class login : System.Web.UI.Page
{
    string connStr = "server=DESKTOP-RNBGQQS;uid=sa;pwd=123456;database=StudentsInfo";    //连接数据库
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void DengluClick(object sender, EventArgs e)
    {
        string ID = id.Text;
        string PWD = pwd.Text;

        if (ID == "" || PWD == "")                                                            //判断是否为空
        {
            Response.Write(@"<script>alert('用户名,密码不能为空！');</script>");
        }
        else
        {

            string selectstr = "select ID,password from si where ID='" + ID + "' and password='" + PWD + "'";       //数据库查询
            SqlConnection conn = new SqlConnection(connStr);                         //连接的数据库名称
            SqlDataAdapter da = new SqlDataAdapter(selectstr, conn);
            DataTable dt = new DataTable();
            conn.Open();                                                             //打开数据库
            da.Fill(dt);                                                            //将数据填充到DataTable（dt）
            conn.Close();                                                           //关闭数据库
            if (dt.Rows.Count == 0)                                                  //如果数据库查询没有这一行信息，则提示错误，否则页面跳转
            {
                Response.Write(@"<script>alert('用户名或密码错误！');</script>");
                id.Text = "";
                pwd.Text = "";
                id.Focus();                                                         //更改光标位置
            }
            else
            {
                string url = "Stuinfo.aspx?id=" + id.Text;
                Response.Redirect(url);                                      //页面跳转
            }
        }

                             
     }
 }
