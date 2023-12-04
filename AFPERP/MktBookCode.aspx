<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="MktBookCode.aspx.cs" Inherits="BLL.MktBookCode" %>
<%@ Import Namespace="Common.Marketing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
<link rel="stylesheet" type="text/css" href="assets/bootstrap-fileupload/bootstrap-fileupload.css" />
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-reset.css" rel="stylesheet" />
    <!--external css-->
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="assets/fancybox/source/jquery.fancybox.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="css/gallery.css" />
    <!-- Custom styles for this template -->
    <link href="css/style.css" rel="stylesheet">
    <link href="css/style-responsive.css" rel="stylesheet" />
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    New Book Version Information
                </div>
                <div class="panel-body">
                        <asp:UpdatePanel runat="server" ID="UpdateArea">
                                <ContentTemplate>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtEntryNo" CssClass="col-sm-3 col-md-3 control-label" Text="Entry No"></asp:Label>
                                        <div class="col-md-5">
                                            <asp:TextBox ID="txtEntryNo" runat="server" CssClass="form-control" ReadOnly="True" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlBookName" Text="Book Name" CssClass="col-md-3 col-sm-6 control-label" runat="server"></asp:Label>
                                        <div class="col-md-5 col-sm-5 ">
                                            <asp:DropDownList CssClass="form-control" ID="ddlBookName" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlEdition" Text="Select Edition" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                        <div class="col-md-5">
                                            <asp:DropDownList CssClass="form-control" ID="ddlEdition" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtPrice" Text="Price" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                        <div class="col-md-5">
                                            <asp:TextBox CssClass="form-control" ID="txtPrice" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtBonus" Text="General Bonus" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                        <div class="col-md-5">
                                            <asp:TextBox CssClass="form-control" ID="txtBonus" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtQty" Text="Price on Qty" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                        <div class="col-md-5">
                                            <asp:TextBox CssClass="form-control" ID="txtQty" runat="server" />
                                        </div>
                                    </div>   
                                 </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="form-group">
                                <div class="col-md-5 col-md-offset-3">
    
                                    <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary pull-right" OnClick="btnVersionSave_Click" />
                                    <asp:Button ID="btnVersionUpdate" Text="Update" CssClass="btn btn-success pull-right" runat="server" visible="true" OnClick="btnVersionUpdate_Click" />
                                    <asp:Button runat="server" ID="btnPrint" Text="Print" CssClass="btn btn-success pull-right"/>
                                </div>
                            </div>
                 </div>

                    <%-------------------------   Start Search System----------------------------%>
                        <div class="form-group">
                            <div class="col-md-10">
                                <div class="search-input">
                                    <i class="icon-search"></i>
                                    <asp:TextBox CssClass="form-control" ID="txtSearchBookName" runat="server" Placeholder="Search" AutoPostBack="True" OnTextChanged="txtSearchBookName_TextChanged" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 table table-responsive">
                                <asp:GridView ID="gvwLibraryInformation" CssClass="table" runat="server" Align="Center" AutoGenerateColumns="false" OnRowDataBound="gvwBookInformation_RowDataBound" OnSelectedIndexChanged="gvwLibraryInformation_SelectedIndexChanged" OnPageIndexChanging="gvwLibraryInformation_PageIndexChanging">
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />
                                        <asp:BoundField DataField="BookID" HeaderText="Book Code" />
                                        <asp:BoundField DataField="BookName" HeaderText="Book Name" />
                                        <asp:BoundField DataField="ClassName" HeaderText="Class" />
                                        <asp:BoundField DataField="Edition" HeaderText="Edition" />
                                        <asp:BoundField DataField="Price" HeaderText="Price" />
                                        <asp:BoundField DataField="StockQuantity" HeaderText="Stock Qty" />
                                        <asp:BoundField DataField="SerialNo" HeaderText="SL No" />
                                        <asp:BoundField DataField="Edit" HeaderText="Action" />
                                    </Columns>
                                    <SelectedRowStyle BackColor="#393737" Font-Bold="true" ForeColor="#F7F7F7" />
                                </asp:GridView>
                            </div>
                        </div>
                </div>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
    <script type="text/javascript">
          $(document).ready(function () {
              open_menu("Book Information");
          });
    </script>
</asp:Content>
