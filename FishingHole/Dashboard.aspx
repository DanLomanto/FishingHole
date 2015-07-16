<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="FishingHole.Dashboard" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Dashboard" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-offset-1 col-md-5 col-xs-12">
                <div class="panel panel-default">
                    <div class="panel-heading clearfix">
                        <div class="btn-group pull-right" style="padding-top: 15px;">
                            <a href="UploadPhotos.aspx" class="btn btn-large btn-primary"><i class="fa fa-plus-square"></i>&nbsp;Upload Photos</a>
                        </div>
                        <h3>Photo Gallery</h3>
                    </div>
                    <div class="panel-body">
                        <div class="container-fluid">
                            <div id="RecentlyAddedPhotosMessage" runat="server" class="row col-md-offset-1">
                                <p>Your 8 most recent photo uploads:</p>
                            </div>
                            <div id="NoPhotosMessage" runat="server" class="row top-buffer col-md-offset-1" visible="false">
                                <div class="alert alert-info col-md-7">
                                    <span>You have not added any Photos yet...</span>
                                </div>
                            </div>
                            <div class="row" id="photoDiv" runat="server">
                            </div>
                            <div class="row top-buffer col-md-offset-1 col-md-10 col-xs-10">
                                <a href="PhotoGallery.aspx">View all photos</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-offset-0 col-md-5 col-xs-12">
                <asp:Panel ID="TripsPanel" runat="server">
                    <div class="panel panel-default">
                        <div class="panel-heading clearfix">
                            <div class="btn-group pull-right" style="padding-top: 15px;">
                                <a href="Trip.aspx?id=0" class="btn btn-large btn-primary"><i class="fa fa-plus-square"></i>&nbsp;Add Trip</a>
                            </div>
                            <h3>Trips</h3>
                        </div>
                        <div class="panel-body">
                            <div class="container-fluid">
                                <div id="RecentlyAddedTripsMessage" runat="server" class="row">
                                    <p>Your 5 most recently added Trips:</p>
                                </div>
                                <div id="NoTripsMessage" runat="server" class="row top-buffer">
                                    <div class="alert alert-info col-md-7">
                                        <span>You have not created any Trips yet...</span>
                                    </div>
                                </div>
                                <div class="row top-buffer" id="recentlyAddedTripsTableContainer" runat="server">
                                    <div class="table-responsive">
                                        <table class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th></th>
                                                    <th>Title</th>
                                                    <th>Date of Trip</th>
                                                    <th>Create Date</th>
                                                </tr>
                                            </thead>
                                            <tbody id="recentlyAddedTripsBody" runat="server">
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <div class="row top-buffer col-md-10">
                                    <a href="Trips.aspx">View all trips</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
        <div class="row">
            <div class="col-md-offset-1 col-md-5 col-xs-12">
                <asp:Panel ID="LocationsPanel" runat="server">
                    <div class="panel panel-default">
                        <div class="panel-heading clearfix">
                            <div class="btn-group pull-right" style="padding-top: 15px;">
                                <a href="Location.aspx?id=0" id="AddLocation" runat="server" class="btn btn-large btn-primary"><i class="fa fa-plus-square"></i>&nbsp;Locations</a>
                            </div>
                            <h3>Locations</h3>
                        </div>
                        <div class="panel-body">
                            <div class="container-fluid">
                                <div id="RecentlyAddedLocationsMessage" runat="server" class="row">
                                    <p>Your 5 most recently added Locations:</p>
                                </div>
                                <div id="NoLocationsMessage" runat="server" class="row top-buffer">
                                    <div class="alert alert-info col-md-8">
                                        <span>You have not created any Locations yet...</span>
                                    </div>
                                </div>
                                <div class="row top-buffer" id="recentlyAddedLocationsTableContainer" runat="server">
                                    <div class="table-responsive">
                                        <table class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th></th>
                                                    <th>Name</th>
                                                    <th>Create Date</th>
                                                </tr>
                                            </thead>
                                            <tbody id="recentlyAddedLocationsBody" runat="server">
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <div class="row top-buffer col-md-10">
                                    <a href="Locations.aspx">View all locations</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
    <div id="lightbox" class="modal fade text-center" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body">
                    <img src="#" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal" aria-hidden="true">Close</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        $(document).ready(function () {

            var $lightbox = $('#lightbox');
            $('[data-target="#lightbox"]').on('click', function (event) {
                var $img = $(this),
                    src = $img.attr('src'),
                    alt = $img.attr('alt'),
                    css = {
                        'maxWidth': $(window).width() - ($(window).width() * .2),
                        'maxHeight': $(window).height() - ($(window).height() * .2)
                    };

                $lightbox.find('.close').addClass('hidden');
                $lightbox.find('img').attr('src', src);
                $lightbox.find('img').attr('alt', alt);
                $lightbox.find('img').css(css);
            });

            $lightbox.on('shown.bs.modal', function (e) {
                var $img = $lightbox;

                $lightbox.find('.modal-dialog').css({ 'width': $img.width() });
                $lightbox.find('.close').removeClass('hidden');
            });

            document.getElementById("DashboardNavItem").className = "active";
        });
    </script>
</asp:Content>