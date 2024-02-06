<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true" CodeBehind="UpdateProfilePage.aspx.cs" Inherits="Portal.UpdateProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">

        <div class="row">
            <div class="col-xs-12 col-sm-8 col-md-6 col-sm-offset-2 col-md-offset-3">
                <div role="form">
                    <h2><span style="color:lawngreen">Edit and Update your Profile</span>  <small style="color:firebrick">Email is your unique ID and hence, it cannot be changed.</small></h2>
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
                        <asp:TextBox runat="server" type="email" name="email" ID="email"  AutoPostBack="true" class="form-control input-lg" placeholder="Email Address" TabIndex="4">
                        </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="email" ForeColor="red" ErrorMessage="Enter Email e.g. abc@def.com"></asp:RequiredFieldValidator>
                    </div>
                    </div>
                        <%--<div class="form-group">
                         <div id="emailErrorId" runat="server" visible="false" class="col-sm-4">
                                            <asp:Label ID="Label4" class="form-control" Font-Size="smaller"
                                                 Font-Italic="true" ForeColor="Black" Font-Bold="true" BackColor="Red"
                                                 runat="server" Text=""></asp:Label>
                                        </div>
                                        <div id="emailErrorId2" runat="server" visible="false" class="col-sm-4">
                                            <asp:Label ID="Label5" class="form-control"
                                                 Font-Italic="true" ForeColor="Black"  Font-Bold="true" BackColor="Green"
                                                 runat="server" Text=""></asp:Label>
                                        </div></div>--%>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 col-sm-6 col-md-6">
                            <div class="form-group">
                                <asp:TextBox runat="server" type="password" name="password" ID="password" class="form-control input-lg" placeholder="Password" TabIndex="5">
                                </asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" display="Dynamic" ForeColor="red" ErrorMessage="Use at least 8 characters." ControlToValidate="password" ValidationExpression="^(?=).{8,}$"></asp:RegularExpressionValidator>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="password" ForeColor="red" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-6 col-md-6">
                            <div class="form-group">
                                <asp:TextBox runat="server" type="password" name="password_confirmation" ID="password_confirmation" class="form-control input-lg" placeholder="Confirm Password" TabIndex="6">
                                </asp:TextBox><asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="smaller" Font-Names="Georgia" 
                                    ErrorMessage="Password & Confirm Password must be same" ControlToCompare="password_confirmation"
                                    ControlToValidate="password"></asp:CompareValidator>
                            </div>
                        </div>
                    </div>
                    

                    <hr class="colorgraph"/>
                    <div class="row">
                        <div class="col-xs-12 col-md-6">
                            <asp:Button ID="Button2"  OnClick="update" type="submit" AutoPostBack="true" class="btn btn-primary btn-block btn-lg" TabIndex="7" runat="server" Text="Update" />
                        </div>
                        <div class="col-xs-12 col-md-6"><a href="Welcome.aspx" class="btn btn-success btn-block btn-lg">Cancel</a></div>
                    </div>

                    <div class="row">
                        <div class="col-xs-12">

                            <asp:Label ID="Label1" runat="server" Text="" Font-Size="Large" forecolor="green" ></asp:Label>

                        </div>
                      </div>
                </div>
            </div>
        </div>
        
    </div>



</asp:Content>
