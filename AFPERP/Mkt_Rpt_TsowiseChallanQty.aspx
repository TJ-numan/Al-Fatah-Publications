<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Rpt_TsowiseChallanQty.aspx.cs" Inherits="BLL.Mkt_Rpt_TsowiseChallanQty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    View Tsowise Challan Quantity Report
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-4 control-label" Text="From Date" runat="server"></asp:Label>
                        <div class="input-group col-md-5">
                            <asp:TextBox CssClass="form-control" ID="dtpFromDate" placeholder="yyyy-MM-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-4 control-label" Text="To Date" runat="server"></asp:Label>
                        <div class="input-group col-md-5">
                            <asp:TextBox CssClass="form-control" ID="dtpToDate" placeholder="yyyy-MM-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlTeritory" runat="server" CssClass="col-md-4 control-label" Text="Teritory" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlTeritory" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlTeritory_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlTso" runat="server" CssClass="col-md-4 control-label" Text="TSO" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlTso" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlBookName" runat="server" CssClass="col-md-4 control-label" Text="Book Name" Visible="false"/>
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlBookName" runat="server" CssClass="form-control" Visible="false"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlEdition" runat="server" CssClass="col-md-4 control-label" Text="Edition" Visible="false" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlEdition" runat="server" CssClass="form-control" Visible="false"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="input-group col-md-8 col-md-offset-4">
                            <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info" runat="server"  OnClick="btnShow_Click" />
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
            open_menu("Reports", "Specimen");
        });
    </script>
</asp:Content>
