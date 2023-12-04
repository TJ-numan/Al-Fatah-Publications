<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Rpt_DatewiseBookStockQty.aspx.cs" Inherits="BLL.Mkt_Rpt_DatewiseBookStockQty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
<div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    View Book Available Stock
                </div>
                <div class="panel-body">
                    <div class="form-group">
                            <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-3 control-label" Text="From" runat="server"></asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-mm-dd" runat="server" />
                                <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-3 control-label" Text="To" runat="server"></asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-mm-dd" runat="server" />
                                <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlCom" CssClass="col-md-3 control-label no-padding-left" Text=" Select Company"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlCom" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCom_SelectedIndexChanged">
                                        <asp:ListItem Value=" " Text="--Select--"></asp:ListItem>
                                        <asp:ListItem Value="A" Text="Alia"></asp:ListItem>
                                        <asp:ListItem Value="Q" Text="Qawmi"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                        </div>
                        <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlCategory" CssClass="col-xs-3 control-label no-padding-right" Text="Category"></asp:Label>
                                <div class="col-xs-4">
                                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlGroup" CssClass="col-xs-3 control-label no-padding-right" Text="Group"></asp:Label>
                                <div class="col-xs-4">
                                    <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlClass" CssClass="col-xs-3 control-label no-padding-right" Text="Class"></asp:Label>
                                <div class="col-xs-4">
                                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlType" CssClass="col-xs-3 control-label no-padding-right" Text="Type"></asp:Label>
                                <div class="col-xs-4">
                                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlBookName" runat="server" CssClass="col-md-3 control-label no-padding-right" Text="Book Name" />
                            <div class="dropdown col-md-4">
                                <asp:DropDownList ID="ddlBookName" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                      <div class="form-group">
                        <asp:Label AssociatedControlID="ddlViewers" runat="server" CssClass="col-md-3 control-label" Text="View Option" />
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
                        <div class="input-group col-md-4 col-md-offset-3">
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
            open_menu("Reports", "Book");
        });
    </script>
</asp:Content>

