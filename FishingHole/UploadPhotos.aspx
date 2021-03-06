﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UploadPhotos.aspx.cs" Inherits="FishingHole.UploadPhotos" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <div class="panel-heading clearfix">
                <h4>Upload Photos</h4>
            </div>
            <div class="panel-body text-center">
                <div class="panel-body">
                    <div class="row">
                        <p>Select which picture you'd like to upload and then click the 'Upload Photo' button.</p>
                    </div>
                    <div class="text-center">
                        <asp:BulletedList ID="UploadErrors" runat="server" CssClass="no-bullets list-group-item-danger center-block text-center" />
                    </div>
                    <div class="row text-center">
                        <div class="form-inline">
                            <asp:FileUpload runat="server" ID="photoUploader" AllowMultiple="true" CssClass="form-control" />
                            <asp:LinkButton CssClass="btn btn-primary" runat="server" ID="uploadPhotoButton" OnClick="UploadPhoto"><i class="glyphicon glyphicon-cloud-upload"></i>&nbsp;Upload Photo</asp:LinkButton>
                        </div>
                    </div>
                    <div class="row top-buffer">
                        <div id="returnMessage" runat="server"></div>
                    </div>
                    <div class="row text-center top-buffer">
                        <asp:LinkButton ID="GoBackButton" runat="server" CssClass="btn btn-default" OnClick="GoBackButton_Click"><i class="glyphicon glyphicon-chevron-left"></i>&nbsp;Go Back</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript">
    </script>
</asp:Content>