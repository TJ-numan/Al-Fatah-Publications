<%@ Page Title="" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_PlateDamageStockEntry.aspx.cs" Inherits="BLL.Pro_PlateDamageStockEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
 <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Damage Plate Stock Entry
                </div>
                <div class="panel-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="col-md-12 no-padding clearfix">
                                <div class="col-md-6 clearfix">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtMemoNo" CssClass="col-xs-4 control-label no-padding-right" Text="Memo No"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtMemoNo" runat="server" CssClass="form-control" Readonly="true"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtChallanDate" CssClass="col-xs-4 control-label no-padding-right" Text="Damage Date"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtChallanDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                            <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtChallanDate" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlFromPress" CssClass="col-xs-4 control-label no-padding-right" Text="Press Name"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList ID="ddlFromPress" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="TxtSlipNo" CssClass="col-xs-4 control-label no-padding-right" Text="Slip No"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="TxtSlipNo" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <%--table--%>
                    <div class="col-md-12 table-responsive clearfix">
                        <table class="table no-head-padding">
                            <tr>                       
                                <td style="min-width: 300px;">
                                    <asp:Label runat="server" AssociatedControlID="ddlPlateType" CssClass="control-label" Text="Plate Type"></asp:Label>
                                </td>
                                <td style="min-width: 300px;">
                                    <asp:Label runat="server" AssociatedControlID="ddlPlateSize" CssClass="control-label" Text="Plate Size"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtQty" CssClass="control-label" Text="Plate Qty"></asp:Label>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlPlateType" CssClass="form-control"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlPlateSize" CssClass="form-control"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQty" runat="server" CssClass="form-control _bill" />
                                </td>                              
                                <td>
                                    <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-primary" Text="Add" OnClick="btnAdd_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>

                    <%--table grid--%>
                    <div class="col-md-12 table-responsive clearfix">
                        <asp:GridView ID="gvwPlatePur" runat="server" CssClass="grid-view table" AutoGenerateColumns="false">
                             <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                            <Columns>
                                <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" DataField="Serial" />                             
                                <asp:BoundField DataField="PlateType" HeaderText="Plate Type" />
                                <asp:BoundField DataField="PlateSize" HeaderText="Plate Size" />
                                <asp:BoundField DataField="Qty" HeaderText="Qty" />
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
                    <div class="col-md-12 no-padding clearfix">
                        <div class="col-md-6 clearfix"></div>
                        <div class="col-md-6 clearfix">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtTotalPlateQty" CssClass="col-xs-4 control-label no-padding-right" Text="Total Plate Qty"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtTotalPlateQty" runat="server" ReadOnly="true" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-8 col-xs-offset-4">
                                    <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                                    <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-primary" runat="server" OnClick="btnPrint_Click" />
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
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Plate");
        });

    </script>
</asp:Content>

