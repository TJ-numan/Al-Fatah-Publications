<%@ Page Title="" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_PlateBasicInfo.aspx.cs" Inherits="BLL.Pro_PlateBasicInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Plate Basic Info
                </div>
                <div class="panel-body">
                    <asp:Panel ID="PanelPlateType" runat="server" GroupingText="Plate Type">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtPlateTypeName" runat="server" CssClass="control-label col-md-2 no-padding-right">Name</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtPlateTypeName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4 col-md-offset-2">
                                <asp:Button ID="btnPlateTypeSave" Text="Save" CssClass="btn btn-success" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="panel-body">
                                <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                                    <asp:GridView ID="gvwPlateType" CssClass="table " runat="server" AutoGenerateColumns="false">
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
                    <asp:Panel ID="PanelPlateSizeType" runat="server" GroupingText="Plate Size Type">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtBrandName" runat="server" CssClass="control-label col-md-2 no-padding-right">Brand Name</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtBrandName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4 col-md-offset-2">
                                <asp:Button ID="btnPlateSizeTypeSave" Text="Save" CssClass="btn btn-success" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="panel-body">
                                <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                                    <asp:GridView ID="gvwPlateSizeType" CssClass="table " runat="server" AutoGenerateColumns="false">
                                        <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                        <Columns>
                                            <asp:BoundField DataField="#" HeaderText="ID" />
                                            <asp:BoundField DataField="#" HeaderText="Size" />
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
                    <asp:Panel ID="PanelPlateSize" runat="server" GroupingText="Plate Size">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlSizeType" runat="server" CssClass="control-label col-md-2 no-padding-right">Size Type</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlSizeType" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="control-label col-md-2 no-padding-right">Size</asp:Label>
                            <div>
                                <asp:TextBox ID="txtsize1" runat="server"/> X <asp:TextBox ID="txtsize2" runat="server"/>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4 col-md-offset-2">
                                <asp:Button ID="btnPlateSizeSave" Text="Save" CssClass="btn btn-success" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="panel-body">
                                <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                                    <asp:GridView ID="gvwPlateSize" CssClass="table " runat="server" AutoGenerateColumns="false">
                                        <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                        <Columns>
                                            <asp:BoundField DataField="#" HeaderText="PlateSizeType" />
                                            <asp:BoundField DataField="#" HeaderText="ID" />
                                            <asp:BoundField DataField="#" HeaderText="BrandName" />
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
