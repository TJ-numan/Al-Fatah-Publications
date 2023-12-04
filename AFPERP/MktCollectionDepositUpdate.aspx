<%@ Page Title="" Language="C#" MasterPageFile="~/AccountingMaster.master" AutoEventWireup="true" CodeBehind="MktCollectionDepositUpdate.aspx.cs" Inherits="BLL.MktCollectionDepositUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-7">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Update Money Receipt
                        </div>
                        <div class="panel-body">

                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtMemoNo" ErrorMessage="Please enter MR No!" ForeColor="Red" ID="RVforMRno" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlCom" CssClass="col-md-3 control-label no-padding-left" Text=" Select Company"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlCom" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0" Text="Alia"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Qawmi"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtMemoNo" Text="Memo No" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox CssClass="form-control" ID="txtMemoNo" runat="server" OnTextChanged="txtMemoNo_OnSelectedTextChanged" AutoPostBack="True" />
                                </div>

                                <div class="col-md-3">
                                    <asp:Button runat="server" ID="btnEnter" Text="Enter" CssClass="btn btn-danger btnBookCodeEnter" OnClick="txtMemoNo_OnSelectedTextChanged"></asp:Button>
                                </div>
                            </div>
                            <hr />




                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlDepositFor" CssClass="col-md-3 control-label no-padding-left" Text=" Select Deposit For"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="ddlDepositFor" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlDepositFor_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlAssetList" ID="lblAssetList" CssClass="col-md-3 control-label no-padding-left" Text=" Select Asset"  ></asp:Label>
                                        <div class="col-md-6" >
                                            <asp:DropDownList ID="ddlAssetList" runat="server" CssClass="form-control"   >
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlLibraryName" CssClass="col-md-3 control-label no-padding-right" Text="Library Name"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="ddlLibraryName" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>


                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtMemoDate" CssClass="col-md-3 control-label no-padding-right" Text=" MR Date"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtMemoDate" runat="server" CssClass="form-control" placeholder="yyyy-MM-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtMemoDate" />
                                </div>
                            </div>


                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtDepositedDate" CssClass="col-md-3 control-label no-padding-right" Text="Deposited Date"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtDepositedDate" runat="server" CssClass="form-control" placeholder="yyyy-MM-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtDepositedDate" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlDepositeType" CssClass="col-md-3 control-label no-padding-right" Text=" Deposit Type"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlDepositeType" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtClearanceDate" CssClass="col-md-3 control-label no-padding-right" Text="Clearance Date"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtClearanceDate" runat="server" CssClass="form-control" placeholder="yyyy-MM-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtClearanceDate" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlBankName" Text="Bank Name" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlBankName" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtBankAddress" Text="Bank Address" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtBankAddress" runat="server" TextMode="MultiLine" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtDDNo" Text="DD/TT/RD No" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtDDNo" runat="server" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtAmount" Text="Amount" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtAmount" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtRemarks" Text="Remark" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtRemarks" runat="server" TextMode="MultiLine" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtVerifiedBy" Text="Verified By" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtVerifiedBy" runat="server" />
                                </div>
                            </div>



                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClientClick="if (!confirm('Do You Want to Update Data?')) return false;" OnClick="btnUpdate_OnClick" />

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
            open_menu("Collection","Deposit");
        });
    </script>
</asp:Content>
