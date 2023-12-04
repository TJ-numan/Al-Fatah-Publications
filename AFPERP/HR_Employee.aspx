<%@ Page Title="HR Employee" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HR_Employee.aspx.cs" Inherits="BLL.HR_Employee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <h4>Add Employee</h4>
    <div id="frmNewEmployee" class="form-horizontal" runat="server">

        <div class="form-group">
            <asp:Label AssociatedControlID="txtEmployeeName" CssClass="col-md-4 control-label" Text="Employee Name" runat="server"></asp:Label>
            <div class="col-md-5">
                <asp:TextBox CssClass="form-control" ID="txtEmployeeName" runat="server" placeholder="Employee Name"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label AssociatedControlID="ddlDepartment" CssClass="col-md-4 control-label" Text="Department" runat="server"></asp:Label>
            <div class="col-md-5">
                <asp:DropDownList CssClass="form-control" ID="ddlDepartment" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label AssociatedControlID="ddlDesignation" CssClass="col-md-4 control-label" Text="Designation" runat="server"></asp:Label>
            <div class="col-md-5">
                <asp:DropDownList CssClass="form-control" ID="ddlDesignation" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label AssociatedControlID="dtpJoinigDate" CssClass="col-md-4 control-label" Text="Joining Date" runat="server"></asp:Label>
            <div class="col-md-5">
                <asp:TextBox CssClass="form-control date" ID="dtpJoinigDate" placeholder="yyyy/MM/dd" runat="server" />
                <ajaxToolkit:CalendarExtender TargetControlID="dtpJoinigDate" Format="yyyy/MM/dd" runat="server" />
                <%--                        <asp:RegularExpressionValidator runat="server" ControlToValidate="dtpJoinigDate" ValidationExpression="(((0|1)[1-9]|2[1-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                             ErrorMessage="Invalid date format." ValidationGroup="Group1" />--%>
            </div>
        </div>
        <div class="form-group">
            <asp:Label AssociatedControlID="txtContactNo" CssClass="col-md-4 control-label" Text="Contact No" runat="server"></asp:Label>
            <div class="col-md-5">
                <asp:TextBox CssClass="form-control" ID="txtContactNo" placeholder="Contact No" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label AssociatedControlID="txtResidentAddress" CssClass="col-md-4 control-label" Text="Resident Address" runat="server"></asp:Label>
            <div class="col-md-5">
                <asp:TextBox CssClass="form-control" ID="txtResidentAddress" placeholder="Resident Address" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label AssociatedControlID="txtResidentContactNo" CssClass="col-md-4 control-label" Text="Resident Contact No" runat="server"></asp:Label>
            <div class="col-md-5">
                <asp:TextBox CssClass="form-control" ID="txtResidentContactNo" placeholder="Resident Contact No" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label AssociatedControlID="ddlWorkArea" CssClass="col-md-4 control-label" Text="Work Area" runat="server"></asp:Label>
            <div class="col-md-5">
                <asp:DropDownList CssClass="form-control" ID="ddlWorkArea" runat="server" OnSelectedIndexChanged="ddlWorkArea_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label AssociatedControlID="ddlWorkPlace" CssClass="col-md-4 control-label" Text="Work Place" runat="server"></asp:Label>
            <div class="col-md-5">
                <asp:DropDownList CssClass="form-control" ID="ddlWorkPlace" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label AssociatedControlID="ddlEmployeeStatus" CssClass="col-md-4 control-label" Text="Employee Status" runat="server"></asp:Label>
            <div class="col-md-5">
                <asp:DropDownList CssClass="form-control" ID="ddlEmployeeStatus" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label AssociatedControlID="txtRemark" CssClass="col-md-4 control-label" Text="Remarks" runat="server"></asp:Label>
            <div class="col-md-5">
                <asp:TextBox CssClass="form-control" ID="txtRemark" TextMode="MultiLine" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-8 col-md-offset-4">
                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_OnClick" />
                <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnUpdate_Click" />
            </div>
        </div>
    </div>

        <div class="table-responsive col-md-12">
        <asp:GridView ID="gvwEmployee" CssClass="grid-view table" runat="server" Align="Center" AutoGenerateColumns="false" OnRowDataBound="gvwEmployee_RowDataBound" OnSelectedIndexChanged="gvwEmployee_SelectedIndexChanged">       
            <Columns>
                <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                        HeaderStyle-CssClass="HiddenColumn" />
                <asp:BoundField DataField="EmployeID" HeaderText="EmployeeID"
                    SortExpression="DateField" />
                <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name"/>
                <asp:BoundField DataField="DepartmentID" HeaderText="DepartmentID" />
                <%--<asp:BoundField DataField="DepartmentName" HeaderText="Department"/>--%>
                <asp:BoundField DataField="DesignationID" HeaderText="DesignationID" />
                <%--<asp:BoundField DataField="Designation" HeaderText="Designation"/>--%>
                <asp:BoundField DataField="JoiningDate" HeaderText="Joining Date" DataFormatString="{0:yyyy/MM/dd}"/>
                <asp:BoundField DataField="ContactNo" HeaderText="Contact No"/>
                <asp:BoundField DataField="ResidentialAdd" HeaderText="Resident Address"/>
                <asp:BoundField DataField="ResidentContact" HeaderText="Resi. Contact No"/>
                <asp:BoundField DataField="WorkAreaID" HeaderText="WorkAreaID" />
               <%--  <asp:BoundField DataField="DemName" HeaderText="Work Area"/>--%>
                <asp:BoundField DataField="WorkPlaceID" HeaderText="Work Place" />
               <%--<asp:BoundField DataField="EmpStatusID" HeaderText="EmpStatusID"/>--%>
                <asp:BoundField DataField="EmpStatus" HeaderText="Employee Status" />
                <asp:BoundField DataField="Remark" HeaderText="Remarks"/>
            </Columns>
                                
        </asp:GridView>

    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSHR" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Employee Information");
        });
    </script>


</asp:Content>
