<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="RndWorkOrderBillGenerateGraphics.aspx.cs" Inherits="BLL.RndWorkOrderBillGenerateGraphics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
<div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Graphics Work Order Bill Generate
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtWorkOrder" CssClass="col-md-4 control-label" Text="Order No/ Employee Name" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox CssClass="form-control" ID="txtWorkOrder" placeholder="Order No or Employee Name" runat="server" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="btnShow" CssClass="col-md-4 control-label" Text="" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:Button ID="btnShow" Text="Show"  CssClass="btn btn-info" runat="server" OnClick="btnShow_Click" />

                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="table-responsive table-bordered clearfix ">
                            <asp:GridView ID="gvWorkOderDetails" CssClass="table " runat="server" AutoGenerateColumns="false" OnRowDataBound="gvWorkOderDetails_RowDataBound" OnSelectedIndexChanged="gvWorkOderDetails_SelectedIndexChanged">
                                <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                <Columns>
                                    <asp:TemplateField>
                                         <ItemTemplate>
                                              <asp:CheckBox ID="chkWorkOrderSelect" runat="server" AutoPostBack="true" OnCheckedChanged="chkWorkOrderSelect_CheckedChanged" />
                                         </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="WorkOrderID" HeaderText="Order No"/>
                                    <asp:BoundField DataField="WorkOrderDetID" HeaderText="Details ID" />
                                    <asp:BoundField DataField="WorkIssueDate" HeaderText="Issue Date" DataFormatString="{0:dd/MM/yyyy}"/>
                                    <asp:BoundField DataField="IsHired" HeaderText="Employee For"/>
                                    <asp:BoundField DataField="SectionName" HeaderText="Section"/>
                                    <asp:BoundField DataField="EmployeeID" HeaderText="Name"/>
                                    <asp:BoundField DataField="BookID" HeaderText="Book"/>
                                    <asp:BoundField DataField="ClassName" HeaderText="Class"/>
                                    <asp:BoundField DataField="WorkTypeID" HeaderText="Work Type"/>
                                    <asp:BoundField DataField="EDD" HeaderText="EDD" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="TotalUnit" HeaderText="Total Unit" />
                                    <asp:BoundField DataField="TotalDelivery" HeaderText="Total Delivery" />
                                    <asp:BoundField DataField="TransferedQty" HeaderText="Transferred Unit" />
                                    <asp:BoundField DataField="DueQty" HeaderText="Due Unit"/>
                                    <asp:TemplateField HeaderText="Delivery Date" HeaderStyle-Width="120px">
                                           <ItemTemplate>
                                                <asp:TextBox CssClass="form-control date" ID="dtpdeliveryDate" placeholder="yyyy-mm-dd" runat="server" />
                                                <ajaxToolkit:CalendarExtender TargetControlID="dtpdeliveryDate" Format="yyyy-MM-dd" runat="server" />
                                           </ItemTemplate>
                                    </asp:TemplateField> 
                                    <asp:TemplateField HeaderText="Delivery Unit" HeaderStyle-Width="50px">
                                           <ItemTemplate>
                                                <asp:TextBox ID="txtActualDelivery" runat="server"  CssClass="click pl-rate" data-field="pl-rate" Width="80px" ></asp:TextBox>
                                           </ItemTemplate>
                                    </asp:TemplateField> 

                                    <asp:TemplateField HeaderText="Rate" HeaderStyle-Width="50px">
                                          <ItemTemplate>
                                               <asp:TextBox ID="txtRate" runat="server"  CssClass="click pl-qty" placeholder="0" data-field="pl-qty" Width="80px"></asp:TextBox>
                                          </ItemTemplate>
                                    </asp:TemplateField>      
                                    <asp:TemplateField HeaderText="Amount">
                                          <ItemTemplate>
                                              <asp:TextBox ID="txtTotal" CssClass="row-total"  runat="server" Width="80px"></asp:TextBox>
                                          </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                          <ItemTemplate>
                                              <asp:button ID="btnGenerateBill"  text='<%#Eval("IsBillGen") %>' OnClick="btnUpdate_OnClick" runat="server" CommandArgument='<%#Eval("WorkOrderDetID") %>' CssClass="btn btn-success" Width="100px"></asp:button>
                                          </ItemTemplate>
                                    </asp:TemplateField>                                                                                                             
                                </Columns>
                            </asp:GridView>
                        </div>
                        <br />
                    </div>                   
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSRandD" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Graphics");
        });
    </script>
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
</asp:Content>
