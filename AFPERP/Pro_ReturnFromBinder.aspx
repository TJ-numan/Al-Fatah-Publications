<%@ Page Title="Return From Binder" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_ReturnFromBinder.aspx.cs" Inherits="BLL.Pro_ReturnFromBinder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <asp:UpdatePanel ID="UpadatePanel1" runat="server">
        <ContentTemplate>
            <div class="form-horizontal clearfix" runat="server">
                <div class="panel-body" style="border: 1px solid #BDC3CA">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Return From Binder
                        </div>
                        <%--<div id="frmReturnFromBinder" runat="server" class="form-horizontal clearfix">--%>
                        <div class="panel-body">
                            <div class="col-md-12 no-padding clearfix">
                                <div class="col-md-6 clearfix">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtOrderDate" CssClass="col-xs-4 control-label no-padding-right" Text="Date"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtOrderDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                            <ajaxToolkit:CalendarExtender runat="server" TargetControlID="txtOrderDate" Format="yyyy-MM-dd" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" AssociatedControlID="txtReceiceNo" CssClass="col-xs-4 control-label no-padding-right" Text="Receive No"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtReceiceNo" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlBookBinderName" CssClass="col-sm-4 control-label no-padding-right" Text="Binding Name"></asp:Label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="ddlBookBinderName" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlCategory" CssClass="col-xs-4 control-label no-padding-right" Text="Category"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlGroup" CssClass="col-xs-4 control-label no-padding-right" Text="Group"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlClass" CssClass="col-xs-4 control-label no-padding-right" Text="Class"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlType" CssClass="col-xs-4 control-label no-padding-right" Text="Type"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlBookName" CssClass="col-sm-4 control-label no-padding-right" Text="Book Name"></asp:Label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="ddlBookName" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlBookName_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlEdition" CssClass="col-xs-4 control-label no-padding-right" Text="Edition"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList ID="ddlEdition" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="col-md-8 col-md-offset-4 table-responsive clearfix">
                                <table class="table no-head-padding">
                                    <tr>
                                        <td>
                                            <asp:Label AssociatedControlID="ddlItemType" runat="server" Text="Item Type"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label AssociatedControlID="txtQty" runat="server" Text="Qty"></asp:Label>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px;">
                                            <asp:DropDownList ID="ddlItemType" runat="server" CssClass="form-control">
                                                <asp:ListItem>Cover</asp:ListItem>
                                                <asp:ListItem>Inner</asp:ListItem>
                                                <asp:ListItem>2 No Forma</asp:ListItem>
                                                <asp:ListItem>Main Forma</asp:ListItem>
                                                <asp:ListItem>Postani</asp:ListItem>
                                                <asp:ListItem>Rebing Book</asp:ListItem>
                                                <asp:ListItem>Golti Forma</asp:ListItem>
                                                <asp:ListItem>Promotional</asp:ListItem>
                                                <asp:ListItem>Administrative</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="txtQty" runat="server" CssClass="form-control" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-xs" Text="Add" OnClick="btnAdd_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="clearfix"></div>
                            <div class="col-md-12 clearfix table-responsive">
                                <asp:GridView ID="gvwReturnFB" runat="server" CssClass="table grid-view" AutoGenerateColumns="false">
                                     <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:BoundField DataField="BookName" HeaderText="BookName" />
                                        <asp:BoundField DataField="Class" HeaderText="Class" />
                                        <asp:BoundField DataField="Type" HeaderText="Type" />
                                        <asp:BoundField DataField="Edition" HeaderText="Edition" />
                                        <asp:BoundField DataField="ItemType" HeaderText="Item Type" />
                                        <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("Serial") %>' OnClick="lbDelete_Click">
                                                 Delete
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="col-md-12 clearfix no-padding">
                                <div class="col-md-6 col-md-offset-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtTotalPlateQty" CssClass="col-xs-4 control-label no-padding-right" Text="Total Qty"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtTotalPlateQty" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-xs-8 col-xs-offset-4">
                                            <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-info" runat="server" OnClick="btnPrint_Click" />
                                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSPro" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Binding");
        });
    </script>
</asp:Content>
