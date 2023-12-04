<%@ Page Title="" Language="C#" MasterPageFile="~/Distribution.master" AutoEventWireup="true" CodeBehind="Mkt_SPCAdjustment.aspx.cs" Inherits="BLL.Mkt_SPCAdjustment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DistributionContent" runat="server">
    <div id="frmChallanNew" runat="server" class="form-horizontal clearfix">
        <div class="col-md-12 clearfix no-padding">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h4>Adjustment Speciman Challan</h4>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6 clearfix">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtMemoNo" CssClass="col-md-4 control-label no-padding-right" Text="Memo No"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="txtMemoNo" CssClass="form-control" TabIndex="100" AutoPostBack="True" OnTextChanged="txtChlNewMemoNo_TextChanged" />

                                </div>
                                <div class="text-success col-md-8 col-md-offset-4">

                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtChalanID" CssClass="col-md-4 control-label no-padding-right" Text="Chalan ID"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="txtChalanID" CssClass="form-control" ReadOnly="true"/>

                                </div>
                                <div class="text-success col-md-8 col-md-offset-4">

                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtChlNewDate" CssClass="col-md-4 control-label no-padding-right" Text="Challan Date"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="txtChlNewDate" CssClass="form-control" placeholder="yyyy-mm-dd" AutoPostBack="false" TabIndex="0" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtChlNewDate" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlTSOName" CssClass="col-md-4 control-label no-padding-right" Text="TSO Name"></asp:Label>
                                <div class="col-md-8">
                                    <asp:DropDownList runat="server" ID="ddlTSOName" CssClass="form-control" TabIndex="1">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <hr style="border: 1px solid silver" />
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtSlipNo" CssClass="col-md-4 control-label no-padding-right" Text="Slip No"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="txtSlipNo" CssClass="form-control" placeholder="Slip No" />
                                </div>
                            </div>
                           <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtSlipDate" CssClass="col-md-4 control-label no-padding-right" Text="Slip Date"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="txtSlipDate" CssClass="form-control" placeholder="yyyy-mm-dd" AutoPostBack="false" TabIndex="0" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtSlipDate" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label CssClass="col-md-4 control-label no-padding-right" AssociatedControlID="chkIsDonation" Text="Donation" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:CheckBox ID="chkIsDonation" CssClass="checkbox pull-left" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtDeliveredBy" CssClass="col-md-4 control-label no-padding-right" Text="Delivered By"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtDeliveredBy" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr style="border: 1px solid silver" />
                   
                    <div class="col-xs-12">
                        <div class="form-group pull-left">
                            <asp:Label Style="float: left" runat="server" AssociatedControlID="txtBookCode" CssClass="control-label no-padding-right" Text="Book Code"></asp:Label>
                            <div class="col-xs-4 no-padding-right">
                                <asp:TextBox runat="server" ID="txtBookCode" OnTextChanged="txtBookCode_OnTextChanged" onhoverchanged="" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-xs-4">
                                <asp:Button runat="server" ID="btnEnter" Text="Enter" CssClass="btn btn-danger btnBookCodeEnter" OnClick="txtBookCode_OnTextChanged"></asp:Button>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix table-responsive">
                        <table class=" table-responsive table no-head-padding ">
                            <tr>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtBookName" CssClass="control-label" Text="Book Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtType" CssClass="control-label" Text="Type"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtClass" CssClass="control-label" Text="Class"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="ddlEdition" CssClass="control-label" Text="Edition"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtUnitPrice" CssClass="control-label" Text="Unit Price"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtAdjustmentQty" CssClass="control-label" Text="Quantity"></asp:Label>
                                </td>

                            </tr>
                            <tr>
                                <td style="width: 300px">
                                    <asp:TextBox runat="server" ID="txtBookName" CssClass="form-control" ReadOnly="True" disabled="" />
                                </td>

                                <td style="width: 100px">
                                    <asp:TextBox runat="server" ID="txtType" CssClass="form-control" ReadOnly="True" disabled="" />
                                </td>

                                <td style="width: 100px">
                                    <asp:TextBox runat="server" ID="txtClass" CssClass="form-control" ReadOnly="True" disabled="" />
                                </td>

                                <td style="width: 100px">
                                    <asp:DropDownList runat="server" ID="ddlEdition" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                                </td>

                                <td style="width: 95px">
                                    <asp:TextBox runat="server" ID="txtUnitPrice" CssClass="form-control" ReadOnly="True" disabled="" />
                                </td>
                                <td style="width: 95px">
                                    <asp:TextBox runat="server" ID="txtAdjustmentQty" CssClass="form-control" />
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-primary newReturnAdd" Text="Add" OnClick="btnAdd_OnClick" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <hr style="border: 1px solid silver" />
                    <%-- <div class="clearfix table-responsive">
                            <asp:GridView ID="gvwChlNew" runat="server" AutoGenerateColumns="False" CssClass="table">
                                <Columns>
                                    <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" DataField="Serial" />
                                    <%--<asp:BoundField HeaderStyle-Width="100px" HeaderText="Book AC Code" DataField="BookAcCode" />--%>
                    <%--<asp:BoundField HeaderStyle-Width="100px" HeaderText="Book Code" DataField="BookID"/>
                                    <asp:BoundField HeaderStyle-Width="200px" HeaderText="Book Name" DataField="BookName" />
                                    <asp:BoundField HeaderStyle-Width="100px" HeaderText="Class" DataField="Class" />
                                    <asp:BoundField HeaderStyle-Width="100px" HeaderText="Type" DataField="Type" />
                                    <asp:BoundField HeaderStyle-Width="100px" HeaderText="Edition" DataField="Edition" />--%>
                                    <%--<asp:BoundField HeaderStyle-Width="100px" HeaderText="UnitPrice" DataField="UnitPrice" />--%>
                                    <%--<asp:TemplateField HeaderText="UnitPrice" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                              <asp:TextBox ID="UnitPrice" runat="server" Text='<%# Eval("UnitPrice")%>' CssClass="form-control calc"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField> 

                                    <asp:TemplateField HeaderText="Qty" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                              <asp:TextBox ID="Qty" runat="server" Text='<%# Eval("Qty")%>' CssClass="form-control qcal"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    
                                    <%--<asp:BoundField HeaderStyle-Width="100px" HeaderText="Qty" DataField="Qty" />--%>
                                    <%--<asp:BoundField HeaderStyle-Width="120px" HeaderText="Amount" DataField="Total"/>--%>
                                    <%--<asp:TemplateField HeaderText="Amount" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                              <asp:TextBox ID="Total" runat="server" Text='<%# Eval("Total")%>' CssClass="form-control calc-total"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                   <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("Serial") %>' OnClick="lblDelete_OnClick">
                                                 Delete
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                </Columns>
                            </asp:GridView>--%>
                                    <%--</div>--%>

                    <div class="col-md-12  no-padding ">
                            <div class="clearfix table-responsive">
                                <asp:GridView ID="gvwReturn" runat="server" AutoGenerateColumns="False" CssClass="table">
                                    <Columns>
                                        <asp:BoundField HeaderStyle-Width="50px" HeaderText="Serial" DataField="Serial" />
                                        <asp:BoundField HeaderStyle-Width="150px" HeaderText="Book Code" DataField="BookID" />
                                        <asp:BoundField HeaderStyle-Width="200px" HeaderText="Book Name" DataField="BookName" />
                                        <asp:BoundField HeaderStyle-Width="100px" HeaderText="Type" DataField="Type" />
                                        <asp:BoundField HeaderStyle-Width="100px" HeaderText="Class" DataField="Class" />
                                        <asp:BoundField HeaderStyle-Width="100px" HeaderText="Edition" DataField="Edition" />
                                        <asp:TemplateField HeaderText="UnitPrice" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                 <asp:TextBox ID="UnitPrice" runat="server" Text='<%# Eval("UnitPrice")%>' CssClass="click pl-rate" data-field="pl-rate" ></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField> 

                                        <asp:TemplateField HeaderText="Qty" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="Qty" runat="server" Text='<%# Eval("Qty")%>' CssClass="click pl-qty" data-field="pl-qty"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField HeaderStyle-Width="100px" HeaderText="Price" DataField="UnitPrice" />--%>
                                        <%--<asp:BoundField HeaderStyle-Width="90px" HeaderText=" Quantity " DataField="Qty" />--%>
                                        <%--<asp:BoundField HeaderStyle-Width="120px" HeaderText="Amount" DataField="Total" />--%>
<%--                                        <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                 <asp:TextBox ID="Total" runat="server" Text='<%# Eval("Total")%>' CssClass="row-total"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:TextBox ID="Total" CssClass="row-total" Text='<%# Eval("Total")%>' runat="server" Width="70px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblDelete" OnClick="lblDelete_OnClick" runat="server" CommandArgument='<%#Eval("Serial") %>'>
                                                                           Delete
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                           </div>
                     </div>

                <hr style="border: 1px solid silver" />
                </div>
                <div class="col-md-12 clearfix no-padding">
                    <div class="panel-body">
                        <div class="col-md-6 clearfix">
                        </div>
                        <div class="col-md-6 clearfix">
                            <asp:UpdatePanel ID="upPayment" runat="server">
                                <ContentTemplate>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtTotalAmount" CssClass="col-md-4 control-label no-padding-right" Text="Total Amount"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" ID="txtTotalAmount" CssClass="form-control" data-tot="tot-amount" />
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="form-group">
                                <%--<div class="col-md-8 col-md-offset-4">                                   
                                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" Text="Save Adjustment"   OnClientClick="if (!confirm('Do You Want to Save Adjustment?')) return false;" OnClick="btnCancel_Click"/>
                                </div>--%>
                                <div class="col-md-8 col-md-offset-4">
                                    <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-danger" runat="server"  OnClick="btnPrint_Click"/>
                                    <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_OnClick" OnClientClick="if (!confirm('Do You Want to Save Adjustment?')) return false;"  />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12 clearfix no-padding">
                    <div class="panel">
                        <div class="panel-body">
                            <div class="col-md-6 clearfix">
                            </div>
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
             $(".click").on("keyup", function () {
                 tr = $(this).closest('tr');
                 plrate = tr.find('input[data-field=pl-rate]').val();
                 plqty = tr.find('input[data-field=pl-qty]').val();
                 //prorate = tr.find('input[data-field=pro-rate]').val();
                 tot = tr.find('input.row-total');
                 //tot.val(((plqty * plrate) + (plqty * prorate)).toFixed(2));
                 tot.val(((plqty * plrate)).toFixed(2));
                 var totsum = 0, totplq = 0, totplb = 0, totprob = 0;
                 $('input.row-total').each(function () {
                     totsum += parseFloat(this.value);
                 });
                 $('input[data-field=pl-qty]').each(function () {
                     totplq += parseFloat((this.value == '') ? '0' : this.value);
                     v = $(this).closest('tr').find('input[data-field=pl-rate]').val();
                     totplb += parseFloat((this.value == '') ? '0' : this.value) * parseFloat(v == '' ? '0' : v);
                 });


                 $('input[data-tot=tot-plq]').val(totplq.toFixed(2));
                 $('input[data-tot=tot-plb]').val(totplb.toFixed(2));
                 $('input[data-tot=tot-amount]').val(totsum.toFixed(2));
                
             });

         });
    </script>
         <%--<script type="text/javascript">
             $(document).ready(function () {

                 calculateMul(".calc", ".qcal", ".calc-total");

                 $(".calc").on("keyup", function () {
                     calculateMul(".calc", ".qcal", ".calc-total");
                 });

                 $(".qcal").on("keyup", function () {
                     calculateMul(".calc", ".qcal", ".calc-total");
                 });

                 open_menu("Speciman");
             });



             //more field summation with textchange
             function calculateMul(calc, qcal, total) {
                 var calc;
                 var qcal;
                 var mul = 1;
                 $(calc).each(function () {
                     if (!isNaN(this.value) && this.value.length != 0) {
                         calc = parseFloat(this.value);
                     }

                 });
                 $(qcal).each(function () {
                     if (!isNaN(this.value) && this.value.length != 0) {
                         qcal = parseFloat(this.value);
                     }

                 });

                 mul = calc * qcal;
                 //$(total).val(mul);
             }
        </script>--%>
        <%--<script type="text/javascript">
            $(document).ready(function () {

                calculateTot(".row-total", ".tot-amount");

                $(".row-total").on("keyup", function () {
                    calculateTot(".row-total", ".tot-amount");
                });


                open_menu("Speciman");
            });

            //more field summation with textchange
            function calculateTot(field, total) {
                var sum = 0;

                $(field).each(function () {
                    //add only if the value is number
                    if (!isNaN(this.value) && this.value.length != 0) {
                        sum += parseFloat(this.value);
                    }
                });
                $(total).val(sum.toFixed(0));

            }
    </script>--%>

    <script>
        $(document).ready(function () {
            open_menu("Speciman");
        });
    </script>
</asp:Content>
