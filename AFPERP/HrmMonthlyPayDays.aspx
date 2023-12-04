<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmMonthlyPayDays.aspx.cs" Inherits="BLL.HrmMonthlyPayDays" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                   Monthly PayDays
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPayMonth" runat="server" CssClass="control-label col-md-2 no-padding-right">Pay Month</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtPayMonth" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlEmployee" runat="server" CssClass="control-label col-md-2 no-padding-right">Employee</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlEmployee" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPresentDay" runat="server" CssClass="control-label col-md-2 no-padding-right">Present Day</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtPresentDay" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtLeaveDay" runat="server" CssClass="control-label col-md-2 no-padding-right">Leave Day</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtLeaveDay" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtLeaveWithoutPay" runat="server" CssClass="control-label col-md-2 no-padding-right">Leave Without Pay</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtLeaveWithoutPay" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtWeekend" runat="server" CssClass="control-label col-md-2 no-padding-right">Weekend</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtWeekend" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>


                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtHoliday" runat="server" CssClass="control-label col-md-2 no-padding-right">Holiday</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtHoliday" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPayDay" runat="server" CssClass="control-label col-md-2 no-padding-right">PayDay</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtPayDay" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                   


                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-2">
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" />
                            <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-10 col-md-offset-1">
                                <div class="search-input">
                                    <i class="icon-search"></i>
                                    <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" Placeholder="Search" />
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                                <%--                                <asp:GridView ID="gvwDependents" CssClass="table " runat="server" AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />
                                        <asp:BoundField DataField="DepenId" HeaderText="ID" />
                                        <asp:BoundField DataField="DepenName" HeaderText="Dependent Name" />
                                        <asp:BoundField DataField="EmpName" HeaderText="Employee Name"/>
                                        <asp:BoundField DataField="Relation" HeaderText="Relation" />
                                        <asp:BoundField DataField="DoB" HeaderText="Date of Birth" />
                                        <asp:BoundField DataField="CertificateNo" HeaderText="Certificate No" />
                                        <asp:BoundField DataField="InfStatus" HeaderText="Info Status" />
                                    </Columns>
                                </asp:GridView>--%>
                            </div>
                            <br />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSHR" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Attendance");
        });
    </script>
</asp:Content>
