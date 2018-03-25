<%@ Page Language="C#" MasterPageFile="~/ADMINmaster.master" AutoEventWireup="true" CodeFile="sortManage.aspx.cs" Inherits="admin_sortManage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="content">
 
 <form action="sortManage.aspx" method="post">
    <table style="margin-left:50px; margin-top:50px;text-align:center">
        <thead>
            <tr>
                <th  style="border:1px solid #666; text-align:center" width="200"; height="50">id</th>
                <th  style="border:1px solid #666;text-align:center" width="200" height="50">类别</th>
                <th  style="border:1px solid #666;text-align:center" width="200" height="50">进行删除</th>
            </tr>
            <%=tdout %>
            
        </thead>
    
    </table>
 </form>
 </div>
</asp:Content>

