<%@ Page Title="" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_CoverBill.aspx.cs" Inherits="BLL.Pro_CoverBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">

<%--    <asp:UpdatePanel runat="server">
        <ContentTemplate>--%>
            <div class="form-horizontal clearfix" runat="server">
                <div class="panel-body" style="border: 1px solid #BDC3CA">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Cover Bill
                        </div>

                        <%--<div id="frmLaminationParty" runat="server" class="form-horizontal clearfix">--%>
                        <div class="panel-body">
                            <div class="col-md-12 no-padding clearfix">
                                <div class="col-md-6 clearfix">

                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="dtpBillDate" CssClass="col-md-4 control-label" Text="Bill Date" runat="server"></asp:Label>
                                        <div class="col-md-7">
                                            <asp:TextBox CssClass="form-control" ID="dtpBillDate" placeholder="yyyy/mm/dd" runat="server" />
                                            <ajaxToolkit:CalendarExtender TargetControlID="dtpBillDate" Format="yyyy/MM/dd" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtBillNo" CssClass="col-md-4 control-label" Text="Bill No" runat="server"></asp:Label>
                                        <div class="col-md-7">
                                            <asp:TextBox CssClass="form-control" ID="txtBillNo" placeholder="Order No" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlCategory" CssClass="col-md-4 control-label" Text="Category" runat="server"></asp:Label>
                                        <div class="col-md-7">
                                            <asp:DropDownList CssClass="form-control" ID="ddlCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlGroup" CssClass="col-md-4 control-label" Text="Group" runat="server"></asp:Label>
                                        <div class="col-md-7">
                                            <asp:DropDownList CssClass="form-control" ID="ddlGroup" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlClass" CssClass="col-md-4 control-label" Text="Class" runat="server"></asp:Label>
                                        <div class="col-md-7">
                                            <asp:DropDownList CssClass="form-control" ID="ddlClass" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlType" CssClass="col-md-4 control-label" Text="Type" runat="server"></asp:Label>
                                        <div class="col-md-7">
                                            <asp:DropDownList CssClass="form-control" ID="ddlType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlBookName" CssClass="col-md-4 control-label" Text="Book Name" runat="server"></asp:Label>
                                        <div class="col-md-7">
                                            <asp:DropDownList CssClass="form-control" ID="ddlBookName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBookName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlEdition" CssClass="col-md-4 control-label" Text="Edition" runat="server"></asp:Label>
                                        <div class="col-md-7">
                                            <asp:DropDownList CssClass="form-control" ID="ddlEdition" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlSource" CssClass="col-md-4 control-label" Text="Source" runat="server"></asp:Label>
                                        <div class="col-md-7">
                                            <asp:DropDownList CssClass="form-control" ID="ddlSource" runat="server" OnSelectedIndexChanged="ddlCoverSource_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">Press</asp:ListItem>
                                                <asp:ListItem Value="2">Lemination</asp:ListItem>
                                                <asp:ListItem Value="3">Plastic Cover</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlSupplier" CssClass="col-md-4 control-label" Text="Supplier" runat="server"></asp:Label>
                                        <div class="col-md-7">
                                            <asp:DropDownList CssClass="form-control" ID="ddlSupplier" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group" style="display: none">
                                        <asp:Label AssociatedControlID="ddlReceiveType" CssClass="col-md-4 control-label" Text="Receive Type" runat="server"></asp:Label>
                                        <div class="col-md-7">
                                            <asp:DropDownList CssClass="form-control" ID="ddlReceiveType" runat="server" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <%--grid table--%>
                            <div class="col-md-12 clearfix table-responsive">
                                <asp:GridView ID="gvwCoverBill" runat="server" CssClass="table grid-view" AutoGenerateColumns="false">
                                    <Columns>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelect_CheckedChanged" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ReceiveID" HeaderText="ReceiveID" />
                                        <asp:BoundField DataField="ReceiveDate" HeaderText="Receive Date" DataFormatString="{0:yyyy-MM-dd}" />
                                        <asp:BoundField DataField="Qty" HeaderText="Quantity" />
                                        <asp:BoundField DataField="ReceiveMemo" HeaderText="Receive Memo" />
                                        <asp:BoundField DataField="LemiSize" HeaderText="Lemination Size" />
                                        <asp:BoundField DataField="SqInch" HeaderText="Square Inch" />
                                        <asp:BoundField DataField="TotalSqlInch" HeaderText="Total Square Inch" />
                                    </Columns>
                                </asp:GridView>
                            </div>

                            <div class="col-md-12 no-padding clearfix">
                                <div class="col-md-8">
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtTotalQty" CssClass="col-xs-4 no-padding-right control-label" Text="Total Qty" runat="server"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox CssClass="form-control coverbill" ID="txtTotalQty" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtBillRate" CssClass="col-xs-4 no-padding-right control-label" Text="Bill Rate" runat="server"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox CssClass="form-control coverbill" ID="txtBillRate" runat="server" Text="0"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtTotalBill" CssClass="col-xs-4 no-padding-right control-label" Text="Total Bill" runat="server"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox CssClass="form-control coverbill-tot" ID="txtTotalBill" runat="server" placeholder="0"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12 no-padding clearfix">
                                <div class="form-group">
                                    <div class="col-xs-8 col-xs-offset-4">
                                        <asp:Button ID="btnPrintBillPrint" Text="Print" CssClass="btn btn-danger" runat="server" OnClick="btnPrintBillPrint_Click" />
                                        <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSPro" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {

            calculateMult(".coverbill", ".coverbill-tot");

            $(".coverbill").on("keyup", function () {
                calculateMult(".coverbill", ".coverbill-tot");
            });

        });

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
        
        // bind elements after postback
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_pageLoaded(calculateMult);

    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Cover");
        });
    </script>
</asp:Content>
