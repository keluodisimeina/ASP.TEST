<%@ Page Language="C#" MasterPageFile="~/ADMINmaster.master" AutoEventWireup="true" CodeFile="videoupload.aspx.cs" Inherits="admin_videoupload" Title="Untitled Page"  validateRequest=false %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form id="form3"  runat="server">
  <div class="content">
 	
            <div class="dianying"  runat="server">
            	<p><span>电影名称:&nbsp;&nbsp;&nbsp;&nbsp;</span><input style=" width: 293px;height:40px; line-height:40px;" name="movieName" type="text"/></p>
                    
                    <p><span>选择分类:&nbsp;&nbsp;&nbsp;&nbsp;</span>
                        <select class="select" name="types">
                        <option selected="selected">电影类型</option>
                        <%=showType%>
    </select>
                        
                    </p>
                <p style="float:left;"><span>上传图片:&nbsp;&nbsp;&nbsp;&nbsp;</span></p><p style="float:left; margin-top:10px;"><asp:FileUpload ID="FileUpload1" runat="server"  onchange="changImg(event)"  /><img alt="" id="myImg" src="" height="100px",width="100px" style=" margin-top:10px">  </p>
                   <div  style=" clear:both"></div>
                <p style="float:left;"><span>上传视频:&nbsp;&nbsp;&nbsp;&nbsp;</span></p><p style="float:left; margin-top:10px;"><asp:FileUpload ID="FileUpload2" runat="server" style="" /></p>
                <div  style=" clear:both"></div>
                <p><span>电影简介:&nbsp;&nbsp;&nbsp;&nbsp;</span></p>
                <textarea rows="4" style=" width:480px; overflow:scroll; overflow-x:hidden; height:90px; line-height:6px"  id="Text1" name="movieBrief"></textarea>
                <input style=" margin:10px 90px; width:293px; height:40px; background:#27a9e3; color:White; border:none; border-radius:25px" type="button" id= "btnSubmit" value="提交" runat="server" onfocus="content()" onserverclick="Button1_Click1"/>
            
                
</div>
 
 </div>
</form>
<script type="text/javascript">  
     function changImg(e){  
        for (var i = 0; i < e.target.files.length; i++) {  
            var file = e.target.files.item(i);  
            if (!(/^image\/.*$/i.test(file.type))) {  
                continue; //不是图片 就跳出这一次循环  
            }  
            //实例化FileReader API  
            var freader = new FileReader();  
            freader.readAsDataURL(file);  
            freader.onload = function(e) {  
                $("#myImg").attr("src",e.target.result);  
            }  
        }  
    }  
</script> 
<script>
function content()
{

   
    var fff=$(".nicEdit-main").html();
    
      
    var oT=document.getElementById("Text1")
    oT.innerText=fff
}

</script>


<!--http://bbs.csdn.net/topics/390303980-->
</asp:Content>

