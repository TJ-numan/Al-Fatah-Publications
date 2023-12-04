<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmAssetBrand.aspx.cs" Inherits="BLL.HrmAssetBrand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Asset Brand
                </div>
                  

                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>


                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtBrandName" runat="server" CssClass="control-label col-md-2 no-padding-right">Brand Name</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtBrandName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>


                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-2">
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                            <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnUpdate_Click" />
                        </div>
                    </div>


       
                        <div class="row">
                            <div class="table-responsive table-bordered clearfix " style="height: 150px; overflow: auto">
                                <asp:GridView ID="gvAssetBrand" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="gvAssetBrand_RowDataBound" OnSelectedIndexChanged="gvAssetBrand_SelectedIndexChanged">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns> 
                                          <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                HeaderStyle-CssClass="HiddenColumn" />
                                        <asp:BoundField DataField="BrandId" HeaderText="BrandId"></asp:BoundField>
                                        <asp:BoundField DataField="BrandName" HeaderText="BrandName"></asp:BoundField>
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
