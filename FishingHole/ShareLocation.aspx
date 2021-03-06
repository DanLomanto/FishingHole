﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ShareLocation.aspx.cs" Inherits="FishingHole.ShareLocation" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid col-md-8 col-md-offset-2">
        <a href="Locations.aspx" class="btn btn-primary"><i class="fa fa-arrow-circle-o-left"></i>&nbsp;Return to all locations</a>
        <div class="top-buffer">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3>Share a Location</h3>
                </div>
                <div class="panel-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-8 col-md-offset-2">
                                <asp:BulletedList ID="formErrors" runat="server" CssClass="no-bullets list-group-item-danger center-block text-center" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-inline">
                                <label>Select a location to share:</label>
                                <asp:DropDownList ID="locationsDropDown" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row top-buffer">
                            <div class="form-inline">
                                <label>Select a person to share the location with:</label>
                                <asp:DropDownList ID="friendsDropDown" runat="server" class="form-control"></asp:DropDownList>
                                <a href="#" class="btn btn-primary" onclick="AddPerson();"><i class="fa fa-plus-square"></i>&nbsp;Add to List</a>
                            </div>
                        </div>
                        <div class="row top-buffer">
                            <h4>Share location with:</h4>
                            <div class="panel panel-default">
                                <div id="selectedFriends" class="panel-body">
                                    <span id="NoFriendsSelectedMessage">You have not selected any friends yet...</span>
                                </div>
                            </div>
                        </div>
                        <div id="LocationSharedNotification" runat="server" class="row">
                            <div class="text-center">
                                <span class="alert alert-info">Location shared.&nbsp;<i class="fa fa-check"></i></span>
                            </div>
                        </div>
                        <div class="row top-buffer text-center">
                            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#confirmLocationShare">Share Location&nbsp;<i class="fa fa-share-square-o"></i></button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <a href="Locations.aspx" class="btn btn-primary"><i class="fa fa-arrow-circle-o-left"></i>&nbsp;Return to all locations</a>
    </div>
    <input id="selectedPeople" runat="server" type="text" value="|" style="display: none;" />
    <div class="modal fade" id="confirmLocationShare">
        <div class="modal-dialog" style="max-width: 375px; max-height: 200px">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Share Location</h4>
                </div>
                <div class="modal-body">
                    <p>Are you sure you want to share this location?</p>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary" OnClick="ShareLocationWithFriends_Click">Confirm</asp:LinkButton>
                    <button type="button" class="btn btn-default" data-dismiss="modal" aria-hidden="true">Cancel</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        var addedPeople = [];

        function AddPerson() {
            var personDropDown = document.getElementById("MainContent_friendsDropDown");
            var name = personDropDown.options[personDropDown.selectedIndex].text;
            var idOfSelectedPerson = personDropDown.options[personDropDown.selectedIndex].value;

            if (idOfSelectedPerson < 0)
            { return; }

            var isPersonAlreadyAdded = false;
            if (addedPeople.length > 0) {
                for (var i = addedPeople.length - 1; i >= 0; i--) {
                    if (addedPeople[i] === name) {
                        isPersonAlreadyAdded = true;
                        break;
                    }
                }
            }
            if (!isPersonAlreadyAdded) {

                document.getElementById("NoFriendsSelectedMessage").style.display = "none";

                addedPeople.push(name);

                $('#selectedFriends').append("<div class=\"col-xs-12 col-sm-3 col-md-2\">" +
                                            "<div class=\"well user-padding\">" +
                                                "<div class=\"row\">" +
                                                    "<button type=\"button\" data-toggle=\"modal\" data-target=\"#confirmDeletionModal\" class=\"close pull-right\" onclick=\"DeleteAddedPerson(this, '" + name + "', " + idOfSelectedPerson + ");\">&times;</button>" +
                                                "</div>" +
                                                "<div class=\"row text-center\">" +
                                                    "<span><strong>" + name + "</strong></span>" +
                                                "</div>" +
                                            "</div>" +
                                        "</div>");

                document.getElementById('MainContent_selectedPeople').value = document.getElementById('MainContent_selectedPeople').value + idOfSelectedPerson + "|";
            }

        };

        function DeleteAddedPerson(element, name, id) {

            // Remove the person from the added list.
            if (addedPeople.length > 0) {
                for (var i = addedPeople.length - 1; i >= 0; i--) {
                    if (addedPeople[i] === name) {
                        addedPeople.splice(i, 1);
                        break;
                    }
                }
            }

            // Remove the person from the selected list.
            document.getElementById('MainContent_selectedPeople').value = document.getElementById('MainContent_selectedPeople').value.replace("|" + id + "|", "|")

            // Remove the html element.
            element.parentNode.parentNode.parentNode.parentNode.removeChild(element.parentNode.parentNode.parentNode);

            if (addedPeople.length == 0) {
                document.getElementById("NoFriendsSelectedMessage").style.display = "";
            }
        };
    </script>
</asp:Content>