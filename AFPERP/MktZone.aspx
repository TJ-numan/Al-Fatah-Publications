<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.Master" AutoEventWireup="true" CodeBehind="MktZone.aspx.cs" Inherits="BLL.MktZone" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    New Zone Entry
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlDivision" CssClass="control-label col-md-2 no-padding-right" runat="server">Division Name</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlDivision" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtZoneName" runat="server" CssClass="control-label col-md-2 no-padding-right">Zone Name</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtZoneName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtZoneBanglaName" runat="server" CssClass="control-label col-md-2 no-padding-right">Zone Bangla</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtZoneBanglaName" CssClass="form-control" Font-Names="SutonnyMJ" runat="server"></asp:TextBox>
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
                                <asp:GridView ID="gvwZone" CssClass="table " runat="server" AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />
                                        <asp:BoundField DataField="ZonID" HeaderText="ZoneID" />
                                        <asp:BoundField DataField="ZonName" HeaderText="ZoneName" />
                                        <asp:BoundField DataField="Zon_Bn" HeaderText="ZoneBangla" ItemStyle-Font-Names="SutonnyMJ" />
                                        <asp:BoundField DataField="DivName" HeaderText="DivisionName" />
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
