<%@ Page Title="Agent Summary" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Rpt_AgentSummary.aspx.cs" Inherits="BLL.Mkt_Rpt_AgentSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    View Agent Summary Report
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlRegionMain" runat="server" CssClass="col-md-4 control-label no-padding-right" Text="Region Main" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlRegionMain" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlRegionMain_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlRegion" runat="server" CssClass="col-md-4 control-label" Text="Sub Region" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlDivision" runat="server" CssClass="col-md-4 control-label" Text="Division" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlDivision" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlZone" runat="server" CssClass="col-md-4 control-label" Text="Zone" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlZone" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlTeritory" runat="server" CssClass="col-md-4 control-label" Text="Teritory" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlTeritory" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="input-group col-md-8 col-md-offset-4">
                            <asp:CheckBox CssClass="" ID="chkQawmi" runat="server" />
                            <asp:Label AssociatedControlID="chkQawmi" CssClass="control-label" runat="server" Text="Qawmi"></asp:Label>
                        </div>
                        <div class="input-group col-md-8 col-md-offset-4">
                            <asp:CheckBox CssClass="" ID="chkWithCash" runat="server" />
                            <asp:Label AssociatedControlID="chkWithCash" CssClass="control-label" runat="server" Text="Cash"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-4 control-label" Text="From Date" runat="server"></asp:Label>
                        <div class="input-group col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-4 control-label" Text="To Date" runat="server"></asp:Label>
                        <div class="input-group col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlViewers" runat="server" CssClass="col-md-4 control-label" Text="View Option" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlViewers" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0"> Select any type</asp:ListItem>
                                <asp:ListItem Value="1"> View as Pdf File</asp:ListItem>
                                <asp:ListItem Value="2"> View as Excel File</asp:ListItem>
                                <asp:ListItem Value="3"> View as Word File</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="input-group col-md-8 col-md-offset-4">
                            <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info" runat="server" OnClick="btnShow_Click"  />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Reports", "Others");
        });
    </script>
</asp:Content>
