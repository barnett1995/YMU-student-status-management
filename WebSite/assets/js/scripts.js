
jQuery(document).ready(function() {

    /*
        Background slideshow
    */
    $.backstretch([
      "assets/img/backgrounds/1.jpg"
    , "assets/img/backgrounds/2.jpg"
    , "assets/img/backgrounds/3.jpg"
    ], {duration: 3000, fade: 750});

    /*
        Tooltips
    */
    $('.links a.home').tooltip();
    $('.links a.blog').tooltip();

    /*
        Form validation
    */
    $('.register form').submit(function(){
        
		
		
		
		
		
		$(this).find("label[for='mypicture']").html('标准正规照');//照片部分搞定
		$(this).find("label[for='firstname']").html('你的名字');//名字搞定
        $(this).find("label[for='lastname']").html('你的曾用名');//曾用名搞定
        //$(this).find("label[for='school']").html('所在院系');//所在院系挂掉了需要修复(此行代码有重大问题)
		$(this).find("label[for='nationality']").html('所属民族');//民族搞定
        $(this).find("label[for='group']").html('政治面貌');//政治面貌搞定
        $(this).find("label[for='body']").html('健康状况');//健康状况搞定
        $(this).find("label[for='sex']").html('你的性别');//你的性别搞定
        $(this).find("label[for='date1']").html('你的出生年月');//出生年月搞定
        $(this).find("label[for='email']").html('你的电子邮件');//电子邮件搞定
        $(this).find("label[for='phone']").html('你的联系方式');//联系方式搞定
        $(this).find("label[for='phone2']").html('家庭联系方式');//家庭联系搞定
        $(this).find("label[for='site']").html('生源地');//生源地搞定
        $(this).find("label[for='idcard']").html('你的身份证号码');//身份证搞定
        $(this).find("label[for='home']").html('你的家庭住址');//家庭住址搞定
        $(this).find("label[for='postalcode']").html('邮政编码');//邮政编码搞定
        $(this).find("label[for='joingroup']").html('入党过程');//入党过程搞定
        $(this).find("label[for='award']").html('奖励明细');//奖励明细搞定
        $(this).find("label[for='punishment']").html('惩罚明细');//惩罚明细搞定
        $(this).find("label[for='education']").html('学历经历');//学历经历搞定
        $(this).find("label[for='anything']").html('其他问题说明');//其他问题搞定
        $(this).find("label[for='everything']").html('个人介绍与事件记录');//个人介绍搞定
        ////
		var mypicture = $(this).find('input#mypicture').val();//照片部分搞定
		var firstname = $(this).find('input#firstname').val();//名字搞定
        var lastname = $(this).find('input#lastname').val();//曾用名搞定
		var school = $(this).find('select#province').val();//所在院系挂掉了需要修复（此行代码有重大问题）
        var nationality = $(this).find('input#nationality').val();//民族搞定
        var group = $(this).find('input#group').val();//政治面貌搞定
		var body = $(this).find('input#body').val();//健康状况搞定
		var sex = $(this).find('select#sex').val();//你的性别搞定
        var date1 = $(this).find('input#date1').val();//出生年月搞定
		var email = $(this).find('input#email').val();//电子邮件搞定
		var phone = $(this).find('input#phone').val();//联系方式搞定
		var phone2 = $(this).find('input#phone2').val();//家庭联系搞定
		var site = $(this).find('input#site').val();//生源地搞定
		var idcard = $(this).find('input#idcard').val();//身份证搞定
		var home = $(this).find('input#home').val();//家庭住址搞定
		var postalcode = $(this).find('input#postalcode').val();//邮政编码搞定
		var joingroup = $(this).find('textarea#joingroup').val();//入党过程搞定
		var award = $(this).find('textarea#award').val();//奖励明细搞定
		var punishment = $(this).find('textarea#punishment').val();//惩罚明细搞定
		var education = $(this).find('textarea#education').val();//学历经历搞定
		var anything = $(this).find('textarea#anything').val();//其他问题搞定
		var everything = $(this).find('textarea#everything').val();//个人介绍搞定		
		
		
        if(mypicture == '') {
            $(this).find("label[for='mypicture']").append("<span style='display:none' class='red'> - 请选择一张本人正规照，大小不超过2M</span>");//照片部分搞定
            $(this).find("label[for='mypicture'] span").fadeIn('medium');
            return false;
        }
		if(firstname == '') {
            $(this).find("label[for='firstname']").append("<span style='display:none' class='red'> - 必须填写你的名字</span>");//名字搞定
            $(this).find("label[for='firstname'] span").fadeIn('medium');
            return false;
        }
        if(lastname == '') {
            $(this).find("label[for='lastname']").append("<span style='display:none' class='red'> - 必须填写你的曾用名，没有就填无</span>");//曾用名搞定
            $(this).find("label[for='lastname'] span").fadeIn('medium');
            return false;
        }
		/*if(province == '学院') {
            $(this).find("label[for='school']").append("<span style='display:none' class='red'> - 必须选择所属院系</span>");//所属院系挂掉了需要修复（本代码有重大问题谨慎研究）
            $(this).find("label[for='school'] span").fadeIn('medium');
            return false;
        }*/
		if(nationality == '') {
            $(this).find("label[for='nationality']").append("<span style='display:none' class='red'> - 必须填写你的民族</span>");//民族搞定
            $(this).find("label[for='nationality'] span").fadeIn('medium');
            return false;
        }
        if(group == '') {
            $(this).find("label[for='group']").append("<span style='display:none' class='red'> - 必须填写所属党派，没有就填群众</span>");//政治面貌搞定
            $(this).find("label[for='group'] span").fadeIn('medium');
            return false;
        }
		if(body == '') {
            $(this).find("label[for='body']").append("<span style='display:none' class='red'> - 必须填写健康状况</span>");//健康状况搞定
            $(this).find("label[for='body'] span").fadeIn('medium');
            return false;
        }
		if(sex == '请选择') {
            $(this).find("label[for='sex']").append("<span style='display:none' class='red'> - 必须选择性别</span>");//你的性别搞定
            $(this).find("label[for='sex'] span").fadeIn('medium');
            return false;
        }
		 if(date1 == '') {
            $(this).find("label[for='date1']").append("<span style='display:none' class='red'> - 必须填写出生年月</span>");//出生年月搞定
            $(this).find("label[for='date1'] span").fadeIn('medium');
            return false;
        }
		if(email == '') {
            $(this).find("label[for='email']").append("<span style='display:none' class='red'> - 必须填写电子邮件，没有就填无</span>");//电子邮件搞定
            $(this).find("label[for='email'] span").fadeIn('medium');
            return false;
        }
		if(phone == '') {
            $(this).find("label[for='phone']").append("<span style='display:none' class='red'> - 必须填写联系方式，没什么理由</span>");//联系方式搞定
            $(this).find("label[for='phone'] span").fadeIn('medium');
            return false;
        }
		if(phone2 == '') {
            $(this).find("label[for='phone2']").append("<span style='display:none' class='red'> - 必须填写联系方式，更没啥理由</span>");//家庭联系方式搞定
            $(this).find("label[for='phone2'] span").fadeIn('medium');
            return false;
        }
		if(site == '') {
            $(this).find("label[for='site']").append("<span style='display:none' class='red'> - 必须填写生源地</span>");//生源地搞定
            $(this).find("label[for='site'] span").fadeIn('medium');
            return false;
        }
		if(idcard == '') {
            $(this).find("label[for='idcard']").append("<span style='display:none' class='red'> - 必须填写身份证，不填你可能就是假人</span>");//身份证搞定
            $(this).find("label[for='idcard'] span").fadeIn('medium');
            return false;
        }
		if(home == '') {
            $(this).find("label[for='home']").append("<span style='display:none' class='red'> - 必须填写家庭住址，不填你可能就是偷渡者</span>");//家庭住址搞定
            $(this).find("label[for='home'] span").fadeIn('medium');
            return false;
        }
		if(postalcode == '') {
            $(this).find("label[for='postalcode']").append("<span style='display:none' class='red'> - 必须填写邮政编码，好歹是大学生邮政编码都不知道？</span>");//邮政编码搞定
            $(this).find("label[for='postalcode'] span").fadeIn('medium');
            return false;
        }
		if(joingroup == '') {
            $(this).find("label[for='joingroup']").append("<span style='display:none' class='red'> - 没有入党就填写未入党，3个字都不想写吗！又累不死你！</span>");//入党过程搞定
            $(this).find("label[for='joingroup'] span").fadeIn('medium');
            return false;
        }
		if(award == '') {
            $(this).find("label[for='award']").append("<span style='display:none' class='red'> - 你这十几年真没有奖励？好佩服你居然上了民大，那就填写无奖励</span>");//奖励明细搞定
            $(this).find("label[for='award'] span").fadeIn('medium');
            return false;
        }
		if(punishment == '') {
            $(this).find("label[for='punishment']").append("<span style='display:none' class='red'> - 我知道你没被惩罚过很骄傲，但是给至于骄傲到连字都不想写？好好睁大眼睛读提示要你写什么！</span>");//惩罚明细搞定
            $(this).find("label[for='punishment'] span").fadeIn('medium');
            return false;
        }
		if(education == '') {
            $(this).find("label[for='education']").append("<span style='display:none' class='red'> - 不填的是找死或者傻逼</span>");//学历经历搞定
            $(this).find("label[for='education'] span").fadeIn('medium');
            return false;
        }
		if(anything == '') {
            $(this).find("label[for='anything']").append("<span style='display:none' class='red'> - 最后了，麻烦你补上点字，给是怕自己被累死？</span>");//其他问题搞定
            $(this).find("label[for='anything'] span").fadeIn('medium');
            return false;
        }
		if(everything == '') {
            $(this).find("label[for='everything']").append("<span style='display:none' class='red'> - 这个你不写？找死是吧？活腻了？不想活可以去跳楼何必来这弄脏一块地方？不要学籍你来民大干什么？吃屎？</span>");//个人介绍搞定
            $(this).find("label[for='everything'] span").fadeIn('medium');
            return false;
        }

		
		
    });


});


