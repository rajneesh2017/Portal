<%@ Page Title="" Language="C#" MasterPageFile="./Portal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Portal.Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
   <br /><br /><br /><br /><br /><br /><br /><br />
    <div id="df" class="text-center" style="vertical-align: middle; text-align: center; " >
        
            
                <h1>Welcome to the<strong><span class="color" style="color:orangered;"> Blog Website</span></strong></h1>
                <p class="lead">
                    You can write your <strong style="color:darkslateblue;">story</strong> right away!<br />

                </p>

                <div class="container">
                    <div class="row">
                        <div class="col-sm-6">
                            <asp:HyperLink ID="HyperLink1" NavigateUrl="./SignUp.aspx" class="btn btn-block btn-lg btn-warning" runat="server" Style="color: black; font-size: 2em"><span class="fa fa-user-plus"></span>Sign Up</asp:HyperLink>
                        </div>
                        <div class="col-sm-6">
                            <asp:HyperLink ID="HyperLink2" NavigateUrl="./SignIn.aspx" class="btn btn-block btn-lg btn-success" runat="server" Style="color: black; font-size: 2em"><span class="fa fa-user-secret"></span>Sign In</asp:HyperLink>
                        </div>
                        
                    </div>
                    
                </div>

           
    </div>

<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>


