<%@ Page Title="Paper Delivery" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_PaperDelivery.aspx.cs" Inherits="BLL.Pro_PaperDelivery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Paper Delivery Order
                </div>             
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPaperDeliveryID" CssClass="col-md-4 control-label" Text="Delivery ID"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPaperDeliveryID" runat="server" CssClass="form-control" placeholder="Delivery ID" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" AssociatedControlID="ddlPaperSuplier" CssClass="col-md-4 control-label" Text="Suplier"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlPaperSuplier" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPaperSuplier_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="ddlPaperPurchaseOrder" CssClass="col-md-4 control-label" Text="Purchase Order"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlPaperPurchaseOrder" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlPaperPurchaseOrder_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPaperBillNo" CssClass="col-md-4 control-label" Text="Bill No"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPaperBillNo" runat="server" CssClass="form-control" placeholder="Bill No" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="dtpPaperBillDate" CssClass="col-md-4 control-label" Text="Bill Date"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="dtpPaperBillDate" runat="server" CssClass="form-control" placeholder="yyyy-MM-dd" />
                            <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="dtpPaperBillDate" />
                        </div>
                    </div>

                    <%--table placement--%>
                    <div class="table-responsive">
                        <table class="table no-head-padding">
                            <tr>
                                <td>
                                    <asp:Label ID="lblPaperSuplyDate" runat="server" Text="Supply Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaperType" runat="server" Text="Type"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaperSize" runat="server" Text="Size"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaperGSM" runat="server" Text="GSM"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaperBrand" runat="server" Text="Brand"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaperOrigin" runat="server" Text="Origin"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblPaperQty" runat="server" Text="Quantity"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaperPrice" runat="server" Text="Price"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="max-width: 100px">
                                    <asp:TextBox ID="dtpPaperSupplyDate" runat="server" CssClass="form-control" placeholder="yyyy-MM-dd" />
                                    <ajaxToolkit:CalendarExtender Format="yyyy-MM-dd" TargetControlID="dtpPaperSupplyDate" runat="server" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPaperType" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlPaperType_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPaperSize" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlPaperSize_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPaperGSM" runat="server" CssClass="form-control"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPaperBrand" runat="server" CssClass="form-control"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPaperOrigin" runat="server" CssClass="form-control"></asp:DropDownList>
                                </td>
                                <td style="max-width: 100px">
                                    <asp:TextBox ID="txtPaperQty" runat="server" CssClass="form-control" placeholder="0" />
                                </td>
                                <td style="max-width: 100px">
                                    <asp:DropDownList ID="ddlPaperUnit" runat="server" CssClass="form-control" />
                                </td>
                                <td style="max-width: 100px">
                                    <asp:TextBox ID="txtPaperPrice" runat="server" CssClass="form-control" placeholder="0" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <%--table placement--%>
                    <div>
                        <div class="table-responsive col-md-6 col-md-offset-3 no-padding">
                            <table class="table no-head-padding">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Receipt No"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Press"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Delivery Qty"></asp:Label>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtReceiptNo" runat="server" CssClass="form-control" />
                                    </td>
                                    <td  class="col-md-5">
                                        <asp:DropDownList ID="ddlPress" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDeliveryQty" runat="server" CssClass="form-control" />
                            <span>
                                <asp:Label ID="lblRoll" runat="server" Text="Roll : " Visible="false"></asp:Label>
                                <asp:TextBox ID="txtRoll" runat="server" Visible="false"></asp:TextBox>
                            </span>
                                    </td>

                                    <td>
                                        <asp:Button ID="btnPaperAdd" runat="server" CssClass="btn btn-xs btn-primary" Text="Add" OnClick="btnPaperAdd_Click"></asp:Button>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>

                    <%--grid view--%>
                    <div class="table-responsive">
                        <asp:GridView ID="gvwPaperAddedData" CssClass="grid-view table" runat="server" Align="center" AutoGenerateColumns="false">
                             <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                            <Columns>
                                    <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" DataField="Serial" />
                                <asp:BoundField DataField="PurchaseOrder" HeaderText="PurchaseOrder" />
                                <asp:BoundField DataField="PressRNo" HeaderText="PressRNo"/>
                                <asp:BoundField DataField="RollQty" HeaderText="Roll Qty" />
                                <asp:BoundField DataField="Press" HeaderText="Press"/>
                                <asp:BoundField DataField="Type" HeaderText="Type"/>
                                <asp:BoundField DataField="Size" HeaderText="Size"/>
                                <asp:BoundField DataField="GSM" HeaderText="GSM"/>
                                <asp:BoundField DataField="Brand" HeaderText="Brand"/>
                                <asp:BoundField DataField="Origin" HeaderText="Origin"/>
                                <asp:BoundField DataField="SupplyDate" HeaderText="SupplyDate" DataFormatString="{0:yyyy-MM-dd}"/>
                                <asp:BoundField DataField="Qty" HeaderText="Qty"/>
                                <asp:BoundField DataField="Unit" HeaderText="Unit"/>
                                <asp:BoundField DataField="Price" HeaderText="Price"/>
                                <asp:BoundField DataField="Amount" HeaderText="Amount"/>
                                
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
                            <asp:TextBox ID="txtPaperTotalAmount" runat="server" CssClass="form-control calc" placeholder="0" Enable="false" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPaperLabourCost" CssClass="col-md-4 control-label" Text="Labour Cost"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPaperLabourCost" runat="server" CssClass="form-control calc" Text="0" placeholder="0" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPaperNetAmount" CssClass="col-md-4 control-label" Text="Net Amount"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPaperNetAmount" runat="server" CssClass="form-control calc-total" placeholder="0" disabled="disabled" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">
                            <asp:Button ID="btnPaperSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnPaperSave_Click" />
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

             calculateSum(".calc", ".calc-total");

             $(".calc").on("keyup", function () {
                 calculateSum(".calc", ".calc-total");
             });
   

         });

         //more field summation with textchange
         function calculateSum(field, total) {
             var sum = 0;

             $(field).each(function () {
                 //add only if the value is number
                 if (!isNaN(this.value) && this.value.length != 0) {
                     sum += parseFloat(this.value);
                 }
             });
             $(total).val(sum.toFixed(2));

         }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Paper");
        });
    </script>
</asp:Content>
