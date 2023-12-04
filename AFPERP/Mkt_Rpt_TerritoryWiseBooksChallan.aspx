<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Rpt_TerritoryWiseBooksChallan.aspx.cs" Inherits="BLL.Mkt_Rpt_TerritoryWiseBooksChallan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
<div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Territory Wise Book Sales Report
                </div>
                <div class=" panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlRegionMain" runat="server" CssClass="col-md-4 control-label no-padding-right" Text="Region Main" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlRegionMain" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlRegionMain_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlRegion" runat="server" CssClass="col-md-4 control-label" Text="Region" />
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
                        <asp:Label AssociatedControlID="ddlTeritory" CssClass="col-md-4 control-label" Text="Territory" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlTeritory" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-4 control-label" Text="From" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-MM-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-4 control-label" Text="To" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-MM-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />

                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlSession" CssClass="col-md-4 control-label" Text="Project Name " runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlSession" runat="server">                                
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlEdition" CssClass="col-md-4 control-label" Text="Edition" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlEdition" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="chkIsQawmi" CssClass="col-md-4 control-label" Text="IsQawmi" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:CheckBox CssClass="form-control" ID="chkIsQawmi" runat="server">
                            </asp:CheckBox>
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
                        <div class="col-md-8 col-md-offset-4">
                            <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info" runat="server" OnClick="btnShow_Click" />
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
                open_menu("Reports","Chalan");
            });
    </script>
</asp:Content>
