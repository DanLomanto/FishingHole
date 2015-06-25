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
                        <div id="ThreadBody" runat="server" class="container-fluid">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 id="OriginalMessageHeader" runat="server"><i class="fa fa-comment"></i>&nbsp;Originator: Chris Frompkin</h4>
                                </div>
                                <div class="panel-body">
                                    <span id="OriginalMessage" runat="server">This is the original message from the thread creator. This is the original message from the thread creator. This is the original message from the thread creator. This is the original message from the thread creator. This is the original message from the thread creator. </span>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4><i class="fa fa-reply"></i>&nbsp;Reply From: Bill Sweet</h4>
                                </div>
                                <div class="panel-body">
                                    <span>This is the reply Message that Bill has. This is the reply Message that Bill has. This is the reply Message that Bill has. This is the reply Message that Bill has. This is the reply Message that Bill has. This is the reply Message that Bill has. </span>
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
</asp:Content>