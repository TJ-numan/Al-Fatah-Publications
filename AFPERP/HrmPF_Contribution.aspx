<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmPF_Contribution.aspx.cs" Inherits="BLL.HrmPF_Contribution" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Provident Fund Contribution
                </div>
                <div class="panel-body">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtProjectTitle" runat="server" CssClass="control-label col-md-2 no-padding-right">Project Title</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtProjectTitle" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="dtpProjectStDate" CssClass="control-label col-md-2 no-padding-right">Project Sart Date</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox CssClass="form-control" ID="dtpProjectStDate" placeholder="dd-MM-yyyy" runat="server" />
                                <ajaxToolkit:CalendarExtender TargetControlID="dtpProjectStDate" Format="dd-MM-yyyy" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="dtpProjectEndDate" CssClass="control-label col-md-2 no-padding-right">Project End Date</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox CssClass="form-control" ID="dtpProjectEndDate" placeholder="dd-MM-yyyy" runat="server" />
                                <ajaxToolkit:CalendarExtender TargetControlID="dtpProjectEndDate" Format="dd-MM-yyyy" runat="server" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-4 col-md-offset-2">
                                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" />
                                <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" />
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
