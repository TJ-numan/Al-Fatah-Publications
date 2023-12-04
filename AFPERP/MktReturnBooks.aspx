<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="MktReturnBooks.aspx.cs" Inherits="BLL.MktReturnBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div id="frmNewReturn" class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Book Return Information
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtMemoNo" CssClass="col-md-4 control-label no-padding-right" Text="Memo No"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtMemoNo" runat="server" CssClass="form-control" ReadOnly="True" />
                                    <asp:Label runat="server" ID="lblMsg"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlCompany" CssClass="col-md-4 control-label no-padding-right" Text="Company"></asp:Label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlCompany" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">-Select-</asp:ListItem>
                                        <asp:ListItem Value="1">Alim</asp:ListItem>
                                        <asp:ListItem Value="2">Qawmi</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtReturnId" CssClass="col-md-4 control-label no-padding-right" Text="Return Id" Visible="false"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtReturnId" runat="server" CssClass="form-control" ReadOnly="False" Visible="false" />
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
                                <asp:Label AssociatedControlID="ddlLibraryName" CssClass="col-md-4 control-label no-padding-right" Text="Library Name" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:DropDownList CssClass="form-control" ID="ddlLibraryName" runat="server">
                                    </asp:DropDownList>
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
                                    <asp:Label runat="server" AssociatedControlID="txtQty" CssClass="control-label" Text="Quantity"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtDiscount" CssClass="control-label" Text="Discount"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtDamage" CssClass="control-label" Text="Damage"></asp:Label>
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
                                    <asp:DropDownList runat="server" ID="ddlEdition" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlEdition_SelectedIndexChanged"></asp:DropDownList>
                                </td>

                                <td style="width: 95px">
                                    <asp:TextBox runat="server" ID="txtUnitPrice" CssClass="form-control" ReadOnly="True" disabled="" />
                                </td>
                                <td style="width: 95px">
                                    <asp:TextBox runat="server" ID="txtQty" CssClass="form-control" />
                                </td>
                                <td style="width: 95px">
                                    <asp:TextBox runat="server" ID="txtDiscount" CssClass="form-control" />
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox runat="server" ID="txtDamage" CssClass="form-control" />
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-primary newReturnAdd" Text="Add" OnClick="btnAdd_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                     <div class="col-md-12  no-padding ">
                            <div class="clearfix table-responsive">
                                <asp:GridView ID="gvwReturn" runat="server" AutoGenerateColumns="False" CssClass="table">
                                    <Columns>
                                        <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" DataField="Serial" />
                                        <asp:BoundField HeaderStyle-Width="40px" HeaderText="BooCode" DataField="BookCode" />
                                        <asp:BoundField HeaderStyle-Width="200px" HeaderText="Book Name" DataField="BookName" />
                                        <asp:BoundField HeaderStyle-Width="100px" HeaderText="Type" DataField="Type" />
                                        <asp:BoundField HeaderStyle-Width="100px" HeaderText="Class" DataField="Class" />
                                        <asp:BoundField HeaderStyle-Width="100px" HeaderText="Edition" DataField="Edition" />
                                        <asp:BoundField HeaderStyle-Width="90px" HeaderText=" Quantity " DataField="Qty" />
                                        <asp:BoundField HeaderStyle-Width="120px" HeaderText="DamageQty" DataField="DamageQty" />
                                        <asp:BoundField HeaderStyle-Width="100px" HeaderText="UnitPrice" DataField="UnitPrice" />
                                        <asp:BoundField HeaderStyle-Width="120px" HeaderText="Discout %" DataField="DiscountPer" />
                                        <asp:BoundField HeaderStyle-Width="120px" HeaderText="Damage Amount" DataField="DamageAmount" />
                                        <asp:BoundField HeaderStyle-Width="120px" HeaderText="Discount" DataField="Discount" />
                                        <asp:BoundField HeaderStyle-Width="120px" HeaderText="Return Amount" DataField="ReturnAmount" />
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblDelete" OnClick="lblDelete_Click" runat="server" CommandArgument='<%#Eval("Serial") %>'>
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
                                <asp:Label runat="server" AssociatedControlID="txtReturnAmount" CssClass="col-md-4 control-label no-padding-right" Text="Total Return Amount"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtReturnAmount" placeholder="0.00" runat="server" CssClass="form-control" ReadOnly="True" />
                                </div>
                            </div>
                            <asp:UpdatePanel runat="server" ID="CalculateTotalCost">
                                <ContentTemplate>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtPacketNo" CssClass="col-md-4 control-label no-padding-right" Text="Packet No"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtPacketNo" placeholder="0" runat="server" AutoPostBack="True" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtPerPacketCost" CssClass="col-md-4 control-label no-padding-right" Text="Per Packet Cost"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtPerPacketCost" placeholder="0.00" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtPerPacketCost_OnTextChanged"  />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtTotalPacketCost" CssClass="col-md-4 control-label no-padding-right" Text="Total Packet Cost"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtTotalPacketCost" placeholder="0.00" runat="server" CssClass="form-control" AutoPostBack="True" ReadOnly="True" OnTextChanged="txtPacketNo_TextChanged" />
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtTotalDiscount" CssClass="col-md-4 control-label no-padding-right" Text="Total Discount"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtTotalDiscount" placeholder="0.00" runat="server" ReadOnly="True" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtAmountPayable" CssClass="col-md-4 control-label no-padding-right" Text="Amount Payable"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtAmountPayable" placeholder="0.00" runat="server" CssClass="form-control" ReadOnly="True" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-6">
                                    <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-danger " runat="server" OnClick="btnPrint_OnClick" />
                                    <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success " runat="server" OnClick="btnSave_Click" />
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
            open_menu("Returns");
        });
    </script>
</asp:Content>
