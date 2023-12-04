<%@ Page Title="" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_PrintLaminationOrder.aspx.cs" Inherits="BLL.Pro_PrintLaminationOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="form-horizontal clearfix" runat="server">
                <div class="panel-body" style="border: 1px solid #BDC3CA">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Print Lemination Order
                        </div>
                        <%--<div id="frmPlateProcessBill" runat="server" class="form-horizontal clearfix">--%>
                        <div class="panel-body">
                            <div class="col-md-12 no-padding clearfix">
                                <div class="col-md-6 clearfix">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtOrderDate" CssClass="col-xs-4 control-label no-padding-right" Text="Order Date"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtOrderDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                            <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtOrderDate" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtLemiOrderNo" CssClass="col-xs-4 control-label no-padding-right" Text="Lemination Order"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtLemiOrderNo" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="dtpFromDate" CssClass="col-xs-4 control-label no-padding-right" Text="From Date"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="dtpFromDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                            <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="dtpFromDate" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="dtpToDate" CssClass="col-xs-4 control-label no-padding-right" Text="To Date"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="dtpToDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                            <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="dtpToDate" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlLemination" CssClass="col-xs-4 control-label no-padding-right" Text="Lemination"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList ID="ddlLemination" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-xs-8 col-xs-offset-4">
                                            <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info" runat="server" OnClick="btnShow_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 clearfix">
                                <div class="form-group">
                                    <div class="col-md-8 table-responsive">
                                        <asp:GridView runat="server" CssClass="table grid-view" ID="gvwPrintLemiOrder" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelect_CheckedChanged" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="BookName" HeaderText="BookName" />
                                                <asp:BoundField DataField="ClassName" HeaderText="Class" />
                                                <asp:BoundField DataField="TypeName" HeaderText="Type" />
                                                <asp:BoundField DataField="Edition" HeaderText="Edition" />
                                                <asp:BoundField DataField="PrintSl" HeaderText="Print No" />
                                                <asp:BoundField DataField="SerialNo" HeaderText="LemSerial" />
                                                <asp:BoundField DataField="Type" HeaderText="LeminationType" />
                                                <asp:BoundField DataField="Qty" HeaderText="Qty"/>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 clearfix no-padding">
                                <div class="col-md-6 col-md-offset-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtTotalQty" CssClass="col-xs-4 control-label no-padding-right" Text="Total Qty"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtTotalQty" runat="server" CssClass="form-control" Text="0" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-xs-8 col-xs-offset-4">
                                            <asp:Button ID="btnSavePrint" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSavePrint_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSPro" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Lamination");
        });
    </script>
</asp:Content>
