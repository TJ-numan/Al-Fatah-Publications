<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="RndWritingEditingInfo.aspx.cs" Inherits="BLL.RndWritingEditingInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-7">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Writing and Editing Information
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
                                <asp:Label AssociatedControlID="dtpWorkDate" CssClass="col-md-4 control-label no-padding-right" Text="Working Date" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control date" ID="dtpWorkDate" placeholder="yyyy/mm/dd" runat="server" />
                                    <ajaxToolkit:CalendarExtender TargetControlID="dtpWorkDate" Format="yyyy/MM/dd" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            Pages Information
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtInner" CssClass="col-md-6 control-label no-padding-right" Text="Inner" runat="server"></asp:Label>
                                <div class="col-md-5">
                                    <asp:TextBox CssClass="form-control" ID="txtInner" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtSuggestion" CssClass="col-md-6 control-label no-padding-right" Text="Suggestion" runat="server"></asp:Label>
                                <div class="col-md-5">
                                    <asp:TextBox CssClass="form-control" ID="txtSuggestion" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtIndex" CssClass="col-md-6 control-label no-padding-right" Text="Index" runat="server"></asp:Label>
                                <div class="col-md-5">
                                    <asp:TextBox CssClass="form-control" ID="txtIndex" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtMainPart" CssClass="col-md-6 control-label no-padding-right" Text="Main Part" runat="server"></asp:Label>
                                <div class="col-md-5">
                                    <asp:TextBox CssClass="form-control" ID="txtMainPart" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtLastPart" CssClass="col-md-6 control-label no-padding-right" Text="Last Part" runat="server"></asp:Label>
                                <div class="col-md-5">
                                    <asp:TextBox CssClass="form-control" ID="txtLastPart" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtTotalPages" CssClass="col-md-6 control-label no-padding-right" Text="Total Page" runat="server"></asp:Label>
                                <div class="col-md-5">
                                    <asp:TextBox CssClass="form-control" ID="txtTotalPages" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h6>Next>></h6>
                        </div>
                        <div class="panel-body" style="border: 1px solid #BDC3CA">
                            <div class="form-group">
                                <div class="col-md-1">
                                    <div class="help">From Pge</div>
                                    <asp:TextBox CssClass="form-control" ID="txtFromPage" placeholder="000" runat="server" />
                                </div>
                                <div class="col-md-1">
                                    <div class="help">To Page</div>
                                    <asp:TextBox CssClass="form-control" ID="txtToPage" placeholder="000" runat="server" />
                                </div>
                                <div class="col-md-2">
                                    <div class="help">Work At:</div>
                                    <asp:DropDownList CssClass="form-control" ID="ddlWorkAt" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <div class="help">Name:</div>
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-md-3">
                                    <div class="help">Task:</div>
                                    <asp:DropDownList CssClass="form-control" ID="ddlTask" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-md-3">
                                    <div class="help">Comments:</div>
                                    <asp:TextBox CssClass="form-control" ID="txtComments" placeholder="Comments Here" TextMode="MultiLine" runat="server" />
                                </div>
                            </div>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSRandD" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Writting and Edition");
        });
    </script>
</asp:Content>
