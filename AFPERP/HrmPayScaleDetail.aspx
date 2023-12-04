<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmPayScaleDetail.aspx.cs" Inherits="BLL.HrmPayScaleDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
       <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Pay Scale Detail
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlPayScale" runat="server" CssClass="control-label col-md-2 no-padding-right">Pay Scale</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlPayScale" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlPayHead" runat="server" CssClass="control-label col-md-2 no-padding-right">Pay Head</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlPayHead" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtAmount" runat="server" CssClass="control-label col-md-2 no-padding-right">Amount</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server"></asp:TextBox>
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
                                <asp:GridView ID="gvwPayScaleDetail" CssClass="table " runat="server" AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />
                                        <asp:BoundField DataField="PSDetId" HeaderText="ID" />
                                        <asp:BoundField DataField="PSName" HeaderText="Pay Scale" />
                                        <asp:BoundField DataField="PaHName" HeaderText="Pay Head" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
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
                open_menu("PIMS", "Basic Setting");
            });
    </script>
</asp:Content>
