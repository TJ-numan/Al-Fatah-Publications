<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Rpt_RoutePlan.aspx.cs" Inherits="BLL.Mkt_Rpt_RoutePlan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
       <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Route Plan Reports
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlUnitName" CssClass="col-md-4 control-label no-padding-right" Text="Unit Name"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlUnitName" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlUnitName_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlDemarcationStep" CssClass="col-md-4 control-label no-padding-right" Text="Demarcation Step"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlDemarcationStep" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlDemarcationStep_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlDemarcationName" CssClass="col-md-4 control-label no-padding-right" Text="Demarcation Name"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlDemarcationName" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                <div class="form-group">
                    <div class="col-md-5 col-md-offset-3">
                        <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-success btn pull-right" runat="server" OnClick ="btnPrint_Click"/>
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
                open_menu("Route Plan");
            });
    </script>
</asp:Content>
