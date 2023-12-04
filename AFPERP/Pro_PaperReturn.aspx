<%@ Page Title="" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_PaperReturn.aspx.cs" Inherits="BLL.Pro_PaperReturn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Paper Return
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPaperReturnNo" CssClass="col-md-4 control-label" Text="Return No"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPaperReturnNo" runat="server" CssClass="form-control" placeholder="Return No" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="dtpPaperReturnDate" CssClass="col-md-4 control-label" Text="Return Date"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="dtpPaperReturnDate" runat="server" CssClass="form-control" placeholder="yyyy/mm/dd" />
                            <ajaxToolkit:CalendarExtender runat="server" Format="yyyy/MM/dd" TargetControlID="dtpPaperReturnDate" />
                        </div>
                    </div>
                    <div>
                        <div class="col-sm-6">
                            <fieldset class="fsStyle">
                                <legend class="legendStyle">From Press</legend>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="ddlPaperPressGodownFrom" CssClass="col-md-4 control-label" Text="Press"></asp:Label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlPaperPressGodownFrom" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="col-sm-6">
                            <fieldset class="fsStyle">
                                <legend class="legendStyle">To Supplier</legend>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="ddlPaperPressGodownTo" CssClass="col-md-4 control-label" Text="Supplier"></asp:Label>
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
                                    <asp:Label ID="lblPaperTrReceiptNo" runat="server" Text="Receipt No"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaperTrType" runat="server" Text="Type"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaperTrSize" runat="server" Text="Size"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaperTrGSM" runat="server" Text="GSM"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaperTrBrand" runat="server" Text="Brand"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaperTrQty" runat="server" Text="Quantity"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaperTrPrice" runat="server" Text="Price"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblUnit" runat="server" Text="Unit"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblRoll" runat="server" Text="Roll" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="max-width: 100px">
                                    <asp:TextBox ID="dtpSupplyDate" runat="server" CssClass="form-control" placeholder="yyyy/mm/dd" />
                                    <ajaxToolkit:CalendarExtender Format="yyyy/MM/dd" TargetControlID="dtpSupplyDate" runat="server" />
                                </td>
                                <td style="max-width: 100px">
                                    <asp:TextBox ID="txtPaperReceiptNo" runat="server" CssClass="form-control" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPaperType" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlPaperType_SelectedIndexChanged"></asp:DropDownList>
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
                                <td style="max-width: 100px">
                                    <asp:TextBox ID="txtPaperQty" runat="server" CssClass="form-control" placeholder="0" />
                                </td>
                                <td style="max-width: 100px">
                                    <asp:TextBox ID="txtPaperPrice" runat="server" CssClass="form-control" placeholder="0" />
                                </td>
                                <td style="max-width: 100px">
                                    <asp:DropDownList ID="ddlPaperUnit" runat="server" CssClass="form-control" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRoll" runat="server" Visible="false"></asp:TextBox>
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
                                <asp:BoundField DataField="SupplyDate" HeaderText="SupplyDate" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="ReceiptNo" HeaderText="ReceiptNo" />
                                <asp:BoundField DataField="Type" HeaderText="Type" />
                                <asp:BoundField DataField="Size" HeaderText="Size" />
                                <asp:BoundField DataField="GSM" HeaderText="GSM" />
                                <asp:BoundField DataField="Brand" HeaderText="Brand" />
                                <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                <asp:BoundField DataField="Price" HeaderText="Price" />
                                <asp:BoundField DataField="Bill" HeaderText="Bill" />
                                <asp:BoundField DataField="RollQty" HeaderText="Roll Qty" />

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
                            <asp:TextBox ID="txtPaperTotalAmount" runat="server" CssClass="form-control calc" placeholder="0" Readonly="true" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPaperLabourCost" CssClass="col-md-4 control-label" Text="Labour Cost"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPaperLabourCost" runat="server" CssClass="form-control calc" placeholder="0"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPaperNetAmount" CssClass="col-md-4 control-label" Text="Net Amount"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPaperNetAmount" runat="server" CssClass="form-control calc-total" placeholder="0" Readonly="true" />
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
