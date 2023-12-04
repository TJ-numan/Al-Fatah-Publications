<%@ Page Title="" Language="C#" MasterPageFile="~/AccountingMaster.master" AutoEventWireup="true" CodeBehind="Account_RnDWorkOrderPrintQawmi.aspx.cs" Inherits="BLL.Account_RnDWorkOrderPrintQawmi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AccountingContent" runat="server">
<div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Work order Print Qawmi
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtWorkID" ID="lbltxtWorkID" CssClass="col-md-4 control-label no-padding-right" Text="Order No" runat="server"></asp:Label>
                                <div class="col-md-6">  
                                    <asp:TextBox CssClass="form-control" ID="txtWorkID" runat="server" ReadOnly="false"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="btnPrint" ID="lblbtnPrint" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">  
                                        <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-info" runat="server" OnClick="btnPrint_OnClick" />
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