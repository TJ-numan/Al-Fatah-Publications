<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmInterviewTemplate.aspx.cs" Inherits="BLL.HrmInterviewTemplate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Interview Template
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlInterviewSchedule" runat="server" CssClass="control-label col-md-2 no-padding-right">Interview Schedule</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlInterviewSchedule" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlVacancy" runat="server" CssClass="control-label col-md-2 no-padding-right">Vacancy</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlVacancy" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>   
                              
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlTestId" runat="server" CssClass="control-label col-md-2 no-padding-right">Test ID</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlTestId" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtCanditadeName" runat="server" CssClass="control-label col-md-2 no-padding-right">Canditade Name</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtCanditadeName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtEduQualification" runat="server" CssClass="control-label col-md-2 no-padding-right">EduQualification</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtEduQualification" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtSkill" runat="server" CssClass="control-label col-md-2 no-padding-right">Skill</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtSkill" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtObtainMarks" runat="server" CssClass="control-label col-md-2 no-padding-right">Obtain Marks</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtObtainMarks" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtVivaMarks" runat="server" CssClass="control-label col-md-2 no-padding-right">Viva Marks</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtVivaMarks" CssClass="form-control" runat="server"></asp:TextBox>
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
