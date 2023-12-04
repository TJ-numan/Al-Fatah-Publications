<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmFinalSettlement.aspx.cs" Inherits="BLL.HrmFinalSettlement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
          <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Final Settlement
                </div>
                <div class="panel-body">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlEmployee" runat="server" CssClass="control-label col-md-2 no-padding-right">Employee</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlEmployee" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlEmploymentSt" runat="server" CssClass="control-label col-md-2 no-padding-right">Employment Status</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList runat="server" ID="ddlEmploymentSt" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                                        
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtJoiningDate" CssClass="control-label col-md-2 no-padding-right">Joining Date</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox CssClass="form-control" ID="txtJoiningDate" placeholder="dd-MM-yyyy" runat="server" />
                                <ajaxToolkit:CalendarExtender TargetControlID="txtJoiningDate" Format="dd-MM-yyyy" runat="server" />
                            </div>
                        </div>                    
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtEndOfService" CssClass="control-label col-md-2 no-padding-right">End of Service</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox CssClass="form-control" ID="txtEndOfService" placeholder="dd-MM-yyyy" runat="server" />
                                <ajaxToolkit:CalendarExtender TargetControlID="txtEndOfService" Format="dd-MM-yyyy" runat="server" />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtComments" runat="server" CssClass="control-label col-md-2 no-padding-right">Comments</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtComments" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtNOC_Upload" runat="server" CssClass="control-label col-md-2 no-padding-right">NOC</asp:Label>
                            <div class="col-md-4">
                                <asp:FileUpload ID="txtNOC_Upload" CssClass="form-control" runat="server"></asp:FileUpload>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtResign_Upload" runat="server" CssClass="control-label col-md-2 no-padding-right">Resign Letter</asp:Label>
                            <div class="col-md-4">
                                <asp:FileUpload ID="txtResign_Upload" CssClass="form-control" runat="server"></asp:FileUpload>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtEndPOF" runat="server" CssClass="control-label col-md-2 no-padding-right">PF Amt.</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtEndPOF" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtGratuity" runat="server" CssClass="control-label col-md-2 no-padding-right">Gratuity</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtGratuity" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="chkIsAssetClear" runat="server" CssClass="control-label col-md-2 no-padding-right">Is Asset Clear</asp:Label>
                            <div class="col-md-4">
                                <asp:CheckBox ID="chkIsAssetClear" CssClass="form-control" runat="server"></asp:CheckBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="chkIsDeptClear" runat="server" CssClass="control-label col-md-2 no-padding-right">Is Dept. Clear</asp:Label>
                            <div class="col-md-4">
                                <asp:CheckBox ID="chkIsDeptClear" CssClass="form-control" runat="server"></asp:CheckBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtLoan" runat="server" CssClass="control-label col-md-2 no-padding-right">Loan</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtLoan" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtOtherAmt" runat="server" CssClass="control-label col-md-2 no-padding-right">Other Amount</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtOtherAmt" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>


                        <div class="form-group">
                            <div class="col-md-4 col-md-offset-2">
                                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick ="btnSave_Click" />
                                <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick ="btnUpdate_Click" />
                            </div>
                        </div>
                    
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-10 col-md-offset-1">
                                <div class="search-input">
                                    <i class="icon-search"></i>
                                    <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" Placeholder="Search" />
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                                <%--                                <asp:GridView ID="gvwDependents" CssClass="table " runat="server" AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />
                                        <asp:BoundField DataField="DepenId" HeaderText="ID" />
                                        <asp:BoundField DataField="DepenName" HeaderText="Dependent Name" />
                                        <asp:BoundField DataField="EmpName" HeaderText="Employee Name"/>
                                        <asp:BoundField DataField="Relation" HeaderText="Relation" />
                                        <asp:BoundField DataField="DoB" HeaderText="Date of Birth" />
                                        <asp:BoundField DataField="CertificateNo" HeaderText="Certificate No" />
                                        <asp:BoundField DataField="InfStatus" HeaderText="Info Status" />
                                    </Columns>
                                </asp:GridView>--%>
                            </div>
                            <br />
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
                open_menu("PIMS");
            });
    </script>
</asp:Content>
