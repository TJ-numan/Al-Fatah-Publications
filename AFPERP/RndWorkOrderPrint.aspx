<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="RndWorkOrderPrint.aspx.cs" Inherits="BLL.RndWorkOrderPrint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
      <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Work Order View
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-4 control-label no-padding-right" Text="From Date" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-mm-dd" runat="server" />
                                    <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                                </div>
                            </div>
                           <div class="form-group">
                                <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-4 control-label no-padding-right" Text="To Date" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-mm-dd" runat="server" />
                                    <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />
                                </div>
                           </div>
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
                                <asp:Label AssociatedControlID="ddlSection" ID="lblSection" CssClass="col-md-4 control-label no-padding-right" Text="Section" runat="server"></asp:Label>
                                <div class="col-md-4">  
                                   <asp:DropDownList CssClass="form-control" ID="ddlSection" runat="server" OnTextChanged="ddlSection_TextChanged" AutoPostBack="True">
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
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSRandD" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Reports","Work Orders");
        });
    </script>
</asp:Content>
