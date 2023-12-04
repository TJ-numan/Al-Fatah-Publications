<%@ Page Title="" Language="C#" MasterPageFile="~/AccountingMaster.master" AutoEventWireup="true" CodeBehind="Acca_WritterwiseWorkOrderQawmi.aspx.cs" Inherits="BLL.Acca_WritterwiseWorkOrderQawmi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AccountingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Writer Wise Work Order
                        </div>
                        <div class="panel-body">                        
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlEmplyeeFor" CssClass="col-md-4 control-label no-padding-right" Text="Emplyee For" runat="server"></asp:Label>
                                <div class="col-md-4">   
                                    <asp:DropDownList CssClass="form-control" ID="ddlEmplyeeFor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEmployeeFor_SelectedIndexChanged">
                                          <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                          <asp:ListItem Value="1" Text="InHouse"></asp:ListItem>
                                          <asp:ListItem Value="2" Text="OutSource"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlEmpName" CssClass="col-md-4 control-label no-padding-right" Text="Name" runat="server"></asp:Label>
                                <div class="col-md-4">  
                                   <asp:DropDownList CssClass="form-control" ID="ddlEmpName" runat="server" AutoPostBack="True" OnTextChanged="ddlEmpName_OnTextChanged">
                                   </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="btnShow" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-success" runat="server" OnClick="btnShow_Click" />
                                </div>
                           </div>
                        </div>
                     </div>
                 </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSAcc" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Reports", "RnD Work");
        });
    </script>
</asp:Content>
