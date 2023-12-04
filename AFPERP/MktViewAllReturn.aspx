<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="MktViewAllReturn.aspx.cs" Inherits="BLL.MktViewAllReturn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            View All Return
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtFromDate" CssClass="col-md-3 control-label no-padding-right" Text="From"></asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtToDate" CssClass="col-md-3 control-label no-padding-right" Text="To"></asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-3">
                                    <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info btn pull-right" runat="server" OnClick="btnShow_OnClick"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group">
                    <div class="col-md-10 col-md-offset-1">
                        <div class="search-input">
                            <i class="icon-search"></i>
                            <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" Placeholder="Search" />
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                        <asp:GridView ID="gvReturn" CssClass="table " runat="server" AutoGenerateColumns="false">
                            <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                            <Columns>
                                <asp:BoundField HeaderText="Return Id" DataField="ReturnID" />
                                <asp:BoundField HeaderText="Library Name" DataField="LibraryName" />
                                <asp:BoundField HeaderText="Library Address" DataField="LibraryAddress" />
                                <asp:BoundField HeaderText="Memo No" DataField="MemoNo" />
                                <asp:BoundField HeaderText="Total amount" DataField="TotalAmount" />
                                <asp:BoundField HeaderText="Packet No" DataField="PacketNo" />
                                 <asp:BoundField HeaderText="Per Packet cost" DataField="PerPacketCost" />
                                <asp:BoundField HeaderText="Amount Receivable" DataField="AmountReceivable" />
                                <asp:BoundField HeaderText="Sl no" DataField="SerialNo" />
                                <asp:BoundField HeaderText="Book Received By" DataField="BookReceivedBy" />                                                            
                            </Columns>
                        </asp:GridView>
                    </div>
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
     <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Returns");
        });
    </script>
</asp:Content>
