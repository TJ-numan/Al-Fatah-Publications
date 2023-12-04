<%@ Page Title="" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_PestingLemination.aspx.cs" Inherits="BLL.Pro_PestingLemination" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
        <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Pesting & Lamination Info
                </div>
                <div class="panel-body">
                    <asp:Panel ID="PanelPestingType" runat="server" GroupingText="Pesting Type">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtPestingType" runat="server" CssClass="control-label col-md-2 no-padding-right">Type</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtPestingType" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4 col-md-offset-2">
                                <asp:Button ID="btnPestingTypeSave" Text="Save" CssClass="btn btn-success" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="panel-body">
                                <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                                    <asp:GridView ID="gvwPestingType" CssClass="table " runat="server" AutoGenerateColumns="false">
                                        <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                        <Columns>
                                            <asp:BoundField DataField="#" HeaderText="ID" />
                                            <asp:BoundField DataField="#" HeaderText="Type" />
                                            <asp:BoundField DataField="#" HeaderText="CreatedDate" />
                                            <asp:BoundField DataField="#" HeaderText="CreatedBy" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <br />
                            </div>
                        </div>
                    </asp:Panel>
                </div>


                <div class="panel-body">
                    <asp:Panel ID="PanelLaminationType" runat="server" GroupingText="Lamination Type">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtLaminationType" runat="server" CssClass="control-label col-md-2 no-padding-right">Type</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtLaminationType" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4 col-md-offset-2">
                                <asp:Button ID="btnLaminationTypeSave" Text="Save" CssClass="btn btn-success" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="panel-body">
                                <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                                    <asp:GridView ID="gvwLaminationType" CssClass="table " runat="server" AutoGenerateColumns="false">
                                        <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                        <Columns>
                                            <asp:BoundField DataField="#" HeaderText="ID" />
                                            <asp:BoundField DataField="#" HeaderText="Type" />
                                            <asp:BoundField DataField="#" HeaderText="CreatedDate" />
                                            <asp:BoundField DataField="#" HeaderText="CreatedBy" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <br />
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSPro" runat="server">
            <script type="text/javascript">
                $(document).ready(function () {
                    open_menu("Basic Setting");
                });
    </script>
</asp:Content>
