<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Stuinfo.aspx.cs" Inherits="t" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>云南民族大学学籍管理与登记信息</title>
    <script type="text/javascript">
    function imgPreview(fileDom){
        if (window.FileReader) {
            var reader = new FileReader();
        } else {
            alert("您的设备不支持图片预览功能，如需该功能请升级您的设备！");
        }
        var file = fileDom.files[0];
        var imageType = /^image\//;
        if (!imageType.test(file.type)) {
            alert("请选择图片！");
            return;
        }
        reader.onload = function(e) {
            var img = document.getElementById("preview");
            img.src = e.target.result;
        };
        reader.readAsDataURL(file);
    }
    </script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel='stylesheet' href='http://fonts.googleapis.com/css?family=PT+Sans:400,700'>
    <link rel='stylesheet' href='http://fonts.googleapis.com/css?family=Oleo+Script:400,700'>
    <link rel="stylesheet" type="text/css" href="/assets/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="/assets/css/style.css">
</head>
<body>
<div class="header">
  <div class="container">
    <div class="row">
      <div class="logo span4">
        <h2><a href="http://202.203.158.158/sso/login">云南民族大学<span class="red">学籍信息录入页</span></a></h2>
      </div>
      <div class="links span8"> <a class="home" href="http://www.ynni.edu.cn" rel="tooltip" data-placement="bottom" data-original-title="学校官网"></a> </div>
    </div>
  </div>
</div>
<div class="register-container container">
<div class="row">
<div class="iphone span5"> <img src="assets/img/iphone.png" alt=""> </div>
<div class="register span6">
<form id="form1" runat="server">
<h2>填写你的 <span class="red"><strong>学籍信息</strong></span></h2>
<label for="mypicture">标准正规照</label>
<img id="preview" />
<br/>
<input type="file" id="mypicture" name="mypicture" onchange="imgPreview(this)" runat="server"  required />
<label for="firstname">你的名字</label>
<input type="text" id="firstname" name="firstname" placeholder="你的身份证姓名..." runat="server"  required>
<label for="lastname">你的曾用名</label>
<input type="text" id="lastname" name="lastname" placeholder="你的曾用名..." required runat="server"  >

   </body>
        <label for="nationality">所属民族</label>
<input type="text" id="nationality" name="nationality" placeholder="你的民族..." required runat="server">
<label for="group">政治面貌</label>
<input type="text" id="group" name="group" placeholder="共产党员、团员、各民主党人士..." required runat="server">
<label for="body">健康状况</label>
<input type="text" id="body" name="body" placeholder="健康、亚健康、是否残疾、..." required runat="server">
<label for="body">婚姻状况</label>
<input tyoe="text" id="marriage" name="marr" placeholder="已婚未婚" required runat="server">

<label for="sex">你的性别</label>
<select id="sex" name="sex" runat="server">
  <option>请选择</option>
  <option value = "男">男</option>
  <option value = "女">女</option>
</select>
<label for="date1">你的出生年月</label>
<input type="text" placeholder="格式为2017/1/1" id="date1" name="date1" required runat="server" pattern="^\d{4}/\d{1,2}/\d{1,2}$" title="请填写正确生日格式（例：2017/1/1）"  >

<label for="email">你的电子邮件</label>
<input type="text" id="email" name="email" placeholder="电子邮件地址、QQ邮箱等等..." required runat="server" pattern="^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
  title="请填写正确邮箱格式"> 
<label for="phone">你的联系方式</label>
<input type="text" id="phone" name="phone" placeholder="与你本人可接通的有效联系方式..." required runat="server" pattern="^\d{11}$" title="填写正确手机号">
<label for="phone2">家庭联系方式</label>
<input type="text" id="phone2" name="phone2" placeholder="家中任意监护人的有效联系方式..." required runat="server"  pattern="^\d{11}$" title="填写正确手机号" >
<label for="sex">选择银行</label>
<select id="bankcard1" name="bankcard" runat="server">
  <option>请选择</option>
  <option value = "中国建设银行">中国建设银行</option>
  <option value = "中国工商银行">中国工商银行</option>
  <option value = "中国农业银行">中国农业银行</option>
  <option value = "中国银行">中国银行</option>
  <option value = "中国邮政储蓄银行">中国邮政储蓄银行</option>
  <option value = "招商银行">招商银行</option>
  <option value = "交通银行">交通银行</option>
  <option value = "浦发银行">浦发银行</option>
  <option value = "云南农村信用社">云南农村信用社</option>
  <option value = "其他">其他</option>
</select>
<label for="site">银行卡卡号</label>
<input type="text" id="bankcard" name="site" placeholder="银行卡卡号" required runat="server">
<label for="site">生源地</label>
<input type="text" id="site" name="site" placeholder="户籍所在地，出生地..." required runat="server">
<label for="idcard">你的身份证号码</label>
<input type="text" id="idcard" name="idcard" placeholder="输入18位身份证号码..." required runat="server" pattern="^(\d{6})(\d{4})(\d{2})(\d{2})(\d{3})([0-9]|X)$" title="请填写正确身份证格式" >
<label for="home">你的家庭住址</label>
<input type="text" id="home" name="home" placeholder="你的户籍所在地居住地..." required runat="server">
<label for="postalcode">邮政编码</label>
<input type="text" id="postalcode" name="postalcode" placeholder="输入6位居住地邮政编码..." required runat="server" pattern="^\d{6}$" title="填写正确邮政编码">
<label for="joingroup">入党过程</label>
<textarea id="joingroup" name="joingroup" style="width:445px;height:100px;" placeholder="何时何地经何人介绍加入中国共产党、共青团，未入党就填写未入党" required runat="server"></textarea>
<label for="award">奖励明细</label>
<textarea id="award" name="award" style="width:445px;height:300px;" placeholder="何时何地因何种原因受过何种奖励，没有就写无" required runat="server"></textarea>
<label for="punishment">惩罚明细</label>
<textarea id="punishment" name="punishment" style="width:445px;height:100px;" placeholder="何时何地因何种原因受过何种惩罚，没有就写（无），我想应该是大家都没有惩罚记录，什么？你还有惩罚记录？666，组织对你刮目相看" required runat="server"></textarea>
<label for="education">学历经历</label>

<label for="education">社会经历表(至少填写1个)</label>
    <p>
    <textarea name="sh11" id="sh11" style="width:130px;height:20px;" placeholder="时间" required runat="server"></textarea>
    <textarea name="sh12" id="sh12" style="width:200px;height:20px;" placeholder="学校（单位）" required runat="server"></textarea>
    <textarea name="sh13" id="sh13" style="width:70px;height:20px;" placeholder="职务" required runat="server"></textarea>
    </p>
    <p>
    <textarea name="sh21" id="sh21" style="width:130px;height:20px;" placeholder="时间" required runat="server"></textarea>
    <textarea name="sh22" id="sh22" style="width:200px;height:20px;" placeholder="学校（单位）" required runat="server"></textarea>
    <textarea name="sh23" id="sh23" style="width:70px;height:20px;" placeholder="职务" required runat="server"></textarea>
    </p>
    <p>
    <textarea name="sh31" id="sh31" style="width:130px;height:20px;" placeholder="时间" required runat="server"></textarea>
    <textarea name="sh32" id="sh32" style="width:200px;height:20px;" placeholder="学校（单位）" required runat="server"></textarea>
    <textarea name="sh33" id="sh33" style="width:70px;height:20px;" placeholder="职务" required runat="server"></textarea>
    </p>
    <p>
    <textarea name="sh41" id="sh41" style="width:130px;height:20px;" placeholder="时间" required runat="server"></textarea>
    <textarea name="sh42" id="sh42" style="width:200px;height:20px;" placeholder="学校（单位）" required runat="server"></textarea>
    <textarea name="sh43" id="sh43" style="width:70px;height:20px;" placeholder="职务" required runat="server"></textarea>
    </p>
    <p>
    <textarea name="sh51" id="sh51" style="width:130px;height:20px;" placeholder="时间" required runat="server"></textarea>
    <textarea name="sh52" id="sh52" style="width:200px;height:20px;" placeholder="学校（单位）" required runat="server"></textarea>
    <textarea name="sh53" id="sh53" style="width:70px;height:20px;" placeholder="职务" required runat="server"></textarea>
    </p>
    <p>
    <textarea name="sh61" id="sh61" style="width:130px;height:20px;" placeholder="时间" required runat="server"></textarea>
    <textarea name="sh62" id="sh62" style="width:200px;height:20px;" placeholder="学校（单位）" required runat="server"></textarea>
    <textarea name="sh63" id="sh63" style="width:70px;height:20px;" placeholder="职务" required runat="server"></textarea>
    </p>
    
<label for="family">家庭成员关系(至少填写1个)</label>
<textarea name="family11" id="family11" style="width:60px;height:20px;" placeholder="姓名" required runat="server"></textarea>
<textarea name="family12" id="family12" style="width:80px;height:20px;" placeholder="与本人关系" required runat="server"></textarea>
<textarea name="family13" id="family13" style="width:70px;height:20px;" placeholder="政治面貌" required runat="server"></textarea>
<textarea name="family14" id="family14" style="width:180px;height:20px;" placeholder="工作单位、务农、待业" required runat="server"></textarea>
<textarea name="family15" id="family15" style="width:280px;height:20px;" placeholder="职务、去向、是否在人世" required runat="server"></textarea>
<textarea name="family16" id="family16" style="width:145px;height:20px;" placeholder="联系电话" required runat="server"></textarea>
<textarea name="family21" id="family21" style="width:60px;height:20px;" placeholder="姓名"  runat="server"></textarea>
<textarea name="family22" id="family22" style="width:80px;height:20px;" placeholder="与本人关系" runat="server"></textarea>
<textarea name="family23" id="family23" style="width:70px;height:20px;" placeholder="政治面貌"  runat="server"></textarea>
<textarea name="family24" id="family24" style="width:180px;height:20px;" placeholder="工作单位、务农、待业"  runat="server"></textarea>
<textarea name="family25" id="family25" style="width:280px;height:20px;" placeholder="职务、去向、是否在人世"  runat="server"></textarea>
<textarea name="family26" id="family26" style="width:145px;height:20px;" placeholder="联系电话" runat="server"></textarea>
<textarea name="family31" id="family31" style="width:60px;height:20px;" placeholder="姓名" runat="server"></textarea>
<textarea name="family32" id="family32" style="width:80px;height:20px;" placeholder="与本人关系" runat="server"></textarea>
<textarea name="family33" id="family33" style="width:70px;height:20px;" placeholder="政治面貌" runat="server"></textarea>
<textarea name="family34" id="family34" style="width:180px;height:20px;" placeholder="工作单位、务农、待业" runat="server"></textarea>
<textarea name="family35" id="family35" style="width:280px;height:20px;" placeholder="职务、去向、是否在人世" runat="server"></textarea>
<textarea name="family36" id="family36" style="width:145px;height:20px;" placeholder="联系电话" runat="server"></textarea>
<textarea name="family41" id="family41" style="width:60px;height:20px;" placeholder="姓名" runat="server"></textarea>
<textarea name="family42" id="family42" style="width:80px;height:20px;" placeholder="与本人关系" runat="server"></textarea>
<textarea name="family43" id="family43" style="width:70px;height:20px;" placeholder="政治面貌" runat="server"></textarea>
<textarea name="family44" id="family44" style="width:180px;height:20px;" placeholder="工作单位、务农、待业" runat="server"></textarea>
<textarea name="family45" id="family45" style="width:280px;height:20px;" placeholder="职务、去向、是否在人世" runat="server"></textarea>
<textarea name="family46" id="family46" style="width:145px;height:20px;" placeholder="联系电话" runat="server"></textarea>
<textarea name="family51" id="family51" style="width:60px;height:20px;" placeholder="姓名" runat="server"></textarea>
<textarea name="family52" id="family52" style="width:80px;height:20px;" placeholder="与本人关系" runat="server"></textarea>
<textarea name="family53" id="family53" style="width:70px;height:20px;" placeholder="政治面貌" runat="server"></textarea>
<textarea name="family54" id="family54" style="width:180px;height:20px;" placeholder="工作单位、务农、待业" runat="server"></textarea>
<textarea name="family55" id="family55" style="width:280px;height:20px;" placeholder="职务、去向、是否在人世" runat="server"></textarea>
<textarea name="family56" id="family56" style="width:145px;height:20px;" placeholder="联系电话" runat="server"></textarea>
<textarea name="family61" id="family61" style="width:60px;height:20px;" placeholder="姓名" runat="server"></textarea>
<textarea name="family62" id="family62" style="width:80px;height:20px;" placeholder="与本人关系" runat="server"></textarea>
<textarea name="family63" id="family63" style="width:70px;height:20px;" placeholder="政治面貌" runat="server"></textarea>
<textarea name="family64" id="family64" style="width:180px;height:20px;" placeholder="工作单位、务农、待业" runat="server"></textarea>
<textarea name="family65" id="family65" style="width:280px;height:20px;" placeholder="职务、去向、是否在人世" runat="server"></textarea>
<textarea name="family66" id="family66" style="width:145px;height:20px;" placeholder="联系电话" runat="server"></textarea>

<label for="friend">社会成员关系(至少填写1个)</label>
<textarea name="friend11" id="friend11" style="width:60px;height:20px;" placeholder="姓名" required runat="server"></textarea>
<textarea name="friend12" id="friend12" style="width:80px;height:20px;" placeholder="与本人关系" required runat="server"></textarea>
<textarea name="friend13" id="friend13" style="width:70px;height:20px;" placeholder="政治面貌" required runat="server"></textarea>
<textarea name="friend14" id="friend14" style="width:180px;height:20px;" placeholder="工作单位" required runat="server"></textarea>
<textarea name="friend15" id="friend15" style="width:280px;height:20px;" placeholder="职务" required runat="server"></textarea>
<textarea name="friend16" id="friend16" style="width:145px;height:20px;" placeholder="联系电话" required runat="server"></textarea>
<textarea name="friend21" id="friend21" style="width:60px;height:20px;" placeholder="姓名"  runat="server"></textarea>
<textarea name="friend22" id="friend22" style="width:80px;height:20px;" placeholder="与本人关系"  runat="server"></textarea>
<textarea name="friend23" id="friend23" style="width:70px;height:20px;" placeholder="政治面貌"  runat="server"></textarea>
<textarea name="friend24" id="friend24" style="width:180px;height:20px;" placeholder="工作单位"  runat="server"></textarea>
<textarea name="friend25" id="friend25" style="width:280px;height:20px;" placeholder="职务"  runat="server"></textarea>
<textarea name="friend26" id="friend26" style="width:145px;height:20px;" placeholder="联系电话" runat="server"></textarea>
<textarea name="friend31" id="friend31" style="width:60px;height:20px;" placeholder="姓名"  runat="server"></textarea>
<textarea name="friend32" id="friend32" style="width:80px;height:20px;" placeholder="与本人关系"  runat="server"></textarea>
<textarea name="friend33" id="friend33" style="width:70px;height:20px;" placeholder="政治面貌"  runat="server"></textarea>
<textarea name="friend34" id="friend34" style="width:180px;height:20px;" placeholder="工作单位、务农、待业"  runat="server"></textarea>
<textarea name="friend35" id="friend35" style="width:280px;height:20px;" placeholder="职务、去向、是否在人世"  runat="server"></textarea>
<textarea name="friend36" id="friend36" style="width:145px;height:20px;" placeholder="联系电话" runat="server"></textarea>
<textarea name="friend41" id="friend41" style="width:60px;height:20px;" placeholder="姓名"  runat="server"></textarea>
<textarea name="friend42" id="friend42" style="width:80px;height:20px;" placeholder="与本人关系"  runat="server"></textarea>
<textarea name="friend43" id="friend43" style="width:70px;height:20px;" placeholder="政治面貌"  runat="server"></textarea>
<textarea name="friend44" id="friend44" style="width:180px;height:20px;" placeholder="工作单位、务农、待业"  runat="server"></textarea>
<textarea name="friend45" id="friend45" style="width:280px;height:20px;" placeholder="职务、去向、是否在人世"  runat="server"></textarea>
<textarea name="friend46" id="friend46" style="width:145px;height:20px;" placeholder="联系电话" runat="server"></textarea>
<textarea name="friend51" id="friend51" style="width:60px;height:20px;" placeholder="姓名"  runat="server"></textarea>
<textarea name="friend52" id="friend52" style="width:80px;height:20px;" placeholder="与本人关系"  runat="server"></textarea>
<textarea name="friend53" id="friend53" style="width:70px;height:20px;" placeholder="政治面貌"  runat="server"></textarea>
<textarea name="friend54" id="friend54" style="width:180px;height:20px;" placeholder="工作单位、务农、待业"  runat="server"></textarea>
<textarea name="friend55" id="friend55" style="width:280px;height:20px;" placeholder="职务、去向、是否在人世"  runat="server"></textarea>
<textarea name="friend56" id="friend56" style="width:145px;height:20px;" placeholder="联系电话" runat="server"></textarea>
<textarea name="friend61" id="friend61" style="width:60px;height:20px;" placeholder="姓名"  runat="server"></textarea>
<textarea name="friend62" id="friend62" style="width:80px;height:20px;" placeholder="与本人关系"  runat="server"></textarea>
<textarea name="friend63" id="friend63" style="width:70px;height:20px;" placeholder="政治面貌"  runat="server"></textarea>
<textarea name="friend64" id="friend64" style="width:180px;height:20px;" placeholder="工作单位、务农、待业"  runat="server"></textarea>
<textarea name="friend65" id="friend65" style="width:280px;height:20px;" placeholder="职务、去向、是否在人世"  runat="server"></textarea>
<textarea name="friend66" id="friend66" style="width:145px;height:20px;" placeholder="联系电话" runat="server"></textarea>


<textarea name="friend99" id="wt" style="width:442px;height:80px;" placeholder="家庭成员或社会关系成员中某人有无重大问题，与本人关系如何，没有就填写无" required runat="server"></textarea>
<label for="anything">其他问题说明</label>
<textarea id="anything" name="anything" style="width:445px;height:100px;" placeholder="其他需要向组织说明的问题，没有就填写无" runat="server"></textarea>
<label for="everything">个人介绍与事件记录</label>
<textarea id="everything" name="everything" style="width:445px;height:400px;" placeholder="个人记事，阅历，介绍，不少于300字，写得多有好处，当然你敷衍了事也行，后果自负" runat="server"></textarea>
<button type="submit" runat="server" onserverclick="ButtonClick"  >提交信息</button>
</form>
   
    </div>
</div>
</div>
<div align="center">云南民族大学职业技术学院版权所有</div>

<!-- Javascript部分 -->
<script src="/assets/js/geo.js"></script>
<script src="/assets/js/jquery-1.8.2.min.js"></script>
<script src="/assets/bootstrap/js/bootstrap.min.js"></script>
<script src="/assets/js/jquery.backstretch.min.js"></script>
<script src="/assets/js/scripts.js"></script>
</body>
</html>
