<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="MktMRSheetUpdate.aspx.cs" Inherits="BLL.MktMRSheetUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">


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


                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtMRId" CssClass="col-md-4 control-label" Text="Held Up" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:CheckBox CssClass="form-control" ID="chkHeldUp" runat="server" Enabled="false" />
                        </div>
                    </div>

                    
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtMRId" CssClass="col-md-4 control-label" Text="Before Send" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:CheckBox CssClass="form-control" ID="chkIsAlSend" runat="server" Enabled="false" />
                        </div>
                    </div>


                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlLibraryName" runat="server" CssClass="col-md-4 control-label no-padding-right" Text="Library Name" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlLibraryName" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlLibrary_OnSelectedChanged" AutoPostBack="true" >
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlDepositFor" runat="server" CssClass="col-md-4 control-label" Text="Deposit For" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlDepositFor" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>



                    <div class="form-group">
                        <div class="input-group col-md-8 col-md-offset-4">
                            <asp:CheckBox CssClass="" ID="chkQawmi" runat="server" />
                            <asp:Label AssociatedControlID="chkQawmi" CssClass="control-label" runat="server" Text="Qawmi"></asp:Label>
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
                                    <asp:Label runat="server" AssociatedControlID="ddlReceivedParty" CssClass="control-label" Text="Received From" ID="lblCashParty"  Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtRemarkInv" CssClass="control-label" Text="Remark"></asp:Label>
                                </td>

                            </tr>
                            <tr>
                                <td style="width: 125px">
                                    <asp:TextBox runat="server" ID="dtpDepositDate" CssClass="form-control" placeholder="yyyy-MM-dd" Enabled="false" />
                                    <ajaxToolkit:CalendarExtender runat="server" TargetControlID="dtpDepositDate" Format="yyyy-MM-dd" />
                                </td>

                                <td style="width: 125px">
                                    <asp:DropDownList runat="server" ID="ddlDepositType" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                </td>

                                <td style="width: 125px">
                                    <asp:TextBox runat="server" ID="txtDDTTRDNo" CssClass="form-control" Enabled="false" />
                                </td>

                                <td style="width: 125px">
                                    <asp:DropDownList runat="server" ID="ddlBank" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox runat="server" ID="txtBankBranch" CssClass="form-control" Enabled="false" />
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox runat="server" ID="txtAmount" CssClass="form-control" Enabled="false" />
                                </td>

                                <td style="width: 100px">
                                    <asp:TextBox runat="server" ID="txtAccNo" CssClass="form-control" Enabled="false" />
                                </td>
                                <td style="width: 250px">
                                    <asp:DropDownList runat="server" ID="ddlReceivedParty" CssClass="form-control" Visible="false" OnSelectedIndexChanged="ddlCashParty_OnSelectedChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td style="width: 200px">
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

                                    <asp:TemplateField HeaderText="HeldUp" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lblHeldUp" runat="server" CommandArgument='<%#Eval("MRDetId") %>' BackColor="Red" ForeColor="Black" OnClick="lblHeldUp_Click">
                                                 HeldUp
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
                                    <asp:Label AssociatedControlID="txtCauseOfHeldUp" Text="Cause Of Held Up" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox CssClass="form-control" ID="txtCauseOfHeldUp" runat="server" placeholder="In Case Of Held Up" />
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
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Collection", "Datewise MRSheet");
        });
    </script>
</asp:Content>
