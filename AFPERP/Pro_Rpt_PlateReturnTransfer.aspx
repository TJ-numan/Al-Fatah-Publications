<%@ Page Title="" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_Rpt_PlateReturnTransfer.aspx.cs" Inherits="BLL.Pro_Rpt_PlateReturnTransfer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
         <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                   Plate Return Transfer
                </div>
                <%-- <div id="frmPlateProcess" runat="server" class="form-horizontal clearfix">--%>
                <div class="panel-body">
                    <div class="col-md-12 no-padding clearfix">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtPlateReturnID" CssClass="col-xs-4 control-label no-padding-right" Text="Plate Return ID"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtPlateReturnID" runat="server" CssClass="form-control"/>
                                </div>
                            </div>
                                                        <div class="form-group">
                                <div class="col-xs-8 col-xs-offset-4">
                                    <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info" runat="server" OnClick="btnShow_Click"/>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSPro" runat="server">
        <script type="text/javascript">
            $(document).ready(function () {
                open_menu("Reports","Plate");
            });
    </script>
</asp:Content>
