<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmWorkShift.aspx.cs" Inherits="BLL.HrmWorkShift" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <link href="Content/jquery-ui-timepicker-addon.min.css" rel="stylesheet" />
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Work Shift
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlScheduleId" runat="server" CssClass="control-label col-md-2 no-padding-right">Office Schedule</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlScheduleId" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group" style="display:none">
                        <asp:Label AssociatedControlID="txtWorkShiftId" runat="server" CssClass="control-label col-md-2 no-padding-right">Work Shift Id</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtWorkShiftId" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtWorkShift" runat="server" CssClass="control-label col-md-2 no-padding-right">Work Shift</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtWorkShift" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtStartingTime" CssClass="col-md-2 control-label no-padding-right" Text="Starting Time"></asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtStartingTime" runat="server" CssClass="form-control" placeholder="HH:mm" />
                            <ajaxToolkit:MaskedEditExtender ID="dtStartingTime" runat="server" MaskType="Time" Mask="99:99" TargetControlID="txtStartingTime" AcceptAMPM="true" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtEndingTime" CssClass="col-md-2 control-label no-padding-right" Text="Ending Time"></asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtEndingTime" runat="server" CssClass="form-control" placeholder="HH:mm" />
                            <ajaxToolkit:MaskedEditExtender ID="dtEndingTime" runat="server" MaskType="Time" Mask="99:99" TargetControlID="txtEndingTime" AcceptAMPM="true" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtGraceMinutes" runat="server" CssClass="control-label col-md-2 no-padding-right">Grace Minutes</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtGraceMinutes" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>


                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtMinStatyHr" runat="server" CssClass="control-label col-md-2 no-padding-right">Minimum Stay Hr</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtMinStatyHr" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-2">
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                            <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnUpdate_Click" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group"  style="display:none">
                            <div class="col-md-10 col-md-offset-1">
                                <div class="search-input">
                                    <i class="icon-search"></i>
                                    <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" Placeholder="Search" />
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                                <asp:GridView ID="gvwWorkShift" CssClass="table " runat="server" AutoGenerateColumns="false" OnRowDataBound="gvwWorkShift_RowDataBound" OnSelectedIndexChanged="gvwWorkShift_SelectedIndexChanged">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />
                                        <asp:BoundField DataField="WkShfId" HeaderText="ID" />
                                        <asp:BoundField DataField="WkShfStartT" HeaderText="Starting Date" />
                                        <asp:BoundField DataField="WkShfEndT" HeaderText="Ending Date" />
                                        <asp:BoundField DataField="WkShfDes" HeaderText="Description" />
                                        <asp:BoundField DataField="InfStId" HeaderText="Info Status" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <%--DataFormatString="{0:HH:mm}"--%>
                            <br />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSHR" runat="server">
    <script type="text/javascript">
        $(function () {
            $('[id*=gvwWorkShift]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Setting", "Work Shift");
        });
    </script>
</asp:Content>
