<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmOrganogram.aspx.cs" Inherits="BLL.HrmOrganogram" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
      <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Organogram
                </div>
                <div class="panel-body">
  
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>     
                        <div class="form-group" >
                            <asp:Label AssociatedControlID="txtOrgId" runat="server" CssClass="control-label col-md-2 no-padding-right">Organogram Id</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtOrgId" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>  
                                      
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlJobTitle" runat="server" CssClass="control-label col-md-2 no-padding-right">Position Title</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlJobTitle" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlDepartment" runat="server" CssClass="control-label col-md-2 no-padding-right">Department</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlDepartment" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>   
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlDesignation" runat="server" CssClass="control-label col-md-2 no-padding-right">Designation</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlDesignation" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div> 
                    
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlJobCategory" runat="server" CssClass="control-label col-md-2 no-padding-right">Job Category</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlJobCategory" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="chkIsDefault" runat="server" CssClass="control-label col-md-2 no-padding-right">Is Default</asp:Label>
                            <div class="col-md-4">
                                <asp:CheckBox ID="chkIsDefault" CssClass="form-control" runat="server"></asp:CheckBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlReportToPosition" runat="server" CssClass="control-label col-md-2 no-padding-right">Report To</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlReportToPosition" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>  

                        <div class="form-group">
                            <div class="col-md-4 col-md-offset-2">
                                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick ="btnSave_Click" />
                                <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick ="btnUpdate_Click" />
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
                 open_menu("Setting", "Organogram");
             });
    </script>
</asp:Content>
