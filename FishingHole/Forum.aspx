<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Forum.aspx.cs" Inherits="FishingHole.Forum" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="ForumContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="col-xs-10 col-xs-offset-1 col-md-offset-0 col-md-3">
            <div class="row">
                <div class="form-inline">
                    <div class="form-group">
                        <input type="text" class="form-control input-md" placeholder="Search threads..." />
                        <a href="#" class="btn btn-primary"><i class="glyphicon glyphicon-search"></i></a>
                    </div>
                </div>
            </div>
            <div class="row top-buffer">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Categories</h3>
                    </div>
                    <div class="panel-body">
                        <div><i class="glyphicon glyphicon-book"></i>&nbsp;General Discussion</div>
                        <hr />
                        <div><i class="glyphicon glyphicon-book"></i>&nbsp;Fly Tying</div>
                        <hr />
                        <div><i class="glyphicon glyphicon-book"></i>&nbsp;Tips & Tricks</div>
                        <hr />
                        <div><i class="glyphicon glyphicon-book"></i>&nbsp;Bait & Tackle</div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xs-10 col-xs-offset-1 col-md-offset-0 col-md-9">
            <div class="container-fluid">
                <div class="row">
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="btn-group pull-right col-xs-5 form-inline" style="padding-top: 15px;">
                            <div class="form-group pull-right">
                                <a id="LaunchNewThreadModal" href="#AddThreadModal" class="btn btn-large btn-primary" data-toggle="modal"><i class="glyphicon glyphicon-plus"></i>&nbsp New Thread</a>
                            </div>
                        </div>
                        <h3>Recently Updated Threads</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-xs-10">
                                <div class="row">
                                    <a href="#">
                                        <h4 class="col-xs-8" style="color: #477bb7"><i class="glyphicon glyphicon-comment"></i>&nbsp;Where to go fishing this weekend?</h4>
                                    </a>
                                </div>
                                <div class="row">
                                    <div class="col-xs-3 col-sm-3 col-md-3"><i class="glyphicon glyphicon-calendar"></i>&nbsp;Last Comment: 10/12/2014</div>
                                    <div class="col-xs-6 col-sm-6 col-md-6"><i class="glyphicon glyphicon-user"></i>&nbsp;Created by Bill Shrader</div>
                                </div>
                            </div>
                            <div class="col-xs-2 col-sm-2 col-md-2 text-center">
                                <a href="#" style="color: #000000">
                                    <div class="col-xs-7 well well-md" style="min-width: 100px">
                                        <span>Comments <strong>2</strong></span>
                                    </div>
                                </a>
                            </div>
                            <br />
                            <br />
                            <br />
                            <br />
                            <hr />
                        </div>
                        <div class="row">
                            <div class="col-xs-10">
                                <div class="row">
                                    <a href="#">
                                        <h4 class="col-xs-8" style="color: #477bb7"><i class="glyphicon glyphicon-comment"></i>&nbsp;What flies to use?</h4>
                                    </a>
                                </div>
                                <div class="row">
                                    <div class="col-xs-3 col-sm-3 col-md-3"><i class="glyphicon glyphicon-calendar"></i>&nbsp;Last Comment: 11/12/2014</div>
                                    <div class="col-xs-6 col-sm-6 col-md-6"><i class="glyphicon glyphicon-user"></i>&nbsp;Created by Frank Smith</div>
                                </div>
                            </div>
                            <div class="col-xs-2 col-sm-2 col-md-2 text-center">
                                <a href="#" style="color: #000000">
                                    <div class="col-xs-7 well well-md" style="min-width: 100px">
                                        <span>Comments <strong>8</strong></span>
                                    </div>
                                </a>
                            </div>
                            <br />
                            <br />
                            <br />
                            <br />
                            <hr />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="AddThreadModal" class="modal" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">New Thread</h4>
                </div>
                <div class="modal-body">
                    <div class="container-fluid col-xs-offset-1">
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
                                    <select id="Categories" class="form-control">
                                        <option>General Discussion</option>
                                        <option>Fly Tying</option>
                                        <option>Tips & Tricks</option>
                                        <option>Bait & Tackle</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal" aria-hidden="true">Save</button>
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

            document.getElementById("ForumNavItem").className = "active";
        });
    </script>
</asp:Content>