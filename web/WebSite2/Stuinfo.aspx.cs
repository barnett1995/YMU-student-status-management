using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Stuinfo : System.Web.UI.Page
{
    string connStr = "server=DESKTOP-RNBGQQS;uid=sa;pwd=123456;database=StudentsInfo";
    protected void Page_Load(object sender, EventArgs e)
    {
        show();
    }

    public void show()
    {
        string id = "201620247001";
       // string id = Request.QueryString["id" ];
        string photoStr = "SELECT Photo FROM si WHERE ID='" + id + "'";
        string selectStr = "SELECT * FROM si WHERE ID='" + id + "'";                //查询学生信息表
        string selectStr1 = "SELECT * FROM Relation WHERE ID='" + id + "'";          //查看社会关系表
        string selectStr2 = "SELECT * FROM marriage WHERE ID = '" + id + "'";        //查询家庭关系表
        string selectStr3 = "SELECT * FROM Experience WHERE ID='" + id + "'";        //查询社会关系表

        SqlConnection conn = new SqlConnection(connStr);                         //连接的数据库名称
        SqlCommand cmd = new SqlCommand(photoStr, conn);
        SqlDataAdapter da = new SqlDataAdapter(selectStr, conn);
        SqlDataAdapter da1 = new SqlDataAdapter(selectStr1, conn);
        SqlDataAdapter da2 = new SqlDataAdapter(selectStr2, conn);
        SqlDataAdapter da3 = new SqlDataAdapter(selectStr3, conn);
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        conn.Open();                                          //打开数据库

        da.Fill(dt);                                                            //将数据填充到DataTable（dt）
        da1.Fill(dt1);
        da2.Fill(dt2);
        da3.Fill(dt3);
        SqlDataReader reader = cmd.ExecuteReader();
        reader.Read();
        string photoPath = reader[0].ToString();
        conn.Close();
        Response.Write(@"<script>alert('"+photoPath+"');</script>");

        preview.Src = photoPath;
      
        //基本信息表 dt
        name.Value = dt.Rows[0]["Name"].ToString();                        //姓名    
        lastnaem.Value = dt.Rows[0]["OnceName"].ToString();                     //曾用名
        minzu.Value = dt.Rows[0]["Nationality"].ToString();               //民族    
        zhengzhi.Value = dt.Rows[0]["Political"].ToString();                      // 政治面貌
        jiankang.Value = dt.Rows[0]["Body"].ToString();                             //健康状况
        hunyin.Value = dt.Rows[0]["Marriage"].ToString();                     //婚姻状况

        shenri.Value = dt.Rows[0]["Birthday"].ToString();                        //生日
        email.Value = dt.Rows[0]["E_Mail"].ToString();                          //邮箱
        phone.Value = dt.Rows[0]["MobileNo手机号码"].ToString();                 //你的联系方式
        jtphone.Value = dt.Rows[0]["JTDH"].ToString();                           //家庭联系方式
        syd.Value = dt.Rows[0]["SYD"].ToString();                               //生源地
        idcard.Value = dt.Rows[0]["CardID"].ToString();                          //身份证号
        jtzz.Value = dt.Rows[0]["JTZZ"].ToString();                              //家庭住址
        yzbm.Value = dt.Rows[0]["JZBM"].ToString();                        //邮政编码
        rudang.Value = dt.Rows[0]["JoinTssue"].ToString();                   //入党过程
        jiangli.Value = dt.Rows[0]["Reward"].ToString();                          //奖励明细
        chengfa.Value = dt.Rows[0]["punishment"].ToString();                 //惩罚明细
        jtgx.Value = dt.Rows[0]["BigEvents"].ToString();                          //家庭主要成员和主要关系中有无重大问题，与本人关系如何
        qita.Value = dt.Rows[0]["OtherProblem"].ToString();                 //其他问题说明
        jishi.Value = dt.Rows[0]["Remember"].ToString();                    //个人介绍与事件记录
        bank.Value = dt.Rows[0]["Bank"].ToString();
        bankcard.Value = dt.Rows[0]["Bankcard"].ToString();
        sex.Value = dt.Rows[0]["Sex"].ToString();

        //社会关系表 Relation
        friend11.Value = dt1.Rows[0]["Name"].ToString();                    //姓名
        friend12.Value = dt1.Rows[0]["Relation"].ToString();                //与本人关系
        friend13.Value = dt1.Rows[0]["PoliticalFace"].ToString();           //政治面貌
        friend14.Value = dt1.Rows[0]["Company"].ToString();                 //工作单位
        friend15.Value = dt1.Rows[0]["Work"].ToString();                  //工作
        friend16.Value = dt1.Rows[0]["phone"].ToString();                   //联系电话

        friend21.Value = dt1.Rows[1]["Name"].ToString();
        friend22.Value = dt1.Rows[1]["Relation"].ToString();
        friend23.Value = dt1.Rows[1]["PoliticalFace"].ToString();
        friend24.Value = dt1.Rows[1]["Company"].ToString();
        friend25.Value = dt1.Rows[1]["Work"].ToString();
        friend26.Value = dt1.Rows[1]["phone"].ToString();

        friend31.Value = dt1.Rows[2]["Name"].ToString();
        friend32.Value = dt1.Rows[2]["Relation"].ToString();
        friend33.Value = dt1.Rows[2]["PoliticalFace"].ToString();
        friend34.Value = dt1.Rows[2]["Company"].ToString();
        friend35.Value = dt1.Rows[2]["Work"].ToString();
        friend36.Value = dt1.Rows[2]["phone"].ToString();

        friend41.Value = dt1.Rows[3]["Name"].ToString();
        friend42.Value = dt1.Rows[3]["Relation"].ToString();
        friend43.Value = dt1.Rows[3]["PoliticalFace"].ToString();
        friend44.Value = dt1.Rows[3]["Company"].ToString();
        friend45.Value = dt1.Rows[3]["Work"].ToString();
        friend46.Value = dt1.Rows[3]["phone"].ToString();

        friend51.Value = dt1.Rows[4]["Name"].ToString();
        friend52.Value = dt1.Rows[4]["Relation"].ToString();
        friend53.Value = dt1.Rows[4]["PoliticalFace"].ToString();
        friend54.Value = dt1.Rows[4]["Company"].ToString();
        friend55.Value = dt1.Rows[4]["Work"].ToString();
        friend56.Value = dt1.Rows[4]["phone"].ToString();

        friend51.Value = dt1.Rows[5]["Name"].ToString();
        friend52.Value = dt1.Rows[5]["Relation"].ToString();
        friend53.Value = dt1.Rows[5]["PoliticalFace"].ToString();
        friend54.Value = dt1.Rows[5]["Company"].ToString();
        friend55.Value = dt1.Rows[5]["Work"].ToString();
        friend56.Value = dt1.Rows[5]["phone"].ToString();

        //家庭关系表 marriage

        family11.Value = dt2.Rows[0]["Name"].ToString();                    //姓名
        family12.Value = dt2.Rows[0]["Relation"].ToString();                //与本人关系
        family13.Value = dt2.Rows[0]["PoliticalFace"].ToString();           //政治面貌
        family14.Value = dt2.Rows[0]["Company"].ToString();                 //工作单位
        family15.Value = dt2.Rows[0]["Work"].ToString();                  //职务
        family16.Value = dt2.Rows[0]["phone"].ToString();                   //电话号码

        family21.Value = dt2.Rows[1]["Name"].ToString();
        family22.Value = dt2.Rows[1]["Relation"].ToString();
        family23.Value = dt2.Rows[1]["PoliticalFace"].ToString();
        family24.Value = dt2.Rows[1]["Company"].ToString();
        family25.Value = dt2.Rows[1]["Work"].ToString();
        family26.Value = dt2.Rows[1]["phone"].ToString();

        family31.Value = dt2.Rows[2]["Name"].ToString();
        family32.Value = dt2.Rows[2]["Relation"].ToString();
        family33.Value = dt2.Rows[2]["PoliticalFace"].ToString();
        family34.Value = dt2.Rows[2]["Company"].ToString();
        family35.Value = dt2.Rows[2]["Work"].ToString();
        family36.Value = dt2.Rows[2]["phone"].ToString();

        family41.Value = dt2.Rows[3]["Name"].ToString();
        family42.Value = dt2.Rows[3]["Relation"].ToString();
        family43.Value = dt2.Rows[3]["PoliticalFace"].ToString();
        family44.Value = dt2.Rows[3]["Company"].ToString();
        family45.Value = dt2.Rows[3]["Work"].ToString();
        family46.Value = dt2.Rows[3]["phone"].ToString();

        family51.Value = dt2.Rows[4]["Name"].ToString();
        family52.Value = dt2.Rows[4]["Relation"].ToString();
        family53.Value = dt2.Rows[4]["PoliticalFace"].ToString();
        family54.Value = dt2.Rows[4]["Company"].ToString();
        family55.Value = dt2.Rows[4]["Work"].ToString();
        family56.Value = dt2.Rows[4]["phone"].ToString();

        family61.Value = dt2.Rows[5]["Name"].ToString();
        family62.Value = dt2.Rows[5]["Relation"].ToString();
        family63.Value = dt2.Rows[5]["PoliticalFace"].ToString();
        family64.Value = dt2.Rows[5]["Company"].ToString();
        family65.Value = dt2.Rows[5]["Work"].ToString();
        family66.Value = dt2.Rows[5]["phone"].ToString();

        sh11.Value = dt3.Rows[0]["time"].ToString();                 //时间
        sh12.Value = dt3.Rows[0]["Attribution"].ToString();             //工作地点
        sh13.Value = dt3.Rows[0]["Position"].ToString();                //职务

        sh21.Value = dt3.Rows[1]["time"].ToString();
        sh22.Value = dt3.Rows[1]["Attribution"].ToString();
        sh23.Value = dt3.Rows[1]["Position"].ToString();

        sh31.Value = dt3.Rows[2]["time"].ToString();
        sh32.Value = dt3.Rows[2]["Attribution"].ToString();
        sh33.Value = dt3.Rows[2]["Position"].ToString();

        sh41.Value = dt3.Rows[3]["time"].ToString();
        sh42.Value = dt3.Rows[3]["Attribution"].ToString();
        sh43.Value = dt3.Rows[3]["Position"].ToString();

        sh51.Value = dt3.Rows[4]["time"].ToString();
        sh52.Value = dt3.Rows[4]["Attribution"].ToString();
        sh53.Value = dt3.Rows[4]["Position"].ToString();

        sh61.Value = dt3.Rows[5]["time"].ToString();
        sh62.Value = dt3.Rows[5]["Attribution"].ToString();
        sh63.Value = dt3.Rows[5]["Position"].ToString();
    }


}