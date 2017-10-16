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
    string connStr = "server=1-PC;uid=sa;pwd=admin2017GAO;database=StudentsInfo";     //连接数据库
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void DengluClick(object sender, EventArgs e)
    {
        
        string ID = id.Text;
        string PWD = pwd.Text;
        string XGB = xgb.Value;
        string XZR = xzr.Value;
        string BZR = bzr.Value;

        if (ID == "" || PWD == "")                                                            //判断是否为空
        {
            Response.Write(@"<script>alert('用户名,密码不能为空！');</script>");
        }
        else
        {
            if (xgb.Checked)
            {
                string selectstr = "select ID,Password,Position from Teacher where ID='" + ID + "' and password='" + PWD + "' and Position='"+XGB+"'";       //数据库查询
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
                    
                
                    Session["ID"] = id.Text;
                    Response.Redirect("College.aspx");                                      //页面跳转
                }
            }
            else if (xzr.Checked)
            {
                string selectstr = "select ID,Password,Position from Teacher where ID='" + ID + "' and password='" + PWD + "' and Position='" + XZR + "'";       //数据库查询
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
                    Session["ID"] = id.Text;
                    Response.Redirect("Admin0.aspx");                                     //页面跳转
                }
            }
            else if (bzr.Checked)
            {
                string selectstr = "select ID,Password,Position from Teacher where ID='" + ID + "' and password='" + PWD + "' and Position='" + BZR + "'";                                        //数据库查询
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
                    Session["ID"] = id.Text;
                    Response.Redirect("Teacher.aspx");                                  //页面跳转
                }
            }
        }       

    }


}
