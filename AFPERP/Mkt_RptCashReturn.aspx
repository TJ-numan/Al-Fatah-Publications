<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_RptCashReturn.aspx.cs" Inherits="BLL.Mkt_RptCashReturn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA" runat="server">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <h4>View Cash Return By Memo</h4>
                </div>
                <div class="panel-body">
                    <div class="col-md-7">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtReturnMemo" CssClass="col-md-4 control-label no-padding-right" Text="Memo No" runat="server"></asp:Label>
                            <div class="col-md-5">
                                <asp:TextBox CssClass="form-control" ID="txtReturnMemo" OnTextChanged="btnLoad_Click" AutoPostBack="true" placeholder="Memo No" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-8 col-md-offset-4">
                                <asp:Button ID="btnLoad" Text="Show" CssClass="btn btn-info" runat="server" OnClick="btnLoad_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
    <script>
        $(document).ready(function () {
            open_menu("Reports","Return");
        });
    </script>
</asp:Content>
