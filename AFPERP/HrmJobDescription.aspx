<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmJobDescription.aspx.cs" Inherits="BLL.HrmJobDescription" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
      <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Job Description
                </div>
                <div class="panel-body">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>      
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlPosition" runat="server" CssClass="control-label col-md-2 no-padding-right">Position</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlPosition" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlJobResposibility" runat="server" CssClass="control-label col-md-2 no-padding-right">Job Responsibility</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlJobResposibility" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>   
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlEducationReq" runat="server" CssClass="control-label col-md-2 no-padding-right">Education Req</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlEducationReq" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlExperienceReq" runat="server" CssClass="control-label col-md-2 no-padding-right">Experience Req</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlExperienceReq" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlJobRequirement" runat="server" CssClass="control-label col-md-2 no-padding-right">Job Requirement</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlJobRequirement" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlJobBenefit" runat="server" CssClass="control-label col-md-2 no-padding-right">Job Benefit</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlJobBenefit" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-4 col-md-offset-2">
                                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                                <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnUpdate_Click" />
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
