<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmPFProjectTran.aspx.cs" Inherits="BLL.HrmPFProjectTran" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
        <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Provident Fund Project Transaction
                </div>
                <div class="panel-body">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlProject" runat="server" CssClass="control-label col-md-2 no-padding-right">Project</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlProject" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="dtpTransDate" CssClass="control-label col-md-2 no-padding-right">Transaction Date</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox CssClass="form-control" ID="dtpTransDate" placeholder="dd-MM-yyyy" runat="server" />
                                <ajaxToolkit:CalendarExtender TargetControlID="dtpTransDate" Format="dd-MM-yyyy" runat="server" />
                            </div>
                        </div>
                    
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtInvestAmt" runat="server" CssClass="control-label col-md-2 no-padding-right">Investment Amt</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtInvestAmt" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtReturnAmt" runat="server" CssClass="control-label col-md-2 no-padding-right">Return Amt</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtReturnAmt" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtProfitAmt" runat="server" CssClass="control-label col-md-2 no-padding-right">Profit Amt</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtProfitAmt" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtBankName" runat="server" CssClass="control-label col-md-2 no-padding-right">Bank Name</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtBankName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtBankAddress" runat="server" CssClass="control-label col-md-2 no-padding-right">Bank Address</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtBankAddress" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtBankAcNo" runat="server" CssClass="control-label col-md-2 no-padding-right">Bank Acount No</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtBankAcNo" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-4 col-md-offset-2">
                                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" />
                                <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" />
                            </div>
                        </div>
                   

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSHR" runat="server">
    <script type="text/javascript">
            $(document).ready(function () {
                open_menu("Payroll Management");
            });
    </script>
</asp:Content>
