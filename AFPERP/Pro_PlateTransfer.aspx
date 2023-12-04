<%@ Page Title="" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_PlateTransfer.aspx.cs" Inherits="BLL.Pro_PlateTransfer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
<div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Plate Transfer
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPaperTransferNo" CssClass="col-md-4 control-label" Text="Transfer No"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPaperTransferNo" runat="server" CssClass="form-control" placeholder="Transfer No" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPaperRefNo" CssClass="col-md-4 control-label" Text="Ref No"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPaperRefNo" runat="server" CssClass="form-control" placeholder="Ref No" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="dtpPaperTransferDate" CssClass="col-md-4 control-label" Text="Transfer Date"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="dtpPaperTransferDate" runat="server" CssClass="form-control" placeholder="yyyy-MM-dd" />
                            <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="dtpPaperTransferDate" />
                        </div>
                    </div>
                    <div>
                        <div class="col-sm-6">
                            <fieldset class="fsStyle">
                                <legend class="legendStyle">From</legend>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="ddlPaperPressGodownFrom" CssClass="col-md-4 control-label" Text="Press/Godown"></asp:Label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlPaperPressGodownFrom" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="col-sm-6">
                            <fieldset class="fsStyle">
                                <legend class="legendStyle">To</legend>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="ddlPaperPressGodownTo" CssClass="col-md-4 control-label" Text="Press/Godown"></asp:Label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlPaperPressGodownTo" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                    <%--table placement--%>
                    <div class="table-responsive no-padding">
                        <table class="table no-head-padding">
                            <tr>
                                <td>
                                    <asp:Label ID="lblSuplyDate" runat="server" Text="Supply Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPlateReceiptNo" runat="server" Text="Receipt No"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPlateFor" runat="server" Text="Plate For"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPlateType" runat="server" Text="Type"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPlateSize" runat="server" Text="Size"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPlateQty" runat="server" Text="Quantity"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPlateRate" runat="server" Text="Rate"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="max-width: 100px">
                                    <asp:TextBox ID="dtpSupplyDate" runat="server" CssClass="form-control" placeholder="yyyy-MM-dd" />
                                    <ajaxToolkit:CalendarExtender Format="yyyy-MM-dd" TargetControlID="dtpSupplyDate" runat="server" />
                                </td>
                                <td style="max-width: 100px">
                                    <asp:TextBox ID="txtPlateReceiptNo" runat="server" CssClass="form-control" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPlateFor" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">Cover</asp:ListItem>
                                        <asp:ListItem Value="1">Inner</asp:ListItem>
                                        <asp:ListItem Value="2">2 No Forma</asp:ListItem>
                                        <asp:ListItem Value="3">Main Forma</asp:ListItem>
                                        <asp:ListItem Value="4">Postani</asp:ListItem>
                                        <asp:ListItem Value="5">Promotional</asp:ListItem>
                                        <asp:ListItem Value="6">Administrative</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPlateType" runat="server" CssClass="form-control"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPlateSize" runat="server" CssClass="form-control"></asp:DropDownList>
                                </td>
                                <td style="max-width: 100px">
                                    <asp:TextBox ID="txtPlateQty" runat="server" CssClass="form-control" placeholder="0" />
                                </td>
                                <td style="max-width: 100px">
                                    <asp:TextBox ID="txtPlateRate" runat="server" CssClass="form-control" placeholder="0" />
                                </td>
                            </tr>
                        </table>
                    </div>

                    <div class="clearfix">
                        <asp:Button ID="btnPaperAdd" runat="server" CssClass="btn btn-xs btn-primary pull-right" Text="Add" OnClick="btnPaperAdd_Click"></asp:Button>
                    </div>

                    <%--grid view--%>
                    <div class="table-responsive">
                        <asp:GridView ID="gvwPaperTrAddedData" CssClass="grid-view table" runat="server" Align="Center" AutoGenerateColumns="false">
                            <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                            <Columns>
                                <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" DataField="Serial" />
                                <asp:BoundField DataField="SupplyDate" HeaderText="SupplyDate" DataFormatString="{0:yyyy-MM-dd}" />
                                <asp:BoundField DataField="ReceiptNo" HeaderText="ReceiptNo" />
                                <asp:BoundField DataField="Brand" HeaderText="Plate For" />
                                <asp:BoundField DataField="Type" HeaderText="Type" />
                                <asp:BoundField DataField="Size" HeaderText="Size" />                              
                                <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                <asp:BoundField DataField="Rate" HeaderText="Rate" />
                                <asp:BoundField DataField="Bill" HeaderText="Amount"/>
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

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPaperRemark" CssClass="col-md-4 control-label" Text="Remarks"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPaperRemark" runat="server" CssClass="form-control" placeholder="Remarks" TextMode="MultiLine" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPaperTotalAmount" CssClass="col-md-4 control-label" Text="Total Amount"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPaperTotalAmount" runat="server" CssClass="form-control" placeholder="0" readonly="true"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                            <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-primary" runat="server" OnClick="btnPrint_Click" />
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
            open_menu("Plate");
        });
    </script>
</asp:Content>