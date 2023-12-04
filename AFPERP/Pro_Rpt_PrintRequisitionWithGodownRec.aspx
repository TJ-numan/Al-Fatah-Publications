<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Pro_Rpt_PrintRequisitionWithGodownRec.aspx.cs" Inherits="BLL.Pro_Rpt_PrintRequisitionWithGodownRec" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Print Requisition With Godown Receive
                </div>
                <%--<div id="frmReturnFromBinder" runat="server" class="form-horizontal clearfix">--%>
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
                                <asp:Label runat="server" AssociatedControlID="ddlCategory" CssClass="col-xs-4 control-label no-padding-right" Text="Category"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlGroup" CssClass="col-xs-4 control-label no-padding-right" Text="Group"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlClass" CssClass="col-xs-4 control-label no-padding-right" Text="Class"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlType" CssClass="col-xs-4 control-label no-padding-right" Text="Type"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlBookName" CssClass="col-sm-4 control-label no-padding-right" Text="Book Name"></asp:Label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="ddlBookName" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlBookName_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlEdition" CssClass="col-xs-4 control-label no-padding-right" Text="Edition"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlEdition" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlViewers" runat="server" CssClass="col-sm-4 control-label no-padding-right" Text="View Option" />
                                <div class="col-sm-8">
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
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Reports", "Book");
        });
    </script>
</asp:Content>
