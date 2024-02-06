<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true" validateRequest="false"
    CodeBehind="AddBlog.aspx.cs" Inherits="Portal.AddBlog" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-8 col-md-6 col-sm-offset-2 col-md-offset-3">
                    <div role="form">
                        <h2>Way to go! <small style="color:lawngreen">Write your Blog.</small></h2>
                        <hr class="colorgraph" />

                        <div class="row">
                            <div class="col-xs-8">
                                <div class="form-group">
                                    <asp:TextBox name="blgID" ID="blgID" class="form-control input-lg"
                                        placeholder="Unique Blog Id" OnTextChanged="CheckUniqueBlogID"
                                        AutoPostBack="true" TabIndex="1" width="300" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                        ControlToValidate="blgID" ErrorMessage="Required Field" ForeColor="red">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <div id="blogErrorId" runat="server" visible="false" class="col-sm-4">
                                    <asp:Label ID="Label4" class="form-control" Font-Size="smaller" Font-Italic="true"
                                        ForeColor="Black" Font-Bold="true" BackColor="Red" runat="server" Text="">
                                    </asp:Label>
                                </div>
                                <div id="blogErrorId2" runat="server" visible="false" class="col-sm-4">
                                    <asp:Label ID="Label5" class="form-control" Font-Italic="true" ForeColor="Black"
                                        Font-Bold="true" BackColor="Green" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <asp:TextBox name="title" ID="title" class="form-control input-lg"
                                        placeholder="title" TabIndex="1" width="500" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="title" ErrorMessage="Required Field" ForeColor="red">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <asp:TextBox name="body" ID="body" class="form-control input-lg"
                                        placeholder="Write your Blog here" textmode="MultiLine" TabIndex="1"
                                        runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 col-md-6">
                                <asp:Button ID="Button2" type="submit" AutoPostBack="true"
                                    class="btn btn-primary btn-block btn-lg" TabIndex="7" runat="server" Text="Submit"
                                    OnClick="Button2_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript" src="//tinymce.cachefly.net/5.0/tinymce.min.js"></script>
        <script type="text/javascript">
            tinymce.init({ selector: 'textarea' });
        </script>
    </asp:Content>