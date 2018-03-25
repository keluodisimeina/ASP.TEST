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


public partial class index : System.Web.UI.Page
{
    public string hotlist = "";
    public string recommendlist="";
    public string newlist = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sql = "select top 4 * from movielist order by playtimes desc";
            hotlist = outputList(sql);

            sql = "select top 4 * from movielist where isrecommend=1";
            recommendlist = outputList(sql);

            sql = "select top 4 * from movielist order by onlinetime desc";
            newlist = outputList(sql);

            
            /*Hotlist();                  
            Recommendlist();
            Newlist();*/
        }
    }


    private string outputList(string sql) 
    {
        string outputList = "";

        DataSet ds = DBHelper.getDataSet(sql);

        int cnt = ds.Tables[0].Rows.Count;
        for (int i = 0; i < cnt; i++)
        {
            string mname = ds.Tables[0].Rows[i]["mname"].ToString();
            string maker = ds.Tables[0].Rows[i]["maker"].ToString();
            string url = ds.Tables[0].Rows[i]["url"].ToString();
            string img = ds.Tables[0].Rows[i]["img"].ToString();

            string isrecommend = ds.Tables[0].Rows[i]["isrecommend"].ToString();
            string onlinetime = ds.Tables[0].Rows[i]["onlinetime"].ToString();
            string brief = ds.Tables[0].Rows[i]["brief"].ToString();
            string tid = ds.Tables[0].Rows[i]["tid"].ToString();
            string id=ds.Tables[0].Rows[i]["id"].ToString();

            
            
            

            //简介
            if(brief.Length>50)
            {
                brief = brief.Substring(0, 48) + "...";
            }

            //时间日期
            
            onlinetime = DateTime.Parse(onlinetime).ToString("yyyy-MM-dd HH:mm:ss");
            string month = onlinetime.Substring(5, 2);
            string day = onlinetime.Substring(8, 2);
            month = new dateUtil().getEnglishMonth(int.Parse(month));
            
            month = month.Substring(0, 3);







            outputList += "<div class=\"span3\"><article> <a href='play.aspx?id=" + id + "'>  <img src=\"" + img + "\" alt=\"\" class=\"imgOpa\"><div class=\"date\">  </a> <span class=\"day\">" + day + "</span><span class=\"month\">" + month + "</span></div><h4><a href=\"play.aspx?id=" + id + "\">" + mname + "</a></h4><p>" + brief + "<a href=\"bloghome.html\" class=\"read-more\">read more <i class=\"icon-angle-right\"></i></a></p></article></div>";
        }
        return outputList;

    }




    ///<summary>
    ///  1:影院热播
    // 文档注释
    /// </summary>
     


    
   /* private void Hotlist()
    {
        string sql = "select top 4 * from movielist order by playtimes desc";
        DataSet ds = DBHelper.getDataSet(sql);
        int cnt = ds.Tables[0].Rows.Count;
        for (int i = 0; i < cnt; i++)
        {
            string mname = ds.Tables[0].Rows[i]["mname"].ToString();
            string maker = ds.Tables[0].Rows[i]["maker"].ToString();
            string url = ds.Tables[0].Rows[i]["url"].ToString();
            string img = ds.Tables[0].Rows[i]["img"].ToString();
            
            string isrecommend = ds.Tables[0].Rows[i]["isrecommend"].ToString();
            string onlinetime = ds.Tables[0].Rows[i]["onlinetime"].ToString();
            string brief = ds.Tables[0].Rows[i]["brief"].ToString();
            string tid = ds.Tables[0].Rows[i]["tid"].ToString();
            hotlist += "<div class=\"span3\"><article><img src=\"" + img + "\" alt=\"\" class=\"imgOpa\"><div class=\"date\"><span class=\"day\">" + 99 +"</span><span class=\"month\">Jan</span></div><h4><a href=\"bloghome.html\">" + mname + "</a></h4><p>" + brief + "<a href=\"bloghome.html\" class=\"read-more\">read more <i class=\"icon-angle-right\"></i></a></p></article></div>";
        }

    }
    //2:精彩连轴看
    private void Recommendlist()
    {
        string sql = "select top 4 * from movielist where isrecommend=1";
        DataSet ds = DBHelper.getDataSet(sql);
        int cnt = ds.Tables[0].Rows.Count;
        for (int i = 0; i < cnt; i++)
        {
            string mname = ds.Tables[0].Rows[i]["mname"].ToString();
            string maker = ds.Tables[0].Rows[i]["maker"].ToString();
            string url = ds.Tables[0].Rows[i]["url"].ToString();
            string img = ds.Tables[0].Rows[i]["img"].ToString();
            string playtimes = ds.Tables[0].Rows[i]["playtimes"].ToString();
            string isrecommend = ds.Tables[0].Rows[i]["isrecommend"].ToString();
            string onlinetime = ds.Tables[0].Rows[i]["onlinetime"].ToString();
            string brief = ds.Tables[0].Rows[i]["brief"].ToString();
            string tid = ds.Tables[0].Rows[i]["tid"].ToString();
            recommendlist += "<div class=\"span3\"><article><img src=\"" + img + "\" alt=\"\" class=\"imgOpa\"><div class=\"date\"><span class=\"day\">" + playtimes + "</span><span class=\"month\">Jan</span></div><h4><a href=\"bloghome.html\">" + mname + "</a></h4><p>" + brief + "<a href=\"bloghome.html\" class=\"read-more\">read more <i class=\"icon-angle-right\"></i></a></p></article></div>";
        }
    }
    //3:最新上线
    private void Newlist()
    {
        string sql = "select top 4 * from movielist order by onlinetime desc";
        DataSet ds = DBHelper.getDataSet(sql);
        int cnt = ds.Tables[0].Rows.Count;
        for (int i = 0; i < cnt; i++)
        {
            string mname = ds.Tables[0].Rows[i]["mname"].ToString();
            string maker = ds.Tables[0].Rows[i]["maker"].ToString();
            string url = ds.Tables[0].Rows[i]["url"].ToString();
            string img = ds.Tables[0].Rows[i]["img"].ToString();
            string playtimes = ds.Tables[0].Rows[i]["playtimes"].ToString();
            string isrecommend = ds.Tables[0].Rows[i]["isrecommend"].ToString();
            string onlinetime = ds.Tables[0].Rows[i]["onlinetime"].ToString();
            string brief = ds.Tables[0].Rows[i]["brief"].ToString();
            string tid = ds.Tables[0].Rows[i]["tid"].ToString();
            newlist += "<div class=\"span3\"><article><img src=\"" + img + "\" alt=\"\" class=\"imgOpa\"><div class=\"date\"><span class=\"day\">" + playtimes + "</span><span class=\"month\">Jan</span></div><h4><a href=\"bloghome.html\">" + mname + "</a></h4><p>" + brief + "<a href=\"bloghome.html\" class=\"read-more\">read more <i class=\"icon-angle-right\"></i></a></p></article></div>";
        }
    }*/

}
