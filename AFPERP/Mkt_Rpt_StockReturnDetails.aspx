<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Rpt_StockReturnDetails.aspx.cs" Inherits="BLL.Mkt_Rpt_StockReturnDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    View Stock Details Report
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="dtpFromDate" CssClass="col-md-4 control-label no-padding-right" Text="From Date"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="dtpFromDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                            <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="dtpFromDate" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="dtpToDate" CssClass="col-md-4 control-label no-padding-right" Text="To Date"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="dtpToDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                            <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="dtpToDate" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlCategory" CssClass="col-md-4 control-label" Text="Category" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                <asp:ListItem Value="">--Select--</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlGroup" CssClass="col-md-4 control-label" Text="Group" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlGroup" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlClass" CssClass="col-md-4 control-label" Text="Class" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlClass" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlType" CssClass="col-md-4 control-label" Text="Type" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlBookName" CssClass="col-md-4 control-label" Text="Book Name" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlBookName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBookName_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlEdition" CssClass="col-md-4 control-label" Text="Edition" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlEdition" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>

 
                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">
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
            open_menu("Reports", "Stock");
        });
    </script>
</asp:Content>
