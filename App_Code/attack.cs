using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// DBHelper 的摘要说明
/// </summary>
public class attack
{


   /* public static string inputAttack(string a) 
    {
        string str = "";
        str = a.Replace("'", "''");
        str = a.Replace("drop", "");
        str = a.Replace("-", "");
        str = a.Replace("!", "");
        return str;

    }*/

    public static bool hasSqlattack(string a)
    {
        string str = "and |exec |insert |select |delete |update |chr |mid |master |or |truncate |char| declare |join |drop |' |--";
        a = a.ToLower();
        string[] strs = str.Split('|');
        for (int i = 0; i < strs.Length; i++) 
        {
            if (a.Contains(strs[i])) 
            {
                return true;
            }
        }
        return false;
        
    }

}
