using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class demo2 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //  ScriptManager1.RegisterAsyncPostBackControl(Button1);
       // ScriptManager1.RegisterAsyncPostBackControl(Button1);
        string url = "login.aspx";
        Response.Write("<script language='javascript'>window.open('" + url + "','','height=500,width=611,scrollbars=yes,status =yes')</script>");
    }
}