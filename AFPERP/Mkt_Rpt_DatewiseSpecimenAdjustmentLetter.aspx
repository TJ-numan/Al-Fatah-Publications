<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Rpt_DatewiseSpecimenAdjustmentLetter.aspx.cs" Inherits="BLL.Mkt_Rpt_DatewiseSpecimenAdjustmentLetter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">

        <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                 Datewise  Specimen Adjustment Letter
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-4 control-label" Text="From Date" runat="server"></asp:Label>
                        <div class="input-group col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-4 control-label" Text="To Date" runat="server"></asp:Label>
                        <div class="input-group col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>

 
 
                    <div class="form-group">
                        <div class="input-group col-md-8 col-md-offset-4">                       
                            <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-default" runat="server" OnClick="btnPrint_Click" />
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
                open_menu("Specimen", "Datewise Adjustment Letter");
            });
    </script>


</asp:Content>
