<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Rpt_TSOFinalSettlement.aspx.cs" Inherits="BLL.Mkt_Rpt_TSOFinalSettlement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
<div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    TSO Final Settlement Report
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlTSOName" runat="server" CssClass="col-md-4 control-label" Text="TSO Name" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlTSOName" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="input-group col-md-8 col-md-offset-4">
                            <asp:Button ID="btnLoad" Text="Print" CssClass="btn btn-info" runat="server"  OnClick="btnLoad_Click" />
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
              open_menu("Reports", "Specimen");
          });
    </script>
</asp:Content>
