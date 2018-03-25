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
using System.IO;

public partial class admin_movieChange : System.Web.UI.Page
{
    public string showType2 = "";

    public string name = "";//存电影名字

    public string brief = "";//存电影简介

    public string img11 = "";//存图片

    public string video11 = "";//存视频

    public string tid = "";//存电影类型

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            string rid = Request.QueryString["id"];
            if (rid == null) //链接id无数值
            {
                Response.Redirect("movieEdit.aspx");
            }
            else 
            {
                string sql = "select * from movieList where id=" + rid;
                DataSet ds = DBHelper.getDataSet(sql);
                int cnt = ds.Tables[0].Rows.Count;
                if (cnt == 0) 
                {
                    Response.Redirect("movieEdit.aspx");//找不到对应id的视频
                }
                else 
                {
                    name = ds.Tables[0].Rows[0]["mname"].ToString();
                    tid = ds.Tables[0].Rows[0]["tid"].ToString();
                    brief = ds.Tables[0].Rows[0]["brief"].ToString();
                    img11 = ds.Tables[0].Rows[0]["img"].ToString();
                    video11 = ds.Tables[0].Rows[0]["url"].ToString();


                   //获取电影类别
                    string sql2 = "select * from types";
                    DataSet ds2 = DBHelper.getDataSet(sql2);
                    int cnt2 = ds2.Tables[0].Rows.Count;
                    for (int i = 0; i < cnt2; i++) 
                    {
                        string id = ds2.Tables[0].Rows[i]["id"].ToString();// 电影类别id
                        string cname = ds2.Tables[0].Rows[i]["tname"].ToString();//电影类别名称
                        if (id == tid)//movielist找到的id与type找到的id相匹配
                        {
                            showType2 += "<option value='" + tid + "' selected>" + cname + "</option>";
                        }
                        else 
                        {
                            showType2 += "<option value='" + id + "' >" + cname + "</option>";
                        }

                    }


                }

            }
        }

    }


   /* void types2() 
    {
        string sql = "select * from types";
        DataSet ds = DBHelper.getDataSet(sql);
        int cnt = ds.Tables[0].Rows.Count;
        for (int i = 0; i < cnt; i++)
        {
            string name = ds.Tables[0].Rows[i]["tname"].ToString();
            string id = ds.Tables[0].Rows[i]["id"].ToString();

            showType2 += "<option value=" + id + ">" + name + "</option>";
        }
    }*/




    protected void btnSubmit_ServerClick(object sender, EventArgs e)
    {
        string imgUrl = Request["another"];//图片的原路径
        string moivesUrl = Request["moviepath"];//视频的原路径


        //图片上传
        Boolean filelsvalid = false;
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
                    moivesUrl = "uploadVideo /" + FileUpload2.FileName;

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




        //数据库

        string movieName = Request.Form["movieName"];
        string onlinetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string movieBrief = Request.Form["movieBrief"];
        string tid = Request.Form["types"];
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


        string sql = "update movieList set mname='" + movieName + "',img='" + imgUrl + "',url='" + moivesUrl + "',brief='" + movieBrief + "',tid=" + tid + " where id=" + Request.QueryString["id"];

        
        int n = DBHelper.exeDML(sql);
        if (n > 0)
        {
            Response.Write("<script>alert('电影修改成功');</script>");
            Response.Redirect("~/admin/movieEdit.aspx");
        }
        else { Response.Write("<script>alert('电影修改失败');</script>"); }

    }
}
