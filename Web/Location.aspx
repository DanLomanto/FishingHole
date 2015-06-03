﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Location.aspx.cs" Inherits="Location" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="col-md-8 col-md-offset-2" style="min-width: 750px">
        <div class="panel panel-default">
            <div class="panel-heading text-center">
                <h3>Location Information</h3>
            </div>
            <div class="panel-body">
                <div class="row text-center">
                    <asp:BulletedList ID="formErrors" runat="server" CssClass="col-centered" />
                </div>
                <div class="row form-group top-buffer">
                    <label for="LocationName" class="col-md-4 control-label">Name:</label>
                    <div class="col-m-10">
                        <input type="text" runat="server" id="LocationName" class="form-control has-error" placeholder="Name" maxlength="50" />
                    </div>
                </div>
                <div class="row form-group top-buffer">
                    <label for="MainContent_AssociatedTrip" class="col-md-4 control-label">Associated Trip:</label>
                    <select id="AssociatedTrip" runat="server" class="form-control">
                    </select>
                </div>
                <div class="row form-group top-buffer">
                    <label for="Description" class="col-md-4 control-label">Description:</label>
                    <div>
                        <textarea runat="server" id="Description" class="form-control" placeholder="Description" rows="4" cols="50" maxlength="500" />
                    </div>
                </div>
                <div class="row top-buffer">
                    <div class="form-group">
                        <label for="locationType" class="col-md-4 control-label">Select how you'd like to enter your location:</label>
                        <select id="locationType" runat="server" class="form-control">
                            <option value="SelectOption">Select Option...</option>
                            <option value="StreetAddress">Street Address</option>
                            <option value="Coordinates">Coordinates</option>
                        </select>
                    </div>
                    <div class="row top-buffer">
                        <div class="container">
                            <div id="AddressControl">
                                <div class="form-group">
                                    <label for="StreetAddress" class="col-md-4 control-label">Street Address:</label>
                                    <div class="col-m-10">
                                        <input type="text" runat="server" id="StreetAddress" class="form-control" placeholder="Street Address" maxlength="255" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="Address" class="col-md-4 control-label">City/Town:</label>
                                    <div class="col-m-10">
                                        <input type="text" runat="server" id="CityTown" class="form-control" placeholder="City/Town" maxlength="255" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="Address" class="col-md-4 control-label">State:</label>
                                    <select id="States" runat="server" class="form-control">
                                        <option value="AL">Alabama</option>
                                        <option value="AK">Alaska</option>
                                        <option value="AZ">Arizona</option>
                                        <option value="AR">Arkansas</option>
                                        <option value="CA">California</option>
                                        <option value="CO">Colorado</option>
                                        <option value="CT">Connecticut</option>
                                        <option value="DE">Delaware</option>
                                        <option value="DC">District Of Columbia</option>
                                        <option value="FL">Florida</option>
                                        <option value="GA">Georgia</option>
                                        <option value="HI">Hawaii</option>
                                        <option value="ID">Idaho</option>
                                        <option value="IL">Illinois</option>
                                        <option value="IN">Indiana</option>
                                        <option value="IA">Iowa</option>
                                        <option value="KS">Kansas</option>
                                        <option value="KY">Kentucky</option>
                                        <option value="LA">Louisiana</option>
                                        <option value="ME">Maine</option>
                                        <option value="MD">Maryland</option>
                                        <option value="MA">Massachusetts</option>
                                        <option value="MI">Michigan</option>
                                        <option value="MN">Minnesota</option>
                                        <option value="MS">Mississippi</option>
                                        <option value="MO">Missouri</option>
                                        <option value="MT">Montana</option>
                                        <option value="NE">Nebraska</option>
                                        <option value="NV">Nevada</option>
                                        <option value="NH">New Hampshire</option>
                                        <option value="NJ">New Jersey</option>
                                        <option value="NM">New Mexico</option>
                                        <option value="NY">New York</option>
                                        <option value="NC">North Carolina</option>
                                        <option value="ND">North Dakota</option>
                                        <option value="OH">Ohio</option>
                                        <option value="OK">Oklahoma</option>
                                        <option value="OR">Oregon</option>
                                        <option value="PA">Pennsylvania</option>
                                        <option value="RI">Rhode Island</option>
                                        <option value="SC">South Carolina</option>
                                        <option value="SD">South Dakota</option>
                                        <option value="TN">Tennessee</option>
                                        <option value="TX">Texas</option>
                                        <option value="UT">Utah</option>
                                        <option value="VT">Vermont</option>
                                        <option value="VA">Virginia</option>
                                        <option value="WA">Washington</option>
                                        <option value="WV">West Virginia</option>
                                        <option value="WI">Wisconsin</option>
                                        <option value="WY">Wyoming</option>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label for="ZipCode" class="col-md-4 control-label">Zipcode:</label>
                                    <div class="col-m-2">
                                        <input type="text" runat="server" id="ZipCode" class="form-control" placeholder="Zipcode" maxlength="5" onkeypress='onlyAllowNumbers(event)' />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="CoordinatesControl" class="row top-buffer">
                        <div class="col-md-offset-2">
                            <div class="row">
                                <label for="Lattitude" class="col-md-2 control-label">Lattitude:</label>
                                <select id="LattitudeDropDown" runat="server" class="col-md-2 form-control" style="width: 65px">
                                    <option value="N">N</option>
                                    <option value="S">S</option>
                                </select>
                                <input type="text" runat="server" id="Lattitude" class="col-md-4 form-control" placeholder="Lattitude Coordinates" maxlength="20" onkeypress='onlyAllowNumbersAndPeriod(event)' /><p>&nbsp;&deg</p>
                            </div>
                            <div class="row top-buffer">
                                <label for="Longitude" class="col-md-2 control-label">Longitude:</label>
                                <select id="LongitudeDropDown" runat="server" class="col-md-2 form-control" style="width: 65px; margin-left: 10px">
                                    <option value="E">E</option>
                                    <option value="W">W</option>
                                </select>
                                <input type="text" runat="server" id="Longitude" class="col-md-4 form-control" placeholder="Longitude Coordinates" maxlength="20" onkeypress='onlyAllowNumbersAndPeriod(event)' /><p>&nbsp;&deg</p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row top-buffer text-center">
                    <iframe id="GoogleMap" runat="server" visible="false"
                        width="600"
                        height="450"
                        frameborder="0" style="border: 0"
                        src="placeholder" />
                </div>
                <div class="form-group top-buffer">
                    <div class="text-center">
                        <asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="btn btn-m btn-primary" OnClick="SaveButton_Click"></asp:Button>
                        <asp:Button ID="CancelButton" runat="server" Text="Cancel" CssClass="btn btn-m btn-default" OnClick="CancelButton_Click"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            var addressControl = document.getElementById('AddressControl');
            addressControl.style.display = 'none';
            var coordinatesControl = document.getElementById('CoordinatesControl');
            coordinatesControl.style.display = 'none';

            $("select").change(function () {
                $("select option:selected").each(function () {
                    if ($(this).attr("value") == "SelectOption") {
                        addressControl.style.display = 'none';
                        coordinatesControl.style.display = 'none';
                    }
                    if ($(this).attr("value") == "StreetAddress") {
                        addressControl.style.display = '';
                        coordinatesControl.style.display = 'none';
                    }
                    if ($(this).attr("value") == "Coordinates") {
                        addressControl.style.display = 'none';
                        coordinatesControl.style.display = '';
                    }
                });
            }).change();
        });

        function onlyAllowNumbers(evt) {
            var theEvent = evt || window.event;
            var key = theEvent.keyCode || theEvent.which;
            key = String.fromCharCode(key);
            var regex = /[0-9]/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        function onlyAllowNumbersAndPeriod(evt) {
            var theEvent = evt || window.event;
            var key = theEvent.keyCode || theEvent.which;
            key = String.fromCharCode(key);
            var regex = /[0-9]|\./;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }
    </script>
</asp:Content>