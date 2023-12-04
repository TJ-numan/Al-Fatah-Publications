<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Rpt_AgreementDetailsReport.aspx.cs" Inherits="BLL.Mkt_Rpt_AgreementDetailsReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Agreement Details Report
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlAgreementYear" Text="Session" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList CssClass="form-control" ID="ddlAgreementYear" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtAgrNo" CssClass="col-md-4 control-label no-padding-right" Text="SL No"></asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtAgrNo" runat="server" CssClass="form-control" OnTextChanged="btnShow_Click" AutoPostBack="true" />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="input-group col-md-8 col-md-offset-4">
                            <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info" runat="server" OnClick="btnShow_Click" />
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
            open_menu("Reports", "Madrasah");
        });
    </script>
</asp:Content>
