<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_MadrashaDonationPayment.aspx.cs" Inherits="BLL.Mkt_MadrashaDonationPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Donation Payment
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtLetterNo" CssClass="col-md-4 control-label no-padding-right" Text="Letter No"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtLetterNo" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtLetterNo_TextChanged" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:GridView runat="server" CssClass="table table-bordered " ID="gvwletter" AutoGenerateColumns="False">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkDonSelect" runat="server" AutoPostBack="true" OnCheckedChanged="chkDonSelect_CheckedChanged" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="AgrNo" HeaderText="Agr No" />
                                        <asp:BoundField DataField="MadSomity" HeaderText="Mad/ Somity" />
                                        <asp:BoundField DataField="TeritoryName" HeaderText="Teritory" />
                                        <asp:BoundField DataField="Donation" HeaderText="Donation" />
                                        <asp:BoundField DataField="PrevPayment" HeaderText="Prev Payment" />
                                        <asp:BoundField DataField="DemandAmnt" HeaderText="Demand Amnt" />
                                        <asp:BoundField DataField="DueAmnt" HeaderText="Due Amnt" />
                                        <asp:BoundField DataField="PayTypName" HeaderText="Pay Type" />
                                        <%--<asp:BoundField DataField="AccountTitle" HeaderText="Account Title_En" />--%>
                                        <asp:BoundField DataField="AccountTitle_bn" HeaderText="Account Title_Bn" ItemStyle-Font-Names="SutonnyMJ" />
                                        <asp:BoundField DataField="AccountNo" HeaderText="Acc. No" />
                                        <asp:BoundField DataField="AcTypeName" HeaderText="Acc. Type" />
                                        <asp:BoundField DataField="BankName" HeaderText="Bank Name" />
                                        <asp:BoundField DataField="Branch" HeaderText="Branch" />
                                        <%--                                        <asp:BoundField DataField="Addres" HeaderText="Address" />--%>
                                        <%--                                        <asp:BoundField DataField="ContactNo" HeaderText="ContactNo" />--%>
                                        <asp:TemplateField HeaderText="Payment Method/ Memo No">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtPayMedium" runat="server" data-field="pro-rate" Enabled="false" CssClass="click pro-rate" Width="70px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Challan Value">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtChallanValue" runat="server" data-field="pro-rate" Enabled="false" CssClass="click pro-rate" Width="70px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Payment Date">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtpayDate" runat="server" data-field="pro-rate" Enabled="false" CssClass="click pro-rate" Width="70px" placeholder="yyyy-mm-dd"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtpayDate" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="PSId" HeaderText="SId" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-4">
                                    <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-lock pull-right" runat="server" OnClientClick="if (!confirm('Do You Want to Save?')) return false;" OnClick="btnSave_Click" />
                                </div>
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
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Madrasah");
        })
    </script>
</asp:Content>
