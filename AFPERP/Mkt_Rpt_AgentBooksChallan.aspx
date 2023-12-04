<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Rpt_AgentBooksChallan.aspx.cs" Inherits="BLL.Mkt_Rpt_AgentBooksChallan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Agent's Bookwise Quantity
                </div>
                <div class=" panel-body">


                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlLibrary" CssClass="col-md-4 control-label" Text="Library" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlLibrary" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-4 control-label" Text="From" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-MM-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-4 control-label" Text="To" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-MM-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />

                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlEdition" CssClass="col-md-4 control-label" Text="Edition" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlEdition" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="chkIsQawmi" CssClass="col-md-4 control-label" Text="IsQawmi" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:CheckBox CssClass="form-control" ID="chkIsQawmi" runat="server">
                            </asp:CheckBox>
                        </div>
                    </div>
                                        <div class="form-group">
                        <asp:Label AssociatedControlID="ddlViewers" runat="server" CssClass="col-md-4 control-label" Text="View Option" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlViewers" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0"> Select any type</asp:ListItem>
                                <asp:ListItem Value="1"> View as Pdf File</asp:ListItem>
                                <asp:ListItem Value="2"> View as Excel File</asp:ListItem>
                                <asp:ListItem Value="3"> View as Word File</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">
                            <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info" runat="server" OnClick="btnShow_Click" />
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
                    open_menu("Reports", "Chalan");
                });
            </script>
</asp:Content>

