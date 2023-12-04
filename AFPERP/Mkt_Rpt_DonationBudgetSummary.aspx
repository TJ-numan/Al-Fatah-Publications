<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Rpt_DonationBudgetSummary.aspx.cs" Inherits="BLL.Mkt_Rpt_DonationBudgetSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div id="frmChallanNew" runat="server" class="form-horizontal clearfix">
        <div class="panel-body " style="border: 1px solid #BDC3CA">
            <div class="col-md-12 clearfix no-padding">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Donation Budget Summary
                    </div>
                    <div class="panel-body">
                        
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlAgreementYear" Text="Session" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList CssClass="form-control" ID="ddlAgreementYear" runat="server" OnSelectedIndexChanged="ddlAgreementYear_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
<%--                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlYear" CssClass="col-md-4 control-label" Text="Year" runat="server"></asp:Label>
                            <div class="dropdown col-md-5">
                                <asp:DropDownList CssClass="form-control" ID="ddlYear" runat="server" AutoPostBack="false">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="2017-2018" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="2016-2017" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <asp:Label runat="server" ID="lblYearMsg"></asp:Label>
                        </div>--%>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-4 control-label" Text="From Date" runat="server" ID="lblFromDate"  Visible="False"></asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-mm-dd" runat="server" ReadOnly="True" Visible="False"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-4 control-label" Text="To Date" runat="server" ID="lblToDate"  Visible="False"></asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-mm-dd" runat="server" ReadOnly="True"  Visible="False"/>
                        </div>
                    </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="ddlDonationType" CssClass="col-md-4 control-label no-padding-right" Text="Donation Type" ID="lblDonType"></asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList runat="server" ID="ddlDonationType" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlViewers" runat="server" CssClass="col-md-4 control-label" Text="View Option" />
                            <div class="dropdown col-md-4">
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
                                <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info" runat="server" OnClick="btnShow_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
    <script>
        $(document).ready(function () {
            open_menu("Reports", "Madrasah");
        });
    </script>
</asp:Content>
