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

public partial class admin_movieEdit : System.Web.UI.Page
{
    public string type = "";
    public string showTable = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            types();
            string action = Request.QueryString["action"];
            if (action == null) 
            {
                string sql = "select  m.id,mname,img,onlinetime,tname from types t ,movielist m  where t.id=m.tid order by onlinetime desc limit 3";
                tables(sql);
            }
            else if (action.Equals("search")) 
            {
                search();
            }
            else if (action.Equals("dele")) 
            {
                string id = Request.QueryString["id"];
                dele(id);
                
            }



        }
       
    }

    //下拉框
    void types()
    {

        string sql = "select * from types";
        DataSet ds = DBHelper.getDataSet(sql);
        int cnt = ds.Tables[0].Rows.Count;
        for (int i = 0; i < cnt; i++)
        {
            string name = ds.Tables[0].Rows[i]["tname"].ToString();
            string id = ds.Tables[0].Rows[i]["id"].ToString();

            type += "<option value=" + id + ">" + name + "</option>";
        }

    }
    //table 表

    void tables(string sql) 
    {
        DataSet ds = DBHelper.getDataSet(sql);
        int cnt = ds.Tables[0].Rows.Count;
        for (int i = 0; i < cnt; i++) 
        {
            string id = ds.Tables[0].Rows[i]["id"].ToString();
            string name = ds.Tables[0].Rows[i]["mname"].ToString();
            string img = ds.Tables[0].Rows[i]["img"].ToString();
            string onlinetime = ds.Tables[0].Rows[i]["onlinetime"].ToString();
            string tname = ds.Tables[0].Rows[i]["tname"].ToString();
            showTable += "<tr><td><input name=\"\" type=\"checkbox\" value=\"'" + id + "'\" /></td><td>" + name + "</td><td style=\"padding:8px;\"><img src=\"../" + img + "\" width=\"150\" height=\"100\" /></td><td>" + tname + "</td><td>" + onlinetime + "</td><td><a style=\" margin-right:10px;\" href=\"movieChange.aspx?action=change&id=" + id + "\">修改</a><a href=\"movieEdit.aspx?action=dele&id=" + id + "\">删除</a></td></tr>";

        }



    }


        //search功能
        void search()
        {
            string sql = "select m.id,mname,img,onlinetime,tname from types t,movielist m where t.id=m.tid ";
            string id = Request.Form["types"];
            string search = Request.Form["search"];
            if (!id.Equals("")) //不为空按类型搜索 
            {
                sql += " and t.id=" + id;
            }
            else if (!search.Equals("")) //不为空按搜索框查询
            {
                sql += " and mname like '%" + search + "%'";
            }
            else 
            {
                sql += " order by onlinetime desc";//全局搜索
            }
            tables(sql);

        }


    //删除功能
    void dele(string id) 
    {
        if (id != null)
        {
            string sql = "delete from movielist where id=" + id;
            int n = DBHelper.exeDML(sql);
            if (n > 0)
            {
                Response.Write("<script>alert('删除成功');</script>");
            }
            else
            {
                Response.Write("<script>alert('数据未删除');</script>");
            }
        }
        string sql2 = "select m.id,mname,img,onlinetime,tname from types t,movielist m where t.id=m.tid order by onlinetime desc";
        tables(sql2);
    }

}
