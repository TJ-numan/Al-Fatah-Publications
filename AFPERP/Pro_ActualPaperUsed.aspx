<%@ Page Title="Actual Paper Used" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_ActualPaperUsed.aspx.cs" Inherits="BLL.Pro_ActualPaperUsed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <asp:UpdatePanel ID="UpadatePanel1" runat="server">
        <ContentTemplate>
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Actual Paper Used
                </div>
                <%-- <div id="frmActualPaperUsed" runat="server" class="form-horizontal clearfix">--%>
                <div class="panel-body">
                    <div class="col-md-12 no-padding clearfix">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtDate" CssClass="col-xs-4 control-label no-padding-right" Text="Date"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" placeholder="yyyy/mm/dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" TargetControlID="txtDate" Format="yyyy/MM/dd" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlPressName" CssClass="col-xs-4 control-label no-padding-right" Text="Press"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlPressName" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtOrderNo" CssClass="col-xs-4 control-label no-padding-right" Text="Order No"></asp:Label>
                                <div class="col-xs-4">
                                    <asp:TextBox ID="txtOrderNo" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtOrderNo_TextChanged" />
                                </div>
                                <div class="col-xs-4">
                                    <asp:DropDownList runat="server" ID="ddlPlateFor" CssClass="form-control">
                                        <asp:ListItem Value="C">Cover</asp:ListItem>
                                        <asp:ListItem Value="F">Forma</asp:ListItem>
                                        <asp:ListItem Value="A">Administrative</asp:ListItem>
                                        <asp:ListItem Value="P">Promotional</asp:ListItem>
                                        <asp:ListItem Value="Z">Zinix</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtPrintOrderDate" CssClass="col-xs-4 control-label no-padding-right" Text="Print Order Date"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtPrintOrderDate" runat="server" CssClass="form-control" placeholder="yyyy/mm/dd" disabled="" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtPrintQty" CssClass="col-xs-4 control-label no-padding-right" Text="Print Qty"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtPrintQty" runat="server" CssClass="form-control" disabled="" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtGroup" CssClass="col-xs-4 control-label no-padding-right" Text="Group"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtGroup" runat="server" CssClass="form-control" disabled="" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtClass" CssClass="col-xs-4 control-label no-padding-right" Text="Class"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtClass" runat="server" CssClass="form-control" disabled="" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtType" CssClass="col-xs-4 control-label no-padding-right" Text="Type"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtType" runat="server" CssClass="form-control" disabled="" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlBookName" CssClass="col-sm-4 control-label no-padding-right" Text="Book Name"></asp:Label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="ddlBookName" runat="server" CssClass="form-control" disabled="" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlEdition" CssClass="col-xs-4 control-label no-padding-right" Text="Edition"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="ddlEdition" runat="server" CssClass="form-control" disabled="" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--table--%>
                    <div class="col-md-12 table-responsive clearfix">
                        <table class="table no-head-padding">
                            <tr>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtRunNo" CssClass="control-label" Text="Run No"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtRollNo" CssClass="control-label" Text="Roll No"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtAFNo" CssClass="control-label" Text="AF No"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtBRNo" CssClass="control-label" Text="BR No"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:Label runat="server" AssociatedControlID="txtPaperQty" CssClass="control-label" Text="Paper Qty"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" ID="txtRunNo" CssClass="form-control" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtRollNo" CssClass="form-control" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtAFNo" CssClass="form-control" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtBRNo"  CssClass="form-control" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPaperQty" runat="server" CssClass="form-control" />
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-primary btn-xs" Text="Add" OnClick="btnAdd_Click"/>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="col-md-12 clearfix">
                        <div class="table-responsive">
                            <asp:GridView ID="gvwPrintBill" runat="server" CssClass="grid-view table" AutoGenerateColumns="false">
                                 <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                <Columns>
                                    <asp:BoundField DataField="RunNo" HeaderText="Run No" />
                                    <asp:BoundField DataField="RollNo" HeaderText="Roll No" />
                                    <asp:BoundField DataField="AFNo" HeaderText="AF No" />
                                    <asp:BoundField DataField="BRNo" HeaderText="BR No" />
                                    <asp:BoundField DataField="PaperQty" HeaderText="Paper Qty." />
                                    <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("Serial") %>' OnClick="lbDelete_Click">
                                                 Delete
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="col-md-12 no-padding clearfix">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtRemark" CssClass="col-xs-4 control-label no-padding-right" Text="Remarks"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtRemark" runat="server" CssClass="form-control" placeholder="Remarks" TextMode="MultiLine" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtTotalPaperQty" CssClass="col-xs-4 control-label no-padding-right" Text="Paper Used"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtTotalPaperQty" runat="server" CssClass="form-control" ReadOnly="True" disabled="" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtTotalPlateQty" CssClass="col-xs-4 control-label no-padding-right" Text="Plate Used"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtTotalPlateQty" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtTotalRoll" CssClass="col-xs-4 control-label no-padding-right" Text="Total Roll"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtTotalRoll" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtTotalPrint" CssClass="col-xs-4 control-label no-padding-right" Text="Total Print"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtTotalPrint" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-8 col-xs-offset-4">
                                    <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSPro" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Printing");
        });
    </script>
</asp:Content>
