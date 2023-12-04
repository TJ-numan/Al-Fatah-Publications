<%@ Page Title="" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_RptPlatePurchase.aspx.cs" Inherits="BLL.Pro_RptPlatePurchase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
  <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    View Plate Purchase Report
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-3 control-label no-padding-right" Text="From" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-3 control-label no-padding-right" Text="To" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="ddlSupplier" CssClass="col-md-3 control-label no-padding-right" Text="Supplier"></asp:Label>
                        <div class="col-md-5">
                             <asp:DropDownList ID="ddlSupplier" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="input-group col-md-8 col-md-offset-3">
                            <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info" runat="server" OnClick="btnShow_Click" />
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
            open_menu("Reports", "Plate");
        });
    </script>
</asp:Content>
