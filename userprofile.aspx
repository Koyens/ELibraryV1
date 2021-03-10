<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="ELibrary2.userprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="bg-dark py-2">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-5">
                    <div class="card bg-danger border-warning">
                        <div class="card-body">
                            <div class="card border-warning">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col">
                                            <center>
                                                <img src="imgs/user-male.png" width="100px" />
                                            </center>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <center>
                                                <h3>User Profile</h3>
                                            </center>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <center>
                                                <span>Account Status &diams; <asp:Label class="badge badge-pill badge-success" ID="LabelStatus" runat="server" Text="Active"></asp:Label></span>
                                            </center>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <hr />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xl-6">
                                            <div class="form-group">
                                                <label>Full Name</label>
                                                <asp:TextBox CssClass="form-control" ID="TextBoxFullName" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-xl-6">
                                            <div class="form-group">
                                                <label>Date of Birth</label>
                                                <asp:TextBox CssClass="form-control" TextMode="Date" ID="TextBoxBirthdate" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xl-6">
                                            <div class="form-group">
                                                <label>Contact Number</label>
                                                <asp:TextBox CssClass="form-control" TextMode="Number" ID="TextBoxContactNumber" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-xl-6">
                                            <div class="form-group">
                                                <label>Email</label>
                                                <asp:TextBox CssClass="form-control" TextMode="Email" ID="TextBoxEmail" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xl-4">
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
                                        <div class="col-xl-4">
                                            <div class="form-group">
                                                <label>City</label>
                                                <asp:TextBox CssClass="form-control" ID="TextBoxCity" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-xl-4">
                                            <div class="form-group">
                                                <label>Zip Code</label>
                                                <asp:TextBox CssClass="form-control" TextMode="Number" ID="TextBoxCode" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <div class="form-group">
                                                <label>Full Address</label>
                                                <asp:TextBox CssClass="form-control" ID="TextBoxAddress" TextMode="MultiLine" runat="server"></asp:TextBox>
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
                                        <div class="col-xl-4">
                                            <div class="form-group">
                                                <label>User ID</label>
                                                <asp:TextBox CssClass="form-control" Text="Koyen" ReadOnly="true" ID="TextBoxUserID" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-xl-4">
                                            <div class="form-group">
                                                <label>Old Password</label>
                                                <asp:TextBox CssClass="form-control" Text="123456" ReadOnly="true" ID="TextBoxOldPassword" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-xl-4">
                                            <div class="form-group">
                                                <label>New Password</label>
                                                <asp:TextBox CssClass="form-control" placeholder="New Password" ID="TextBoxNewPassword" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-8 mx-auto">
                                            <button type="button" class="btn btn-primary btn-block" data-toggle="modal" data-target="#staticBackdrop">
                                                Update
                                            </button>

                                            <!-- Modal -->
                                            <div class="modal fade" id="staticBackdrop" data-backdrop="static" data-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                                                <div class="modal-dialog modal-dialog-centered">
                                                    <div class="modal-content bg-warning">
                                                        <div class="modal-header">
                                                            <h5 class="modal-title" id="staticBackdropLabel">Update Confirmation</h5>
                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                <span aria-hidden="true">&times;</span>
                                                            </button>
                                                        </div>
                                                        <div class="modal-body">
                                                            Are you sure to continue updating your profile?
                                                        </div>
                                                        <div class="modal-footer">
                                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">No</button>
                                                            <asp:Button CssClass="btn btn-primary" ID="ButtonUpdateProfile" runat="server" Text="Yes" OnClick="ButtonUpdateProfile_Click" />
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
                    <a href="homepage.aspx" class="text-light text-decoration-none"><< Go Home</a>
                </div>
                <div class="col-md-7">
                    <div class="card bg-secondary">
                        <div class="card-body">
                            <div class="card">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col">
                                            <center>
                                                <img src="imgs/bks.png" width="164px" />
                                            </center>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <center>
                                                <h3>Your Issued Books</h3>
                                            </center>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <center>
                                                <span class="badge badge-pill badge-info">Primary</span>
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
                                            <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound">
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
