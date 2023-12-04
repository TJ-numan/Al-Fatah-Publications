<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmAssetList.aspx.cs" Inherits="BLL.HrmAssetList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Asset List
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtAssetCode" runat="server" CssClass="control-label col-md-2 no-padding-right">Asset Code</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtAssetCode" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlAssetCategory" runat="server" CssClass="control-label col-md-2 no-padding-right">Asset Type</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlAssetCategory" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlAssetBrand" runat="server" CssClass="control-label col-md-2 no-padding-right">Asset Brand</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlAssetBrand" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtModelNo" runat="server" CssClass="control-label col-md-2 no-padding-right">Model No</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtModelNo" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtAssetName" runat="server" CssClass="control-label col-md-2 no-padding-right">Asset Specification</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtAssetName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPurchaseAmt" runat="server" CssClass="control-label col-md-2 no-padding-right">Purchase Amount</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtPurchaseAmt" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>




                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlAssetVendor" runat="server" CssClass="control-label col-md-2 no-padding-right">Asset Vendor</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlAssetVendor" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>

                    
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpPurchaseDate" CssClass="control-label col-md-2 no-padding-right" Text="Purchase Date" runat="server"></asp:Label> 
                        <div class="col-md-4">
                            <asp:TextBox CssClass="form-control date" ID="dtpPurchaseDate" placeholder="yyyy-MM-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpPurchaseDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpWarrantyDate" CssClass="control-label col-md-2 no-padding-right" Text="Warranty Date" runat="server"></asp:Label> 
                        <div class="col-md-4">
                            <asp:TextBox CssClass="form-control date" ID="dtpWarrantyDate" placeholder="yyyy-MM-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpWarrantyDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpLifeTimeDate" CssClass="control-label col-md-2 no-padding-right" Text="Life Time" runat="server"></asp:Label> 
                        <div class="col-md-4">
                            <asp:TextBox CssClass="form-control date" ID="dtpLifeTimeDate" placeholder="yyyy-MM-dd" runat="server"/>
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpLifeTimeDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>



                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlDepartment" runat="server" CssClass="control-label col-md-2 no-padding-right">Department</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlDepartment" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlEmployee" runat="server" CssClass="control-label col-md-2 no-padding-right">Employeel</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlEmployee" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
<%--                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtwarrTime" runat="server" CssClass="control-label col-md-2 no-padding-right">Warr. Time</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtwarrTime"  runat="server" TextMode="Number"></asp:TextBox>
                            <asp:DropDownList ID="ddlYMD"  runat="server">
                                <asp:ListItem Text="Year" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Month" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Day" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>--%>

                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-2">
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                            <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnUpdate_Click" />
                            <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-info" runat="server" OnClick="btnPrint_Click"/>
                        </div>
                    </div>
                                       <div class="row">
                            <div class="table-responsive table-bordered clearfix " style="height: 400px; overflow: auto">
                                <asp:GridView ID="gvAssetList" runat="server" AutoGenerateColumns="False" Width="100%"  OnRowDataBound="gvAssetList_RowDataBound" OnSelectedIndexChanged="gvAssetList_SelectedIndexChanged">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns> 
                                          <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                HeaderStyle-CssClass="HiddenColumn" />
                                        <asp:BoundField DataField="AssetId" HeaderText="Id"></asp:BoundField>
                                        <asp:BoundField DataField="AssetCode" HeaderText="Asset Code"></asp:BoundField>
                                        <asp:BoundField DataField="Category" HeaderText="AssetType"></asp:BoundField>
                                        <asp:BoundField DataField="AssetName" HeaderText="Asset Configuration"></asp:BoundField>
                                        <asp:BoundField DataField="ModelNo" HeaderText="ModelNo"></asp:BoundField>
                                        <asp:BoundField DataField="BrandName" HeaderText="Brand"></asp:BoundField>
                                        <asp:BoundField DataField="VendorName" HeaderText="Vendor"></asp:BoundField>

                                        <asp:BoundField DataField="PurchaseAmt" HeaderText="Purchase Amount"></asp:BoundField>
                                        <asp:BoundField DataField="PurchaseDate" HeaderText="Purchase Date" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
                                        <asp:BoundField DataField="WarrantyPeriod" HeaderText="Warranty Date" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
                                        <asp:BoundField DataField="Life_Time" HeaderText="Life_Time Date" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>

                                        <asp:BoundField DataField="DepName" HeaderText="Department"></asp:BoundField>
                                        <asp:BoundField DataField="EmpName" HeaderText="Employee"></asp:BoundField>
                                        <asp:BoundField DataField="InfStId" HeaderText="InfStId"></asp:BoundField>  
                                    </Columns>
                                </asp:GridView>
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
