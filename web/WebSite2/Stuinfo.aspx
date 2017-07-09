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
				top: 200px;
				left: 25px;
            }
            #table007{
                width: 750px;
				height: 260px;
				position: relative;
				top: 200px;
				left: 25px;
            }
            #table008{
                 width: 750px;
				height: 260px;
				position: relative;
				top: 200px;
				left: 25px;
            }
            #table008{
                 width: 750px;
				height: 260px;
				position: relative;
				top: 200px;
				left: 25px;
            }
            #table009{
                 width: 750px;
				height: 400px;
				position: relative;
				top: 250px;
				left: 25px;
            }
            #table010{
                 width: 750px;
				height: 600px;
				position: relative;
				top: 300px;
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
            top: 250px;
            left: 25px;
            text-align: center;
            }
            #table010-bt{
            width: 750px;
            height: 50px;
            position: relative;
            top: 300px;
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
                width:30%;
                height:60px;
            }
            .table2-2{
                width:50%;
                height:60px;
            }
            .table2-3{
                width:20%;
                height:60px;
            }
            .table3-1{
                width: 12%;
                height:60px;
                text-align:center;
            }
            .table3-2{
                 width: 12%;
                  height:60px;
                 text-align:center;
            }
            .table3-3{
                 width: 12%;
                  height:60px;
                 text-align:center;
            }
            .table3-4{
                 width: 30%;
                  height:60px;
                 text-align:center;
            }
            .table3-5{
                 width: 12%; 
                  height:60px;
                 text-align:center;
            }
            .table3-6 {
                 height:60px;
                text-align: center;
            }

            .input1{
                width:100%;
                height:100%;
                border-style:none;
                ime-mode: disabled;
            }
            .textarea{
                width:100%;
                height:200px;
                border-style:none;
                ime-mode: disabled;
                overflow:hidden;
                resize:none;
            }
             .textarea1{
                width:100%;
                height:260px;
                border-style:none;
                ime-mode: disabled;
                overflow:hidden;
                resize:none;
            }
             .textarea2{
                width:100%;
                height:400px;
                border-style:none;
                ime-mode: disabled;
                overflow:hidden;
                resize:none;
            }
             .textarea3{
                width:100%;
                height:600px;
                border-style:none;
                ime-mode: disabled;
                overflow:hidden;
                resize:none;
            }
     
		
		.auto-style1 {
            height: 48px;
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
                                
					           <td class="table1-1" >姓名:</td>
                               <td class="table1-2">
                                   <input id="name" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>
					 
						    </tr>
                            <tr>
					           <td class="table1-1">曾用名:</td>
                               <td class="table1-2" >
                                   <input id="lastnaem" runat="server" type="text" class="input1"  onFocus="this.blur()" />
                               </td>
					   
						    </tr>
                             <tr>
					           <td class="table1-1">性别:</td>
                               <td class="table1-2" >
                                   <input id="sex" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>
					 
						    </tr>
                            <tr>
					           <td class="table1-1">民族:</td>
                               <td class="table1-2" >
                                    <input id="minzu" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>
					 
						    </tr>
                            <tr>
					           <td class="table1-1">政治面貌:</td>
                               <td class="table1-2" >
                                    <input id="zhengzhi" runat="server" type="text"  class="input1" onFocus="this.blur()" />
                               </td>
					 
						    </tr>
                            <tr>
					           <td class="table1-1">婚姻状况:</td>
                               <td class="table1-2" >
                                    <input id="hunyin" runat="server" type="text"  class="input1" onFocus="this.blur()"/>
                               </td>
					 
						    </tr>
                             <tr>
					           <td class="table1-1">健康状况:</td>
                               <td class="table1-2" >
                                    <input id="jiankang" runat="server" type="text"  class="input1" onFocus="this.blur()"/>
                               </td>
					 
						    </tr>
                             <tr>
					           <td class="table1-1">出生日期:</td>
                               <td class="table1-2" >
                                    <input id="shenri" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>
					 
						    </tr>
                             <tr>
					           <td class="table1-1">联系电话:</td>
                               <td class="table1-2" >
                                    <input id="phone" runat="server" type="text"  class="input1" onFocus="this.blur()"/>
                               </td>
					 
						    </tr>
                             <tr>
					           <td class="table1-1">电子邮箱:</td>
                               <td class="table1-2" >
                                    <input id="email" runat="server" type="text"  class="input1" onFocus="this.blur()"/>
                               </td>
					 
						    </tr>
                             <tr>
					           <td class="table1-1">家庭联系电话:</td>
                               <td class="table1-2" >
                                    <input id="jtphone" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>					 
						    </tr>
                             <tr>
					           <td class="table1-1">银行卡号:</td>
                               <td class="table1-2" >
                                    <input id="bankcard" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>					 
						    </tr>
                              <tr>
					           <td class="table1-1">银行卡所属银行:</td>
                               <td class="table1-2" >
                                    <input id="bank" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>					 
						    </tr>
                            <tr>
					           <td class="table1-1">身份证号:</td>
                               <td class="table1-2" >
                                    <input id="idcard" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>					 
						    </tr>
                            <tr>
					           <td class="table1-1">生源地:</td>
                               <td class="table1-2" >
                                    <input id="syd" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>					 
						    </tr>
                            <tr>
					           <td class="table1-1">家庭住址:</td>
                               <td class="table1-2" >
                                    <input id="jtzz" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>					 
						    </tr>
                            <tr>
					           <td class="table1-1">邮政编码:</td>
                               <td class="table1-2" >
                                    <input id="yzbm" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>					 
						    </tr>
				        
					    
					    </table>                             
                                      
                    </div>
                    <div id="div009" style="float:left;">
                        <img id="preview" runat="server" />
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
                                <td class="table2-1">
                                    <input id="sh11" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>
                             
                                <td class="table2-2">
                                    <input id="sh12" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>
                               
                                <td class="table2-3">
                                    <input id="sh13" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>
                                
                            </tr>
                             <tr>
                                <td class="table2-1">
                                    <input id="sh21" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>
                             
                                <td class="table2-2">
                                    <input id="sh22" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>
                               
                                <td class="table2-3">
                                    <input id="sh23" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>
                            </tr>
                             <tr>
                               <td class="table2-1">
                                    <input id="sh31" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>
                             
                                <td class="table2-2">
                                    <input id="sh32" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>
                               
                                <td class="table2-3">
                                    <input id="sh33" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>
                            </tr>
                             <tr>
                                <td class="table2-1">
                                    <input id="sh41" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>
                             
                                <td class="table2-2">
                                    <input id="sh42" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>
                               
                                <td class="table2-3">
                                    <input id="sh43" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>
                            </tr>
                             <tr>
                                <td class="table2-1">
                                    <input id="sh51" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>
                             
                                <td class="table2-2">
                                    <input id="sh52" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>
                               
                                <td class="table2-3">
                                    <input id="sh53" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>
                            </tr>
                             <tr>
                                <td class="table2-1">
                                    <input id="sh61" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>
                             
                                <td class="table2-2">
                                    <input id="sh62" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>
                               
                                <td class="table2-3">
                                    <input id="sh63" runat="server" type="text" class="input1" onFocus="this.blur()" />
                               </td>
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
                                <td class="table3-1">
                                     <input id="family11" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-2">
                                    <input id="family12" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-3">
                                    <input id="family13" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-4">
                                    <input id="family14" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-5">
                                    <input id="family15" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-6">
                                    <input id="family16" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                            </tr>
                             <tr>
                                <td class="table3-1">
                                     <input id="family21" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-2">
                                    <input id="family22" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-3">
                                    <input id="family23" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-4">
                                    <input id="family24" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-5">
                                    <input id="family25" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-6">
                                    <input id="family26" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                            </tr>
                             <tr>
                                <td class="table3-1">
                                     <input id="family31" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-2">
                                    <input id="family32" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-3">
                                    <input id="family33" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-4">
                                    <input id="family34" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-5">
                                    <input id="family35" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-6">
                                    <input id="family36" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                            </tr>
                             <tr>
                                <td class="table3-1">
                                     <input id="family41" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-2">
                                    <input id="family42" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-3">
                                    <input id="family43" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-4">
                                    <input id="family44" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-5">
                                    <input id="family45" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-6">
                                    <input id="family46" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                            </tr>
                             <tr>
                                <td class="table3-1">
                                     <input id="family51" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-2">
                                    <input id="family52" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-3">
                                    <input id="family53" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-4">
                                    <input id="family54" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-5">
                                    <input id="family55" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-6">
                                    <input id="family56" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                            </tr>
                             <tr>
                                <td class="table3-1">
                                     <input id="family61" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-2">
                                    <input id="family62" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-3">
                                    <input id="family63" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-4">
                                    <input id="family64" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-5">
                                    <input id="family65" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-6">
                                    <input id="family66" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
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
                                <td class="table3-1">
                                     <input id="friend11" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-2">
                                    <input id="friend12" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-3">
                                    <input id="friend13" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-4">
                                    <input id="friend14" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-5">
                                    <input id="friend15" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-6">
                                    <input id="friend16" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                            </tr>
                            <tr>
                                <td class="table3-1">
                                     <input id="friend21" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-2">
                                    <input id="friend22" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-3">
                                    <input id="friend23" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-4">
                                    <input id="friend24" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-5">
                                    <input id="friend25" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-6">
                                    <input id="friend26" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                            </tr>
                            <tr>
                                <td class="table3-1">
                                     <input id="friend31" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-2">
                                    <input id="friend32" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-3">
                                    <input id="friend33" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-4">
                                    <input id="friend34" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-5">
                                    <input id="friend35" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-6">
                                    <input id="friend36" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                            </tr>
                            <tr>
                                <td class="table3-1">
                                     <input id="friend41" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-2">
                                    <input id="friend42" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-3">
                                    <input id="friend43" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-4">
                                    <input id="friend44" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-5">
                                    <input id="friend45" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-6">
                                    <input id="friend46" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                            </tr>
                            <tr>
                                <td class="table3-1">
                                     <input id="friend51" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-2">
                                    <input id="friend52" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-3">
                                    <input id="friend53" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-4">
                                    <input id="friend54" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-5">
                                    <input id="friend55" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-6">
                                    <input id="friend56" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                            </tr>
                            <tr>
                                <td class="table3-1">
                                     <input id="friend61" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-2">
                                    <input id="friend62" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-3">
                                    <input id="friend63" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-4">
                                    <input id="friend64" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-5">
                                    <input id="friend65" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                                <td class="table3-6">
                                    <input id="friend66" runat="server" type="text" class="input1" onFocus="this.blur()" />
                                </td>
                            </tr>
                        </table>
                        <table id="table005-bt" border="1" cellspacing="0">
                            <tr>
                                <td >家庭关系和社会关系成员中有无重大问题，与本人关系如何</td>                       
                            </tr>
                       </table>
                        <table id="table005" border="1" cellspacing="0">
                            <tr>
                                <td>
                                    <textarea id="jtgx" runat="server" class="textarea" onFocus="this.blur()"> </textarea>
                                </td>
                            </tr>
                       </table>
                        <table id="table006-bt" border="1" cellspacing="0">
                            <tr>
                                <td>入党过程</td>
                            </tr>
                        </table>
                        <table id="table006" border="1" cellspacing="0">
                            <tr>
                                <td>
                                    <textarea id="rudang" runat="server" class="textarea1" onFocus="this.blur()"> </textarea>
                                </td>
                            </tr>
                        </table>
                        <table id="table007-bt" border="1" cellspacing="0">
                            <tr>
                                <td>奖励明细</td>
                            </tr>
                        </table>
                        <table id="table007" border="1" cellspacing="0">
                            <tr>
                                <td>
                                    <textarea id="jiangli" runat="server" class="textarea1" onFocus="this.blur()"> </textarea>
                                </td>
                            </tr>
                        </table>
                        <table id="table008-bt" border="1" cellspacing="0">
                            <tr>
                                <td>惩罚明细</td>
                            </tr>
                        </table>
                        <table id="table008" border="1" cellspacing="0">
                            <tr>
                                <td>
                                    <textarea id="chengfa" runat="server" class="textarea1" onFocus="this.blur()"> </textarea>
                                </td>
                            </tr>
                        </table>
                        <table id="table009-bt" border="1" cellspacing="0">
                            <tr>
                                <td>其他问题说明</td>
                            </tr>
                        </table>
                        <table id="table009" border="1" cellspacing="0">
                            <tr>
                                <td><textarea id="qita" runat="server" class="textarea2" onFocus="this.blur()"> </textarea></td>
                            </tr>
                        </table>
                         <table id="table010-bt" border="1" cellspacing="0">
                            <tr>
                                <td class="auto-style1">个人介绍与事件记录</td>
                            </tr>
                        </table>
                        <table id="table010" border="1" cellspacing="0">
                            <tr>
                                <td>
                                    <textarea id="jishi" runat="server" class="textarea3" onFocus="this.blur()"> </textarea>
                                </td>
                            </tr>
                        </table>
                    </div>
                    
				</div>                
                </div>
			</div>

		
    </form>
</body>
</html>
