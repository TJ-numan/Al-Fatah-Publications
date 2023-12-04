<%@ Page Title="Paper Purhcase" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_PaperPurchase.aspx.cs" Inherits="BLL.Pro_PaperPurchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Paper Purchasing Order
                </div>
                <%--<div id="frmPaperPurchase" class="form-horizontal clearfix" runat="server">--%>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtSerialNo" CssClass="col-md-4 control-label" Text="Serial No" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtSerialNo" placeholder="Serial No" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpOrderDate" CssClass="col-md-4 control-label" Text="Date" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="dtpOrderDate" placeholder="yyyy-MM-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="dtpOrderDate" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtOrderNo" CssClass="col-md-4 control-label" Text="Order No" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtOrderNo" placeholder="Order No" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlPartyName" CssClass="col-md-4 control-label" Text="Party Name" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlPartyName" runat="server">
                            </asp:DropDownList>

                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtAddress" CssClass="col-md-4 control-label" Text="Address" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtAddress" placeholder="Address" runat="server" />
                        </div>
                    </div>

                    <div class="table-responsive col-md-8 col-md-offset-2 no-padding">
                        <table class="table no-head-padding">
                            <tr>
                                <td>
                                    <asp:Label ID="lblPaperType" runat="server" Text="Type"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaperSize" runat="server" Text="Size"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaperGSM" runat="server" Text="GSM"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaperBrand" runat="server" Text="Brand"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaperOrigin" runat="server" Text="Origin"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlPaperType" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlPaperType_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPaperSize" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlPaperSize_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPaperGSM" runat="server" CssClass="form-control"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPaperBrand" runat="server" CssClass="form-control"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPaperOrigin" runat="server" CssClass="form-control"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtQuantity" CssClass="col-md-4 control-label" Text="Quantity" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <span class="col-xs-9 no-padding">
                                <asp:TextBox CssClass="form-control col-xs-9" ID="txtQuantity" placeholder="Paper Quantity" runat="server" AutoPostBack ="true"  OnTextChanged="txtUnitPrice_TextChanged"/>
                            </span>
                            <span class="col-xs-3 no-padding padding-left">
                                <asp:DropDownList CssClass="form-control col-xs-3" ID="ddlPaperQtyUnit" placeholder="Unit" runat="server" />
                            </span>
                            <span>
                                <asp:Label ID="lblRoll" runat="server" Text="Roll : " Visible="false"></asp:Label>
                                <asp:TextBox ID="txtRoll" runat="server" Visible="false"></asp:TextBox>
                            </span>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtUnitPrice" CssClass="col-md-4 control-label" Text="Price" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtUnitPrice" placeholder="0" runat="server" AutoPostBack="true" OnTextChanged="txtUnitPrice_TextChanged" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtTotal" CssClass="col-md-4 control-label" Text="Total" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtTotal" placeholder="0" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtRemark" CssClass="col-md-4 control-label" Text="Remarks" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtRemark" placeholder="Remarks" runat="server" TextMode="MultiLine" />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">
                            <asp:Button ID="btnPaperSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnPaperSave_Click" />
                            <%-- <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-info" runat="server" />--%>
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
            open_menu("Paper");
        });
    </script>
</asp:Content>
