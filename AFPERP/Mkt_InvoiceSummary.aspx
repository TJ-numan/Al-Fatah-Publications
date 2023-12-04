<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_InvoiceSummary.aspx.cs" Inherits="BLL.Mkt_InvoiceSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Summary Basic Information
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtSummarySL" ID="lbltxtSummarySL" CssClass="col-md-4 control-label no-padding-right" Text="Summary SL" runat="server"></asp:Label>
                                <div class="col-md-3">
                                    <asp:TextBox CssClass="form-control" ID="txtSummarySL" runat="server" ReadOnly="false" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlCompany" CssClass="col-md-4 control-label no-padding-right" Text="Emplyee For" runat="server"></asp:Label>
                                <div class="col-md-3">
                                    <asp:DropDownList CssClass="form-control" ID="ddlCompany" runat="server">
                                        <asp:ListItem Value="0" Text="--Select Company--"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Al Fatah Publications(Alia)"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Maktabatul Fatah Bangladesh(Qawmi)"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Chancellor Publications"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-4 control-label no-padding-right" Text="From" runat="server"></asp:Label>
                                <div class="col-md-3">
                                    <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-MM-dd" runat="server" />
                                    <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-4 control-label no-padding-right" Text="To" runat="server"></asp:Label>
                                <div class="col-md-3">
                                    <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-MM-dd" runat="server" />
                                    <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />

                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label AssociatedControlID="btnShow" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                <div class="col-md-3">
                                    <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-primary btn pull-left" runat="server" OnClick="btnShow_Click" />
                                    <asp:Button ID="btnSumPrint" Text="Summary Print" CssClass="btn btn-info btn pull-left" runat="server" OnClick="btnSumPrint_OnClick" />
                                    <asp:Button ID="btnMemoPrint" Text="Memo Print" CssClass="btn btn-dark btn pull-left" runat="server" OnClick="btnMemoPrint_OnClick" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h4>Invoice Details</h4>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive table-bordered clearfix ">
                                <div style="height: 400px; width: 780px; overflow: auto;">
                                    <asp:GridView ID="gvInvoiceDetails" CssClass="table " runat="server" AutoGenerateColumns="false" AllowPaging="false">
                                        <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                        <PagerSettings Mode="NumericFirstLast" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkMemoNo" runat="server" AutoPostBack="true" OnCheckedChanged="chkMemoNo_CheckedChanged" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="MemoNo" HeaderText="Memo No" />
                                            <asp:BoundField DataField="LibraryID" HeaderText="LibraryID" />
                                            <asp:BoundField DataField="TotalAmount" HeaderText="Amount" />
                                            <asp:BoundField DataField="PacketNo" HeaderText="Packet Qty" />
                                        </Columns>
                                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" Font-Size="Large" />
                                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="true" ForeColor="#F7F7F7" />
                                    </asp:GridView>
                                </div>
                            </div>
                            <br />
                        </div>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h4>Summary Details</h4>
                        </div>
                        <div class="panel-body" style="border: 1px solid #BDC3CA">
                            <div class="row">
                                <asp:GridView ID="gvSummaryDetails" runat="server" AutoGenerateColumns="False" CssClass="table">
                                    <Columns>
                                        <asp:BoundField DataField="MemoNo" HeaderText="Memo No" />
                                        <asp:BoundField DataField="LibraryID" HeaderText="LibraryID" />
                                        <asp:BoundField DataField="TotalAmount" HeaderText="Amount" />
                                        <asp:BoundField DataField="PacketNo" HeaderText="Packet Qty" />
                                    </Columns>
                                </asp:GridView>
                                <hr style="border: 1px solid silver" />
                            </div>
                            <asp:UpdatePanel runat="server" ID="UpdateArea">
                                <ContentTemplate>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtTotalPackNo" Text="Total Packet" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox CssClass="form-control" ID="txtTotalPackNo" AutoPostBack="true" runat="server" ReadOnly="true" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtTotalAmount" Text="Total Amount" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox CssClass="form-control" ID="txtTotalAmount" runat="server" ReadOnly="true" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-6">
                                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success btn pull-right" runat="server" OnClick="btnSave_OnClick" />
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
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
            open_menu("Challan");
        });
    </script>
</asp:Content>
