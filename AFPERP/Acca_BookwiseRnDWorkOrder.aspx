<%@ Page Title="" Language="C#" MasterPageFile="~/AccountingMaster.master" AutoEventWireup="true" CodeBehind="Acca_BookwiseRnDWorkOrder.aspx.cs" Inherits="BLL.Acca_BookwiseRnDWorkOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AccountingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Book Wise Work Order Report
                        </div>
                        <div class="panel-body">                  
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlClass" CssClass="col-md-4 control-label no-padding-right" Text="Class" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlClass" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlBookName" CssClass="col-md-4 control-label no-padding-right" Text="Book Name" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlBookName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBookName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlEdition" CssClass="col-md-4 control-label no-padding-right" Text="Edition" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlEdition" runat="server"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label AssociatedControlID="btnPrint" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                <div class="col-md-3">
                                    <asp:Button ID="btnPrint" Text="Show" CssClass="btn btn-info" runat="server" OnClick="btnPrint_OnClick" />
                                </div>
                            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSAcc" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Reports", "RnD Work");
        });
    </script>
</asp:Content>