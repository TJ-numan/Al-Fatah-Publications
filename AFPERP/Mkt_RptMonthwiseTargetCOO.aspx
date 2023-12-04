<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_RptMonthwiseTargetCOO.aspx.cs" Inherits="BLL.Mkt_RptMonthwiseTargetCOO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
<div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Monthwise Target & Aceivement Report
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlCompany" runat="server" CssClass="control-label col-md-4" Text="Company Name" />
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlCompany" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0">--Select Company--</asp:ListItem>
                                <asp:ListItem Value="1">Al Fatah Publications</asp:ListItem>
                                <asp:ListItem Value="2">Maktabatul Fatah Bangladesh</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    
                    <div class="form-group">
                        <label class="control-label col-md-4">Select Year</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlYear" runat="server" Width="377" TabIndex="4" CssClass="form-control">
                                <asp:ListItem Text="Select Any" Value="0"></asp:ListItem>
                                <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
                                <asp:ListItem Text="2024" Value="2024"></asp:ListItem>
                                <asp:ListItem Text="2025" Value="2025"></asp:ListItem>
                                <asp:ListItem Text="2026" Value="2026"></asp:ListItem>
                                <asp:ListItem Text="2027" Value="2027"></asp:ListItem>
                                <asp:ListItem Text="2028" Value="2028"></asp:ListItem>
                                <asp:ListItem Text="2029" Value="2029"></asp:ListItem>
                                <asp:ListItem Text="2030" Value="2030"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>


                    <div class="form-group">
                        <label class="control-label col-md-4">Select Month</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlMonth" runat="server" Width="377" TabIndex="4" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                                <asp:ListItem Text="Select Any" Value="0"></asp:ListItem>
                                <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                <asp:ListItem Text="February" Value="2"></asp:ListItem>
                                <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                <asp:ListItem Text="December" Value="12"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-4 control-label" Text="From" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpFromDate"  Text="" ReadOnly="true" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-4 control-label" Text="To" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpToDate"  Text="" ReadOnly="true" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />
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
                        <asp:Label AssociatedControlID="ddlTeritory" runat="server" CssClass="col-md-4 control-label" Text="Teritory" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlTeritory" runat="server" CssClass="form-control"></asp:DropDownList>
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
                open_menu("Reports", "Management");
            });
    </script>
</asp:Content>
