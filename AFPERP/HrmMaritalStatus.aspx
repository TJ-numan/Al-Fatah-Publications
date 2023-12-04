<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmMaritalStatus.aspx.cs" Inherits="BLL.HrmMaritalStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
     <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Marital Status
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group"  style="display:none">
                        <asp:Label AssociatedControlID="txtMaritalStatusId" runat="server" CssClass="control-label col-md-2 no-padding-right">Marital Status Id</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtMaritalStatusId" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtMaritalStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Marital Status</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtMaritalStatus" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-2">
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick ="btnSave_Click"  />
                            <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnUpdate_Click" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group"  style="display:none">
                            <div class="col-md-10 col-md-offset-1">
                                <div class="search-input">
                                    <i class="icon-search"></i>
                                    <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" Placeholder="Search" />
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                                <asp:GridView ID="gvwMaritalStatus" CssClass="table " runat="server" AutoGenerateColumns="false" OnRowDataBound ="gvwMaritalStatus_RowDataBound" OnSelectedIndexChanged ="gvwMaritalStatus_SelectedIndexChanged">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                     <Columns>
                                <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                    HeaderStyle-CssClass="HiddenColumn" />
                                <asp:BoundField DataField="MarStId" HeaderText="ID" />
                                <asp:BoundField DataField="MarStName" HeaderText="Marital Status"/>
                                <asp:BoundField DataField="InfStId" HeaderText="Info Status"/>
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
                $('[id*=gvwMaritalStatus]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                    "responsive": true,
                    "sPaginationType": "full_numbers"
                });
            });
    </script>
    <script type="text/javascript">
            $(document).ready(function () {
                open_menu("Setting", "Marital Status");
            });
    </script>
</asp:Content>
