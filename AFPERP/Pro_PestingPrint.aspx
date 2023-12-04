<%@ Page Title="" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_PestingPrint.aspx.cs" Inherits="BLL.Pro_PestingPrint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA" runat="server">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    View Pasting Info By Entry No
                </div>
                <div class="panel-body">
                    <div class="col-md-7">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtEntryId" CssClass="col-md-4 control-label no-padding-right" Text="Entry No" runat="server"></asp:Label>
                            <div class="col-md-5">
                                <asp:TextBox runat="server" ID="txtEntryId" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-8 col-md-offset-4">
                                <asp:Button ID="btnLoad" Text="Show" CssClass="btn btn-info" runat="server" OnClick="btnLoad_OnClick" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSPro" runat="server">
         <script>
             $(document).ready(function () {
                 open_menu("Pasting", "Pasting Report by EntryNo");
             });
    </script>
</asp:Content>
