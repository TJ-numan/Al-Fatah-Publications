<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Rpt_TargetVsAchievement.aspx.cs" Inherits="BLL.Mkt_Rpt_TargetVsAchievement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    View Target Vs Achievement Report
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6">
                            <fieldset class="fsStyle">
                                <legend class="legendStyle">Search Panel</legend>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlCategory" CssClass="col-md-4 control-label" Text="Category" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:DropDownList CssClass="form-control" ID="ddlCategory" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtBookName" CssClass="col-md-4 control-label" Text="Book Name" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:TextBox CssClass="form-control" ID="txtBookName" placeholder="Book Name" runat="server" AutoPostBack="True" OnTextChanged="txtEdition_TextChanged" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtBookType" CssClass="col-md-4 control-label" Text="Book Type" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:TextBox CssClass="form-control" ID="txtBookType" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtClass" CssClass="col-md-4 control-label" Text="Class" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:TextBox CssClass="form-control" ID="txtClass" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtEdition" CssClass="col-md-4 control-label" Text="Edition" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:TextBox CssClass="form-control" ID="txtEdition" runat="server" AutoPostBack="True" OnTextChanged="txtEdition_TextChanged"></asp:TextBox>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="col-md-6">
                            <asp:UpdatePanel ID="UpdateArea1" runat="server">
                                <ContentTemplate>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-4 control-label" Text="From Date" runat="server"></asp:Label>
                                        <div class="input-group col-md-5">
                                            <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-mm-dd" runat="server" />
                                            <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-4 control-label" Text="To Date" runat="server"></asp:Label>
                                        <div class="input-group col-md-5">
                                            <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-mm-dd" runat="server" />
                                            <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlRegionMain" runat="server" CssClass="col-md-4 control-label no-padding-right" Text="Region Main" />
                                        <div class="dropdown col-md-5">
                                            <asp:DropDownList ID="ddlRegionMain" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlRegionMain_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlRegion" runat="server" CssClass="col-md-4 control-label" Text="Region" />
                                        <div class="dropdown col-md-5">
                                            <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlDivision" runat="server" CssClass="col-md-4 control-label" Text="Division" />
                                        <div class="dropdown col-md-5">
                                            <asp:DropDownList ID="ddlDivision" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlZone" runat="server" CssClass="col-md-4 control-label" Text="Zone" />
                                        <div class="dropdown col-md-5">
                                            <asp:DropDownList ID="ddlZone" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlTeritory" runat="server" CssClass="col-md-4 control-label" Text="Teritory" />
                                        <div class="dropdown col-md-5">
                                            <asp:DropDownList ID="ddlTeritory" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-5 col-md-offset-4">
                                        <label class="checkbox-inline">
                                            <asp:CheckBox runat="server" ID="chkQawmi" />Qawmi
                                        </label>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <label class="checkbox-inline">
                                    <asp:CheckBox runat="server" ID="chkAll" OnCheckedChanged="chkAll_CheckedChanged" AutoPostBack="True" />Select All
                                </label>
                            </div>
                            <asp:UpdatePanel ID="UpdateArea2" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="chkAll" />
                                </Triggers>
                                <ContentTemplate>
                                    <div class="col-md-8">
                                        <%-- <asp:CheckBox ID="chkAll" runat="server" Text="Select All" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />--%>
                                        <div style="height: 300px; width: 680px; overflow: auto;">
                                            <asp:GridView runat="server" ID="gvwAllBookStock" CssClass="table grid-view" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Select">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelect_CheckedChanged" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="BookCode" HeaderText="BookCode" />
                                                    <asp:BoundField DataField="BookName" HeaderText="BookName" />
                                                    <asp:BoundField DataField="ClassName" HeaderText="ClassName" />
                                                    <asp:BoundField DataField="BookType" HeaderText="BookType" />
                                                    <asp:BoundField DataField="Edition" HeaderText="Edition" />
                                                    <asp:BoundField DataField="Price" HeaderText="Price" />
                                                    <asp:BoundField DataField="StockQuantity" HeaderText="StockQty" />
                                                    <asp:BoundField DataField="SerialNo" HeaderText="SerialNo" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>

                                    </div>
                                    <div class="col-md-4">
                                        <div style="height: 300px; width: 300px; overflow: auto;">
                                            <asp:GridView runat="server" ID="gvwSubItem" CssClass="table grid-view col-md-5" AutoGenerateColumns="false" OnRowDeleting="gvwSubItem_RowDeleting">
                                                <Columns>
                                                    <asp:BoundField DataField="BookCodeEdition" HeaderText="BookCode / Edition" />
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbDelete" runat="server" CommandName="Delete">
                                                              Delete
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <hr />
                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-2">
                            <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info pull-right" runat="server" OnClick="btnShow_Click" />
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
            open_menu("Reports", "Chalan");
        });
    </script>
</asp:Content>
