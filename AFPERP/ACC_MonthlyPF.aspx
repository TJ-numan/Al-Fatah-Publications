<%@ Page Title="" Language="C#" MasterPageFile="~/AccountingMaster.master" AutoEventWireup="true" CodeBehind="ACC_MonthlyPF.aspx.cs" Inherits="BLL.ACC_MonthlyPF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AccountingContent" runat="server">
      <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Monthly Provident Fund Report
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
                                <asp:ListItem Text ="Payroll" Value ="16"></asp:ListItem>
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
</asp:Content>
