<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Forum.aspx.cs" Inherits="FishingHole.Forum" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="ForumContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid">
        <div class="col-xs-10 col-xs-offset-1 col-md-offset-0 col-md-3">
            <div class="container-fluid">
                <div class="row">
                    <div class="form-inline">
                        <div class="form-group">
                            <input id="SearchThreadsText" runat="server" type="text" class="form-control input-md" placeholder="Search all threads..." maxlength="50" />
                            <asp:LinkButton ID="SearchThreadsButton" runat="server" CssClass="btn btn-primary" OnClick="SearchThreadsButton_Click"><i class="glyphicon glyphicon-search"></i></asp:LinkButton>
                            <asp:LinkButton ID="ResetFilterButton" runat="server" CssClass="btn btn-default" OnClick="ResetFilterButton_Click">Reset</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="row top-buffer">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Categories</h3>
                        </div>
                        <div id="ThreadTopics" runat="server" class="panel-body">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xs-10 col-xs-offset-1 col-md-offset-0 col-md-9">
            <div class="container-fluid">
                <div class="row">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-12 col-md-10">
                                    <h3>Recently Updated Threads</h3>
                                </div>
                                <div class="col-xs-12 col-md-2 pull-right" style="padding-top: 15px;">
                                    <a id="LaunchNewThreadModal" href="#AddThreadModal" class="btn btn-large btn-primary" data-toggle="modal"><i class="glyphicon glyphicon-plus"></i>&nbsp New Thread</a>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div id="FilterSearchTextTag" runat="server" class="row" visible="false">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-xs-12 col-md-offset-3 col-md-6 text-center">
                                            <div class="alert alert-info left-buffer">
                                                Filter Text:&nbsp;
                                                <span id="FilterSearchTagText" runat="server" class="badge"></span>&nbsp;
                                                <asp:LinkButton ID="CloseFilter" runat="server" OnClick="ResetFilterButton_Click"><i class="fa fa-times-circle"></i></asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <hr />
                                    </div>
                                </div>
                            </div>
                            <div id="FilterCategoryTag" runat="server" class="row" visible="false">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-xs-12 col-md-offset-3 col-md-6 text-center">
                                            <div class="alert alert-info left-buffer">
                                                Filter Category:&nbsp;
                                                <span id="FilterCategoryTagText" runat="server" class="badge"></span>&nbsp;
                                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="ResetFilterButton_Click"><i class="fa fa-times-circle"></i></asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <hr />
                                    </div>
                                </div>
                            </div>
                            <div id="RecentlyUpdatedThreads" runat="server">
                            </div>
                            <div class="row col-xs-offset-1 col-xs-10">
                                <asp:LinkButton runat="server" ID="ViewOlderThreads" CssClass="btn btn-default" OnClick="ViewOlderThreads_Click"><i class="glyphicon glyphicon-arrow-left"></i>&nbsp;Older Threads</asp:LinkButton>
                                <asp:LinkButton runat="server" ID="ViewNewerThreads" CssClass="btn btn-default pull-right" OnClick="ViewNewerThreads_Click">Newer Threads&nbsp;<i class="glyphicon glyphicon-arrow-right"></i></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <input type="text" id="hiddenShowModal" runat="server" style="display: none;" />
    <div id="AddThreadModal" class="modal" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">New Thread</h4>
                </div>
                <div class="modal-body">
                    <div class="container-fluid col-xs-offset-1">
                        <div class="row text-center col-xs-offset-1">
                            <asp:BulletedList ID="formErrors" runat="server" CssClass="no-bullets list-group-item-danger center-block text-center col-md-10" />
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <label for="ThreadTitle" class="pull-left col-xs-2 control-label">Title:</label>
                                <div class="col-md-9 col-xs-12">
                                    <input type="text" runat="server" id="ThreadTitle" class="form-control" placeholder="Title" />
                                </div>
                            </div>
                        </div>
                        <div class="row top-buffer">
                            <div class="form-group">
                                <label for="ThreadMessage" class="pull-left col-xs-2 control-label">Message:</label>
                                <div class="col-md-9 col-xs-12">
                                    <textarea type="text" runat="server" id="ThreadMessage" class="form-control" placeholder="Thread Message" rows="10" cols="50" maxlength="1000" />
                                </div>
                            </div>
                        </div>
                        <div class="row top-buffer">
                            <div class="form-group">
                                <label for="ThreadTitle" class="pull-left col-xs-2 control-label">Category:</label>
                                <div class="col-md-9 col-xs-12">
                                    <asp:DropDownList ID="AddThreadCategories" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="CreateNewThread" runat="server" CssClass="btn btn-primary" OnClick="CreateNewThread_Click">Save</asp:LinkButton>
                    <button type="button" class="btn btn-default" data-dismiss="modal" aria-hidden="true">Cancel</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $('#AddThreadModal').modal({
            backdrop: 'static',
            keyboard: false
        });

        $("#LaunchNewThreadModal").click(function () {
            document.getElementById("AddThreadModal").className = "modal fade";
        });

        $(document).ready(function () {

            $('#AddThreadModal').modal('hide');

            var displayModal = $('#MainContent_hiddenShowModal').val();
            if (displayModal == "true") {
                $('#AddThreadModal').modal('show');
            }

            document.getElementById("ForumNavItem").className = "active";
        });

        $('#AddThreadModal').on('hidden.bs.modal', function (e) {
            $('#MainContent_ThreadTitle').val("");
            $('#MainContent_ThreadMessage').val("");
        });
    </script>
</asp:Content>