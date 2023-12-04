<%@ Page Title="Cover Print Order" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_PrintOrderCover.aspx.cs" Inherits="BLL.Pro_PrintOrderCover" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="form-horizontal clearfix" runat="server">
                <div class="panel-body" style="border: 1px solid #BDC3CA">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Cover Print Order
                        </div>
                        <div class="panel-body">
                            <div class=" col-md-12 clearfix">
                                <div class="col-md-6 clearfix">
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtOrderNo" CssClass="col-xs-4 control-label" Text="Order No" runat="server"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox CssClass="form-control" ID="txtOrderNo" placeholder="Order No" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="dtpOrderDate" CssClass="col-xs-4 control-label" Text="Order Date"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="dtpOrderDate" runat="server" CssClass="form-control" placeholder="yyyy/mm/dd">
                                            </asp:TextBox>
                                            <ajaxToolkit:CalendarExtender runat="server" Format="yyyy/MM/dd" TargetControlID="dtpOrderDate" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlCategory" CssClass="col-xs-4 control-label" Text="Category" runat="server"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList CssClass="form-control" ID="ddlCategory" runat="server" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlGroup" CssClass="col-xs-4 control-label" Text="Group" runat="server"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList CssClass="form-control" ID="ddlGroup" runat="server" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlClass" CssClass="col-xs-4 control-label" Text="Class" runat="server"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList CssClass="form-control" ID="ddlClass" runat="server" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlType" CssClass="col-xs-4 control-label" Text="Type" runat="server"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList CssClass="form-control" ID="ddlType" runat="server" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlBookName" CssClass="col-sm-4 control-label" Text="Book Name" runat="server"></asp:Label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList CssClass="form-control" ID="ddlBookName" runat="server" OnSelectedIndexChanged="ddlBookName_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="clearfix">
                                        <div class="col-xs-3 col-xs-offset-4 no-padding-left clearfix padding-small-right">
                                            <div class="form-group">
                                                <asp:DropDownList CssClass="form-control" ID="ddlPestingType" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-xs-5 no-padding-right clearfix">
                                            <div class="form-group">
                                                <asp:Label AssociatedControlID="ddlEdition" CssClass="col-xs-3 no-padding-right control-label" Text="Edition" runat="server"></asp:Label>
                                                <div class="col-xs-7">
                                                    <asp:DropDownList CssClass="form-control" ID="ddlEdition" runat="server" OnSelectedIndexChanged="ddlEdition_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6 clearfix">
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlBookSize" CssClass="col-xs-4 control-label" Text="Book Size" runat="server"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList CssClass="form-control" ID="ddlBookSize" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtFormaQty" CssClass="col-xs-4 control-label" Text="Forma Qty" runat="server"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox CssClass="form-control" ID="txtFormaQty" runat="server" />
                                        </div>
                                    </div>
                                    <div class="clearfix">
                                        <div class="col-xs-8 no-padding clearfix padding-small-right">
                                            <div class="form-group">
                                                <asp:Label AssociatedControlID="txtPressPrintQty" CssClass="col-xs-6 control-label" Text="Print Qty" runat="server"></asp:Label>
                                                <div class="col-xs-6">
                                                    <asp:TextBox CssClass="form-control" ID="txtPressPrintQty" runat="server" AutoPostBack="True" OnTextChanged="ddlPaperType_SelectedIndexChanged" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-4 no-padding-right clearfix">
                                            <div class="form-group">
                                                <asp:Label AssociatedControlID="ddlPrintSl" CssClass="col-xs-3 no-padding-right control-label" Text="as" runat="server"></asp:Label>
                                                <div class="col-xs-9">
                                                    <asp:DropDownList CssClass="form-control" ID="ddlPrintSl" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlPressName" CssClass="col-sm-4 control-label" Text="Press Name" runat="server"></asp:Label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList CssClass="form-control" ID="ddlPressName" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlPaperType" CssClass="col-xs-4 control-label" Text="Paper Type" runat="server"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList CssClass="form-control" ID="ddlPaperType" runat="server" OnSelectedIndexChanged="ddlPaperType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlPaperSize" CssClass="col-xs-4 control-label" Text="Paper Size" runat="server"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList CssClass="form-control" ID="ddlPaperSize" runat="server" OnSelectedIndexChanged="ddlPaperSize_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlPaperGsm" CssClass="col-xs-4 control-label" Text="GSM" runat="server"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList CssClass="form-control" ID="ddlPaperGsm" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlBrand" CssClass="col-xs-4 control-label" Text="Brand" runat="server"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList CssClass="form-control" ID="ddlBrand" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <%--table placement--%>
                            <div class="table-responsive col-md-12 clearfix">
                                <table class="table no-head-padding">
                                    <tr>
                                        <td style="width: 120px;">
                                            <asp:Label AssociatedControlID="txtSettingPerSheet" CssClass="control-label no-padding" Text="Setting Per Sheet" runat="server"></asp:Label>
                                        </td>
                                        <td style="width: 80px;">
                                            <asp:TextBox ID="txtSettingPerSheet" runat="server" CssClass="form-control" />
                                        </td>
                                        <td style="width: 105px;">
                                            <asp:Label AssociatedControlID="txtPaperQty" CssClass="control-label no-padding" Text="App. Paper Qty" runat="server"></asp:Label>
                                        </td>
                                        <td style="width: 125px;">
                                            <div class="col-xs-8 no-padding-left">
                                                <asp:TextBox ID="txtPaperQty" ReadOnly="true" runat="server" CssClass="form-control" Text="0" />
                                            </div>
                                            <div class="col-xs-4 no-padding">
                                                <asp:DropDownList ID="ddlPaperUnit" runat="server" CssClass="form-control" />

                                            </div>
                                        </td>
                                        <td style="width: 100px">
                                            <div class="col-xs-3 no-padding">
                                                <asp:Label AssociatedControlID="txtPaperSheetQty" CssClass="control-label no-padding" Text="OR" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-xs-9 no-padding">
                                                <asp:TextBox ID="txtPaperSheetQty" CssClass="form-control Scalc" runat="server" AutoPostBack="True" OnTextChanged="txtPcsPerSheet_TextChanged" />
                                            </div>
                                        </td>
                                        <td style="width: 58px;">
                                            <asp:Label AssociatedControlID="txtPcsPerSheet" runat="server" CssClass="control-label no-padding" Text="Sheet &times;"></asp:Label>
                                        </td>
                                        <td style="width: 50px;">
                                            <asp:TextBox runat="server" ID="txtPcsPerSheet" CssClass="form-control Scalc" OnTextChanged="txtPcsPerSheet_TextChanged" AutoPostBack="true" />
                                        </td>
                                        <td style="width: 100px">
                                            <div class="col-xs-2 no-padding">
                                                <asp:Label AssociatedControlID="txtTotalSheet" runat="server" CssClass="control-label no-padding Scalc-tot" Text=" = "></asp:Label>
                                            </div>
                                            <div class="col-xs-10 no-padding">
                                                <asp:TextBox ID="txtTotalSheet" runat="server" CssClass="form-control" />
                                            </div>
                                        </td>
                                        <td style="width: 100px">
                                            <asp:Label runat="server" CssClass="control-label no-padding" Text="Pieces of Sheet"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <%--table--%>
                            <div class=" col-md-12 clearfix table-responsive">
                                <table class="table no-head-padding">
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" AssociatedControlID="txtUps" Text="Ups"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" AssociatedControlID="txtImpression" Text="Impression"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" AssociatedControlID="txtColorNo" Text="Color No"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" AssociatedControlID="txtBillRate" Text="Rate Per Color"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" AssociatedControlID="txtBillAmount" Text="Total Bill"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" AssociatedControlID="txtPrintingCOthBill" Text="Other Print"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtUps" CssClass="form-control" />
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtImpression" CssClass="form-control" />
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtColorNo" CssClass="form-control" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBillRate" runat="server" CssClass="form-control" placeholder="0" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBillAmount" runat="server" CssClass="form-control" placeholder="0" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPrintingCOthBill" runat="server" CssClass="form-control" placeholder="0" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="col-md-12 col-md-offset-10 no-padding-right clearfix">
                                <div class="form-group">
                                    <asp:Button ID="btnPrintingFAdd" Text="Add" CssClass="btn btn-primary btn-sm" runat="server" OnClick="btnPrintingFAdd_Click" />
                                </div>
                            </div>

                            <%--grid view--%>
                            <div class="table-responsive">
                                <asp:GridView ID="gvwPrintingCShowData" runat="server" CssClass="grid-view table" Align="Center" AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:BoundField DataField="Ups" HeaderText="Ups" />
                                        <asp:BoundField DataField="Impression" HeaderText="Impression" />
                                        <asp:BoundField DataField="ColorNo" HeaderText="Color No" />
                                        <asp:BoundField DataField="BillRate" HeaderText="Rate/Color" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                        <asp:BoundField DataField="CoverQty" HeaderText="Cover Qty" />
                                        <asp:BoundField DataField="OtherPrint" HeaderText="OtherPrint" />
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
                            <div class="col-md-12 clearfix">
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <asp:RadioButton ID="chkShortForma" GroupName="rdoPrintingCChange" runat="server" OnCheckedChanged="chkShortForma_CheckedChanged" AutoPostBack="true" />
                                        <asp:Label AssociatedControlID="chkShortForma" runat="server" Text="Short Cover"></asp:Label>
                                        <br />
                                        <asp:RadioButton ID="chkOther" GroupName="rdoPrintingCChange" runat="server" />
                                        <asp:Label AssociatedControlID="chkOther" runat="server" Text="Other"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-6 no-padding">
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtRemark" CssClass="col-xs-4 no-padding-right control-label" runat="server" Text="Remark"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtRemark" CssClass="form-control" runat="server" placeholder="Remark" TextMode="MultiLine" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4 no-padding-right">
                                    <div>
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="txtTotalImpression" CssClass="col-xs-4 no-padding-right control-label" runat="server" Text="Total Impression"></asp:Label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtTotalImpression" CssClass="form-control" runat="server" placeholder="0" />
                                            </div>
                                        </div>
                                    </div>
                                    <div>
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="txtTotalCover" CssClass="col-xs-4 no-padding-right control-label" runat="server" Text="Total Cover"></asp:Label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtTotalCover" CssClass="form-control" runat="server" placeholder="0" />
                                            </div>
                                        </div>
                                    </div>
                                    <div>
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="txtTotalBill" CssClass="col-xs-4 no-padding-right control-label" runat="server" Text="Total Bill"></asp:Label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtTotalBill" CssClass="form-control" runat="server" placeholder="0" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 clearfix">
                                <div class="form-group">
                                    <div class="col-md-8 col-md-offset-4 clearfix">
                                        <asp:Button ID="btnPrintingCSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnPrintingCSave_Click" />
                                        <asp:Button ID="btnPrintingCSupPlate" Text="Supply Plate" CssClass="btn btn-info" runat="server" OnClick="btnPrintingCSupPlate_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSPro" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {

            calculateMult(".Scalc", ".Scalc-tot");

            $(".Scalc").on("keyup", function () {
                calculateMult(".Scalc", ".Scalc-tot");
            });

        });

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

        //function ConfirmApproval(objMsg) {
        //    if (confirm(objMsg)) {
        //        alert("execute code.");
        //        return true;
        //    }
        //    else
        //        return false;
        //}

        //function Confirm() {
        //    var confirm_value = document.createElement("INPUT");
        //    confirm_value.type = "hidden";
        //    confirm_value.name = "confirm_value";
        //    if (confirm("Do you want to delete data?")) {
        //        confirm_value.value = "Yes";
        //    } else {
        //        confirm_value.value = "No";
        //    }
        //    document.forms[0].appendChild(confirm_value);
        //}

        $(document).ready(function () {
            open_menu("Printing");
        });
    </script>
</asp:Content>
