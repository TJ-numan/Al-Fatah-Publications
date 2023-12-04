<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="MktRoutePlan.aspx.cs" Inherits="BLL.MktRoutePlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-5">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Select All
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlUnitName" CssClass="col-md-4 control-label no-padding-right" Text="Unit Name"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlUnitName" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlUnitName_OnSelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlDemarcationStep" CssClass="col-md-4 control-label no-padding-right" Text="Demarcation Step"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlDemarcationStep" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlDemarcationName" CssClass="col-md-4 control-label no-padding-right" Text="Demarcation Name"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlDemarcationName" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                              <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtRouteName" CssClass="col-md-4 control-label no-padding-right" Text="Route Name"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtRouteName" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-7">
                    <div class="panel panel-primary">
                        <div class="panel-heading">Route Plan</div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtPointName" Text="Point Name" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtPointName" runat="server" />
                                </div>
                            </div>
                            <div class="checkbox col-md-offset-3">
                                <div class="checkbox">
                                    <asp:Label AssociatedControlID="chkStartPoint" runat="server" Text="Start Point"></asp:Label>
                                    <asp:CheckBox ID="chkStartPoint" runat="server" />
                                </div>
                                <div class="checkbox">
                                    <asp:Label AssociatedControlID="chkMidlePoint" runat="server" Text="Midle Point"></asp:Label>
                                    <asp:CheckBox ID="chkMidlePoint" runat="server" />
                                </div>
                                <div class="checkbox">
                                    <asp:Label AssociatedControlID="chkEndPoint" runat="server" Text="End Point"></asp:Label>
                                    <asp:CheckBox ID="chkEndPoint" runat="server" />
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtPointAddress" Text="Point Address" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtPointAddress" runat="server" TextMode="MultiLine" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtPointRemarks" Text="Remarks" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtPointRemarks" runat="server" TextMode="MultiLine" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <asp:Button ID="btnAdd" Text="Add" CssClass="btn btn-success btn pull-right" runat="server" OnClick="btnAdd_OnClick"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="panel-body">
                    <div class="table-responsive table-bordered clearfix " style="height: 250px; overflow: auto">
                        <asp:GridView ID="gvPoints" CssClass="table " runat="server" AutoGenerateColumns="false">
                            <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                            <Columns>
                                <asp:BoundField HeaderText="#" DataField="#" />
                                <asp:BoundField HeaderText="#" DataField="#" />
                                <asp:BoundField HeaderText="#" DataField="# " />
                                <asp:BoundField HeaderText="#" DataField="#" />
                                <asp:BoundField HeaderText="#" DataField="#" />
                                <asp:BoundField HeaderText="#" DataField="#" />
                                <asp:BoundField HeaderText="#" DataField="#" />
                                <asp:BoundField HeaderText="#" DataField="#" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="form-group">
                    <div class="col-md-6 col-md-offset-5">
                        <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success btn pull-right" runat="server" OnClick="btnSave_OnClick" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Route Plan");
        });
    </script>
</asp:Content>
