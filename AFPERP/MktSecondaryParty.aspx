<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="MktSecondaryParty.aspx.cs" Inherits="BLL.MktSecondaryParty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Create Secondary Party
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlCAName" CssClass="col-md-4 control-label" Text="Credit Agent Name" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlCAName" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtLibraryName" CssClass="col-md-4 control-label" Text="Library Name" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtLibraryName" placeholder="Library Owner ID" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtPropietorName" CssClass="col-md-4 control-label" Text="Propietor Name" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtPropietorName" placeholder="Library Owner Name" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtPropietorMobile" CssClass="col-md-4 control-label" Text="Propietor Mobile" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtPropietorMobile" placeholder="Propietor Mobile No" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlCategory" CssClass="col-md-4 control-label" Text="Category" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlCategory" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtAvgSell" CssClass="col-md-4 control-label" Text="Monthly Average Sell" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtAvgSell" placeholder="0000" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-5">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtLibraryID" CssClass="col-md-4 control-label" Text="Library ID" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtLibraryID" placeholder="Library Owner ID" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtAddress" CssClass="col-md-4 control-label" Text="Address" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtAddress" placeholder="Address" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtPostOffice" CssClass="col-md-4 control-label" Text="Post Office" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtPostOffice" placeholder="Propietor Mobile No" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlRegion" CssClass="col-md-4 control-label" Text="Region" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlRegion" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlArea" CssClass="col-md-4 control-label" Text="Area" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlArea" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlTerritory" CssClass="col-md-4 control-label" Text="Territory" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlTerritory" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlDistrict" CssClass="col-md-4 control-label" Text="District" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlDistrict" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlThana" CssClass="col-md-4 control-label" Text="Thana" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlThana" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-4">
                                    <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success btn pull-right" runat="server" />
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="panel panel-success">                         
                                <div class="panel-body">
                                    <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                                        <asp:GridView ID="gvSecondaryPary" CssClass="table " runat="server" AutoGenerateColumns="false">
                                            <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                            <Columns>
                                                <asp:BoundField HeaderText="Edit" DataField="#" />
                                                <asp:BoundField HeaderText="#" DataField="#" />
                                                <asp:BoundField HeaderText="#" DataField="# " />
                                                <asp:BoundField HeaderText="#" DataField="#" />
                                                <asp:BoundField HeaderText="#" DataField="#" />
                                                <asp:BoundField HeaderText="#" DataField="#" />
                                                <asp:BoundField HeaderText="#" DataField="#" />                                             
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <br />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var anc = $('span:contains("Library Information"), ul.sub a[href="MktSecondaryParty"]').parent().addClass("active");
            anc.next("ul").css("display", "block");
        });
    </script>
</asp:Content>
