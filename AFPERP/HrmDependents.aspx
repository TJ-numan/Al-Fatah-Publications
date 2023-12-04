<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmDependents.aspx.cs" Inherits="BLL.HrmDependents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Dependents
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group" style="display:none">
                        <asp:Label AssociatedControlID="txtDependentId" runat="server" CssClass="control-label col-md-2 no-padding-right">Dependent ID</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtDependentId" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtDependentName" runat="server" CssClass="control-label col-md-2 no-padding-right">Dependent Name</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtDependentName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlEmployee" runat="server" CssClass="control-label col-md-2 no-padding-right">Employee</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlEmployee" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtRelation" runat="server" CssClass="control-label col-md-2 no-padding-right">Relation</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtRelation" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="control-label col-md-2 no-padding-right">Date of Birth</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox CssClass="form-control" ID="txtDateOfBirth" placeholder="dd-MM-yyyy" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="txtDateOfBirth" Format="dd-MM-yyyy" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtCertificateNo" runat="server" CssClass="control-label col-md-2 no-padding-right">Certificate No</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtCertificateNo" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="File1" runat="server" CssClass="control-label col-md-2 no-padding-right">Certificate Upload</asp:Label>
                        <%--   <div class="col-md-4">
                            <asp:FileUpload ID="txtCertfUpload" CssClass="form-control" runat="server"></asp:FileUpload>
                        </div>--%>
                        <div class="col-md-4">

                            <input type="file" id="File1" name="File1" runat="server" accept=".pdf">
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-2">
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                            <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnUpdate_Click" />
                        </div>
                    </div>
                    <div class="row">
 
                        <div class="panel-body">
                            <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                                <asp:GridView ID="gvwDependents" CssClass="table " runat="server" AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" /> 

                                        <asp:BoundField DataField="DepenId" HeaderText="ID"   />
                                        <asp:BoundField DataField="DepenName" HeaderText="Dependent Name" />
                                        <asp:BoundField DataField="EmpName" HeaderText="Employee Name" />
                                        <asp:BoundField DataField="Relation" HeaderText="Relation" />
                                        <asp:BoundField DataField="DoB" HeaderText="Date of Birth" DataFormatString="{0:dd-MM-yyyy}"   /> 
                                        <asp:BoundField DataField="InfStatus" HeaderText="Info Status" />
                                        <asp:BoundField DataField="IDNo" HeaderText="Employee ID"  />
                                        <asp:BoundField DataField="EmpName" HeaderText="Employee Name" />
                                        <asp:BoundField DataField="NickName" HeaderText="Nick Name" />                             
                                        <asp:BoundField DataField="DepName" HeaderText="Department"   />
                                        <asp:BoundField DataField="DesName" HeaderText="Designation" /> 
                                        
                                          </Columns> 
                                </asp:GridView>
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
            $(function () {
                $('[id*=gvwDependents]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                    "responsive": true,
                    "sPaginationType": "full_numbers"
                });
            });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("PIMS");
        });
    </script>
</asp:Content>
