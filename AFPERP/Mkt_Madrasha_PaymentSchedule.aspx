<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Madrasha_PaymentSchedule.aspx.cs" Inherits="BLL.Mkt_Madrasha_PaymentSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
     
            <div class="form-horizontal clearfix" runat="server">
                <div class="panel-body" style="border: 1px solid #BDC3CA">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Payment Schedule
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
                                            <asp:DropDownList ID="ddlMadSomPer" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlMadSomPer_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><br />
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
                                        <asp:Label runat="server" AssociatedControlID="txtAmount" CssClass="col-md-4 control-label no-padding-right" Text="Amount"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtAmount" runat="server" TextMode="Number" CssClass="form-control" Text="0" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtStartingDate" CssClass="col-md-4 control-label no-padding-right" Text="From Date"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtStartingDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                            <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtStartingDate" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtEndingDate" CssClass="col-md-4 control-label no-padding-right" Text="To Date"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtEndingDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                            <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtEndingDate" />
                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <div class="col-md-6 col-md-offset-4">
                                            <asp:Button ID="btnAdd" Text="Add" CssClass="btn btn-primary btn-sm pull-right" runat="server" OnClick="btnAdd_Click" />
                                            <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-danger btn-sm pull-left" runat="server" OnClientClick="if (!confirm('Do You Want to Update?')) return false;" OnClick="btnUpdate_Click" />
                                        </div>


                                    </div>
                                    <br />
                                    <div class="form-group">
                                        <asp:GridView runat="server" CssClass="table" ID="gvwPaymentSchedule" AutoGenerateColumns="False">
                                            <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkDonSelect" runat="server" AutoPostBack="true" OnCheckedChanged="chkDonSelect_CheckedChanged" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Serial" HeaderText="Serial" />
                                                <asp:BoundField DataField="DoDescription" HeaderText="Payment Type" />
                                                <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                                <asp:BoundField DataField="StartingDate" HeaderText="Starting Date" DataFormatString="{0:yyyy-MM-dd}" />
                                                <asp:BoundField DataField="EndingDate" HeaderText="Ending Date" DataFormatString="{0:yyyy-MM-dd}" />
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
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="chkIsBankPay" CssClass="col-md-4 control-label no-padding-right" Text="Is Bank Pay" Visible="false"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:CheckBox ID="chkIsBankPay" runat="server" CssClass="form-control" Visible="false"></asp:CheckBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtAcountName_bn" CssClass="col-md-4 control-label no-padding-right" Text="Account Title"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtAcountName_bn" runat="server" CssClass="form-control" Font-Names="SutonnyMJ"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtAcountName" Visible="false" CssClass="col-md-4 control-label no-padding-right" Text="AC Title/Receiver"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtAcountName" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtAccountNo" Text="AC / Memo No" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox CssClass="form-control" ID="txtAccountNo" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlAcountType" Text="Acount Type" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="ddlAcountType" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlPaymentType" Text="Payment Type" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="ddlPaymentType" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtBankName" Text="Bank/CO Name" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox CssClass="form-control" ID="txtBankName" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtBranchAddress" Text="Branch/Address" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox CssClass="form-control" ID="txtBranchAddress" runat="server" />
                                        </div>
                                    </div>
 
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
 

                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtContactNo" Text="Contact No" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox CssClass="form-control" ID="txtContactNo" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlTransportID" Text="Transport" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList CssClass="form-control" ID="ddlTransportID" runat="server" />
                                        </div>
                                    </div>

                                    <%--                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="chkIsRecAckNo" CssClass="col-md-4 control-label no-padding-right" Text="Is Received Ack No"></asp:Label>
                                <div class="col-md-6">
                                    <asp:CheckBox ID="chkIsRecAckNo" runat="server" CssClass="form-control"></asp:CheckBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtAckNO" Text="Acknowledgement No" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtAckNO" runat="server" />
                                </div>
                            </div>--%>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtRemarks" Text="Remarks" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox CssClass="form-control" ID="txtRemarks" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-6 col-md-offset-4">
                                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success pull-right" runat="server" OnClick="btnSave_Click" OnClientClick="if (!confirm('Do You Want to Save?')) return false;" />
                                            <asp:Button ID="btnRefresh" Text="Refresh" CssClass="btn btn-success pull-left" runat="server" OnClick="btnRefresh_Click" />
                                        </div>
                                    </div>
                                </div>
                                <%--  <div class="col-md-12 clearfix">
                            <div class="form-group">
                                <div class="col-md-6 table-responsive">

                                   <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <fieldset class="fsStyle">
                                    <legend class="legendStyle">Donation</legend>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlDonationType" CssClass="col-md-4 control-label no-padding-right" Text="Select Donation Type"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="ddlDonationType" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtAmount2" CssClass="col-xs-4 control-label no-padding-right" Text="Amount"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtAmount2" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-xs-8 col-xs-offset-4">
                                            <asp:Button ID="btnAdd_Don" runat="server" CssClass="btn btn-primary btn-sm pull-right" Text="Add" OnClick="btnAdd_Don_Click" />
                                        </div>
                                    </div>
                                    <asp:GridView ID="gvwDonationType" runat="server" CssClass="table" AutoGenerateColumns="false">
                                        <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                        <Columns>
                                            <asp:BoundField DataField="Serial" HeaderText="Serial" />

                                            <asp:BoundField DataField="DonType" HeaderText="Donation Type" />
                                            <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbDelete_Don" runat="server" CommandArgument='<%#Eval("Serial") %>' OnClick="lbDelete_Don_Click">
                                                 Delete
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>

                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtTotalAmount" CssClass="col-xs-4 control-label no-padding-right" Text="Total Amount">
                                        </asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtTotalAmount" runat="server" CssClass="form-control" ReadOnly="True" />
                                        </div>
                                    </div>
                                </fieldset>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>--%>
                            </div>
                            <div class="row">
                                <div class="col-md-6">

                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtLetterNo" CssClass="col-md-4 control-label no-padding-right" Text="Letter No"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtLetterNo" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlDonationType" CssClass="col-md-4 control-label no-padding-right" Text="Donation Type"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="ddlDonationType" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-6 col-md-offset-4">
                                            <asp:Button ID="btnAddToLetter" Text="Add To Letter" CssClass="btn btn-primary btn-sm pull-right" runat="server" OnClick="btnAddToLetter_Click" />
                                        </div>
                                    </div>
                                    <%--<fieldset class="fsStyle">
                                        <legend class="legendStyle">Select Type</legend>
                                        <div class="form-group">
                                            <div class="col-md-12 col-md-offset-4">
                                                <label class="radio-inline">
                                                    <asp:RadioButton runat="server" ID="rdbCash" GroupName="Type" Checked="True" />Cash
                                                </label>
                                                <label class="radio-inline">
                                                    <asp:RadioButton runat="server" ID="rdbBook" GroupName="Type" />Book
                                                </label>
                                                <label class="radio-inline">
                                                    <asp:RadioButton runat="server" ID="rdbGift" GroupName="Type" />Gift
                                                </label>
                                                <label class="radio-inline">
                                                    <asp:RadioButton runat="server" ID="rdbOthers" GroupName="Type" />Others
                                                </label>
                                            </div>
                                        </div>
                                    </fieldset>--%>
                                    <asp:Label ID="lblShedPaySerial" runat="server" Visible="false"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:GridView runat="server" CssClass="table" ID="gvwletter" AutoGenerateColumns="False">
                                            <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                            <Columns>
                                                <asp:BoundField DataField="AgrNo" HeaderText="SL No" />
                                                <asp:BoundField DataField="MadSomityName" HeaderText="Mad/Somity" />
                                                <asp:BoundField DataField="TeritoryName" HeaderText="Teritory" />
                                                <asp:BoundField DataField="DonationAmnt" HeaderText="Donation" />
                                                <asp:BoundField DataField="PrevPayment" HeaderText="Prev Payment" />
                                                <asp:BoundField DataField="CurDemandAmnt" HeaderText="Demand Amnt" />
                                                <asp:BoundField DataField="DueAmnt" HeaderText="Due Amnt" />
                                                <asp:BoundField DataField="PayType" HeaderText="Pay Type" />
                                                <asp:BoundField DataField="AccountName" HeaderText="Account Title" />
                                                <asp:BoundField DataField="AccountNameBn" HeaderText="Account Title_Bn" ItemStyle-Font-Names="SutonnyMJ" />
                                                <asp:BoundField DataField="AccountNo" HeaderText="Account No" />
                                                <asp:BoundField DataField="AccountType" HeaderText="Account Type" />
                                                <asp:BoundField DataField="BankName" HeaderText="BankName" />
                                                <asp:BoundField DataField="Branch" HeaderText="Branch" />
                                                <asp:BoundField DataField="Address" HeaderText="Address" />
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbDeleteLetter" runat="server" CommandArgument='<%#Eval("Serial") %>' OnClick="lbDeleteLetter_Click">
                                                 Delete
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtLetterAmount" CssClass="col-md-4 control-label no-padding-right" Text="Total Amount"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox runat="server" ID="txtLetterAmount" CssClass="form-control" Text="0" ReadOnly="True" disabled="" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-6 col-md-offset-4">
                                            <asp:Button ID="btnLetterSave" Text="Save" CssClass="btn btn-lock pull-right" runat="server" OnClientClick="if (!confirm('Do You Want to Save?')) return false;" OnClick="btnLetterSave_Click" />
                                            <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-info pull-left" runat="server" OnClick="btnPrint_Click" />
                                        </div>
                                    </div>
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
            open_menu("Madrasah");
        })
    </script>
</asp:Content>
