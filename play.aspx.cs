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


public partial class play : System.Web.UI.Page
{
    public string moviename="";
    public string movieurl = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            //1接收查询字符串url的参数 id
            string mID = Request.QueryString["id"];

            //2根据id查询详细内容
            if (mID == null || mID.Equals("")||attack.hasSqlattack(mID)) 
            {
                Response.Redirect("~/index.aspx");
                return;
            }



            //3取出内容显示到页面上
            DataSet ds = DBHelper.getDataSet("select top 1 id,mname,url from movielist where id=" + mID);
            int cnt = ds.Tables[0].Rows.Count;
            if (0 == cnt) 
            {
                Response.Redirect("~/index.aspx");
            }
            else
            {
                moviename=ds.Tables[0].Rows[0]["mname"].ToString();
                movieurl=ds.Tables[0].Rows[0]["url"].ToString(); 
                //4播放次数加一
                playtimesAdd(mID);

            }

            //5修改index和sort的影片图片和名称的超链接，给出id值
        }
    }
    void playtimesAdd(string a) 
    {
        string sql = "update movielist set playtimes=playtimes+1 where id=" + a;
        DBHelper.exeDML(sql);
    }
}
