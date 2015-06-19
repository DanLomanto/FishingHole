<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Forum.aspx.cs" Inherits="FishingHole.Forum" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="col-xs-10 col-xs-offset-1 col-md-offset-0 col-md-3">
            <div class="row">
                <a href="#" class="btn btn-primary btn-block"><i class="glyphicon glyphicon-plus"></i>&nbsp Add New Thread</a>
            </div>
            <div class="row top-buffer">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Categories</h3>
                    </div>
                    <div class="panel-body">
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
                        <div class="btn-group pull-right col-xs-3 form-inline" style="padding-top: 15px;">
                            <div class="form-group">
                                <input type="text" class="form-control" placeholder="Search threads..." />
                                <a href="#" class="btn btn-primary"><i class="glyphicon glyphicon-search"></i></a>
                            </div>
                        </div>
                        <h3>Recently Updated Threads</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-xs-10">
                                <div class="row">

                                    <h4 class="col-xs-8" style="color: #477bb7"><i class="glyphicon glyphicon-comment"></i>&nbsp;Where to go fishing this weekend?</h4>
                                </div>
                                <div class="row">
                                    <div class="col-xs-3 col-sm-3 col-md-3"><i class="glyphicon glyphicon-calendar"></i>&nbsp;Last Comment: 10/12/2014</div>
                                    <div class="col-xs-6 col-sm-6 col-md-6"><i class="glyphicon glyphicon-user"></i>&nbsp;Created by Bill Shrader</div>
                                </div>
                            </div>
                            <div class="col-xs-2 col-sm-2 col-md-1 text-center well well-md">Comments <strong>2</strong></div>
                            <br />
                            <br />
                            <br />
                            <br />
                            <hr />
                        </div>
                        <div class="row">
                            <div class="col-xs-10">
                                <div class="row">

                                    <h4 class="col-xs-8" style="color: #477bb7"><i class="glyphicon glyphicon-comment"></i>&nbsp;What flies to use?</h4>
                                </div>
                                <div class="row">
                                    <div class="col-xs-3 col-sm-3 col-md-3"><i class="glyphicon glyphicon-calendar"></i>&nbsp;Last Comment: 11/12/2014</div>
                                    <div class="col-xs-6 col-sm-6 col-md-6"><i class="glyphicon glyphicon-user"></i>&nbsp;Created by Frank Smith</div>
                                </div>
                            </div>
                            <div class="col-xs-2 col-sm-2 col-md-1 text-center well well-md">Comments <strong>8</strong></div>
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
</asp:Content>