<%@ WebHandler Language="C#" Class="login" %>

using System;
using System.Web;
using System.Data;
using System.Web.SessionState;



public class login : IHttpHandler,IRequiresSessionState {
    
    public void ProcessRequest (HttpContext context) {
        string name = context.Request.Form["username"];
        string pwd = context.Request.Form["password"];
        //注入式攻击
       /* string Name = attack.inputAttack(name);
        string Pwd = attack.inputAttack(pwd);
        
        */

        if (name == null || pwd == null || name.Equals("") || pwd.Equals("")) 
        {
            context.Response.Redirect("~/loginAdmin.html");
        }
        if (attack.hasSqlattack(name) || attack.hasSqlattack(pwd)) 
        {
            context.Response.Write("<script>alert('警告！');window.open('index.aspx','_self');</script>");
        }
        
        
        
        
        
        
        
        
        //查询数据库

        string MD5_pwd = md5.GetMD5(pwd);
        DataSet ds = DBHelper.getDataSet("select id,name,pwd,limit from admins where name='" + name + "' and pwd='" + MD5_pwd + "'");

        int cnt = ds.Tables[0].Rows.Count;
        if (cnt != 1)
        {
            context.Response.Write("<script>alert('登录失败！');</script>");
            context.Response.Redirect("~/loginAdmin.html");

        }
        else 
        {
            context.Session["userId"] = ds.Tables[0].Rows[0]["id"].ToString();
            context.Session["userName"] = name;



            
            context.Session["userLimit"] = ds.Tables[0].Rows[0]["limit"].ToString();
            context.Response.Redirect("admin/main.aspx");
            
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}