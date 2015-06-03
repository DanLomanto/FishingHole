<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PhotoGallery.aspx.cs" Inherits="PhotoGallery" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="col-md-8 col-md-offset-2">
        <div class="checkbox-inline">
            <asp:CheckBoxList runat="server" ID="photoGalleryChecklist" CssClass="checkbox-inline CheckboxLabel" OnDataBound="photoGalleryChecklist_DataBound" RepeatDirection="Horizontal">
            </asp:CheckBoxList>
        </div>
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
                        <asp:LinkButton runat="server" ID="prevTwentyImages" CssClass="btn btn-default text-center" OnClick="prevTwentyImages_Click"><i class="glyphicon glyphicon-chevron-left"></i>&nbsp;Previous 20</asp:LinkButton>
                    </div>
                    <div class="col-md-3 col-md-offset-7">
                        <asp:LinkButton runat="server" ID="nextTwentyImages" CssClass="btn btn-default pull-right" OnClick="nextTwentyImages_Click">Next 20&nbsp;<span class="glyphicon glyphicon-chevron-right" /></asp:LinkButton>
                    </div>
                </div>
                <div class="top-buffer row">
                    <div class="form-inline col-md-offset-1">
                        <label for="FilterByTripDropDown">Filter Photos by Trip:</label>
                        <asp:DropDownList ID="FilterByTripDropDown" runat="server" class="form-control"></asp:DropDownList>
                        <asp:LinkButton ID="FilterPhotosBtn" runat="server" CssClass="btn btn-primary" OnClick="FilterPhotosBtn_Click">Filter</asp:LinkButton>
                    </div>
                </div>
                <div class="top-buffer row">
                    <p id="NoPhotosAssociatedMessage" runat="server" visible="false" class="col-md-offset-2"><em>You have not associated any photos to this trip yet...</em></p>
                    <ul id="photoGallery" runat="server">
                    </ul>
                </div>
                <div class="top-buffer row">
                    <div class="form-inline text-center">
                        <label for="TripAssociationDropDown">Associate selected photos to Trip:</label>
                        <asp:DropDownList ID="TripAssociationDropDown" runat="server" class="form-control"></asp:DropDownList>
                        <asp:LinkButton ID="ApplyTripAssociation" runat="server" CssClass="btn btn-primary" OnClick="ApplyTripAssociation_Click">Apply</asp:LinkButton>
                    </div>
                </div>
                <div class="top-buffer row text-center">
                    <span>Or</span>
                </div>
                <div class="top-buffer row text-center">
                    <a href="#confirmDeletionModal" id="deletePhotosBtn" class="btn btn-primary">Delete Selected Photo(s)</a>
                </div>
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
    <div class="modal fade" id="confirmDeletionModal">
        <div class="modal-dialog" style="max-width: 375px; max-height: 200px">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Delete Confirmation</h4>
                </div>
                <div class="modal-body">
                    <p>Are you sure you want to delete the selected photo(s)?</p>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="DeleteSelectedPhotos" runat="server" CssClass="btn btn-primary" OnClick="DeletePhotos">Confirm</asp:LinkButton>
                    <button type="button" class="btn btn-default" data-dismiss="modal" aria-hidden="true">Cancel</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        $(document).ready(function () {

            if ($('#form1 input:checkbox:checked').length > 0) {
                $('#deletePhotosBtn').removeClass("disabled");
                $('#MainContent_ApplyTripAssociation').removeClass("disabled");
            }
            else {
                $('#deletePhotosBtn').addClass("disabled");
                $('#MainContent_ApplyTripAssociation').addClass("disabled");
            }

            document.getElementById("PhotoGalleryNavItem").className = "active";

            var $lightbox = $('#lightbox');

            $('[data-target="#lightbox"]').on('click', function (event) {
                var $img = $(this),
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
                var $img = $lightbox;

                $lightbox.find('.modal-dialog').css({ 'width': $img.width() });
                $lightbox.find('.close').removeClass('hidden');
            });

            $('#deletePhotosBtn').on('click', function (event) {
                $('#confirmDeletionModal').modal({});
            });

            $('[type="checkbox"]').on('click', function (event) {
                if ($('#form1 input:checkbox:checked').length > 0) {
                    $('#deletePhotosBtn').removeClass("disabled");
                    $('#MainContent_ApplyTripAssociation').removeClass("disabled");
                }
                else {
                    $('#deletePhotosBtn').addClass("disabled");
                    $('#MainContent_ApplyTripAssociation').addClass("disabled");
                }
            });
        });
    </script>
</asp:Content>