<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="RandD_AddNewAuthor.aspx.cs" Inherits="BLL.RandD_AddNewAuthor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Add New Author
                </div>
                <div class="panel-body">
                    <div class="col-md-7">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtAuthorID" CssClass="col-md-4 control-label" Text="Author ID" runat="server"></asp:Label>
                            <div class="col-md-7">
                                <asp:TextBox CssClass="form-control" ID="txtAuthorID" placeholder="Author ID" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtAuthorsName" CssClass="col-md-4 control-label" Text="Author's Name" runat="server"></asp:Label>
                            <div class="col-md-7">
                                <asp:TextBox CssClass="form-control" ID="txtAuthorsName" placeholder="Author's Name" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtResidenceAddress" CssClass="col-md-4 control-label" Text="Residence Address" runat="server"></asp:Label>
                            <div class="col-md-7">
                                <asp:TextBox CssClass="form-control" ID="txtResidenceAddress" placeholder="Residence Address" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlDistrict" CssClass="col-md-4 control-label" Text="District" runat="server"></asp:Label>
                            <div class="col-md-7">
                                <asp:DropDownList CssClass="form-control" ID="ddlDistrict" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlInstitutionName" CssClass="col-md-4 control-label" Text="Name of Institution" runat="server"></asp:Label>
                            <div class="col-md-7">
                                <asp:DropDownList CssClass="form-control" ID="ddlInstitutionName" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlDesignation" CssClass="col-md-4 control-label" Text="Designation" runat="server"></asp:Label>
                            <div class="col-md-7">
                                <asp:DropDownList CssClass="form-control" ID="ddlDesignation" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtMobile1" CssClass="col-md-4 control-label" Text="Mobile 1" runat="server"></asp:Label>
                            <div class="col-md-7">
                                <asp:TextBox CssClass="form-control" ID="txtMobile1" placeholder=" " runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtMobile2" CssClass="col-md-4 control-label" Text="Mobile 2" runat="server"></asp:Label>
                            <div class="col-md-7">
                                <asp:TextBox CssClass="form-control" ID="txtMobile2" placeholder=" " runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-5">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlClass" CssClass="col-md-4 control-label" Text="Select Class" runat="server"></asp:Label>
                            <div class="col-md-7">
                                <asp:DropDownList CssClass="form-control" ID="ddlClass" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="lbChooseSubject" CssClass="col-md-4 control-label" Text="Choose Subject" runat="server"></asp:Label>
                            <div class="col-md-7">
                                <asp:ListBox CssClass="form-control" ID="lbChooseSubject" runat="server"></asp:ListBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="lbClassSubjectList" CssClass="col-md-4 control-label" Text="Class & Subject List" runat="server"></asp:Label>
                            <div class="col-md-7">
                                <asp:ListBox CssClass="form-control" ID="lbClassSubjectList" runat="server"></asp:ListBox>
                            </div>
                        </div>
                    </div>
                  
                    <div class="col-md-7">
                        <div class="form-group">
                            <div class="col-md-8 col-md-offset-4">
                                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" />
                                <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" />
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
            open_menu("Author Information");
        });
    </script>
</asp:Content>
