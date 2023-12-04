<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="MktAdjustmentChallan.aspx.cs" Inherits="BLL.MktAdjustmentChallan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-4">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                           Select Chalan Type
                        </div>
                        <div class="panel-body" style="padding-left: 50px; height: 310px">
                            <div class="form-group">
                                <div class="checkbox">
                                    <asp:Label AssociatedControlID="chkRegular" runat="server" Text="Regular"></asp:Label>
                                    <asp:CheckBox ID="chkRegular" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="checkbox">
                                    <asp:Label AssociatedControlID="chkBoishakiChalan" runat="server" Text="Boishaki Chalan"></asp:Label>
                                    <asp:CheckBox ID="chkBoishakiChalan" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="checkbox">
                                    <asp:Label AssociatedControlID="chkBoishakiBonus" runat="server" Text="Boishaki Bonus"></asp:Label>
                                    <asp:CheckBox ID="chkBoishakiBonus" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="checkbox">
                                    <asp:Label AssociatedControlID="chkAlimSpecial" runat="server" Text="Alim Special"></asp:Label>
                                    <asp:CheckBox ID="chkAlimSpecial" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="checkbox">
                                    <asp:Label AssociatedControlID="chkAlimBonus" runat="server" Text="Alim Bonus"></asp:Label>
                                    <asp:CheckBox ID="chkAlimBonus" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4>Chalan Info</h4>
                        </div>
                        <div class="panel-body" style="height: 310px">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtDate" CssClass="col-md-4 control-label no-padding-right" Text="Date"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlLibraryName" Text="Library Name" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlLibraryName" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtMemoNo" Text="Memo No" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox CssClass="form-control" ID="txtMemoNo" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtRefChalanNo" Text="Ref Chalan No" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox CssClass="form-control" ID="txtRefChalanNo" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4>Book Info</h4>
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtBookCode" Text="Book Code" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox CssClass="form-control" ID="txtBookCode" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtBookName" Text="Book Name" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox CssClass="form-control" ID="txtBookName" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtClass" Text="Class" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox CssClass="form-control" ID="txtClass" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtType" Text="Type" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox CssClass="form-control" ID="txtType" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlEdition" Text="Edition" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlEdition" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtPrice" Text="UnitPrice" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox CssClass="form-control" ID="txtPrice" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtDiscount" Text="Discount" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox CssClass="form-control" ID="txtDiscount" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtShortQuantity" Text=" Short Quantity" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox CssClass="form-control" ID="txtShortQuantity" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtOverQuantity" Text=" Over Quantity" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox CssClass="form-control" ID="txtOverQuantity" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-8 col-md-offset-4">
                                    <asp:Button ID="btnAdd" Text="Add" CssClass="btn btn-success btn pull-right" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-primary">
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-inbox" id="dt">
                            <thead>
                                <tr>
                                    <th>Delete</th>
                                    <th>Code</th>
                                    <th>Book Name</th>
                                    <th>Type</th>
                                    <th>Class</th>
                                    <th>Edition</th>
                                    <th>Short Qty</th>
                                    <th>Over Qty</th>
                                    <th>Price</th>
                                    <th>Short Amount</th>
                                    <th>Over Amount</th>
                                    <th>Short Discount Amount</th>
                                    <th>Over Discount Amount</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>Delete</td>
                                    <td>Code</td>
                                    <td>Book Name</td>
                                    <td>Type</td>
                                    <td>Class</td>
                                    <td>Edition</td>
                                    <td>Short Qty</td>
                                    <td>Over Qty</td>
                                    <td>Price</td>
                                    <td>Short Amount</td>
                                    <td>Over Amount</td>
                                    <td>Short Discount Amount</td>
                                    <td>Over Discount Amount</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-md-6">
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtShortAmount" Text="Short Amount" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox CssClass="form-control" ID="txtShortAmount" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtOverAmount" Text="Over Amount" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox CssClass="form-control" ID="txtOverAmount" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtTotalDiscount" Text="Total Discount" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox CssClass="form-control" ID="txtTotalDiscount" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtPacketNo" Text="Packet No" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox CssClass="form-control" ID="txtPacketNo" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtAdjustAmount" Text="Adjust Amount" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox CssClass="form-control" ID="txtAdjustAmount" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-6 col-md-offset-6">
                                <asp:Button ID="btnPreview" Text="Preview" CssClass="btn btn-info" runat="server" />
                                <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-danger" runat="server" />
                                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" />
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
            var anc = $('span:contains("Chalan"), ul.sub a[href="MktAdjustmentChallan.aspx"]').parent().addClass("active");
            anc.next("ul").css("display", "block");
        });
    </script>
    <script>
        $(document).ready(function () {
            $('#dt').dataTable();
            responsive: true;
        });
    </script>
</asp:Content>
