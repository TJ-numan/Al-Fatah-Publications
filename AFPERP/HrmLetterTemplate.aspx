<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmLetterTemplate.aspx.cs" Inherits="BLL.HrmLetterTemplate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Letter Template
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group"  style="display:none">
                        <asp:Label AssociatedControlID="txtLetTempNameId" runat="server" CssClass="control-label col-md-2 no-padding-right">Letter Template Id</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtLetTempNameId" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtLetTempName" runat="server" CssClass="control-label col-md-2 no-padding-right">Letter Template</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtLetTempName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="File1" runat="server" CssClass="control-label col-md-2 no-padding-right">Template Path</asp:Label> 
                        <div class="col-md-4">
                            
                            <input type="file" id="File1" name="File1" runat="server" accept =".pdf"  >
                             
                        </div>
                     


                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtTemplateDes" runat="server" CssClass="control-label col-md-2 no-padding-right">Template Dscr.</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtTemplateDes" CssClass="form-control" runat="server"></asp:TextBox>
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
                                <asp:GridView ID="gvwLetterTemplate" CssClass="table " runat="server" AutoGenerateColumns="false" OnRowDataBound="gvwLetterTemplate_RowDataBound" OnSelectedIndexChanged="gvwLetterTemplate_SelectedIndexChanged">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />
                                        <asp:BoundField DataField="TempId" HeaderText="ID" />
                                        <asp:BoundField DataField="TempName" HeaderText="TempName" />
                                        <asp:BoundField DataField="TempPath" HeaderText="Temp Path" />
                                        <asp:BoundField DataField="TempDes" HeaderText="Temp Des" />
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
                $('[id*=gvwLetterTemplate]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                    "responsive": true,
                    "sPaginationType": "full_numbers"
                });
            });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Setting", "Letter Template");
        });
    </script>
</asp:Content>
