<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="Rnd_Rpt_WriterList.aspx.cs" Inherits="BLL.Rnd_Rpt_WriterList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
     <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    View R&D Writer List
                </div>
                <div class="panel-body">             
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlCompanyType" runat="server" CssClass="col-md-4 control-label" Text="Company" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlCompanyType" runat="server" CssClass="form-control">
                                   <asp:ListItem Value="1">Alia</asp:ListItem>
                                   <asp:ListItem Value="2">Qawmi</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlWriterType" runat="server" CssClass="col-md-4 control-label" Text="Writer Type" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlWriterType" runat="server" CssClass="form-control">
                                   <asp:ListItem Value="1">InHouse</asp:ListItem>
                                   <asp:ListItem Value="2">OutSource</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlViewers" runat="server" CssClass="col-md-4 control-label" Text="View Option" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlViewers" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0"> Select any type</asp:ListItem>
                                <asp:ListItem Value="1"> View as Pdf File</asp:ListItem>
                                <asp:ListItem Value="2"> View as Excel File</asp:ListItem>
                                <asp:ListItem Value="3"> View as Word File</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="input-group col-md-8 col-md-offset-4">
                            <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info" runat="server" OnClick="btnShow_Click" />
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
                open_menu("Reports");
            });
    </script>
</asp:Content>
