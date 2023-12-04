<%@ Page Title="Print Bill" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_PrintBill.aspx.cs" Inherits="BLL.Pro_PrintBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Print Bill
                </div>
                <%-- <div id="frmPrintingBill" runat="server" class="form-horizontal clearfix">--%>
                <div class="panel-body">
                    <div class="col-md-12 no-padding clearfix">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtPrintBillDate" CssClass="col-xs-4 control-label no-padding-right" Text="Date"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtPrintBillDate" runat="server" CssClass="form-control" placeholder="yyyy/mm/dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" TargetControlID="txtPrintBillDate" Format="yyyy/MM/dd" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtBillNo" CssClass="col-xs-4 control-label no-padding-right" Text="Bill No"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtBillNo" runat="server" CssClass="form-control" placeholder="Bill No" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlPressName" CssClass="col-xs-4 control-label no-padding-right" Text="Press"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlPressName" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlOrderNo" CssClass="col-xs-4 control-label no-padding-right" Text="Order No"></asp:Label>
                                <div class="col-xs-4">
                                    <asp:TextBox ID="ddlOrderNo" runat="server" CssClass="form-control" OnTextChanged="ddlOrderNo_TextChanged" AutoPostBack="true"/>
                                </div>
                                <div class="col-xs-4">
                                    <asp:DropDownList runat="server" ID="ddlPlateFor" CssClass="form-control">
                                        <asp:ListItem Value="C">Cover</asp:ListItem>
                                        <asp:ListItem Value="F">Forma</asp:ListItem>
                                        <asp:ListItem Value="A">Administrative</asp:ListItem>
                                        <asp:ListItem Value="P">Promotional</asp:ListItem>
                                        <asp:ListItem Value="Z">Zinix</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtPrintOrderDate" CssClass="col-xs-4 control-label no-padding-right" Text="Print Order Date"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtPrintOrderDate" runat="server" CssClass="form-control" placeholder="yyyy/mm/dd" disabled="" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtPrintQty" CssClass="col-xs-4 control-label no-padding-right" Text="Print Qty"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtPrintQty" runat="server" CssClass="form-control" disabled="" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtGroup" CssClass="col-xs-4 control-label no-padding-right" Text="Group"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtGroup" runat="server" CssClass="form-control" disabled="" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtClass" CssClass="col-xs-4 control-label no-padding-right" Text="Class"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtClass" runat="server" CssClass="form-control" disabled="" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtType" CssClass="col-xs-4 control-label no-padding-right" Text="Type"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtType" runat="server" CssClass="form-control" disabled="" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlBookName" CssClass="col-xs-4 control-label no-padding-right" Text="Book Name"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlBookName" runat="server" CssClass="form-control" Enabled="false" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtEdition" CssClass="col-xs-4 control-label no-padding-right" Text="Edition"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtEdition" runat="server" CssClass="form-control" disabled="" />
                                </div>
                            </div>
                            <div class="col-xs-8 col-xs-offset-4">
                                <asp:Label runat="server" AssociatedControlID="chkExtra" CssClass="control-label" Text="Extra Plate Supply"></asp:Label>
                                <asp:CheckBox CssClass="checkbox col-xs-1" runat="server" ID="chkExtra" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12 no-padding clearfix">
                        <div class="col-md-6">
                            <div class="table-responsive">
                                <asp:GridView ID="gvwPrintBill" runat="server" CssClass="grid-view table" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:BoundField DataField="SerialNo" HeaderText="Serial"/>
                                        <asp:BoundField DataField="BookPart" HeaderText="BookPart"/>
                                        <asp:BoundField DataField="PrintSl" HeaderText="Print No"/>
                                        <asp:BoundField DataField="FormaQty" HeaderText="Forma Qty"/>
                                        <asp:BoundField DataField="FormaDis" HeaderText="Description"/>
                                        <asp:BoundField DataField="ColorNo" HeaderText="Color No"/>
                                        <asp:BoundField DataField="PrintQty" HeaderText="Print Qty"/>
                                        <asp:BoundField DataField="BillRate" HeaderText="Rate"/>
                                        <asp:BoundField DataField="TotalBill" HeaderText="Bill"/>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="table-responsive">
                                <asp:GridView ID="gvwPlateBill" runat="server" CssClass="grid-view table" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:BoundField DataField="SlNo" HeaderText="Serial"/>
                                        <asp:BoundField DataField="Type" HeaderText="Plate Type"/>
                                        <asp:BoundField DataField="Size" HeaderText="Plate Size"/>
                                        <asp:BoundField DataField="PlateQty" HeaderText="Plate Qty"/>
                                        <asp:BoundField DataField="PlateGivenType" HeaderText="PlateGivenType"/>
                                        <asp:BoundField DataField="PlateBillRate" HeaderText="Plate Rate"/>
                                        <asp:BoundField DataField="ProcessGivenType" HeaderText="Process Type"/>
                                        <asp:BoundField DataField="ProcessBillRate" HeaderText="Process Rate"/>
                                        <asp:BoundField DataField="TotalAmount" HeaderText="Total"/>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12 no-padding clearfix">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtPrintBill" CssClass="control-label col-xs-4 no-padding-right" Text="Print Bill"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox runat="server" ID="txtPrintBill" CssClass="form-control" placeholder="0"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-8 col-xs-offset-4 text-right">
                                    <asp:Button runat="server" ID="btnPrintBillUpdate" Text="&lt;&lt; Update Bill &gt;&gt;" CssClass="btn btn-info btn-sm" OnClick="btnPrintBillUpdate_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtTotalPlateQty" CssClass="control-label col-xs-4 no-padding-right" Text="Total Plate Qty"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox runat="server" ID="txtTotalPlateQty" CssClass="form-control" placeholder="0"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtTotalPlateBill" CssClass="control-label col-xs-4 no-padding-right" Text="Total Plate Bill"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox runat="server" ID="txtTotalPlateBill" CssClass="form-control" placeholder="0"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtTotalProcessBill" CssClass="control-label col-xs-4 no-padding-right" Text="Total Process Bill"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox runat="server" ID="txtTotalProcessBill" CssClass="form-control" placeholder="0"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12 no-padding clearfix">
                        <div class="col-md-8">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtTotalBill" CssClass="col-xs-4 no-padding-right control-label" Text="Total Bill" runat="server"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox CssClass="form-control" ID="txtTotalBill" runat="server" placeholder="0"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtRemark" CssClass="col-xs-4 no-padding-right control-label" Text="Remark" runat="server"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox CssClass="form-control" ID="txtRemark" runat="server" placeholder="Remark" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                    </div>

                    <div class="col-md-12 no-padding clearfix">
                        <div class="form-group">
                            <div class="col-xs-8 col-xs-offset-4">
                                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                                <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-info" runat="server" OnClick="btnPrint_Click" />
                            </div>
                        </div>
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
            open_menu("Printing");
        });
    </script>
</asp:Content>
