<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Rpt_PaymentReport.aspx.cs" Inherits="BLL.Mkt_Rpt_PaymentReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <h3>Payment Report View Page</h3>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
     <script type="text/javascript">
         $(document).ready(function () {
             open_menu("Reports","Deposit");
         });
    </script>
</asp:Content>
