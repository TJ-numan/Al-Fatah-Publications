<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="RndPestingOrder.aspx.cs" Inherits="BLL.RndPestingOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
   <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Pasting Order
                </div>
                <%--<div id="frmPastingPartyInfo" class="form-horizontal clearfix" runat="server">--%>
                <div class="panel-body">
                    <div>
                        <div class="col-md-7">
                            <fieldset class="fsStyle">
                                <legend class="legendStyle">Book Info</legend>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtOrderNo" CssClass="col-md-4 control-label" Text="Order No" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:TextBox CssClass="form-control" ID="txtOrderNo" placeholder="Order No" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="dtpWorkingDate" CssClass="col-md-4 control-label" Text="Working Date" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:TextBox CssClass="form-control date" ID="dtpWorkingDate" placeholder="yyyy/mm/dd" runat="server" />
                                        <ajaxToolkit:CalendarExtender TargetControlID="dtpWorkingDate" Format="yyyy/MM/dd" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlPartyName" CssClass="col-md-4 control-label" Text="Party Name" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:DropDownList CssClass="form-control" ID="ddlPartyName" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlCategory" CssClass="col-md-4 control-label" Text="Category" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:DropDownList CssClass="form-control" ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlGroup" CssClass="col-md-4 control-label" Text="Group" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:DropDownList CssClass="form-control" ID="ddlGroup" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlClass" CssClass="col-md-4 control-label" Text="Class" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:DropDownList CssClass="form-control" ID="ddlClass" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlType" CssClass="col-md-4 control-label" Text="Type" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:DropDownList CssClass="form-control" ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlBookName" CssClass="col-md-4 control-label" Text="Book Name" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:DropDownList CssClass="form-control" ID="ddlBookName" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtEdition" CssClass="col-md-4 control-label" Text="Edition" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:TextBox CssClass="form-control" ID="txtEdition" runat="server">
                                        </asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtExam" CssClass="col-md-4 control-label" Text="Exam" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:TextBox CssClass="form-control" ID="txtExam" placeholder="Exam" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlPestingType" CssClass="col-md-4 control-label" Text="Pasting Type" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:DropDownList CssClass="form-control" ID="ddlPestingType" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlBookSize" CssClass="col-md-4 control-label" Text="Size" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:DropDownList CssClass="form-control" ID="ddlBookSize" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="col-md-4">
                            <fieldset class="fsStyle">
                                <legend class="legendStyle">Pages</legend>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtInner" CssClass="col-md-6 control-label" Text="Inner" runat="server"></asp:Label>
                                    <div class="col-md-5">
                                        <asp:TextBox CssClass="form-control calc" ID="txtInner" runat="server" AutoPostBack="false" OnTextChanged="txtInner_TextChanged" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtSuggestion" CssClass="col-md-6 control-label" Text="Suggestion" runat="server"></asp:Label>
                                    <div class="col-md-5">
                                        <asp:TextBox CssClass="form-control calc" ID="txtSuggestion" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtIndex" CssClass="col-md-6 control-label" Text="Index" runat="server"></asp:Label>
                                    <div class="col-md-5">
                                        <asp:TextBox CssClass="form-control calc" ID="txtIndex" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtMainPart" CssClass="col-md-6 control-label" Text="Main Part" runat="server"></asp:Label>
                                    <div class="col-md-5">
                                        <asp:TextBox CssClass="form-control calc" ID="txtMainPart" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtLastPart" CssClass="col-md-6 control-label" Text="Last Part" runat="server"></asp:Label>
                                    <div class="col-md-5">
                                        <asp:TextBox CssClass="form-control calc" ID="txtLastPart" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtTotalPages" CssClass="col-md-6 control-label" Text="Total Page" runat="server"></asp:Label>
                                    <div class="col-md-5">
                                        <asp:TextBox CssClass="form-control calc-total" ID="txtTotalPages" runat="server" ReadOnly="true" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div>
                        <div class="col-md-12">
                            <fieldset class="fsStyle">
                                <legend class="legendStyle">Forma Details</legend>
                                <div class="table-responsive">
                                    <table class="table no-head-padding">
                                        <tr>
                                            <th></th>
                                            <th>
                                                <asp:Label runat="server" Text="4 Color"></asp:Label>
                                            </th>
                                            <th>
                                                <asp:Label runat="server" Text="2 Color"></asp:Label>
                                            </th>
                                            <th>
                                                <asp:Label runat="server" Text="1 Color"></asp:Label>
                                            </th>
                                            <th>
                                                <asp:Label runat="server" Text="Black"></asp:Label>
                                            </th>
                                            <th>
                                                <asp:Label runat="server" Text="Total"></asp:Label>
                                            </th>
                                            <th>
                                                <asp:Label runat="server" Text="Machine"></asp:Label>
                                            </th>
                                            <th>
                                                <asp:Label runat="server" Font-Names="SutonnyMJ" Text="dg©vi weeiY"></asp:Label>
                                            </th>
                                        </tr>
                                        <tr id="inner">
                                            <th>
                                                <asp:Label ID="lbl_inner" runat="server" Text="Inner" Font-Size="Large"></asp:Label>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txt_inner4color" CssClass="form-control calc-inner" runat="server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_inner2color" CssClass="form-control calc-inner" runat="server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_inner1color" CssClass="form-control calc-inner" runat="server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_innerBlack" CssClass="form-control calc-inner" runat="server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_innerTotal" CssClass="form-control calc-inner-total calc-t" runat="server" ContentEditable="false"/>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlinnerMachine" CssClass="form-control" runat="server">
                                                    <asp:ListItem Value="1">Offset</asp:ListItem>
                                                    <asp:ListItem Value="2">Web</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_innerFormaDetails" CssClass="form-control" Font-Names="SutonnyMJ" runat="server" />
                                            </td>
                                        </tr>
                                        <tr id="forma">
                                            <th>
                                                <asp:Label ID="lbl_forma" runat="server" Text="Forma" Font-Size="Large"></asp:Label>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txt_forma4color" CssClass="form-control calc-forma" runat="server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_forma2color" CssClass="form-control calc-forma" runat="server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_forma1color" CssClass="form-control calc-forma" runat="server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_formaBlack" CssClass="form-control calc-forma" runat="server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_formaTotal" CssClass="form-control calc-forma-total calc-t" runat="server"  ContentEditable="false"  />
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlformaMachine" CssClass="form-control" runat="server">
                                                    <asp:ListItem Value="1">Offset</asp:ListItem>
                                                    <asp:ListItem Value="2">Web</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_formaFormaDetails" CssClass="form-control" Font-Names="SutonnyMJ" runat="server" />
                                            </td>
                                        </tr>
                                        <tr id="postani">
                                            <th>
                                                <asp:Label ID="lbl_postani" runat="server" Text="Postani" Font-Size="Large"></asp:Label>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txt_postani4color" CssClass="form-control calc-postani" runat="server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_postani2color" CssClass="form-control calc-postani" runat="server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_postani1color" CssClass="form-control calc-postani" runat="server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_postaniBlack" CssClass="form-control calc-postani" runat="server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_postaniTotal" CssClass="form-control calc-postani-total calc-t" runat="server" ContentEditable="false"  />
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlpostaniMachine" CssClass="form-control" runat="server">
                                                    <asp:ListItem Value="1">Offset</asp:ListItem>
                                                    <asp:ListItem Value="2">Web</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_postaniFormaDetails" CssClass="form-control" Font-Names="SutonnyMJ" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8">
                                                <div class="form-group">
                                                    <asp:Label AssociatedControlID="txtTotalQty" CssClass="col-xs-4 control-label" Text="Total Qty" runat="server"></asp:Label>
                                                    <div class="col-xs-3">
                                                        <asp:TextBox CssClass="form-control calc-grand-t" ID="txtTotalQty" placeholder="0" runat="server"   ContentEditable="false"/>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <div>
                                    </div>
                                </div>

                            </fieldset>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <table class="table table-bordered">
                                <tr>
                                    <td>
                                        <asp:Label AssociatedControlID="txtFormaNoPestingBill" runat="server" Text="Forma No of Pesting bill"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control formabill" ID="txtFormaNoPestingBill" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label AssociatedControlID="txtformaRate" runat="server" Text="Forma Rate"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control formabill" ID="txtformaRate" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label AssociatedControlID="txtAmount" runat="server" Text="Amount"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control formabill-tot" ID="txtAmount" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="form-group">
                            <div class="col-md-11 col-md-offset-0">
                                <asp:Button ID="btnPOSave" Text="Save" CssClass="btn btn-success pull-right" runat="server" OnClick="btnPOSave_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSRandD" runat="server">
        <script type="text/javascript">
            $(document).ready(function () {

                calculateSum(".calc", ".calc-total");
                calculateSum(".calc-inner", ".calc-inner-total");
                calculateSum(".calc-forma", ".calc-forma-total");
                calculateSum(".calc-postani", ".calc-postani-total");
                calculateSum(".calc-t", ".calc-grand-t");
                calculateMult(".formabill", ".formabill-tot");

                $(".calc").on("keyup", function () {
                    calculateSum(".calc", ".calc-total");
                });
                $(".calc-inner").on("keyup", function () {
                    calculateSum(".calc-inner", ".calc-inner-total");
                });
                $(".calc-forma").on("keyup", function () {
                    calculateSum(".calc-forma", ".calc-forma-total");
                });
                $(".calc-postani").on("keyup", function () {
                    calculateSum(".calc-postani", ".calc-postani-total");
                });
                $(".form-control").on("keyup", function () {
                    calculateSum(".calc-t", ".calc-grand-t");
                });

                $(".formabill").on("keyup", function () {
                    calculateMult(".formabill", ".formabill-tot");
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
            open_menu("Pesting");
        });
    </script>
</asp:Content>
