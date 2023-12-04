<%@ Page Title="Donation Information" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_MadrashaDonationInfo.aspx.cs" Inherits="BLL.Mkt_MadrashaDonationInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <%--       <asp:UpdatePanel runat="server">
        <ContentTemplate>--%>
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Education Development Cost
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6">

                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlAgreementYear" Text="Session" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlAgreementYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAgreementYear_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlTerritory" Text="Select Teritory" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlTerritory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAgreementYear_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>



                            <asp:GridView ID="gvBudgetAndPaid" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
                                <Columns>

                                    <asp:BoundField DataField="DoDesID" HeaderText="DoDesID" SortExpression="DoDesID" />
                                    <asp:BoundField DataField="DoDescription" HeaderText="DoDescription" />
                                    <asp:BoundField DataField="DonationBudget" HeaderText="DonationBudget" />
                                    <asp:BoundField DataField="PaidBudget" HeaderText="PaidBudget" />
                                    <asp:BoundField DataField="RestAmount" HeaderText="RestAmount" />


                                </Columns>
                            </asp:GridView>

                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlDonationFor" Text="Donation For" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control chkStore" ID="ddlDonationFor" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDonationFor_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-danger" OnClick="btnEdit_Click" />
                            </div>
                            <br />

                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtAgreementNo" Text="SL No" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtAgreementNo" runat="server" MaxLength="4" AutoPostBack="True" OnTextChanged="txtAgreementNo_TextChanged" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblEIINNo" AssociatedControlID="txtEIINNo" CssClass="col-md-4 control-label" Text="EIIN No"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtEIINNo" runat="server" CssClass="form-control" TextMode="Number" AutoPostBack="true" OnTextChanged="txtEIINNo_TextChanged" />
                                </div>
                            </div>







                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlMadrasah" ID="lblMadrasah" Text="Select Madrasah" CssClass="col-md-4 control-label" Visible="false" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlMadrasah" runat="server" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="ddlMadrasah_SelectedIndexChanged" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtName" Text="Name" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtName" TextMode="MultiLine" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtVillRoBaz" Text="Vill/Road/Bazar" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtVillRoBaz" runat="server" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtPostOffice" Text="Post Office" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtPostOffice" runat="server" />
                                </div>
                            </div>
                            <div class="form-group ">
                                <asp:Label AssociatedControlID="txtPhoneNo" Text="Phone No" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtPhoneNo" runat="server" />
                                </div>
                            </div>



                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlDistrict" Text="Select District" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlDistrict" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlThana" Text="Select Thana" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlThana" runat="server" AutoPostBack="false"></asp:DropDownList>
                                </div>
                            </div>

                           <%--<fieldset class="fsStyle" style="background-color: antiquewhite">
                                <legend class="legendStyle">তথ্য প্রদানকারী</legend>
                                <div class="clearfix table-responsive">
                                    <table class=" table-responsive table no-head-padding ">
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" AssociatedControlID="txtInformerName" CssClass="control-label" Text="নাম"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" AssociatedControlID="txtResponsibility" CssClass="control-label" Text="দায়িত্ব"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" AssociatedControlID="txtInformerMobileNo" CssClass="control-label" Text="মোবাইল"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chk" runat="server" Text="Copy"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 200px">
                                                <asp:TextBox runat="server" ID="txtInformerName" CssClass="form-control" />
                                            </td>

                                            <td style="width: 150px">
                                                <asp:TextBox runat="server" ID="txtResponsibility" CssClass="form-control" />
                                            </td>

                                            <td style="width: 150px">
                                                <asp:TextBox runat="server" ID="txtInformerMobileNo" CssClass="form-control" />
                                            </td>


                                            <td>
                                                <asp:Button runat="server" ID="btnInformerAdd" CssClass="btn btn-primary newReturnAdd" Text="Add" OnClick="btnInformerAdd_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="col-md-12  no-padding ">
                                    <div class="clearfix table-responsive">
                                        <asp:GridView ID="gvwInformer" runat="server" AutoGenerateColumns="False" CssClass="table">
                                            <HeaderStyle BackColor="#c1d4f2" ForeColor="#2A3542"></HeaderStyle>
                                            <Columns>
                                                <asp:BoundField HeaderStyle-Width="20px" HeaderText="SL" DataField="Serial" />
                                                <asp:BoundField HeaderStyle-Width="200px" HeaderText="নাম" DataField="InformerName" />
                                                <asp:BoundField HeaderStyle-Width="150px" HeaderText="দায়িত্ব" DataField="Responsibility" />
                                                <asp:BoundField HeaderStyle-Width="100px" HeaderText="মোবাইল" DataField="Mobile" />
                                                <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="60px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lblInfoDelete" runat="server" CommandArgument='<%#Eval("Serial") %>' OnClick="lblInfoDelete_Click">
                                                 Delete
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtReceivedInfos" CssClass="col-xs-4 control-label no-padding-left" Text="প্রাপ্ত তথ্য সমূহ">
                                    </asp:Label>

                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtReceivedInfos" runat="server" CssClass="form-control" Font-Names="SutonnyMJ" TextMode="MultiLine" />

                                    </div>

                                    <asp:Label runat="server" AssociatedControlID="txtProblems" CssClass="col-xs-4 control-label no-padding-left" Text="সমস্যা">
                                    </asp:Label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtProblems" runat="server" CssClass="form-control" Font-Names="SutonnyMJ" TextMode="MultiLine"></asp:TextBox>

                                    </div>
                                    <div class="col-xs-8">
                                        </br>
                                    </div>
                                    <div class="col-xs-8">
                                        <asp:Button ID="btnSaveInformer" runat="server" CssClass="btn btn-success pull-left" Text="Save POR" OnClick="btnSaveInformer_Click"></asp:Button>
                                        <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary pull-right" runat="server"/>
                                        <asp:Button ID="btnPrintPOR" Text="Print POR" CssClass="btn btn-info pull-right" runat="server" OnClick="btnPrintPOR_Click"/>
                                    </div>

                                </div>
                            </fieldset> --%>
 

                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Panel ID="pnlNumofStudent" runat="server" Visible="false">

                                    <div class="form-group ">
                                        <asp:Label AssociatedControlID="ddlMadrashaLevel" Text="Madrasha Level" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList CssClass="form-control" ID="ddlMadrashaLevel" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlMadrashaLevel_SelectedIndexChanged" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <table class="table table-bordered table-striped">
                                            <thead>
                                                <tr>
                                                    <th>Children</th>
                                                    <th>One</th>
                                                    <th>Two</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtChildren" CssClass="calc form-control" TextMode="Number"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtClassOne" CssClass="calc form-control" TextMode="Number"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtClassTwo" CssClass="calc form-control" TextMode="Number"></asp:TextBox></td>

                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="row">
                                        <table class="table table-bordered table-striped">
                                            <thead>
                                                <tr>
                                                    <th>Three</th>
                                                    <th>Four</th>
                                                    <th>Five</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtClassThree" CssClass="calc form-control" TextMode="Number"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtClassFour" CssClass="calc form-control" TextMode="Number"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtClassFive" CssClass="calc form-control" TextMode="Number"></asp:TextBox></td>

                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="row">
                                        <table class="table table-bordered table-striped">
                                            <thead>
                                                <tr>
                                                    <th>Six</th>
                                                    <th>Seven</th>
                                                    <th>Eight</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtClassSix" CssClass="calc form-control" TextMode="Number"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtClassSeven" CssClass="calc form-control" TextMode="Number"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtClassEight" CssClass="calc form-control" TextMode="Number"></asp:TextBox></td>

                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="row">
                                        <table class="table table-bordered table-striped">
                                            <thead>
                                                <tr>
                                                    <th>Nine</th>
                                                    <th>Ten</th>
                                                    <th>Alim First Year</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtClassNine" CssClass="calc form-control" TextMode="Number"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtClassTen" CssClass="calc form-control" TextMode="Number"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtAlim_1stY" CssClass="calc form-control" TextMode="Number"></asp:TextBox></td>

                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="row">
                                        <table class="table table-bordered table-striped">
                                            <thead>
                                                <tr>
                                                    <th>Alim Second Year</th>
                                                    <th>Fazil First Year</th>
                                                    <th>Fazil 2nd Year</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtAlim_2ndY" CssClass="calc form-control" TextMode="Number"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtFazil_1stY" CssClass="calc form-control" TextMode="Number"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtFazil_2ndY" CssClass="calc form-control" TextMode="Number"></asp:TextBox></td>

                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="row">
                                        <table class="table table-bordered table-striped">
                                            <thead>
                                                <tr>
                                                    <th>Fazil 3rd Year</th>
                                                    <th>Kamil First Year</th>
                                                    <th>Kamil 2nd Year</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtFazil_3rdY" CssClass="calc form-control" TextMode="Number"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtKamil_1stY" CssClass="calc form-control" TextMode="Number"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtKamil_2ndY" CssClass="calc form-control" TextMode="Number"></asp:TextBox></td>

                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="row">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th>Total Student</th>
                                                    <%--  <th>Total Budget</th>
                                                    <th>Per Student Cost</th>--%>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtTotalStudent" CssClass="calc-total  form-control"></asp:TextBox></td>
                                                    <%-- <td> 
                                                           <asp:TextBox runat="server" ID="txtTotalBudget"></asp:TextBox></td>
                                                    <td> 
                                                           <asp:TextBox runat="server" ID="txtPerStudCost"></asp:TextBox></td>--%>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </asp:Panel>
                            </div>
                            <asp:Panel ID="plnSecretary" runat="server">
                                <fieldset class="fsStyle">
                                    <legend class="legendStyle">Principle</legend>
                                    <div class="form-group ">
                                        <asp:Label AssociatedControlID="txtChair_Prin" Text="Principle/Chairman" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox CssClass="form-control" ID="txtChair_Prin" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group ">
                                        <asp:Label AssociatedControlID="txtChair_PrinCont" Text="Contact No" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox CssClass="form-control" ID="txtChair_PrinCont" runat="server" />
                                        </div>
                                    </div>
                                </fieldset>
                                <%--<fieldset class="fsStyle">--%>
                                <%--<legend class="legendStyle">Vice principle</legend>--%>
                                <div class="form-group ">
                                    <asp:Label AssociatedControlID="txtSec_ViceP" Text="VicePrin/Secretary" Visible="false" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                    <div class="col-md-6">
                                        <asp:TextBox CssClass="form-control" ID="txtSec_ViceP" runat="server" Visible="false" />
                                    </div>
                                </div>
                                <div class="form-group ">
                                    <asp:Label AssociatedControlID="txtSec_VicePCont" Text="Contact No" Visible="false" CssClass="col-md-3 control-label" runat="server"></asp:Label>

                                    <div class="col-md-6">
                                        <asp:TextBox CssClass="form-control" ID="txtSec_VicePCont" runat="server" Visible="false" />
                                    </div>
                                </div>
                                <%--</fieldset>--%>
                            </asp:Panel>
                        </div>

                    </div>


                    <div class="row">
                        <div class="col-md-6">

                            <fieldset class="fsStyle">
                                <legend class="legendStyle">Donation</legend>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="ddlDonationType" CssClass="col-md-4 control-label no-padding-right" Text="Select Donation Type"></asp:Label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlDonationType" runat="server" CssClass="form-control" AutoPostBack="False" OnSelectedIndexChanged="ddlDonationType_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtAmount2" CssClass="col-xs-4 control-label no-padding-right" Text="Amount"></asp:Label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtAmount2" TextMode="Number" CssClass="form-control" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group" style="display: none;">
                                    <asp:Label runat="server" AssociatedControlID="txtTerBudgAmt" ID="lblTerBudgAmt" Text="Teritory Budget" CssClass="col-xs-4 control-label no-padding-right"></asp:Label>
                                    <div class="col-md-6">
                                        <asp:TextBox runat="server" ID="txtTerBudgAmt" ReadOnly="true" TabIndex="501"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group" style="display: none;">
                                    <asp:Label runat="server" AssociatedControlID="txtTerBudgAmtPaid" ID="lblTerBudgAmtPaid" Text="Paid Amount" CssClass="col-xs-4 control-label no-padding-right"></asp:Label>
                                    <div class="col-md-6">
                                        <asp:TextBox runat="server" ID="txtTerBudgAmtPaid" ReadOnly="true" TabIndex="502"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-xs-8 col-xs-offset-4">
                                        <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-sm pull-right" Text="Add" OnClick="btnAdd_Click" />
                                    </div>
                                </div>
                                <div>
                                    <asp:GridView ID="gvwDonationType" runat="server" CssClass="table" AutoGenerateColumns="false">
                                        <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                        <Columns>
                                            <asp:BoundField DataField="Serial" HeaderText="SL" />
                                            <asp:BoundField DataField="DonType" HeaderText="Donation Type" />
                                            <asp:BoundField DataField="Amount" HeaderText="Amount" />
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
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtTotalAmount" CssClass="col-xs-4 control-label no-padding-right" Text="Total Amount">
                                    </asp:Label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtTotalAmount" runat="server" CssClass="form-control" ReadOnly="True" />

                                    </div>
                                    <asp:Label runat="server" AssociatedControlID="txtCountableAmt" CssClass="col-xs-4 control-label no-padding-right" Text="Countable Amount">
                                    </asp:Label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtCountableAmt" runat="server" ReadOnly="true" Text="0"></asp:TextBox>

                                    </div>
                                    <asp:Label runat="server" AssociatedControlID="txtPerStudentCost" CssClass="col-xs-4 control-label no-padding-right" Text="Per Student Cost">
                                    </asp:Label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtPerStudentCost" runat="server" ReadOnly="true"></asp:TextBox>

                                    </div>
                                </div>
                            </fieldset>


                        </div>
                        <div class="col-md-6">
                        </div>
                    </div>



                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-1">
                            <asp:Button ID="btnSave" runat="server" OnClientClick="if (!confirm('Do You Want to Save?')) return false;" CssClass="btn btn-success pull-right" Text="Save" OnClick="btnSave_Click" />
                            <asp:Button ID="btnRefresh" runat="server" CssClass="btn btn-success pull-left" Text="Refresh" OnClick="btnRefresh_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--                    </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {

            calculateSum(".calc", ".calc-total");

            $(".calc").on("keyup", function () {
                calculateSum(".calc", ".calc-total");
            });


            open_menu("Madrasah");
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
            $(total).val(sum.toFixed(0));

        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            if (document.getElementById('_ispostback').value == 1) $('.process-div').removeClass('hidden');
            else $('.process-div').addClass('hidden');
        });
    </script>
<%--    <script type="text/javascript">
        $("#<%= chk.ClientID %>").change(function () {
            var txtPrinName = $("#<%= txtInformerName.ClientID %>").val();
            $("#<%= txtChair_Prin.ClientID %>").val(txtPrinName);

            var txtPrinMob = $("#<%= txtInformerMobileNo.ClientID %>").val();
            $("#<%= txtChair_PrinCont.ClientID %>").val(txtPrinMob);
     });
    </script>--%>

</asp:Content>
