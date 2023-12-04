<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_AdjustmentChalan.aspx.cs" Inherits="BLL.Mkt_AdjustmentChalan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div id="frmChallanNew" runat="server" class="form-horizontal clearfix">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="col-md-12 clearfix no-padding">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Adjustment Chalan
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-6 clearfix">
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtDate" CssClass="col-md-4 control-label no-padding-right" Text="Date"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" ID="txtDate" CssClass="form-control" placeholder="yyyy-mm-dd" AutoPostBack="false" TabIndex="0" />
                                        <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="ddlLibraryName" CssClass="col-md-4 control-label no-padding-right" Text="Library Name"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:DropDownList runat="server" ID="ddlLibraryName" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtMemoNo" CssClass="col-md-4 control-label no-padding-right" Text="Memo No"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" ID="txtMemoNo" CssClass="form-control" ReadOnly="True" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtRefChalanNo" CssClass="col-md-4 control-label no-padding-right" Text="Ref. Chalan No"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" ID="txtRefChalanNo" CssClass="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <fieldset class="fsStyle">
                                    <legend class="legendStyle">Select Type</legend>
                                    <div class="form-group">
                                        <div class="col-md-7">
                                            <label class="radio-inline">
                                                <asp:RadioButton runat="server" ID="radRegular" GroupName="Type" Checked="True" />Regular
                                            </label>
                                            <label class="radio-inline">
                                                <asp:RadioButton runat="server" ID="radBoishakhi" GroupName="Type" />Boishakhi Chalan
                                            </label>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-7">
                                            <label class="radio-inline">
                                                <asp:RadioButton runat="server" ID="radAlim" GroupName="Type" />Alim Special
                                            </label>
                                            <label class="radio-inline">
                                                <asp:RadioButton runat="server" ID="radBoishakhiBonus" GroupName="Type" />Boishakhi Bonus
                                            </label>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-7">
                                            <label class="radio-inline">
                                                <asp:RadioButton runat="server" ID="radAlimBonus" GroupName="Type" />Alim Bonus
                                            </label>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="col-md-6">
                                <label class="checkbox-inline">
                                    <asp:CheckBox runat="server" ID="chkForReturn" />For Chalan
                                </label>
                            </div>
                        </div>
                        <hr style="border: 1px solid silver" />
                        <div class="col-xs-12 clearfix">
                            <div class="form-group pull-left">
                                <asp:Label Style="float: left" runat="server" AssociatedControlID="txtBookCode" CssClass="control-label no-padding-right" Text="Book Code"></asp:Label>
                                <div class="col-xs-4 no-padding-right">
                                    <asp:TextBox runat="server" ID="txtBookCode" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtBookCode_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-xs-4">
                                    <asp:Button runat="server" ID="btnEnter" Text="Enter" CssClass="btn btn-danger btnBookCodeEnter"></asp:Button>
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
                                        <asp:Label runat="server" AssociatedControlID="txtPrice" CssClass="control-label" Text="Price"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" AssociatedControlID="txtDiscount" CssClass="control-label" Text="Discount(%)"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" AssociatedControlID="txtShortQty" CssClass="control-label" Text="Short Qty"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" AssociatedControlID="txtOverQty" CssClass="control-label" Text="Over Qty"></asp:Label>
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
                                        <asp:TextBox runat="server" ID="txtPrice" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <td class="p75">
                                        <asp:TextBox runat="server" ID="txtDiscount" CssClass="form-control" />
                                    </td>
                                    <td class="p75">
                                        <asp:TextBox runat="server" ID="txtShortQty" CssClass="form-control" />
                                    </td>
                                    <td class="p75">
                                        <asp:TextBox runat="server" ID="txtOverQty" CssClass="form-control" />
                                    </td>
                                    <td>
                                        <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-primary newChalanAdd" Text="Add" OnClick="btnAdd_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <div class="col-md-12  no-padding ">
                            <div class="clearfix table-responsive">
                                <asp:GridView ID="gvwChlAdjust" runat="server" AutoGenerateColumns="False" CssClass="table">
                                    <Columns>
                                        <asp:BoundField DataField="Serial" HeaderText="Serial" />
                                        <asp:BoundField DataField="BookName" HeaderText="Book Name" />
                                        <asp:BoundField DataField="Type" HeaderText="Type" />
                                        <asp:BoundField DataField="Class" HeaderText="Class" />
                                        <asp:BoundField DataField="Edition" HeaderText="Edition" />
                                        <asp:BoundField DataField="ShortQty" HeaderText="Short Quantity" />
                                        <asp:BoundField DataField="OverQty" HeaderText="Over Quantity" />
                                        <asp:BoundField DataField="Price" HeaderText="Price" />
                                        <asp:BoundField DataField="ShortAmount" HeaderText="Short Amount" />
                                        <asp:BoundField DataField="OverAmount" HeaderText="Over Amount" />
                                        <asp:BoundField DataField="ShortDisAmount" HeaderText="Short Dis Amount" />
                                        <asp:BoundField DataField="OverDisAmount" HeaderText="Over Dis Amount" />
                                        <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="60px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblDelete" runat="server" CommandArgument='<%#Eval("Serial") %>' OnClick="lblDelete_OnClick">
                                                 Delete
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <hr style="border: 1px solid silver" />
                    </div>
                    <div class="col-md-12 clearfix no-padding">
                        <div class="panel-body">
                            <div class="col-md-6 clearfix">
                            </div>
                            <div class="col-md-6 clearfix">
                                <asp:UpdatePanel ID="upPayment" runat="server">
                                    <ContentTemplate>
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="txtTotalShortAmount" CssClass="col-md-4 control-label no-padding-right" Text="Short Amount"></asp:Label>
                                            <div class="col-md-8">
                                                <asp:TextBox runat="server" ID="txtTotalShortAmount" CssClass="form-control" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="txtTotalOverAmount" CssClass="col-md-4 control-label no-padding-right" Text="Over Amount"></asp:Label>
                                            <div class="col-md-8">
                                                <asp:TextBox runat="server" ID="txtTotalOverAmount" CssClass="form-control" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="txtTotalDiscount" CssClass="col-md-4 control-label no-padding-right" Text="Total Discount"></asp:Label>
                                            <div class="col-md-8">
                                                <asp:TextBox runat="server" ID="txtTotalDiscount" CssClass="form-control" PlaceHolder="0" ReadOnly="true" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="txtPktNo" CssClass="col-md-4 control-label no-padding-right" Text="Packet No"></asp:Label>
                                            <div class="col-md-8">
                                                <asp:TextBox runat="server" ID="txtPktNo" CssClass="form-control" PlaceHolder="0" ReadOnly="true" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="txtPerPktCost" CssClass="col-md-4 control-label no-padding-right" Text="Per Pcket cost"></asp:Label>
                                            <div class="col-md-8">
                                                <asp:TextBox runat="server" ID="txtPerPktCost" CssClass="form-control" PlaceHolder="0" ReadOnly="True" disabled="" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="txtAdjustAmount" CssClass="col-md-4 control-label no-padding-right" Text="Adjust Amount"></asp:Label>
                                            <div class="col-md-8">
                                                <asp:TextBox runat="server" ID="txtAdjustAmount" CssClass="form-control" PlaceHolder="0" ReadOnly="True" disabled="" />
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="form-group">
                                    <div class="col-md-8 col-md-offset-4">
                                        <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12 clearfix no-padding">
                        <div class="panel">
                            <div class="panel-body">
                                <div class="col-md-6 clearfix">
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
