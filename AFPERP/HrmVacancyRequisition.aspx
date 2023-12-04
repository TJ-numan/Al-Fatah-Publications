<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmVacancyRequisition.aspx.cs" Inherits="BLL.HrmVacancyRequisition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
      <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Vacancy Requisition
                </div>
                <div class="panel-body">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div> 
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtVacancyTitle" runat="server" CssClass="control-label col-md-2 no-padding-right">Vacancy Title</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtVacancyTitle" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>     
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlPosition" runat="server" CssClass="control-label col-md-2 no-padding-right">Position</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlPosition" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div> 
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlVacancyFor" runat="server" CssClass="control-label col-md-2 no-padding-right">Vacancy For</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlVacancyFor" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>  
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlEmployeeType" runat="server" CssClass="control-label col-md-2 no-padding-right">Employee Type</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlEmployeeType" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>  
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtQualification" runat="server" CssClass="control-label col-md-2 no-padding-right">Qualification</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtQualification" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtExperience" runat="server" CssClass="control-label col-md-2 no-padding-right">Experience</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtExperience" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtRequiredTime" runat="server" CssClass="control-label col-md-2 no-padding-right">Required Time</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtRequiredTime" CssClass="form-control" runat="server"></asp:TextBox>
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
