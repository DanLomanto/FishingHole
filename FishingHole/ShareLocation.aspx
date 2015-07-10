<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ShareLocation.aspx.cs" Inherits="FishingHole.ShareLocation" %>

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
                            <div class="form-inline">
                                <label>Select a location to share:</label>
                                <select class="form-control">
                                    <option>Please select a location...</option>
                                    <option>Location 1</option>
                                    <option>Location 2</option>
                                </select>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-inline">
                                <label>Select a person to share to:</label>
                                <select id="friendsDropDown" runat="server" class="form-control">
                                    <option value="0">Please select a Person...</option>
                                    <option value="1">Person 1</option>
                                    <option value="2">Person 2</option>
                                </select>
                                <a href="#" class="btn btn-primary" onclick="AddPerson();">Add to List</a>
                            </div>
                        </div>
                        <div class="row">
                            <h4>Share location with:</h4>
                            <div class="panel panel-default">
                                <div id="selectedFriends" class="panel-body">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <a href="Locations.aspx" class="btn btn-primary"><i class="fa fa-arrow-circle-o-left"></i>&nbsp;Return to all locations</a>
    </div>
    <input id="selectedPeople" runat="server" type="text" value="|" style="display: none;" />
    <script type="text/javascript">

        var addedPeople = [];

        function AddPerson() {
            var personDropDown = document.getElementById("MainContent_friendsDropDown");
            var name = personDropDown.options[personDropDown.selectedIndex].text;
            var idOfSelectedPerson = personDropDown.options[personDropDown.selectedIndex].value;

            if (name == 'Please select a Person...')
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
                addedPeople.push(name);

                $('#selectedFriends').append("<div class=\"col-xs-6 col-sm-3 col-md-2\">" +
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
        };
    </script>
</asp:Content>