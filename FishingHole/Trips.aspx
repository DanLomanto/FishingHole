<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Trips.aspx.cs" Inherits="FishingHole.Trips" %>

<%@ MasterType VirtualPath="~/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Trips" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="col-md-offset-1 col-md-10">
        <div class="panel panel-default">
            <div class="panel-heading clearfix">
                <div class="btn-group pull-right" style="padding-top: 15px;">
                    <a href="Trip.aspx?id=0&returnUrl=Trips" class="btn btn-large btn-primary"><i class="fa fa-plus-square"></i>&nbsp;Add Trip</a>
                </div>
                <h3>Your Trips</h3>
            </div>
            <div class="panel-body">
                <div class="container-fluid">
                    <div id="NoTripsMessage" runat="server" class="row alert alert-info col-md-offset-1 col-md-4">
                        <span>You have not created any Trips yet...</span>
                    </div>
                    <div class="row" id="yourLocationsTableContainer" runat="server">
                        <div class="table-responsive">
                            <table class="table table-striped table-bordered">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>Title</th>
                                        <th>Description</th>
                                        <th>Targeted Species</th>
                                        <th>Water Conditions</th>
                                        <th>Weather Conditions</th>
                                        <th>Date of Trip</th>
                                        <th>Flies/Lures Used</th>
                                        <th>Catch of The Day</th>
                                        <th>Create Date</th>
                                    </tr>
                                </thead>
                                <tbody id="yourTripsTableBody" runat="server">
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <input type="text" id="tripToDelete" runat="server" style="display: none;" />
    <div class="modal fade" id="confirmTripDeletion">
        <div class="modal-dialog" style="max-width: 375px; max-height: 200px">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Confirm Deletion</h4>
                </div>
                <div class="modal-body">
                    <p>Are you sure you want to delete this trip?</p>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="ConfirmLocationDeletion" runat="server" CssClass="btn btn-primary" OnClick="DeleteTrip">Delete</asp:LinkButton>
                    <button type="button" class="btn btn-default" data-dismiss="modal" aria-hidden="true">Cancel</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            document.getElementById("TripsNavItem").className = "active";
        });
    </script>
</asp:Content>