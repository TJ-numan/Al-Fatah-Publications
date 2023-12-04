<%@ Page Title="" Language="C#" MasterPageFile="~/AccountingMaster.master" AutoEventWireup="true" CodeBehind="Acc_CBOCMrPrint.aspx.cs" Inherits="BLL.Acc_CBOCMrPrint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AccountingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Cashback Offer MR Print
                        </div>
                        <div class="panel-body">

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlCom" CssClass="col-md-3 control-label no-padding-left" Text=" Select Company"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlCom" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0" Text="Alia"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Qawmi"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtMemoNo" Text="MR No" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox CssClass="form-control" ID="txtMemoNo" runat="server" />
                                </div>
                            </div>                        
                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-3">
                                    <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-danger" runat="server" OnClick="btnPrint_Click" />
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
                open_menu("Reports", "Deposit");
            });
    </script>
</asp:Content>
