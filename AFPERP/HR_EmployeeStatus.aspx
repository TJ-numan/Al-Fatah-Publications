<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HR_EmployeeStatus.aspx.cs" Inherits="BLL.HR_EmployeeStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">

    <h4>Add Employee Status</h4>

    <div id="frmEmployeeStatus" class="form-horizontal" runat="server">

        <div class="form-group">
            <asp:Label AssociatedControlID="txtEmployeeStatus" CssClass="col-md-4 control-label" Text="Employee Status" runat="server"></asp:Label>
            <div class="input-group col-md-5">
                <asp:TextBox CssClass="form-control" ID="txtEmployeeStatus" placeholder="Enter Employee Status" runat="server" />
            </div>
        </div>

        <div class="form-group">
            <div class="input-group col-md-8 col-md-offset-4">
                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnUpdate_Click" />
            </div>
        </div>
        <div class="table-responsive col-md-12">
            <asp:GridView ID="gvwEmployeeStatus" CssClass="grid-view table" runat="server" Align="Center" AutoGenerateColumns="false" OnSelectedIndexChanged="gvwEmployeeStatus_SelectedIndexChanged" OnRowDataBound="gvwEmployeeStatus_RowDataBound">
                <Columns>
                    <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                        HeaderStyle-CssClass="HiddenColumn" />
                    <asp:BoundField DataField="EmpStatusID" HeaderText="EmployeeStatusID" SortExpression="DateField" />
                    <asp:BoundField DataField="EmpStatus" HeaderText="EmployeeStatus" />
                </Columns>

            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSHR" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Employee Information");
        });
    </script>
</asp:Content>
