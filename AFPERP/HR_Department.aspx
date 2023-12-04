<%@ Page Title="HR Department" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HR_Department.aspx.cs" Inherits="BLL.HR_Department" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">

    <h4>Add Department</h4>
    <div id="frmDepartment" class="form-horizontal" runat="server">

        <div class="form-group">
            <asp:Label AssociatedControlID="txtDepartment" CssClass="col-md-4 control-label" Text="Department" runat="server"></asp:Label>
            <div class="input-group col-md-5">
                <asp:TextBox CssClass="form-control" ID="txtDepartment" placeholder="Enter Department Name" runat="server" />
            </div>
        </div>

        <div class="form-group">
            <div class="input-group col-md-8 col-md-offset-4">
                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_OnClick" />
                <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnUpdate_Click" />
            </div>
        </div>
        <div class="table-responsive col-md-12">
            <asp:GridView ID="gvwDepartment" CssClass="grid-view table" runat="server" Align="Center" AutoGenerateColumns="false" OnSelectedIndexChanged="gvwDepartment_SelectedIndexChanged" OnRowDataBound="gvwDepartment_RowDataBound">
                <Columns>
                    <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                        HeaderStyle-CssClass="HiddenColumn" />
                    <asp:BoundField DataField="DepartmentID" HeaderText="DepartmentID" SortExpression="DateField" />
                    <asp:BoundField DataField="DepartmentName" HeaderText="Department" />
                </Columns>
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="true" ForeColor="#F7F7F7" />
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
