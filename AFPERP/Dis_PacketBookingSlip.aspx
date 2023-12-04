<%@ Page Title="" Language="C#" MasterPageFile="~/Distribution.master" AutoEventWireup="true" CodeBehind="Dis_PacketBookingSlip.aspx.cs" Inherits="BLL.Reports.Store.Dis_PacketBookingSlip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DistributionContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Packet Booking Slip
                        </div>
                        <div class="panel-body">

                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlCompany" CssClass="col-md-4 control-label no-padding-right" Text="Unit For" runat="server"></asp:Label>
                                <div class="col-md-3">
                                    <asp:DropDownList CssClass="form-control" ID="ddlCompany" runat="server">
                                        <asp:ListItem Value="0" Text="--Select Company--"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Al Fatah Publications(Alia)"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Maktabatul Fatah Bangladesh(Qawmi)"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Chancellor Publications"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Al Fatah Sales Center"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="Maktabatul Fatah Sales Center"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtMemoNo" ID="lbltxtMemono" CssClass="col-md-4 control-label no-padding-right" Text="Memo No" runat="server"></asp:Label>
                                <div class="col-md-3">
                                    <asp:TextBox CssClass="form-control" ID="txtMemoNo" runat="server" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label AssociatedControlID="btnPrint" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                <div class="col-md-3">
                                    <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-primary btn pull-left" runat="server" OnClick="btnPrint_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSDistribution" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Challan");
        });
    </script>
</asp:Content>
