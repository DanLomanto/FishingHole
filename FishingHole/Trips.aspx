<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Trips.aspx.cs" Inherits="FishingHole.Trips" %>

<%@ MasterType VirtualPath="~/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Trips" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="col-md-offset-1 col-md-10">
        <div class="panel panel-default">
            <div class="panel-heading clearfix">
                <div class="btn-group pull-right" style="padding-top: 15px;">
                    <a href="Trip.aspx?id=0&returnUrl=Trips" class="btn btn-large btn-primary"><i class="glyphicon glyphicon-plus"></i>&nbsp;Add Trip</a>
                </div>
                <h3>Trips</h3>
            </div>
            <div class="panel-body">
                <div id="NoTripsMessage" runat="server" class="row" style="margin-left: 10px">
                    <div class="alert alert-info col-md-5">
                        <span>You have not created any Trips yet...</span>
                    </div>
                </div>
                <div class="table-responsive">
                    <asp:UpdatePanel ID="TripsDataGridUpdatePanel" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="TripsDataGrid" OnSorting="TripsDataGrid_Sorting" runat="server" AllowPaging="True" AllowSorting="True"
                                CssClass="table table-striped table-bordered table-hover" BorderStyle="NotSet" AutoGenerateColumns="false"
                                OnSelectedIndexChanged="OnTripsSelectedIndexChanged" OnRowDataBound="OnTripsRowDataBound" AutoGenerateSelectButton="true">
                                <Columns>
                                    <asp:BoundField ItemStyle-CssClass="maxWidthGrid" DataField="ID" HeaderText="ID" Visible="false" />
                                    <asp:BoundField ItemStyle-CssClass="maxWidthGrid" DataField="Title" HeaderText="Title" />
                                    <asp:BoundField ItemStyle-CssClass="maxWidthGrid" DataField="Description" HeaderText="Description" />
                                    <asp:BoundField ItemStyle-CssClass="maxWidthGrid" DataField="TargetedSpecies" HeaderText="Targeted Species" />
                                    <asp:BoundField ItemStyle-CssClass="maxWidthGrid" DataField="WaterConditions" HeaderText="Water Conditions" />
                                    <asp:BoundField ItemStyle-CssClass="maxWidthGrid" DataField="WeatherConditions" HeaderText="Weather Conditions" />
                                    <asp:BoundField ItemStyle-CssClass="maxWidthGrid" DataField="DateOfTrip" HeaderText="Date of Trip" />
                                    <asp:BoundField ItemStyle-CssClass="maxWidthGrid" DataField="FliesLuresUsed" HeaderText="Flies/Lures Used" />
                                    <asp:BoundField ItemStyle-CssClass="maxWidthGrid" DataField="CatchOfTheDay" HeaderText="Catch of The Day" />
                                    <asp:BoundField ItemStyle-CssClass="maxWidthGrid" DataField="OtherNotes" HeaderText="Other Notes" />
                                    <asp:BoundField ItemStyle-CssClass="maxWidthGrid" DataField="CreateDate" HeaderText="Create Date" />
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            document.getElementById("TripsNavItem").className = "active";
        });
    </script>
</asp:Content>