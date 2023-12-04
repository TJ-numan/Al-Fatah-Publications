<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Store_Rpt_CentralStockInventory.aspx.cs" Inherits="BLL.Store_Rpt_CentralStockInventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Central Stock Inventory
                </div>
                <%--<div id="frmReturnFromBinder" runat="server" class="form-horizontal clearfix">--%>
                <div class="panel-body">
                    <div class="col-md-12 no-padding clearfix">
                        <div class="col-md-6 clearfix">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="dtpFromDate" CssClass="col-xs-4 control-label no-padding-right" Text="From Date"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="dtpFromDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="dtpFromDate" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="dtpToDate" CssClass="col-xs-4 control-label no-padding-right" Text="To Date"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="dtpToDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="dtpToDate" OnClientDateSelectionChanged="validateDateSelection" />

                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlCategory" CssClass="col-xs-4 control-label no-padding-right" Text="Category"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlGroup" CssClass="col-xs-4 control-label no-padding-right" Text="Group"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlClass" CssClass="col-xs-4 control-label no-padding-right" Text="Class"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlType" CssClass="col-xs-4 control-label no-padding-right" Text="Type"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlBookName" CssClass="col-sm-4 control-label no-padding-right" Text="Book Name"></asp:Label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="ddlBookName" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlBookName_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlEdition" CssClass="col-xs-4 control-label no-padding-right" Text="Edition"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlEdition" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlViewers" runat="server" CssClass="col-md-4 control-label" Text="View Option" />
                                <div class="dropdown col-md-8">
                                    <asp:DropDownList ID="ddlViewers" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0"> Select any type</asp:ListItem>
                                        <asp:ListItem Value="1"> View as Pdf File</asp:ListItem>
                                        <asp:ListItem Value="2"> View as Excel File</asp:ListItem>
                                        <asp:ListItem Value="3"> View as Word File</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-xs-8 col-xs-offset-4">
                                    <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info" runat="server" OnClick="btnShow_Click" />
                                     <asp:Button ID="Button1" Text="OurReport" CssClass="btn btn-info" runat="server" OnClick="OurReportShow"  />
                                </div>
                            </div>
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
            open_menu("Reports", "Stock");
        });
    </script>

    <script type="text/javascript">
        function validateDateSelection() {
           
        var toDateCalendar = document.getElementById('<%= dtpToDate.ClientID %>');
        var fromDateTextbox = document.getElementById('<%= dtpFromDate.ClientID %>');
       
        var selectedToDate = new Date(toDateCalendar.get_selectedDate());
        var fromDate = new Date(fromDateTextbox.value);

        if (selectedToDate < fromDate) {
            alert("Selected date must be equal to or later than the From Date.");
            toDateCalendar.set_selectedDate(fromDate);
        }
    }
</script>



</asp:Content>
