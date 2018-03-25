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

public partial class play : System.Web.UI.Page
{
    public string comedy = "";
    public string tName = "";


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Comedy();
            
        }

    }



    private void Comedy()
    {
        string tid=Request.QueryString["tid"];//从客户端请求值tid
        string sql;
        if(tid==null)//tid为空查询出sort所有movies
        {
            sql="select m.id,mname,img,playtimes,tname from movielist m inner join types t on m.tid=t.id";
        }
        else//不为空以tid值寻找类
        {
            sql = "select m.id,mname,img,playtimes,tname from movielist m inner join types t on m.tid=t.id where tid=" + tid;
        }

       // string sql = "select m.id,mname,img,playtimes,tname from movielist m inner join types t on m.tid=t.id where tid="+ tid +;
        DataSet ds = DBHelper.getDataSet(sql);
        int cnt = ds.Tables[0].Rows.Count;
        if(cnt == 0 && tid!=null)//排除数据库中一个数据也没有的情况
        {//没有数据
            sql="select id,tname from types where id=" + tid;
            DataSet dsTypes = DBHelper.getDataSet(sql);
            int cntTypes = dsTypes.Tables[0].Rows.Count;

            if (cntTypes == 0)
            {//没有类别
                Response.Write("<script>alert('没有此类别');</script>");
                Response.Redirect("~/sort.aspx");

            }
            else 
            {//有类别
                tName = ">>" + dsTypes.Tables[0].Rows[0]["tname"].ToString();
            }
            return;
        }


        //有数据才显示

        for (int i = 0; i < cnt; i++)
        {
            string mname = ds.Tables[0].Rows[i]["mname"].ToString();
            string id = ds.Tables[0].Rows[i]["id"].ToString();
            string img = ds.Tables[0].Rows[i]["img"].ToString();
            string playtimes = ds.Tables[0].Rows[i]["playtimes"].ToString();
            tName = ">>" + ds.Tables[0].Rows[i]["tname"].ToString();
            comedy += "<div class=\"movie left\"><a href=\"play.aspx?id=" + id + "\"><img src=\"" + img + "\"width=\"170\" height=\"140\"/></a><br/><a href='play.aspx?id=" + id + "'> " + mname + "</a><span class=\"right\" style=\"margin-right:20px; color: #F63\">7.7</span><br><img src=\"images/list_good.png\">20<span style=\"margin-top:10px; margin-left:10px; font-size:15px;\">播放次数<small style=\"color:red\"> " + playtimes + "</small></span></div>";
        }


        if(tid==null)
        {
            tName="";
        }

    }


}
