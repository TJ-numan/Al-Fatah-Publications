<%@ Page Title="" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_LaminationSizeBasic.aspx.cs" Inherits="BLL.Pro_LaminationSizeBasic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Lamination Size
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtSizeId" CssClass="col-md-4 control-label" Text="ID" runat="server"></asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox CssClass="form-control" ID="txtSizeId" ReadOnly="true" placeholder="Size ID" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="" CssClass="col-md-4 control-label" Text="Lamination Size" runat="server"></asp:Label>
                        <div class="col-md-6">
                            <div class="col-md-2">
                                <asp:TextBox CssClass="form-control" ID="txtSizeLeft" runat="server" />
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="lblCross" Text="×" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox CssClass="form-control" ID="txtSizeRight" runat="server" />
                            </div>

                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-4">
                            <asp:Button ID="btnPaperSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnPaperSave_Click" />
                            <asp:Button ID="btnPaperUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnPaperUpdate_Click" />

                        </div>
                    </div>


                    <div class="table-responsive">
                        <asp:GridView ID="gvLaminationSize" CssClass="grid-view table" runat="server" Align="Center" AutoGenerateColumns="false">
                            <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                            <Columns>
                                <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                    HeaderStyle-CssClass="HiddenColumn" />
                                <asp:BoundField DataField="LemiSizeID" HeaderText="ID" />
                                <asp:BoundField DataField="LemiSize" HeaderText="Size" />

                            </Columns>
                            <SelectedRowStyle BackColor="#393737" Font-Bold="true" ForeColor="#F7F7F7" />
                            <FooterStyle BackColor="#F2DEDE" ForeColor="#2A3542"></FooterStyle>
                        </asp:GridView>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSPro" runat="server">
</asp:Content>
