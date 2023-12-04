<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmEmpProfesionCertf.aspx.cs" Inherits="BLL.HrmEmpProfesionCertf" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
      <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Employee Professional Certificate
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
                        <asp:Label AssociatedControlID="txtCertification" runat="server" CssClass="control-label col-md-2 no-padding-right">Certification</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtCertification" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtInstituteName" runat="server" CssClass="control-label col-md-2 no-padding-right">Institute Name</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtInstituteName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtLocation" runat="server" CssClass="control-label col-md-2 no-padding-right">Location</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtLocation" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtCertificationPeriod" runat="server" CssClass="control-label col-md-2 no-padding-right">Certification Period</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtCertificationPeriod" CssClass="form-control" runat="server"></asp:TextBox>
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
                        <asp:Label AssociatedControlID="chkIsMembership" runat="server" CssClass="control-label col-md-2 no-padding-right">Is Membership</asp:Label>
                        <div class="col-md-4">
                            <asp:CheckBox ID="chkIsMembership" CssClass="form-control" runat="server"></asp:CheckBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-2">
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click"/>
                            <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" />
                        </div>
                    </div>
                    <div class="row">
 
                        <div class="panel-body">
                            <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                                <asp:GridView ID="gvProfessionalCertificates" CssClass="table " runat="server" AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>

                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />

                                        <asp:BoundField DataField="ProQuaId" HeaderText="ID" />
                                       
                                        <asp:BoundField DataField="IDNo" HeaderText="Employee ID"/>
                                        <asp:BoundField DataField="EmpName" HeaderText="EmpName" />
                                        <asp:BoundField DataField="DepName" HeaderText="DepName" />
                                        <asp:BoundField DataField="DesName" HeaderText="DesName" />
                                        <asp:BoundField DataField="Certification" HeaderText="Certification" />

                                        						 												
                                        <asp:BoundField DataField="InstituteName" HeaderText="InstituteName" />
                                        <asp:BoundField DataField="Location" HeaderText="Location"/>
                                        <asp:BoundField DataField="CertificationPeriod" HeaderText="CertificationPeriod" />
                                        <asp:BoundField DataField="CertifPath" HeaderText="CertifPath" />
                                        <asp:BoundField DataField="IsMembership" HeaderText="IsMembership" />
                                    


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
    	                $('[id*=gvProfessionalCertificates]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
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
