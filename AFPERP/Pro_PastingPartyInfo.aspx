<%@ Page Title="Party Info" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_PastingPartyInfo.aspx.cs" Inherits="BLL.Pro_PastingPartyInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Pasting Party Info
                </div>             
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPastingPartyID" CssClass="col-md-4 control-label" Text="Party ID" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtPastingPartyID" ReadOnly="true" placeholder="Party ID" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPastinPartyName" CssClass="col-md-4 control-label" Text="Party Name" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtPastinPartyName" placeholder="Party Name" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPastinPartyName_Bn" CssClass="col-md-4 control-label" Text="Party Name Bangla" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtPastinPartyName_Bn" placeholder="cvwU© bvg" Font-Names="SutonnyMJ" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPastinOpeningBalance" CssClass="col-md-4 control-label" Text="Opening Balance" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtPastinOpeningBalance" placeholder="Opening Balance" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPastinAddress" CssClass="col-md-4 control-label" Text="Address" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtPastinAddress" placeholder="Address" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPastinAddress_Bn" CssClass="col-md-4 control-label" Text="Address Bangla" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtPastinAddress_Bn" placeholder="wVKvbv" Font-Names="SutonnyMJ" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPastinPhone" CssClass="col-md-4 control-label" Text="Phone" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtPastinPhone" placeholder="Phone" runat="server" />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">                          
                            <asp:Button ID="btnPastingUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnPastingUpdate_Click" />
                            <asp:Button ID="btnPastingSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnPastingSave_Click" />
                        </div>
                    </div>
                </div>

                <div class="table-responsive">
                    <asp:GridView ID="gvwPastingParty" CssClass="grid-view table" runat="server" Align="Center" AutoGenerateColumns="false" OnSelectedIndexChanged="gvwPastingParty_SelectedIndexChanged" OnRowDataBound="gvwPastingParty_RowDataBound">
                         <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                        <Columns>
                            <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                HeaderStyle-CssClass="HiddenColumn" />
                            <asp:BoundField DataField="ID" HeaderText="ID"
                                SortExpression="DateField" />
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Name_Bn" HeaderText="Name Bangla"
                                ItemStyle-Font-Names="SutonnyMJ" />
                            <asp:BoundField DataField="Address" HeaderText="Address" />
                            <asp:BoundField DataField="Address_Bn" HeaderText="Address Bangla"
                                ItemStyle-Font-Names="SutonnyMJ" />
                            <asp:BoundField DataField="Phone" HeaderText="Phone" />
                            <asp:BoundField DataField="O_Balance" HeaderText="O_Balance" />
                            <asp:BoundField DataField="SerialNo" HeaderText="SerialNo" />
                            <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" DataFormatString="{0:dd/MM/yyyy}" />
                        </Columns>

                        <SelectedRowStyle BackColor="#393737" Font-Bold="true" ForeColor="#F7F7F7" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSPro" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Pasting");
        });
    </script>
</asp:Content>
