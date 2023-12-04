<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_MadrashaInfo.aspx.cs" Inherits="BLL.Mkt_MadrashaInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Madrasah Information
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtMadrasahID" Text="Madrasah ID" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtMadrasahID" runat="server" ReadOnly="true" />
                                </div>
                            </div>
                            <br />
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlAgreementYear" Text="Session" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList CssClass="form-control" ID="ddlAgreementYear" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtAgreementNo" CssClass="col-md-4 control-label" Text="SL No"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtAgreementNo" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtAgreementNo_TextChanged" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlSomitee" Text="Select Somitee" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlSomitee" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtEIINNo" CssClass="col-md-4 control-label" Text="EIIN No"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtEIINNo" runat="server" CssClass="form-control" TextMode="Number" AutoPostBack="true" OnTextChanged="txtEIINNo_TextChanged" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtMadrasahName" Text="Madrasah Name" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtMadrasahName" TextMode="MultiLine" runat="server" />
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
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlDristrict" Text="Select District" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList CssClass="form-control" ID="ddlDristrict" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDristrict_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlThana" Text="Select Thana" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList CssClass="form-control" ID="ddlThana" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="form-group ">
                                <asp:Label AssociatedControlID="ddlMadrashaLevel" Text="Madrasha Level" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlMadrashaLevel" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlMadrashaLevel_SelectedIndexChanged" />
                                </div>
                            </div>
                            <div class="form-group ">
                                <asp:Label AssociatedControlID="txtChair_Prin" Text="Principle Name" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtChair_Prin" runat="server" />
                                </div>
                            </div>
                            <div class="form-group ">
                                <asp:Label AssociatedControlID="txtChair_PrinCont" Text="Contact No" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtChair_PrinCont" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
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
                                                <asp:TextBox runat="server" ID="txtChildren" CssClass="calc" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtClassOne" CssClass="calc" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtClassTwo" CssClass="calc" TextMode="Number"></asp:TextBox></td>

                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div class="row">
                                <table class="table table-bordered table-striped table-responsive">
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
                                                <asp:TextBox runat="server" ID="txtClassThree" CssClass="calc" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtClassFour" CssClass="calc" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtClassFive" CssClass="calc" TextMode="Number"></asp:TextBox></td>

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
                                                <asp:TextBox runat="server" ID="txtClassSix" CssClass="calc" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtClassSeven" CssClass="calc" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtClassEight" CssClass="calc" TextMode="Number"></asp:TextBox></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div class="row table-responsive">
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
                                                <asp:TextBox runat="server" ID="txtClassNine" CssClass="calc" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtClassTen" CssClass="calc" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtAlim_1stY" CssClass="calc" TextMode="Number"></asp:TextBox></td>

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
                                                <asp:TextBox runat="server" ID="txtAlim_2ndY" CssClass="calc" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtFazil_1stY" CssClass="calc" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtFazil_2ndY" CssClass="calc" TextMode="Number"></asp:TextBox></td>

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
                                                <asp:TextBox runat="server" ID="txtFazil_3rdY" CssClass="calc" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtKamil_1stY" CssClass="calc" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtKamil_2ndY" CssClass="calc" TextMode="Number"></asp:TextBox></td>

                                        </tr>
                                    </tbody>
                                </table>
                            </div>

                            <div class="form-group">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success pull-left" Text="Save" OnClick="btnSave_Click" OnClientClick="if (!confirm('Do You Want to Save?')) return false;"/>
                                
                            
                                    <asp:TextBox runat="server" ID="txtTotalStudent" ReadOnly="true" CssClass="calc-total pull-right"></asp:TextBox>
                                <asp:Label AssociatedControlID="txtTotalStudent" Text="Total Student" CssClass="col-md-4 control-label pull-right" runat="server"></asp:Label>
                                
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

            calculateSum(".calc", ".calc-total");

            $(".calc").on("keyup", function () {
                calculateSum(".calc", ".calc-total");
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
            $(total).val(sum.toFixed(0));

        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Madrasah");
        })
    </script>
</asp:Content>
