<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="MktNewLibraryOwner.aspx.cs" Inherits="BLL.MktNewLibraryOwner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Create New Library Owner
                </div>
                <div class="panel-body">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtOwnerID" CssClass="col-md-4 control-label" Text="Library Owner ID" runat="server"></asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox CssClass="form-control" ID="txtOwnerID" placeholder="Library Owner ID" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtOwnerName" CssClass="col-md-4 control-label" Text="Owner Name" runat="server"></asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox CssClass="form-control" ID="txtOwnerName" placeholder="Library Owner Name" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtPropietorMobile" CssClass="col-md-4 control-label" Text="Propietor Mobile" runat="server"></asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox CssClass="form-control" ID="txtPropietorMobile" placeholder="Propietor Mobile No" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtManagerMobile" CssClass="col-md-4 control-label" Text="Manager Mobile" runat="server"></asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox CssClass="form-control" ID="txtManagerMobile" placeholder="Manager Mobile No" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtFutureAgent" CssClass="col-md-4 control-label" Text="Probable Future Agent" runat="server"></asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox CssClass="form-control" ID="txtFutureAgent" placeholder="Probable Future Agent" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-5">
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
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <div class="col-md-6 col-md-offset-4">
                                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" />
                                <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel">
                <div class="panel-body">
                    <div class="form-group">
                        <div class="col-md-10">
                            <div class="search-input">
                                <i class="icon-search"></i>
                                <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" Placeholder="Search" />
                            </div>
                        </div>
                    </div>
                   <div class="row">
                        <div class="col-md-12">
                            <div class="panel panel-success">                         
                                <div class="panel-body">
                                    <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                                        <asp:GridView ID="gvLibraryOwner" CssClass="table " runat="server" AutoGenerateColumns="false">
                                            <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                            <Columns>
                                                <asp:BoundField HeaderText="Edit" DataField="#" />
                                                <asp:BoundField HeaderText="Owner Name" DataField="#" />
                                                <asp:BoundField HeaderText="Propitor mobile" DataField="# " />
                                                <asp:BoundField HeaderText="Manager Mobile" DataField="#" />
                                                <asp:BoundField HeaderText="Future Agent" DataField="#" />
                                                <asp:BoundField HeaderText="Area Name" DataField="#" />                                               
                                                <asp:BoundField HeaderText="Territory Name" DataField="#"/>
                                                <asp:BoundField HeaderText="District Name" DataField="#"/>
                                                <asp:BoundField HeaderText="Thana Name" DataField="#"/>                                              
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
            var anc = $('span:contains("Library Information"), ul.sub a[href="MktNewLibraryOwner"]').parent().addClass("active");
            anc.next("ul").css("display", "block");
        });
    </script>
</asp:Content>
