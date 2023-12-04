<%@ Page Title="" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_Rpt_FormaPrintingOrder.aspx.cs" Inherits="BLL.Pro_Rpt_FormaPrintingOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Forma Printing Order
                </div>
                
                <div class="panel-body">
                    <div class="col-md-12 no-padding clearfix">
                        <div class="col-md-6 clearfix">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlPlateFor" CssClass="col-xs-4 control-label no-padding-right" Text="Order for"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlPlateFor" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="C">Cover</asp:ListItem>
                                        <asp:ListItem Value="F">Forma</asp:ListItem>
                                        <asp:ListItem Value="A">Administrative</asp:ListItem>
                                        <asp:ListItem Value="P">Promotional</asp:ListItem>
                                        <asp:ListItem Value="Z">Zinix</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtOrderNo" CssClass="col-xs-4 control-label no-padding-right" Text="Order No"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtOrderNo" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtOrderNo_TextChanged" />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-xs-8 col-xs-offset-4">
                                    <asp:Label runat="server" AssociatedControlID="chkExtra" CssClass="control-label" Text="Extra Plate Supply"></asp:Label>
                                    <asp:CheckBox CssClass="checkbox col-xs-1" runat="server" ID="chkExtra" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlPressName" CssClass="col-xs-4 control-label no-padding-right" Text="Press"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlPressName" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-xs-8 col-xs-offset-4">
                                    <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info" runat="server" OnClick="btnShow_Click" />
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
</asp:Content>
