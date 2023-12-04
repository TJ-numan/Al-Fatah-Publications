<%@ Page Title="Plate Return" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_PlateReturn.aspx.cs" Inherits="BLL.Pro_PlateReturn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Plate Return
                </div>
                <%--<div id="frmPlateReturn" runat="server" class="form-horizontal clearfix">--%>
                <div class="panel-body">
                    <div class="col-md-12 no-padding clearfix">
                        <div class="col-md-6 clearfix">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtReturnID" CssClass="col-xs-4 control-label no-padding-right" Text="Plate Return ID"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtReturnID" runat="server" CssClass="form-control" ReadOnly="true"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtPlateRetDate" CssClass="col-xs-4 control-label no-padding-right" Text="Date"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtPlateRetDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtPlateRetDate" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12 no-padding clearfix">
                        <div class="col-md-6 clearfix">
                            <div class="checkbox">
                                <div class="col-xs-8 col-xs-offset-4">
                                    <asp:RadioButton ID="chkRtnGodown" runat="server" GroupName="PlateTrns" OnCheckedChanged="chkRtnGodown_CheckedChanged" AutoPostBack="true"/>
                                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="chkRtnGodown" Text="Return In Godown"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlPressName" CssClass="col-xs-4 control-label no-padding-right" Text="From Press Name"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlPressName" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 clearfix">
                            <div class="checkbox">
                                <div class="col-xs-8 col-xs-offset-4">
                                    <asp:RadioButton ID="chkPlateRetPT" runat="server" GroupName="PlateTrns"  AutoPostBack="true" OnCheckedChanged="chkPlateRetPT_CheckedChanged"/>
                                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="chkPlateRetPT" Text="Press Transfer"></asp:Label> 
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlTransferPress" CssClass="col-xs-4 control-label no-padding-right" Text="To Press Name"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlTransferPress" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12 clearfix">
                        <hr />
                    </div>
                    <div class="col-md-12 clearfix no-padding">
                        <div class="col-md-6 clearfix">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlCategory" CssClass="col-xs-4 control-label no-padding-right" Text="Category"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
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
                        <div class="col-md-6 clearfix">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlPlateFor" CssClass="col-xs-4 control-label no-padding-right" Text="Plate For"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlPlateFor" runat="server" CssClass="form-control">
                                        <asp:ListItem>Cover</asp:ListItem>
                                        <asp:ListItem>Inner</asp:ListItem>
                                        <asp:ListItem>2 No Forma</asp:ListItem>
                                        <asp:ListItem>Main Forma</asp:ListItem>
                                        <asp:ListItem>Postani</asp:ListItem>
                                        <asp:ListItem>Promotional</asp:ListItem>
                                        <asp:ListItem>Administrative</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                           <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlPlateType" CssClass="col-xs-4 control-label no-padding-right" Text="Plate Type"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlPlateType" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                           <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlPlateSize" CssClass="col-xs-4 control-label no-padding-right" Text="Plate Size"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlPlateSize" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlPlateUse" CssClass="col-xs-4 control-label no-padding-right" Text="Plate Use Type"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlPlateUse" runat="server" CssClass="form-control">
                                        <asp:ListItem>Used</asp:ListItem>
                                        <asp:ListItem>Unused</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtPlateRetQty" CssClass="col-xs-4 control-label no-padding-right" Text="Qty"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtPlateRetQty" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-8 col-xs-offset-4">
                                    <asp:Button ID="btnPlateRetAdd" Text="Add" CssClass="btn btn-primary btn-sm" runat="server" OnClick="btnPlateRetAdd_Click" />
                                </div>
                            </div>
                        </div>
                    </div><br/>
                    <div class="clearfix"></div>
                    <%--table grid view--%>
                    <div class="col-md-12 clearfix table-responsive">
                        <asp:GridView ID="gvwPlateRet" runat="server" CssClass="grid-view table" AutoGenerateColumns="false">
                             <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                            <Columns>
                                <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" DataField="Serial" />
                                <asp:BoundField DataField="BookName" HeaderText="Book Name" />
                                <asp:BoundField DataField="Class" HeaderText="Class" />
                                <asp:BoundField DataField="Type" HeaderText="Type" />
                                <asp:BoundField DataField="Edition" HeaderText="Edition" />
                                <asp:BoundField DataField="PlateFor" HeaderText="Plate For" />
                                <asp:BoundField DataField="PlateType" HeaderText="Plate Type" />
                                <asp:BoundField DataField="PlateSize" HeaderText="Plate Size" />
                                <asp:BoundField DataField="PlateUseType" HeaderText="Plate Use Type" />
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
                                <asp:Label runat="server" AssociatedControlID="txtTotalQty" CssClass="col-xs-4 control-label no-padding-right" Text="Total Qty"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtTotalQty" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtCauseOfDel" CssClass="col-xs-4 control-label no-padding-right" Text="Cause Of Delete"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtCauseOfDel" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-8 col-xs-offset-4">
                                    <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-primary" runat="server" OnClick="btnPrint_Click" />
                                    <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
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
            open_menu("Plate");
        });
    </script>
</asp:Content>
