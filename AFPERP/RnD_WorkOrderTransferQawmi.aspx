<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="RnD_WorkOrderTransferQawmi.aspx.cs" Inherits="BLL.RnD_WorkOrderTransferQawmi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
<div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Qawmi Work Order Transfer
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
                                <asp:Label AssociatedControlID="WorkOrderDetID" Text="Work ID" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control" ID="WorkOrderDetID" runat="server" ReadOnly="True" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlEmployeeName" CssClass="col-md-3 control-label" Text="Name" runat="server"></asp:Label>
                                <div class="col-md-7">  
                                   <asp:TextBox CssClass="form-control" ID="ddlEmployeeName" runat="server" Readonly="true"/>
                                </div>
                            </div> 
                             <div class="form-group">
                                    <asp:Label AssociatedControlID="txtTotalQty" ID="lbltxtTotalQty"  CssClass="col-md-3 control-label" Text="Total Qty" runat="server"></asp:Label>
                                    <div class="col-md-7">     
                                        <asp:TextBox CssClass="form-control" ID="txtTotalQty" placeholder="Ex. 3" runat="server" ReadOnly="true" />
                                    </div>
                             </div>   
                              <div class="form-group">
                                    <asp:Label AssociatedControlID="txtTotalDeliveryQty" ID="lbltxtTotalDeliveryQty"  CssClass="col-md-3 control-label" Text="Delivery Qty" runat="server"></asp:Label>
                                    <div class="col-md-7">     
                                        <asp:TextBox CssClass="form-control" ID="txtTotalDeliveryQty" placeholder="Ex. 3" runat="server" ReadOnly="true"/>
                                    </div>
                             </div>
                             <div class="form-group">
                                    <asp:Label AssociatedControlID="txtTotalTransferQty" ID="Label1"  CssClass="col-md-3 control-label" Text="Transferred Qty" runat="server"></asp:Label>
                                    <div class="col-md-7">     
                                        <asp:TextBox CssClass="form-control" ID="txtTotalTransferQty" placeholder="Ex. 3" runat="server" ReadOnly="true"/>
                                    </div>
                             </div>
                             <div class="form-group">
                                    <asp:Label AssociatedControlID="txtTotalDueQty" ID="lbltxtTotalDueQty"  CssClass="col-md-3 control-label" Text="Due Qty" runat="server"></asp:Label>
                                    <div class="col-md-7">     
                                        <asp:TextBox CssClass="form-control" ID="txtTotalDueQty" placeholder="Ex. 3" runat="server" ReadOnly="true"/>
                                    </div>
                             </div>                                          
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlEmplyeeFor" CssClass="col-md-3 control-label" Text="Emplyee For" runat="server"></asp:Label>
                                <div class="col-md-7">   
                                    <asp:DropDownList CssClass="form-control" ID="ddlEmplyeeFor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEmployeeFor_SelectedIndexChanged">
                                          <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                          <asp:ListItem Value="1" Text="InHouse"></asp:ListItem>
                                          <asp:ListItem Value="2" Text="OutSource"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlSection" ID="lblSection" CssClass="col-md-3 control-label" Text="Section" runat="server"></asp:Label>
                                <div class="col-md-7">  
                                   <asp:DropDownList CssClass="form-control" ID="ddlSection" runat="server" OnTextChanged="ddlSection_TextChanged" AutoPostBack="True">
                                   </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlEmpName" CssClass="col-md-3 control-label" Text="Name" runat="server"></asp:Label>
                                <div class="col-md-7">  
                                   <asp:DropDownList CssClass="form-control" ID="ddlEmpName" runat="server">
                                   </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                 <asp:Label AssociatedControlID="txtEDDate" CssClass="col-md-3 control-label" Text="EDD" runat="server"></asp:Label>
                                 <div class="col-md-7">
                                      <asp:TextBox CssClass="form-control date" ID="txtEDDate" placeholder="yyyy-MM-dd" runat="server" />
                                      <ajaxToolkit:CalendarExtender TargetControlID="txtEDDate" Format="yyyy-MM-dd" runat="server" />
                                 </div>
                           </div>  
                            <div class="form-group">
                                    <asp:Label AssociatedControlID="txtTotalTransfer" ID="lblTotalCharacter" CssClass="col-md-3 control-label" Text="Tranfer Qty" runat="server"></asp:Label>
                                    <div class="col-md-7"> 
                                        <asp:TextBox CssClass="form-control" ID="txtTotalTransfer" placeholder="Ex. 50" runat="server" />
                                    </div>
                             </div>    
                                <div class="form-group">
                                    <div class="col-md-10 col-md-offset-0">
                                        <asp:Button ID="btnTranfer" Text="Transfer Now" CssClass="btn btn-success pull-right" runat="server" OnClick="btnTranfer_OnClick" />
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
                                    <asp:BoundField DataField="WorkIssueDate" HeaderText="Issue Date" DataFormatString="{0:dd/MM/yyyy}"/>
                                    <asp:BoundField DataField="IsHired" HeaderText="Employee For"/>
                                    <asp:BoundField DataField="SectionName" HeaderText="Section"/>
                                    <asp:BoundField DataField="EmployeeID" HeaderText="Name"/>
                                    <asp:BoundField DataField="BookID" HeaderText="Book"/>
                                    <asp:BoundField DataField="ClassName" HeaderText="Class"/>
                                    <asp:BoundField DataField="WorkTypeID" HeaderText="Work Type"/>
                                    <asp:BoundField HeaderText="EDD" DataField="EDD" DataFormatString="{0:yyyy-MM-dd}"/>
                                    <asp:BoundField HeaderText="Total Page" DataField="TotalPage"/>
                                    <asp:BoundField HeaderText="Total Qty" DataField="TotalQty"/>
                                    <asp:BoundField HeaderText="Delivery Qty" DataField="TotalDelivery"/>
                                    <asp:BoundField DataField="TransferedQty" HeaderText="Transfer Qty" />
                                    <asp:BoundField HeaderText="Due Qty" DataField="DueQty"/>
                                    <asp:CommandField SelectText="Transfer" ShowSelectButton="true" Visible="true" ItemStyle-CssClass="btn btn-compose" HeaderStyle-CssClass="HiddenColumn" />
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
