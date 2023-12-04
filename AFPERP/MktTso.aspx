<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="MktTso.aspx.cs" Inherits="BLL.MktTso" %>

<%@ Import Namespace="Common.HR" %>
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
    <!-- bootsrap update 
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
     -->
    <div class="form-horizontal clearfix runat=server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Create Teritory Sales Officer
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtTsoID" CssClass="col-md-4 control-label" Text="TSO ID" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox CssClass="form-control" ID="txtTsoID" placeholder="TSO ID" runat="server" ReadOnly="True" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtEmployeeCode" CssClass="col-md-4 control-label" Text="Employee ID" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox CssClass="form-control" ID="txtEmployeeCode" placeholder="Employee ID" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtName" CssClass="col-md-4 control-label" Text="Name" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox CssClass="form-control" ID="txtName" placeholder="Name" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtMobile" CssClass="col-md-4 control-label" Text="Mobile" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox CssClass="form-control" ID="txtMobile" placeholder="Mobile No" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtEmail" CssClass="col-md-4 control-label" Text="Email ID" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox CssClass="form-control" ID="txtEmail" placeholder="Email ID" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtAddress" CssClass="col-md-4 control-label" Text="Address" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:TextBox CssClass="form-control" ID="txtAddress" placeholder="Address Here" runat="server" TextMode="MultiLine" />
                                        </div>
                                    </div>
                                    <div class="form-group ">
                                        <asp:Label AssociatedControlID="ddlTransportMain" Text="Primary Transport" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList CssClass="form-control" ID="ddlTransportMain" AutoPostBack="false" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group ">
                                        <asp:Label AssociatedControlID="ddlTransportAlter" Text="Alternate Transport" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList CssClass="form-control" ID="ddlTransportAlter" AutoPostBack="false" runat="server" />
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-4">
                                    <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlDristrict" Text="Select District" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList CssClass="form-control" ID="ddlDristrict" runat="server" OnSelectedIndexChanged="ddlDristrict_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlThana" Text="Select Thana" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList CssClass="form-control" ID="ddlThana" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlTerritory" CssClass="col-md-3 control-label" Text="Territory" runat="server"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList CssClass="form-control" ID="ddlTerritory" runat="server" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="form-group">
                            <div class="col-md-10">
                                <div class="search-input">
                                    <i class="icon-search"></i>
                                    <asp:TextBox CssClass="form-control" ID="txtSearchTsoName" runat="server" Placeholder="Search" AutoPostBack="True" OnTextChanged="txtSearchTSOName_TextChanged" />
                                </div>
                            </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="panel panel-success">
                                <div class="panel-body">
                                    <% List<TSoInformation> tSO = Li_SalesPersonManager.Get_AllTSO(); %>
                                    <table class="table table-striped " id="TsoTable">
                                        <thead>
                                            <tr class="danger">
                                                <th>Tso Id</th>
                                                <th>Name</th>
                                                <th>Mobile</th>
                                                <th>Address</th>
                                                <th>Territory Name</th>
                                                <th>Area</th>
                                                <th>Region</th>
                                                <th>Status</th>
                                                <th>Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <%
                                                foreach (var person in tSO)
                                                {%>
                                            <tr>
                                                <td><%=person.TSOID %></td>
                                                <td><%=person.Name %></td>
                                                <td><%= person.Mobile %></td>
                                                <td><%=person.Address %></td>
                                                <td><%= person.TerritoryName %></td>
                                                <td><%=person.Region %></td>
                                                <td><%=person.AreaName %></td>
                                                <td><%=person.Status %></td>
                                                <td>
                                                    <a href="" class="btn btn-default">Edit</a>
                                                </td>
                                            </tr>
                                            <%}     
                                            %>
                                        </tbody>
                                        <tfoot>
                                            <tr class="danger">
                                                <th>Tso Id</th>
                                                <th>Name</th>
                                                <th>Mobile</th>
                                                <th>Address</th>
                                                <th>Territory Name</th>
                                                <th>Area</th>
                                                <th>Region</th>
                                                <th>Status</th>
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
            $('#TsoTable').DataTable();

        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Library Information");
        });
    </script>

</asp:Content>
