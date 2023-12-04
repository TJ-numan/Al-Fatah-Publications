<%@ Page Title="" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_Rpt_GodownCoverReceivingMemo.aspx.cs" Inherits="BLL.Pro_Rpt_GodownCoverReceivingMemo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Print Cover Receiving Memo
                </div>
                <%-- <div id="frmPlateProcess" runat="server" class="form-horizontal clearfix">--%>
                <div class="panel-body">
                    <div class="col-md-12 no-padding clearfix">
                        <div class="col-md-6">

                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlCoverSource" CssClass="col-md-4 control-label" Text="Cover Source" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlCoverSource" runat="server"  >
                                        <asp:ListItem Value="">--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">Press</asp:ListItem>
                                        <asp:ListItem Value="2">Lemination</asp:ListItem>
                                        <asp:ListItem Value="3">Plastic Cover</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtReceiveId" CssClass="col-xs-4 control-label no-padding-right" Text="Receive ID"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtReceiveId" runat="server" CssClass="form-control" />
                                </div>
                            </div>


                            <div class="form-group">
                                <div class="col-xs-8 col-xs-offset-4">
                                    <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info" runat="server" OnClick="btnShow_Click" />
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
</asp:Content>
