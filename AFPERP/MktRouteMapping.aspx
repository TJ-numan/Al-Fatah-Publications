<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="MktRouteMapping.aspx.cs" Inherits="BLL.MktRouteMapping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Route Mapping
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlUnitName" CssClass="col-md-3 control-label no-padding-right" Text="Unit Name"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlUnitName" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlDemarcationStep" CssClass="col-md-3 control-label no-padding-right" Text="Demarcation Step" ></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlDemarcationStep" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlDemarcationStep_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlDemarcationLocation" CssClass="col-md-3 control-label no-padding-right" Text="Demarcation Location"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlDemarcationLocation" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlDemarcationLocation_OnSelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtMadeBy" Text="Route Made By" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox CssClass="form-control" ID="txtMadeBy" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtVerifiedBy" Text="Route Verified By" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox CssClass="form-control" ID="txtVerifiedBy" runat="server" />
                                </div>
                            </div>
                            <div class="form-Inline">
                                <div class="form-group">
                                    <div class="col-md-4 col-md-offset-3">
                                        <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success btn pull-right" runat="server" OnClick="btnSave_OnClick" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="panel-body">
                    <div class="table-responsive table-bordered clearfix " style="height: 250px; overflow: auto">
                        <asp:GridView ID="dgvRouteMaping" CssClass="table " runat="server" AutoGenerateColumns="false">
                            <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                            <Columns>
                                 <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                    HeaderStyle-CssClass="HiddenColumn" />
                                <asp:BoundField HeaderText="Unit Name" DataField="Unit Name" />
                                <asp:BoundField HeaderText="Demarcation" DataField="Demarcation" />
                                <asp:BoundField HeaderText="Location Name" DataField="LocationName" />
                                <asp:BoundField HeaderText="MadeBy" DataField="MadeBy" />
                                <asp:BoundField HeaderText="Verified By" DataField="Verified By" />                              
                            </Columns>
                        </asp:GridView>
                    </div>
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Route Plan");
        });
    </script>
</asp:Content>
