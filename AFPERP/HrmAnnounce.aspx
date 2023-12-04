<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmAnnounce.aspx.cs" Inherits="BLL.HrmAnnounce" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSHR" runat="server">
    <script type="text/javascript">
            $(document).ready(function () {
                open_menu("HR Administration");
            });
    </script>
</asp:Content>
