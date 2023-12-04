<%@ Page Title="" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_PrintBasic.aspx.cs" Inherits="BLL.Pro_PrintBasic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
        <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Print Basic Info
                </div>
                <div class="panel-body">
                    <asp:Panel ID="PanelPromotionalItem" runat="server" GroupingText="Promotional Item">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtName" runat="server" CssClass="control-label col-md-2 no-padding-right">Name</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4 col-md-offset-2">
                                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="panel-body">
                                <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                                    <asp:GridView ID="gvwPromotionalItem" CssClass="table " runat="server" AutoGenerateColumns="false">
                                        <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                        <Columns>
                                            <asp:BoundField DataField="#" HeaderText="ID" />
                                            <asp:BoundField DataField="#" HeaderText="Name" />
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
