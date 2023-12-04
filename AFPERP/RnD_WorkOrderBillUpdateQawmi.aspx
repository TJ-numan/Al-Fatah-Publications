<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="RnD_WorkOrderBillUpdateQawmi.aspx.cs" Inherits="BLL.RnD_WorkOrderBillUpdateQawmi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
<div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Qawmi Work Order Bill Update
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtEmpName" Text="Order No/ Employee Name" CssClass="col-md-3 control-label" runat="server" Visible="true"></asp:Label>
                            <div class="col-md-5">  
                                 <asp:TextBox CssClass="form-control" ID="txtEmpName" placeholder="Search by Order No or Employee Name" runat="server" AutoPostBack="True" OnTextChanged="txtEmpName_TextChanged"/>
                            </div>
                    </div>
                    <%-- Update Pannel Start --%>
                    <div class="panel-body" >
                        <div class="table-responsive table-bordered clearfix " ID="UpdatePanel" runat="server" visible="false">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="TxtBillNo" Text="Bill No" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control" ID="TxtBillNo" runat="server" ReadOnly="True" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="WorkOrderDetID" Text="Work ID" CssClass="col-md-3 control-label" runat="server" Visible="false" ></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control" ID="WorkOrderDetID" runat="server" ReadOnly="True" Visible="false" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlEmployeeName" CssClass="col-md-3 control-label" Text="Name" runat="server"></asp:Label>
                                <div class="col-md-7">  
                                   <asp:TextBox CssClass="form-control" ID="ddlEmployeeName" runat="server" Readonly="true"/>
                                </div>
                            </div> 
                            <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlSubject" CssClass="col-md-3 control-label" Text="Subject" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:TextBox CssClass="form-control" ID="ddlSubject" runat="server" Readonly="true"/>
                                    </div>
                            </div>
                            <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlTask" CssClass="col-md-3 control-label" Text="Task" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:TextBox CssClass="form-control" ID="ddlTask" runat="server" Readonly="true"/>
                                    </div>
                            </div>
                            <div class="form-group">
                                 <asp:Label AssociatedControlID="txtDDate" CssClass="col-md-3 control-label" Text="DD" runat="server"></asp:Label>
                                 <div class="col-md-7">
                                      <asp:TextBox CssClass="form-control date" ID="txtDDate" placeholder="yyyy-MM-dd" runat="server" />
                                      <ajaxToolkit:CalendarExtender TargetControlID="txtDDate" Format="yyyy-MM-dd" runat="server" />
                                 </div>
                           </div>                
                        </div>
                        <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtTotalPage" CssClass="col-md-3 control-label" Text="Total Page" runat="server"></asp:Label>
                                     <div class="col-md-7">  
                                        <asp:TextBox CssClass="form-control" ID="txtTotalPage" runat="server" ReadOnly="true"/>
                                     </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtTotalDelivery" ID="lblTotalDelivery"  CssClass="col-md-3 control-label" Text="Delivery Qty" runat="server"></asp:Label>
                                    <div class="col-md-7">     
                                        <asp:TextBox CssClass="form-control" ID="txtTotalDelivery" placeholder="Ex. 3" runat="server" AutoPostBack="True" OnTextChanged="txtQtyChange_TextChanged"/>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtRate" ID="lblRate" CssClass="col-md-3 control-label" Text="Rate" runat="server" Visible="false"></asp:Label>
                                    <div class="col-md-7"> 
                                        <asp:TextBox CssClass="form-control" ID="txtRate" placeholder="Ex. 5000" runat="server" AutoPostBack="True" OnTextChanged="txtQtyChange_TextChanged" Visible="false"/>
                                    </div>
                               </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtTotalAmount" ID="lblTotalAmount" CssClass="col-md-3 control-label" Text="Total Amount" runat="server" Visible="false"></asp:Label>
                                    <div class="col-md-7"> 
                                        <asp:TextBox CssClass="form-control" ID="txtTotalAmount" placeholder="Ex. 5000" runat="server" FormatString="{0:0.00}" Visible="false"/>
                                    </div>
                               </div>
                                <div class="form-group">
                                    <div class="col-md-10 col-md-offset-0">
                                        <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-success pull-right" runat="server" OnClick="btnUpdate_OnClick" />
                                    </div>
                                </div>
                         </div>
                        </div>
                    </div>
                   <%-- Update Pannel End --%>
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
                                    <asp:BoundField DataField="Rate" HeaderText="Rate" visible="false"/>
                                    <asp:BoundField DataField="Total" HeaderText="Total Amount" DataFormatString="{0:0.00}" Visible="false"/>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:TextBox ID="btnStatus"  text='<%#Eval("IsBillPay") %>' runat="server" CssClass="form-control" CommandArgument='<%#Eval("WorkOrderDetID") %>'  Width="80px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField SelectText="Edit" ShowSelectButton="true" Visible="true" ItemStyle-CssClass="btn btn-compose" HeaderStyle-CssClass="HiddenColumn" ButtonType="button"/>
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