<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="RndScriptPlanning.aspx.cs" Inherits="BLL.RndScriptPlanning" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Script Planning
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlCategory" CssClass="col-md-4 control-label no-padding-right" Text="Category" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlCategory" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlGroup" CssClass="col-md-4 control-label no-padding-right" Text="Group" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlGroup" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlClass" CssClass="col-md-4 control-label no-padding-right" Text="Class" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlClass" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlType" CssClass="col-md-4 control-label no-padding-right" Text="Type" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlType" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlBookName" CssClass="col-md-4 control-label no-padding-right" Text="Book Name" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlBookName" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlEddition" CssClass="col-md-4 control-label no-padding-right" Text="Edition" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlEddition" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtFormaQty" CssClass="col-md-4 control-label no-padding-right" Text="Approximate Qty" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control" ID="txtFormaQty" placeholder="Quantity" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlBookSize" CssClass="col-md-4 control-label no-padding-right" Text="Book Size" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlBookSize" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="dtpFinalDatePositive" CssClass="col-md-4 control-label no-padding-right" Text="Final Date Of Positive " runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control date" ID="dtpFinalDatePositive" placeholder="yyyy/mm/dd" runat="server" />
                                    <ajaxToolkit:CalendarExtender TargetControlID="dtpFinalDatePositive" Format="yyyy/MM/dd" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="Panel panel-danger">
                        <div class="panel-heading">
                            Direction About Writing
                        </div>
                        <div class="panel-body" style="border: 1px solid #BDC3CA">
                            <asp:ListBox CssClass="form-control" ID="lbSelectSection" runat="server" Height="150px"></asp:ListBox>
                        </div>
                        <div class="panel-body" style="border: 1px solid #BDC3CA">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtChapterUnit" CssClass="col-lg-4 control-label no-padding-right" Text="Chapter/Unit No" runat="server"></asp:Label>
                                    <div class="col-lg-7">
                                        <asp:TextBox CssClass="form-control" ID="txtChapterUnit" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtHeading" CssClass="col-lg-4 control-label no-padding-right" Text="Heading" runat="server"></asp:Label>
                                    <div class="col-lg-7">
                                        <asp:TextBox CssClass="form-control" ID="txtHeading" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlAuthor" CssClass="col-lg-4 control-label no-padding-right" Text="Author/Editor" runat="server"></asp:Label>
                                    <div class="col-lg-7">
                                        <asp:DropDownList CssClass="form-control" ID="ddlAuthor" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlName" CssClass="col-lg-4 control-label no-padding-right" Text="Name" runat="server"></asp:Label>
                                    <div class="col-lg-7">
                                        <asp:DropDownList CssClass="form-control" ID="ddlName" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="dtpFinalDate" CssClass="col-lg-4 control-label no-padding-right" Text="Script Final Date" runat="server"></asp:Label>
                                    <div class="col-lg-7">
                                        <asp:TextBox CssClass="form-control date" ID="dtpFinalDate" placeholder="yyyy/mm/dd" runat="server" />
                                        <ajaxToolkit:CalendarExtender TargetControlID="dtpFinalDate" Format="yyyy/MM/dd" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <div class="col-md-12 col-md-offset-10">
                            <asp:Button ID="btnAdd" Text="Add" CssClass="btn btn-primary" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                        </div>
                        <div class="panel-body" style="border: 1px solid #BDC3CA">
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:ListBox CssClass="form-control" ID="ListBox1" runat="server" Height="150px"></asp:ListBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtTotalChapterUnit" CssClass="col-md-4 control-label no-padding-right" Text=" Total Chapter/Unit:" runat="server"></asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox CssClass="form-control" ID="txtTotalChapterUnit" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="form-group">
                            <div class="col-md-12 col-md-offset-10">
                                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-primary" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSRandD" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Planning");
        });
    </script>
</asp:Content>
