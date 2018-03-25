<%@ Page Language="C#" MasterPageFile="~/ADMINmaster.master" AutoEventWireup="true" CodeFile="movieEdit.aspx.cs" Inherits="admin_movieEdit" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form id="form4"  method="post" action="movieEdit.aspx">

<div class="content" align="center">

 	<p style=" margin:15px 0;">
           <select class="select" name="types">
                        <option selected="selected" value="">电影类型</option>
                        <%=type %>
                        
    </select>
    <input type="text" name="search"  style=" width:300px;"/>
                      <a href="javascript:search();">搜索</a>
                      <a href="videoupload.aspx">上传视频</a>
                      
                      </p>
                      
                      

<div style="overflow:scroll; height:610px; width:660px;overflow:auto;"> 
<table  border="1">
  <tr>
    <th height="35px" style="border:none; width:50px;">选中</th>
    <th width="120px">电影名称</th>
    <th>电影封面</th><th width="100px;">电影类别</th><th width="180px">上传时间</th><th width="180px">操作</th>
  </tr>
  <%=showTable %>
</table>
</div>
</div>                     

 <script>
        function search(){
            var form = document.getElementById('form4');
            form.action='movieEdit.aspx?action=search';
            form.submit();
        }
       </script>
</form>
</asp:Content>

