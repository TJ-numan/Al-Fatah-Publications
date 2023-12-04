<%@ Page Title="" Language="C#" MasterPageFile="~/Distribution.master" AutoEventWireup="true" CodeBehind="Dist_DailyPackingCost.aspx.cs" Inherits="BLL.Dist_DailyPackingCost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DistributionContent" runat="server">
    <link href="css/GridviewStyling.css" rel="stylesheet" />
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-12">
                        <label class="radio-inline">
                            <asp:RadioButton runat="server" ID="radChalan" GroupName="Type" />Chalan
                        </label>
                        <label class="radio-inline">
                            <asp:RadioButton runat="server" ID="radSpeciman" GroupName="Type" />Speciman Chalan
                        </label>
                        <label class="radio-inline">
                            <asp:RadioButton runat="server" ID="radPromotional" GroupName="Type" />Promotional Item
                        </label>
                        <label class="checkbox-inline">
                            <asp:CheckBox runat="server" ID="chkIsQawmi" GroupName="Type" />Is Qawmi
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-3 control-label" Text="From" runat="server"></asp:Label>
                    <div class="col-md-5">
                        <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-mm-dd" runat="server" />
                        <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-3 control-label" Text="To" runat="server"></asp:Label>
                    <div class="col-md-5">
                        <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-mm-dd" runat="server" />
                        <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label CssClass="col-md-3 control-label" Text="" runat="server"></asp:Label>
                    <div class="col-md-6">
                        <label class="radio-inline">
                            <asp:RadioButton runat="server" ID="radPaid" GroupName="PaymentStatus" />Paid Chalan
                        </label>
                        <label class="radio-inline">
                            <asp:RadioButton runat="server" ID="radUnPaid" GroupName="PaymentStatus" />Unpaid Chalan
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <div class="input-group col-md-12">
                        <asp:Button ID="btnShow1" Text="Show" CssClass="btn btn-info pull-right" runat="server" OnClick="btnShow1_Click" />
                    </div>
                </div>
                <br />
                <div class="row">
                    <%-- <div class="form-group">
                        <div class="col-md-10 col-md-offset-1">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <div class="col-md-10 col-md-offset-1">
                                            <div class="search-input">
                                                <i class="icon-search"></i>
                                                <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" Placeholder="Search" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                    <div class="table-responsive  clearfix " style="max-height: 250px; overflow: auto">
                        <asp:GridView ID="gvwLeft" CssClass="table" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvwLeft_RowDataBound" OnSelectedIndexChanged="gvwLeft_SelectedIndexChanged">
                            <HeaderStyle></HeaderStyle>
                            <Columns>
                                <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                    HeaderStyle-CssClass="HiddenColumn" />
                                <asp:BoundField HeaderText="Memo No" DataField="MemoNo" />
                                <asp:BoundField HeaderText="Library Id" DataField="ID" />
                                <asp:BoundField HeaderText="Library Name" DataField="Name" />
                                <asp:BoundField HeaderText="Address" DataField="Address" />
                                <asp:BoundField HeaderText="Pack No" DataField="PackNo" />
                                <asp:BoundField HeaderText="PerPackCost" DataField="PerPackCost" />
                                <asp:BoundField HeaderText="TotalPackCost" DataField="TotalPackCost" />
                                <asp:BoundField HeaderText="Chalan Date" DataField="ChalanDate" />
                                <asp:BoundField HeaderText="Delivery Date" DataField="DeliveryDate" />
                            </Columns>
                            <SelectedRowStyle BackColor="#393737" Font-Bold="true" ForeColor="#F7F7F7" />
                        </asp:GridView>
                        <br />
                        <div class="pager">
                        </div>
                    </div>
                    <br />
                    <div class="table-responsive  clearfix " style="max-height: 250px; overflow: auto">
                        <asp:GridView ID="gvwLeftPaidChalan" CssClass="table" runat="server" AutoGenerateColumns="false">
                            <HeaderStyle></HeaderStyle>
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Memo No" DataField="MemoNo" />
                                <asp:BoundField HeaderText="Library Id" DataField="LibraryID" />
                                <asp:BoundField HeaderText="Library Name" DataField="LibraryName" />
                                <asp:BoundField HeaderText="Library Address" DataField="LibraryAddress" />
                                <asp:BoundField HeaderText="Transport Name" DataField="TransportName" />
                                <asp:BoundField HeaderText="RR No" DataField="RRNo" />
                                <asp:BoundField HeaderText="Pack No" DataField="PackNo" />
                                <asp:BoundField HeaderText="PerPackCost" DataField="PerPackCost" />
                                <asp:BoundField HeaderText="Created Date" DataField="CreatedDate" />
                                <asp:BoundField HeaderText="Delivery Date" DataField="DeliveryDate" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <br />
                </div>
                <div class=" col-md-8">
                    <div class="form-group">
                        <asp:Label CssClass="col-md-5 control-label" Text="Total Packet" runat="server"></asp:Label>
                        <div class="col-md-7">
                            <asp:TextBox CssClass="form-control" ID="txtTotalPacket1" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label CssClass="col-md-5 control-label" Text="Total Packet Cost" runat="server"></asp:Label>
                        <div class="col-md-7">
                            <asp:TextBox CssClass="form-control" ID="txtPacketCost1" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="col-md-12 ">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlTransport" CssClass="col-md-4 control-label" Text="Transport Name" runat="server"></asp:Label>
                        <div class="col-md-6">
                            <asp:DropDownList CssClass="form-control date" ID="ddlTransport" placeholder="yyyy-mm-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtRRNo" runat="server" CssClass=" col-md-4 control-label" Text="RR No"></asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox CssClass="form-control" ID="txtRRNo" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6 col-md-offset-4">
                            <label class="checkbox-inline">
                                <asp:CheckBox ID="chkIsIncomplete" runat="server" />Is InComplete
                            </label>
                        </div>
                    </div>
                    <div class="form-group ">
                        <div class="col-md-6 col-md-offset-4">
                            <asp:Label runat="server" ID="lblPacNo" Text="P" /><br />
                            <asp:Label runat="server" ID="lblPerPacCost" Text="pp" /><br />
                            <asp:Label runat="server" ID="lblPacCostTotal" Text="TP" /><br />
                        </div>
                    </div>
                    <br />
                    <hr style="border: 1px solid #BDC3CA" />
                    <div class="clearfix table-responsive">
                        <table class="table no-head-padding">
                            <tr>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtPacketNo" CssClass="control-label" Text="Packet No"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtVan" CssClass="control-label" Text="Van"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtTransport" CssClass="control-label" Text="Transport"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtChoat" CssClass="control-label" Text="Choat"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtPolythin" CssClass="control-label" Text="Polythin"></asp:Label>
                                </td>

                            </tr>
                            <tr>
                                <td class="p200">
                                    <asp:TextBox runat="server" ID="txtPacketNo" CssClass="form-control pktcalc" />
                                </td>

                                <td class="p100">
                                    <asp:TextBox runat="server" ID="txtVan" CssClass="form-control calc" />
                                </td>

                                <td class="p100">
                                    <asp:TextBox runat="server" ID="txtTransport" CssClass="form-control calc" />
                                </td>

                                <td style="width: 100px;">
                                    <asp:TextBox runat="server" ID="txtChoat" CssClass="form-control calc"></asp:TextBox>
                                </td>
                                <td class="p75">
                                    <asp:TextBox runat="server" ID="txtPolythin" CssClass="form-control calc" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="clearfix table-responsive">
                        <table class="table no-head-padding">
                            <tr>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtSelaiIn" CssClass="control-label" Text="Selai-In"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtSelaiOut" CssClass="control-label" Text="Selai-Out"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtPerPktCost" CssClass="control-label" Text="Per Pkt Cost"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="txtPktCostTotal" CssClass="control-label" Text="Pkt Cost Total"></asp:Label>
                                </td>
                            </tr>
                            <tr>

                                <td class="p75">
                                    <asp:TextBox runat="server" ID="txtSelaiIn" CssClass="form-control calc" />
                                </td>
                                <td class="p75">
                                    <asp:TextBox runat="server" ID="txtSelaiOut" CssClass="form-control calc" />
                                </td>
                                <td class="p75">
                                    <asp:TextBox runat="server" ID="txtPerPktCost" CssClass="form-control calc-total pktcalc" />
                                </td>
                                <td class="p75">
                                    <asp:TextBox runat="server" ID="txtPktCostTotal" CssClass="form-control pktTotalCal" />
                                </td>
                            </tr>

                        </table>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6 col-md-offset-6">
                            <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-primary newChalanAdd pul" Text="Add" OnClick="btnAdd_Click" />
                        </div>
                    </div>
                    <hr style="border: 1px solid #BDC3CA" />
                    <div class="row">
                        <div class="panel-body">
                            <div class="table-responsive table-bordered clearfix " style="height: 250px; overflow: auto">
                                <asp:GridView ID="gvwRight" CssClass="table " runat="server" AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                        <asp:BoundField DataField="Address" HeaderText="Address" />
                                        <asp:BoundField DataField="MemoNo" HeaderText="Memo" />
                                        <asp:BoundField DataField="PackNo" HeaderText="PackNo" />
                                        <asp:BoundField DataField="Van" HeaderText="Van" />
                                        <asp:BoundField DataField="Transport" HeaderText="Transport" />
                                        <asp:BoundField DataField="Choat" HeaderText="Choat" />
                                        <asp:BoundField DataField="Polithin" HeaderText="Polithin" />
                                        <asp:BoundField DataField="InSelai" HeaderText="In-Selai" />
                                        <asp:BoundField DataField="OutSelai" HeaderText="Out-Selai" />
                                        <asp:BoundField DataField="PerPackCost" HeaderText="PerPackCost" />
                                        <asp:BoundField DataField="TotalPackCost" HeaderText="TotalPackCost" />
                                        <asp:BoundField DataField="TransPortName" HeaderText="TransPortName" />
                                        <asp:BoundField DataField="RRNo" HeaderText="RRNo" />
                                        <asp:BoundField DataField="ChalanDate2" HeaderText="ChalanDate2" />
                                        <asp:BoundField DataField="DeliveryDate" HeaderText="DeliveryDate" />
                                        <asp:BoundField DataField="IsPending" HeaderText="IsPending" />
                                        <asp:BoundField DataField="ID" HeaderText="ID" />
                                        <asp:BoundField DataField="TransportID" HeaderText="TransportID" />
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
                    </div>
                    <div class=" col-md-8">
                        <div class="form-group">
                            <asp:Label CssClass="col-md-6 control-label" Text="Total Packet" runat="server"></asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox CssClass="form-control" ID="txtPacBill" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label CssClass="col-md-6 control-label" Text="Total Packet Cost" runat="server"></asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox CssClass="form-control" ID="txtTotalPacBill" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-12">
                                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success pull-right" runat="server" OnClick="btnSave_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSDistribution" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {

            calculateSum(".calc", ".calc-total");

            calculateMult(".pktcalc", ".pktTotalCal");

            $(".calc").on("keyup", function () {
                calculateSum(".calc", ".calc-total");
            });

            $(".pktcalc").on("keyup", function () {
                calculateMult(".pktcalc", ".pktTotalCal");
            });

        });

        //more field summation with textchange
        function calculateSum(field, total) {
            var sum = 0;

            $(field).each(function () {
                //add only if the value is number
                if (!isNaN(this.value) && this.value.length != 0) {
                    sum += parseFloat(this.value);
                }
            });
            $(total).val(sum.toFixed(2));

        }

        //more field multiplication with textchange
        function calculateMult(field, total) {
            var multi = 1;

            $(field).each(function () {
                //add only if the value is number
                if (!isNaN(this.value) && this.value.length != 0) {
                    multi *= parseFloat(this.value);
                }
                else multi = 0;

            });
            $(total).val(multi.toFixed(2));

        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Chalan");
        });
    </script>
</asp:Content>
