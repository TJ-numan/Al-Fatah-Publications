<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmEmployeeSalary.aspx.cs" Inherits="BLL.HrmEmployeeSalary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
       <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Employee Salary
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlEmployee" runat="server" CssClass="control-label col-md-2 no-padding-right">Employee</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlEmployee" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlPayGrade" runat="server" CssClass="control-label col-md-2 no-padding-right">Pay Grade</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlPayGrade" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlPayGrade_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlPayScale" runat="server" CssClass="control-label col-md-2 no-padding-right">Pay Scale</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlPayScale" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlPayScale_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtEmpProvidentFund" runat="server" CssClass="control-label col-md-2 no-padding-right">Employee PF</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtEmpProvidentFund" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" style="display :none;">
                        <asp:Label AssociatedControlID="txtCompanyCost" runat="server" CssClass="control-label col-md-2 no-padding-right">Company Cost</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtCompanyCost" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" style="display :none;">
                        <asp:Label AssociatedControlID="txtDeductionAmt" runat="server" CssClass="control-label col-md-2 no-padding-right">Deduction Amt</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtDeductionAmt" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPayableAmt" runat="server" CssClass="control-label col-md-2 no-padding-right">Payable Amt</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtPayableAmt" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtComments" runat="server" CssClass="control-label col-md-2 no-padding-right">Comments</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtComments" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                     <div class="table-responsive table-bordered clearfix ">
                        <asp:GridView ID="gvEmpSalaryDetail" CssClass="table " runat="server" AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                       
                                        <asp:BoundField DataField="PayHId" HeaderText="ID" />
                                        <asp:BoundField DataField="PayHead" HeaderText="Pay Head" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount"/>
                                        <asp:BoundField DataField="ExcludeGross" HeaderText="Gross Excluded" /> 
                                    </Columns>
                                </asp:GridView> 
                            </div>

                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-2">
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" onClick="btnSave_Click"/>
                            <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" />
                        </div>
                    </div>
                    <div class="row">
 
                        <div class="panel-body">
                            <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                             <asp:GridView ID="gvEmpSalary" CssClass="table " runat="server" AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />


                                        <asp:BoundField DataField="SalId" HeaderText="ID" />
                                        <asp:BoundField DataField="IDNo" HeaderText="Employee ID" />
                                        <asp:BoundField DataField="EmpName" HeaderText="Employee Name"/>
                                        <asp:BoundField DataField="NickName" HeaderText="NickName" />
                                        <asp:BoundField DataField="DepName" HeaderText="DepName" />
                                        <asp:BoundField DataField="DesName" HeaderText="DesName" /> 
                                       
                                        <asp:BoundField DataField="PayGrName" HeaderText="PayGrName" />
                                        <asp:BoundField DataField="PayGrDes" HeaderText="PayGrDes" />
                                        <asp:BoundField DataField="EPF" HeaderText="EPF" />
                                        <asp:BoundField DataField="CompanyCost" HeaderText="CompanyCost"/>
                                        <asp:BoundField DataField="DeductionAmt" HeaderText="DeductionAmt" />
                                        <asp:BoundField DataField="PayableAmt" HeaderText="PayableAmt" />
                                        <asp:BoundField DataField="Basic Salary" HeaderText="Basic Salary" />
                                        <asp:BoundField DataField="House Rent" HeaderText="House Rent" />
                                        <asp:BoundField DataField="Medical Allowance" HeaderText="Medical Allowance" />
                                        <asp:BoundField DataField="Conveyance" HeaderText="Conveyance" />   
                                        <asp:BoundField DataField="TotalSalary" HeaderText="TotalSalary" />
                                        <asp:BoundField DataField="Entertainment" HeaderText="Entertainment" />                                        
                                        <asp:BoundField DataField="PayableAmount" HeaderText="PayableAmount" />                                          
                                        <asp:BoundField DataField="Comments" HeaderText="Comments" />                                                                                                                                                          	 										
					 

                                    </Columns>
                                </asp:GridView> 
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
    	            $(function () {
    	                $('[id*=gvwDependents]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
    	                    "responsive": true,
    	                    "sPaginationType": "full_numbers"
    	                });
    	            });
    </script>

    <script type="text/javascript">
            $(document).ready(function () {
                open_menu("PIMS");
            });
    </script>


</asp:Content>
