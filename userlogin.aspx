<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="ELibrary2.userlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="bg-secondary py-3">
        <div class="container">
            <div class="row">
                <div class="col-xs-10 col-sm-8 col-md-6 mx-auto">
                    <div class="card">
                        <div class="card-body bg-info">
                            <div class="row">
                                <div class="col">
                                    <center>
                                        <img src="imgs/incognito.png" width="150px" />
                                    </center>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <center>
                                        <h2>Member Login</h2>
                                    </center>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" placeholder="Member ID" ID="TextBoxMemberID" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" placeholder="Password" TextMode="Password" ID="TextBoxMemberPassword" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <asp:Button CssClass="btn btn-secondary btn-block btn-lg" ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <a href="usersignup.aspx"><asp:Button CssClass="btn btn-dark btn-block btn-lg" ID="ButtonSignup" runat="server" Text="Sign Up" /></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <a class="text-dark text-decoration-none" href="homepage.aspx"><< Go Home</a>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
