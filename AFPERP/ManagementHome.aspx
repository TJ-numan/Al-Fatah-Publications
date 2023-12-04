<%@ Page Title="" Language="C#" MasterPageFile="~/ManagementMaster.Master" AutoEventWireup="true" CodeBehind="ManagementHome.aspx.cs" Inherits="BLL.ManagementHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
     <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    View Daily Summary Report
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-5 control-label" Text="From" runat="server"></asp:Label>
                        <div class="col-md-2">
                            <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-5 control-label" Text="To" runat="server"></asp:Label>
                        <div class="col-md-2">
                            <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
<%--                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlViewers" runat="server" CssClass="col-md-4 control-label" Text="View Option" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlViewers" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0"> Select any type</asp:ListItem>
                                <asp:ListItem Value="1"> View as Pdf File</asp:ListItem>
                                <asp:ListItem Value="2"> View as Excel File</asp:ListItem>
                                <asp:ListItem Value="3"> View as Word File</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>--%>
                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-5">
                            <asp:Button ID="btnRefresh" Text="Refresh" CssClass="btn btn-primary" runat="server" OnClick="btnRefresh_Click" />
                            <asp:Button ID="btnShow" Text="Print" CssClass="btn btn-info" runat="server" OnClick="btnShow_Click" />
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="table-responsive table-bordered clearfix ">
                            <asp:GridView ID="gvDailySummaryDetails" CssClass="table " runat="server" AutoGenerateColumns="false" ShowFooter="true" OnRowDataBound="gvDailySummaryDetails_RowDataBound">
                                <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                <Columns>
                                    <asp:BoundField DataField="CompanyName" HeaderText="Company Name"/>
                                    <asp:BoundField DataField="CChallan" HeaderText="Challan" DataFormatString="{0:0,0}"/>
                                    <asp:BoundField DataField="CReturn" HeaderText="Return" DataFormatString="{0:0,0}"/>                               
                                    <asp:BoundField DataField="NetCh" HeaderText="Net Challan" DataFormatString="{0:0,0}"/>
                                    <asp:BoundField DataField="CPC" HeaderText="PC" DataFormatString="{0:0,0}"/>
                                    <asp:BoundField DataField="CDeposit" HeaderText="Deposit" DataFormatString="{0:0,0}"/> 
                                    <asp:BoundField DataField="Due" HeaderText="Due" DataFormatString="{0:0,0}"/>                                                                                               
                                </Columns>
                            </asp:GridView>
                        </div>
                        <br />
                    </div> 
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSPro" runat="server">
</asp:Content>
