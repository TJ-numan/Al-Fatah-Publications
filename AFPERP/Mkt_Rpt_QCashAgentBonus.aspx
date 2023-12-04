<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Rpt_QCashAgentBonus.aspx.cs" Inherits="BLL.Mkt_Rpt_QCashAgentBonus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
        <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <h4>View QCash Agent Bonus Statement Report</h4>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlYear" CssClass="col-md-4 control-label no-padding-right" Text="Select Year" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                                <asp:ListItem Value="0">--Select Year--</asp:ListItem>
                                <asp:ListItem Value="1">2022-2023</asp:ListItem>
                                <asp:ListItem Value="2">2021-2022</asp:ListItem>
                                <asp:ListItem Value="3">2020-2021</asp:ListItem>
                                <asp:ListItem Value="4">2019-2020</asp:ListItem>
                                <asp:ListItem Value="5">2018-2019</asp:ListItem>
                                <asp:ListItem Value="6">2017-2018</asp:ListItem>
                                <asp:ListItem Value="7">2016-2017</asp:ListItem>
                                <asp:ListItem Value="8">2015-2016</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-4 control-label no-padding-right" Text="From" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-mm-dd" runat="server" ReadOnly="True" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-4 control-label no-padding-right" Text="To" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-mm-dd" runat="server" ReadOnly="True" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlLibraryName" CssClass="col-md-4 control-label no-padding-right" Text="Library Name" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlLibraryName" runat="server">
                                <asp:ListItem Value="-1">--Select Library--</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <%--                 <div class="form-group">
                            <asp:Label AssociatedControlID="ddlExportType" CssClass="col-md-4 control-label no-padding-right" Text="Output Format" runat="server"></asp:Label>
                            <div class="col-md-5">
                                <asp:DropDownList CssClass="form-control" ID="ddlExportType" runat="server">
                                    <asp:ListItem text="Select One" Value="-1"></asp:ListItem>
                                    <asp:ListItem text="PDF" Value="1"></asp:ListItem>
                                    <asp:ListItem text="DOC" Value="2"></asp:ListItem>
                                    <asp:ListItem text="EXCEL" Value="3"></asp:ListItem>
                                    <asp:ListItem text="HTML" Value="4"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>--%>
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
   <script>
         $(document).ready(function () {
             open_menu("Reports", "Chalan");
         });
    </script>
</asp:Content>
