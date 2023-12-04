<%@ Page Title="Madrasha Info" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Rpt_MadrashaInfoById.aspx.cs" Inherits="BLL.Mkt_Rpt_MadrashaInfoById" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Madrasha Info
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlRegion" runat="server" CssClass="col-md-4 control-label" Text="Region" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlDivision" runat="server" CssClass="col-md-4 control-label" Text="Division" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlDivision" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlZone" runat="server" CssClass="col-md-4 control-label" Text="Zone" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlZone" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlTeritory" runat="server" CssClass="col-md-4 control-label" Text="Teritory" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlTeritory" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlTeritory_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlMadrasha" runat="server" CssClass="col-md-4 control-label" Text="Madrasha" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlMadrasha" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    
                    <div class="form-group">
                        <div class="input-group col-md-8 col-md-offset-4">
                            <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info" runat="server" OnClick="btnShow_Click"  />
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
            open_menu("Reports", "Others");
        });
    </script>
</asp:Content>
