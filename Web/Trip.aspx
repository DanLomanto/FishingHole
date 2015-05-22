<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Trip.aspx.cs" Inherits="Trip" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Trip" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <div class="panel-heading text-center">
                <h3>Trip Information</h3>
            </div>
            <div class="panel-body">
                <div class="container">
                    <div class="col-md-offset-1 col-md-10">
                        <div class="text-center">
                            <asp:BulletedList ID="formErrors" runat="server" CssClass="col-centered" />
                        </div>
                        <div class="form-group">
                            <label for="TripTitle" class="col-md-4 control-label">Title:</label>
                            <div>
                                <input type="text" runat="server" id="TripTitle" class="form-control has-error" placeholder="Title" maxlength="255" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="Description" class="col-md-4 control-label">Description:</label>
                            <div>
                                <textarea runat="server" id="Description" class="form-control" placeholder="Description" rows="4" cols="50" maxlength="500" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="TargetedSpecies" class="col-md-4 control-label">Targeted Species:</label>
                            <div>
                                <input type="text" runat="server" id="TargetedSpecies" class="form-control" placeholder="Targeted Species" maxlength="255" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="WaterConditions" class="col-md-4 control-label">Water Conditions:</label>
                            <div>
                                <input type="text" runat="server" id="WaterConditions" class="form-control" placeholder="Water Conditions" maxlength="255" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="WeatherConditions" class="col-md-4 control-label">Weather Conditions:</label>
                            <div>
                                <input type="text" runat="server" id="WeatherConditions" class="form-control" placeholder="Weather Conditions" maxlength="255" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="MainContent_TripDate" class="col-md-4 control-label">Trip Date:</label>
                            <div>
                                <input id="TripDate" runat="server" type="text" class="date-picker form-control pull-left" placeholder="Trip Date" maxlength="10" />
                                <label id="datepickerImage" for="MainContent_TripDate" class="btn input-group-addon">
                                    <i class="glyphicon glyphicon-calendar"></i>
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="CatchOfTheDay" class="col-md-4 control-label">Catch of The Day:</label>
                            <div>
                                <input type="text" runat="server" id="CatchOfTheDay" class="form-control" placeholder="Catch of The Day" maxlength="255" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="FliesLuresUsed" class="col-md-4 control-label">Flies\Lures Used:</label>
                            <div>
                                <input type="text" runat="server" id="FliesLuresUsed" class="form-control" placeholder="Flies\Lures Used" maxlength="255" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="OtherNotes" class="col-md-4 control-label">Other Notes:</label>
                            <div>
                                <textarea type="text" runat="server" id="OtherNotes" class="form-control" placeholder="Other Notes" rows="4" cols="50" maxlength="500" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="container col-md-10 col-md-offset-1">
                    <div class="panel-group" id="accordion">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none; color: #606060;">
                                    <h4 class="panel-title">Create or Attach a Location
                                    </h4>
                                </a>
                            </div>
                            <div id="collapseOne" class="panel-collapse collapse" aria-expanded="false">
                                <div class="panel-body">
                                    <div class="row">
                                        <label for="AssociatedLocation" class="col-md-4 control-label">Location:</label>
                                        <select id="AssociatedLocation" runat="server" class="form-control">
                                        </select>
                                    </div>
                                    <div class="row text-center">
                                        <span>Or</span>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-offset-2 col-md-8">
                                            <a id="SaveAndCreateLocation" runat="server" href="#" class="btn btn-success btn-block">Save & Create New Location</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" style="text-decoration: none; color: #606060;">
                                    <h4 class="panel-title">Upload or Attach Photos
                                    </h4>
                                </a>
                            </div>
                            <div id="collapseTwo" class="panel-collapse collapse" aria-expanded="false">
                                <div class="panel-body">
                                    <div class="row">
                                        <span>Select a Location:</span>
                                    </div>
                                    <div class="row">
                                        <span>Or</span>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-offset-2 col-md-8">
                                            <a id="SaveAndCreatePhotos" runat="server" href="#" class="btn btn-success btn-block">Save & Upload New Photos</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <br />
                <br />
                <br />
                <div class="container">
                    <div class="row">
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
    </div>

    <script src="Scripts/pikaday.js"></script>
    <script>
    </script>
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