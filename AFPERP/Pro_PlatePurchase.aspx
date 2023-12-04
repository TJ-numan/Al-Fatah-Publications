<%@ Page Title="Plate Purchase" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_PlatePurchase.aspx.cs" Inherits="BLL.Pro_PlatePurchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">

    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Plate Purchase
                </div>
                <%--<div id="frmPlatePurchase" runat="server" class="form-horizontal clearfix">--%>
                <div class="panel-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="col-md-12 no-padding clearfix">
                                <div class="col-md-6 clearfix">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtOrderDate" CssClass="col-xs-4 control-label no-padding-right" Text="Order Date"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtOrderDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                            <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtOrderDate" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtOrderNo" CssClass="col-xs-4 control-label no-padding-right" Text="Order No"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtOrderNo" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlSupplier" CssClass="col-xs-4 control-label no-padding-right" Text="Supplier"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList ID="ddlSupplier" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlReceiveBy" CssClass="col-xs-4 control-label no-padding-right" Text="Received By"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList ID="ddlReceiveBy" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlReceiveBy_SelectedIndexChanged">
                                                <asp:ListItem Value=""> </asp:ListItem>
                                                <asp:ListItem Value="0">Press</asp:ListItem>
                                                <asp:ListItem Value="1">Process</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlReceiveAt" CssClass="col-xs-4 control-label no-padding-right" Text="Press Name"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList ID="ddlReceiveAt" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6 clearfix">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlCategory" CssClass="col-xs-4 control-label no-padding-right" Text="Category"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlGroup" CssClass="col-xs-4 control-label no-padding-right" Text="Group"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlClass" CssClass="col-xs-4 control-label no-padding-right" Text="Class"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlType" CssClass="col-xs-4 control-label no-padding-right" Text="Type"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlBookName" CssClass="col-sm-4 control-label no-padding-right" Text="Book Name"></asp:Label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="ddlBookName" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlBookName_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlEdition" CssClass="col-xs-4 control-label no-padding-right" Text="Edition"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList ID="ddlEdition" runat="server" CssClass="form-control"></asp:DropDownList>
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
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtRefNo" CssClass="control-label" Text="Ref No"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtPurchaseDate" CssClass="control-label" Text="Purchase Date"></asp:Label>
                                </td>
                                <td style="min-width: 80px;">
                                    <asp:Label runat="server" AssociatedControlID="ddlPlateFor" CssClass="control-label" Text="Plate For"></asp:Label>
                                </td>
                                <td style="min-width: 80px;">
                                    <asp:Label runat="server" AssociatedControlID="ddlPlateType" CssClass="control-label" Text="Plate Type"></asp:Label>
                                </td>
                                <td style="min-width: 80px;">
                                    <asp:Label runat="server" AssociatedControlID="ddlPlateSize" CssClass="control-label" Text="Plate Size"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtQty" CssClass="control-label" Text="Plate Qty"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtRate" CssClass="control-label" Text="Rate"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtTotalBill" CssClass="control-label" Text="Total"></asp:Label>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" ID="txtRefNo" CssClass="form-control" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtPurchaseDate" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtPurchaseDate" />
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlPlateFor" CssClass="form-control">
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
                                    <asp:DropDownList runat="server" ID="ddlPlateType" CssClass="form-control"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlPlateSize" CssClass="form-control"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQty" runat="server" CssClass="form-control _bill" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRate" runat="server" CssClass="form-control _bill" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTotalBill" runat="server" CssClass="form-control bill-tot" />
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-primary btn-xs" Text="Add" OnClick="btnAdd_Click" />
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
                                <asp:BoundField DataField="BookName" HeaderText="Book Name" />
                                <asp:BoundField DataField="Class" HeaderText="Class" />
                                <asp:BoundField DataField="Type" HeaderText="Type" />
                                <asp:BoundField DataField="Edition" HeaderText="Edition" />
                                <asp:BoundField DataField="ReferNo" HeaderText="Ref. No" />
                                <asp:BoundField DataField="PurchaseDate" HeaderText="Date" />
                                <asp:BoundField DataField="PlateFor" HeaderText="Plate For" />
                                <asp:BoundField DataField="PlateType" HeaderText="Plate Type" />
                                <asp:BoundField DataField="PlateSize" HeaderText="Plate Size" />
                                <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                <asp:BoundField DataField="BillRate" HeaderText="BillRate" />
                                <asp:BoundField DataField="TotalBill" HeaderText="TotalBill" />
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
                                <asp:Label runat="server" AssociatedControlID="txtTotalAmount" CssClass="col-xs-4 control-label no-padding-right" Text="Total Amount"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtTotalAmount" runat="server" ReadOnly="true" CssClass="form-control" />
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


        calculateMult("._bill", ".bill-tot");

        $("._bill").on("keyup", function () {
            calculateMult("._bill", ".bill-tot");
        });

        function calculateMult(field, total) {
            var multi = 1;

            $(field).each(function () {
                //add only if the value is number
                if (!isNaN(this.value) && this.value.length != 0) {
                    multi *= parseFloat(this.value);
                }
                else multi = 0;

            });
            $(total).val(multi.toFixed(2));

        }

    </script>
</asp:Content>
