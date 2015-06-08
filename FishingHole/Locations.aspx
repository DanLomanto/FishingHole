<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Locations.aspx.cs" Inherits="FishingHole.Locations" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Locations" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="col-md-offset-1 col-md-10">
        <div class="panel panel-default">
            <div class="panel-heading clearfix">
                <div class="btn-group pull-right" style="padding-top: 15px;">
                    <a href="Location.aspx?id=0&returnUrl=locations" id="AddLocation" runat="server" class="btn btn-large btn-primary"><i class="glyphicon glyphicon-plus"></i>&nbsp;Locations</a>
                </div>
                <h3>Locations</h3>
            </div>
            <div class="panel-body">
                <div id="NoLocationsMessage" runat="server" class="row " style="margin-left: 10px">
                    <div class="alert alert-info col-md-5">
                        <span>You have not created any Locations yet...</span>
                    </div>
                </div>
                <div class="table-responsive">
                    <asp:UpdatePanel ID="LocationsGridUpdatePanel" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="LocationsGrid" OnSorting="LocationsGrid_Sorting" runat="server" AllowPaging="True" AllowSorting="True"
                                CssClass="table table-striped table-bordered table-hover" BorderStyle="NotSet" AutoGenerateColumns="false"
                                OnRowDataBound="OnLocationsRowDataBound" OnSelectedIndexChanged="OnLocationsSelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField ItemStyle-CssClass="maxWidthGrid" DataField="ID" HeaderText="ID" Visible="false" />
                                    <asp:BoundField ItemStyle-CssClass="maxWidthGrid" DataField="Name" HeaderText="Name" />
                                    <asp:BoundField ItemStyle-CssClass="maxWidthGrid" DataField="LattitudeDirection" HeaderText="Lattitude Direction" />
                                    <asp:BoundField ItemStyle-CssClass="maxWidthGrid" DataField="Lattitude" HeaderText="Lattitude" />
                                    <asp:BoundField ItemStyle-CssClass="maxWidthGrid" DataField="LongitudeDirection" HeaderText="Longitude Direction" />
                                    <asp:BoundField ItemStyle-CssClass="maxWidthGrid" DataField="Longitude" HeaderText="Longitude" />
                                    <asp:BoundField ItemStyle-CssClass="maxWidthGrid" DataField="StreetAddress" HeaderText="Street Address" />
                                    <asp:BoundField ItemStyle-CssClass="maxWidthGrid" DataField="CityTown" HeaderText="City/Town" />
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
            document.getElementById("LocationsNavItem").className = "active";
        });
    </script>
</asp:Content>