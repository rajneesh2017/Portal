<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true" CodeBehind="DisplayBlog.aspx.cs" Inherits="Portal.DisplayBlog" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>
    <asp:Label ID="lblTitle" runat="server" /></h2>
<hr />
<asp:Label ID="lblBody" runat="server" style="font-size:large"/>
</asp:Content>
