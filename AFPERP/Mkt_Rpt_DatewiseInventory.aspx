<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Rpt_DatewiseInventory.aspx.cs" Inherits="BLL.Mkt_Rpt_DatewiseInventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Show Datewise Inventory Report
                </div>
                <div class="panel-body">
                    <div class="col-md-12">
                        <div class="col-md-8">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-4 control-label no-padding-right" Text="From Date" runat="server"></asp:Label>
                                <div class="input-group col-md-5">
                                    <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-mm-dd" runat="server" />
                                    <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-4 control-label no-padding-right" Text="To Date" runat="server"></asp:Label>
                                <div class="input-group col-md-5">
                                    <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-mm-dd" runat="server" />
                                    <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlCategory" CssClass="col-md-4 control-label" Text="Category" runat="server"></asp:Label>
                                <div class="col-md-5">
                                    <asp:DropDownList CssClass="form-control" ID="ddlCategory" runat="server">
                                        <asp:ListItem Value="">--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlGroup" CssClass="col-md-4 control-label" Text="Group" runat="server"></asp:Label>
                                <div class="col-md-5">
                                    <asp:DropDownList CssClass="form-control" ID="ddlGroup" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlClass" CssClass="col-md-4 control-label" Text="Class" runat="server"></asp:Label>
                                <div class="col-md-5">
                                    <asp:DropDownList CssClass="form-control" ID="ddlClass" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlType" CssClass="col-md-4 control-label" Text="Type" runat="server"></asp:Label>
                                <div class="col-md-5">
                                    <asp:DropDownList CssClass="form-control" ID="ddlType" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlBookName" CssClass="col-md-4 control-label" Text="Book Name" runat="server"></asp:Label>
                                <div class="col-md-5">
                                    <asp:DropDownList CssClass="form-control" ID="ddlBookName" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlEdition" CssClass="col-md-4 control-label" Text="Edition" runat="server"></asp:Label>
                                <div class="col-md-5">
                                    <asp:DropDownList CssClass="form-control" ID="ddlEdition" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-8 col-md-offset-4">
                                    <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info" runat="server" OnClientClick="target='_blank'" />
                                </div>
                            </div>

                        </div>
                        <div class="col-md-4" >
                            <div class="panel panel-danger">
                                <div class="panel-heading">
                                    <h4>Select Any One</h4>
                                </div>
                                <div class="panel-body" id="selectChk" style="border: 1px solid #BDC3CA">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:CheckBox CssClass="" ID="chkCentralInventory" runat="server" />
                                            <asp:Label AssociatedControlID="chkCentralInventory" CssClass="control-label" runat="server" Text="Central Inventory"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:CheckBox CssClass="" ID="chkReturnInventory" runat="server" />
                                            <asp:Label AssociatedControlID="chkReturnInventory" CssClass="control-label" runat="server" Text="Return Inventory"></asp:Label>
                                        </div>
                                    </div>
                                     <div class="form-group">
                                        <div class="input-group">
                                            <asp:CheckBox CssClass="" ID="chkRebindingInventory" runat="server" />
                                            <asp:Label AssociatedControlID="chkRebindingInventory" CssClass="control-label" runat="server" Text="Rebinding Inventory"></asp:Label>
                                        </div>
                                    </div>
                                      <div class="form-group">
                                        <div class="input-group">
                                            <asp:CheckBox CssClass="" ID="chkDamageInventory" runat="server" />
                                            <asp:Label AssociatedControlID="chkDamageInventory" CssClass="control-label" runat="server" Text="Damage Inventory"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
</asp:Content>
