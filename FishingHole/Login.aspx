<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FishingHole.Login" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="LoginPage" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container top-buffer">
        <div class="col-md-6 col-md-offset-3">
            <div class="panel panel-default" style="min-width: 350px">
                <div class="panel-heading text-center">
                    <h3>Welcome to the Fishing Hole!</h3>
                </div>
                <div class="panel-body">
                    <div class="container-fluid">
                        <div class="row text-center">
                            <img src="images/FishLogo.jpg" height="225" width="300" />
                        </div>
                        <div class="row col-md-8 col-md-offset-2">
                            <asp:BulletedList ID="formErrors" runat="server" CssClass="no-bullets list-group-item-danger center-block text-center" />
                        </div>
                        <div class="row top-buffer">
                            <div class="form-group">
                                <label for="emailInput" class="col-md-3 control-label">Email:</label>
                                <div class="col-md-9">
                                    <input type="email" runat="server" id="emailInput" class="form-control" placeholder="Email" />
                                </div>
                            </div>
                        </div>
                        <div class="row top-buffer">
                            <div class="form-group">
                                <label for="passwordInput" class="col-md-3 control-label">Password:</label>
                                <div class="col-md-9">
                                    <input type="password" runat="server" id="passwordInput" class="form-control" placeholder="Password" />
                                </div>
                            </div>
                        </div>
                        <div class="row top-buffer">
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <asp:Button ID="SignInButton" runat="server" Text="Sign In" CssClass="btn btn-m btn-primary btn-block" OnClick="SignInButtonClick"></asp:Button>
                                </div>
                            </div>
                        </div>
                        <div class="row text-center top-buffer">
                            <a href="NewUser.aspx" class="text-center new-account">Create an account </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        function hitEnterOnSignInButton() {
            $("#emailInput").keyup(function (event) {
                if (event.keyCode == 13) {
                    $("#SignInButton").click();
                }
            });

            $("#passwordInput").keyup(function (event) {
                if (event.keyCode == 13) {
                    $("#SignInButton").click();
                }
            });
        }
    </script>
</asp:Content>