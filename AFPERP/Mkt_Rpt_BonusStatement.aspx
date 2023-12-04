<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Rpt_BonusStatement.aspx.cs" Inherits="BLL.Mkt_Rpt_BonusStatement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    View Bonus Statement Report
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlYear" CssClass="col-md-4 control-label" Text="Year" runat="server"></asp:Label>
                        <div class="dropdown col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="2022-2023" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2021-2022" Value="2"></asp:ListItem>
                                <asp:ListItem Text="2020-2021" Value="3"></asp:ListItem>
                                <asp:ListItem Text="2019-2020" Value="4"></asp:ListItem>
                                <asp:ListItem Text="2018-2019" Value="5"></asp:ListItem>
                                <asp:ListItem Text="2017-2018" Value="6"></asp:ListItem>
                                <asp:ListItem Text="2016-2017" Value="7"></asp:ListItem>
                                <asp:ListItem Text="2015-2016" Value="8"></asp:ListItem>
                                <asp:ListItem Text="2014-2015" Value="9"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <asp:Label runat="server" ID="lblYearMsg"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-4 control-label" Text="From Date" runat="server"></asp:Label>
                        <div class="input-group col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-mm-dd" runat="server" ReadOnly="True" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-4 control-label" Text="To Date" runat="server"></asp:Label>
                        <div class="input-group col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-mm-dd" runat="server" ReadOnly="True" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlLibraryName" CssClass="col-md-4 control-label" Text="Agent Name" runat="server"></asp:Label>
                        <div class="dropdown col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlLibraryName" runat="server">
                                 <asp:ListItem Value="-1">--Select Library--</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>



                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">
                            <asp:CheckBox ID="chkIsQawmi" CssClass="checkbox pull-left" runat="server" />
                            <asp:Label AssociatedControlID="chkIsQawmi" CssClass="control-label" runat="server" Text="Qawmi"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="input-group col-md-8 col-md-offset-4">
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
