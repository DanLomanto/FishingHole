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
                        </div>
                        <div id="ThreadBody" runat="server" class="container-fluid">
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="container-fluid text-center">
                            <div class="row">
                                <div class="col-xs-4 col-xs-offset-4">
                                    <textarea runat="server" id="ThreadReply" class="form-control" placeholder="Reply Message..." maxlength="1000" style="width: 300px; height: 150px;" />
                                </div>
                            </div>
                            <div class="row top-buffer">
                                <asp:LinkButton ID="PostReply" runat="server" OnClick="PostReply_Click" CssClass="btn btn-primary">Post Reply</asp:LinkButton>
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
</asp:Content>