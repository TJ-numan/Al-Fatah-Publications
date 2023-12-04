<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmPFRules.aspx.cs" Inherits="BLL.HrmPFRules" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
      <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Provident Fund Rules
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPFRulesName" runat="server" CssClass="control-label col-md-2 no-padding-right">PF Rules Name</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtPFRulesName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPFRate" runat="server" CssClass="control-label col-md-2 no-padding-right">PF Rate</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtPFRate" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                   
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtJobYerF" runat="server" CssClass="control-label col-md-2 no-padding-right">txtJobYerF</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtJobYerF" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtJobYerT" runat="server" CssClass="control-label col-md-2 no-padding-right">txtJobYerT</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtJobYerT" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtBenefitRate" runat="server" CssClass="control-label col-md-2 no-padding-right">Benefit Rate</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtBenefitRate" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtComments" runat="server" CssClass="control-label col-md-2 no-padding-right">Comments</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtComments" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>


                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-2">
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" />
                            <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-10 col-md-offset-1">
                                <div class="search-input">
                                    <i class="icon-search"></i>
                                    <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" Placeholder="Search" />
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                                <%--                                <asp:GridView ID="gvwDependents" CssClass="table " runat="server" AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />
                                        <asp:BoundField DataField="DepenId" HeaderText="ID" />
                                        <asp:BoundField DataField="DepenName" HeaderText="Dependent Name" />
                                        <asp:BoundField DataField="EmpName" HeaderText="Employee Name"/>
                                        <asp:BoundField DataField="Relation" HeaderText="Relation" />
                                        <asp:BoundField DataField="DoB" HeaderText="Date of Birth" />
                                        <asp:BoundField DataField="CertificateNo" HeaderText="Certificate No" />
                                        <asp:BoundField DataField="InfStatus" HeaderText="Info Status" />
                                    </Columns>
                                </asp:GridView>--%>
                            </div>
                            <br />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSHR" runat="server">
   <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Payroll Management");
        });
    </script>
</asp:Content>
