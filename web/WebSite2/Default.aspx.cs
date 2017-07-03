using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadProductData();
        }
    }

    void LoadProductData()
    {
        DataTable dt = CreateSampleProductData();

        GridView1.DataSource = dt;
        GridView1.DataBind();

    }

    static DataTable CreateSampleProductData()
    {
        DataTable tbl = new DataTable("Products");

        tbl.Columns.Add("ProductID", typeof(int));
        tbl.Columns.Add("ProductName", typeof(string));
        tbl.Columns.Add("UnitPrice", typeof(decimal));
        tbl.Columns.Add("CategoryID", typeof(int));

        tbl.Rows.Add(1, "Chai", 18, 1);
        tbl.Rows.Add(2, "Chang", 19, 1);
        tbl.Rows.Add(3, "Aniseed Syrup", 10, 2);
        tbl.Rows.Add(4, "Chef Anton's Cajun Seasoning", 22, 2);
        tbl.Rows.Add(5, "Chef Anton's Gumbo Mix", 21.35, 2);
        tbl.Rows.Add(47, "Zaanse koeken", 9.5, 3);
        tbl.Rows.Add(48, "Chocolade", 12.75, 3);
        tbl.Rows.Add(49, "Maxilaku", 20, 3);

        return tbl;
    }

    private void RememberOldValues()
    {
        ArrayList categoryIDList = new ArrayList();
        int index = -1;
        foreach (GridViewRow row in GridView1.Rows)
        {
            index = (int)GridView1.DataKeys[row.RowIndex].Value;
            bool result = ((CheckBox)row.FindControl("checkD")).Checked;

            // Check in the Session
            if (Session["CHECKED_ITEMS"] != null)
                categoryIDList = (ArrayList)Session["CHECKED_ITEMS"];
            if (result)
            {
                if (!categoryIDList.Contains(index))
                    categoryIDList.Add(index);
            }
            else
                categoryIDList.Remove(index);
        }
        if (categoryIDList != null && categoryIDList.Count > 0)
            Session["CHECKED_ITEMS"] = categoryIDList;
    }

    private void RePopulateValues()
    {
        ArrayList categoryIDList = (ArrayList)Session["CHECKED_ITEMS"];
        if (categoryIDList != null && categoryIDList.Count > 0)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                int index = (int)GridView1.DataKeys[row.RowIndex].Value;
                if (categoryIDList.Contains(index))
                {
                    CheckBox myCheckBox = (CheckBox)row.FindControl("checkD");
                    myCheckBox.Checked = true;
                }
            }
        }
    }



    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        RememberOldValues();
        this.GridView1.PageIndex = e.NewPageIndex;
        this.LoadProductData();
        RePopulateValues();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ArrayList categoryIDList2 = new ArrayList();
        categoryIDList2 = (ArrayList)Session["CHECKED_ITEMS"];
        for (int i = 0; i < categoryIDList2.Count; i++)
        {
            Response.Write(categoryIDList2[i]);
            //Response.Write(@"<script>alert('"+categoryIDList2[i]+"')
        }
    }
}