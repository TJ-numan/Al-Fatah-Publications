<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="RnDWorkOrderBillPrintQawmi.aspx.cs" Inherits="BLL.RnDWorkOrderBillPrintQawmi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
<div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Qawmi Work Order Bill Print
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtEmpName" Text="Order No/ Employee Name" CssClass="col-md-3 control-label" runat="server" Visible="true"></asp:Label>
                            <div class="col-md-5">  
                                 <asp:TextBox CssClass="form-control" ID="txtEmpName" placeholder="Search by Order No or Employee Name" runat="server" AutoPostBack="True" OnTextChanged="txtEmpName_TextChanged"/>
                            </div>
                    </div>
                    <div class="panel-body">
                        <div class="table-responsive table-bordered clearfix ">
                            <asp:GridView ID="gvDateWiseWorkOrderDetails" CssClass="table " runat="server" AutoGenerateColumns="false" OnRowDataBound="gvDateWiseWorkDetails_RowDataBound" OnSelectedIndexChanged="gvDateWiseWorkDetails_SelectedIndexChanged">
                                <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                <Columns>
                                    <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn" HeaderStyle-CssClass="HiddenColumn" visible="false"/>
                                    <asp:BoundField DataField="WorkOrderID" HeaderText="Order No"/>
                                    <asp:BoundField DataField="WorkOrderDetID" HeaderText="Details ID" />
                                    <asp:BoundField DataField="BillNo" HeaderText="Bill No" />
                                    <asp:BoundField DataField="WorkIssueDate" HeaderText="Issue Date" DataFormatString="{0:dd/MM/yyyy}"/>
                                    <asp:BoundField DataField="IsHired" HeaderText="Employee For"/>
                                    <asp:BoundField DataField="SectionName" HeaderText="Section"/>
                                    <asp:BoundField DataField="EmployeeID" HeaderText="Name"/>
                                    <asp:BoundField DataField="BookID" HeaderText="Book"/>
                                    <asp:BoundField DataField="ClassName" HeaderText="Class"/>
                                    <asp:BoundField DataField="WorkTypeID" HeaderText="Work Type"/>
                                    <asp:BoundField DataField="DD" HeaderText="Delivery Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="TotalPage" HeaderText="Total Page" />
                                    <asp:BoundField DataField="TotalDelivery" HeaderText="Delivery Qty" />
                                    <asp:BoundField DataField="Rate" HeaderText="Rate" />
                                    <asp:BoundField DataField="Total" HeaderText="Total Amount" DataFormatString="{0:0.00}"/> 
                                    <asp:CommandField SelectText="Print" ShowSelectButton="true" Visible="true" ItemStyle-CssClass="btn btn-compose" HeaderStyle-CssClass="HiddenColumn" ButtonType="button"/>
                                </Columns>
                                <SelectedRowStyle BackColor="#393737" Font-Bold="true" ForeColor="#F7F7F7" />


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
            open_menu("Work Order Qawmi");
        });
    </script>
</asp:Content>
