<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Locations.aspx.cs" Inherits="FishingHole.Locations" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Locations" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="col-md-offset-1 col-md-10">
        <div class="panel panel-default">
            <div class="panel-heading clearfix">
                <div class="btn-group pull-right" style="padding-top: 15px;">
                    <a href="Location.aspx?id=0&returnUrl=locations" id="AddLocation" runat="server" class="btn btn-large btn-primary"><i class="fa fa-plus-square"></i>&nbsp;Add Location</a>
                </div>
                <h3>Your Locations</h3>
            </div>
            <div class="panel-body">
                <div class="container-fluid">
                    <div id="NoLocationsMessage" runat="server" class="row alert alert-info col-md-offset-1 col-md-4">
                        <span>You have not created any Locations yet...</span>
                    </div>
                    <div class="row" id="yourLocationsTableContainer" runat="server">
                        <div class="table-responsive">
                            <table class="table table-striped table-bordered">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>Name</th>
                                        <th>Lattitude Direction</th>
                                        <th>Lattitude</th>
                                        <th>Longitude Direction</th>
                                        <th>Longitude</th>
                                        <th>Street Address</th>
                                        <th>City/Town</th>
                                    </tr>
                                </thead>
                                <tbody id="yourLocationsTableBody" runat="server">
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading clearfix">
                <div class="btn-group pull-right" style="padding-top: 15px;">
                    <a href="ShareLocation.aspx" class="btn btn-large btn-primary">Share Location&nbsp;<i class="fa fa-share-square-o"></i></a>
                </div>
                <h3>Locations Shared with You</h3>
            </div>
            <div class="panel-body">
                <div class="container-fluid">
                    <div id="NoSharedLocationsText" runat="server" class="row alert alert-info col-md-offset-1 col-md-4">
                        <span>No one has shared any Locations with you yet...</span>
                    </div>
                    <div class="table-responsive" id="sharedLocationsTableContainer" runat="server">
                        <table class="table table-striped table-bordered">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Name</th>
                                    <th>Lattitude Direction</th>
                                    <th>Lattitude</th>
                                    <th>Longitude Direction</th>
                                    <th>Longitude</th>
                                    <th>Street Address</th>
                                    <th>City/Town</th>
                                </tr>
                            </thead>
                            <tbody id="sharedLocationsTableBody" runat="server">
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <input type="text" id="locationToDelete" runat="server" style="display: none;" />
    <div class="modal fade" id="confirmLocationDeletion">
        <div class="modal-dialog" style="max-width: 375px; max-height: 200px">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Confirm Deletion</h4>
                </div>
                <div class="modal-body">
                    <p>Are you sure you want to delete this location?</p>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="ConfirmLocationDeletion" runat="server" CssClass="btn btn-primary" OnClick="DeleteLocation">Delete</asp:LinkButton>
                    <button type="button" class="btn btn-default" data-dismiss="modal" aria-hidden="true">Cancel</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            document.getElementById("LocationsNavItem").className = "active";
        });
    </script>
</asp:Content>