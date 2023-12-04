<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="MktNewBookCode.aspx.cs" Inherits="BLL.MktNewBookCode" %>

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
            <div class="row">
                <div class="col-md-12">
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
                                    <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-success pull-right" OnClick="btnSave_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-success">
                        <div class="panel-body">
                            <% List<BookVersionInfo> versionInfos = li_StockManager.GetAllStocksInformations(); %>
                            <table class="table table-striped" id="BookCodeTable">
                                <thead>
                                    <tr class="danger">
                                        <th>Book Code</th>
                                        <th>Book Name</th>
                                        <th>Class</th>
                                        <th>Edition</th>
                                        <th>Price</th>
                                        <th>Stock Qty</th>
                                        <th>SL No</th>
                                        <th>Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%
                                        foreach (var info in versionInfos)
                                        {%>
                                    <tr>
                                        <td><%=info.BookCode %></td>
                                        <td><%=info.BookName %></td>
                                        <td><%=info.ClassName %></td>
                                        <td><%= info.Edition %></td>
                                        <td><%= info.Price %></td>
                                        <td><%=info.StockQuantity%></td>
                                        <td><%= info.SerialNo %></td>
                                        <td><a href="" class="btn btn-default">Edit</a></td>
                                    </tr>

                                    <%}
                                    %>
                                </tbody>
                                <tfoot>
                                    <tr class="danger">
                                        <th>Book Code</th>
                                        <th>Book Name</th>
                                        <th>Class</th>
                                        <th>Edition</th>
                                        <th>Price</th>
                                        <th>Stock Qty</th>
                                        <th>SL No</th>
                                        <th>Action</th>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
    <!-- js placed at the end of the document so the pages load faster -->
    <script src="js/jquery.js"></script>
    <%--<script src="js/bootstrap.min.js"></script>--%>
    <script class="include" type="text/javascript" src="js/jquery.dcjqaccordion.2.7.js"></script>
    <script src="js/jquery.scrollTo.min.js"></script>
    <script src="js/jquery.nicescroll.js" type="text/javascript"></script>
    <script src="js/respond.min.js"></script>

    <!--this page plugins-->
    <script type="text/javascript" src="assets/fuelux/js/spinner.min.js"></script>
    <script type="text/javascript" src="assets/bootstrap-fileupload/bootstrap-fileupload.js"></script>
    <script type="text/javascript" src="assets/bootstrap-wysihtml5/wysihtml5-0.3.0.js"></script>
    <script type="text/javascript" src="assets/bootstrap-wysihtml5/bootstrap-wysihtml5.js"></script>
    <script type="text/javascript" src="assets/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="assets/bootstrap-datetimepicker/js/bootstrap-datetimepicker.js"></script>
    <script type="text/javascript" src="assets/bootstrap-daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="assets/bootstrap-daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="assets/bootstrap-colorpicker/js/bootstrap-colorpicker.js"></script>
    <script type="text/javascript" src="assets/bootstrap-timepicker/js/bootstrap-timepicker.js"></script>
    <script type="text/javascript" src="assets/jquery-multi-select/js/jquery.multi-select.js"></script>
    <script type="text/javascript" src="assets/jquery-multi-select/js/jquery.quicksearch.js"></script>
    <!--this page  script only-->
    <script src="js/advanced-form-components.js"></script>
    <%-- <script src="//cdn.datatables.net/1.10.11/js/jquery.dataTables.min.js"></script>
    <script src="//cdn.datatables.net/plug-ins/1.10.6/integration/bootstrap/3/dataTables.bootstrap.js"></script>--%>
    <script src="Content/jquery.dataTables.min.js"></script>
    <script src="Content/dataTables.bootstrap.js"></script>
    <script>
        $(document).ready(function () {
            $('#BookCodeTable').DataTable();

        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Book Information");
        });
    </script>
</asp:Content>
