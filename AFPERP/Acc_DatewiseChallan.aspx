<%@ Page Title="" Language="C#" MasterPageFile="~/AccountingMaster.master" AutoEventWireup="true" CodeBehind="Acc_DatewiseChallan.aspx.cs" Inherits="BLL.Acc_DatewiseChallan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountingContent" runat="server">

    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    View Datewise Chalan Memo Report
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-4 control-label" Text="From" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-4 control-label" Text="To" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>




                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlVoucherType" CssClass="col-md-4 control-label" Text="Voucher Type" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control date" ID="ddlVoucherType"  runat="server" >
                                <asp:ListItem Text= "Regular" Value ="11" Selected ="True"></asp:ListItem>
                                <asp:ListItem Text ="Boishaki Challan" Value ="00"></asp:ListItem>
                                <asp:ListItem Text ="Boishaki Bonus -M" Value ="101"></asp:ListItem>
                                <asp:ListItem Text ="Qawmi" Value ="10"></asp:ListItem>
                            </asp:DropDownList>
                             
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">
                            <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info" runat="server" OnClick="btnShow_Click" />

                            <asp:Button ID="btnConvertXML" Text="Convert XML" CssClass="btn btn-info" runat="server" OnClick="btnConvertXML_Click" />

                            <asp:Button ID="DownloadXML" Text="Download XML" CssClass="btn btn-info" runat="server" OnClick="DownloadXML_Click" />
                        </div>
                    </div>

                    <div class="panel-body">
                        <div class="table-responsive table-bordered clearfix ">
                            <asp:GridView ID="gvDatewiseChallan" CssClass="table " runat="server" AutoGenerateColumns="false">
                                <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                <Columns>

                                    <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" DataFormatString="{0:yyyy-MM-dd}" />
                                    <asp:BoundField DataField="LibraryID" HeaderText="ID" />
                                    <asp:BoundField DataField="Library" HeaderText="Library" />
                                    <asp:BoundField DataField="MemoNo" HeaderText="MemoNo" />
                                    <asp:BoundField DataField="TotalAmount" HeaderText="Challan" />
                                    <asp:BoundField DataField="TotalPacCost" HeaderText="PacketCost" />
                                    <asp:BoundField DataField="AmountReceivable" HeaderText="Total" />

                                </Columns>
                            </asp:GridView>
                        </div>
                        <br />
                    </div>

                </div>
            </div>
        </div>
    </div>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSAcc" runat="server">

    <script type="text/javascript">
        $(function () {
            $('[id*=gvDatewiseChallan]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Reports", "Challan");
        });
    </script>


</asp:Content>
