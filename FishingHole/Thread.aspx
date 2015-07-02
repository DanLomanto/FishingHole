<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Thread.aspx.cs" Inherits="FishingHole.Thread" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="col-xs-10 col-xs-offset-1">
            <div class="row">
                <a href="Forum.aspx" class="btn btn-primary"><i class="glyphicon glyphicon-arrow-left"></i>&nbsp;Return to all threads</a>
            </div>
            <div class="row top-buffer">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3>Thread Title</h3>
                    </div>
                    <div class="panel-body">
                        <div class="panel-body">
                            <div id="OriginalThreadMessage" runat="server">
                            </div>
                            <hr />
                        </div>

                        <div id="ThreadBody" runat="server" class="container-fluid">
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="panel panel-default well">
                            <div class="panel-body">

                                <div class="container-fluid">
                                    <div class="row text-center col-md-offset-2">
                                        <asp:BulletedList ID="formErrors" runat="server" CssClass="no-bullets list-group-item-danger center-block text-center col-md-8" />
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-12 col-md-4 col-md-offset-1">
                                            <textarea runat="server" id="ThreadReply" class="form-control" placeholder="Reply Message..." maxlength="1000" style="min-width: 150px; max-width: 500px; height: 150px;" />
                                        </div>
                                        <div class="col-xs-12 col-md-4 col-md-offset-2">
                                            <div class="radio">
                                                <label>
                                                    <input id="DontShareLocationsRadioBtn" runat="server" type="radio" name="shareLocationBtns" checked="true" />Don't share location
                                                </label>
                                            </div>
                                            <div class="radio">
                                                <label>
                                                    <input id="ShareLocationsRadioBtn" runat="server" type="radio" name="shareLocationBtns" class="pull-left" />Share location
                                                </label>
                                                <div class="top-buffer">
                                                    <select id="Locations" runat="server" class="form-control" disabled="disabled"></select>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row top-buffer text-center">
                                        <asp:LinkButton ID="PostReply" runat="server" OnClick="PostReply_Click" CssClass="btn btn-primary">Post Reply</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <a href="Forum.aspx" class="btn btn-primary"><i class="glyphicon glyphicon-arrow-left"></i>&nbsp;Return to all threads</a>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $('#MainContent_ShareLocationsRadioBtn').click(function () {
            document.getElementById('<%= Locations.ClientID %>').disabled = false;
        });

        $('#MainContent_DontShareLocationsRadioBtn').click(function () {
            document.getElementById('<%= Locations.ClientID %>').disabled = true;
        });
    </script>
</asp:Content>