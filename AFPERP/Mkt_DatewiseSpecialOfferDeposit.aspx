<%@ Page Title="" Language="C#" MasterPageFile="~/AccountingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_DatewiseSpecialOfferDeposit.aspx.cs" Inherits="BLL.Mkt_DatewiseSpecialOfferDeposit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AccountingContent" runat="server">
<div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Show Agent Deposit Report
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-4 control-label" Text="From" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-4 control-label" Text="To" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlRegionMain" runat="server" CssClass="col-md-4 control-label no-padding-right" Text="Region Main" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlRegionMain" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlRegionMain_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlRegion" runat="server" CssClass="col-md-4 control-label" Text="Region" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlDivision" runat="server" CssClass="col-md-4 control-label" Text="Division" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlDivision" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlTeritory" runat="server" CssClass="col-md-4 control-label" Text="Teritory" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlTeritory" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">
                            <asp:CheckBox ID="chkIsAlia" CssClass="checkbox pull-left" runat="server" />
                            <asp:Label AssociatedControlID="chkIsAlia" CssClass="control-label" runat="server" Text="Alia"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">
                            <asp:CheckBox ID="chkIsQawmi" CssClass="checkbox pull-left" runat="server" />
                            <asp:Label AssociatedControlID="chkIsQawmi" CssClass="control-label" runat="server" Text="Qawmi"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">
                            <asp:CheckBox ID="chkIsAliaCounter" CssClass="checkbox pull-left" runat="server" />
                            <asp:Label AssociatedControlID="chkIsAliaCounter" CssClass="control-label" runat="server" Text="Alia Counter"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">
                            <asp:CheckBox ID="chkIsQawmiCounter" CssClass="checkbox pull-left" runat="server" />
                            <asp:Label AssociatedControlID="chkIsQawmiCounter" CssClass="control-label" runat="server" Text="Qawmi Counter"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlViewers" runat="server" CssClass="col-md-4 control-label" Text="View Option" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlViewers" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0"> Select any type</asp:ListItem>
                                <asp:ListItem Value="1"> View as Pdf File</asp:ListItem>
                                <asp:ListItem Value="2"> View as Excel File</asp:ListItem>
                                <asp:ListItem Value="3"> View as Word File</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
 

                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">
                            <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-Primary" runat="server" OnClick="btnShow_Click" />
                            <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-info" runat="server" OnClick="btnPrint_Click" />
                        </div>
                    </div>
                </div>
                <!--------Start Of Mr Gridview-------->
                <div class="panel-body">
                        <div class="table-responsive table-bordered clearfix ">
                            <asp:GridView ID="gvMRSheetDetailsUpdate" CssClass="table " runat="server" AutoGenerateColumns="false">
                                <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                <Columns>
                                    <asp:BoundField DataField="LibraryID" HeaderText="LibraryID" />
                                    <asp:BoundField DataField="LibraryName" HeaderText="LibraryName" />
                                    <asp:BoundField DataField="LibraryAddress" HeaderText="ShortAddress" />
                                    <asp:BoundField DataField="Com" HeaderText="Com" />                                   
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:0}"/>
                                    <asp:BoundField DataField="SpBonus" HeaderText="SpBonus" DataFormatString="{0:0}"/>
                                </Columns>
                                <SelectedRowStyle BackColor="#F4B6B6" Font-Bold="true" ForeColor="#110101" />
                            </asp:GridView>
                        </div>
                        <br />
                    </div>



                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="col-md-6">
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtTotalAmount" Text="Total Amount" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox CssClass="form-control" ID="txtTotalAmount" runat="server" ReadOnly="True" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtTotalSpBonus" Text="Total SpBonus" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox CssClass="form-control" ID="txtTotalSpBonus" runat="server" ReadOnly="True" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtRemarks" Text="Remarks" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox CssClass="form-control" ID="txtRemarks" runat="server" />
                                    </div>
                                </div>
                                
                                <div class="form-group">
                                    <div class="col-md-6 col-md-offset-4">
                                        <asp:Button ID="btnSave" Text="Save As MR" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                                        &nbsp;&nbsp;&nbsp; 
                                    </div>
                                </div>



                            </div>
                        </div>
                  </div>
                <!--------End Of Mr Gridview-------->
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RequiredJSAcc" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Reports", "Deposit");
        });
    </script>
</asp:Content>