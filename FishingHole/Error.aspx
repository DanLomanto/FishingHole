<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="FishingHole.Error" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container top-buffer">
        <div class="col-md-6 col-md-offset-3">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="text-center"><span><i class="fa fa-3x fa-exclamation-triangle"></i></span></div>
                    <br />
                    <div class="well">
                        <p class="has-error">An unexpected error has occurred. We have logged the error and are sorry for the inconvenience. Please login and try again.</p>
                    </div>
                    <div class="text-center">
                        <a href="Login.aspx">Return to login page</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>