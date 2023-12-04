<%@ Page Title="Binding Order" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_BindingOrder.aspx.cs" Inherits="BLL.Pro_BindingOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <asp:UpdatePanel ID="UpadatePanel1" runat="server">
        <ContentTemplate>
            <div class="form-horizontal clearfix" runat="server">
                <div class="panel-body" style="border: 1px solid #BDC3CA">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Binding Order Details  
                        </div>                       
                        <div class="panel-body">
                            <div class="col-md-12 no-padding clearfix">
                                <div class="col-md-6 clearfix">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtBookCode" CssClass="col-xs-4 control-label no-padding-right" Text="Book Code"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtBookCode" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlBookName" CssClass="col-sm-4 control-label no-padding-right" Text="Book Name"></asp:Label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="ddlBookName" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlPressName" CssClass="col-sm-4 control-label no-padding-right" Text="Press Name"></asp:Label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="ddlPressName" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlBinderName" CssClass="col-sm-4 control-label no-padding-right" Text="Binder Name"></asp:Label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="ddlBinderName" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6 clearfix">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlType" CssClass="col-sm-4 control-label no-padding-right" Text="Book Type"></asp:Label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlClass" CssClass="col-sm-4 control-label no-padding-right" Text="Class"></asp:Label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlEdition" CssClass="col-sm-4 control-label no-padding-right" Text="Edition"></asp:Label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="ddlEdition" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="checkbox">
                                        <div class="col-xs-8 col-xs-offset-4">
                                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="chkCover" Text="Cover"></asp:Label>
                                            <asp:CheckBox ID="chkCover" runat="server" />
                                        </div>
                                        <div class="col-xs-8 col-xs-offset-4">
                                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="chkInner" Text="Inner"></asp:Label>
                                            <asp:CheckBox ID="chkInner" runat="server" />
                                        </div>
                                        <div class="col-xs-8 col-xs-offset-4">
                                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="chkForma" Text="Forma"></asp:Label>
                                            <asp:CheckBox ID="chkForma" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-xs-8 col-xs-offset-4">
                                            <asp:Button ID="btnLoad" Text="Load" CssClass="btn btn-info" runat="server" OnClick="btnLoad_Click" />
                                            <asp:Button ID="btnRefresh" Text="Refresh" CssClass="btn btn-primary" runat="server" OnClick="btnRefresh_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div><br/>
                            
                            <div class="col-md-12 clearfix table-responsive">
                                <asp:GridView ID="gvwBinderOrder" runat="server" CssClass="grid-view table" Align="Center" AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="gvwBinderOrder_OnPageIndexChanging" PageSize="10">
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:BoundField DataField="BookID" HeaderText="BookID" />
                                        <asp:BoundField DataField="BookName" HeaderText="Book Name" />
                                        <asp:BoundField DataField="Class" HeaderText="Class" />
                                        <asp:BoundField DataField="Type" HeaderText="Type" />
                                        <asp:BoundField DataField="Edition" HeaderText="Edition" />
                                        <asp:BoundField DataField="Binder" HeaderText="Binder" />
                                        <asp:BoundField DataField="PressOrder" HeaderText="PressOrder" />
                                        <asp:BoundField DataField="Date" HeaderText="Date" />
                                        <asp:BoundField DataField="Cover" HeaderText="Cover" />
                                        <asp:BoundField DataField="Inner" HeaderText="Inner" />
                                        <asp:BoundField DataField="Forma" HeaderText="Forma" />
                                        <asp:BoundField DataField="FormaQty" HeaderText="Forma Qty" />
                                        <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                    </Columns>
                                    <SelectedRowStyle BackColor="#393737" Font-Bold="true" ForeColor="#F7F7F7" />
                                </asp:GridView>
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
