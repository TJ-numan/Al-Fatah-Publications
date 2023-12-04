<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.Master" AutoEventWireup="true" CodeBehind="MktTeritory.aspx.cs" Inherits="BLL.MktTeritory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    New Teritory Entry
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlZone" CssClass="control-label col-md-2 no-padding-right" runat="server">Zone Name</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlZone" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtTeritoryCode" runat="server" CssClass="control-label col-md-2 no-padding-right">Teritory Code</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtTeritoryCode" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtTeritoryName" runat="server" CssClass="control-label col-md-2 no-padding-right">Teritory Name</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtTeritoryName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtTeritoryBanglaName" runat="server" CssClass="control-label col-md-2 no-padding-right">Teritory Bangla</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtTeritoryBanglaName" CssClass="form-control" Font-Names="SutonnyMJ" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-2">
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                            <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnUpdate_Click" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-10 col-md-offset-1">
                                <div class="search-input">
                                    <i class="icon-search"></i>
                                    <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" Placeholder="Search" />
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                                <asp:GridView ID="gvwTeritory" CssClass="table " runat="server" AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />
                                        <asp:BoundField DataField="TeritoryID" HeaderText="TeritoryID" />
                                        <asp:BoundField DataField="TeritoryName" HeaderText="TeritoryName" />
                                        <asp:BoundField DataField="Territory_Bn" HeaderText="TeritoryBangla" ItemStyle-Font-Names="SutonnyMJ" />
                                        <asp:BoundField DataField="ZonName" HeaderText="ZoneName" />
                                        <asp:BoundField DataField="TeritoryCode" HeaderText="TeritoryCode" />
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
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Basic Settings");
        });
    </script>
</asp:Content>
