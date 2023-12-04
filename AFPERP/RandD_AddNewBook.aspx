<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="RandD_AddNewBook.aspx.cs" Inherits="BLL.RandD_AddNewBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-7">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Create New Book
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtBookCode" CssClass="col-md-4 control-label" Text="Book Code" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control" ID="txtBookCode" placeholder="Book Code" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtBookName" CssClass="col-md-4 control-label" Text="Book Name" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control" ID="txtBookName" placeholder="Book Name" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtBookNameBangla" CssClass="col-md-4 control-label bangla-font" Text="eB‡qi bvg" runat="server" Font-Names="SutonnyMJ"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control bangla-font" ID="txtBookNameBangla" placeholder="eB‡qi bvg" Font-Names="SutonnyMJ" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlBookType" CssClass="col-md-4 control-label" Text="Book Type" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlBookType" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlClass" CssClass="col-md-4 control-label" Text="Class" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlClass" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlGroup" CssClass="col-md-4 control-label" Text="Group" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlGroup" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlSession" CssClass="col-md-4 control-label" Text="Session" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlSession" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                           Select Related Section
                        </div>
                        <div class="panel-body" style="border: 1px solid #BDC3CA; padding-left:50px">
                            <div class="form-group">
                                <div class="checkbox">
                                    <asp:Label AssociatedControlID="chkQuran" runat="server" Text="Quran"></asp:Label>
                                    <asp:CheckBox ID="chkQuran" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="checkbox">
                                    <asp:Label AssociatedControlID="chkHadith" runat="server" Text="Hadith"></asp:Label>
                                    <asp:CheckBox ID="chkHadith" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="checkbox">
                                    <asp:Label AssociatedControlID="chkAlFikh" runat="server" Text="Al Fikh"></asp:Label>
                                    <asp:CheckBox ID="chkAlFikh" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="checkbox">
                                    <asp:Label AssociatedControlID="chkArabic" runat="server" Text="Arabic"></asp:Label>
                                    <asp:CheckBox ID="chkArabic" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="checkbox">
                                    <asp:Label AssociatedControlID="chkEnglish" runat="server" Text="English"></asp:Label>
                                    <asp:CheckBox ID="chkEnglish" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="checkbox">
                                    <asp:Label AssociatedControlID="chkGeneral" runat="server" Text="General"></asp:Label>
                                    <asp:CheckBox ID="chkGeneral" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="checkbox">
                                    <asp:Label AssociatedControlID="chkScienceMath" runat="server" Text="Science & Math"></asp:Label>
                                    <asp:CheckBox ID="chkScienceMath" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="checkbox">
                                    <asp:Label AssociatedControlID="chkBangla" runat="server" Text="Bangla"></asp:Label>
                                    <asp:CheckBox ID="chkBangla" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="checkbox">
                                    <asp:Label AssociatedControlID="chkQawmi" runat="server" Text="Qawmi"></asp:Label>
                                    <asp:CheckBox ID="chkQawmi" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-7">
                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" />
                            <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:ListBox ID="ListBox2" runat="server"></asp:ListBox>
                                </div>
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
            open_menu("Book Information");
        });
    </script>
</asp:Content>
