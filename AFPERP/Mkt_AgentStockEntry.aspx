<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_AgentStockEntry.aspx.cs" Inherits="BLL.Mkt_AgentStockEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Agent Stock Entry
                </div>

                 <div class="panel-body">
                <div class="form-group">
                    <asp:Label AssociatedControlID="ddlProjectName" CssClass="col-md-4 control-label" Text="Project Name " runat="server"></asp:Label>
                    <div class="col-md-5">
                        <asp:DropDownList CssClass="form-control" ID="ddlProjectName" runat="server" OnSelectedIndexChanged="ddlProjectName_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-4 control-label no-padding-left" Text="Start Date" runat="server"></asp:Label>
                        <div class="input-group col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-mm-dd" runat="server" ReadOnly="true" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-4 control-label no-padding-left" Text="End Date " runat="server"></asp:Label>
                        <div class="input-group col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-mm-dd" runat="server" ReadOnly="true" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>



                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlLibraryName" CssClass="col-md-4 control-label" Text="Agent Name" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlLibraryName" runat="server" AutoPostBack="false">
                                <asp:ListItem Value="">--Select--</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                     <div class="row">
                        <div class="col-md-9 pull-right">
                            <div class="form-group">
                                <asp:GridView runat="server" CssClass="table table-bordered" ID="gvwProjectBooks" AutoGenerateColumns="False">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:BoundField DataField="StockProjectBookID" HeaderText="PBID" />
                                        <asp:BoundField DataField="BookID" HeaderText="Book ID" />
                                        <asp:BoundField DataField="BookName" HeaderText="Book Name" />
                                        <asp:BoundField DataField="Edition" HeaderText="Edition" />
                                        <asp:BoundField DataField="TypeName" HeaderText="Type" />
                                        <asp:BoundField DataField="ClassName" HeaderText="Class" />
                                  <%--  <asp:BoundField DataField="DueAmnt" HeaderText="Due Amnt" />
                                        <asp:BoundField DataField="PayTypName" HeaderText="Pay Type" />
                                        <%--<asp:BoundField DataField="AccountTitle" HeaderText="Account Title_En" />
                                        <asp:BoundField DataField="AccountTitle_bn" HeaderText="Account Title_Bn" ItemStyle-Font-Names="SutonnyMJ" />
                                        <asp:BoundField DataField="AccountNo" HeaderText="Acc. No" />
                                        <asp:BoundField DataField="AcTypeName" HeaderText="Acc. Type" />
                                        <asp:BoundField DataField="BankName" HeaderText="Bank Name" />
                                        <asp:BoundField DataField="Branch" HeaderText="Branch" /> 
                                        --%>
                                        <asp:TemplateField HeaderText="Stock Qty">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtQty" runat="server" data-field="StockQty" Enabled="true"  Width="70px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                  <%--                      <asp:TemplateField HeaderText="Challan Value">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtChallanValue" runat="server" data-field="pro-rate" Enabled="false" CssClass="click pro-rate" Width="70px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Payment Date">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtpayDate" runat="server" data-field="pro-rate" Enabled="false" CssClass="click pro-rate" Width="70px" placeholder="yyyy-mm-dd"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtpayDate" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="PSId" HeaderText="SId" />--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-4">
                                    <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-lock pull-right" runat="server" OnClientClick="if (!confirm('Do You Want to Save?')) return false;" OnClick="btnSave_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
<%--                    <div class="form-group">
                        <div class="input-group col-md-8 col-md-offset-4">
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-info" runat="server"/>
                        </div>
                    </div>--%>

                </div>

                 <div class="panel-body">
                        <div class="table-responsive table-bordered clearfix ">
                            <asp:GridView ID="gvwProjectForView" CssClass="table " runat="server" AutoGenerateColumns="false" OnRowDataBound="gvwProjectForView_RowDataBound" OnSelectedIndexChanged="gvwProjectForView_SelectedIndexChanged">
                                <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                <Columns>

                                    <asp:BoundField DataField="StockProjectID" HeaderText="SPID" />
                                    <asp:BoundField DataField="StockProjectName" HeaderText="Project Name" />
                                    <asp:BoundField DataField="LibraryID" HeaderText="LibraryID" />
                                    <asp:BoundField DataField="Library" HeaderText="Library Name" />
                                    <asp:BoundField DataField="StockQty" HeaderText="Stock Qty" />
                                    <asp:CommandField SelectText="Edit" ShowSelectButton="true" Visible="true" ItemStyle-CssClass="btn btn-compose"
                                        HeaderStyle-CssClass="HiddenColumn" />
                                </Columns>



                            </asp:GridView>
                        </div>
                        <br />
                    </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Library Information");
        });
    </script>
</asp:Content>
