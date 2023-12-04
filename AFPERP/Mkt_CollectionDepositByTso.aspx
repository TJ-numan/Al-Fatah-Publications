<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_CollectionDepositByTso.aspx.cs" Inherits="BLL.Mkt_CollectionDepositByTso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div id="frmNewReturn" class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Collection Deposit By Tso
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtInvoice" CssClass="col-md-4 control-label no-padding-right" Text="Invoice"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtInvoice" runat="server" CssClass="form-control" ReadOnly="True" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtMRDate" CssClass="col-md-4 control-label no-padding-right" Text="MR Date" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox CssClass="form-control date" ID="txtMRDate" placeholder="dd-MM-yyyy" runat="server" />
                                    <ajaxToolkit:CalendarExtender TargetControlID="txtMRDate" Format="dd-MM-yyyy" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtMemoNo" CssClass="col-md-4 control-label no-padding-right" Text="Memo No"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtMemoNo" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddTsoName" CssClass="col-md-4 control-label no-padding-right" Text="Tso Name" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:DropDownList CssClass="form-control" ID="ddTsoName" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label CssClass="col-md-4 control-label no-padding-right" Text="Select Type:" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <label class="radio-inline">
                                        <asp:RadioButton runat="server" ID="radRegular" GroupName="Type" />Regular
                                    </label>
                                    <label class="radio-inline">
                                        <asp:RadioButton runat="server" ID="radBoishakhi" GroupName="Type" />Boishakhi
                                    </label>
                                    <label class="radio-inline">
                                        <asp:RadioButton runat="server" ID="radAlim" GroupName="Type" />Alim
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtDepositDate" CssClass="col-md-4 control-label no-padding-right" Text="Deposit Date" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox CssClass="form-control date" ID="txtDepositDate" placeholder="dd-MM-yyyy" runat="server" />
                                    <ajaxToolkit:CalendarExtender TargetControlID="txtDepositDate" Format="dd-MM-yyyy" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlDepositType" CssClass="col-md-4 control-label no-padding-right" Text="Deposit Type" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:DropDownList CssClass="form-control" ID="ddlDepositType" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtClearanceDate" CssClass="col-md-4 control-label no-padding-right" Text="Clearance Date" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox CssClass="form-control date" ID="txtClearanceDate" placeholder="dd-MM-yyyy" runat="server" />
                                    <ajaxToolkit:CalendarExtender TargetControlID="txtClearanceDate" Format="dd-MM-yyyy" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlBankName" CssClass="col-md-4 control-label no-padding-right" Text="Bank Name" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:DropDownList CssClass="form-control" ID="ddlBankName" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtBankAddress" CssClass="col-md-4 control-label no-padding-right" Text="Bank Address"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtBankAddress" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtDDNo" CssClass="col-md-4 control-label no-padding-right" Text="DD/TT/RD No"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtDDNo" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtDeliveredBy" CssClass="col-md-4 control-label no-padding-right" Text="Delivered By"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtDeliveredBy" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtAmount" CssClass="col-md-4 control-label no-padding-right" Text="Amount"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtVerifiedBy" CssClass="col-md-4 control-label no-padding-right" Text="Verified By"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtVerifiedBy" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtRemark" CssClass="col-md-4 control-label no-padding-right" Text="Remark"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtRemark" runat="server" CssClass="form-control" TextMode="MultiLine" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-4">
                                    <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_OnClick" />
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
</asp:Content>
