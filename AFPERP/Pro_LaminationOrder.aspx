<%@ Page Title="Lamination Order" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_LaminationOrder.aspx.cs" Inherits="BLL.Pro_LaminationOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="form-horizontal clearfix" runat="server">
                <div class="panel-body" style="border: 1px solid #BDC3CA">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Lamination Order
                        </div>
                        <%--<div id="frmLaminationOrder" runat="server" class="form-horizontal clearfix">--%>
                        <div class="panel-body">
                            <div class="col-md-12 no-padding clearfix">
                                <div class="col-md-6 clearfix">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtOrderDate" CssClass="col-xs-4 control-label no-padding-right" Text="Date"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtOrderDate" runat="server" CssClass="form-control" />
                                            <ajaxToolkit:CalendarExtender runat="server" TargetControlID="txtOrderDate" Format="yyyy-MM-dd" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtLemiOrderNo" CssClass="col-xs-4 control-label no-padding-right" Text="Lamination Order No"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtLemiOrderNo" runat="server" CssClass="form-control"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtOrderNo" CssClass="col-xs-4 control-label no-padding-right" Text="Cover Order No"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtOrderNo" runat="server" OnTextChanged="txtOrderNo_TextChanged" AutoPostBack="True"  CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlPressName" CssClass="col-xs-4 control-label no-padding-right" Text="Press"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList ID="ddlPressName" runat="server" CssClass="form-control" ReadOnly="True" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtPrintQty" CssClass="col-xs-4 control-label no-padding-right" Text="Print Qty"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtPrintQty" runat="server" CssClass="form-control" ReadOnly="True" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6 clearfix">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtGroup" CssClass="col-xs-4 control-label no-padding-right" Text="Group"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtGroup" runat="server" CssClass="form-control" ReadOnly="True" disabled="" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtClassName" CssClass="col-xs-4 control-label no-padding-right" Text="Class"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtClassName" runat="server" CssClass="form-control" ReadOnly="True" disabled="" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtTypeName" CssClass="col-xs-4 control-label no-padding-right" Text="Type"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtTypeName" runat="server" CssClass="form-control" ReadOnly="True" disabled="" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlBookName" CssClass="col-xs-4 control-label no-padding-right" Text="Book Name"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList ID="ddlBookName" runat="server" CssClass="form-control" ReadOnly="True" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtEdition" CssClass="col-xs-4 control-label no-padding-right" Text="Edition"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtEdition" runat="server" CssClass="form-control" ReadOnly="True" disabled="" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <hr />
                            </div>
                            <div class="col-md-12 no-padding clearfix">
                                <div class="col-md-6 clearfix">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlLemiType" CssClass="col-xs-4 control-label no-padding-right" Text="Type"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList ID="ddlLemiType" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlLemiParty" CssClass="col-sm-4 control-label no-padding-right" Text="Party"></asp:Label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="ddlLemiParty" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtQty" CssClass="col-xs-4 control-label no-padding-right" Text="Qty"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtQty" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-xs-8 col-xs-offset-4">
                                            <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-sm pull-right" Text="Add" OnClick="btnAdd_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div><br/>
                            
                            <div class="col-md-12 table-responsive clearfix">
                                <asp:GridView ID="gvwLamiOrder" runat="server" CssClass="table grid-view" AutoGenerateColumns="false">
                                     <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:BoundField DataField="Type" HeaderText="Type" />
                                        <asp:BoundField DataField="PartyName" HeaderText="Name" />
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
                                <div class="col-md-6 col-md-offset-6 clearfix">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtTotalQty" CssClass="col-xs-4 control-label no-padding-right" Text="Total Qty"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtTotalQty" runat="server" CssClass="form-control" ReadOnly="true" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-xs-8 col-xs-offset-4">
                                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click" />
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
            open_menu("Lamination");
        });
    </script>
</asp:Content>
