<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_BoishakhiOffer.aspx.cs" Inherits="BLL.Mkt_BoishakhiOffer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="panel-body" style="border: 1px solid #BDC3CA">
        <div class="form-horizontal clearfix">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Boishaki Offer
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="dtpFromDate" Text="From Date" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="dtpFromDate" runat="server" />
                                    <ajaxToolkit:CalendarExtender runat="server" TargetControlID="dtpFromDate" Format="yyyy-MM-dd" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="dtpToDate" Text="To Date" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="dtpToDate" runat="server" />
                                    <ajaxToolkit:CalendarExtender runat="server" TargetControlID="dtpToDate" Format="yyyy-MM-dd" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtLibrary" Text="Library Name" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtLibrary" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-8 col-md-offset-3">
                                    <asp:Button ID="btnLibrarySave" Text="Show" CssClass="btn btn-info" runat="server" />
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
                                        <asp:GridView ID="gvNewLibrary" CssClass="table " runat="server" AutoGenerateColumns="false">
                                            <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                            <Columns>
                                                <asp:BoundField HeaderText="Chalan Id" DataField="#" />
                                                <asp:BoundField HeaderText="Memo No" DataField="#" />
                                                <asp:BoundField HeaderText="Packet No" DataField="# " />
                                                <asp:BoundField HeaderText="Packet cost" DataField="#" />
                                                <asp:BoundField HeaderText="Total Packet cost" DataField="#" />
                                                <asp:BoundField HeaderText="Total Amount" DataField="#" />
                                                <asp:BoundField HeaderText="Amount Receivable" DataField="#" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>                                 
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtTotalChalan" runat="server" Text="Total Chalan" CssClass="col-md-3 control-label"></asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="txtTotalChalan" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtBonus" runat="server" Text="Bonus" CssClass="col-md-3 control-label"></asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="txtBonus" CssClass="form-control" ReadOnly="True"></asp:TextBox>
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
