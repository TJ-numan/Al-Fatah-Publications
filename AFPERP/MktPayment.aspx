<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="MktPayment.aspx.cs" Inherits="BLL.MktPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                           Credit Agent Payment Entry
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtDate" CssClass="col-md-3 control-label no-padding-right" Text=" Date"></asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" InitialValue="0" ControlToValidate="ddlLibraryName" ErrorMessage="Please Select Library Name!" ForeColor="Red" ID="RVLibraryName" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlLibraryName" CssClass="col-md-3 control-label no-padding-right" Text="Agent Name"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlLibraryName" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" InitialValue="0" ControlToValidate="ddlPaymentOn" ErrorMessage="Please Select Payment Mode!" ForeColor="Red" ID="RequiredFieldValidator4" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlPaymentOn" CssClass="col-md-3 control-label no-padding-right" Text=" Payment On"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlPaymentOn" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" InitialValue="0" ControlToValidate="ddlBankName" ErrorMessage="Please Select Bank Name!" ForeColor="Red" ID="RequiredFieldValidator6" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlBankName" Text="Bank Name" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlBankName" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtAccountNo" ErrorMessage="Please enter Account No!" ForeColor="Red" ID="RVforACCno" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtAccountNo" Text="A/C No" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox CssClass="form-control" ID="txtAccountNo" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddlDepositType" InitialValue="0" ErrorMessage="Please Select Deposit Type!" ForeColor="Red" ID="RequiredFieldValidator5" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlDepositType" Text="Payment Mode" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlDepositType" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtBranchDeposit" ErrorMessage="Please enter Bank branch name!" ForeColor="Red" ID="RequiredFieldValidator7" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtBranchDeposit" Text="Branch of Deposit" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox CssClass="form-control" ID="txtBranchDeposit" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtAmount" ErrorMessage="Please enter Amount!" ForeColor="Red" ID="RequiredFieldValidator1" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtAmount" Text="Amount" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox CssClass="form-control" ID="txtAmount" runat="server" />
                                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-3 col-md-offset-4">
                                    <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success pull-right" runat="server" OnClick="btnSave_Click" />
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
            open_menu("Collection");
        });
    </script>
</asp:Content>
