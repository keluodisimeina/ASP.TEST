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
public class DBHelper
{
	public DBHelper()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    //静态方法，获取sql连接对象
    public static SqlConnection getConn()
    {
        string connStr = ConfigurationManager.ConnectionStrings["connstring2"].ConnectionString;
        SqlConnection conn=new SqlConnection(connStr);
        return conn;

    }

    ///<summary>
    ///根据select语句，定义数据集
    ///</summary>
    ///<param name="sql">sql是select语句</param>
    ///<returns>Data数据集</returns>


    public static DataSet getDataSet(string sql) 
    {
      
        SqlConnection conn = DBHelper.getConn();
        SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        return ds;
    }


    /// <summary>
    /// 执行insert，update，delet语句
    /// </summary>
    public static int exeDML(string sql) 
    {
        SqlConnection conn = getConn();
        try
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            int n = cmd.ExecuteNonQuery();
            return n;
        }
        finally
        {
            if (conn.State == ConnectionState.Open) 
            {
                conn.Close();
            }
        }
    }
}
