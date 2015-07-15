<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Trip.aspx.cs" Inherits="FishingHole.Trip" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Trip" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <div class="panel-heading text-center">
                <h3>Trip Information</h3>
            </div>
            <div class="panel-body">
                <div class="container-fluid col-md-offset-1 col-md-10">
                    <div class="row top-buffer">
                        <div class="text-center">
                            <asp:BulletedList ID="formErrors" runat="server" CssClass="no-bullets list-group-item-danger center-block text-center" />
                        </div>
                    </div>
                    <div class="form-horizontal" role="form">
                        <div class="form-group">
                            <label for="TripTitle" class="control-label col-xs-12 col-md-4">Title:</label>
                            <div class="col-xs-8">
                                <input type="text" runat="server" id="TripTitle" class="form-control has-error" placeholder="Title" maxlength="255" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="Description" class="control-label col-xs-12 col-md-4">Description:</label>
                            <div class="col-xs-8">
                                <textarea runat="server" id="Description" class="form-control" placeholder="Description" rows="4" cols="50" maxlength="500" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="TargetedSpecies" class="control-label col-xs-12 col-md-4">Targeted Species:</label>
                            <div class="col-xs-8">
                                <input type="text" runat="server" id="TargetedSpecies" class="form-control" placeholder="Targeted Species" maxlength="255" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="WaterConditions" class="control-label col-xs-12 col-md-4">Water Conditions:</label>
                            <div class="col-xs-8">
                                <input type="text" runat="server" id="WaterConditions" class="form-control" placeholder="Water Conditions" maxlength="255" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="WeatherConditions" class="control-label col-xs-12 col-md-4">Weather Conditions:</label>
                            <div class="col-xs-8">
                                <input type="text" runat="server" id="WeatherConditions" class="form-control" placeholder="Weather Conditions" maxlength="255" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="MainContent_TripDate" class="control-label col-xs-12 col-md-4">Trip Date:</label>
                            <div class="col-xs-8">
                                <input id="TripDate" runat="server" type="text" class="date-picker form-control pull-left" placeholder="Trip Date" maxlength="10" />
                                <label id="datepickerImage" for="MainContent_TripDate" class="btn input-group-addon" style="width: 40px">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="CatchOfTheDay" class="control-label col-xs-12 col-md-4">Catch of The Day:</label>
                            <div class="col-xs-8">
                                <input type="text" runat="server" id="CatchOfTheDay" class="form-control" placeholder="Catch of The Day" maxlength="255" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="FliesLuresUsed" class="control-label col-xs-12 col-md-4">Flies\Lures Used:</label>
                            <div class="col-xs-8">
                                <input type="text" runat="server" id="FliesLuresUsed" class="form-control" placeholder="Flies\Lures Used" maxlength="255" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="OtherNotes" class="control-label col-xs-12 col-md-4">Other Notes:</label>
                            <div class="col-xs-8">
                                <textarea type="text" runat="server" id="OtherNotes" class="form-control" placeholder="Other Notes" rows="4" cols="50" maxlength="500" />
                            </div>
                        </div>
                    </div>
                    <div class="container-fluid top-buffer col-md-10 col-md-offset-1">
                        <div class="panel-group" id="accordion">
                            <div class="panel panel-default">
                                <div id="AttachLocationHeader" class="panel-heading" data-toggle="collapse" data-target="#LocationAccordian" data-parent="#accordion">
                                    <h4 class="panel-title">Create or Attach a Location
                                    </h4>
                                </div>
                                <div id="LocationAccordian" class="panel-collapse collapse" aria-expanded="false">
                                    <div class="panel-body">
                                        <div class="container-fluid">
                                            <div class="row col-md-offset-1 top-buffer">
                                                <label for="AttachedLocation" class="control-label col-xs-12 col-md-4">Attached Location:</label>
                                            </div>
                                            <div class="row">
                                                <div class="form-inline col-md-8 col-md-offset-2 text-center">
                                                    <asp:DropDownList ID="AttachedLocation" runat="server" class="form-control"></asp:DropDownList>
                                                    <asp:LinkButton ID="SaveAndViewLocationBtn" runat="server" CssClass="btn btn-primary" OnClick="SaveAndViewLocationBtn_Click">Save & view location&nbsp;<i class="glyphicon glyphicon-expand"></i></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="row text-center top-buffer">
                                                <span><strong>Or</strong></span>
                                            </div>
                                            <div class="row top-buffer">
                                                <div class="col-md-offset-3 col-md-6">
                                                    <asp:LinkButton ID="SaveAndCreateLocation" runat="server" CssClass="btn btn-info btn-block" OnClick="SaveAndCreateLocation_Click">Save & create location&nbsp;<i class="glyphicon glyphicon-expand"></i></asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div id="AttachPhotosHeader" class="panel-heading" data-toggle="collapse" data-target="#PhotosAccordian" data-parent="#accordion">
                                    <h4 class="panel-title">Upload or Attach Photos
                                    </h4>
                                </div>
                                <div id="PhotosAccordian" class="panel-collapse collapse" aria-expanded="false">
                                    <div class="panel-body">
                                        <div class="container-fluid">
                                            <div class="row col-md-offset-1">
                                                <label>Attached Photo(s):</label>
                                            </div>
                                            <div class="row col-xs-12 col-md-8 col-md-offset-2">
                                                <p id="NoPhotosAttachedMessage" runat="server" visible="false"><em>You have not attached any photos to this trip yet...</em></p>
                                            </div>
                                            <div class="row">
                                                <div id="CarouselContainer" runat="server" class="carousel slide col-md-offset-2 col-md-8">
                                                    <div id="CarouselImages" runat="server" class="carousel-inner" role="listbox">
                                                    </div>
                                                    <a class="left carousel-control" href="#myCarousel" data-slide="prev"><span runat="server" id="leftCarouselControl" class="glyphicon glyphicon-chevron-left"></span></a>
                                                    <a class="right carousel-control" href="#myCarousel" data-slide="next"><span runat="server" id="rightCarouselControl" class="glyphicon glyphicon-chevron-right"></span></a>
                                                </div>
                                            </div>
                                            <div class="row top-buffer">
                                                <div class="form-horizontal">
                                                    <div class="form-group">
                                                        <label for="photoUploader" class="control-label col-xs-12 col-md-4">Upload Photo(s):</label>
                                                        <div class="col-xs-8">
                                                            <span class="btn btn-default btn-file"><i class="fa fa-folder-open-o"></i>&nbsp;Browse
                                                                <asp:FileUpload runat="server" ID="photoUploader" AllowMultiple="true" CssClass="form-control col-xs-12 col-md-5" />
                                                            </span>
                                                            <asp:LinkButton CssClass="btn btn-primary" runat="server" ID="uploadPhotoButton" OnClick="UploadPhoto"><i class="glyphicon glyphicon-cloud-upload"></i>&nbsp;Upload Photo(s)</asp:LinkButton>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div id="returnMessage" runat="server" class="col-md-8 text-center"></div>
                                                    </div>
                                                    <div class="form-group text-center">
                                                        <span><strong>Or</strong></span>
                                                    </div>
                                                    <div class="form-group text-center">
                                                        <asp:LinkButton ID="SaveAndCreatePhotos" runat="server" OnClick="SaveAndCreatePhotos_Click" CssClass="btn btn-info">Attach pictures&nbsp;<i class="glyphicon glyphicon-expand"></i></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="container-fluid top-buffer col-md-10 col-md-offset-1">
                            <div class="form-group">
                                <div class="text-center">
                                    <div class="top-buffer">
                                        <asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="btn btn-m btn-primary" OnClick="SaveButton_Click"></asp:Button>
                                        <asp:Button ID="CancelButton" runat="server" Text="Cancel" CssClass="btn btn-m btn-default" OnClick="CancelButton_Click"></asp:Button>
                                    </div>
                                </div>
                            </div>
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
            <script type="text/javascript">
                $(document).ready(function () {

                    $('#AttachLocationHeader').on('click', function () {
                        $($(this).data('target')).collapse('toggle');
                    });

                    $('#AttachPhotosHeader').on('click', function () {
                        $($(this).data('target')).collapse('toggle');
                    });

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

                    $('.carousel').carousel({
                        wrap: false,
                        interval: 0
                    });
                });

                $('#MainContent_TripDate').datepicker();

                $('#MainContent_TripDate').on("change", function () {
                    var id = $(this).attr("id");
                    var val = $("label[for='" + id + "']").text();
                    $("#msg").text(val + " changed");
                });

                function validate(evt) {
                    var theEvent = evt || window.event;
                    var key = theEvent.keyCode || theEvent.which;
                    key = String.fromCharCode(key);
                    var regex = /[0-9]/;
                    if (!regex.test(key)) {
                        theEvent.returnValue = false;
                        if (theEvent.preventDefault) theEvent.preventDefault();
                    }
                }

                $(document).on('change', '.btn-file :file', function () {
                    var input = $(this),
                        numFiles = input.get(0).files ? input.get(0).files.length : 1,
                        label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
                    input.trigger('fileselect', [numFiles, label]);
                });
            </script>
</asp:Content>