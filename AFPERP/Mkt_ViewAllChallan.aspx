<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_ViewAllChallan.aspx.cs" Inherits="BLL.Mkt_ViewAllChallan" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            View All Chalan
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtFromDate" CssClass="col-md-3 control-label no-padding-right" Text="From"></asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" placeholder="yyyy-MM-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtToDate" CssClass="col-md-3 control-label no-padding-right" Text="To"></asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" placeholder="yyyy-MM-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-3">
                                    <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info btn pull-right" runat="server" OnClick="btnShow_OnClick" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="panel-body">
                    <div class="table-responsive clearfix ">
                        <%--<dx:ASPxGridView ID="ASPxGridViewChalan" runat="server" Width="100%" AutoGenerateColumns="False">
                            <SettingsPager Visible="False">
                            </SettingsPager>
                            <Columns>
                                <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0">
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="MemoNo" Name="Memo No" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="LibraryName" VisibleIndex="2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="District Name" VisibleIndex="3">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Thana Name" VisibleIndex="4">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="PktNo" VisibleIndex="5">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="PerPktCost" VisibleIndex="6">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Name="TotalPktCost" VisibleIndex="7">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Total Chalan" VisibleIndex="8">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Amount Receivable" VisibleIndex="9">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <Styles AdaptiveDetailButtonWidth="22"></Styles>
                        </dx:ASPxGridView>--%>
                    </div>
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Challan");
        });
    </script>
</asp:Content>
