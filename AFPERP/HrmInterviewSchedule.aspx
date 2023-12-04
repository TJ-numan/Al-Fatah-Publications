<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmInterviewSchedule.aspx.cs" Inherits="BLL.HrmInterviewSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
     <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Interview Schedule
                </div>
                <div class="panel-body">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>      
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlScheduleTitle" runat="server" CssClass="control-label col-md-2 no-padding-right">Schedule Title</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlScheduleTitle" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div> 
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlInterviewType" runat="server" CssClass="control-label col-md-2 no-padding-right">Interview Type</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlInterviewType" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtStartingTime" CssClass="col-md-2 control-label no-padding-right" Text="Starting Time"></asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtStartingTime" runat="server" CssClass="form-control" placeholder="HH:mm" />
                            <ajaxToolkit:MaskedEditExtender ID="dtStartTime" runat="server" MaskType="Time" Mask="99:99" TargetControlID="txtStartingTime" AcceptAMPM="true" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtEndingTime" CssClass="col-md-2 control-label no-padding-right" Text="Ending Time"></asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtEndingTime" runat="server" CssClass="form-control" placeholder="HH:mm" />
                            <ajaxToolkit:MaskedEditExtender ID="dtEndTime" runat="server" MaskType="Time" Mask="99:99" TargetControlID="txtEndingTime" AcceptAMPM="true" />
                        </div>
                    </div> 
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtCanNo" runat="server" CssClass="control-label col-md-2 no-padding-right">ConNO</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtCanNo" CssClass="form-control" runat="server"></asp:TextBox>
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
