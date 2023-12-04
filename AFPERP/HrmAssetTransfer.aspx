<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmAssetTransfer.aspx.cs" Inherits="BLL.HrmAssetTransfer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <div id="frmAssetTransfer" runat="server" class="form-horizontal clearfix">
        <div class="panel-body " style="border: 1px solid #BDC3CA">
            <div class="col-md-12 clearfix no-padding">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Asset Transfer
                    </div>
                    <div class="panel-body">

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtAssetCode" CssClass="col-md-4 control-label no-padding-right" Text="Asset Code"></asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtAssetCode" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtAssetCode_TextChanged">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtAssetName" CssClass="col-md-4 control-label no-padding-right" Text="Asset Name"></asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtAssetName" CssClass="form-control" ReadOnly="true">
                                </asp:TextBox>
                            </div>
                        </div>
                        
                    
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpPurchaseDate" CssClass="col-md-4 control-label no-padding-right" Text="Purchase Date" runat="server"></asp:Label> 
                        <div class="col-md-4">
                            <asp:TextBox CssClass="form-control date" ID="dtpPurchaseDate" placeholder="yyyy-MM-dd" runat="server" ReadOnly="true"/>
                            <%--<ajaxToolkit:CalendarExtender TargetControlID="dtpPurchaseDate" Format="yyyy-MM-dd" runat="server" />--%>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpWarrantyDate" CssClass="col-md-4 control-label no-padding-right" Text="Warranty Date" runat="server"></asp:Label> 
                        <div class="col-md-4">
                            <asp:TextBox CssClass="form-control date" ID="dtpWarrantyDate" placeholder="yyyy-MM-dd" runat="server" ReadOnly="true" />
                            <%--<ajaxToolkit:CalendarExtender TargetControlID="dtpWarrantyDate" Format="yyyy-MM-dd" runat="server" />--%>
                        </div>
                    </div>
                    
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpLifeTimeDate" CssClass="col-md-4 control-label no-padding-right" Text="Life Time" runat="server"></asp:Label> 
                        <div class="col-md-4">
                            <asp:TextBox CssClass="form-control date" ID="dtpLifeTimeDate" placeholder="yyyy-MM-dd" runat="server" ReadOnly="true" />
                            <%--<ajaxToolkit:CalendarExtender TargetControlID="dtpLifeTimeDate" Format="yyyy-MM-dd" runat="server" />--%>
                        </div>
                    </div>
                        

                        <div class="row col-md-12">
                            <div class="col-md-6 clearfix">
                                <div class="panel-heading">
                                    From
                                </div>
                                <div class="panel-body " style="border: 1px solid #BDC3CA">
                                    <asp:UpdatePanel runat="server" ID="UpdateArea1">
                                        <ContentTemplate>
                                            <div class="form-group">
                                                <asp:Label runat="server" AssociatedControlID="ddlDepartmentFrom" CssClass="col-md-4 control-label no-padding-right" Text="Department From"></asp:Label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList runat="server" ID="ddlDepartmentFrom" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartmentFrom_SelectedIndexChanged" Enabled="false">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label runat="server" AssociatedControlID="ddlEmployeeFrom" CssClass="col-md-4 control-label no-padding-right" Text="Employee From"></asp:Label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList runat="server" ID="ddlEmployeeFrom" CssClass="form-control" Enabled="false">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                           
                                            
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <br />
                                <%--                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtDate" CssClass="col-xs-4 control-label no-padding-right" Text="Order Date"></asp:Label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                        <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate" />
                                    </div>
                                </div>--%>
                            </div>
                            <div class="col-md-6">
                                <div class="panel-heading">
                                    To
                                </div>
                                <div class="panel-body " style="border: 1px solid #BDC3CA">
                                    <asp:UpdatePanel runat="server" ID="UpdateArea2">
                                        <ContentTemplate>
                                           
                                            <div class="form-group">
                                                <asp:Label runat="server" AssociatedControlID="ddlDepartmentTo" CssClass="col-md-4 control-label no-padding-right" Text="Department To"></asp:Label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList runat="server" ID="ddlDepartmentTo" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartmentTo_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label runat="server" AssociatedControlID="ddlEmployeeTo" CssClass="col-md-4 control-label no-padding-right" Text="Employee To"></asp:Label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList runat="server" ID="ddlEmployeeTo" CssClass="form-control" >
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <br />

                            </div>
                        </div>
                        <div class="form-group">
<%--                            <asp:Label runat="server" AssociatedControlID="txtTransferAmount" CssClass="col-md-4 control-label no-padding-right" Text="Transfer Amount"></asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtTransferAmount" runat="server" CssClass="form-control calc" />
                            </div>--%>
                        </div>
                        </br></br>
                            <div class="form-group">
                                <div class="input-group col-md-8 col-md-offset-4">
                                    <asp:Button ID="btnSave" Text="Transfer" CssClass="btn btn-info"  OnClientClick="if (!confirm('Are you sure to Transfer?')) return false;" runat="server" OnClick="btnSave_Click"/>
                                </div>
                            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSHR" runat="server">
        <script type="text/javascript">
            $(document).ready(function () {
                open_menu("HR Administration");
            });
    </script>
</asp:Content>
