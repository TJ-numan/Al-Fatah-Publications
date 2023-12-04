<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmEmpEducation.aspx.cs" Inherits="BLL.HrmEmpEducation" %>
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
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlEmployee" runat="server" CssClass="control-label col-md-2 no-padding-right">Employee</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlEmployee" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlEducationLevel" runat="server" CssClass="control-label col-md-2 no-padding-right">Education Level</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlEducationLevel" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlExamination" runat="server" CssClass="control-label col-md-2 no-padding-right">Examination</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlExamination" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlEduResult" runat="server" CssClass="control-label col-md-2 no-padding-right">Result</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlEduResult" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtMajorOrGroup" runat="server" CssClass="control-label col-md-2 no-padding-right">Major Or Group</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtMajorOrGroup" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPassingYear" runat="server" CssClass="control-label col-md-2 no-padding-right">Passing Year</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtPassingYear" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtCertfUpload" runat="server" CssClass="control-label col-md-2 no-padding-right">Certificate Upload</asp:Label>
                        <div class="col-md-4">
                            <asp:FileUpload ID="txtCertfUpload" CssClass="form-control" runat="server"></asp:FileUpload>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtInstituteName" runat="server" CssClass="control-label col-md-2 no-padding-right">Institute Name</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtInstituteName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="chkIsForeign" runat="server" CssClass="control-label col-md-2 no-padding-right">Is Foreign</asp:Label>
                        <div class="col-md-4">
                            <asp:CheckBox ID="chkIsForeign" CssClass="form-control" runat="server"></asp:CheckBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtAchievement" runat="server" CssClass="control-label col-md-2 no-padding-right">Achievement</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtAchievement" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-2">
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click"/>
                            <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick  ="btnUpdate_Click" />
                        </div>
                    </div>
                    <div class="row">
 
                        <div class="panel-body">
                            <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                                <asp:GridView ID="gvEmpEducation" CssClass="table " runat="server" AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />
                                        <asp:BoundField DataField="EmpSl" HeaderText="ID" />
                                        <asp:BoundField DataField="IDNo" HeaderText="IDNo" />
                                        <asp:BoundField DataField="EmpName" HeaderText="Employee Name"/>
                                        <asp:BoundField DataField="NickName" HeaderText="NickName" />
                                        <asp:BoundField DataField="DepName" HeaderText="DepName" />
                                        <asp:BoundField DataField="DesName" HeaderText="DesName" />
                                        <asp:BoundField DataField="EduLevelName" HeaderText="EduLevelName" />

                                        <asp:BoundField DataField="ExamName" HeaderText="ExamName" />
                                        <asp:BoundField DataField="EduReName" HeaderText="EduReName" />
                                        <asp:BoundField DataField="MajorOrGroup" HeaderText="MajorOrGroup" />                                        						 		 			

                                        <asp:BoundField DataField="ExamName" HeaderText="ExamName" />
                                        <asp:BoundField DataField="EduReName" HeaderText="EduReName" />
                                        <asp:BoundField DataField="PassYr" HeaderText="PassYr" />   						 			

                                        <asp:BoundField DataField="InstituteName" HeaderText="InstituteName" />
                                        <asp:BoundField DataField="CertifPath" HeaderText="CertifPath" />
                                        <asp:BoundField DataField="IsForeign" HeaderText="Foreign" />   						 		
                                        <asp:BoundField DataField="Achievement" HeaderText="Achievement" />   
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
    	                $('[id*=gvEmpEducation]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
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
