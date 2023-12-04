<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmOfficeShift.aspx.cs" Inherits="BLL.HrmOfficeShift" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Office Shift
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlSchedule" runat="server" CssClass="control-label col-md-2 no-padding-right">Schedule</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlSchedule" CssClass="form-control" runat="server"></asp:DropDownList>
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
                        <asp:Label AssociatedControlID="txtLateCountGrace" runat="server" CssClass="control-label col-md-2 no-padding-right">Late Count Grace</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtLateCountGrace" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>


                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtMinHalfDayIn" CssClass="col-md-2 control-label no-padding-right" Text="Min Half Day In"></asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtMinHalfDayIn" runat="server" CssClass="form-control" placeholder="HH:mm" />
                            <ajaxToolkit:MaskedEditExtender ID="dtpMinHalfDayIn" runat="server" MaskType="Time" Mask="99:99" TargetControlID="txtMinHalfDayIn" AcceptAMPM="true" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtMaxHalfDayIn" CssClass="col-md-2 control-label no-padding-right" Text="Max Half Day In"></asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtMaxHalfDayIn" runat="server" CssClass="form-control" placeholder="HH:mm" />
                            <ajaxToolkit:MaskedEditExtender ID="dtpMaxHalfDayIn" runat="server" MaskType="Time" Mask="99:99" TargetControlID="txtMaxHalfDayIn" AcceptAMPM="true" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtMinStayHr" runat="server" CssClass="control-label col-md-2 no-padding-right">MinStayHour</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtMinStayHr" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtMinLateDay" runat="server" CssClass="control-label col-md-2 no-padding-right">Min Late Day</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtMinLateDay" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtNextLateDay" runat="server" CssClass="control-label col-md-2 no-padding-right">Next Late Day</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtNextLateDay" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-2">
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" />
                            <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-10 col-md-offset-1">
                                <div class="search-input">
                                    <i class="icon-search"></i>
                                    <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" Placeholder="Search" />
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                                <%--                                <asp:GridView ID="gvwWorkShift" CssClass="table " runat="server" AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />
                                        <asp:BoundField DataField="WkShfId" HeaderText="ID" />
                                        <asp:BoundField DataField="StartingDate" HeaderText="Starting Date" DataFormatString="{0:HH:mm}" />
                                        <asp:BoundField DataField="EndingDate" HeaderText="Ending Date" DataFormatString="{0:HH:mm}" />
                                        <asp:BoundField DataField="WkShfDes" HeaderText="Description" />
                                        <asp:BoundField DataField="InfStatus" HeaderText="Info Status" />
                                    </Columns>
                                </asp:GridView>--%>
                            </div>
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
        $(document).ready(function () {
            open_menu("Attendance");
        });
    </script>
</asp:Content>
