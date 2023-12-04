<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="MktAddNewBook.aspx.cs" Inherits="BLL.MktAddNewBook" %>

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
                <div class="col-md-7">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Create New Book
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtBookCode" CssClass="col-md-4 control-label" Text="Book Code" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control" ID="txtBookCode" placeholder="Book Code" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtBookName" CssClass="col-md-4 control-label" Text="Book Name" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control" ID="txtBookName" placeholder="Book Name" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtBookNameBangla" CssClass="col-md-4 control-label bangla-font" Text="eB‡qi bvg" runat="server" Font-Names="SutonnyMJ"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control bangla-font" ID="txtBookNameBangla" placeholder="eB‡qi bvg" Font-Names="SutonnyMJ" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlBookType" CssClass="col-md-4 control-label" Text="Book Type" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlBookType" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlClass" CssClass="col-md-4 control-label" Text="Class" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlClass" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlGroup" CssClass="col-md-4 control-label" Text="Group" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlGroup" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlSession" CssClass="col-md-4 control-label" Text="Series" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlSession" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-8 col-md-offset-4">
                                    <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            Select Related Section
                        </div>
                        <div class="panel-body" style="border: 1px solid #BDC3CA; padding-left: 50px">
                            <asp:GridView ID="gvSection" CssClass="table " runat="server" AutoGenerateColumns="false">
                                <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                          <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSection" runat="server" AutoPostBack="False"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:BoundField DataField="SectionId" HeaderText=" "/>
                                        <asp:BoundField DataField="SectionName" HeaderText="Section" />
                                    </Columns>                              
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-success">
                        <div class="panel-body">
                            <% List<BookInformation> informations = li_BookInformationManager.GetAll_BookInformations();%>
                            <table class=" table table-striped table-responsive" id="BookTable">
                                <thead>
                                    <tr class="danger">
                                        <th>Book Id</th>
                                        <th>Book Name</th>
                                        <th>Class</th>
                                        <th>Type</th>
                                        <th>In Bangla</th>
                                        <th>Session</th>
                                        <th>Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%
                                        foreach (var info in informations)
                                        {%>
                                    <tr>
                                        <td><%= info.BookId %></td>
                                        <td><%= info.BookName %></td>
                                        <td><%= info.Class %></td>
                                        <td><%= info.Type %></td>
                                        <td style="font-family: sutonnyMJ; font-size: 16px"><%= info.InBangla %></td>
                                        <td><%= info.SessionName %></td>
                                        <td><a href="" class="btn btn-default">Edit</a></td>
                                    </tr>
                                    <%}
                                    %>
                                </tbody>
                                <tfoot>
                                    <tr class="danger">
                                        <th>Book Id</th>
                                        <th>Book Name</th>
                                        <th>Class</th>
                                        <th>Type</th>
                                        <th>In Bangla</th>
                                        <th>Session</th>
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
<%--<script src="//cdn.datatables.net/1.10.11/js/jquery.dataTables.min.js"></script>
    <script src="//cdn.datatables.net/plug-ins/1.10.6/integration/bootstrap/3/dataTables.bootstrap.js"></script>--%>
    <script src="Content/jquery.dataTables.min.js"></script>
    <script src="Content/dataTables.bootstrap.js"></script>
    <script>
        $(document).ready(function () {
            $('#BookTable').DataTable();

        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Book Information");
        });
    </script>
</asp:Content>
