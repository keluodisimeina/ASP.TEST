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
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public string typelist = "";//成员变量，在类内部，方法外面
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //数据库查询出类别
            string sql = "select id,tname from types";
            SqlConnection conn = DBHelper.getConn();//静态方法调用

            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int cnt = ds.Tables[0].Rows.Count;

            for (int i = 0; i < cnt; i++)
            {
                string id = ds.Tables[0].Rows[i]["id"].ToString();
                string tname = ds.Tables[0].Rows[i]["tname"].ToString();
                typelist += "<li><a href=\"sort.aspx?tid="+id+"\">" + tname + "</a></li>";
            }
         
        }
    }


}
