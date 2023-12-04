<%@ Page Title="" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_Rpt_PaperStock.aspx.cs" Inherits="BLL.Pro_Rpt_PaperStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
      <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Paper Stock
                </div>
                <%--<div id="frmPlateProcessBill" runat="server" class="form-horizontal clearfix">--%>
                <div class="panel-body">
                    <div class="col-md-12 no-padding clearfix">
                        <div class="col-md-6 clearfix">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="dtpFromDate" CssClass="col-xs-4 control-label no-padding-right" Text="From Date"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="dtpFromDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="dtpFromDate" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="dtpToDate" CssClass="col-xs-4 control-label no-padding-right" Text="To Date"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="dtpToDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="dtpToDate" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlType" CssClass="col-xs-4 control-label no-padding-right" Text="Type"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlSize" CssClass="col-xs-4 control-label no-padding-right" Text="Size"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlSize" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlSize_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlGSM" CssClass="col-xs-4 control-label no-padding-right" Text="GSM"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlGSM" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlPress" CssClass="col-xs-4 control-label no-padding-right" Text="Press"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlPress" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="input-group col-md-8 col-md-offset-4">
                                    <asp:CheckBox CssClass="" ID="chkPressWise" runat="server" />
                                    <asp:Label AssociatedControlID="chkPressWise" CssClass="control-label" runat="server" Text="Press Wise"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="input-group col-md-8 col-md-offset-4">
                                    <asp:CheckBox CssClass="" ID="chkPaperWise" runat="server" />
                                    <asp:Label AssociatedControlID="chkPaperWise" CssClass="control-label" runat="server" Text="Paper Wise"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlViewers" runat="server" CssClass="col-xs-4 control-label no-padding-right" Text="View Option" />
                                <div class="dropdown col-xs-8">
                                    <asp:DropDownList ID="ddlViewers" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0"> Select any type</asp:ListItem>
                                        <asp:ListItem Value="1"> View as Pdf File</asp:ListItem>
                                        <asp:ListItem Value="2"> View as Excel File</asp:ListItem>
                                        <asp:ListItem Value="3"> View as Word File</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-8 col-xs-offset-4">
                                    <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info" runat="server" OnClick="btnShow_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSPro" runat="server">
        <script type="text/javascript">
            $(document).ready(function () {
                open_menu("Reports", "Press");
            });
    </script>
</asp:Content>
