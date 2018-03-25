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
using System.IO;

public partial class admin_videoupload : System.Web.UI.Page
{

    public string showType = "";
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack) 
        {
            types();
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }


    //显示类型


    void types() 
    {
        
        string sql = "select * from types";
        DataSet ds = DBHelper.getDataSet(sql);
        int cnt = ds.Tables[0].Rows.Count;
        for (int i = 0; i < cnt; i++) 
        {
            string name=ds.Tables[0].Rows[i]["tname"].ToString();
            string id=ds.Tables[0].Rows[i]["id"].ToString();

            showType += "<option value=" + id + ">" + name + "</option>";
        }

    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        string imgUrl="";
        string videoUrl = "";


        //图片上传

        bool filelsvalid = false;

        string tid = "";
        if (Request.Form["types"] == "电影类型")
        {
            Response.Write("<script>alert('请选择电影类型');</script>");
            return;
        }
        else
        {
            tid = Request.Form["types"];
        }
        //判断有无文件夹
        string path = Server.MapPath("~/uploadImages/");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        if (this.FileUpload1.HasFile)
        {
            string fileExtension = System.IO.Path.GetExtension(this.FileUpload1.FileName).ToLower();
            string[] restrictExtension ={ ".gif", ".jpg", ".bmp", ".png" };
            for (int i = 0; i < restrictExtension.Length; i++)
            {
                if (fileExtension == restrictExtension[i])
                {
                    filelsvalid = true;
                }
            }
            if (filelsvalid == true)
            {
                try
                {
                    //图片路径储存
                    this.FileUpload1.SaveAs(path + FileUpload1.FileName);

                    imgUrl = "uploadImages/" + FileUpload1.FileName;

                    Response.Write("<script>alert('图片上传成功')</script>");
                }
                catch
                {

                    Response.Write("<script>alert('图片上传失败')</script>");
                }
                finally
                {
                }
            }
            else
            {
                Response.Write("<script>alert('检查文件格式是否有误')</script>");

            }


        }
        else
        {
            Response.Write("<script>alert('并未选择任何文件')</script>");

            return;
        }


        //视频上传
       filelsvalid = false;
        //判断有无文件夹
        path = Server.MapPath("~/uploadVideo/");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        if (this.FileUpload2.HasFile)
        {
            string fileExtension = System.IO.Path.GetExtension(this.FileUpload2.FileName).ToLower();
            string[] restrictExtension ={ ".mp4", ".flv", ".mkv", ".avi" };
            for (int i = 0; i < restrictExtension.Length; i++)
            {
                if (fileExtension == restrictExtension[i])
                {
                    filelsvalid = true;
                }
            }
            if (filelsvalid == true)
            {
                try
                {
                    //this.Image1.ImageUrl = "~/movies/" + FileUpload2.FileName;
                    
                    //视频储存路径
                    this.FileUpload2.SaveAs(path + FileUpload2.FileName);
                    videoUrl = "uploadVideo /" + FileUpload2.FileName;
                  
                    Response.Write("<script>alert('视频上传成功')</script>");
                }
                catch
                {
                    Response.Write("<script>alert('视频上传失败')</script>");

                }
                finally
                {
                }
            }
            else
            {
                Response.Write("<script>alert('检查视频格式是否有误')</script>");
            }


        }
        else
        {
            Response.Write("<script>alert('并未选择任何视频')</script>");

            return;
        }

        //数据库
        string movieName = Request.Form["movieName"]; 
        string onlinetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string movieBrief = Request.Form["movieBrief"];

        if (movieName == "" || movieName == null) 
        {
            Response.Write("<script>alert('请输入电影名字');</script>");
            return;
        }
        else if (movieBrief == "" || movieBrief == null) 
        {
            Response.Write("<script>alert('请输入电影简介');</script>");
            return;
        }
       
        string person = Session["userName"].ToString();
        string sql = "insert into movielist(mname,maker,url,img,onlinetime,brief,tid)" +
                    "values('" + movieName + "','" + person + "','" + videoUrl + "','" + imgUrl + "','" + onlinetime + "','" + movieBrief + "'," + tid + ")";
        int n = DBHelper.exeDML(sql);
        if (n > 0)
        {
            Response.Write("<script>alert('电影上传成功');</script>");
            Response.Redirect("~/admin/videoUpload.aspx");
        }
        else { Response.Write("<script>alert('电影上传失败');</script>"); }

    }
}
