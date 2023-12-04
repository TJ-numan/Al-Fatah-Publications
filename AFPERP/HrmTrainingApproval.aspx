<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmTrainingApproval.aspx.cs" Inherits="BLL.HrmTrainingApproval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
      <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Training Approval
                </div>
                <div class="panel-body">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>      
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlTrainingApplication" runat="server" CssClass="control-label col-md-2 no-padding-right">Training Application</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlTrainingApplication" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div> 
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlEmployee" runat="server" CssClass="control-label col-md-2 no-padding-right">Employee</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlEmployee" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>  
                        <div class="form-group">
                            <asp:Label AssociatedControlID="chkIsApproved" runat="server" CssClass="control-label col-md-2 no-padding-right">Is Approved</asp:Label>
                            <div class="col-md-4">
                                <asp:CheckBox ID="chkIsApproved" CssClass="form-control" runat="server"></asp:CheckBox>
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
