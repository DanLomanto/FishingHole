<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PhotoGallery.aspx.cs" Inherits="PhotoGallery" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <div class="panel-heading clearfix">
                <div class="btn-group pull-right" style="padding-top: 15px;">
                    <a href="UploadPhotos.aspx?returnUrl=PhotoGallery" class="btn btn-large btn-primary"><i class="glyphicon glyphicon-plus"></i>&nbsp;Upload Photos</a>
                </div>
                <h3>Photo Gallery</h3>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-2 pull-left">
                        <asp:LinkButton runat="server" ID="prevTwentyImages" CssClass="btn btn-default text-center" OnClick="prevTwentyImages_Click"><i class="glyphicon glyphicon-chevron-left"></i>&nbsp;Previous 8</asp:LinkButton>
                    </div>
                    <div class="col-md-3 col-md-offset-7">
                        <asp:LinkButton runat="server" ID="nextTwentyImages" CssClass="btn btn-default pull-right" OnClick="nextTwentyImages_Click">Next 8&nbsp;<span class="glyphicon glyphicon-chevron-right" /></asp:LinkButton>
                    </div>
                </div>
                <div class="top-buffer">
                    <ul id="photoGallery" class="row" runat="server">
                    </ul>
                </div>
            </div>
    </div>
    </div>
    <div id="lightbox" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
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

            document.getElementById("PhotoGalleryNavItem").className = "active";

            var $lightbox = $('#lightbox');

            $('[data-target="#lightbox"]').on('click', function (event) {
                var $img = $(this).find('img'),
                    src = $img.attr('src'),
                    alt = $img.attr('alt'),
                    css = {
                        'maxWidth': $(window).width() - 300,
                        'maxHeight': $(window).height() - 300
                    };

                $lightbox.find('.close').addClass('hidden');
                $lightbox.find('img').attr('src', src);
                $lightbox.find('img').attr('alt', alt);
                $lightbox.find('img').css(css);
            });

            $lightbox.on('shown.bs.modal', function (e) {
                var $img = $lightbox.find('img');

                $lightbox.find('.modal-dialog').css({ 'width': $img.width() });
                $lightbox.find('.close').removeClass('hidden');
            });
        });
    </script>
</asp:Content>