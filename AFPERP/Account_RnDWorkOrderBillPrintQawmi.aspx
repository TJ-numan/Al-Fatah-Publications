<%@ Page Title="" Language="C#" MasterPageFile="~/AccountingMaster.master" AutoEventWireup="true" CodeBehind="Account_RnDWorkOrderBillPrintQawmi.aspx.cs" Inherits="BLL.Account_RnDWorkOrderBillPrintQawmi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AccountingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Work Order Bill Print Qawmi
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
                            <asp:Button ID="btnPrint" Text="Bill Print" CssClass="btn btn-info" runat="server" OnClick="btnPrint_OnClick" />
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
                                    <asp:BoundField DataField="ActualDelivery" HeaderText="Forma/Char Qty" />
                                    <asp:BoundField DataField="Rate" HeaderText="Rate" />
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:0.00}"/>
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
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSAcc" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Reports", "RnD Work");
        });
    </script>
</asp:Content>
