<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="MktChalanQawmi.aspx.cs" Inherits="BLL.MktChalanQawmi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Chalan Posting for Qawmi
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtMemoNo" Text="Memo No" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox CssClass="form-control" ID="txtMemoNo" runat="server" ReadOnly="True" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtChalanDate" CssClass="col-md-4 control-label no-padding-right" Text=" Chalan Date"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtChalanDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtChalanDate" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlLibraryName" Text="Library Name" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlLibraryName" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtDeliveredBy" Text="Delivered By" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox CssClass="form-control" ID="txtDeliveredBy" runat="server" />
                                </div>
                            </div>
                         </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            Select Chalan Type
                        </div>
                        <div class="panel-body">
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="ddlCompany" CssClass="col-md-3 control-label no-padding-right" Text="Company"></asp:Label>
                                 <div class="col-md-4">
                                       <asp:DropDownList runat="server" ID="ddlCompany" CssClass="form-control">
                                            <asp:ListItem>Qawmi</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <label class="radio-inline">
                                            <asp:RadioButton runat="server" ID="radRegular" GroupName="Type" Checked="True" />Regular
                                        </label>
                                        <label class="radio-inline">
                                            <asp:RadioButton runat="server" ID="radBChalan" GroupName="Type" />Boishakhi Chalan
                                        </label>
                                        <label class="radio-inline">
                                            <asp:RadioButton runat="server" ID="radBBonus" GroupName="Type" />Boishakhi Bonus
                                        </label>
                                        <label class="radio-inline">
                                            <asp:RadioButton runat="server" ID="radAlimSpecial" GroupName="Type" />Alim Special
                                        </label>
                                        <label class="radio-inline">
                                            <asp:RadioButton runat="server" ID="radAlimBonus" GroupName="Type" />Alim Bonus
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
            </div>
            <hr style="border: 1px solid silver" />
            <div class="col-xs-12">
                <div class="form-group pull-left">
                    <asp:Label Style="float: left" runat="server" AssociatedControlID="txtBookCode" CssClass="control-label no-padding-right" Text="Book Code"></asp:Label>
                    <div class="col-xs-4 no-padding-right">
                        <asp:TextBox runat="server" ID="txtBookCode" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtBookCode_OnTextChanged"></asp:TextBox>
                    </div>
                    <div class="col-xs-4">
                        <asp:Button runat="server" ID="btnEnter" Text="Enter" CssClass="btn btn-danger btnBookCodeEnter" OnClick="btnEnter_OnClick"></asp:Button>
                    </div>
                </div>
            </div>
            <br>
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
                        <td style="width: 350px">
                            <asp:TextBox runat="server" ID="txtBookName" CssClass="form-control" ReadOnly="True" disabled="" />
                        </td>

                        <td style="width: 125px">
                            <asp:TextBox runat="server" ID="txtType" CssClass="form-control" ReadOnly="True" disabled="" />
                        </td>

                        <td style="width: 125px">
                            <asp:TextBox runat="server" ID="txtClass" CssClass="form-control" ReadOnly="True" disabled="" />
                        </td>

                        <td style="width: 125px">
                            <asp:DropDownList runat="server" ID="ddlEdition" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                        </td>
                        <td style="width: 100px">
                            <asp:TextBox runat="server" ID="txtCurrentStock" CssClass="form-control" Readonly="true" disabled="" />
                        </td>
                        <td style="width: 100px">
                            <asp:TextBox runat="server" ID="txtUnitPrice" CssClass="form-control" Readonly="true" disabled="" />
                        </td>
                        <td style="width: 100px">
                            <asp:TextBox runat="server" ID="txtQty" CssClass="form-control" />
                        </td>
                        <td>
                            <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-primary newReturnAdd" Text="Add" OnClick="btnAdd_OnClick" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="col-md-12  no-padding ">
                <div class="clearfix table-responsive">
                    <asp:GridView ID="gvChalan" runat="server" AutoGenerateColumns="False" CssClass="table">
                        <Columns>
                            <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" DataField="Serial" />
                            <asp:BoundField HeaderStyle-Width="100px" HeaderText="BookCode" DataField="BookCode" />
                            <asp:BoundField HeaderStyle-Width="300px" HeaderText="Book Name" DataField="BookName" />
                            <asp:BoundField HeaderStyle-Width="100px" HeaderText="Type" DataField="Type" />
                            <asp:BoundField HeaderStyle-Width="100px" HeaderText="Class" DataField="Class" />
                            <asp:BoundField HeaderStyle-Width="100px" HeaderText="Edition" DataField="Edition" />
                            <asp:BoundField HeaderStyle-Width="90px" HeaderText=" Quantity " DataField="Qty" />
                            <asp:BoundField HeaderStyle-Width="100px" HeaderText="Unit Price" DataField="UnitPrice" />
                            <asp:BoundField HeaderStyle-Width="100px" HeaderText="Total Amount" DataField="SellAmount" />
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
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-md-6">
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtTotalAmount" Text="Total Amount" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox CssClass="form-control" ID="txtTotalAmount" runat="server" ReadOnly="True" />
                            </div>
                        </div>
                        <asp:UpdatePanel runat="server" ID="TotalCost">
                            <ContentTemplate>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtPacketNo" Text="Packet No" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox CssClass="form-control" ID="txtPacketNo" runat="server" OnTextChanged="txtPacketNo_TextChanged" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtPerPacketCost" Text="Per Packet Cost" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox CssClass="form-control" ID="txtPerPacketCost" runat="server" AutoPostBack="True" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtTotalPacketCost" Text="Total Packet Cost" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox CssClass="form-control" ID="txtTotalPacketCost" runat="server" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtAmountReceivable" Text="Amount Receiveable" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox CssClass="form-control" ID="txtAmountReceivable" runat="server" />
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="form-group">
                            <div class="col-md-6 col-md-offset-4">                              
                                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_OnClick" />
                                <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-danger" runat="server" OnClick="btnPrint_OnClick" />
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
