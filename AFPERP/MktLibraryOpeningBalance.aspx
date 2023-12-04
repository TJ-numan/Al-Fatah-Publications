<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="MktLibraryOpeningBalance.aspx.cs" Inherits="BLL.MktLibraryOpeningBalance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Update Library Opening Balance
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddllIBraryID" CssClass="col-md-4 control-label" Text="Library ID" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddllIBraryID" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtOpeningBalance" CssClass="col-md-4 control-label" Text="Opening Balance" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtOpeningBalance" placeholder="0000" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-4">
                                    <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var anc = $('span:contains("Library Information"), ul.sub a[href="MktLibraryOpeningBalance"]').parent().addClass("active");
            anc.next("ul").css("display", "block");
        });
    </script>
</asp:Content>
