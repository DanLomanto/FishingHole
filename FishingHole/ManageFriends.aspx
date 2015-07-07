﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageFriends.aspx.cs" Inherits="FishingHole.ManageFriends" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid col-md-8 col-md-offset-2">
        <div class="panel panel-default" id="FriendRequestPanel" runat="server" visible="false">
            <div class="panel-heading">
                <h3>Manage Friend Requests</h3>
            </div>
            <div class="panel-body">
                <div class="container-fluid" id="FriendRequestContainer" runat="server">
                    <div class="row">
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-4 col-md-3">
                                <div class="well user-padding">
                                    <div class="row text-center">
                                        <span><strong>Dan Lomanto</strong></span>
                                    </div>
                                    <div class="row text-center">
                                        <span>something@gmail.com</span>
                                    </div>
                                    <div class="row text-center top-buffer">
                                        <button type="button" data-toggle="modal" data-target="#acceptFriendRequestModal" class="btn-sm btn-primary" onclick="document.getElementById('MainContent_acceptedFriendRequestId').value = '33';\">Accept Request</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="btn-group pull-right" style="padding-top: 15px;">
                    <a href="Location.aspx?id=0&returnUrl=locations" id="AddLocation" runat="server" class="btn btn-large btn-primary"><i class="glyphicon glyphicon-search"></i>&nbsp;Find Friends</a>
                </div>
                <h3>Manage Friends</h3>
            </div>
            <div class="panel-body">
                <div class="container-fluid" id="FriendsList" runat="server">
                </div>
            </div>
        </div>
    </div>
    <input type="text" id="selectedFriendId" runat="server" style="display: none" />
    <input type="text" id="acceptedFriendRequestId" runat="server" style="display: none" />
    <div class="modal fade" id="confirmDeletionModal">
        <div class="modal-dialog" style="max-width: 375px; max-height: 200px">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Delete Confirmation</h4>
                </div>
                <div class="modal-body">
                    <p>Are you sure you want to remove this friend?</p>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="DeleteSelectedPhotos" runat="server" CssClass="btn btn-primary" OnClick="DeleteFriend">Confirm</asp:LinkButton>
                    <button type="button" class="btn btn-default" data-dismiss="modal" aria-hidden="true">Cancel</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="acceptFriendRequestModal">
        <div class="modal-dialog" style="max-width: 375px; max-height: 200px">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Accept Request</h4>
                </div>
                <div class="modal-body">
                    <p>Are you sure you want to connect with this friend?</p>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="AcceptFriendRequestBtn" runat="server" CssClass="btn btn-primary" OnClick="AcceptFriendRequest">Accept</asp:LinkButton>
                    <button type="button" class="btn btn-default" data-dismiss="modal" aria-hidden="true">Cancel</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>