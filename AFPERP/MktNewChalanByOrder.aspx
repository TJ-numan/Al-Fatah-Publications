<%@ Page Title="" Language="C#" MasterPageFile="~/Distribution.master" AutoEventWireup="true" CodeBehind="MktNewChalanByOrder.aspx.cs" Inherits="BLL.MktNewChalanByOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DistributionContent" runat="server">
    <script type="text/javascript">

        function getDueAlert() {

            var agentId = document.getElementById('<%=ddlLibraryName .ClientID %>').selectedIndex;
            if (agentId == 0) {
                alert('Please select an agent.');
                return false;
            }
 <%--           var memoType = document.getElementById('<%=ddlMemoType .ClientID %>').selectedIndex;
            if (memoType == 0) {
                alert('Please select an memo type');
                return false;
            }--%>


            var subTotal = document.getElementById('<%=txtSubTotal.ClientID %>').value;
                    if (subTotal <= 0) {
                        alert('Subtotal Amount can not be zero.\n Please select a valid item.');
                        return false;
                    }

                    var dueVal = document.getElementById('<%=txtDue.ClientID %>').value;
                if (dueVal > 0) {
                    if (confirm('Payment is not clear.\n Do you want to continue ?') == true) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }

            }
    </script>
    <div id="frmChallanNew" runat="server" class="form-horizontal clearfix">
        <div class="col-md-12 clearfix no-padding">
            <div class="panel panel-primary"  style="border: 1px solid #BDC3CA">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6"   style="border: 1px solid #BDC3CA">
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    Add Chalan Information
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtOrderNo" CssClass="col-md-4 control-label no-padding-right" Text="Order No" runat="server"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtOrderNo" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtOrderNo_TextChanged"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtChlNewDate" CssClass="col-md-4 control-label no-padding-right" Text="Challan Date"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" ID="txtChlNewDate" CssClass="form-control" placeholder="yyyy-mm-dd" AutoPostBack="false" TabIndex="0" />
                                        <ajaxToolkit:CalendarExtender ID="Calender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtChlNewDate" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="ddlLibraryName" CssClass="col-md-4 control-label no-padding-right" Text="Library Name"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:DropDownList runat="server" ID="ddlLibraryName" CssClass="form-control" TabIndex="1">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="ddlMemoType" CssClass="col-md-4 control-label no-padding-right" Text="Memo Type"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:DropDownList runat="server" ID="ddlMemoType" CssClass="form-control" TabIndex="2">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtChlNewMemoNo" CssClass="col-md-4 control-label no-padding-right" Text="Memo No"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" ID="txtChlNewMemoNo" CssClass="form-control" TabIndex="100" />

                                    </div>
                                    <div class="text-success col-md-8 col-md-offset-4">
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
                                    <div class="checkbox">
                                        <asp:RadioButton ID="chkRegular" GroupName="ChalanType" runat="server" />
                                        <asp:Label AssociatedControlID="chkRegular" runat="server" Text="Regular"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="checkbox">
                                        <asp:RadioButton ID="chkBoishakiChalan" GroupName="ChalanType" runat="server" />
                                        <asp:Label AssociatedControlID="chkBoishakiChalan" runat="server" Text="Boishaki Chalan"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="checkbox">
                                        <asp:RadioButton ID="chkBoishakiBonus" GroupName="ChalanType" runat="server" />
                                        <asp:Label AssociatedControlID="chkBoishakiBonus" runat="server" Text="Boishaki Bonus"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="checkbox">
                                        <asp:RadioButton ID="chkAlimSpecial" GroupName="ChalanType" runat="server" />
                                        <asp:Label AssociatedControlID="chkAlimSpecial" runat="server" Text="Alim Special"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="checkbox">
                                        <asp:RadioButton ID="chkAlimBonus" GroupName="ChalanType" runat="server" />
                                        <asp:Label AssociatedControlID="chkAlimBonus" runat="server" Text="Alim Bonus"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <hr style="border: 1px solid silver" />
                <%--                    <div class="col-xs-12 clearfix">
                        <div class="form-group pull-left">
                            <asp:Label Style="float: left" runat="server" AssociatedControlID="txtChlNewBookCode" CssClass="control-label no-padding-right" Text="Book Code"></asp:Label>
                            <div class="col-xs-4 no-padding-right">
                                <asp:TextBox runat="server" ID="txtChlNewBookCode" OnTextChanged="txtChlNewBookCode_TextChanged" AutoPostBack="true" CssClass="form-control" TabIndex="3"></asp:TextBox>
                            </div>
                            <div class="col-xs-4">
                                <asp:Button runat="server" ID="btnEnter" Text="Enter" CssClass="btn btn-danger btnBookCodeEnter" OnClick="txtChlNewBookCode_TextChanged" TabIndex="4"></asp:Button>
                            </div>
                        </div>
                    </div>--%>
                <div class="col-md-12  no-padding ">
                    <div class="clearfix table-responsive">
                        <asp:GridView ID="gvBookReceive" runat="server" AutoGenerateColumns="False" CssClass="table">
                            <Columns>
                                <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" DataField="Serial" />
                                <asp:BoundField HeaderStyle-Width="40px" HeaderText="BooCode" DataField="BookCode" Visible="false" />
                                <asp:BoundField HeaderStyle-Width="200px" HeaderText="Book Name" DataField="BookName" />
                                <asp:BoundField HeaderStyle-Width="100px" HeaderText="Class" DataField="Class" />
                                <asp:BoundField HeaderStyle-Width="200px" HeaderText="Type" DataField="Type" />
                                <asp:BoundField HeaderStyle-Width="100px" HeaderText="Edition" DataField="Edition" />
                                <asp:BoundField HeaderStyle-Width="100px" HeaderText="UnitPrice" DataField="UnitPrice" />
                                <asp:BoundField HeaderStyle-Width="90px" HeaderText=" Qty " DataField="Qty" />
                                <asp:BoundField HeaderStyle-Width="120px" HeaderText="Discout %" DataField="DiscountPer" />
                                <asp:BoundField HeaderStyle-Width="120px" HeaderText="Discount" DataField="TotalDiscount" />
                                <asp:BoundField HeaderStyle-Width="120px" HeaderText="Amount" DataField="Total" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>

            <div class="col-md-12 clearfix no-padding">
                <div class="panel-body">
                    <div class="col-md-6 clearfix">
                    </div>
                    <div class="col-md-6 clearfix">

                        <asp:UpdatePanel ID="upPayment" runat="server">
                            <ContentTemplate>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtSubTotal" CssClass="col-md-4 control-label no-padding-right" Text="Total Amount"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" ID="txtSubTotal" CssClass="form-control" Text="0" ReadOnly="true" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtPacketNo" CssClass="col-md-4 control-label no-padding-right" Text="*Packet No"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" ID="txtPacketNo" CssClass="form-control" Text="0" AutoPostBack="true" OnTextChanged="txtPacketNo_TextChanged" TabIndex="5" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtPerPacketCost" CssClass="col-md-4 control-label no-padding-right" Text="*Per Packet Cost"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" ID="txtPerPacketCost" CssClass="form-control" Text="0" AutoPostBack="true" OnTextChanged="txtPacketNo_TextChanged" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtChlNewTotPCost" CssClass="col-md-4 control-label no-padding-right" Text="Total Packet Cost"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" ID="txtChlNewTotPCost" CssClass="form-control" Text="0" ReadOnly="true" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtDiscountTotal" CssClass="col-md-4 control-label no-padding-right" Text="Total Discount"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" ID="txtDiscountTotal" CssClass="form-control" Text="0" ReadOnly="true" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtAmountReceivable" CssClass="col-md-4 control-label no-padding-right" Text="Amount Receivable"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" ID="txtAmountReceivable" CssClass="form-control" Text="0" ReadOnly="true" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtAmountPaid" CssClass="col-md-4 control-label no-padding-right" Text="Amount Paid"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" ID="txtAmountPaid" CssClass="form-control" Text="0" AutoPostBack="true" ReadOnly="false" OnTextChanged="txtPacketNo_TextChanged" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtDue" CssClass="col-md-4 control-label no-padding-right" Text="Due"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" ID="txtDue" CssClass="form-control" Text="0" ReadOnly="True" disabled="" />
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="form-group">
                            <div class="col-md-8 col-md-offset-4">
                                <asp:Button runat="server" ID="btnChlNewPrint" CssClass="btn btn-primary" Text="Print" OnClick="btnChlNewPrint_Click" />
                                <asp:Button runat="server" ID="btnChlNewSave" CssClass="btn btn-success" Text="Save" OnClientClick="getDueAlert(); " OnClick="btnChlNewSave_Click" />
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSDistribution" runat="server">
    <script>
        $(document).ready(function () {
            open_menu("Chalan");
        });
    </script>
    <script type="text/javascript">

        function SetFocus() {

            var PaidAmount = document.getElementById('<%=txtAmountPaid .ClientID %>').value;
            if (PaidAmount <= 0) {
                alert('Please give a valid amount');
                return false;

            }
        }
    </script>
</asp:Content>
