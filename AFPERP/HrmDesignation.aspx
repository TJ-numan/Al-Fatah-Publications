<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmDesignation.aspx.cs" Inherits="BLL.HrmDesignation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Designation
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group" style="display:none">
                        <asp:Label AssociatedControlID="txtDesignationId" runat="server" CssClass="control-label col-md-2 no-padding-right">Designation Id</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtDesignationId" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtDesignation" runat="server" CssClass="control-label col-md-2 no-padding-right">Designation</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtDesignation" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>


                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-2">
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                            <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnUpdate_Click" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group" style="display:none">
                            <div class="col-md-10 col-md-offset-1">
                                <div class="search-input">
                                    <i class="icon-search"></i>
                                    <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" Placeholder="Search" />
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                                <asp:GridView ID="gvDesignation" CssClass="table " runat="server" AutoGenerateColumns="false" OnRowDataBound  ="gvDesignation_RowDataBound"  OnSelectedIndexChanged ="gvDesignation_SelectedIndexChanged">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />
                                        <asp:BoundField DataField="DesId" HeaderText="ID" />
                                        <asp:BoundField DataField="DesName" HeaderText="TermReason" />
                                        <asp:BoundField DataField="InfStId" HeaderText="Info Status" />
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
           $('[id*=gvDesignation]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
               "responsive": true,
               "sPaginationType": "full_numbers"
           });
       });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Setting", "Designation");
        });
    </script>
</asp:Content>
