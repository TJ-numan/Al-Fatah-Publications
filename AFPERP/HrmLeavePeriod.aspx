<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmLeavePeriod.aspx.cs" Inherits="BLL.HrmLeavePeriod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                  Leave Period
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtLvPeriodName" runat="server" CssClass="control-label col-md-2 no-padding-right">Leave Period Name</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtLvPeriodName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPeriodStartDate" CssClass="control-label col-md-2 no-padding-right">Period Start Date</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox CssClass="form-control" ID="txtPeriodStartDate" placeholder="dd-MM-yyyy" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="txtPeriodStartDate" Format="dd-MM-yyyy" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPeriodEndDate" CssClass="control-label col-md-2 no-padding-right">Period End Date</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox CssClass="form-control" ID="txtPeriodEndDate" placeholder="dd-MM-yyyy" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="txtPeriodEndDate" Format="dd-MM-yyyy" runat="server" />
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
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click"/>
                            <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server"/>
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
                             <asp:GridView ID="gvLeavePeriod" CssClass="table " runat="server" AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />
                                        <asp:BoundField DataField="PerId" HeaderText="ID" />
                                        <asp:BoundField DataField="PerName" HeaderText="Period" />
                                        <asp:BoundField DataField="PerStDate" HeaderText="Start"/>
                                        <asp:BoundField DataField="PerEnDate" HeaderText="End" />
                                        <asp:BoundField DataField="Comments" HeaderText="Remark" /> 
                                        <asp:BoundField DataField="InfStId" HeaderText="Info Status" />
                                    </Columns>
                                </asp:GridView>   
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
