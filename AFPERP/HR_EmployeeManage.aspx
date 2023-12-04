<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HR_EmployeeManage.aspx.cs" Inherits="BLL.HR_EmployeeManage" %>

<%@ Import Namespace="BLL" %>
<%@ Import Namespace="Common.HR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <link rel="stylesheet" type="text/css" href="assets/bootstrap-fileupload/bootstrap-fileupload.css" />
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-reset.css" rel="stylesheet" />
    <!--external css-->
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="assets/fancybox/source/jquery.fancybox.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="css/gallery.css" />
    <!-- Custom styles for this template -->
    <link href="css/style.css" rel="stylesheet">
    <link href="css/style-responsive.css" rel="stylesheet" />
    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">--%>

    <div class="form-horizontal clearfix" runat="server">
        <section class="panel">
            <header class="panel-heading tab-bg-dark-navy-blue ">
                <ul class="nav nav-tabs">
                    <li class="active">
                        <a data-toggle="tab" href="#List">Employee List</a>
                    </li>
                    <li class="">
                        <a data-toggle="tab" href="#Add">Add New Employee</a>
                    </li>
                </ul>
            </header>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-success">
                        <div class="panel-body">
                            <div class="tab-content">
                                <div id="List" class="tab-pane fade in active">
                                    <% 
                                        List<EmployeeInformation> employees = Li_EmployeeManager.GetAllEmployee();
                                    %>
                                    <table class="table table-bordered" id="empTable">
                                        <thead>
                                            <tr class="danger">
                                                <th>Name</th>
                                                <th>Department</th>
                                                <th>Designation</th>
                                                <th>Contact</th>
                                                <th>Joining Date</th>
                                                <th>Status</th>
                                                <th>Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <%
                                                foreach (var liEmployee in employees)
                                                {%>
                                            <tr>
                                                <td><%=liEmployee.EmployeeName %></td>
                                                <td><%=liEmployee.DepartmentName %></td>
                                                <td><%= liEmployee.Designation %></td>
                                                <td><%= liEmployee.ContactNo %></td>
                                                <td><%= liEmployee.JoiningDate %></td>

                                                <%
                                                   
                                                    if (liEmployee.EmpStatus == 1)
                                                    {%>
                                                <td><span style="color: green">Active</span></td>
                                                <%}
                                                    else
                                                    {%>
                                                <td><span style="color: red">Inactive</span></td>
                                                <%}
                                                    
                                                     
                                                %>
                                                <td>
                                                    <a href="EditEmployee.aspx?employeeId=<%=liEmployee.EmployeID %>" class="btn btn-default">Edit</a>
                                                </td>
                                            </tr>
                                            <%}
                                            %>
                                        </tbody>
                                        <tfoot>
                                            <tr class="danger">
                                                <th>Name</th>
                                                <th>Department</th>
                                                <th>Designation</th>
                                                <th>Contact</th>
                                                <th>Joining Date</th>
                                                <th>Status</th>
                                                <th>Action</th>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </div>
                                <div id="Add" class="tab-pane fade">

                                    <%--form strat--%>
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="txtEmpId" runat="server" CssClass="control-label col-md-4 no-padding-right">Employee ID:</asp:Label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtEmpId" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:RequiredFieldValidator ControlToValidate="txtEmpId" Display="Dynamic" ForeColor="Red" ErrorMessage="Please enter Employee Id!" runat="Server" ID="RVfortxtEmpId" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="txtName" runat="server" CssClass="control-label col-md-4 no-padding-right">Employee Name:</asp:Label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtName" ErrorMessage="Please enter employee name!" ForeColor="Red" ID="RVforName" />
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="txtPresentAddress" runat="server" CssClass="control-label col-md-4 no-padding-right">Present Address:</asp:Label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtPresentAddress" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtPresentAddress" ErrorMessage="Please enter Present Address!" ForeColor="Red" ID="RVforPresentAddress" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="txtPermanentAddress" runat="server" CssClass="control-label col-md-4 no-padding-right">Permanent Address:</asp:Label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtPermanentAddress" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtPresentAddress" ErrorMessage="Please enter Present Address!" ForeColor="Red" ID="RequiredFieldValidator1" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="ddlDesignation" runat="server" CssClass="control-label col-md-4 no-padding-right">Designation:</asp:Label>
                                            <div class="col-md-4">
                                                <asp:DropDownList runat="server" ID="ddlDesignation" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddlDesignation" ErrorMessage="Please select designation!" InitialValue="0" ForeColor="Red" ID="RVforDesignation" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="ddlDepartment" runat="server" CssClass="control-label col-md-4 no-padding-right">Department:</asp:Label>
                                            <div class="col-md-4">
                                                <asp:DropDownList CssClass="form-control" ID="ddlDepartment" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddlDepartment" ErrorMessage="Please select Department!" InitialValue="0" ForeColor="Red" ID="RVforDepartment" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="txtMobNo" runat="server" CssClass="control-label col-md-4 no-padding-right" ID="msg">Mobile No:</asp:Label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtMobNo" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtMobNo" ErrorMessage="Please enter Mobile No!" ForeColor="Red" ID="RVforMobileNo" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="ddlBloodGroup" runat="server" CssClass="control-label col-md-4 no-padding-right">Blood Group:</asp:Label>
                                            <div class="col-md-4">
                                                <asp:DropDownList CssClass="form-control" ID="ddlBloodGroup" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddlBloodGroup" ErrorMessage="Please select Blood Group!" InitialValue="0" ForeColor="Red" ID="RVforBloodGroup" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="txtPhoneNo" runat="server" CssClass="control-label col-md-4 no-padding-right">Phone No:</asp:Label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtPhoneNo" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="txtEmail" runat="server" CssClass="control-label col-md-4 no-padding-right">Email:</asp:Label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>                                    
                                        <div class="form-group">
                                            <asp:Label runat="server" CssClass="control-label col-md-4 no-padding-right">Joining Date:</asp:Label>
                                            <div class="col-md-4">
                                                <asp:TextBox CssClass="form-control" ID="txtJoiningDate" placeholder="dd-MM-yyyy" runat="server" />
                                                <ajaxToolkit:CalendarExtender TargetControlID="txtJoiningDate" Format="dd-MM-yyyy" runat="server" />
                                            </div>
                                            <div class="col-md-4">
                                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtJoiningDate" ErrorMessage="Please enter Joining Date" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <asp:UpdatePanel runat="server" ID="UpdateArea1" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div class="form-group">
                                                    <asp:Label runat="server" CssClass="col-md-4 control-label no-padding-right">Section</asp:Label>
                                                    <div class="col-md-4">
                                                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlSection" />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <asp:Label runat="server" CssClass="col-md-4 control-label no-padding-right">Work Area</asp:Label>
                                                    <div class="col-md-4">
                                                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlWorkArea" AutoPostBack="True" OnSelectedIndexChanged="ddlWorkArea_SelectedIndexChanged" />
                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                    <asp:Label runat="server" CssClass="col-md-4 control-label no-padding-right">Work Place</asp:Label>
                                                    <div class="col-md-4">
                                                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlWorkPalce" />
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="form-group">
                                            <div class="col-md-4 col-md-offset-4">
                                                <asp:Button runat="server" Text="Save" CssClass="btn btn-success" ID="btnSave" OnClick="btnSave_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    <%--form end--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSHR" runat="server">
    <!-- js placed at the end of the document so the pages load faster -->
    <script src="js/jquery.js"></script>
    <%--<script src="js/bootstrap.min.js"></script>--%>
    <script class="include" type="text/javascript" src="js/jquery.dcjqaccordion.2.7.js"></script>
    <script src="js/jquery.scrollTo.min.js"></script>
    <script src="js/jquery.nicescroll.js" type="text/javascript"></script>
    <script src="js/respond.min.js"></script>

    <!--this page plugins-->
    <script type="text/javascript" src="assets/fuelux/js/spinner.min.js"></script>
    <script type="text/javascript" src="assets/bootstrap-fileupload/bootstrap-fileupload.js"></script>
    <script type="text/javascript" src="assets/bootstrap-wysihtml5/wysihtml5-0.3.0.js"></script>
    <script type="text/javascript" src="assets/bootstrap-wysihtml5/bootstrap-wysihtml5.js"></script>
    <script type="text/javascript" src="assets/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="assets/bootstrap-datetimepicker/js/bootstrap-datetimepicker.js"></script>
    <script type="text/javascript" src="assets/bootstrap-daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="assets/bootstrap-daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="assets/bootstrap-colorpicker/js/bootstrap-colorpicker.js"></script>
    <script type="text/javascript" src="assets/bootstrap-timepicker/js/bootstrap-timepicker.js"></script>
    <script type="text/javascript" src="assets/jquery-multi-select/js/jquery.multi-select.js"></script>
    <script type="text/javascript" src="assets/jquery-multi-select/js/jquery.quicksearch.js"></script>
    <!--this page  script only-->
    <script src="js/advanced-form-components.js"></script>
    <script src="//cdn.datatables.net/1.10.11/js/jquery.dataTables.min.js"></script>
    <script src="//cdn.datatables.net/plug-ins/1.10.6/integration/bootstrap/3/dataTables.bootstrap.js"></script>
    <script>
        $(document).ready(function () {
            $('#empTable').DataTable();

        });
    </script>

</asp:Content>
