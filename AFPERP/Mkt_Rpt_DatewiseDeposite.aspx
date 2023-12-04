<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Rpt_DatewiseDeposite.aspx.cs" Inherits="BLL.Mkt_Rpt_DatewiseDeposite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    View Datewise Deposit Report
                </div>
                <div class="panel-body">
                    <div class=" row col-md-6">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-3 control-label" Text="From" runat="server"></asp:Label>
                            <div class="col-md-7">
                                <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-mm-dd" runat="server" />
                                <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-3 control-label" Text="To" runat="server"></asp:Label>
                            <div class="col-md-7">
                                <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-mm-dd" runat="server" />
                                <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-8 col-md-offset-3">
                                <asp:CheckBox ID="chkIsQawmi" CssClass="checkbox pull-left" runat="server" />
                                <asp:Label AssociatedControlID="chkIsQawmi" CssClass="control-label" runat="server" Text="Qawmi"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-8 col-md-offset-3">
                                <asp:CheckBox ID="chkIsBoishaki" CssClass="checkbox pull-left" runat="server" />
                                <asp:Label AssociatedControlID="chkIsBoishaki" CssClass="control-label" runat="server" Text="Boishaki"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-6 col-md-offset-3">
                                <asp:CheckBox ID="chkIsAlim" CssClass="checkbox pull-left" runat="server" />
                                <asp:Label AssociatedControlID="chkIsAlim" CssClass="control-label" runat="server" Text="Alim"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-6 col-md-offset-4">
                                <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info pull-right" runat="server" OnClick="btnShow_Click" />
                            </div>
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
            open_menu("Reports", "Deposit");
        });
    </script>
</asp:Content>
