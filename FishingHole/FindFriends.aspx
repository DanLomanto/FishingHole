<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FindFriends.aspx.cs" Inherits="FishingHole.FindFriends" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid col-md-8 col-md-offset-2">
        <div class="panel panel-default" id="FriendRequestPanel" runat="server" visible="false">
            <div class="panel-heading">
                <h3>Search for Friends</h3>
            </div>
            <div class="panel-body">
            </div>
        </div>
    </div>
</asp:Content>