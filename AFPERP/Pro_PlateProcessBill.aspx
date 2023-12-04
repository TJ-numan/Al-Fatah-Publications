<%@ Page Title="" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_PlateProcessBill.aspx.cs" Inherits="BLL.Pro_PlateProcessBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="form-horizontal clearfix" runat="server">
                <div class="panel-body" style="border: 1px solid #BDC3CA">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Plate Process Bill
                        </div>
                        <%--<div id="frmPlateProcessBill" runat="server" class="form-horizontal clearfix">--%>
                        <div class="panel-body">
                            <div class="col-md-12 no-padding clearfix">
                                <div class="col-md-6 clearfix">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtBillDate" CssClass="col-xs-4 control-label no-padding-right" Text="Bill Date"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtBillDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                            <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtBillDate" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtBillNo" CssClass="col-xs-4 control-label no-padding-right" Text="Bill No"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtBillNo" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlSupplier" CssClass="col-xs-4 control-label no-padding-right" Text="Supplier"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList ID="ddlSupplier" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 clearfix">
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="gvwReceiveDetails" CssClass="col-md-2 control-label no-padding-right" Text="Receive Detail"></asp:Label>
                                    <div class="col-md-8 table-responsive">
                                        <asp:GridView runat="server" CssClass="table grid-view" ID="gvwReceiveDetails" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelect_CheckedChanged" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="PlateQty" HeaderText="Plate Qty" />
                                                <asp:BoundField DataField="Pro_ID" HeaderText="PurchaseOrder" />
                                                <asp:BoundField DataField="TotalBill" HeaderText="Bill" />
                                                <asp:BoundField DataField="ReceiveIn" HeaderText="ReceiveIn" />
                                                <asp:BoundField DataField="PressID" HeaderText="PressID" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 clearfix no-padding">
                                <div class="col-md-6 col-md-offset-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtTotalQty" CssClass="col-xs-4 control-label no-padding-right" Text="Total Plate Qty"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtTotalQty" runat="server" CssClass="form-control" Text="0" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtTotalBill" CssClass="col-xs-4 control-label no-padding-right" Text="Total Bill"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtTotalBill" runat="server" CssClass="form-control" Text="0" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-xs-8 col-xs-offset-4">
                                            <asp:Button ID="btnShowBill" Text="Show Bill" CssClass="btn btn-info" runat="server" OnClick="btnShowBill_Click" />
                                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 clearfix">
                                <%--crystal report view--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSPro" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Plate");
        });
    </script>
</asp:Content>
