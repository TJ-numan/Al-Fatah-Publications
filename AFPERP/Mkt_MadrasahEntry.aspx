<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_MadrasahEntry.aspx.cs" Inherits="BLL.Mkt_MadrasahEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="form-horizontal clearfix" runat="server">
                <div class="panel-body" style="border: 1px solid #BDC3CA">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Create New Madrasah
                        </div>
                        <div class="panel-body">
                            <%-- <div class="row">--%>
                            <div class="col-md-6">

                             <%--   <asp:UpdatePanel runat="server">
                                    <ContentTemplate>--%>
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="txtEIIN" Text="EIIN" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                            <div class="col-md-6">
                                                <asp:TextBox CssClass="form-control" ID="txtEIIN" runat="server" ReadOnly="false" TextMode="Number" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="txtMadrasahName" Text="Madrasah Name" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                            <div class="col-md-6">
                                                <asp:TextBox CssClass="form-control" ID="txtMadrasahName" runat="server" TextMode="MultiLine" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="txtVillRoBaz" Text="Vill/Road/Bazar" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                            <div class="col-md-6">
                                                <asp:TextBox CssClass="form-control" ID="txtVillRoBaz" runat="server" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="txtPostOffice" Text="Post Office" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                            <div class="col-md-6">
                                                <asp:TextBox CssClass="form-control" ID="txtPostOffice" runat="server" />
                                            </div>
                                        </div>
                        <%--            </ContentTemplate>
                                </asp:UpdatePanel>--%>

                            </div>
                            <div class="col-md-6">

                               <%-- <asp:UpdatePanel runat="server">
                                    <ContentTemplate>--%>
                                        <div class="form-group ">
                                            <asp:Label AssociatedControlID="ddlMadrashaLevel" Text="Madrasha Level" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                            <div class="col-md-6">
                                                <asp:DropDownList CssClass="form-control" ID="ddlMadrashaLevel" AutoPostBack="false" runat="server" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="ddlDristrict" Text="Select District" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                            <div class="col-md-6">
                                                <asp:DropDownList CssClass="form-control" ID="ddlDristrict" runat="server" OnSelectedIndexChanged="ddlDristrict_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="ddlThana" Text="Select Thana" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                            <div class="col-md-6">
                                                <asp:DropDownList CssClass="form-control" ID="ddlThana" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group ">
                                            <asp:Label AssociatedControlID="txtPhoneNo" Text="Phone No" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                            <div class="col-md-6">
                                                <asp:TextBox CssClass="form-control" ID="txtPhoneNo" runat="server" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-9 col-md-offset-0">
                                                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success pull-left" runat="server" OnClick="btnSave_Click" />
                                                <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary pull-right" runat="server" OnClick="btnUpdate_Click" />
                                            </div>
                                        </div>
                       <%--             </ContentTemplate>
                                </asp:UpdatePanel>--%>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                            <%--    <asp:UpdatePanel runat="server">
                                    <ContentTemplate>--%>
                                        <div class="form-group">
                                            <div class="col-md-4 col-md-offset-0">
                                                <asp:TextBox CssClass="form-control pull-right" ID="txtSearch" runat="server" Placeholder="Search" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="table-responsive table-bordered clearfix">
                                            <asp:GridView ID="gvwMadrasahEntry" runat="server" AllowPaging="true" AutoGenerateColumns="False" OnRowDataBound="gvwMadrasahEntry_RowDataBound" OnSelectedIndexChanged="gvwMadrasahEntry_SelectedIndexChanged" OnPageIndexChanging="gvwMadrasahEntry_PageIndexChanging" PageSize="22">
                                                <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                                <PagerSettings Mode="NumericFirstLast" />
                                                <Columns>
                                                    <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                                        HeaderStyle-CssClass="HiddenColumn" />
                                                    <asp:BoundField DataField="Code" HeaderText="EIIN"></asp:BoundField>
                                                    <asp:BoundField DataField="Name" HeaderText="Madrasah Name"></asp:BoundField>
                                                    <asp:BoundField DataField="Level_Name" HeaderText="Level"></asp:BoundField>
                                                    <asp:BoundField DataField="Address" HeaderText="Address"></asp:BoundField>
                                                    <asp:BoundField DataField="PostOffice" HeaderText="PostOffice"></asp:BoundField>
                                                    <asp:BoundField DataField="Mobile" HeaderText="Phone"></asp:BoundField>
                                                    <asp:BoundField DataField="DistrictName" HeaderText="District"></asp:BoundField>
                                                    <asp:BoundField DataField="ThanaName" HeaderText="Thana"></asp:BoundField>
                                                    <asp:BoundField DataField="TeritoryName" HeaderText="Territory"></asp:BoundField>

                                                </Columns>
                                                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" Font-Size="Large" />
                                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="true" ForeColor="#F7F7F7" />
                                            </asp:GridView>
                                        </div>

                               <%--     </ContentTemplate>
                                </asp:UpdatePanel>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Madrasah");
        });
    </script>
</asp:Content>
