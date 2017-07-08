using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class t : System.Web.UI.Page
{
    string connStr = "server=DESKTOP-RNBGQQS;uid=sa;pwd=123456;database=StudentsInfo";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            show();
        }

    }

    /// <summary>
    /// 显示已填写信息
    /// </summary>
    public void show()
    {
        Application.Lock();
        string id = Application["ID"].ToString();
        Application.UnLock();
        string photoStr= "SELECT Photo FROM si WHERE ID='" + id + "'";
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
      





        if (dt.Rows.Count == 0 || dt1.Rows.Count == 0 || dt2.Rows.Count == 0 || dt3.Rows.Count == 0)
        {
            Response.Write(@"<script>alert('请认真填写，全部填写完方可提交！');</script>");
        }
        else
        {
            preview.Src = photoPath;
            //基本信息表 dt
            firstname.Value = dt.Rows[0]["Name"].ToString();                        //姓名    
            lastname.Value = dt.Rows[0]["OnceName"].ToString();                     //曾用名
            nationality.Value = dt.Rows[0]["Nationality"].ToString();               //民族    
            group.Value = dt.Rows[0]["Political"].ToString();                      // 政治面貌
            body.Value = dt.Rows[0]["Body"].ToString();                             //健康状况
            marriage.Value = dt.Rows[0]["Marriage"].ToString();                     //婚姻状况
          
            date1.Value = dt.Rows[0]["Birthday"].ToString();                        //生日
            email.Value = dt.Rows[0]["E_Mail"].ToString();                          //邮箱
            phone.Value = dt.Rows[0]["MobileNo手机号码"].ToString();                 //你的联系方式
            phone2.Value = dt.Rows[0]["JTDH"].ToString();                           //家庭联系方式
            site.Value = dt.Rows[0]["SYD"].ToString();                               //生源地
            idcard.Value = dt.Rows[0]["CardID"].ToString();                          //身份证号
            home.Value = dt.Rows[0]["JTZZ"].ToString();                              //家庭住址
            postalcode.Value = dt.Rows[0]["JZBM"].ToString();                        //邮政编码
            joingroup.Value = dt.Rows[0]["JoinTssue"].ToString();                   //入党过程
            award.Value = dt.Rows[0]["Reward"].ToString();                          //奖励明细
            punishment.Value = dt.Rows[0]["punishment"].ToString();                 //惩罚明细
            wt.Value = dt.Rows[0]["BigEvents"].ToString();                          //家庭主要成员和主要关系中有无重大问题，与本人关系如何
            anything.Value = dt.Rows[0]["OtherProblem"].ToString();                 //其他问题说明
            everything.Value = dt.Rows[0]["Remember"].ToString();                    //个人介绍与事件记录
            bank.SelectedItem.Text= dt.Rows[0]["Bank"].ToString();
            bankcard.Value = dt.Rows[0]["Bankcard"].ToString();
            Sex.SelectedItem.Text = dt.Rows[0]["Sex"].ToString();

    

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

            //社会经历表  Experience     

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


    /// <summary>
    /// 检查上传图片的格式
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    protected string CheckFileName(string fileName)
    {
        //返回指定路径文件的扩展名 并转换成小写
        string fileType = Path.GetExtension(fileName).ToLower();

        //判断文件的后缀名
        if (fileType == ".jpg" || fileType == ".jpeg" || fileType == ".png")
        {
            //返回指定路径不具有扩展名的文件名
            string oldName = Path.GetFileNameWithoutExtension(fileName);
            //使用时间来重新命名图片 为了避免重名
            string newName = DateTime.Now.ToFileTime() + fileType;
            return newName;
        }
        else
        {
            return null;
        }
    }

    protected void ButtonClick(object sender, EventArgs e)
    {
        Application.Lock();
        string id = Application["ID"].ToString();
        Application.UnLock();                          //获取url传参参数

        String name = firstname.Value;                          //姓名
        String lname = lastname.Value;                          //曾用名
        String hunyin = marriage.Value;                         //婚姻
        String minzu = nationality.Value;                       //民族
        String zhengzhi = group.Value;                          //政治面貌
        String jiankang = body.Value;                           //健康状况
        String xingbie = Sex.SelectedItem.Text;                             //性别
        String shenri = date1.Value;                            //生日
        String youxiang = email.Value;                          //邮箱
        String shouji = phone.Value;                            //手机号
        String jiazhang = phone2.Value;                         //家庭电话
        String yinhang = bank.SelectedItem.Text;                       //银行
        String kahao = bankcard.Value;                          //卡号
        String chushengdi = site.Value;                         //出生地
        String shenfengzheng = idcard.Value;                    //身份证
        String huji = home.Value;                               //户籍
        String youzheng = postalcode.Value;                     //邮政编码
        String rudang = joingroup.Value;                        //入党入团
        String jiangli = award.Value;                           //奖励
        String chengfa = punishment.Value;                      //惩罚
        String wenti = wt.Value;                                //关系中有无重大问题
        String zuzhi = anything.Value;                          //向组织说明的其他问题
        String jishi = everything.Value;                        //记事

        //社会经历表
        String sa1 = sh11.Value;
        String sb1 = sh12.Value;
        String sc1 = sh13.Value;
        String sa2 = sh21.Value;
        String sb2 = sh22.Value;
        String sc2 = sh23.Value;
        String sa3 = sh31.Value;
        String sb3 = sh32.Value;
        String sc3 = sh33.Value;
        String sa4 = sh41.Value;
        String sb4 = sh42.Value;
        String sc4 = sh43.Value;
        String sa5 = sh51.Value;
        String sb5 = sh52.Value;
        String sc5 = sh53.Value;
        String sa6 = sh61.Value;
        String sb6 = sh62.Value;
        String sc6 = sh63.Value;


        // 家庭关系表（h） 姓名(a) 与本人关系(b) 政治面貌(c) 工作单位d 职务(e) 联系电话(f) 数字表示行数

        String ha1 = family11.Value;
        String hb1 = family12.Value;
        String hc1 = family13.Value;
        String hd1 = family14.Value;
        String he1 = family15.Value;
        String hf1 = family16.Value;
        String ha2 = family21.Value;
        String hb2 = family22.Value;
        String hc2 = family23.Value;
        String hd2 = family24.Value;
        String he2 = family25.Value;
        String hf2 = family26.Value;
        String ha3 = family31.Value;
        String hb3 = family32.Value;
        String hc3 = family33.Value;
        String hd3 = family34.Value;
        String he3 = family35.Value;
        String hf3 = family36.Value;
        String ha4 = family41.Value;
        String hb4 = family42.Value;
        String hc4 = family43.Value;
        String hd4 = family44.Value;
        String he4 = family45.Value;
        String hf4 = family46.Value;
        String ha5 = family51.Value;
        String hb5 = family52.Value;
        String hc5 = family53.Value;
        String hd5 = family54.Value;
        String he5 = family55.Value;
        String hf5 = family56.Value;
        String ha6 = family61.Value;
        String hb6 = family62.Value;
        String hc6 = family63.Value;
        String hd6 = family64.Value;
        String he6 = family65.Value;
        String hf6 = family66.Value;


        // 社会关系表（f） 姓名(a) 与本人关系(b) 政治面貌(c) 工作单位d 职务(e) 联系电话(f) 数字表示行数


        String fa1 = friend11.Value;
        String fb1 = friend12.Value;
        String fc1 = friend13.Value;
        String fd1 = friend14.Value;
        String fe1 = friend15.Value;
        String ff1 = friend16.Value;
        String fa2 = friend21.Value;
        String fb2 = friend22.Value;
        String fc2 = friend23.Value;
        String fd2 = friend24.Value;
        String fe2 = friend25.Value;
        String ff2 = friend26.Value;
        String fa3 = friend31.Value;
        String fb3 = friend32.Value;
        String fc3 = friend33.Value;
        String fd3 = friend34.Value;
        String fe3 = friend35.Value;
        String ff3 = friend36.Value;
        String fa4 = friend41.Value;
        String fb4 = friend42.Value;
        String fc4 = friend43.Value;
        String fd4 = friend44.Value;
        String fe4 = friend45.Value;
        String ff4 = friend46.Value;
        String fa5 = friend51.Value;
        String fb5 = friend52.Value;
        String fc5 = friend53.Value;
        String fd5 = friend54.Value;
        String fe5 = friend55.Value;
        String ff5 = friend56.Value;
        String fa6 = friend61.Value;
        String fb6 = friend62.Value;
        String fc6 = friend63.Value;
        String fd6 = friend64.Value;
        String fe6 = friend65.Value;
        String ff6 = friend66.Value;


       

     
        string sortStr = "SELECT sort FROM Relation WHERE ID='" + id + "'";
        string sortStr1 = "SELECT sort FROM marriage WHERE ID='" + id + "'";
        string sortStr2 = "SELECT sort FROM Experience WHERE ID='" + id + "'";
        SqlConnection conn = new SqlConnection(connStr);                         //连接的数据库名称
        SqlDataAdapter sortda = new SqlDataAdapter(sortStr, conn);
        SqlDataAdapter sortda1 = new SqlDataAdapter(sortStr1, conn);
        SqlDataAdapter sortda2 = new SqlDataAdapter(sortStr2, conn);

        DataTable sortdt = new DataTable();
        DataTable sortdt1 = new DataTable();
        DataTable sortdt2 = new DataTable();
        conn.Open();                                                             //打开数据库
        sortda.Fill(sortdt);                                                            //将数据填充到DataTable
        sortda1.Fill(sortdt1);
        sortda2.Fill(sortdt2);
        conn.Close();

                    //获得Relation Experience marriage 三个表中对应各个ID的sort,然后循环控制，生成update语句，用于Relation Experience marriage三个表的更新                            









        
         if (!mypicture.HasFiles)
         {
                  
             string updateStr = "UPDATE si SET Name='" + name + "',OnceName='" + lname + "',Marriage='" + hunyin + "',Nationality='" + minzu + "',Political='" + zhengzhi + "',Body='" + jiankang + "',Sex='" + xingbie + "',Birthday='" + shenri + "',E_Mail='" + youxiang + "',MobileNo手机号码='" + shouji + "', JTDH='" + jiazhang + "',SYD='" + chushengdi + "',CardID='" + shenfengzheng + "',JTZZ='" + huji + "',JZBM='" + youzheng + "',JoinTssue='" + rudang + "',Reward='" + jiangli + "',punishment='" + chengfa + "',BigEvents='" + wenti + "',OtherProblem='" + zuzhi + "',Remember='" + jishi + "',Bank='" + yinhang + "',Bankcard='" + kahao + "' WHERE ID='" + id + "'";            //更新si表

                /*
                 社会关系表 Relation
                 社会关系表（f） 姓名(a) 与本人关系(b) 政治面貌(c) 工作单位d 职务(e) 联系电话(f) 数字表示行数

                */
              string updateStr1 = "UPDATE Relation SET Name='" + fa1 + "',Relation='" + fb1 + "',PoliticalFace='" + fc1 + "',Company='" + fd1 + "',Work='" + fe1 + "',phone='" + ff1 + "' WHERE sort='" + sortdt.Rows[0]["sort"].ToString() + "'; UPDATE Relation SET Name='" + fa2 + "',Relation='" + fb2 + "',PoliticalFace='" + fc2 + "',Company='" + fd2 + "',Work='" + fe2 + "',phone='" + ff2 + "' WHERE sort='" + sortdt.Rows[1]["sort"].ToString() + "'; UPDATE Relation SET Name='" + fa3 + "',Relation='" + fb3 + "',PoliticalFace='" + fc3 + "',Company='" + fd3 + "',Work='" + fe3 + "',phone='" + ff3 + "' WHERE sort='" + sortdt.Rows[2]["sort"].ToString() + "';UPDATE Relation SET Name='" + fa4 + "',Relation='" + fb4 + "',PoliticalFace='" + fc4 + "',Company='" + fd4 + "',Work='" + fe4 + "',phone='" + ff4 + "' WHERE sort='" + sortdt.Rows[3]["sort"].ToString() + "'; UPDATE Relation SET Name='" + fa5 + "',Relation='" + fb5 + "',PoliticalFace='" + fc5 + "',Company='" + fd5 + "',Work='" + fe5 + "',phone='" + ff5 + "' WHERE sort='" + sortdt.Rows[4]["sort"].ToString() + "'; UPDATE Relation SET Name='" + fa6 + "',Relation='" + fb6 + "',PoliticalFace='" + fc6 + "',Company='" + fd6 + "',Work='" + fe6 + "',phone='" + ff6 + "' WHERE sort='" + sortdt.Rows[5]["sort"].ToString() + "'";

                /*
                家庭关系表 marriage
                社会关系表（h） 姓名(a) 与本人关系(b) 政治面貌(c) 工作单位d 职务(e) 联系电话(f) 数字表示行数
                */
                     string updateStr2 = "UPDATE marriage SET Name='" + ha1 + "',Relation='" + hb1 + "',PoliticalFace='" + hc1 + "',Company='" + hd1 + "',Work='" + he1 + "',phone='" + hf1 + "' WHERE sort='" + sortdt1.Rows[0]["sort"].ToString() + "';UPDATE marriage SET Name='" + ha2 + "',Relation='" + hb2 + "',PoliticalFace='" + hc2 + "',Company='" + hd2 + "',Work='" + he2 + "',phone='" + hf2 + "' WHERE sort='" + sortdt1.Rows[1]["sort"].ToString() + "';UPDATE marriage SET Name='" + ha3 + "',Relation='" + hb3 + "',PoliticalFace='" + hc3 + "',Company='" + hd3 + "',Work='" + he3 + "',phone='" + hf3 + "' WHERE sort='" + sortdt1.Rows[2]["sort"].ToString() + "';UPDATE marriage SET Name='" + ha4 + "',Relation='" + hb4 + "',PoliticalFace='" + hc4 + "',Company='" + hd4 + "',Work='" + he4 + "',phone='" + hf4 + "' WHERE sort='" + sortdt1.Rows[3]["sort"].ToString() + "';UPDATE marriage SET Name='" + ha5 + "',Relation='" + hb5 + "',PoliticalFace='" + hc5 + "',Company='" + hd5 + "',Work='" + he5 + "',phone='" + hf5 + "' WHERE sort='" + sortdt1.Rows[4]["sort"].ToString() + "';UPDATE marriage SET Name='" + ha6 + "',Relation='" + hb6 + "',PoliticalFace='" + hc6 + "',Company='" + hd6 + "',Work='" + he6 + "',phone='" + hf6 + "' WHERE sort='" + sortdt1.Rows[5]["sort"].ToString() + "'";

                /*
                社会经历表 Experience(s)  
                时间（a） 单位（b） 职务（c）
                 */
                       string updateStr3 = "UPDATE Experience SET time='" + sa1 + "',Attribution='" + sb1 + "',Position='" + sc1 + "' WHERE sort='" + sortdt1.Rows[0]["sort"].ToString() + "';UPDATE Experience SET time='" + sa2 + "',Attribution='" + sb2 + "',Position='" + sc2 + "' WHERE sort='" + sortdt1.Rows[1]["sort"].ToString() + "';UPDATE Experience SET time='" + sa3 + "',Attribution='" + sb3 + "',Position='" + sc3 + "' WHERE sort='" + sortdt1.Rows[2]["sort"].ToString() + "';UPDATE Experience SET time='" + sa4 + "',Attribution='" + sb4 + "',Position='" + sc4 + "' WHERE sort='" + sortdt1.Rows[3]["sort"].ToString() + "';UPDATE Experience SET time='" + sa5 + "',Attribution='" + sb5 + "',Position='" + sc5 + "' WHERE sort='" + sortdt1.Rows[4]["sort"].ToString() + "';UPDATE Experience SET time='" + sa6 + "',Attribution='" + sb6 + "',Position='" + sc6 + "' WHERE sort='" + sortdt1.Rows[5]["sort"].ToString() + "'";

                        SqlDataAdapter upda = new SqlDataAdapter(updateStr, conn);
                        SqlDataAdapter upda1 = new SqlDataAdapter(updateStr1, conn);
                        SqlDataAdapter upda2 = new SqlDataAdapter(updateStr2, conn);
                        SqlDataAdapter upda3 = new SqlDataAdapter(updateStr3, conn);
                        DataSet upds = new DataSet();
                        DataSet upds1 = new DataSet();
                        DataSet upds2 = new DataSet();
                        DataSet upds3 = new DataSet();
                        conn.Open();                                                                          //打开数据库
                        upda.Fill(upds);
                        upda1.Fill(upds1);
                        upda2.Fill(upds2);
                        upda3.Fill(upds3);
                        conn.Close();
                        Response.Write(@"<script>alert('信息上传成功！');</script>");
                        Response.AddHeader("Refresh", "0");

        }
              else if(mypicture.HasFiles)
                  {
                        string fileName = mypicture.PostedFile.FileName;                     //获得上传文件的文件名
                        int position = fileName.LastIndexOf("\\");                  //截取.的位置
                        string splitName = fileName.Substring(position + 1);       //截取后缀
                        string newPath = CheckFileName(splitName);                 //判断后缀名是否合法并赋予新的文件名
                        string savePath = Server.MapPath("picture/");            //Server.MapPath方法返回与指定虚拟路径相对应的物理路径。                             
                     // string savePath1 = Server.MapPath("C:\\web\\WebSite2\\picture\\");
                       // mypicture.PostedFile.SaveAs(savePath1 + newPath);
                        mypicture.PostedFile.SaveAs(savePath + newPath);                //FileUpload1.SaveAs方法：将上载文件的内容保存到 Web 服务器上的指定路径。后面加上文件名
                        string wpath = "picture\\" + newPath;
                       // string photoupStr = "UPDATE si SET Photo='" + wpath + "' WHERE ID='" + id + "'";
                      
                        if (mypicture.PostedFile.ContentLength > 102400)
                        {
                            Response.Write(@"<script>alert('图片不能大于100k');</script>");

                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(newPath))                        //指示指定的字符串是 null 还是 Empty 字符串。
                            {
                                string updateStr = "UPDATE si SET Name='" + name + "',OnceName='" + lname + "',Marriage='" + hunyin + "',Nationality='" + minzu + "',Political='" + zhengzhi + "',Body='" + jiankang + "',Sex='" + xingbie + "',Birthday='" + shenri + "',E_Mail='" + youxiang + "',MobileNo手机号码='" + shouji + "', JTDH='" + jiazhang + "',SYD='" + chushengdi + "',CardID='" + shenfengzheng + "',JTZZ='" + huji + "',JZBM='" + youzheng + "',JoinTssue='" + rudang + "',Reward='" + jiangli + "',punishment='" + chengfa + "',BigEvents='" + wenti + "',OtherProblem='" + zuzhi + "',Remember='" + jishi + "',Bank='" + yinhang + "',Bankcard='" + kahao + "',Photo='" + wpath + "' WHERE ID='" + id + "'";            //更新si表

                                /*
                                 社会关系表 Relation
                                 社会关系表（f） 姓名(a) 与本人关系(b) 政治面貌(c) 工作单位d 职务(e) 联系电话(f) 数字表示行数

                                */
                                string updateStr1 = "UPDATE Relation SET Name='" + fa1 + "',Relation='" + fb1 + "',PoliticalFace='" + fc1 + "',Company='" + fd1 + "',Work='" + fe1 + "',phone='" + ff1 + "' WHERE sort='" + sortdt.Rows[0]["sort"].ToString() + "'; UPDATE Relation SET Name='" + fa2 + "',Relation='" + fb2 + "',PoliticalFace='" + fc2 + "',Company='" + fd2 + "',Work='" + fe2 + "',phone='" + ff2 + "' WHERE sort='" + sortdt.Rows[1]["sort"].ToString() + "'; UPDATE Relation SET Name='" + fa3 + "',Relation='" + fb3 + "',PoliticalFace='" + fc3 + "',Company='" + fd3 + "',Work='" + fe3 + "',phone='" + ff3 + "' WHERE sort='" + sortdt.Rows[2]["sort"].ToString() + "';UPDATE Relation SET Name='" + fa4 + "',Relation='" + fb4 + "',PoliticalFace='" + fc4 + "',Company='" + fd4 + "',Work='" + fe4 + "',phone='" + ff4 + "' WHERE sort='" + sortdt.Rows[3]["sort"].ToString() + "'; UPDATE Relation SET Name='" + fa5 + "',Relation='" + fb5 + "',PoliticalFace='" + fc5 + "',Company='" + fd5 + "',Work='" + fe5 + "',phone='" + ff5 + "' WHERE sort='" + sortdt.Rows[4]["sort"].ToString() + "'; UPDATE Relation SET Name='" + fa6 + "',Relation='" + fb6 + "',PoliticalFace='" + fc6 + "',Company='" + fd6 + "',Work='" + fe6 + "',phone='" + ff6 + "' WHERE sort='" + sortdt.Rows[5]["sort"].ToString() + "'";

                                /*
                                家庭关系表 marriage
                                社会关系表（h） 姓名(a) 与本人关系(b) 政治面貌(c) 工作单位d 职务(e) 联系电话(f) 数字表示行数
                                */
                                string updateStr2 = "UPDATE marriage SET Name='" + ha1 + "',Relation='" + hb1 + "',PoliticalFace='" + hc1 + "',Company='" + hd1 + "',Work='" + he1 + "',phone='" + hf1 + "' WHERE sort='" + sortdt1.Rows[0]["sort"].ToString() + "';UPDATE marriage SET Name='" + ha2 + "',Relation='" + hb2 + "',PoliticalFace='" + hc2 + "',Company='" + hd2 + "',Work='" + he2 + "',phone='" + hf2 + "' WHERE sort='" + sortdt1.Rows[1]["sort"].ToString() + "';UPDATE marriage SET Name='" + ha3 + "',Relation='" + hb3 + "',PoliticalFace='" + hc3 + "',Company='" + hd3 + "',Work='" + he3 + "',phone='" + hf3 + "' WHERE sort='" + sortdt1.Rows[2]["sort"].ToString() + "';UPDATE marriage SET Name='" + ha4 + "',Relation='" + hb4 + "',PoliticalFace='" + hc4 + "',Company='" + hd4 + "',Work='" + he4 + "',phone='" + hf4 + "' WHERE sort='" + sortdt1.Rows[3]["sort"].ToString() + "';UPDATE marriage SET Name='" + ha5 + "',Relation='" + hb5 + "',PoliticalFace='" + hc5 + "',Company='" + hd5 + "',Work='" + he5 + "',phone='" + hf5 + "' WHERE sort='" + sortdt1.Rows[4]["sort"].ToString() + "';UPDATE marriage SET Name='" + ha6 + "',Relation='" + hb6 + "',PoliticalFace='" + hc6 + "',Company='" + hd6 + "',Work='" + he6 + "',phone='" + hf6 + "' WHERE sort='" + sortdt1.Rows[5]["sort"].ToString() + "'";

                                /*
                                社会经历表 Experience(s)  
                                时间（a） 单位（b） 职务（c）
                                 */
                                string updateStr3 = "UPDATE Experience SET time='" + sa1 + "',Attribution='" + sb1 + "',Position='" + sc1 + "' WHERE sort='" + sortdt1.Rows[0]["sort"].ToString() + "';UPDATE Experience SET time='" + sa2 + "',Attribution='" + sb2 + "',Position='" + sc2 + "' WHERE sort='" + sortdt1.Rows[1]["sort"].ToString() + "';UPDATE Experience SET time='" + sa3 + "',Attribution='" + sb3 + "',Position='" + sc3 + "' WHERE sort='" + sortdt1.Rows[2]["sort"].ToString() + "';UPDATE Experience SET time='" + sa4 + "',Attribution='" + sb4 + "',Position='" + sc4 + "' WHERE sort='" + sortdt1.Rows[3]["sort"].ToString() + "';UPDATE Experience SET time='" + sa5 + "',Attribution='" + sb5 + "',Position='" + sc5 + "' WHERE sort='" + sortdt1.Rows[4]["sort"].ToString() + "';UPDATE Experience SET time='" + sa6 + "',Attribution='" + sb6 + "',Position='" + sc6 + "' WHERE sort='" + sortdt1.Rows[5]["sort"].ToString() + "'";

                                SqlDataAdapter upda = new SqlDataAdapter(updateStr, conn);
                                SqlDataAdapter upda1 = new SqlDataAdapter(updateStr1, conn);
                                SqlDataAdapter upda2 = new SqlDataAdapter(updateStr2, conn);
                                SqlDataAdapter upda3 = new SqlDataAdapter(updateStr3, conn);
                                DataSet upds = new DataSet();
                                DataSet upds1 = new DataSet();
                                DataSet upds2 = new DataSet();
                                DataSet upds3 = new DataSet();
                                conn.Open();                                                                          //打开数据库
                                upda.Fill(upds);
                                upda1.Fill(upds1);
                                upda2.Fill(upds2);
                                upda3.Fill(upds3);
                                conn.Close();
                                Response.Write(@"<script>alert('信息上传成功！');</script>");
                                Response.AddHeader("Refresh", "0");
                }

                        
                            
            }

                

            }

                    


        

      }     
     
}