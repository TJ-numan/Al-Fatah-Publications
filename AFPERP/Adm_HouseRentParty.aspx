<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="Adm_HouseRentParty.aspx.cs" Inherits="BLL.Adm_HouseRentParty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    House Rent Party Info
                </div>              
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtHouseRentPartyID" CssClass="col-md-4 control-label" Text="Party ID" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtHouseRentPartyID" ReadOnly="true" placeholder="Party ID" runat="server"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtHouseRentPartyName" CssClass="col-md-4 control-label" Text="Party Name" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtHouseRentPartyName" placeholder="Party Name" runat="server" />
                        </div>
                    </div>
<%--                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPaperPartyName_Bn" CssClass="col-md-4 control-label" Text="Party Name Bangla" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtPaperPartyName_Bn" placeholder="cvwU© bvg" Font-Names="SutonnyMJ" runat="server" />
                        </div>
                    </div>--%>
<%--                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPaperOpeningBalance" CssClass="col-md-4 control-label" Text="Opening Balance" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtPaperOpeningBalance" placeholder="Opening Balance" runat="server" />
                        </div>
                    </div>--%>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtAddress" CssClass="col-md-4 control-label" Text="Address" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtAddress" placeholder="Address" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtOwnerName" CssClass="col-md-4 control-label" Text="Owner Name" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtOwnerName" placeholder="Owner Name" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtContactPerson" CssClass="col-md-4 control-label" Text="Contact Person" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtContactPerson" placeholder="Phone" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPhone" CssClass="col-md-4 control-label" Text="Phone" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtPhone" placeholder="Phone" runat="server" />
                        </div>
                    </div>
<%--                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPaperAddress_Bn" CssClass="col-md-4 control-label" Text="Address Bangla" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtPaperAddress_Bn" placeholder="wVKvbv" Font-Names="SutonnyMJ" runat="server" />
                        </div>
                    </div>--%>

                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">                          
                            <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnUpdate_Click" />
                             <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>

                <div class="table-responsive">
                    <asp:GridView ID="gvwHouseRentParty" CssClass="grid-view table" runat="server" Align="Center" AutoGenerateColumns="false" OnSelectedIndexChanged="gvwHouseRentParty_SelectedIndexChanged" OnRowDataBound="gvwHouseRentParty_RowDataBound" AllowPaging="True" OnPageIndexChanging="gvwHouseRentParty_OnPageIndexChanging" PageSize="10">
                         <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                        <Columns>
                            <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                HeaderStyle-CssClass="HiddenColumn" />
                            <asp:BoundField DataField="PartyID" HeaderText="ID" />
                            <asp:BoundField DataField="PartName" HeaderText="Name"/>
                            <%--<asp:BoundField DataField="Name_Bn" HeaderText="Name Bangla" ItemStyle-Font-Names="SutonnyMJ"/>--%>
                            <asp:BoundField DataField="P_Add" HeaderText="Address"/>
                            <%--<asp:BoundField DataField="Address_Bn" HeaderText="Address Bangla" ItemStyle-Font-Names="SutonnyMJ"/>--%>
                            <asp:BoundField DataField="OwnerName" HeaderText="Owner Name"/>
                            <asp:BoundField DataField="ContactPer" HeaderText="Contact Person"/>
                            <asp:BoundField DataField="Phone" HeaderText="Phone"/>
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
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSHR" runat="server">
        <script type="text/javascript">
            $(document).ready(function () {
                open_menu("HR Administration");
            });
    </script>
</asp:Content>
