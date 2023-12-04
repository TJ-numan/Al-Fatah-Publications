<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_NewChalanQawmi.aspx.cs" Inherits="BLL.Mkt_NewChalanQawmi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div id="frmChallanNew" runat="server" class="form-horizontal clearfix">
        <div class="panel-body " style="border: 1px solid #BDC3CA">
            <div class="col-md-12 clearfix no-padding">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        New Chalan Qawmi
                    </div>
                    <div class="panel-body">
                        <div class="row col-md-12">
                            <div class="col-md-8 clearfix">
                                <div class="panel-body " style="border: 1px solid #BDC3CA">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtChalanId" CssClass="col-md-4 control-label no-padding-right" Text="Chalan Id"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox runat="server" ID="txtChalanId" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlLibraryName" CssClass="col-md-4 control-label no-padding-right" Text="Library Name"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList runat="server" ID="ddlLibraryName" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtMemoNo" CssClass="col-md-4 control-label no-padding-right" Text="Memo No"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox runat="server" ID="txtMemoNo" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtDeliveredBy" CssClass="col-md-4 control-label no-padding-right" Text="Delivered By"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox runat="server" ID="txtDeliveredBy" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="dtpChalanDate" CssClass="col-md-4 control-label no-padding-right" Text="Chalan Date"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox runat="server" ID="dtpChalanDate" CssClass="form-control"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender runat="server" TargetControlID="dtpChalanDate" Format="dd-MM-YYYY" />
                                        </div>
                                    </div>
                                    <fieldset class="fsStyle">
                                        <legend class="legendStyle">Select Type</legend>
                                        <div class="form-group">
                                            <div class="col-md-12">
                                                <label class="radio-inline">
                                                    <asp:RadioButton runat="server" ID="radRegular" GroupName="Type" />Regular
                                                </label>
                                                <label class="radio-inline">
                                                    <asp:RadioButton runat="server" ID="radBChalan" GroupName="Type" />Boishakhi Chalan
                                                </label>
                                                <label class="radio-inline">
                                                    <asp:RadioButton runat="server" ID="radBBonus" GroupName="Type" />Boishakhi Bonus
                                                </label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-12">
                                                <label class="radio-inline">
                                                    <asp:RadioButton runat="server" ID="radAlimSpecial" GroupName="Type" />Alim Special
                                                </label>
                                                <label class="radio-inline">
                                                    <asp:RadioButton runat="server" ID="radAlimBonus" GroupName="Type" />Alim Bonus
                                                </label>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr style="border: 1px solid #BDC3CA" />
                    <div class="col-xs-12 clearfix">
                        <div class="form-group pull-left">
                            <asp:Label Style="float: left" runat="server" AssociatedControlID="txtBookCode" CssClass="control-label no-padding-right" Text="Book Code"></asp:Label>
                            <div class="col-xs-4 no-padding-right">
                                <asp:TextBox runat="server" ID="txtBookCode" AutoPostBack="true" CssClass="form-control" OnTextChanged="btnEnter_OnClick"></asp:TextBox>
                            </div>
                            <div class="col-xs-4">
                                <asp:Button runat="server" ID="btnEnter" Text="Enter" CssClass="btn btn-danger btnBookCodeEnter" OnClick="btnEnter_OnClick"></asp:Button>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix table-responsive">
                        <table class="table no-head-padding table-bordered">
                            <tr>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtBookName" CssClass="control-label" Text="Book Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtType" CssClass="control-label" Text="Type"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtClass" CssClass="control-label" Text="Class"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="ddlEdition" CssClass="control-label" Text="Edition"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtCurrentStock" CssClass="control-label" Text="Current Stock"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtUnitPrice" CssClass="control-label" Text="Unit Price"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtQty" CssClass="control-label" Text="Quantity"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="p200">
                                    <asp:TextBox runat="server" ID="txtBookName" CssClass="form-control" />
                                </td>

                                <td class="p100">
                                    <asp:TextBox runat="server" ID="txtType" CssClass="form-control" />
                                </td>

                                <td class="p100">
                                    <asp:TextBox runat="server" ID="txtClass" CssClass="form-control" />
                                </td>

                                <td style="width: 100px;">
                                    <asp:DropDownList runat="server" ID="ddlEdition" CssClass="form-control"></asp:DropDownList>
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox runat="server" ID="txtCurrentStock" CssClass="form-control" />
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox runat="server" ID="txtUnitPrice" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox runat="server" ID="txtQty" CssClass="form-control" />
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="btnChlNewAdd" CssClass="btn btn-primary newChalanAdd" Text="Add" OnClick="btnChlNewAdd_OnClick"/>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <hr style="border: 1px solid #BDC3CA" />
                    <asp:GridView ID="gvChalan" runat="server" AutoGenerateColumns="False" CssClass="table">
                        <Columns>
                            <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" DataField="Serial" />
                            <asp:BoundField HeaderStyle-Width="300px" HeaderText="Book Name" DataField="BookName" />
                            <asp:BoundField HeaderStyle-Width="100px" HeaderText="Type" DataField="Type" />
                            <asp:BoundField HeaderStyle-Width="100px" HeaderText="Class" DataField="Class" />
                            <asp:BoundField HeaderStyle-Width="100px" HeaderText="Edition" DataField="Edition" />
                            <asp:BoundField HeaderStyle-Width="90px" HeaderText=" Quantity " DataField="Qty" />
                            <asp:BoundField HeaderStyle-Width="100px" HeaderText="Unit Price" DataField="UnitPrice" />
                            <asp:BoundField HeaderStyle-Width="100px" HeaderText="Sell Amount" DataField="SellAmount" />
                            <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="60px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblDelete" runat="server" CommandArgument='<%#Eval("Serial") %>' OnClick="lblDelete_OnClick">
                                                 Delete
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div class="row">
                        <div class=" col-md-5 pull-right">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtTotalAmount" CssClass="col-md-4 control-label" Text="Total Amount"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox runat="server" ID="txtTotalAmount" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtPktNo" CssClass="col-md-4 control-label" Text="Packet No"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox runat="server" ID="txtPktNo" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtPerPktCost" CssClass="col-md-4 control-label" Text="Per Packet Cost"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox runat="server" ID="txtPerPktCost" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtTotalPktCost" CssClass="col-md-4 control-label" Text="Total Packet Cost"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox runat="server" ID="txtTotalPktCost" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtAmountReceivable" CssClass="col-md-4 control-label" Text="Amount Receivable"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox runat="server" ID="txtAmountReceivable" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-4">
                                    <asp:Button runat="server" CssClass="btn btn-success" Text="Save" />
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
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Challan");
        });
    </script>
</asp:Content>
