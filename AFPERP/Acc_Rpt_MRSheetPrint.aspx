<%@ Page Title="" Language="C#" MasterPageFile="~/AccountingMaster.master" AutoEventWireup="true" CodeBehind="Acc_Rpt_MRSheetPrint.aspx.cs" Inherits="BLL.Acc_Rpt_MRSheetPrint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountingContent" runat="server">

    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Print MR Sheet
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtSheetNo" CssClass="col-md-4 control-label no-padding-right" Text="Sheet No"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtSheetNo" runat="server" CssClass="form-control" OnTextChanged="btnShow_Click" AutoPostBack="true" />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="input-group col-md-8 col-md-offset-4">
                            <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-success" runat="server" OnClick="btnPrint_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-primary" runat="server" OnClick="btnShow_Click"/>
                        </div>
                    </div>
                </div>
                                    <div class="panel-body">
                        <div class="table-responsive table-bordered clearfix ">
                            <asp:GridView ID="gvMRSheetDetailsPrint" CssClass="table " runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvMRSheetDetailsPrint_SelectedIndexChanged"  OnRowDataBound="gvMRSheetDetailsPrint_RowDataBound">
                                <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                <Columns> 

                                    <asp:BoundField DataField="MRNo" HeaderText="MR"  /> 
                                    <asp:BoundField DataField="LibraryID" HeaderText="LibraryID" />
                                    <asp:BoundField DataField="LibraryName" HeaderText="LibraryName" />
                                    <asp:BoundField DataField="ShortAddress" HeaderText="ShortAddress" />
                                    <asp:BoundField DataField="DepForName" HeaderText="Offer" />
                                    <asp:BoundField DataField="Com" HeaderText="Com" />
                                    <asp:BoundField DataField="CollectionDate" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd}" />
                                    <asp:BoundField DataField="TranbType" HeaderText="Type" />
                                    <asp:BoundField DataField="BankSlipNo" HeaderText="DD/TT/RD" />
                                    <asp:BoundField DataField="BankCode" HeaderText="BankCode" />
                                       <asp:BoundField DataField="BankAddress" HeaderText="BankAddress" />
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" ItemStyle-HorizontalAlign="Right"  DataFormatString="{0:N0}"/>
                                    <asp:BoundField DataField="AccountNo" HeaderText="A/C No" />
                                    <asp:BoundField DataField="Remark" HeaderText="Remarks" />
                                    <asp:CommandField SelectText="Print" ShowSelectButton="true" ItemStyle-CssClass="btn btn-compose"
                                        HeaderStyle-CssClass="HiddenColumn" /> 

                                </Columns>
                                <SelectedRowStyle BackColor="#F4B6B6" Font-Bold="true" ForeColor="#110101" />
                            </asp:GridView>
                        </div>
                        <br />
                    </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSAcc" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Reports", "Deposit");
        });
    </script>
</asp:Content>
