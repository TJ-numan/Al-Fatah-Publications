<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmInterviewTest.aspx.cs" Inherits="BLL.HrmInterviewTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
     <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Interview Test
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
                        <asp:Label AssociatedControlID="txtTestTitle" runat="server" CssClass="control-label col-md-2 no-padding-right">Test Title</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtTestTitle" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtTotalMarks" runat="server" CssClass="control-label col-md-2 no-padding-right">Total Marks</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtTotalMarks" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtTotalTime" runat="server" CssClass="control-label col-md-2 no-padding-right">Total Time</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtTotalTime" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtTimeSegment" runat="server" CssClass="control-label col-md-2 no-padding-right">Time Segment</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtTimeSegment" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtObtainMark" runat="server" CssClass="control-label col-md-2 no-padding-right">Obtain Mark</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtObtainMark" CssClass="form-control" runat="server"></asp:TextBox>
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
