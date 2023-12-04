<%@ Page Title="Paper Party" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_PaperParty.aspx.cs" Inherits="BLL.Pro_PaperParty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Paper Party Info
                </div>              
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPaperPartyID" CssClass="col-md-4 control-label" Text="Party ID" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtPaperPartyID" ReadOnly="true" placeholder="Party ID" runat="server"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPaperPartyName" CssClass="col-md-4 control-label" Text="Party Name" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtPaperPartyName" placeholder="Party Name" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPaperPartyName_Bn" CssClass="col-md-4 control-label" Text="Party Name Bangla" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtPaperPartyName_Bn" placeholder="cvwU© bvg" Font-Names="SutonnyMJ" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPaperOpeningBalance" CssClass="col-md-4 control-label" Text="Opening Balance" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtPaperOpeningBalance" placeholder="Opening Balance" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPaperAddress" CssClass="col-md-4 control-label" Text="Address" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtPaperAddress" placeholder="Address" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPaperPhone" CssClass="col-md-4 control-label" Text="Phone" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtPaperPhone" placeholder="Phone" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPaperAddress_Bn" CssClass="col-md-4 control-label" Text="Address Bangla" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtPaperAddress_Bn" placeholder="wVKvbv" Font-Names="SutonnyMJ" runat="server" />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">                          
                            <asp:Button ID="btnPaperUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnPaperUpdate_Click" />
                             <asp:Button ID="btnPaperSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnPaperSave_Click" />
                        </div>
                    </div>
                </div>

                <div class="table-responsive">
                    <asp:GridView ID="gvwPaperParty" CssClass="grid-view table" runat="server" Align="Center" AutoGenerateColumns="false" OnSelectedIndexChanged="gvwPaperParty_SelectedIndexChanged" OnRowDataBound="gvwPaperParty_RowDataBound" AllowPaging="True" OnPageIndexChanging="gvwPaperParty_OnPageIndexChanging" PageSize="10">
                         <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                        <Columns>
                            <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                HeaderStyle-CssClass="HiddenColumn" />
                            <asp:BoundField DataField="ID" HeaderText="ID" />
                            <asp:BoundField DataField="Name" HeaderText="Name"/>
                            <asp:BoundField DataField="Name_Bn" HeaderText="Name Bangla" ItemStyle-Font-Names="SutonnyMJ"/>
                            <asp:BoundField DataField="Address" HeaderText="Address"/>
                            <asp:BoundField DataField="Address_Bn" HeaderText="Address Bangla" ItemStyle-Font-Names="SutonnyMJ"/>
                            <asp:BoundField DataField="Phone" HeaderText="Phone"/>
                            <asp:BoundField DataField="O_Balance" HeaderText="O_Balance"/>
                            <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" DataFormatString="{0:dd/MM/yyyy}"/>
                        </Columns>
                        <SelectedRowStyle BackColor="#393737" Font-Bold="true" ForeColor="#F7F7F7" />
                        <FooterStyle BackColor="#F2DEDE" ForeColor="#2A3542"></FooterStyle>
                    </asp:GridView>
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
            open_menu("Paper");
        });
    </script>
</asp:Content>
