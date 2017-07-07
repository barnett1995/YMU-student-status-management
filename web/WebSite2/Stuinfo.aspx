<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Stuinfo.aspx.cs" Inherits="Stuinfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="CSS/stdinfo.css" />
    <style>
			#div001{
				width: 100%;
				height: 5100px;
				background-color: white;
			}
			#div002{
				width: 850px;
				height: 5100px;
				margin: 0 auto;
				background-color: #FfFFFF;
			}
          
		
			#div005{
				width: 800px;
				height: 80px;
				margin: 0 auto;
				border: solid 1px #FFFFFF;
				position: relative;
				top:10px;
			}
			#div006{
				width: 800px;
				height: 5000px;
				margin: 0 auto;
				position: relative;
				top: 20px;
				box-shadow: 0px 0px 25px;
				border-radius: 10px;
			}
            #div007 {
                width: 600px;
				height: 700px;
		        
				position: relative;
                top:20px
				
            }
			#div008{
				width: 800px;
				height: 4200px;
				
			}
			#div009{
				width: 200px;
				height: 200px;
                
                position: relative;
				top:20px;
				
			}         
		
			#table001{
				width: 550px;
				height: 640px;
				position: relative;
				top: 25px;
				left: 25px;
			}
			#table002{
				width: 750px;
				height: 420px;
				position: relative;
				top: 50px;
				left: 25px;
			}
            #table003 {
                width: 750px;
				height: 400px;
				position: relative;
				top: 100px;
				left: 25px;
           }
            #table004{
                width: 750px;
				height: 420px;
				position: relative;
				top: 150px;
				left: 25px;
           }
            #table005{
                width: 750px;
				height: 200px;
				position: relative;
				top: 150px;
				left: 25px;
            } 
            #table006{
                width: 750px;
				height: 260px;
				position: relative;
				top: 150px;
				left: 25px;
            }
            #table007{
                width: 750px;
				height: 260px;
				position: relative;
				top: 150px;
				left: 25px;
            }
            #table008{
                 width: 750px;
				height: 260px;
				position: relative;
				top: 150px;
				left: 25px;
            }
            #table008{
                 width: 750px;
				height: 400px;
				position: relative;
				top: 150px;
				left: 25px;
            }
            #table009{
                 width: 750px;
				height: 400px;
				position: relative;
				top: 150px;
				left: 25px;
            }
            #table010{
                 width: 750px;
				height: 800px;
				position: relative;
				top: 150px;
				left: 25px;
            }

            #table002-bt {
                width:750px;
                height:50px;
                position: relative;
				top: 50px;
				left: 25px;
                text-align:center;
            }
            #table003-bt{
                 width:750px;
                height:50px;
                position: relative;
				top: 100px;
				left: 25px;
                text-align:center;
            }
            #table004-bt {
                width:750px;
                height:50px;
                position: relative;
				top: 150px;
				left: 25px;
                text-align:center;
        }    
            #table005-bt{
                width:750px;
                height:50px;
                position: relative;
				top: 150px;
				left: 25px;
                text-align:center;
            }
            #table006-bt {
            width: 750px;
            height: 50px;
            position: relative;
            top: 200px;
            left: 25px;
            text-align: center;
            }
            #table007-bt{
                width: 750px;
            height: 50px;
            position: relative;
            top: 200px;
            left: 25px;
            text-align: center;
            }
            #table008-bt{
                 width: 750px;
            height: 50px;
            position: relative;
            top: 200px;
            left: 25px;
            text-align: center;
            }
            #table009-bt{
            width: 750px;
            height: 50px;
            position: relative;
            top: 200px;
            left: 25px;
            text-align: center;
            }
            #table010-bt{
            width: 750px;
            height: 50px;
            position: relative;
            top: 200px;
            left: 25px;
            text-align: center;
            }
             
          		
		    .table1-1 {

                width: 24%;
                text-align: left;
            }
            .table1-2{
                text-align: left;
            }
            .table2-1{
                width:200px;
                height:60px;
            }
            .table3-1{
                width: 12%;
                height:60px;
                text-align:center;
            }
            .table3-2{
                 width: 12%;
                 text-align:center;
            }
            .table3-3{
                 width: 12%;
                 text-align:center;
            }
            .table3-4{
                 width: 30%;
                 text-align:center;
            }
            .table3-5{
                 width: 12%;
                 text-align:center;
            }
            .table3-6 {
                text-align: center;
            }
     
		
		</style>
</head>
<body>
    <form id="form1" runat="server">
		<div id="div001">
			<div id="div002">
				<div id="div006" style="float:left;">
                    
                    <div id="div007" style="float:left;">                     
					    <table id="table001" border="1" cellspacing="0"  runat="server">
					        <tr>
					           <td class="table1-1">姓名:</td>
                               <td class="table1-2" id="name" runat="server"></td>
					 
						    </tr>
                            <tr>
					           <td class="table1-1">曾用名:</td>
                               <td class="table1-2" id="lastnaem" runat="server"></td>
					 
						    </tr>
                             <tr>
					           <td class="table1-1">性别:</td>
                               <td class="table1-2" id="sex" runat="server"></td>
					 
						    </tr>
                            <tr>
					           <td class="table1-1">民族:</td>
                               <td class="table1-2" id="minzu" runat="server"></td>
					 
						    </tr>
                            <tr>
					           <td class="table1-1">政治面貌:</td>
                               <td class="table1-2" id="zhengzhi" runat="server"></td>
					 
						    </tr>
                             <tr>
					           <td class="table1-1">健康状况:</td>
                               <td class="table1-2" id="jiankang" runat="server"></td>
					 
						    </tr>
                             <tr>
					           <td class="table1-1">出生日期:</td>
                               <td class="table1-2" id="shenri" runat="server"></td>
					 
						    </tr>
                             <tr>
					           <td class="table1-1">联系电话:</td>
                               <td class="table1-2" id="phone" runat="server"></td>
					 
						    </tr>
                             <tr>
					           <td class="table1-1">电子邮箱:</td>
                               <td class="table1-2" id="email" runat="server"></td>
					 
						    </tr>
                             <tr>
					           <td class="table1-1">家庭联系电话:</td>
                               <td class="table1-2" id="jtphone" runat="server"></td>					 
						    </tr>
                             <tr>
					           <td class="table1-1">银行卡号:</td>
                               <td class="table1-2" id="bankcard" runat="server"></td>					 
						    </tr>
                              <tr>
					           <td class="table1-1">银行卡所属银行:</td>
                               <td class="table1-2" id="bank" runat="server"></td>					 
						    </tr>
                            <tr>
					           <td class="table1-1">身份证号:</td>
                               <td class="table1-2" id="idcard" runat="server"></td>					 
						    </tr>
                            <tr>
					           <td class="table1-1">生源地:</td>
                               <td class="table1-2" id="syd" runat="server"></td>					 
						    </tr>
                            <tr>
					           <td class="table1-1">家庭住址:</td>
                               <td class="table1-2" id="jtzz" runat="server"></td>					 
						    </tr>
                            <tr>
					           <td class="table1-1">邮政编码:</td>
                               <td class="table1-2" id="yzbm" runat="server"></td>					 
						    </tr>
				        
					    
					    </table>                             
                     
                    
                    </div>
                    <div id="div009" style="float:left;">
                        <asp:Image ID="Image1" runat="server" />
                    </div>
                        <div id="div008">
                        <table id="table002-bt" border="1" cellspacing="0" >
                            <tr>
                                <td>社会经历表</td>
                             </tr>
                        </table>
					    <table id="table002" border="1" cellspacing="0" >
					   
                            <tr>
                                <td class="table2-1">时间</td>
                                <td>学校/单位</td>
                                <td>职务</td>
                            </tr>
                            <tr>
                                <td class="table2-1"></td>
                                <td></td>
                                <td></td>
                            </tr>
                             <tr>
                                <td class="table2-1"></td>
                                <td></td>
                                <td></td>
                            </tr>
                             <tr>
                                <td class="table2-1"></td>
                                <td></td>
                                <td></td>
                            </tr>
                             <tr>
                                <td class="table2-1"></td>
                                <td></td>
                                <td></td>
                            </tr>
                             <tr>
                                <td class="table2-1"></td>
                                <td></td>
                                <td></td>
                            </tr>
                             <tr>
                                <td class="table2-1"></td>
                                <td></td>
                                <td></td>
                            </tr>
                       
					    </table>
                        <table id="table003-bt" border="1" cellspacing="0">
                            <tr>
                                <td>家庭关系表</td>
                             </tr>
                        </table>
                        <table id="table003" border="1" cellspacing="0">
                            <tr>
                                <td class="table3-1">姓名</td>
                                <td class="table3-2">与本人关系</td>
                                <td class="table3-3">政治面貌</td>
                                <td class="table3-4">工作单位</td>
                                <td class="table3-5">职务</td>
                                <td class="table3-6">联系电话</td>
                            </tr>
                             <tr>
                                <td class="table3-1"></td>
                                <td class="table3-2"></td>
                                <td class="table3-3"></td>
                                <td class="table3-4"></td>
                                <td class="table3-5"></td>
                                <td class="table3-6"></td>
                            </tr>
                             <tr>
                                <td class="table3-1"></td>
                                <td class="table3-2"></td>
                                <td class="table3-3"></td>
                                <td class="table3-4"></td>
                                <td class="table3-5"></td>
                                <td class="table3-6"></td>
                            </tr>
                             <tr>
                                <td class="table3-1"></td>
                                <td class="table3-2"></td>
                                <td class="table3-3"></td>
                                <td class="table3-4"></td>
                                <td class="table3-5"></td>
                                <td class="table3-6"></td>
                            </tr>
                             <tr>
                                <td class="table3-1"></td>
                                <td class="table3-2"></td>
                                <td class="table3-3"></td>
                                <td class="table3-4"></td>
                                <td class="table3-5"></td>
                                <td class="table3-6"></td>
                            </tr>
                             <tr>
                                <td class="table3-1"></td>
                                <td class="table3-2"></td>
                                <td class="table3-3"></td>
                                <td class="table3-4"></td>
                                <td class="table3-5"></td>
                                <td class="table3-6"></td>
                            </tr>
                             <tr>
                                <td class="table3-1"></td>
                                <td class="table3-2"></td>
                                <td class="table3-3"></td>
                                <td class="table3-4"></td>
                                <td class="table3-5"></td>
                                <td class="table3-6"></td>
                            </tr>
                        </table>
                        <table id="table004-bt" border="1" cellspacing="0" >
                            <tr>
                                <td>社会关系表</td>
                             </tr>
                        </table>
                        <table id="table004" border="1" cellspacing="0">
                             <tr>
                                <td class="table3-1">姓名</td>
                                <td class="table3-2">与本人关系</td>
                                <td class="table3-3">政治面貌</td>
                                <td class="table3-4">工作单位</td>
                                <td class="table3-5">职务</td>
                                <td class="table3-6">联系电话</td>
                            </tr>
                            <tr>
                                <td class="table3-1"></td>
                                <td class="table3-2"></td>
                                <td class="table3-3"></td>
                                <td class="table3-4"></td>
                                <td class="table3-5"></td>
                                <td class="table3-6"></td>
                            </tr>
                            <tr>
                                <td class="table3-1"></td>
                                <td class="table3-2"></td>
                                <td class="table3-3"></td>
                                <td class="table3-4"></td>
                                <td class="table3-5"></td>
                                <td class="table3-6"></td>
                            </tr>
                            <tr>
                                <td class="table3-1"></td>
                                <td class="table3-2"></td>
                                <td class="table3-3"></td>
                                <td class="table3-4"></td>
                                <td class="table3-5"></td>
                                <td class="table3-6"></td>
                            </tr>
                            <tr>
                                <td class="table3-1"></td>
                                <td class="table3-2"></td>
                                <td class="table3-3"></td>
                                <td class="table3-4"></td>
                                <td class="table3-5"></td>
                                <td class="table3-6"></td>
                            </tr>
                            <tr>
                                <td class="table3-1"></td>
                                <td class="table3-2"></td>
                                <td class="table3-3"></td>
                                <td class="table3-4"></td>
                                <td class="table3-5"></td>
                                <td class="table3-6"></td>
                            </tr>
                            <tr>
                                <td class="table3-1"></td>
                                <td class="table3-2"></td>
                                <td class="table3-3"></td>
                                <td class="table3-4"></td>
                                <td class="table3-5"></td>
                                <td class="table3-6"></td>
                            </tr>
                        </table>
                        <table id="table005-bt" border="1" cellspacing="0">
                            <tr>
                                <td >家庭关系和社会关系成员中有无重大问题，与本人关系如何</td>                       
                            </tr>
                       </table>
                        <table id="table005" border="1" cellspacing="0">
                            <tr>
                                <td></td>
                            </tr>
                       </table>
                        <table id="table006-bt" border="1" cellspacing="0">
                            <tr>
                                <td>入党过程</td>
                            </tr>
                        </table>
                        <table id="table006" border="1" cellspacing="0">
                            <tr>
                                <td></td>
                            </tr>
                        </table>
                        <table id="table007-bt" border="1" cellspacing="0">
                            <tr>
                                <td>奖励明细</td>
                            </tr>
                        </table>
                        <table id="table007" border="1" cellspacing="0">
                            <tr>
                                <td></td>
                            </tr>
                        </table>
                        <table id="table008-bt" border="1" cellspacing="0">
                            <tr>
                                <td>惩罚明细</td>
                            </tr>
                        </table>
                        <table id="table008" border="1" cellspacing="0">
                            <tr>
                                <td></td>
                            </tr>
                        </table>
                        <table id="table009-bt" border="1" cellspacing="0">
                            <tr>
                                <td>其他问题说明</td>
                            </tr>
                        </table>
                        <table id="table009" border="1" cellspacing="0">
                            <tr>
                                <td></td>
                            </tr>
                        </table>
                         <table id="table010-bt" border="1" cellspacing="0">
                            <tr>
                                <td>个人介绍与事件记录</td>
                            </tr>
                        </table>
                        <table id="table010" border="1" cellspacing="0">
                            <tr>
                                <td></td>
                            </tr>
                        </table>
                    </div>
                    
				</div>                
                </div>
			</div>
		</div>
		
    </form>
</body>
</html>
