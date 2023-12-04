<%@ Page Title="" Language="C#" MasterPageFile="~/AccountingMaster.master" AutoEventWireup="true" CodeBehind="DoMoneyReceipt.aspx.cs" Inherits="BLL.DoMoneyReceipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountingContent" runat="server">


    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    MR From Sheet
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtMRId" CssClass="col-md-4 control-label" Text="MR ID" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox CssClass="form-control" ID="txtMRId" runat="server" Enabled="true"   />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="chkHeldUp" CssClass="col-md-4 control-label" Text="Held Up" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:CheckBox CssClass="form-control" ID="chkHeldUp" runat="server" Enabled="true" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtMRDate" CssClass="col-md-4 control-label" Text="MR Date" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox CssClass="form-control" ID="txtMRDate" runat="server" Enabled="false" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="ddlDepositFor" CssClass="col-md-4 control-label   " Text=" Select Deposit For"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlDepositFor" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="input-group col-md-8 col-md-offset-4">
                            <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-primary" runat="server" OnClick="txtMRId_TextChanged" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlVoucherType" CssClass="col-md-4 control-label" Text="Voucher Type" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control date" ID="ddlVoucherType" runat="server">
                                <asp:ListItem Text="MR-AF/RD"  Value="MRT1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="RCV Offer" Value="MRT2"></asp:ListItem>
                                <asp:ListItem Text="Special Cash Back Offer" Value="MRT3"></asp:ListItem>
                               
                            </asp:DropDownList>

                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">
                            <asp:Button ID="btnDownloadXML" Text="Convert XML" CssClass="btn btn-info" runat="server" OnClick="btnDownloadXML_Click" />
                            <asp:Button ID="DownloadXML" Text="Download XML" CssClass="btn btn-info" runat="server" OnClick="DownloadXML_Click" />
                        </div>
                    </div>

                    <div class="panel-body">
                        <div class="table-responsive table-bordered clearfix ">
                            <asp:GridView ID="gvMRSheetDetailsUpdate" CssClass="table " runat="server" AutoGenerateColumns="false">
                                <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                <Columns>

                                    <asp:BoundField DataField="MRDetId" HeaderText="MRDetId" />
                                    <asp:BoundField DataField="LibraryID" HeaderText="LibraryID" />
                                    <asp:BoundField DataField="LibraryName" HeaderText="LibraryName" />
                                    <asp:BoundField DataField="ShortAddress" HeaderText="ShortAddress" />
                                    <asp:BoundField DataField="DepForName" HeaderText="DepForName" />
                                    <asp:BoundField DataField="Com" HeaderText="Com" />
                                    <asp:BoundField DataField="CollectionDate" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd}" />
                                    <asp:BoundField DataField="TranbType" HeaderText="Type" />
                                    <asp:BoundField DataField="BankSlipNo" HeaderText="DD/TT/RD" />
                                    <asp:BoundField DataField="BankCode" HeaderText="BankCode" />
                                    <asp:BoundField DataField="BankAddress" HeaderText="BankAddress" />
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                    <asp:BoundField DataField="AccountNo" HeaderText="A/C No" />
                                    <asp:BoundField DataField="Remark" HeaderText="Remarks" />

                                </Columns>
                                <SelectedRowStyle BackColor="#F4B6B6" Font-Bold="true" ForeColor="#110101" />
                            </asp:GridView>
                        </div>
                        <br />
                    </div>



                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="col-md-6">
                            </div>
                            <div class="col-md-6">

                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtTotalAmount" Text="Total Amount" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox CssClass="form-control" ID="txtTotalAmount" runat="server" ReadOnly="True" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtRemarks" Text="Narration" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox CssClass="form-control" ID="txtRemarks" runat="server" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-6 col-md-offset-4">
                                        <asp:Button ID="btnSave" Text="Save As MR" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                                        &nbsp;&nbsp;&nbsp; 

                                        <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-group" runat="server" />
                                    </div>
                                </div>



                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSAcc" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Collection", "Deposit");
        });
    </script>
</asp:Content>
