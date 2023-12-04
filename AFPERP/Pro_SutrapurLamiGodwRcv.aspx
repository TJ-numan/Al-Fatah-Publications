<%@ Page Title="" Language="C#" MasterPageFile="~/Distribution.master" AutoEventWireup="true" CodeBehind="Pro_SutrapurLamiGodwRcv.aspx.cs" Inherits="BLL.Pro_SutrapurLamiGodwRcv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DistributionContent" runat="server">
     <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Sutrapur Lamination Godown Receive
                </div>             
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtReceivedID" CssClass="col-md-4 control-label" Text="Received ID"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtReceivedID" runat="server" CssClass="form-control" placeholder="Received ID" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" AssociatedControlID="ddlSuplier" CssClass="col-md-4 control-label" Text="Supply Party"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlSuplier" runat="server" CssClass="form-control" AutoPostBack="true" >
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtSuppBillNo" CssClass="col-md-4 control-label" Text="Supplier Bill No"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtSuppBillNo" runat="server" CssClass="form-control" placeholder="Supplier Bill No" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="dtpSupplierDate" CssClass="col-md-4 control-label" Text="Supply Date"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="dtpSupplierDate" runat="server" CssClass="form-control" placeholder="yyyy-MM-dd" />
                            <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="dtpSupplierDate" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtRcvMemo" CssClass="col-md-4 control-label" Text="Receive Memo"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtRcvMemo" runat="server" CssClass="form-control" placeholder="Receive Memo" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="dtpRcvDate" CssClass="col-md-4 control-label" Text="Receive Date"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="dtpRcvDate" runat="server" CssClass="form-control" placeholder="yyyy-MM-dd" />
                            <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="dtpRcvDate" />
                        </div>
                    </div>

                    <%--table placement--%>
                    <div class="table-responsive">
                        <table class="table no-head-padding">
                            <tr>
                                <td>
                                    <asp:Label ID="lbllamiType" runat="server" Text="Type"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbllamiSize" runat="server" Text="Size"></asp:Label>
                                </td>
                                
                                <td colspan="2">
                                    <asp:Label ID="lblQty" runat="server" Text="Quantity"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaperPrice" runat="server" Text="Price"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlLamiType" runat="server" CssClass="form-control"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlLamiSize" runat="server" CssClass="form-control"></asp:DropDownList>
                                </td>
                               
                                <td style="max-width: 100px">
                                    <asp:TextBox ID="txtQty" runat="server" CssClass="form-control" placeholder="0" />
                                </td>
                                <td style="max-width: 100px">
                                    <asp:DropDownList ID="ddlUnit" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="1" Text="Kg"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Packet"></asp:ListItem>
                                        </asp:DropDownList>
                                </td>
                                <td style="max-width: 100px">
                                    <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="form-control" placeholder="0" />
                                </td>
                                    <td>
                                        <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-xs btn-primary" Text="Add" OnClick="btnAdd_Click"></asp:Button>
                                    </td>
                            </tr>
                        </table>
                    </div>
    

                    <%--grid view--%>
                    <div class="table-responsive">
                        <asp:GridView ID="gvwPaperAddedData" CssClass="grid-view table" runat="server" Align="center" AutoGenerateColumns="false">
                             <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                            <Columns>
                                    <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" DataField="Serial" />
                                <asp:BoundField DataField="Type" HeaderText="Type"/>
                                <asp:BoundField DataField="Size" HeaderText="Size"/>
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
                        <asp:Label runat="server" AssociatedControlID="txtRemarks" CssClass="col-md-4 control-label" Text="Remarks"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" placeholder="Remarks" TextMode="MultiLine" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtTotalAmount" CssClass="col-md-4 control-label" Text="Total Amount"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtTotalAmount" runat="server" CssClass="form-control calc" placeholder="0" Enable="false" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtLabourCost" CssClass="col-md-4 control-label" Text="Labour Cost"  Visible="false"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtLabourCost" runat="server" CssClass="form-control calc" Text="0" placeholder="0"  Visible="false"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtNetAmount" CssClass="col-md-4 control-label" Text="Net Amount" Visible="false"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtNetAmount" runat="server" CssClass="form-control calc-total" placeholder="0" Visible="false" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click"/>
                            <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-info" runat="server" OnClick="btnPrint_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSDistribution" runat="server">
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
            open_menu("Sutrapur Lamination");
        });
    </script>
</asp:Content>
