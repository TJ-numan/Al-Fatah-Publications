<%@ Page Title="Binder Information" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_BinderInfo.aspx.cs" Inherits="BLL.Pro_BinderInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Binder Information
                </div>
                <%--<div id="frmPrintingPressInfo" runat="server" class="form-horizontal clearfix">--%>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtBinderID" CssClass="col-md-4 control-label" Text="Binder ID"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtBinderID" runat="server" ReadOnly="true" CssClass="form-control" placeholder="Press ID">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtBinderName" CssClass="col-md-4 control-label" Text="Binder Name"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtBinderName" runat="server" CssClass="form-control" placeholder="Binder Name">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtBinderNameBn" CssClass="col-md-4 control-label" Text="Binder Name Bangla"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox Font-Names="SutonnyMJ" ID="txtBinderNameBn" runat="server" CssClass="form-control" placeholder="evBÛvi bvg">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtBinderAddress" CssClass="col-md-4 control-label" Text="Binder Address"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtBinderAddress" runat="server" CssClass="form-control" placeholder="Binder Address">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtBinderAddressBn" CssClass="col-md-4 control-label" Text="Binder Address Bangla"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox Font-Names="SutonnyMJ" ID="txtBinderAddressBn" runat="server" CssClass="form-control" placeholder="evBÛvi wVKvbv">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPhone" CssClass="col-md-4 control-label" Text="Phone"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" placeholder="Binder Phone">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtOppeningBalance" CssClass="col-md-4 control-label" Text="Opening Balance"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtOppeningBalance" runat="server" CssClass="form-control" placeholder="Opening Balance">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click"/>
                            <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Update" OnClick="btnUpdate_Click"/>
                        </div>
                    </div>
                </div>
                <%--grid view--%>
                <div class="table-responsive">
                    <asp:GridView ID="gvwBinderInfoData" CssClass="grid-view table" runat="server" Align="Center" AutoGenerateColumns="false" OnRowDataBound="gvwBinderInfoData_RowDataBound" 
                        OnSelectedIndexChanged="gvwBinderInfoData_SelectedIndexChanged">
                         <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                        <Columns>
                            <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                HeaderStyle-CssClass="HiddenColumn" />
                            <asp:BoundField DataField="BinderCode" HeaderText="Code" />
                            <asp:BoundField DataField="BinderName" HeaderText="Sup_Name"/>
                            <asp:BoundField DataField="B_Name" HeaderText="B_Name" ItemStyle-Font-Names="SutonnyMJ"/>
                            <asp:BoundField DataField="Address" HeaderText="Address"/>
                            <asp:BoundField DataField="B_Add" HeaderText="B_Add" ItemStyle-Font-Names="SutonnyMJ"/>
                            <asp:BoundField DataField="Phone" HeaderText="Phone"/>
                            <asp:BoundField DataField="OpennigBalance" HeaderText="O_Balance"/>
                            <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" DataFormatString="{0:yyyy-MM-dd}"/>
                        </Columns>
                        <SelectedRowStyle BackColor="#C7BEBE" Font-Bold="true" ForeColor="#F7F7F7" />
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
            open_menu("Binding");
        });
    </script>
</asp:Content>
