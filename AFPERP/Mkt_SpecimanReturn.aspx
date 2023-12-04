<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_SpecimanReturn.aspx.cs" Inherits="BLL.Mkt_SpecimanReturn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div id="frmNewReturn" class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Speciman Return 
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtReturnId" CssClass="col-md-4 control-label no-padding-right" Text="Return Id"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtReturnId" runat="server" CssClass="form-control" ReadOnly="True" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="dtpReturnDate" CssClass="col-md-4 control-label no-padding-right" Text="Return Date" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox CssClass="form-control date" ID="dtpReturnDate" placeholder="dd-MM-yyyy" runat="server" />
                                    <ajaxToolkit:CalendarExtender TargetControlID="dtpReturnDate" Format="dd-MM-yyyy" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <fieldset>
                                    <div class="checkbox col-md-8 col-md-offset-5">
                                        <asp:Label AssociatedControlID="chkDonation" runat="server" Text="Donation Chalan"></asp:Label>
                                        <asp:CheckBox ID="chkDonation" runat="server" />
                                    </div>
                                </fieldset>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlTsoName" CssClass="col-md-4 control-label no-padding-right" Text="Tso Name" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:DropDownList CssClass="form-control" ID="ddlTsoName" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtMemoNo" CssClass="col-md-4 control-label no-padding-right" Text="Memo No"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtMemoNo" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtDeliveredBy" CssClass="col-md-4 control-label no-padding-right" Text="Delivered By"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtDeliveredBy" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-8">
                        </div>
                    </div>
                    <hr style="border: 1px solid silver" />
                    <div class="col-xs-12">
                        <div class="form-group pull-left">
                            <asp:Label Style="float: left" runat="server" AssociatedControlID="txtBookCode" CssClass="control-label no-padding-right" Text="Book Code"></asp:Label>
                            <div class="col-xs-4 no-padding-right">
                                <asp:TextBox runat="server" ID="txtBookCode" OnTextChanged="txtBookCode_OnTextChanged" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-xs-4">
                                <asp:Button runat="server" ID="btnEnter" Text="Enter" CssClass="btn btn-danger btnBookCodeEnter" OnClick="txtBookCode_OnTextChanged"></asp:Button>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix table-responsive">
                        <table class=" table-responsive table no-head-padding ">
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
                                    <asp:Label runat="server" AssociatedControlID="txtUnitPrice" CssClass="control-label" Text="Unit Price"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtReturnQty" CssClass="control-label" Text="Return"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtAdjustmentQty" CssClass="control-label" Text="Adjustment"></asp:Label>
                                </td>

                            </tr>
                            <tr>
                                <td style="width: 300px">
                                    <asp:TextBox runat="server" ID="txtBookName" CssClass="form-control" ReadOnly="True" disabled="" />
                                </td>

                                <td style="width: 100px">
                                    <asp:TextBox runat="server" ID="txtType" CssClass="form-control" ReadOnly="True" disabled="" />
                                </td>

                                <td style="width: 100px">
                                    <asp:TextBox runat="server" ID="txtClass" CssClass="form-control" ReadOnly="True" disabled="" />
                                </td>

                                <td style="width: 100px">
                                    <asp:DropDownList runat="server" ID="ddlEdition" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                                </td>

                                <td style="width: 95px">
                                    <asp:TextBox runat="server" ID="txtUnitPrice" CssClass="form-control" ReadOnly="True" disabled="" />
                                </td>
                                <td style="width: 95px">
                                    <asp:TextBox runat="server" ID="txtReturnQty" CssClass="form-control" />
                                </td>
                                <td style="width: 95px">
                                    <asp:TextBox runat="server" ID="txtAdjustmentQty" CssClass="form-control" />
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-primary newReturnAdd" Text="Add" OnClick="btnAdd_OnClick" />
                                </td>
                            </tr>
                        </table>
                    </div>
                     <div class="col-md-12  no-padding ">
                            <div class="clearfix table-responsive">
                                <asp:GridView ID="gvwReturn" runat="server" AutoGenerateColumns="False" CssClass="table">
                                    <Columns>
                                        <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" DataField="Serial" />
                                        <asp:BoundField HeaderStyle-Width="40px" HeaderText="Book Code" DataField="BookCode" />
                                        <asp:BoundField HeaderStyle-Width="200px" HeaderText="Book Name" DataField="BookName" />
                                        <asp:BoundField HeaderStyle-Width="100px" HeaderText="Type" DataField="Type" />
                                        <asp:BoundField HeaderStyle-Width="100px" HeaderText="Class" DataField="Class" />
                                        <asp:BoundField HeaderStyle-Width="100px" HeaderText="Edition" DataField="Edition" />
                                        <asp:BoundField HeaderStyle-Width="100px" HeaderText="Price" DataField="Price" />
                                        <asp:BoundField HeaderStyle-Width="90px" HeaderText=" Quantity " DataField="Qty" />
                                        <asp:BoundField HeaderStyle-Width="120px" HeaderText="AQty" DataField="AQty" />
                                        <asp:BoundField HeaderStyle-Width="120px" HeaderText="R Amount" DataField="RAmount" />
                                        <asp:BoundField HeaderStyle-Width="120px" HeaderText="Ad. Amount" DataField="AdAmount" />
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblDelete" OnClick="lblDelete_OnClick" runat="server" CommandArgument='<%#Eval("Serial") %>'>
                                                                           Delete
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                           </div>
                     </div>
                    <hr style="border: 1px solid silver" />
                    <div class="col-md-12">
                        <div class="col-md-6">
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtTotalReturnAmount" CssClass="col-md-4 control-label no-padding-right" Text="Total Return Amount"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtTotalReturnAmount" placeholder="0.00" runat="server" CssClass="form-control" ReadOnly="True" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtTotalAdjustAmount" CssClass="col-md-4 control-label no-padding-right" Text="Total Adjust Amount"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtTotalAdjustAmount" placeholder="0.00" runat="server" ReadOnly="True" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-4">
                                    <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-danger" runat="server"  OnClick="btnPrint_Click"/>
                                    <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_OnClick" />
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
