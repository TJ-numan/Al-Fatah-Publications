<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmInfoStatus.aspx.cs" Inherits="BLL.HrmInfoStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Information Status
                </div>
                <div class="panel-body">

                    <div class="form-group" style="display: none">
                        <asp:Label AssociatedControlID="txtInfoId" runat="server" CssClass="control-label col-md-2 no-padding-right">InfoId</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtInfoId" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Status Name</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtInfoStatus" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-2">
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                            <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnUpdate_Click" />
                        </div>
                    </div>
                    <div class="row">

                        <div class="panel-body">
                            <div>
                                <asp:GridView ID="gvEmpInfoStatus" CssClass="table table-bordered  table-responsive " runat="server" AutoGenerateColumns="false" OnRowDataBound="gvEmpInfoStatus_RowDataBound" OnSelectedIndexChanged="gvEmpInfoStatus_SelectedIndexChanged">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />
                                        <asp:BoundField DataField="InfStId" HeaderText="ID" />
                                        <asp:BoundField DataField="InfStatus" HeaderText="TermReason" />


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
            $('[id*=gvEmpInfoStatus]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Setting", "InfoStatus");
        });
    </script>
</asp:Content>
