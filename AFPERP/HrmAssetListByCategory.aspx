<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmAssetListByCategory.aspx.cs" Inherits="BLL.HrmAssetListByCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
     <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Asset All Information
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlAssetCategory" runat="server" CssClass="control-label col-md-2 no-padding-right">Asset Type</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlAssetCategory" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlDepartment" runat="server" CssClass="control-label col-md-2 no-padding-right">Department</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlDepartment" CssClass="form-control" runat="server" AutoPostBack="false"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-2">
                            <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-info" runat="server" OnClick="btnPrint_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSHR" runat="server">
    
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Reports");
        });
    </script>
</asp:Content>
