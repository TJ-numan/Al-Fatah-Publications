<%@ Page Title="" Language="C#" MasterPageFile="~/AccountingMaster.master" AutoEventWireup="true" CodeBehind="Acc_MRSheetUpdate.aspx.cs" Inherits="BLL.Acc_MRSheetUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Update MR Sheet 
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtMRId" CssClass="col-md-4 control-label" Text="MR ID" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox CssClass="form-control" ID="txtMRId" runat="server" Enabled="false" />
                        </div>
                    </div>

                    <div class="clearfix table-responsive">
                        <table class=" table-responsive table no-head-padding ">
                            <tr>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="dtpDepositDate" CssClass="control-label" Text="DepositDate"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="ddlDepositType" CssClass="control-label" Text="Deposit Type"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtDDTTRDNo" CssClass="control-label" Text="RD/TT/DD "></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="ddlBank" CssClass="control-label" Text="Bank Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtBankBranch" CssClass="control-label" Text="Branch"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtAmount" CssClass="control-label" Text="Amount"></asp:Label>
                                </td>

                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtAccNo" CssClass="control-label" Text="Acc No"></asp:Label>
                                </td>

                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtRemarkInv" CssClass="control-label" Text="Remark"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 125px">
                                    <asp:TextBox runat="server" ID="dtpDepositDate" CssClass="form-control" placeholder="yyyy-MM-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" TargetControlID="dtpDepositDate" Format="yyyy-MM-dd" />
                                </td>

                                <td style="width: 125px">
                                    <asp:DropDownList runat="server" ID="ddlDepositType" CssClass="form-control"></asp:DropDownList>
                                </td>

                                <td style="width: 125px">
                                    <asp:TextBox runat="server" ID="txtDDTTRDNo" CssClass="form-control" />
                                </td>

                                <td style="width: 125px">
                                    <asp:DropDownList runat="server" ID="ddlBank" CssClass="form-control"></asp:DropDownList>
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox runat="server" ID="txtBankBranch" CssClass="form-control" />
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox runat="server" ID="txtAmount" CssClass="form-control" />
                                </td>

                                <td style="width: 100px">
                                    <asp:TextBox runat="server" ID="txtAccNo" CssClass="form-control" />
                                </td>

                                <td style="width: 100px">
                                    <asp:TextBox runat="server" ID="txtRemarkInv" CssClass="form-control" />
                                </td>
                                <td style="width: 1px">
                                    <asp:TextBox runat="server" ID="txtMRDetId" CssClass="form-control" Visible="false" Width="1" />
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-primary" Text="Update" OnClick="btnUpdate_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>





                    <div class="panel-body">
                        <div class="table-responsive table-bordered clearfix ">
                            <asp:GridView ID="gvMRSheetDetailsUpdate" CssClass="table " runat="server" AutoGenerateColumns="false" OnRowDataBound="gvMRSheetDetailsUpdate_RowDataBound" OnSelectedIndexChanged="gvMRSheetDetailsUpdate_SelectedIndexChanged">
                                <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                <Columns>
                                    <asp:CommandField SelectText="Edit" ShowSelectButton="true" Visible="true"
                                        HeaderStyle-CssClass="HiddenColumn" />
                                    <asp:BoundField DataField="MRDetId" HeaderText="MRDetId" />
                                    <asp:BoundField DataField="CollectionDate" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd}" />
                                    <asp:BoundField DataField="TranbType" HeaderText="Type" />
                                    <asp:BoundField DataField="BankSlipNo" HeaderText="DD/TT/RD" />
                                    <asp:BoundField DataField="BankCode" HeaderText="BankCode" />
                                    <asp:BoundField DataField="BankAddress" HeaderText="BankAddress" />
                                    <asp:BoundField DataField="Amount" HeaderText="Amount"  ItemStyle-HorizontalAlign="Right"  DataFormatString="{0:N0}"/>
                                    <asp:BoundField DataField="AccountNo" HeaderText="A/C No" />
                                    <asp:BoundField DataField="Remark" HeaderText="Remarks" />

                                    <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lblDelete" runat="server" CommandArgument='<%#Eval("MRDetId") %>' BackColor="Red" ForeColor="Black" OnClick="lblDelete_Click">
                                                 Delete
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

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
                                    <asp:Label AssociatedControlID="txtCauseOfDel" Text="Cause Of Delete" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox CssClass="form-control" ID="txtCauseOfDel" runat="server" placeholder="In Case Of delete data write valid cause" />
                                    </div>
                                </div>



                                <div class="form-group">
                                    <asp:Label AssociatedControlID="dtpMrDate" Text="MR Date" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" ID="dtpMrDate" CssClass="form-control" placeholder="yyyy-MM-dd" />
                                        <ajaxToolkit:CalendarExtender runat="server" TargetControlID="dtpMrDate" Format="yyyy-MM-dd" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-6 col-md-offset-4">
                                        <asp:Button ID="btnUpdateSend" Text="Update & Send" CssClass="btn btn-success" runat="server" OnClick="btnUpdateSend_Click" />
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-group" runat="server" OnClick="btnPrint_Click" />
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
