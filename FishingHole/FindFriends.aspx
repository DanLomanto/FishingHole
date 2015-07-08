<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FindFriends.aspx.cs" Inherits="FishingHole.FindFriends" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid col-md-8 col-md-offset-2">
        <a href="ManageFriends.aspx" class="btn btn-primary"><i class="fa fa-arrow-circle-o-left"></i>&nbsp;Return to friends</a>
        <div class="top-buffer">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3>Search for Friends</h3>
                </div>
                <div class="panel-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="well">
                                <div class="form-inline">
                                    <div class="form-group">
                                        <label for="SearchFieldText" id="SearchFieldLabel">Search for friend by:</label>
                                        <div>
                                            <input type="text" id="SearchFieldText" runat="server" class="form-control" placeholder="Email or Name..." maxlength="50" />
                                            <asp:LinkButton ID="SearchBtn" runat="server" CssClass="btn btn-primary" OnClick="LoadSearchResults"><i class="fa fa-search"></i></asp:LinkButton>
                                            <a href="FindFriends.aspx" class="btn btn-default">Reset</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="requestSentConfirmation" runat="server" class="row" visible="false" style="white-space: nowrap">
                            <div class="text-center">
                                <span class="alert alert-info">Your friend request has been sent.</span>
                            </div>
                            <br />
                        </div>
                        <div class="row">
                            <div id="searchResultsContainer" runat="server" visible="false">
                                <h4>Search Results...</h4>
                                <div class="panel panel-default">
                                    <div class="panel-body">
                                        <div class="container-fluid" id="searchResults" runat="server">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <a href="ManageFriends.aspx" class="btn btn-primary"><i class="fa fa-arrow-circle-o-left"></i>&nbsp;Return to friends</a>
    </div>
    <input type="text" id="sendFriendRequestPersonId" runat="server" style="display: none" />
    <div class="modal fade" id="confirmSendRequest">
        <div class="modal-dialog" style="max-width: 375px; max-height: 200px">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Confirm Friend Request</h4>
                </div>
                <div class="modal-body">
                    <p>Are you sure you want to send a friend request to this person?</p>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="ConfirmSendFriendRequest" runat="server" CssClass="btn btn-primary" OnClick="SendFriendRequest">Confirm</asp:LinkButton>
                    <button type="button" class="btn btn-default" data-dismiss="modal" aria-hidden="true">Cancel</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>