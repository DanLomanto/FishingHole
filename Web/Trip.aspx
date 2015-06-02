<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Trip.aspx.cs" Inherits="Trip" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

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
                            <asp:BulletedList ID="formErrors" runat="server" CssClass="col-centered" />
                        </div>
                    </div>
                    <div class="row top-buffer">
                        <div class="form-inline">
                            <label for="TripTitle" class="col-md-4 control-label">Title:</label>
                            <div>
                                <input type="text" runat="server" id="TripTitle" class="form-control has-error" placeholder="Title" maxlength="255" />
                            </div>
                        </div>
                    </div>
                    <div class="row top-buffer">
                        <div class="form-inline">
                            <label for="Description" class="col-md-4 control-label">Description:</label>
                            <div>
                                <textarea runat="server" id="Description" class="form-control" placeholder="Description" rows="4" cols="50" maxlength="500" />
                            </div>
                        </div>
                    </div>
                    <div class="row top-buffer">
                        <div class="form-inline">
                            <label for="TargetedSpecies" class="col-md-4 control-label">Targeted Species:</label>
                            <div>
                                <input type="text" runat="server" id="TargetedSpecies" class="form-control" placeholder="Targeted Species" maxlength="255" />
                            </div>
                        </div>
                    </div>
                    <div class="row top-buffer">
                        <div class="form-inline">
                            <label for="WaterConditions" class="col-md-4 control-label">Water Conditions:</label>
                            <div>
                                <input type="text" runat="server" id="WaterConditions" class="form-control" placeholder="Water Conditions" maxlength="255" />
                            </div>
                        </div>
                    </div>
                    <div class="row top-buffer">
                        <div class="form-inline">
                            <label for="WeatherConditions" class="col-md-4 control-label">Weather Conditions:</label>
                            <div>
                                <input type="text" runat="server" id="WeatherConditions" class="form-control" placeholder="Weather Conditions" maxlength="255" />
                            </div>
                        </div>
                    </div>
                    <div class="row top-buffer">
                        <div class="form-inline">
                            <label for="MainContent_TripDate" class="col-md-4 control-label">Trip Date:</label>
                            <input id="TripDate" runat="server" type="text" class="date-picker form-control pull-left" placeholder="Trip Date" maxlength="10" />
                            <label id="datepickerImage" for="MainContent_TripDate" class="btn input-group-addon" style="width: 40px">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </label>
                        </div>
                    </div>
                    <div class="row top-buffer">
                        <div class="form-inline">
                            <label for="CatchOfTheDay" class="col-md-4 control-label">Catch of The Day:</label>
                            <div>
                                <input type="text" runat="server" id="CatchOfTheDay" class="form-control" placeholder="Catch of The Day" maxlength="255" />
                            </div>
                        </div>
                    </div>
                    <div class="row top-buffer">
                        <div class="form-inline">
                            <label for="FliesLuresUsed" class="col-md-4 control-label">Flies\Lures Used:</label>
                            <div>
                                <input type="text" runat="server" id="FliesLuresUsed" class="form-control" placeholder="Flies\Lures Used" maxlength="255" />
                            </div>
                        </div>
                    </div>
                    <div class="row top-buffer">
                        <div class="form-inline">
                            <label for="OtherNotes" class="col-md-4 control-label">Other Notes:</label>
                            <div>
                                <textarea type="text" runat="server" id="OtherNotes" class="form-control" placeholder="Other Notes" rows="4" cols="50" maxlength="500" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="container-fluid top-buffer col-md-10 col-md-offset-1">
                    <div class="panel-group" id="accordion">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <a data-toggle="collapse" data-parent="#accordion" href="#LocationAccordian" style="text-decoration: none; color: #606060;">
                                    <h4 class="panel-title">Create or Attach a Location
                                    </h4>
                                </a>
                            </div>
                            <div id="LocationAccordian" class="panel-collapse collapse" aria-expanded="false">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="form-inline col-md-8 col-md-offset-2">
                                            <label for="AssociatedLocation" class="col-md-4 control-label">Location:</label>
                                            <select id="AssociatedLocation" runat="server" class="form-control">
                                            </select>
                                        </div>
                                    </div>
                                    <div class="row text-center top-buffer">
                                        <span><strong>Or</strong></span>
                                    </div>
                                    <div class="row top-buffer">
                                        <div class="col-md-offset-3 col-md-6">
                                            <a id="SaveAndCreateLocation" runat="server" href="#" class="btn btn-success btn-block">Save & attach new location to trip&nbsp;<i class="glyphicon glyphicon-expand"></i></a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <a data-toggle="collapse" data-parent="#accordion" href="#PhotosAccordian" style="text-decoration: none; color: #606060;">
                                    <h4 class="panel-title">Upload or Attach Photos
                                    </h4>
                                </a>
                            </div>
                            <div id="PhotosAccordian" class="panel-collapse collapse" aria-expanded="false">
                                <div class="panel-body">
                                    <div class="top-buffer row col-md-offset-1">
                                        <label>Attached Photos:</label>
                                    </div>
                                    <div class="top-buffer row col-md-8 col-md-offset-2">
                                        <p id="NoPhotosAttachedMessage" runat="server" visible="false"><em>You have not attached any photos to this trip yet...</em></p>
                                    </div>
                                    <div class="row top-buffer">
                                        <div id="myCarousel" class="carousel slide">
                                            <div id="CarouselImages" runat="server" class="carousel-inner" role="listbox">
                                            </div>
                                            <a class="left carousel-control" href="#myCarousel" data-slide="prev"><span runat="server" id="leftCarouselControl" class="glyphicon glyphicon-chevron-left"></span></a>
                                            <a class="right carousel-control" href="#myCarousel" data-slide="next"><span runat="server" id="rightCarouselControl" class="glyphicon glyphicon-chevron-right"></span></a>
                                        </div>
                                    </div>
                                </div>
                                <div class="container">
                                    <div class="top-buffer row">
                                        <div class="form-inline col-md-8 col-md-offset-2">
                                            <label for="photoUploader">Upload Photo(s):</label>
                                            <asp:FileUpload runat="server" ID="photoUploader" AllowMultiple="true" CssClass="form-control" />
                                            <asp:LinkButton CssClass="btn btn-primary" runat="server" ID="uploadPhotoButton" OnClick="UploadPhoto"><i class="glyphicon glyphicon-cloud-upload"></i>&nbsp;Upload Photo</asp:LinkButton>
                                        </div>
                                        <div class="row top-buffer">
                                            <div id="returnMessage" runat="server" class=""></div>
                                        </div>
                                    </div>
                                    <div class="row text-center top-buffer">
                                        <span><strong>Or</strong></span>
                                    </div>
                                    <div class="row top-buffer">
                                        <div class="col-md-offset-3 col-md-6">
                                            <asp:LinkButton ID="SaveAndCreatePhotos" runat="server" OnClick="SaveAndCreatePhotos_Click" CssClass="btn btn-success btn-block">Save & attach existing pictures to trip&nbsp;<i class="glyphicon glyphicon-expand"></i></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <br />
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
    <script type="text/javascript">
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
    </script>
</asp:Content>