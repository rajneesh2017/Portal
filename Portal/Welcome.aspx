<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="Portal.Welcome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    









    <h3 style="color:aqua;text-align:center;">My Blogs</h3>

   
<br />
<div class="col-xs-12 col-sm-6 col-md-3">

        <a href="AddBlog.aspx" class="btn btn-lg btn-primary btn-block">Add a Blog</a>

    </div>
    
    <div class="col-xs-12 col-sm-6 col-md-3">

        <a href="UpdateProfilePage.aspx" class="btn btn-lg btn-primary btn-block">Update Profile</a>

    </div>
    
    <br /><br />
<hr />
<asp:Repeater ID="rptPages" runat="server">
    <ItemTemplate>
       
        <table>
            <tr>
                <td style="font-size:x-large"> <%# Container.ItemIndex + 1 %><asp:HyperLink ID="HyperLink2" NavigateUrl='<%# string.Format("~/Blogs/{0}/{1}.aspx", Eval("BlogId"), Eval("Slug")) %>'
            Text='<%# Eval("Title") %>' runat="server"  forecolor="#00ff00" style="padding-left:10px" /> </td>


          <td style="padding-left:25px; padding-right:15px; font-size:large"><asp:HyperLink ID="HyperLink1" NavigateUrl='<%# string.Format("~/Blogs/{0}.aspx", Eval("BlogId"), Eval("Slug")) %>'
            Text="Edit | Delete" runat="server" forecolor="Red"/></td>      

            </tr>
        </table>
          
        
    </ItemTemplate>
    <SeparatorTemplate>
        <br />
    </SeparatorTemplate>
</asp:Repeater>


   

</asp:Content>
