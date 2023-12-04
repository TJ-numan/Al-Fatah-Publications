<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_SpecimanInternalTransfer.aspx.cs" Inherits="BLL.Mkt_SpecimanInternalTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div id="frmChallanNew" runat="server" class="form-horizontal clearfix">
        <div class="panel-body " style="border: 1px solid #BDC3CA">
            <div class="col-md-12 clearfix no-padding">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Speciman Internal Transfer
                    </div>
                    <div class="panel-body">
                        <div class="row col-md-12">
                            <div class="col-md-6 clearfix">
                                <div class="panel-heading">
                                    From
                                </div>
                                <div class="panel-body " style="border: 1px solid #BDC3CA">
                                    <asp:UpdatePanel runat="server" ID="UpdateArea1">
                                        <ContentTemplate>
                                            <div class="form-group">
                                                <asp:Label runat="server" AssociatedControlID="ddlTerritoryFrom" CssClass="col-md-4 control-label no-padding-right" Text="Territory"></asp:Label>
                                                <div class="col-md-6">
                                                    <asp:DropDownList runat="server" ID="ddlTerritoryFrom" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlTerritoryFrom_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label runat="server" AssociatedControlID="ddlTsoNameFrom" CssClass="col-md-4 control-label no-padding-right" Text="Tso Name"></asp:Label>
                                                <div class="col-md-6">
                                                    <asp:DropDownList runat="server" ID="ddlTsoNameFrom" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <br />
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtDate" CssClass="col-xs-4 control-label no-padding-right" Text="Order Date"></asp:Label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                        <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="panel-heading">
                                    To
                                </div>
                                <div class="panel-body " style="border: 1px solid #BDC3CA">
                                    <asp:UpdatePanel runat="server" ID="UpdateArea2">
                                        <ContentTemplate>
                                            <div class="form-group">
                                                <asp:Label runat="server" AssociatedControlID="ddlTerritoryTo" CssClass="col-md-4 control-label no-padding-right" Text="Territory"></asp:Label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList runat="server" ID="ddlTerritoryTo" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlTerritoryTo_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label runat="server" AssociatedControlID="ddlTsoNameTo" CssClass="col-md-4 control-label no-padding-right" Text="Tso Name"></asp:Label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList runat="server" ID="ddlTsoNameTo" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <br />
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtSlipNo" CssClass="col-xs-4 control-label no-padding-right" Text="Transfer Slip No"></asp:Label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtSlipNo" runat="server" CssClass="form-control" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <hr style="border: 1px solid #BDC3CA" />
                        <div class="col-xs-12 clearfix">
                            <div class="form-group pull-left">
                                <asp:Label Style="float: left" runat="server" AssociatedControlID="txtBookCode" CssClass="control-label no-padding-right" Text="Book Code"></asp:Label>
                                <div class="col-xs-4 no-padding-right">
                                    <asp:TextBox runat="server" ID="txtBookCode" CssClass="form-control" OnTextChanged="txtBookCode_TextChanged" AutoPostBack="true"></asp:TextBox>
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
                                        <asp:Label runat="server" AssociatedControlID="txtDiscount" CssClass="control-label" Text="Discount(%)"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" AssociatedControlID="txtPrice" CssClass="control-label" Text="Price"></asp:Label>
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
                                        <asp:TextBox runat="server" ID="txtDiscount" CssClass="form-control" />
                                    </td>
                                    <td style="width: 100px">
                                        <asp:TextBox runat="server" ID="txtPrice" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <td style="width: 100px">
                                        <asp:TextBox runat="server" ID="txtQty" CssClass="form-control" />
                                    </td>
                                    <td>
                                        <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-primary newChalanAdd" Text="Add" OnClick="btnAdd_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <hr style="border: 1px solid #BDC3CA" />
                        <div class="col-md-12  no-padding ">
                            <div class="clearfix table-responsive">
                                <asp:GridView ID="gvwSpTransfer" runat="server" AutoGenerateColumns="False" CssClass="table">
                                    <Columns>
                                        <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" DataField="Serial" />
                                        <asp:BoundField HeaderStyle-Width="40px" HeaderText="BooCode" DataField="BookCode" Visible="false" />
                                        <asp:BoundField HeaderStyle-Width="200px" HeaderText="Book Name" DataField="BookName" />
                                        <asp:BoundField HeaderStyle-Width="100px" HeaderText="Class" DataField="Class" />
                                        <asp:BoundField HeaderStyle-Width="200px" HeaderText="Type" DataField="Type" />
                                        <asp:BoundField HeaderStyle-Width="100px" HeaderText="Edition" DataField="Edition" />
                                        <asp:BoundField HeaderStyle-Width="100px" HeaderText="UnitPrice" DataField="UnitPrice" />
                                        <asp:BoundField HeaderStyle-Width="90px" HeaderText=" Qty " DataField="Qty" />
                                        <asp:BoundField HeaderStyle-Width="120px" HeaderText="Discount" DataField="DisAmount" />
                                        <asp:BoundField HeaderStyle-Width="120px" HeaderText="Amount" DataField="Total" />
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("Serial") %>' OnClick="lbDelete_Click">
                                                 Delete
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                        <div class="row">
                            <div class=" col-md-5 pull-right">
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtTotalAmount" CssClass="col-md-4 control-label" Text="Total Amount"></asp:Label>
                                    <div class="col-md-6">
                                        <asp:TextBox runat="server" ID="txtTotalAmount" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtTotalDiscount" CssClass="col-md-4 control-label" Text="Total Discount"></asp:Label>
                                    <div class="col-md-6">
                                        <asp:TextBox runat="server" ID="txtTotalDiscount" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtTotalTransferred" CssClass="col-md-4 control-label" Text="Total Transferred"></asp:Label>
                                    <div class="col-md-6">
                                        <asp:TextBox runat="server" ID="txtTotalTransferred" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-6 col-md-offset-4">
                                        <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" Text="Save" OnClick="btnSave_OnClick" />
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
    <script>
        $(document).ready(function () {
            open_menu("Speciman");
        });
    </script>
</asp:Content>
