<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmVacancyFor.aspx.cs" Inherits="BLL.HrmVacancy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Vacancy For
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtVacancyName" runat="server" CssClass="control-label col-md-2 no-padding-right">Vacancy Name</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtVacancyName" CssClass="form-control" runat="server"></asp:TextBox>
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
            open_menu("HR Administration");
        });
    </script>
</asp:Content>
