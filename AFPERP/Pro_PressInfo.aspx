<%@ Page Title="Press Info" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_PressInfo.aspx.cs" Inherits="BLL.Pro_PressInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Press Info
                </div>            
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPrintingPressID" CssClass="col-md-4 control-label" Text="Press ID"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPrintingPressID" runat="server" ReadOnly="true" CssClass="form-control" placeholder="Press ID">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPrintingPressName" CssClass="col-md-4 control-label" Text="Press Name"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPrintingPressName" runat="server" CssClass="form-control" placeholder="Press Name">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPrintingPressNameBn" CssClass="col-md-4 control-label" Text="Press Name Bangla"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox Font-Names="SutonnyMJ" ID="txtPrintingPressNameBn" runat="server" CssClass="form-control" placeholder="†cÖ‡mi bvg">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPrintingPressAddress" CssClass="col-md-4 control-label" Text="Press Address"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPrintingPressAddress" runat="server" CssClass="form-control" placeholder="Press Address">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPrintingPressAddressBn" CssClass="col-md-4 control-label" Text="Press Address Bangla"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox Font-Names="SutonnyMJ" ID="txtPrintingPressAddressBn" runat="server" CssClass="form-control" placeholder="†cÖ‡mi wVKvbv">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPrintingPressPhone" CssClass="col-md-4 control-label" Text="Press Phone"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPrintingPressPhone" runat="server" CssClass="form-control" placeholder="Press Phone">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPrintingPressOpBal" CssClass="col-md-4 control-label" Text="Opening Balance"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPrintingPressOpBal" runat="server" CssClass="form-control" placeholder="Opening Balance">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">                         
                            <asp:Button ID="btnPrintingUpdate" runat="server" CssClass="btn btn-primary" Text="Update" OnClick="btnPrintingUpdate_Click" />
                            <asp:Button ID="btnPrintingSave" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btnPrintingSave_Click" />
                        </div>
                    </div>
                </div>
                <%--grid view--%>
                <div class="table-responsive">
                    <asp:GridView ID="gvwPrintingPressInfoData" CssClass="grid-view table" runat="server" Align="Center" AutoGenerateColumns="false" OnRowDataBound="gvwPrintingPressInfoData_RowDataBound" OnSelectedIndexChanged="gvwPrintingPressInfoData_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="gvwPrintingPressInfoData_OnPageIndexChanging" PageSize="10">
                         <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                        <Columns>
                            <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                HeaderStyle-CssClass="HiddenColumn" />
                            <asp:BoundField DataField="PressID" HeaderText="PressID" />
                            <asp:BoundField DataField="PressName" HeaderText="PressName"/>
                            <asp:BoundField DataField="Name_Bn" HeaderText="PressName_Bn" ItemStyle-Font-Names="SutonnyMJ"/>
                            <asp:BoundField DataField="Address" HeaderText="Address"/>
                            <asp:BoundField DataField="Add_bn" HeaderText="Address_Bn" ItemStyle-Font-Names="SutonnyMJ"/>
                            <asp:BoundField DataField="Phone" HeaderText="Phone"/>
                            <asp:BoundField DataField="OpeningBalance" HeaderText="O_Balance"/>
                            <asp:BoundField DataField="CrteatedDate" HeaderText="CreatedDate" DataFormatString="{0:dd/MM/yyyy}"/>
                        </Columns>
                        <SelectedRowStyle BackColor="#393737" Font-Bold="true" ForeColor="#F7F7F7" />
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
            open_menu("Printing");
        });
    </script>
</asp:Content>
