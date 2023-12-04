<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmAssetCategory.aspx.cs" Inherits="BLL.AssetCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
     <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                  Asset Category
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>                          
                    
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtAssetCategory" runat="server" CssClass="control-label col-md-2 no-padding-right">Asset Type</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtAssetCategory" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>                       
                    
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtCategoryPrefix" runat="server" CssClass="control-label col-md-2 no-padding-right">Type Prefix</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtCategoryPrefix" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>


                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-2">
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick ="btnSave_Click" />
                            <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnUpdate_Click" />
                        </div>
                    </div>

                           
                        <div class="row">
                            <div class="table-responsive table-bordered clearfix " style="height: 150px; overflow: auto">
                                <asp:GridView ID="gvAssetCategory" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="gvAssetCategory_RowDataBound" OnSelectedIndexChanged="gvAssetCategory_SelectedIndexChanged">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns> 
                                          <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                HeaderStyle-CssClass="HiddenColumn" />
                                        <asp:BoundField DataField="AssetCatId" HeaderText="Id"></asp:BoundField>
                                        <asp:BoundField DataField="Category" HeaderText="AssetType"></asp:BoundField>
                                        <asp:BoundField DataField="CatePrefix" HeaderText="Prefix"></asp:BoundField>
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
