<%@ Page Title="" Language="C#" MasterPageFile="./Portal.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Portal.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">

        <div class="row">
            <div class="col-xs-12 col-sm-8 col-md-6 col-sm-offset-2 col-md-offset-3">
                <div role="form">
                    <h2>Create Your Account <small style="color:lawngreen">It's free and always will be.</small></h2>
                    <hr class="colorgraph"/>
                    <div class="row">
                        <div class="col-xs-12 col-sm-6 col-md-6">
                            <div class="form-group">
                                <asp:TextBox name="first_name" ID="first_name" class="form-control input-lg" placeholder="First Name" TabIndex="1" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="first_name" ErrorMessage="Required Field" ForeColor="red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-6 col-md-6">
                            <div class="form-group">
                                <asp:TextBox runat="server" type="text" name="last_name" ID="last_name" class="form-control input-lg" placeholder="Last Name" TabIndex="2"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="last_name" ErrorMessage="Required Field" ForeColor="red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <%--<div class="form-group">
				<asp:TextBox runat="server" type="text" name="display_name" id="display_name" class="form-control input-lg" placeholder="Display Name" tabindex="3">
			</asp:TextBox>
            </div>--%>
                    <div class="row">
                        <div class="col-sm-8">
                    <div class="form-group">
                        <asp:TextBox runat="server" type="email" name="email" ID="email" OnTextChanged="CheckUniqueEmail" AutoPostBack="true" class="form-control input-lg" placeholder="Email Address" TabIndex="4"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="emailValidator" runat="server" display="Dynamic" ForeColor="red" ErrorMessage="Enter Email e.g. abc@def.com" ControlToValidate="email" ValidationExpression="^[_\w\-]+(\.[_\w\-]+)*@[\w\-]+(\.[\w\-]+)*(\.[\D]{2,3})$"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="email" ForeColor="red" ErrorMessage="Enter Email e.g. abc@def.com"></asp:RequiredFieldValidator>
                        

                    </div>
                    </div>
                        <div class="form-group">
                         <div id="emailErrorId" runat="server" visible="false" class="col-sm-4">
                                            <asp:Label ID="Label4" class="form-control" Font-Size="smaller"
                                                 Font-Italic="true" ForeColor="Black" Font-Bold="true" BackColor="Red"
                                                 runat="server" Text=""></asp:Label>
                                        </div>
                                        <div id="emailErrorId2" runat="server" visible="false" class="col-sm-4">
                                            <asp:Label ID="Label5" class="form-control"
                                                 Font-Italic="true" ForeColor="Black"  Font-Bold="true" BackColor="Green"
                                                 runat="server" Text=""></asp:Label>
                                        </div></div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 col-sm-6 col-md-6">
                            <div class="form-group">
                                <asp:TextBox runat="server" type="password" name="password" ID="password" class="form-control input-lg" placeholder="Password" TabIndex="5"></asp:TextBox>
                                
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" display="Dynamic" ForeColor="red" ErrorMessage="Use at least 8 characters." ControlToValidate="password" ValidationExpression="^(?=).{8,}$"></asp:RegularExpressionValidator>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="password" ForeColor="red" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-6 col-md-6">
                            <div class="form-group">
                                <asp:TextBox runat="server" type="password" name="password_confirmation" ID="password_confirmation" class="form-control input-lg" placeholder="Confirm Password" TabIndex="6">
                                </asp:TextBox><asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="smaller" Font-Names="Georgia" 
                                    ErrorMessage="Password & Confirm Password must be same" ControlToCompare="password_confirmation"
                                    ControlToValidate="password" Display="Dynamic"></asp:CompareValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                       <%-- <div class="col-xs-4 col-sm-3 col-md-3">
                            <span class="button-checkbox">
                            <asp:Button ID="Button1" class="btn" data-color="info" TabIndex="7" runat="server" Text="I Agree" />
                                <asp:CheckBox type="checkbox" name="t_and_c" ID="t_and_c" class="hidden" value="1" runat="server" />
                            </span>
                        </div>--%>
                        <div class="col-xs-8 col-sm-9 col-md-9">
                            By clicking <strong class="label label-primary">Sign Up</strong>, you agree to the <a href="#" data-toggle="modal" data-target="#t_and_c_m">Terms and Conditions</a> set out by this site, including our Cookie Use.
                        </div>
                    </div>

                    <hr class="colorgraph"/>
                    <div class="row">
                        <div class="col-xs-12 col-md-6">
                            <asp:Button ID="Button2" type="submit" AutoPostBack="true" OnClick="signUp" class="btn btn-primary btn-block btn-lg" TabIndex="7" runat="server" Text="Sign Up" />
                        </div>
                        <div class="col-xs-12 col-md-6"><a href="SignIn.aspx" class="btn btn-success btn-block btn-lg">Sign In</a></div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Modal -->
        <div class="modal fade" id="t_and_c_m" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title" id="myModalLabel">Terms & Conditions</h4>
                    </div>
                    <div class="modal-body">
                       <p>By using our Services, you are agreeing to these terms. Please read them carefully.</p>

                        <p>Our Services are very diverse, so sometimes additional terms or product requirements 
                            (including age requirements) may apply. Additional terms will be available with the relevant Services, 
                            and those additional terms become part of your agreement with us if you use those Services.</p>
                        
                        <p>Using our Services does not give you ownership of any intellectual property rights in our Services or 
                            the content you access. You may not use content from our Services unless you obtain permission from 
                            its owner or are otherwise permitted by law. These terms do not grant you the right to use any branding
                             or logos used in our Services. Don’t remove, obscure, or alter any legal notices displayed in or along
                             with our Services.</p>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
    </div>
</asp:Content>
