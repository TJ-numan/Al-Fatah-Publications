<%@ Page Title="" Language="C#" MasterPageFile="~/AccountingMaster.master" AutoEventWireup="true" CodeBehind="Acc_DatewiseReturn.aspx.cs" Inherits="BLL.Acc_DatewiseReturn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AccountingContent" runat="server">
     <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    View Datewise Return Memo 
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-4 control-label" Text="From" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-4 control-label" Text="To" runat="server"></asp:Label> 
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtMemoFrom" CssClass="col-md-4 control-label" Text="Memo From" runat="server"></asp:Label> 
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="txtMemoFrom" placeholder="Optional" runat="server" />                            
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtMemoTo" CssClass="col-md-4 control-label" Text="Memo To" runat="server"></asp:Label> 
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="txtMemoTo" placeholder="Optional" runat="server" />                            
                        </div>
                    </div>

                   <div class="form-group">
                        <div class="col-md-12 control-label ">
                            <asp:CheckBox ID="chkQawmi" Text="Qawmi Return" CssClass="btn btn-block" runat="server"  />
                        </div>
                    </div>

                   <div class="form-group">
                        <div class="input-group col-md-8 col-md-offset-4">
                            <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info" runat="server" OnClick="btnShow_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID ="btnConvertXML" Text ="Convert XML" CssClass ="btn btn-send" runat ="server" OnClick ="btnConvertXML_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID ="btnDownloadXML" Text="Download XML" CssClass ="btn btn-success " runat ="server" OnClick ="btnDownloadXML_Click" />
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
                open_menu("Reports", "Return");
            });
    </script>
</asp:Content>
