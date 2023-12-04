<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="Rnd_Rpt_ScriptPlan.aspx.cs" Inherits="BLL.Rnd_Rpt_ScriptPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    View Script Plan Report
                </div>
                <div class="panel-body">
                    <div class="jumbroton">
                        <div class="col-md-7">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlCategory" CssClass="col-md-4 control-label" Text="Category" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlCategory" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlGroup" CssClass="col-md-4 control-label" Text="Group" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlGroup" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlClass" CssClass="col-md-4 control-label" Text="Class" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlClass" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlType" CssClass="col-md-4 control-label" Text="Type" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlType" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlBookName" CssClass="col-md-4 control-label" Text="Book Name" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlBookName" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtEdition" CssClass="col-md-4 control-label" Text="Edition" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control" ID="txtEdition" placeholder="Edition" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-7">
                        <div class="form-group">
                            <div class="col-md-8 col-md-offset-4">
                                <asp:Button ID="btnLoad" Text="Show" CssClass="btn btn-info" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSRandD" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Reports");
        });
    </script>
</asp:Content>
