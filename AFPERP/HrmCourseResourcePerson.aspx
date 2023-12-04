<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmCourseResourcePerson.aspx.cs" Inherits="BLL.HrmCourseResourcePerson" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
        <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Course Resource Person
                </div>
                <div class="panel-body">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>      
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtResourcePersName" runat="server" CssClass="control-label col-md-2 no-padding-right">Resource Person Name</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtResourcePersName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtProfessionTitle" runat="server" CssClass="control-label col-md-2 no-padding-right">Profession Title</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtProfessionTitle" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtInstituteAdd" runat="server" CssClass="control-label col-md-2 no-padding-right">Institute Address</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtInstituteAdd" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtResourceAdd" runat="server" CssClass="control-label col-md-2 no-padding-right">Resource Address</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtResourceAdd" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtPhone" runat="server" CssClass="control-label col-md-2 no-padding-right">Phone</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtContactPerson" runat="server" CssClass="control-label col-md-2 no-padding-right">Contact Person</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtContactPerson" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtContactPhone" runat="server" CssClass="control-label col-md-2 no-padding-right">Contact Phone</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtContactPhone" CssClass="form-control" runat="server"></asp:TextBox>
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
