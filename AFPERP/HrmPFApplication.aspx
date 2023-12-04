<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmPFApplication.aspx.cs" Inherits="BLL.HrmPFApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Provident Fund Application
                </div>
                <div class="panel-body">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-4 no-padding-right">Info Status</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtPFAcNo" runat="server" CssClass="control-label col-md-4 no-padding-right">PF AccountNo</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtPFAcNo" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlEmployee" runat="server" CssClass="control-label col-md-4 no-padding-right">Employee</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlEmployee" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="ddlEffectiveDate" CssClass="control-label col-md-4 no-padding-right">Effective Date</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox CssClass="form-control" ID="ddlEffectiveDate" placeholder="dd-MM-yyyy" runat="server" />
                                <ajaxToolkit:CalendarExtender TargetControlID="ddlEffectiveDate" Format="dd-MM-yyyy" runat="server" />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtComments" runat="server" CssClass="control-label col-md-4 no-padding-right">Comments</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtComments" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>


                    </div>

                    <div class="col-md-6">
                        <asp:Panel ID="pnlNominee" runat="server" BorderColor="Silver" BorderWidth="1px" GroupingText="Nominee Information">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtNomineeName" runat="server" CssClass="control-label col-md-4 no-padding-right">Nominee Name</asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtNomineeName" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtEmpRelation" runat="server" CssClass="control-label col-md-4 no-padding-right">Employee Relation</asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtEmpRelation" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtNomiPerAdd" runat="server" CssClass="control-label col-md-4 no-padding-right">Permanent Address</asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtNomiPerAdd" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtNomiPresAdd" runat="server" CssClass="control-label col-md-4 no-padding-right">Present Address</asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtNomiPresAdd" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtNationalID" runat="server" CssClass="control-label col-md-4 no-padding-right">National ID</asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtNationalID" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtBirthID" runat="server" CssClass="control-label col-md-4 no-padding-right">Birth Reg. ID</asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtBirthID" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtPercentRatio" runat="server" CssClass="control-label col-md-4 no-padding-right">Percent Ratio</asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtPercentRatio" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtNomineeComments" runat="server" CssClass="control-label col-md-4 no-padding-right">Nominee Comments</asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtNomineeComments" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </asp:Panel>


                        <div class="form-group">
                            <div class="col-md-6 col-md-offset-4">
                                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" />
                                <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" />
                            </div>
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
