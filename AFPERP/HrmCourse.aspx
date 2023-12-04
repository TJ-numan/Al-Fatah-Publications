<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmCourse.aspx.cs" Inherits="BLL.HrmCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
      <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Course
                </div>
                <div class="panel-body">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>      
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtCourseTitle" runat="server" CssClass="control-label col-md-2 no-padding-right">Course Title</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtCourseTitle" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtCourseDescr" runat="server" CssClass="control-label col-md-2 no-padding-right">Course Description</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtCourseDescr" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtComments" runat="server" CssClass="control-label col-md-2 no-padding-right">Comments</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtComments" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlDefaultDepId" runat="server" CssClass="control-label col-md-2 no-padding-right">Default Dep</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlDefaultDepId" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>  
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtDefaultSes" runat="server" CssClass="control-label col-md-2 no-padding-right">Default Ses</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtDefaultSes" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div> 

                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtDefaultDuration" runat="server" CssClass="control-label col-md-2 no-padding-right">Default Duration</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtDefaultDuration" CssClass="form-control" runat="server"></asp:TextBox>
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
