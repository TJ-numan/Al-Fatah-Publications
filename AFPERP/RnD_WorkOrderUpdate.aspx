<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="RnD_WorkOrderUpdate.aspx.cs" Inherits="BLL.RnD_WorkOrderUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
<div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Update Work Order
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
                                    <asp:Label AssociatedControlID="ddlSubject" CssClass="col-md-3 control-label" Text="Subject" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:TextBox CssClass="form-control" ID="ddlSubject" runat="server" Readonly="true"/>
                                    </div>
                            </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlBookSize" CssClass="col-md-3 control-label" Text="Size" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:DropDownList CssClass="form-control" ID="ddlBookSize" runat="server"></asp:DropDownList>
                                    </div>
                            </div>
                            <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlTask" CssClass="col-md-3 control-label" Text="Task" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:DropDownList CssClass="form-control" ID="ddlTask" runat="server">
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
                        </div>
                        <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtFromPage" CssClass="col-md-3 control-label" Text="From Page" runat="server"></asp:Label>
                                    <div class="col-md-7">  
                                        <asp:TextBox CssClass="form-control" ID="txtFromPage" placeholder="Ex. 10" runat="server" AutoPostBack="True" OnTextChanged="txtTopage_TextChanged"/>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtToPage" CssClass="col-md-3 control-label" Text="To Page" runat="server"></asp:Label>
                                     <div class="col-md-7">  
                                        <asp:TextBox CssClass="form-control" ID="txtToPage" placeholder="Ex. 50" runat="server" AutoPostBack="True" OnTextChanged="txtTopage_TextChanged"/>
                                     </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtTotalPage" CssClass="col-md-3 control-label" Text="Total Page" runat="server"></asp:Label>
                                     <div class="col-md-7">  
                                        <asp:TextBox CssClass="form-control" ID="txtTotalPage" runat="server"/>
                                     </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtTotalForma" ID="lblTotalForma"  CssClass="col-md-3 control-label" Text="Total Forma" runat="server"></asp:Label>
                                    <div class="col-md-7">     
                                        <asp:TextBox CssClass="form-control" ID="txtTotalForma" placeholder="Ex. 3" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtTotalCharacter" ID="lblTotalCharacter" CssClass="col-md-3 control-label" Text="Total Character" runat="server"></asp:Label>
                                    <div class="col-md-7"> 
                                        <asp:TextBox CssClass="form-control" ID="txtTotalCharacter" placeholder="Ex. 5000" runat="server" />
                                    </div>
                               </div>
                                <div class="form-group">
                                    <div class="col-md-11 col-md-offset-0">
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
                                    <asp:BoundField DataField="WorkIssueDate" HeaderText="Issue Date" DataFormatString="{0:dd/MM/yyyy}"/>
                                    <asp:BoundField DataField="IsHired" HeaderText="Employee For"/>
                                    <asp:BoundField DataField="SectionName" HeaderText="Section"/>
                                    <asp:BoundField DataField="EmployeeID" HeaderText="Name"/>
                                    <asp:BoundField DataField="BookID" HeaderText="Book"/>
                                    <asp:BoundField DataField="ClassName" HeaderText="Class"/>
                                    <asp:BoundField DataField="WorkTypeID" HeaderText="Work Type"/>
                                    <asp:BoundField HeaderText="EDD" DataField="EDD" DataFormatString="{0:yyyy-MM-dd}"/>
                                    <asp:BoundField HeaderText="From Page" DataField="PageStart"/>
                                    <asp:BoundField HeaderText="To Page" DataField="PageEnd"/>
                                    <asp:BoundField HeaderText="Total Page" DataField="TotalPage"/>
                                    <asp:BoundField HeaderText="Total Forma" DataField="TotalForma"/>
                                    <asp:BoundField HeaderText="Total Char" DataField="TotalCharacter"/>
                                    <asp:CommandField SelectText="Edit" ShowSelectButton="true" Visible="true" ItemStyle-CssClass="btn btn-compose" HeaderStyle-CssClass="HiddenColumn" />
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
            open_menu("Work Order Alia");
        });
    </script>
</asp:Content>
