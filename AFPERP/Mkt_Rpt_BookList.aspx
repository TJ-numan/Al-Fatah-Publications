<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Rpt_BookList.aspx.cs" Inherits="BLL.Mkt_Rpt_BookList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    View Book List Report
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlBookName" runat="server" CssClass="col-md-4 control-label no-padding-right" Text="Book Name" />
                        <div class="dropdown col-md-4">
                            <asp:DropDownList ID="ddlBookName" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlClass" runat="server" CssClass="col-md-4 control-label no-padding-right no-padding-right" Text="Class" />
                        <div class="dropdown col-md-4">
                            <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlBookType" runat="server" CssClass="col-md-4 control-label no-padding-right" Text="Book Type" />
                        <div class="dropdown col-md-4">
                            <asp:DropDownList ID="ddlBookType" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlCategory" runat="server" CssClass="col-md-4 control-label no-padding-right" Text="Group" />
                        <div class="dropdown col-md-4">
                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
<%--                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlEdition" runat="server" CssClass="col-md-4 control-label no-padding-right" Text="Edition" />
                        <div class="dropdown col-md-4">
                            <asp:DropDownList ID="ddlEdition" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>--%>
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
            open_menu("Reports", "Book");
        });
    </script>
</asp:Content>
