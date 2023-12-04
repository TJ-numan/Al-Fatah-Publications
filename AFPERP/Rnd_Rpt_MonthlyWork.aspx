<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="Rnd_Rpt_MonthlyWork.aspx.cs" Inherits="BLL.Rnd_Rpt_MonthlyWork" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    View Monthly Work Report
                </div>
                <div class="panel-body">
                    <div class="jumbroton">
                        <div class="col-md-7">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-4 control-label" Text="From" runat="server"></asp:Label>
                                <div class="col-md-5">
                                    <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy/MM/dd" runat="server" />
                                    <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy/MM/dd" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-4 control-label" Text="To" runat="server"></asp:Label>
                                <div class="col-md-5">
                                    <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy/MM/dd" runat="server" />
                                    <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy/MM/dd" runat="server" />

                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlSection" CssClass="col-md-4 control-label" Text="Section" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlSection" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlEmployee" CssClass="col-md-4 control-label" Text="Employee" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlEmployee" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-7">
                            <div class="form-group">
                                <div class="col-md-8 col-md-offset-4">
                                    <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info" runat="server" />
                                </div>
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
