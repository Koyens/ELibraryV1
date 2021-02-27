<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="ELibrary2.usersignup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="bg-danger py-3">
        <div class="container">
            <div class="row">
                <div class="col-md-8 mx-auto">
                    <div class="card bg-warning">
                        <div class="card-body">
                            <div class="card bg-success">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col">
                                            <center>
                                                <img src="imgs/add-friend.jpg" width="150px" />
                                            </center>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <center>
                                                <h2>User Registration</h2>
                                            </center>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <div class="progress">
                                                <div class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 100%;"></div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <label>Full Name</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" placeholder="Name" ID="TextBoxFullName" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Date of Birth</label>
                                                <asp:TextBox CssClass="form-control" ID="TextBoxBirthdate" TextMode="Date" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Contact</label>
                                                <asp:TextBox CssClass="form-control" placeholder="Contact Number" TextMode="Number" ID="TextBoxContact" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Email</label>
                                                <asp:TextBox CssClass="form-control" placeholder="Email Address" TextMode="Email" ID="TextBoxEmail" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label>State</label>
                                                <asp:DropDownList CssClass="form-control" ID="DropDownListState" runat="server">
                                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                                    <asp:ListItem Text="Banilad" Value="Banilad"></asp:ListItem>
                                                    <asp:ListItem Text="Talamban" Value="Talamban"></asp:ListItem>
                                                    <asp:ListItem Text="Bacayan" Value="Bacayan"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label>City</label>
                                                <asp:TextBox CssClass="form-control" placeholder="City" ID="TextBoxCity" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label>Code</label>
                                                <asp:TextBox CssClass="form-control" placeholder="Zip Code" ID="TextBoxCode" TextMode="Number" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <div class="form-group">
                                                <label>Address</label>
                                                <asp:TextBox CssClass="form-control" placeholder="Full Address" ID="TextBoxAddress" TextMode="MultiLine" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <center>
                                                <span class="badge badge-pill badge-primary">Login Credentials</span>
                                            </center>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label>User ID</label>
                                                <asp:TextBox CssClass="form-control" placeholder="User ID" ID="TextBoxUserID" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label>Password</label>
                                                <asp:TextBox CssClass="form-control" placeholder="Password" ID="TextBoxPassword" TextMode="Password" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label>Confirm</label>
                                                <asp:TextBox CssClass="form-control" placeholder="Confirm Password" ID="TextBoxConfirmPassword" TextMode="Password" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <div class="form-group">
                                                <button type="button" class="btn btn-primary btn-block" data-toggle="modal" data-target="#staticBackdrop">
                                                    Sign Up
                                                </button>

                                                <!-- Modal -->
                                                <div class="modal fade" id="staticBackdrop" data-backdrop="static" data-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                                                    <div class="modal-dialog modal-dialog-centered">
                                                        <div class="modal-content bg-warning">
                                                            <div class="modal-header">
                                                                <h5 class="modal-title" id="staticBackdropLabel">Sign Up Confirmation</h5>
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                    <span aria-hidden="true">&times;</span>
                                                                </button>
                                                            </div>
                                                            <div class="modal-body">
                                                                Are you sure to continue signing up?
                                                            </div>
                                                            <div class="modal-footer">
                                                                <button type="button" class="btn btn-secondary" data-dismiss="modal">No</button>
                                                                <asp:Button CssClass="btn btn-primary" ID="ButtonSignupYes" runat="server" Text="Yes" OnClick="ButtonSignupYes_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <a class="text-primary text-decoration-none" href="homepage.aspx"><< Go Home</a>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
