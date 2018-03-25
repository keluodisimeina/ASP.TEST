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

public partial class ADMINmaster : System.Web.UI.MasterPage
{
    public string outli = "";
    public string loginName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Redirect("~/loginAdmin.html");
        }
        else
        {
            string name = Session["userName"].ToString();
            string sql = "select name,limit from admins where name='" + name + "'";
            DataSet ds = DBHelper.getDataSet(sql);
            if ("1" == ds.Tables[0].Rows[0]["limit"].ToString())
            {
                outli = "<li id=\"oLi2\"><a style=\"border-top: 1px solid #D7D7D7;\" class=\"\" href=\"#\">用户管理</a></li><ul id=\"oUl2\" style=\"opacity:0; width:0px; height:0px;\"><li><a style=\"border-left: 1px solid #D7D7D7;\"  href=\"\" class=\"\"> 编辑用户</a></li><li><a style=\"border-left: 1px solid #D7D7D7;\" href=\"\" class=\"\">新增用户</a></li><li><a style=\"border-left: 1px solid #D7D7D7;\" href=\"\" class=\"\"> 删除用户</a></li></ul>";
            }
            else if ("2" == ds.Tables[0].Rows[0]["limit"].ToString())
            {
                loginName = "<span class=\"ad\">" + name + "管理员</span>";
                return;
            }


            loginName = "<span class=\"ad\">"+name+"管理员</span>";


        }
    }

}