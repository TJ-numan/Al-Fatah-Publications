<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="Rnd_WorkOderBillPaymentQawmi.aspx.cs" Inherits="BLL.Rnd_WorkOderBillPaymentQawmi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
<div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Qawmi Work Order Bill Payment
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtWorkOrder" CssClass="col-md-4 control-label" Text="Bill No" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox CssClass="form-control" ID="txtWorkOrder" placeholder="Bill No" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="btnShow" CssClass="col-md-4 control-label" Text="" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:Button ID="btnShow" Text="Show Bill"  CssClass="btn btn-primary" runat="server" OnClick="btnShow_Click" />
                            <asp:Button ID="btnPrint" Text="Bill Print" CssClass="btn btn-info" Visible="false" runat="server" OnClick="btnPrint_OnClick" />
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="table-responsive table-bordered clearfix ">
                            <asp:GridView ID="gvWorkOderDetails" CssClass="table " runat="server" AutoGenerateColumns="false" OnRowDataBound="gvWorkOderDetails_RowDataBound" OnSelectedIndexChanged="gvWorkOderDetails_SelectedIndexChanged">
                                <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                <Columns>
                                    <asp:BoundField DataField="WorkOrderID" HeaderText="Order No"/>
                                    <asp:BoundField DataField="WorkOrderDetID" HeaderText="Details ID" />
                                    <asp:BoundField DataField="WorkIssueDate" HeaderText="Issue Date" DataFormatString="{0:dd/MM/yyyy}"/>
                                    <asp:BoundField DataField="IsHired" HeaderText="Employee For"/>
                                    <asp:BoundField DataField="SectionName" HeaderText="Section"/>
                                    <asp:BoundField DataField="EmployeeID" HeaderText="Name"/>
                                    <asp:BoundField DataField="BookID" HeaderText="Book"/>
                                    <asp:BoundField DataField="ClassName" HeaderText="Class"/>
                                    <asp:BoundField DataField="WorkTypeID" HeaderText="Work Type"/>
                                    <asp:BoundField DataField="DD" HeaderText="Delivery Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <%--<asp:BoundField DataField="ActualDelivery" HeaderText="Forma/Char Qty" />--%>
<%--                                    <asp:BoundField DataField="Rate" HeaderText="Rate" />
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:0.00}"/>--%>
                                    <asp:TemplateField HeaderText="Forma/Char Qty">
                                          <ItemTemplate>
                                               <asp:TextBox ID="ActualDelivery" runat="server" Text='<%# Eval("ActualDelivery")%>' CssClass="click pl-qty" data-field="pl-qty" ></asp:TextBox>
                                         </ItemTemplate>
                                    </asp:TemplateField> 

                                    <asp:TemplateField HeaderText="Rate" HeaderStyle-Width="100px">
                                         <ItemTemplate>
                                              <asp:TextBox ID="Rate" runat="server" Text='<%# Eval("Rate")%>' CssClass="click pl-rate" data-field="pl-rate"></asp:TextBox>
                                         </ItemTemplate>
                                    </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:TextBox ID="Amount" CssClass="row-total" Text='<%# Eval("Amount")%>' runat="server" Width="70px"></asp:TextBox>
                                            </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks">
                                          <ItemTemplate>
                                              <asp:TextBox ID="txRemarks" runat="server" Width="300px"></asp:TextBox>
                                          </ItemTemplate>
                                    </asp:TemplateField>
                             </Columns>
                            </asp:GridView>
                        </div>
                        <br />
                    </div>                   
                    <div class="form-group">
                        <asp:Label AssociatedControlID="btnApprove" CssClass="col-md-4 control-label" Text="" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:Button ID="btnApprove" Text="Approve"  Visible="true" CssClass="btn btn-success" runat="server" OnClientClick="if (!confirm('Do You Want to Approve this Bill?')) return false;"  OnClick="btnApprove_Click" />
                            <asp:Button ID="btnReject" Text="Reject"  Visible="true" CssClass="btn btn-danger" runat="server" OnClientClick="if (!confirm('Do You Want to Reject this Bill?')) return false;"  OnClick="btnReject_Click" />
                        </div>
                    </div>                   
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSRandD" runat="server">
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
        <script type="text/javascript">
            $(document).ready(function () {
                open_menu("Work Order Qawmi");
            });
    </script>
</asp:Content>
