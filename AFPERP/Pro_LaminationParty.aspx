<%@ Page Title="Lamination Party" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_LaminationParty.aspx.cs" Inherits="BLL.Pro_LaminationParty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="form-horizontal clearfix" runat="server">
                <div class="panel-body" style="border: 1px solid #BDC3CA">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Lamination Party Info
                        </div>

                        <%--<div id="frmLaminationParty" runat="server" class="form-horizontal clearfix">--%>
                        <div class="panel-body">
                            <div class="col-md-12 no-padding clearfix">
                                <div class="col-md-6 clearfix">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtPartyID" CssClass="col-xs-4 control-label no-padding-right" Text="ID"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtPartyID" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtPartyName" CssClass="col-xs-4 control-label no-padding-right" Text="Party Name"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtPartyName" runat="server" CssClass="form-control" placeholder="Party Name" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtPartyName_Bn" CssClass="col-xs-4 control-label no-padding-right" Text="Name In Bangla"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtPartyName_Bn" Font-Names="SutonnyMJ" runat="server" CssClass="form-control" placeholder="cvwU©i bvg" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtPartyAddress" CssClass="col-xs-4 control-label no-padding-right" Text="Address"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtPartyAddress" runat="server" CssClass="form-control" placeholder="Address" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtPartyAddress_Bn" CssClass="col-xs-4 control-label no-padding-right" Text="Address In Bangla"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtPartyAddress_Bn" Font-Names="SutonnyMJ" runat="server" CssClass="form-control" placeholder="wVKvbv" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6 clearfix">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtPhone" CssClass="col-xs-4 control-label no-padding-right" Text="Phone"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtOppeningBalance" CssClass="col-xs-4 control-label no-padding-right" Text="Opening Balance"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtOppeningBalance" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-xs-8 col-xs-offset-4">
                                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click" />
                                            <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Update" />
                                        </div>
                                    </div>
                                </div>
                            </div><br/>
                            
                            <%--grid table--%>
                            <div class="col-md-12 clearfix table-responsive">
                                <asp:GridView ID="gvwAllParty" runat="server" CssClass="table grid-view" AutoGenerateColumns="false" OnRowDataBound="gvwAllParty_RowDataBound" OnSelectedIndexChanged="gvwAllParty_SelectedIndexChanged">
                                     <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />
                                        <asp:BoundField DataField="ID" HeaderText="ID" />
                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                        <asp:BoundField DataField="Name_Bn" HeaderText="Name_Bn" ItemStyle-Font-Names="SutonnyMJ" />
                                        <asp:BoundField DataField="Address" HeaderText="Address" />
                                        <asp:BoundField DataField="Add_Bn" HeaderText="Address_Bn" ItemStyle-Font-Names="SutonnyMJ" />
                                        <asp:BoundField DataField="Phone" HeaderText="Phone" />
                                        <asp:BoundField DataField="OpeningBalance" HeaderText="O_Balance" />
                                        <asp:BoundField DataField="CrteatedDate" HeaderText="CreatedDate" DataFormatString="{0:dd/MM/yyyy}" />
                                    </Columns>
                                </asp:GridView>
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
            open_menu("Lamination");
        });
    </script>
</asp:Content>
