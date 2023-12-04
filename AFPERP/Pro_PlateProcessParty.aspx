<%@ Page Title="" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_PlateProcessParty.aspx.cs" Inherits="BLL.Pro_PlateProcessParty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <asp:UpdatePanel ID="UpadatePanel1" runat="server">
        <ContentTemplate>
            <div class="form-horizontal clearfix" runat="server">
                <div class="panel-body" style="border: 1px solid #BDC3CA">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Plate Process Party Info
                        </div>
                        <%--<div id="frmPlateParty" runat="server" class="form-horizontal clearfix">--%>
                        <div class="panel-body">
                            <div class="col-md-6 clearfix">
                            </div>
                            <div class="clearfix"></div>
                            <div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtProcessID" CssClass="col-xs-4 control-label no-padding-right" Text="Party ID"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtProcessID" runat="server" ReadOnly="true" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtProcessPartyName" CssClass="col-xs-4 control-label no-padding-right" Text="Party Name"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtProcessPartyName" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtProcessPartyName_Bn" CssClass="col-xs-4 control-label no-padding-right" Text="Party Name Bangla"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtProcessPartyName_Bn" runat="server" CssClass="form-control" Font-Names="SutonnyMJ" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtProcessPartyAddress" CssClass="col-xs-4 control-label no-padding-right" Text="Address"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtProcessPartyAddress" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtProcessPartyAddress_Bn" CssClass="col-xs-4 control-label no-padding-right" Text="Address In Bangla"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtProcessPartyAddress_Bn" runat="server" CssClass="form-control" Font-Names="SutonnyMJ" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtProcessPartyPhone" CssClass="col-xs-4 control-label no-padding-right" Text="Phone"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtProcessPartyPhone" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtProcessParty_Open_Bal" CssClass="col-xs-4 control-label no-padding-right" Text="Opening Balance"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtProcessParty_Open_Bal" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-xs-8 col-xs-offset-4">

                                            <asp:Button ID="btnProcessUpdate" runat="server" CssClass="btn btn-primary" Text="Update" OnClick="btnProcessUpdate_Click" />
                                            <asp:Button ID="btnProcessSave" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btnProcessSave_Click" />

                                        </div>
                                    </div>
                                </div>

                                <div class="clearfix"></div>
                                <%--grid view--%>
                                <div class="col-md-12 table-responsive clearfix">
                                    <asp:GridView ID="gvwAllProcessPartyInfo" runat="server" CssClass="grid-view table" AutoGenerateColumns="false" OnRowDataBound="gvwAllProcessPartyInfo_RowDataBound" OnSelectedIndexChanged="gvwAllProcessPartyInfo_SelectedIndexChanged">
                                        <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                        <Columns>
                                            <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                                HeaderStyle-CssClass="HiddenColumn" />
                                            <asp:BoundField DataField="ID" HeaderText="ID" />
                                            <asp:BoundField DataField="Name" HeaderText="Name" />
                                            <asp:BoundField DataField="B_Name" HeaderText="Name Bangla" ItemStyle-Font-Names="SutonnyMJ" />
                                            <asp:BoundField DataField="Address" HeaderText="Address" />
                                            <asp:BoundField DataField="B_Add" HeaderText="Address Bangla" ItemStyle-Font-Names="SutonnyMJ" />
                                            <asp:BoundField DataField="Phone" HeaderText="Phone" />
                                            <asp:BoundField DataField="O_Balance" HeaderText="O_Balance" />
                                            <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" DataFormatString="{0:dd/MM/yyyy}" />
                                        </Columns>
                                    </asp:GridView>
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
            open_menu("Plate");
        });
    </script>
</asp:Content>
