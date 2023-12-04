<%@ Page Title="Binder Bill" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_BinderBill.aspx.cs" Inherits="BLL.Pro_BinderBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Binder Bill
                </div>

                <%--<div id="frmBinderBill" runat="server" class="form-horizontal clearfix">--%>
                <div class="panel-body">
                    <div class="col-md-12 no-padding clearfix">
                        <div class="col-md-6 clearfix">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtBillDate" CssClass="col-xs-4 control-label no-padding-right" Text="Bill Date"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtBillDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtBillDate" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtBillNo" CssClass="col-xs-4 control-label no-padding-right" Text="Bill No"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtBillNo" runat="server" CssClass="form-control" />
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
                        </div>
                        <div class="col-md-6 clearfix">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlBookName" CssClass="col-sm-4 control-label no-padding-right" Text="Book Name"></asp:Label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="ddlBookName" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlBookName_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlEdition" CssClass="col-xs-4 control-label no-padding-right" Text="Edition"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlEdition" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlEdition_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlBindingHosue" CssClass="col-sm-4 control-label no-padding-right" Text="Binding House"></asp:Label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="ddlBindingHosue" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlBindingHosue_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlReceiveType" CssClass="col-xs-4 control-label no-padding-right" Text="Receive Type"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlReceiveType" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlReceiveType_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="gvwBinderBill" runat="server" CssClass="table grid-view" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect" runat="server" OnCheckedChanged="chkSelect_CheckedChanged" AutoPostBack="true"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Qty" HeaderText="Qty"/>
                                        <asp:BoundField DataField="ReceiveID" HeaderText="ReceiveID"/>
                                        <asp:BoundField DataField="ReceiveDate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"/>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12 clearfix no-padding">
                        <div class="col-md-6 clearfix">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtTotalQty" CssClass="col-xs-4 control-label no-padding-right" Text="Total Qty"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtTotalQty" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtAcForma" CssClass="col-xs-4 control-label no-padding-right" Text="Actual Forma"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtAcForma" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtPayForma" CssClass="col-xs-4 control-label no-padding-right" Text="Pay Forma"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtPayForma" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtPayForma_TextChanged" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblMiniBill" AssociatedControlID="txtMinimumBillRate" CssClass="col-xs-4 control-label no-padding-right" Text="Minimum Rate"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtMinimumBillRate" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtBillRate" CssClass="col-xs-4 control-label no-padding-right" Text="Bill Rate"></asp:Label>
                                <div class="col-xs-4">
                                    <asp:TextBox ID="txtBillRate" runat="server" CssClass="form-control" />
                                </div>
                                <div class="col-xs-4">
                                    <asp:DropDownList ID="ddlRateBy" runat="server" CssClass="form-control">
                                        <asp:ListItem>Rate By Forma</asp:ListItem>
                                        <asp:ListItem>Rate By Qty</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 clearfix">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtBindingBill" CssClass="col-xs-4 control-label no-padding-right" Text="Binding Bill"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtBindingBill" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtLabourBill" CssClass="col-xs-4 control-label no-padding-right" Text="Labour Bill"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtLabourBill" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtOtherCost" CssClass="col-xs-4 control-label no-padding-right" Text="Other Cost"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtOtherCost" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtTotalBill" CssClass="col-xs-4 control-label no-padding-right" Text="Total Bill"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtTotalBill" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-8 col-xs-offset-4">
                                    <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                                    <asp:Button ID="btnPreview" Text="Priview" CssClass="btn btn-info" runat="server" OnClick="btnPreview_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSPro" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Binding");
        });
    </script>
</asp:Content>
