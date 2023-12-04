<%@ Page Title="" Language="C#" MasterPageFile="~/MISMaster.master" AutoEventWireup="true" CodeBehind="MIS_UserManage.aspx.cs" Inherits="BLL.MIS_UserManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MISContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    User Manage
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="ddlUser" CssClass="col-md-4 control-label">User Name</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlUser" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="ddlForm" CssClass="col-md-4 control-label">Form Name</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlForm" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-4 control-label">Permissions</asp:Label>
                        <div class="col-md-6">
                            <label class="checkbox-inline">
                                <asp:CheckBox runat="server" ID="chkView" GroupName="Type" />View 
                            </label>
                            <label class="checkbox-inline">
                                <asp:CheckBox runat="server" ID="chkInsert" GroupName="Type" />Insert
                            </label>
                            <label class="checkbox-inline">
                                <asp:CheckBox runat="server" ID="chkUpdate" GroupName="Type" />Update
                            </label>
                            <label class="checkbox-inline">
                                <asp:CheckBox runat="server" ID="chkDelete" GroupName="Type"/>Delete
                            </label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6 col-md-offset-2">
                            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary pull-right" OnClick="btnSave_OnClick"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSPro" runat="server">
</asp:Content>
