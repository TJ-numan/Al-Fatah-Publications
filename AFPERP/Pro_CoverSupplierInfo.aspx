<%@ Page Title="" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_CoverSupplierInfo.aspx.cs" Inherits="BLL.Pro_CoverSupplierInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
      <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Cover Supplier Info
                </div>

                <%--<div id="frmLaminationParty" runat="server" class="form-horizontal clearfix">--%>
                <div class="panel-body">
                    <div class="col-md-12 no-padding clearfix">
                        <div class="col-md-6 clearfix">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtSupplierID" CssClass="col-xs-4 control-label no-padding-right" Text="Supplier ID"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtSupplierID" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtSupplierName" CssClass="col-xs-4 control-label no-padding-right" Text="Supplier Name"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtSupplierName" runat="server" CssClass="form-control" placeholder="Party Name"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtName_Bn" CssClass="col-xs-4 control-label no-padding-right" Text="Name In Bangla"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtName_Bn" Font-Names="SutonnyMJ" runat="server" CssClass="form-control" placeholder="cvwU©i bvg" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtAddress" CssClass="col-xs-4 control-label no-padding-right" Text="Address"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Address"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtAddress_Bn" CssClass="col-xs-4 control-label no-padding-right" Text="Address In Bangla"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtAddress_Bn" Font-Names="SutonnyMJ" runat="server" CssClass="form-control" placeholder="wVKvbv" />
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
                                <asp:Label runat="server" AssociatedControlID="txtOpBal" CssClass="col-xs-4 control-label no-padding-right" Text="Opening Balance"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtOpBal" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-8 col-xs-offset-4">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-success" Text="Save" />
                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Update" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <%--grid table--%>
                    <div class="col-md-12 clearfix table-responsive">
                        <asp:GridView ID="gvwShowLeft" runat="server" CssClass="table grid-view" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="DateField" HeaderText="SerialNo"
                                    SortExpression="DateField" />
                                <asp:BoundField DataField="DateField" HeaderText="COScode"
                                    SortExpression="DateField" />
                                <asp:BoundField DataField="DateField" HeaderText="SupName"
                                    SortExpression="DateField" />
                                <asp:BoundField DataField="DateField" HeaderText="Address"
                                    SortExpression="DateField" />
                                <asp:BoundField DataField="DateField" HeaderText="Phone"
                                    SortExpression="DateField" />
                                <asp:BoundField DataField="DateField" HeaderText="O_Balance"
                                    SortExpression="DateField" />
                                <asp:BoundField DataField="DateField" HeaderText="CreatedDate"
                                    SortExpression="DateField" />
                                <asp:BoundField DataField="DateField" HeaderText="B_Name"
                                    SortExpression="DateField" />
                                <asp:BoundField DataField="DateField" HeaderText="B_Add"
                                    SortExpression="DateField" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSPro" runat="server">
        <script type="text/javascript">
            $(document).ready(function () {
                open_menu("Cover");
            });
    </script>
</asp:Content>
