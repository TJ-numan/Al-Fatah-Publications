<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_ChalanDelivery.aspx.cs" Inherits="BLL.Mkt_ChalanDelivery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
     <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Chalan Delivery
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="dtpFromDate" Text="From Date" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="dtpFromDate" runat="server" />
                                    <ajaxToolkit:CalendarExtender runat="server" TargetControlID="dtpFromDate" Format="yyyy-MM-dd"/>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label AssociatedControlID="dtpToDate" Text="To Date" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="dtpToDate" runat="server" />
                                    <ajaxToolkit:CalendarExtender runat="server" TargetControlID="dtpToDate" Format="yyyy-MM-dd"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtFromMemo" Text="From Memo" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtFromMemo" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtToMemo" Text="To Memo" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtToMemo" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtChalanQty" CssClass="col-md-3 control-label" Text="Chalan Quantity" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtChalanQty" runat="server" />
                                </div>
                            </div>    
                              <div class="form-group">
                                <asp:Label AssociatedControlID="txtPacketyQty" CssClass="col-md-3 control-label" Text="Packet Quantity" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtPacketyQty" runat="server" />
                                </div>
                            </div>                                              
                            <div class="form-group">
                                <div class="col-md-8 col-md-offset-3">
                                    <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info" runat="server" OnClick="btnShow_OnClick"/>                                  
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel">
                <div class="panel-body">
                    <div class="form-group">
                        <div class="col-md-10">
                            <div class="search-input">
                                <i class="icon-search"></i>
                                <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" Placeholder="Search" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="panel panel-success">                         
                                <div class="panel-body">
                                    <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                                        <asp:GridView ID="gvAllChalan" CssClass="table " runat="server" AutoGenerateColumns="false">
                                            <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                            <Columns>
                                                <asp:BoundField HeaderText="Select" DataField="Select" />
                                                <asp:BoundField HeaderText="Memo No" DataField="MemoNo" />
                                                <asp:BoundField HeaderText="Packet Date" DataField="PktDate" />
                                                <asp:BoundField HeaderText="Packet Qty" DataField="PktQty" />
                                                <asp:BoundField HeaderText="Per Packet cost" DataField="PerPktcost" />
                                                <asp:BoundField HeaderText="Packet By" DataField="PacketBy" />
                                                <asp:BoundField HeaderText="Received By" DataField="ReceivedBy" />
                                                <asp:BoundField HeaderText="Checked By" DataField="CheckedBy"/>
                                                <asp:BoundField HeaderText="Delivery Data" DataField="DeliveryData"/>                                            
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <br />
                                </div>
                            </div>
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
