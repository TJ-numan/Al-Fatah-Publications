<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmEmployment.aspx.cs" Inherits="BLL.HrmEmployment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
      <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Employment
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
                            <asp:Label AssociatedControlID="txtCompanyName" runat="server" CssClass="control-label col-md-2 no-padding-right">Company Name</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtCompanyName" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtCompanyBusiness" runat="server" CssClass="control-label col-md-2 no-padding-right">Company Business</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtCompanyBusiness" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtDesignation" runat="server" CssClass="control-label col-md-2 no-padding-right">Designation</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtDesignation" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtDepartment" runat="server" CssClass="control-label col-md-2 no-padding-right">Department</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtDepartment" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtResponsibilities" runat="server" CssClass="control-label col-md-2 no-padding-right">Responsibilities</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtResponsibilities" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtCompLocation" runat="server" CssClass="control-label col-md-2 no-padding-right">Company Location</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtCompLocation" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtJobPeriod" runat="server" CssClass="control-label col-md-2 no-padding-right">Job Period</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtJobPeriod" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="chkIsCurWorking" runat="server" CssClass="control-label col-md-2 no-padding-right">Is Current Working</asp:Label>
                            <div class="col-md-4">
                                <asp:CheckBox ID="chkIsCurWorking" CssClass="form-control" runat="server"></asp:CheckBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtAreaOfExperience" runat="server" CssClass="control-label col-md-2 no-padding-right">AreaOfExperience</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtAreaOfExperience" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>


                        <div class="form-group">
                            <div class="col-md-4 col-md-offset-2">
                                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click"/>
                                <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" />
                            </div>
                        </div>
                    
                    <div class="row">
 
                        <div class="panel-body">
                            <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                               <asp:GridView ID="gvEmployment" CssClass="table " runat="server" AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />

                                        <asp:BoundField DataField="ExperId" HeaderText="ID" />
                                        <asp:BoundField DataField="IDNo" HeaderText="Employee ID" />
                                        <asp:BoundField DataField="EmpName" HeaderText="Employee Name"/>
                                        <asp:BoundField DataField="NickName" HeaderText="NickName" />
                                        <asp:BoundField DataField="DepName" HeaderText="Department" />
                                        <asp:BoundField DataField="DesName" HeaderText="Designation" />
                                        <asp:BoundField DataField="CompName" HeaderText="Previous Company" />

                                        <asp:BoundField DataField="CompBusiness" HeaderText="CompBusiness"/>
                                        <asp:BoundField DataField="Designation" HeaderText="Designation" />
                                        <asp:BoundField DataField="Department" HeaderText="Department" />
                                        <asp:BoundField DataField="Responsibilities" HeaderText="Responsibilities" />
                                        <asp:BoundField DataField="ComLocation" HeaderText="ComLocation" />
                                        						 							
                                        <asp:BoundField DataField="EmployPeriod" HeaderText="EmployPeriod" />
                                        <asp:BoundField DataField="IsCurrentlyWorking" HeaderText="IsCurrentlyWorking" />
                                        <asp:BoundField DataField="AreaOfExperi" HeaderText="AreaOfExperi" />						 				
						 			
 

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
        $('[id*=gvEmployment]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
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
