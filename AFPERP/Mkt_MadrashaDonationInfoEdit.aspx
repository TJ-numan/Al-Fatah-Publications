<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_MadrashaDonationInfoEdit.aspx.cs" Inherits="BLL.Mkt_MadrashaDonationInfoEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Update Education Development Cost 
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6">
                            <asp:UpdatePanel ID="UpPanel1" runat="server">
                                <ContentTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lbltempAmount" runat="server" Visible="false"></asp:Label>
                                        <asp:Label AssociatedControlID="txtTeritorySL" Text="Teritory SL" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox CssClass="form-control" ID="txtTeritorySL" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtAgreementNo" Text="Agreement No" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox CssClass="form-control" ID="txtAgreementNo" runat="server" MaxLength="4" AutoPostBack="True" OnTextChanged="txtAgreementNo_TextChanged" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlAgreementYear" Text="Agreement Year" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList CssClass="form-control" ID="ddlAgreementYear" runat="server">
                                                
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <%--    <asp:UpdatePanel ID="UpdateArea1" runat="server">
                                        <ContentTemplate>--%>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlDistrict" Text="Select District" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList CssClass="form-control" ID="ddlDistrict" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlThana" Text="Select Thana" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList CssClass="form-control" ID="ddlThana" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <%--   </ContentTemplate>
                            </asp:UpdatePanel>--%>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <br />
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlDonationFor" Text="Donation For" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control chkStore" ID="ddlDonationFor" runat="server">
                                    </asp:DropDownList>
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
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Panel ID="pnlNumofStudent" runat="server" Visible="false">

                                    <div class="form-group ">
                                        <asp:Label AssociatedControlID="ddlMadrashaLevel" Text="Madrasha Level" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList CssClass="form-control" ID="ddlMadrashaLevel" runat="server" />
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
                                    <div class="row">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th>Total Student</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtTotalStudent" CssClass="calc-total"></asp:TextBox></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </asp:Panel>
                            </div>
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
                            <fieldset class="fsStyle">
                                <legend class="legendStyle">Vice principle</legend>
                                <div class="form-group ">
                                    <asp:Label AssociatedControlID="txtSec_ViceP" Text="VicePrin/Secretary" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                    <div class="col-md-6">
                                        <asp:TextBox CssClass="form-control" ID="txtSec_ViceP" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group ">
                                    <asp:Label AssociatedControlID="txtSec_VicePCont" Text="Contact No" CssClass="col-md-3 control-label" runat="server"></asp:Label>

                                    <div class="col-md-6">
                                        <asp:TextBox CssClass="form-control" ID="txtSec_VicePCont" runat="server" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        
                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-1">
                            <asp:Button ID="btnUpdate" runat="server" OnClientClick="if (!confirm('Do You Want to Save?')) return false;" CssClass="btn btn-success pull-right" Text="Update" OnClick="btnUpdate_Click" />
                            <asp:Button ID="btnRefresh" runat="server" CssClass="btn btn-success pull-left" Text="Refresh" Visible="false"/>
                        </div>
                    </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <asp:UpdatePanel ID="UpdateArea2" runat="server">
                                <ContentTemplate>
                                    <fieldset class="fsStyle">
                                        <legend class="legendStyle">Donation</legend>
                                        <%--                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="ddlDonationType" CssClass="col-md-4 control-label no-padding-right" Text="Select Donation Type"></asp:Label>
                                            <div class="col-md-6">
                                                <asp:DropDownList ID="ddlDonationType" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="txtAmount2" CssClass="col-xs-4 control-label no-padding-right" Text="Amount"></asp:Label>
                                            <div class="col-md-6">
                                                <asp:TextBox ID="txtAmount2" TextMode="Number" CssClass="form-control" runat="server" />
                                            </div>
                                        </div>--%>
                                        <%--<div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="txtTerBudgAmt" ID="lblTerBudgAmt" Text="Teritory Budget" CssClass="col-xs-4 control-label no-padding-right"></asp:Label>
                                            <div class="col-md-6">
                                                <asp:TextBox runat="server" ID="txtTerBudgAmt" ReadOnly="true" TabIndex="501"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="txtTerBudgAmtPaid" ID="lblTerBudgAmtPaid" Text="Paid Amount" CssClass="col-xs-4 control-label no-padding-right"></asp:Label>
                                            <div class="col-md-6">
                                                <asp:TextBox runat="server" ID="txtTerBudgAmtPaid" ReadOnly="true" TabIndex="502"></asp:TextBox>
                                            </div>
                                        </div>--%>
                                        <div>
                                            <asp:GridView ID="gvwDonationType" runat="server" CssClass="table" DataKeyNames="Amount" AutoGenerateColumns="false" OnRowEditing="gvwDonationType_RowEditing"  OnRowUpdating="gvwDonationType_RowUpdating">
                                                <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                                <Columns>
                                                    <asp:BoundField DataField="DetId" HeaderText="DetId" ReadOnly="true" />
                                                    <asp:BoundField DataField="DoDesId" HeaderText="DoDesId" ReadOnly="true" />
                                                    <asp:BoundField DataField="DoDescription" HeaderText="Don Type" ReadOnly="true" />
                                                    <asp:TemplateField HeaderText="Product Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount")%>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtAmount" runat="server" Text='<%# Eval("Amount")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:CommandField ShowEditButton="True"/>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </fieldset>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
<%--                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-1">
                            <asp:Button ID="btnUpdate" runat="server" OnClientClick="if (!confirm('Do You Want to Save?')) return false;" CssClass="btn btn-success pull-right" Text="Update" />
                            <asp:Button ID="btnRefresh" runat="server" CssClass="btn btn-success pull-left" Text="Refresh" Visible="false"/>
                        </div>
                    </div>--%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">

</asp:Content>
