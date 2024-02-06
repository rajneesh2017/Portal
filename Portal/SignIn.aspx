<%@ Page Title="" Language="C#" MasterPageFile="Portal.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs"  Inherits="Portal.SignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <div class="row" style="margin-top: 20px">
            <div class="col-xs-12 col-sm-8 col-md-6 col-sm-offset-2 col-md-offset-3">
                <div role="form">
                    <fieldset>
                        <h2>Please Sign In</h2>
                        <hr class="colorgraph"/>
                        <div class="form-group">
                            <asp:TextBox type="email" name="email" ID="email" class="form-control input-lg" placeholder="Email Address" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="email" ForeColor="red" ErrorMessage="Required Field"></asp:RequiredFieldValidator>

                        </div>
                        <div class="form-group">
                            <asp:TextBox type="password" name="password" ID="password" class="form-control input-lg" placeholder="Password" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="password" ForeColor="red" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        
                            
                        </div>
                        <span class="button-checkbox">
                           <%-- <asp:Button ID="Button1" type="button" class="btn" data-color="info" runat="server" Text="Remember Me" />
                            <asp:CheckBox type="checkbox" name="remember_me" ID="remember_me" Checked="true" class="hidden" runat="server"></asp:CheckBox>--%>
                           <%-- <a class="btn btn-link pull-right" data-toggle="modal" data-target="#myModalHorizontal">Forgot Password?</a>--%>

                        </span>

                            <!-- Modal -->
<div class="modal fade" id="myModalHorizontal" tabindex="-1" role="dialog" 
     aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content" style="background-color:black;">
            <!-- Modal Header -->
            <div class="modal-header" style="background-color:black;">
                <button type="button" class="close" 
                   data-dismiss="modal">
                       <span aria-hidden="true">&times;</span>
                       <span class="sr-only">Close</span>
                </button>
                <h4 class="modal-title" id="myModalLabel" style="font-family:Georgia;color:white">
                    Forget Password
                </h4>
            </div>
            
            <!-- Modal Body -->
            <div class="modal-body" style="background-color:black">
                
              
                  <div class="form-group">
                    <label  class="col-sm-2 control-label" style="font-family:Georgia;color:white"
                              for="inputEmail3">Email</label>
                      <div class="col-sm-6">
                   <asp:TextBox ID="TextBox1" class="form-control" placeholder="Email" runat="server"></asp:TextBox></div>
                      <div class="col-sm-2">
                         <asp:Button ID="Button2"  class="btn btn-success" runat="server" Text="Recover" CausesValidation="False" OnClick="Button2_Click" />
                    </div>
                    </div>
                   
                    </div><br /><br />
                    


                  </div>
                  
                  </div>
           
                <br /><br />
                  
                
            </div>         
            
            
            
            
            
              <script type="text/javascript">
                  var str;
                  str = window.location.href;
                  var res = str.substr(str.lastIndexOf("#") + 1, 7);
                  if (res == "success") {
                      $(window).load(function () {
                          $('#success').modal('show');
                      });
                  }
                                    </script>


                                     <!--<a class="btn btn-success" id="successModalID" href="#success" data-toggle="modal"></a>-->
                                    
                                    
                                    <!-- Modal -->
                                    <div class="modal fade" id="success" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header modal-header-success">
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                                    <h3><i class="glyphicon glyphicon-thumbs-up"></i>Your password has been recovered. Check your email.</h3>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-danger pull-left" data-dismiss="modal">Close</button>
                                                </div>
                                            </div><!-- /.modal-content -->
                                        </div><!-- /.modal-dialog -->
                                  </div><!-- /.modal -->   
        
                         
                        <hr class="colorgraph"/>
                        <div class="row">
                            <div class="col-xs-6 col-sm-6 col-md-6">
                                <asp:Button runat="server" type="submit" class="btn btn-lg btn-success btn-block"  Text="Sign In" OnClick="Button_Click"></asp:Button>
                            </div>
                            <div class="col-xs-6 col-sm-6 col-md-6">
                                <a href="SignUp.aspx" class="btn btn-lg btn-primary btn-block">Register</a>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>

    </div>


                      

                     

                      

</asp:Content>
