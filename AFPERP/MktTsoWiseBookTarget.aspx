<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="MktTsoWiseBookTarget.aspx.cs" Inherits="BLL.MktTsoWiseBookTarget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div id="frmTsoTargetNew" runat="server" class="form-horizontal clearfix">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="col-md-12 clearfix no-padding">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Book Target Set
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-6 clearfix">
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtStartingDate" CssClass="col-md-4 control-label no-padding-right" Text="Starting Date"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" ID="txtStartingDate" CssClass="form-control" placeholder="yyyy-mm-dd" AutoPostBack="false" TabIndex="0" />
                                        <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtStartingDate" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtEndingDate" CssClass="col-md-4 control-label no-padding-right" Text="Ending Date"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" ID="txtEndingDate" CssClass="form-control" placeholder="yyyy-mm-dd" AutoPostBack="false" TabIndex="0" />
                                        <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtEndingDate" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="ddlTerritory" CssClass="col-md-4 control-label no-padding-right" Text="Territory"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:DropDownList runat="server" ID="ddlTerritory" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <%--<div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtTSO" CssClass="col-md-4 control-label no-padding-right" Text="TSO"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" ID="txtTSO" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtCode" CssClass="col-md-4 control-label no-padding-right" Text="Code"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" ID="txtCode" CssClass="form-control" />
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                        <hr style="border: 1px solid silver" />
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
                                        <asp:Label runat="server" AssociatedControlID="txtPrice" CssClass="control-label" Text="Price"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" AssociatedControlID="txtQty" CssClass="control-label" Text="Quantity"></asp:Label>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td style="width: 400px">
                                        <asp:TextBox runat="server" ID="txtBookName" CssClass="form-control" ReadOnly="True" disabled="" />
                                    </td>

                                    <td style="width: 300px">
                                        <asp:TextBox runat="server" ID="txtType" CssClass="form-control" ReadOnly="True" disabled="" />
                                    </td>

                                    <td style="width: 100px">
                                        <asp:TextBox runat="server" ID="txtClass" CssClass="form-control" ReadOnly="True" disabled="" />
                                    </td>

                                    <td style="width: 100px;">
                                        <asp:DropDownList runat="server" ID="ddlEdition" CssClass="form-control"></asp:DropDownList>
                                    </td>

                                    <td style="width: 75px">
                                        <asp:TextBox runat="server" ID="txtPrice" CssClass="form-control" ReadOnly="True" disabled="" />
                                    </td>
                                    <td style="width: 75px">
                                        <asp:TextBox runat="server" ID="txtQty" CssClass="form-control" />
                                    </td>
                                    <td>
                                        <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-primary newChalanAdd" Text="Add" OnClick="btnAdd_OnClick" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="col-md-12  no-padding ">
                            <div class="clearfix table-responsive">
                                <asp:GridView ID="gvwBookTarget" runat="server" AutoGenerateColumns="False" CssClass="table">
                                    <Columns>
                                        <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" DataField="Serial" Visible="True" />
                                        <asp:BoundField HeaderStyle-Width="40px" HeaderText="BookCode" DataField="BookCode" Visible="True" />
                                        <asp:BoundField HeaderStyle-Width="200px" HeaderText="Book Name" DataField="BookName" />
                                        <asp:BoundField HeaderStyle-Width="100px" HeaderText="Class" DataField="Class" />
                                        <asp:BoundField HeaderStyle-Width="200px" HeaderText="Type" DataField="Type" />
                                        <asp:BoundField HeaderStyle-Width="100px" HeaderText="Edition" DataField="Edition" />
                                        <asp:BoundField HeaderStyle-Width="100px" HeaderText="Price" DataField="Price" />
                                        <asp:BoundField HeaderStyle-Width="90px" HeaderText=" Qty " DataField="Qty" />
                                        <asp:BoundField HeaderStyle-Width="120px" HeaderText="Amount" DataField="Amount" />
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
                                            <asp:Label runat="server" AssociatedControlID="txtTotalQuantity" CssClass="col-md-4 control-label no-padding-right" Text="Total Quantity"></asp:Label>
                                            <div class="col-md-8">
                                                <asp:TextBox runat="server" ID="txtTotalQuantity" CssClass="form-control" placeholder="0" AutoPostBack="true" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="txtTotalAmount" CssClass="col-md-4 control-label no-padding-right" Text="Total Amountr"></asp:Label>
                                            <div class="col-md-8">
                                                <asp:TextBox runat="server" ID="txtTotalAmount" CssClass="form-control" placeholder="0" />
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="form-group">
                                    <div class="col-md-8 col-md-offset-4">
                                        <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" Text="Save" OnClick="btnSave_OnClick" />
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
            var anc = $('span:contains("Book Information"), ul.sub a[href="MktTsoWiseBookTarget"]').parent().addClass("active");
            anc.next("ul").css("display", "block");
        });
    </script>
</asp:Content>
