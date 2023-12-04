<%@ Page Title="HR Designation" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HR_Designation.aspx.cs" Inherits="BLL.HR_Designation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">

    <h4>Add Designation</h4>

    <div id="frmDesignation" class="form-horizontal" runat="server">

        <div class="form-group">
            <asp:Label AssociatedControlID="txtDesignation" CssClass="col-md-4 control-label" Text="Designation" runat="server"></asp:Label>
            <div class="input-group col-md-5">
                <asp:TextBox CssClass="form-control" ID="txtDesignation" placeholder="Enter Name" runat="server" />
            </div>
        </div>

        <div class="form-group">
            <div class="input-group col-md-8 col-md-offset-4">
                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnUpdate_Click" />
            </div>
        </div>
        <div class="table-responsive col-md-12">
            <asp:GridView ID="gvwDesignation" CssClass="grid-view table" runat="server" Align="Center" AutoGenerateColumns="false" OnSelectedIndexChanged="gvwDesignation_SelectedIndexChanged" OnRowDataBound="gvwDesignation_RowDataBound">
                <Columns>
                    <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                        HeaderStyle-CssClass="HiddenColumn" />
                    <asp:BoundField DataField="DesignationID" HeaderText="DesignationID" SortExpression="DateField" />
                    <asp:BoundField DataField="Designation" HeaderText="Designation" />
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
