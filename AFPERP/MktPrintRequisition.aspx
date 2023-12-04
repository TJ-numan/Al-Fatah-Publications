<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="MktPrintRequisition.aspx.cs" Inherits="BLL.MktPrintRequisition" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">


    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Select All
                        </div>
                        <div class="panel-body" style="border: 1px solid #BDC3CA">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="dtpDate" CssClass="col-xs-3 control-label no-padding-right" Text="Date"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="dtpDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="dtpDate" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlCategory" CssClass="col-xs-3 control-label no-padding-right" Text="Category"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlBookGroup" CssClass="col-xs-3 control-label no-padding-right" Text="Group"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlBookGroup" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlClass" CssClass="col-xs-3 control-label no-padding-right" Text="Class"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlBookType" CssClass="col-xs-3 control-label no-padding-right" Text="Type"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlBookType" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlBookType_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                </div>
                            </div>
                            <br />
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="panel panel-danger">
                        <div class="panel-heading">Special Instructions</div>
                        <div class="panel-body" style="border: 1px solid #BDC3CA">
                            <asp:CheckBoxList runat="server" ID="chkReqInstruction" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        <div class="form">
                                            <asp:Label runat="server" AssociatedControlID="ddlBookName_1st" CssClass="col-md-3 control-label no-padding-right" Text="Book Name"></asp:Label>
                                            <div class="col-md-9">
                                                <asp:DropDownList ID="ddlBookName_1st" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlBookName_1st_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-inline">
                                            <asp:Label runat="server" AssociatedControlID="ddlPestingType" CssClass="col-md-4 control-label no-padding-right" Text="Pesting Type"></asp:Label>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlPestingType" runat="server" CssClass="form-control" OnSelectedIndexChanged="btnLoadFirst_OnClick" AutoPostBack="true"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-inline">
                                            <asp:Label runat="server" AssociatedControlID="ddlEdition_1st" CssClass="col-md-3 control-label no-padding-right" Text="Edition"></asp:Label>
                                            <div class="col-md-6">
                                                <asp:DropDownList ID="ddlEdition_1st" runat="server" CssClass="form-control" OnSelectedIndexChanged="btnLoadFirst_OnClick" AutoPostBack="true"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-inline">
                                            <div class="col-md-3">
                                                <asp:Button runat="server" ID="btnLoadFirst" CssClass="btn btn-danger" Text="Load" OnClick="btnLoadFirst_OnClick" Visible="false" />
                                            </div>
                                        </div>

                                        <div class="form-inline">
                                            <div class="col-md-6">
                                                <asp:Label runat="server" ID="lblFormaQty" CssClass="form-control-static" Text="" Font-Size="10px" ForeColor="#9900ff" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="table-responsive table-bordered clearfix " style="height: 150px; overflow: auto">
                                    <asp:GridView ID="gvwCurrentYearSell" runat="server" AutoGenerateColumns="False" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="TargetQty" HeaderText="Target"></asp:BoundField>
                                            <asp:BoundField DataField="ReqQty" HeaderText="ReqQty"></asp:BoundField>
                                            <asp:BoundField DataField="POrder" HeaderText="Printed"></asp:BoundField>
                                            <asp:BoundField DataField="GdReceive" HeaderText="Receive"></asp:BoundField>
                                            <asp:BoundField DataField="ChalanQty" HeaderText="Challan"></asp:BoundField>
                                            <asp:BoundField DataField="AgentRQty" HeaderText="Return"></asp:BoundField>
                                            <asp:BoundField DataField="ACSell" HeaderText="Actual Sell"></asp:BoundField>
                                            <asp:BoundField DataField="SpecQty" HeaderText="Speciman"></asp:BoundField>
                                            <asp:BoundField DataField="StockQuantity" HeaderText="Stock Qty"></asp:BoundField>
                                            <asp:BoundField DataField="RetStock" HeaderText="Ret Stock"></asp:BoundField>
                                            <asp:BoundField DataField="StockInHand" HeaderText="Stock In Hand"></asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        <div class="form">
                                            <asp:Label runat="server" AssociatedControlID="ddlBookName_Last" CssClass="col-md-3 control-label no-padding-right" Text="Book Name"></asp:Label>
                                            <div class="col-md-9">
                                                <asp:DropDownList ID="ddlBookName_Last" runat="server" CssClass="form-control" OnTextChanged="ddlBookName_Last_OnTextChanged" AutoPostBack="true"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-inline">
                                            <asp:Label runat="server" AssociatedControlID="ddlEdition_Last" CssClass="col-md-3 control-label no-padding-right" Text="Edition"></asp:Label>
                                            <div class="col-md-6">
                                                <asp:DropDownList ID="ddlEdition_Last" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="btnLoadLast_Click"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-inline">
                                            <div class="col-md-3">
                                                <asp:Button runat="server" ID="btnLoadLast" CssClass="btn btn-danger" Text="Load" OnClick="btnLoadLast_Click" Visible="false" />
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="table-responsive table-bordered clearfix " style="height: 150px; overflow: auto">
                                    <asp:GridView ID="gvwLastYear" runat="server" AutoGenerateColumns="False" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="BookAcCode" HeaderText="Edition"></asp:BoundField>
                                            <asp:BoundField DataField="POrder" HeaderText="Printed"></asp:BoundField>
                                            <asp:BoundField DataField="GdReceive" HeaderText="Receive"></asp:BoundField>
                                            <asp:BoundField DataField="ACSell" HeaderText="Challan"></asp:BoundField>
                                            <asp:BoundField DataField="SpecQty" HeaderText="Specimen"></asp:BoundField>
                                            <asp:BoundField DataField="RebindingQty" HeaderText="Rebinding"></asp:BoundField>
                                            <asp:BoundField DataField="DamageQty" HeaderText="Damage"></asp:BoundField>
                                            <asp:BoundField DataField="StockInHand" HeaderText="Stock In"></asp:BoundField>
                                            <asp:BoundField DataField="StartDate" HeaderText="FromDate" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
                                            <asp:BoundField DataField="EndDate" HeaderText="ToDate" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group">
                    <asp:Label AssociatedControlID="txtRemark" Text="Remark" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox CssClass="form-control" ID="txtRemark" runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="dtpGodownRcvDate" CssClass="col-md-4 control-label no-padding-right" Text=" Godown Receiving Date"></asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox ID="dtpGodownRcvDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                        <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="dtpGodownRcvDate" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label AssociatedControlID="txtFormaQty" Text="Proposed Qty" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox CssClass="form-control" ID="txtFormaQty" runat="server" />
                    </div>
                    <div class="col-md-2">
                        <asp:Label AssociatedControlID="ddlPrintSl" Text="As" CssClass="col-md-2 control-label no-padding-right" runat="server"></asp:Label>
                        <asp:DropDownList ID="ddlPrintSl" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label AssociatedControlID="txtRequisitionNumber" Text="Requisition Number" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox CssClass="form-control" ID="txtRequisitionNumber" runat="server" />
                    </div>
                </div>

            </div>
            <div class="form-Inline">
                <div class="form-group">
                    <div class="col-md-4 col-md-offset-6">
                        <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" runat="server" />
                        <asp:Button ID="btnPrint" Text="Go For Print" CssClass="btn btn-danger" runat="server" OnClick="btnPrint_Click" />
                        <asp:Button ID="btnUpdte" Text="Update" CssClass="btn btn-info" runat="server" OnClick="btnUpdte_Click" Visible="false"/>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Book Information");
        });
    </script>
</asp:Content>
