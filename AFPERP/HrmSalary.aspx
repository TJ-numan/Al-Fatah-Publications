<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmSalary.aspx.cs" Inherits="BLL.HrmSalary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSHR" runat="server">
    <script type="text/javascript">
            $(document).ready(function () {
                open_menu("Payroll Management");
            });
    </script>
</asp:Content>
