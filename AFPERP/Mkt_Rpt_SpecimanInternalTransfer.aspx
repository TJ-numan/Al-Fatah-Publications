<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Rpt_SpecimanInternalTransfer.aspx.cs" Inherits="BLL.Mkt_Rpt_SpecimanInternalTransfer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
       <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA" runat="server">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Specimen  Internal Transfer Memo
                </div>
                <div class="panel-body">
                    <div class="col-md-7">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtMemono" CssClass="col-md-4 control-label no-padding-right" Text="Slip No" runat="server"></asp:Label>
                            <div class="col-md-5">
                                <asp:TextBox runat="server" ID="txtMemono" CssClass="form-control"></asp:TextBox>
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
<asp:Content ID="Content3" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
        <script type="text/javascript">
            $(document).ready(function () {
                open_menu("Reports", "Specimen");
            });
    </script>
</asp:Content>