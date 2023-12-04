<%@ Page Title="" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_CoverReceive.aspx.cs" Inherits="BLL.Pro_CoverReceive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Cover Receive
                </div>


                <div class="panel-body">
                    <div class="col-md-12 no-padding clearfix">
                        <div class="col-md-6 clearfix">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtMemoNo" CssClass="col-md-4 control-label" Text="Ref No" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control" ID="txtMemoNo" placeholder="Ref No" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtReceivedID" CssClass="col-md-4 control-label" Text="Receive ID" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control" ID="txtReceivedID" placeholder="Receive ID" runat="server" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label AssociatedControlID="dtpReceiveDate" CssClass="col-md-4 control-label" Text="Receive Date" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control" ID="dtpReceiveDate" placeholder="yyyy-MM-dd" runat="server" />
                                    <ajaxToolkit:CalendarExtender TargetControlID="dtpReceiveDate" Format="yyyy-MM-dd" runat="server" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlCoverSource" CssClass="col-md-4 control-label" Text="Cover Source" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlCoverSource" runat="server" OnSelectedIndexChanged="ddlCoverSource_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="">--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">Press</asp:ListItem>
                                        <asp:ListItem Value="2">Lemination</asp:ListItem>
                                        <asp:ListItem Value="3">Plastic Cover</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlSourceName" CssClass="col-md-4 control-label" Text="Source Name" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlSourceName" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlCategory" CssClass="col-md-4 control-label no-padding-right" Text="Category"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlGroup" CssClass="col-md-4 control-label no-padding-right" Text="Group"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlClass" CssClass="col-md-4 control-label no-padding-right" Text="Class"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlType" CssClass="col-md-4 control-label no-padding-right" Text="Type"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlBookName" CssClass="col-md-4 control-label no-padding-right" Text="Book Name"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList ID="ddlBookName" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlBookName_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlEdition" CssClass="col-md-4 control-label no-padding-right" Text="Edition"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList ID="ddlEdition" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlLaminationSize" CssClass="col-md-4 control-label no-padding-right" Text="Lamination Size"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList ID="ddlLaminationSize" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtQuantity" CssClass="col-md-4 control-label" Text="Quantity" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control" ID="txtQuantity" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtRemark" CssClass="col-md-4 control-label" Text="Remark" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control" ID="txtRemark" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12 no-padding clearfix">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSPro" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Cover");
        });
    </script>
</asp:Content>
