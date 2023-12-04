<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Madrasah_Payment_Return.aspx.cs" Inherits="BLL.Mkt_Madrasah_Payment_Return" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">

    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Donation Payment Return
                </div>
                <div class="panel-body">
                    <div class="row">

                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlAgreementYear" Text="Session" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlAgreementYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="txtAgreementNo_TextChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtAgreementNo" CssClass="col-md-4 control-label no-padding-right" Text="SL No"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtAgreementNo" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtAgreementNo_TextChanged" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlMadSomPer" CssClass="col-md-4 control-label no-padding-right" Text="Mad/Somitee/Pers"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlMadSomPer" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMadSomPer_SelectedIndexChanged"></asp:DropDownList><br />
                                    <asp:Label ID="lblbudget" runat="server" ForeColor="Blue" Font-Bold="true"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:GridView runat="server" CssClass="table" ID="gvwAgreementAmount" AutoGenerateColumns="False">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SlNo" HeaderText="S_Id" ItemStyle-Width="0px" />
                                        <asp:BoundField DataField="DoDesId" HeaderText="ID" />
                                        <asp:BoundField DataField="DoDescription" HeaderText="Payment Type" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                    </Columns>
                                </asp:GridView>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlDonationType" CssClass="col-md-4 control-label no-padding-right" Text="Donation Type"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlDonationType" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlDonationType_SelectedIndexChanged" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtDeliveredAmt" CssClass="col-md-4 control-label no-padding-right" Text="Delivered Amt"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtDeliveredAmt" runat="server" CssClass="form-control" Enabled="false" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtReturnAmount" CssClass="col-md-4 control-label no-padding-right" Text="Return Amount"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtReturnAmount" runat="server" TextMode="Number" CssClass="form-control" Text="0" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtReturnCause" CssClass="col-md-4 control-label no-padding-right" Text="Return Cause"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtReturnCause" runat="server" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-4">
                                    <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-primary btn-sm pull-left" runat="server" OnClientClick="if (!confirm('Do You Want to Save?')) return false;" OnClick="btnSave_Click" />
                                </div>
                            </div>
                            <br />
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
                open_menu("Madrasah");
            })
    </script>
</asp:Content>
