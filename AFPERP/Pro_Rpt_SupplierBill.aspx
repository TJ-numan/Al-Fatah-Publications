<%@ Page Title="" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_Rpt_SupplierBill.aspx.cs" Inherits="BLL.Pro_Rpt_SupplierBill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Print Paper Bill
                </div>
                <%--<div id="frmPlateProcessBill" runat="server" class="form-horizontal clearfix">--%>
                <div class="panel-body">
                    <div class="col-md-12 no-padding clearfix">
                        <div class="col-md-6 clearfix">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlSupplier" CssClass="col-xs-4 control-label no-padding-right" Text="Supplier"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlSupplier" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtBillNo" CssClass="col-xs-4 control-label no-padding-right" Text="Bill No"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtBillNo" runat="server" CssClass="form-control" />
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
                    open_menu("Reports", "Paper Supplier");
                });
    </script>
</asp:Content>
