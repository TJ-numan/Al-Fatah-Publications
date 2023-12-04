<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Rpt_DatewiseSpecimanChallan.aspx.cs" Inherits="BLL.Mkt_Rpt_DatewiseSpecimanChallan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
     <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    View Datewise Speciman Chalan Report
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-4 control-label" Text="From" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-4 control-label" Text="To" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="input-group col-md-8 col-md-offset-4">
                            <asp:CheckBox CssClass="" ID="chkDonation" runat="server" />
                            <asp:Label AssociatedControlID="chkDonation" CssClass="control-label" runat="server" Text="Donation"></asp:Label>
                        </div>
                    </div>



                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">
                            <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info" runat="server" OnClick="btnShow_Click"/> &nbsp; &nbsp;
                            <asp:Button ID="btnConverXML" Text="Convert" CssClass="btn btn-group-lg" runat="server" OnClick="btnConverXML_Click"/>&nbsp; &nbsp;
                           <asp:Button ID="DownloadXML" Text="Download XML" CssClass="btn btn-success" runat="server" OnClick="DownloadXML_Click" />
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
                open_menu("Reports", "Specimen");
            });
    </script>
</asp:Content>
