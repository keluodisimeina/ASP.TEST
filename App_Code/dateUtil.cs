using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// dateUtil 的摘要说明
/// </summary>
public class dateUtil
{
	public dateUtil()
	{
        
	}

    public string getEnglishMonth(int month) 
    {
        string str = "";

        switch (month)
        {
            case 1: str = "January"; break;
            case 2: str = "February"; break;
            case 3: str = "March"; break;
            case 4: str = "April"; break;
            case 5: str = "May"; break;
            case 6: str = "June"; break;
            case 7: str = "July"; break;
            case 8: str = "August"; break;
            case 9: str = "September"; break;
            case 10: str = "October"; break;
            case 11: str = "November"; break;
            case 12: str = "December"; break;
            default: str = ""; break;
        }
        return str;

    }

}
