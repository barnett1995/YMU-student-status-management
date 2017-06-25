using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class test : System.Web.UI.Page
{
    string connStr = "server=DESKTOP-RNBGQQS;uid=sa;pwd=123456;database=StudentsInfo";    //连接数据库
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void dowChick(object sender, EventArgs e)
    {
        string id = "2016级计算机科学与技术（专升本）";
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

    protected void lalalalalalalalalalalalChick(object sender, EventArgs e)
    {
        // delExcel();
        copyExcel();
    }


    public void copyExcel()
    {
        string id = "2016级计算机科学与技术（专升本）";
        string ExcelName = "" + id + ".xlsx";
        string Model = "C:/web/WebSite2/Excel/Model/1.xlsx";
        string excel= "C:/web/WebSite2/Excel/"+ExcelName+"";

        System.IO.File.Copy(Model, excel);

    }

    public void delExcel()
    {
        string id = "2016级计算机科学与技术（专升本）";
        string ExcelName = "" + id + ".xlsx";
        System.IO.File.Delete(@"C:/web/WebSite2/Excel/" + ExcelName + "");
    }

    /// <summary>
    /// excel数据操作
    /// </summary>
    /// <param name="ds"></param>
    private void ExcelDataSetOperator(DataSet ds)
    {
        string id = "2016级计算机科学与技术（专升本）";

        int a = ds.Tables[0].Rows.Count;
        String myString = "Provider = Microsoft.ACE.OLEDB.12.0 ;Data Source = C:/web/WebSite2/Excel/" + id + ".xlsx; Extended Properties='Excel 12.0;HDR = YES;'";

        OleDbConnection conn = new OleDbConnection(myString);
        OleDbCommand cmd = conn.CreateCommand();
        conn.Open();
        for (int i = 0; i < a; i++)
        {
            cmd.CommandText = "INSERT INTO [Sheet1$] (学号,姓名,密码,曾用名,班级,年级,生日,性别,民族,健康状况,婚姻状况,手机号码,银行卡号,开户行,电子邮箱,身份证号码,生源地,家庭住址,家庭电话,邮政编码,什么时候受过什么奖励,什么时候入的党团,受过什么处分,家庭主要成员和主要关系中有无重大问题，与本人关系如何,其他需要向组织说明的问题,记事) VALUES('" + ds.Tables[0].Rows[i][0].ToString() + "', '" + ds.Tables[0].Rows[i][1].ToString() + "', '" + ds.Tables[0].Rows[i][2].ToString() + "', '" + ds.Tables[0].Rows[i][3].ToString() + "','" + ds.Tables[0].Rows[i][6].ToString() + "', '" + ds.Tables[0].Rows[i][7].ToString() + "', '" + ds.Tables[0].Rows[i][8].ToString() + "', '" + ds.Tables[0].Rows[i][9].ToString() + "', '" + ds.Tables[0].Rows[i][10].ToString() + "', '" + ds.Tables[0].Rows[i][11].ToString() + "', '" + ds.Tables[0].Rows[i][12].ToString() + "', '" + ds.Tables[0].Rows[i][13].ToString() + "', '" + ds.Tables[0].Rows[i][14].ToString() + "', '" + ds.Tables[0].Rows[i][15].ToString() + "', '" + ds.Tables[0].Rows[i][16].ToString() + "', '" + ds.Tables[0].Rows[i][17].ToString() + "', '" + ds.Tables[0].Rows[i][18].ToString() + "', '" + ds.Tables[0].Rows[i][19].ToString() + "', '" + ds.Tables[0].Rows[i][20].ToString() + "', '" + ds.Tables[0].Rows[i][21].ToString() + "', '" + ds.Tables[0].Rows[i][22].ToString() + "', '" + ds.Tables[0].Rows[i][23].ToString() + "', '" + ds.Tables[0].Rows[i][24].ToString() + "', '" + ds.Tables[0].Rows[i][25].ToString() + "', '" + ds.Tables[0].Rows[i][26].ToString() + "', '" + ds.Tables[0].Rows[i][27].ToString() + "')";

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
        string cm = "计算机科学与技术（专升本）";
        // string selstr = "SELECT * FROM si WHERE classid='"+cm+"'";
        string selstr = "SELECT * FROM si";
        //  string selstr = "SELECT * FROM si WHERE classid=(SELECT Class_ID FROM banji WHERE CLM='" + cm + "')";
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter sda = new SqlDataAdapter(selstr, conn);
        DataSet ds = new DataSet();
        conn.Open();
        sda.Fill(ds);
        conn.Close();
        ExcelDataSetOperator(ds);

    }


}