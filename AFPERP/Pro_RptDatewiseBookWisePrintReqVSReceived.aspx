<%@ Page Title="" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_RptDatewiseBookWisePrintReqVSReceived.aspx.cs" Inherits="BLL.Pro_RptDatewiseBookWisePrintReqVSReceived" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
        <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Datewise Print Requisition Vs Godown Report
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
                        <asp:Label AssociatedControlID="ddlCategory" CssClass="col-md-4 control-label" Text="Category" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                <asp:ListItem Value="">--Select--</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlGroup" CssClass="col-md-4 control-label" Text="Group" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlGroup" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlClass" CssClass="col-md-4 control-label" Text="Class" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlClass" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlType" CssClass="col-md-4 control-label" Text="Type" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlBookName" CssClass="col-md-4 control-label" Text="Book Name" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlBookName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBookName_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlEdition" CssClass="col-md-4 control-label" Text="Edition" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlEdition" runat="server" AutoPostBack="True">
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
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSPro" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Reports", "Print");
        });
    </script>
</asp:Content>

