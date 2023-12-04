<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Rpt_ChalanMemoQawmi.aspx.cs" Inherits="BLL.Mkt_Rpt_ChalanMemoQawmi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
     <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA" runat="server">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    View Qawmi Chalan By Memo No
                </div>
                <div class="panel-body">
                    <div class="col-md-7">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtChalanId" CssClass="col-md-4 control-label no-padding-right" Text="Cash Memo" runat="server"></asp:Label>
                            <div class="col-md-5">
                                <asp:TextBox runat="server" ID="txtChalanId" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-8 col-md-offset-4">
                                <asp:Button ID="btnLoad" Text="Show" CssClass="btn btn-info" runat="server" OnClick="btnLoad_OnClick" />
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
                 open_menu("Reports", "Chalan");
             });
    </script>
</asp:Content>
