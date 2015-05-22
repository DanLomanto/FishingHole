﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewUser.aspx.cs" Inherits="NewUser" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container top-buffer" runat="server">
        <div class="col-md-8 col-md-offset-2">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3>Create Account</h3>
                </div>
                <div class="panel-body">
                    <div class="text-center">
                        <img src="images/FishLogo.jpg" height="225" width="300" />
                    </div>
                    <div style="padding: 5px 5px 5px 25%;">
                        <asp:BulletedList ID="formErrors" runat="server" />
                    </div>
                    <div class="row">
                        <div class="col-md-8">Please enter the following information:</div>
                    </div>
                    <div class="row top-buffer">
                        <label for="firstNameInput" class="col-md-3 control-label">First Name:</label>
                        <div class="col-sm-9">
                            <input class="form-control" runat="server" type="text" id="firstNameInput" placeholder="First Name" />
                        </div>
                    </div>
                    <div class="row top-buffer">
                        <label for="lastNameInput" class="col-md-3 control-label">Last Name:</label>
                        <div class="col-sm-9">
                            <input class="form-control" runat="server" type="text" id="lastNameInput" placeholder="Last Name" />
                        </div>
                    </div>
                    <div class="row top-buffer">
                        <label for="emailInput" class="col-md-3 control-label">Email:</label>
                        <div class="col-sm-9">
                            <input class="form-control" runat="server" type="email" id="emailInput" placeholder="Email" />
                        </div>
                    </div>
                    <div class="row top-buffer">
                        <label for="passwordInput" class="col-md-3 control-label">Password:</label>
                        <div class="col-sm-9">
                            <input class="form-control" runat="server" type="password" id="passwordInput" placeholder="Password" />
                            <em>Password must be between 8 and 15 characters, contain at least one uppercase letter, one lowercase letter, and one number.</em>
                        </div>
                    </div>
                    <div class="row">
                        <label for="confirmPasswordInput" class="col-md-3 control-label">Confirm Password:</label>
                        <div class="col-sm-8">
                            <input class="form-control" runat="server" type="password" id="confirmPasswordInput" placeholder="Confirm Password" />
                        </div>
                    </div>
                    <div class="row top-buffer">
                        <div class="col-md-6 col-md-offset-3">
                            <asp:Button ID="createAccountButton" runat="server" Text="Create Account" CssClass="btn btn-m btn-primary btn-block" OnClick="CreateAccountButtonClick" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-center">
                            <a href="Login.aspx" class="new-account">Back to login page</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        $(document).ready(function () {
            var navMenu = document.getElementById('navMenu');
            navMenu.style.display = 'none';
        });

        function hitEnterOnCreateAccountButton() {
            $("#firstNameInput").keyup(function (event) {
                if (event.keyCode == 13) {
                    $("#SignInButton").click();
                }
            });

            $("#lastNameInput").keyup(function (event) {
                if (event.keyCode == 13) {
                    $("#SignInButton").click();
                }
            });

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

            $("#confirmPasswordInput").keyup(function (event) {
                if (event.keyCode == 13) {
                    $("#SignInButton").click();
                }
            });
        }
    </script>
</asp:Content>