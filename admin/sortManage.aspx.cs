using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class admin_sortManage : System.Web.UI.Page
{
    public string tdout = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            string sql = "select id,tname from types";
            DataSet ds = DBHelper.getDataSet(sql);
            int cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < cnt; i++) 
            {
                string id = ds.Tables[0].Rows[i]["id"].ToString();
                string tname = ds.Tables[0].Rows[i]["tname"].ToString();
                tdout += "<tr><th  style=\"border:1px solid #666;text-align:center\" width=\"200\" height=\"50\">"+id+"</th><th  style=\"border:1px solid #666;text-align:center\" width=\"200\" height=\"50\">"+tname+"</th><th  style=\"border:1px solid #666;text-align:center\" width=\"200\" height=\"50\">删除</th></tr>";
            }

        }
    }
}
