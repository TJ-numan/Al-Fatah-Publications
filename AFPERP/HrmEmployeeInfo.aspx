<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmEmployeeInfo.aspx.cs" Inherits="BLL.HrmEmployeeInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Employee Information
                </div>
                <div class="panel-body">

                    <div class="col-md-4">

                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-4 no-padding-right">Info Status</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList CssClass="form-control" ID="ddlInfoStatus" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddlInfoStatus" ErrorMessage="Please select Info Status!" InitialValue="0" ForeColor="Red" ID="RVforddlInfoStatus" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtEmpId" runat="server" CssClass="control-label col-md-4 no-padding-right">Employee ID</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtEmpId" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:RequiredFieldValidator ControlToValidate="txtEmpId" Display="Dynamic" ForeColor="Red" ErrorMessage="Please enter Employee Id!" runat="Server" ID="RVfortxtEmpId" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtProxomityNo" runat="server" CssClass="control-label col-md-4 no-padding-right">Proxomity No</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtProxomityNo" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:RequiredFieldValidator ControlToValidate="txtProxomityNo" Display="Dynamic" ForeColor="Red" ErrorMessage="Please enter Proxomity No!" runat="Server" ID="RVfortxtProxomityNo" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtEmpName" runat="server" CssClass="control-label col-md-4 no-padding-right">Employee Name</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtEmpName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtEmpName" ErrorMessage="Please enter employee name!" ForeColor="Red" ID="RVfortxtEmpName" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtEmpNameBn" runat="server" CssClass="control-label col-md-4 no-padding-right">Bangla Name</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtEmpNameBn" CssClass="form-control" runat="server" Font-Names="SutonnyMJ"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtEmpNameBn" ErrorMessage="Please enter employee name Bangla!" ForeColor="Red" ID="RVfortxtEmpNameBn" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtNickName" runat="server" CssClass="control-label col-md-4 no-padding-right">Nick Name</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtNickName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtNickName" ErrorMessage="Please enter Nick name!" ForeColor="Red" ID="RVfortxtNickName" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlDepartment" runat="server" CssClass="control-label col-md-4 no-padding-right">Department</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList CssClass="form-control" ID="ddlDepartment" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddlDepartment" ErrorMessage="Please select Department!" InitialValue="0" ForeColor="Red" ID="RVforDepartment" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlDesignation" runat="server" CssClass="control-label col-md-4 no-padding-right">Designation</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList runat="server" ID="ddlDesignation" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddlDesignation" ErrorMessage="Please select designation!" InitialValue="0" ForeColor="Red" ID="RVforDesignation" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlSection" runat="server" CssClass="control-label col-md-4 no-padding-right">Section</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList runat="server" ID="ddlSection" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddlSection" ErrorMessage="Please select Section!" InitialValue="0" ForeColor="Red" ID="RVforddlSection" />
                            </div>
                        </div>


                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlGender" runat="server" CssClass="control-label col-md-4 no-padding-right">Gender</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList CssClass="form-control" ID="ddlGender" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddlGender" ErrorMessage="Please select Gender!" InitialValue="0" ForeColor="Red" ID="RVforddlGender" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlBloodGroup" runat="server" CssClass="control-label col-md-4 no-padding-right">Blood Group</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList runat="server" ID="ddlBloodGroup" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddlBloodGroup" ErrorMessage="Please select Blood Group!" InitialValue="0" ForeColor="Red" ID="RVforddlBloodGroup" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlReligion" runat="server" CssClass="control-label col-md-4 no-padding-right">Religion</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList runat="server" ID="ddlReligion" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddlReligion" ErrorMessage="Please select Religion!" InitialValue="0" ForeColor="Red" ID="RVforddlReligion" />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlNationality" runat="server" CssClass="control-label col-md-4 no-padding-right">Nationality</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList runat="server" ID="ddlNationality" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddlNationality" ErrorMessage="Please select a Nationality!" InitialValue="0" ForeColor="Red" ID="RequiredFieldValidator1" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlJobCategory" runat="server" CssClass="control-label col-md-4 no-padding-right"> Job Category</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList runat="server" ID="ddlJobCategory" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddlJobCategory" ErrorMessage="Please select Job Category!" InitialValue="0" ForeColor="Red" ID="RVforddlEmploymentSt" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlJobTitle" runat="server" CssClass="control-label col-md-4 no-padding-right"> Job Title</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlJobTitle" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddlJobTitle" ErrorMessage="Please select a Job Title !" ForeColor="Red" ID="RVfortxtReportJobTitle" />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlReportTo" runat="server" CssClass="control-label col-md-4 no-padding-right"> Report To</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlReportTo" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddlReportTo" ErrorMessage="Please enter Report To !" ForeColor="Red" ID="RVfortxtReportTo" />
                            </div>
                        </div>


                        <div class="form-group">
                            <asp:Label runat="server" CssClass="control-label col-md-4 no-padding-right">Joining Date</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox CssClass="form-control" ID="txtJoiningDate" placeholder="yyyy-MM-dd" runat="server"  Text="1999-01-01"/>
                                <ajaxToolkit:CalendarExtender TargetControlID="txtJoiningDate" Format="yyyy-MM-dd" runat="server" />
                            </div>
                            <div class="col-md-6">
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtJoiningDate" ErrorMessage="Please enter Joining Date" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="control-label col-md-4 no-padding-right">Date of Birth</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox CssClass="form-control" ID="txtDateofBirth" placeholder="yyyy-MM-dd" runat="server" Text="1999-01-01"/>
                                <ajaxToolkit:CalendarExtender TargetControlID="txtDateofBirth" Format="yyyy-MM-dd" runat="server" />
                            </div>
                            <div class="col-md-6">
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtDateofBirth" ErrorMessage="Please enter Date of Birth" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtEmployeeAge" runat="server" CssClass="control-label col-md-4 no-padding-right">Employee Age</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtEmployeeAge" CssClass="form-control" runat="server" Text="30"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtPhoneNo" runat="server" CssClass="control-label col-md-4 no-padding-right">Phone No</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtPhoneNo" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label AssociatedControlID="EmpImg" runat="server" CssClass="control-label col-md-4 no-padding-right">Image Upload</asp:Label>
                            <div class="col-md-6">
                                <input type="file" id="EmpImg" name="EmpImg" runat="server" accept=".png">
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="imgDetail" runat="server" CssClass="control-label col-md-4 no-padding-right"></asp:Label>
                            <div class="col-md-6">
                                <asp:Image ID="imgDetail" Visible="true" runat="server" Width="100px" Height="100px" />
                            </div>
                        </div>


                        <div class="form-group">
                            <asp:Label AssociatedControlID="EmpSign" runat="server" CssClass="control-label col-md-4 no-padding-right">Signature</asp:Label>
                            <div class="col-md-6">
                                <input type="file" id="EmpSign" name="EmpSign" runat="server" accept=".png">
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="signDetail" runat="server" CssClass="control-label col-md-4 no-padding-right"></asp:Label>
                            <div class="col-md-6">
                                <asp:Image ID="signDetail" Visible="true" runat="server" Width="200px" Height="100px" />
                            </div>
                        </div>


                        <div class="form-group" style="display: none;">
                            <asp:Label AssociatedControlID="txtFatherName" runat="server" CssClass="control-label col-md-4 no-padding-right">Father Name</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtFatherName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6" style="display: none;">
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtFatherName" ErrorMessage="Please enter Father Name!" ForeColor="Red" ID="RVfortxtFatherName" />
                            </div>
                        </div>
                        <div class="form-group" style="display: none;">
                            <asp:Label AssociatedControlID="txtMotherName" runat="server" CssClass="control-label col-md-4 no-padding-right">Mother Name</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtMotherName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6" style="display: none;">
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtMotherName" ErrorMessage="Please enter Mother Name!" ForeColor="Red" ID="RVforMotherName" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlMaritalSt" runat="server" CssClass="control-label col-md-4 no-padding-right">Marital Status</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList runat="server" ID="ddlMaritalSt" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group" style="display: none;">
                            <asp:Label AssociatedControlID="txtSpouseName" runat="server" CssClass="control-label col-md-4 no-padding-right">Spouse Name</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtSpouseName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">

                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtPresentAddress" runat="server" CssClass="control-label col-md-4 no-padding-right">Present Address</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtPresentAddress" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtPresentAddress" ErrorMessage="Please enter Present Address!" ForeColor="Red" ID="RVforPresentAddress" />
                            </div>
                        </div>
                        <asp:UpdatePanel runat="server" ID="presDistrict">
                            <ContentTemplate>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlPresDistrict" runat="server" CssClass="control-label col-md-4 no-padding-right"> District</asp:Label>
                                    <div class="col-md-6">
                                        <asp:DropDownList runat="server" ID="ddlPresDistrict" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPresDistrict_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlPresThana" runat="server" CssClass="control-label col-md-4 no-padding-right"> Thana</asp:Label>
                                    <div class="col-md-6">
                                        <asp:DropDownList runat="server" ID="ddlPresThana" CssClass="form-control">
                                            <asp:ListItem Value="0" Text="N/A"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtPermanentAddress" runat="server" CssClass="control-label col-md-4 no-padding-right">Permanent Address</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtPermanentAddress" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtPresentAddress" ErrorMessage="Please enter Permanent Address!" ForeColor="Red" ID="RVforPermanentAdd" />
                            </div>
                        </div>
                        <asp:UpdatePanel runat="server" ID="perDistrict">
                            <ContentTemplate>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlPermDistrict" runat="server" CssClass="control-label col-md-4 no-padding-right">District</asp:Label>
                                    <div class="col-md-6">
                                        <asp:DropDownList runat="server" ID="ddlPermDistrict" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPermDistrict_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlPermThana" runat="server" CssClass="control-label col-md-4 no-padding-right">Thana</asp:Label>
                                    <div class="col-md-6">
                                        <asp:DropDownList runat="server" ID="ddlPermThana" CssClass="form-control">
                                            <asp:ListItem Value="0" Text="N/A"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtNID" runat="server" CssClass="control-label col-md-4 no-padding-right">National ID</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtNID" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtEmailAdd" runat="server" CssClass="control-label col-md-4 no-padding-right">Email Address</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtEmailAdd" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label AssociatedControlID="EmpCv" runat="server" CssClass="control-label col-md-4 no-padding-right">CV Path</asp:Label>
                            <div class="col-md-6">
                                <input type="file" id="EmpCv" name="EmpCv" runat="server" accept=".pdf">
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-8 col-md-offset-4">
                                <asp:Button runat="server" Text="Save" CssClass="btn btn-success pull-left" ID="btnSave" OnClick="btnSave_Click" />
                                <asp:Button runat="server" Text="Update" CssClass="btn btn-primary pull-right" ID="btnUpdate" OnClick="btnUpdate_Click" />
                            </div>
                        </div>
                    </div>

                </div>
                <div class="row">

                    <div class="panel-body">
                        <div class="table table-responsive table-bordered clearfix " style="height: 600px; overflow: auto">
                            <asp:GridView ID="gvEmployeeInfo" CssClass="table grid-view" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvEmployeeInfo_RowDataBound" OnSelectedIndexChanged="gvEmployeeInfo_SelectedIndexChanged">
                                <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                <Columns>

                                    <asp:CommandField SelectText="Edit" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                        HeaderStyle-CssClass="HiddenColumn" />
                                    <asp:BoundField DataField="EmpSl" HeaderText="ID" Visible="true" />
                                    <asp:BoundField DataField="IDNo" HeaderText="IDNo" />
                                    <asp:BoundField DataField="EmpName" HeaderText="Name" />

                                   <asp:TemplateField HeaderText="Photo" HeaderStyle-Width="60px">
                                    <ItemTemplate> 
                                         <asp:Image ImageUrl='<%# "data:image/png;base64," + Convert.ToBase64String((byte[])Eval("ImgPath")) %>' runat="server" Height ="60" Width ="50"/> 
                                      </ItemTemplate>
                                    </asp:TemplateField> 
                                    
                                    <asp:BoundField DataField="JobTiName" HeaderText="Designation" />
                                    <asp:BoundField DataField="DepName" HeaderText="Department" />
                                    <asp:BoundField DataField="JoiningDate" HeaderText="Joining Date" DataFormatString="{0:dd-MM-yyyy}" />
                                    <asp:BoundField DataField="JobCatName" HeaderText="Job Status" />
                                    <asp:BoundField DataField="PhoneNo" HeaderText="PhoneNo" />
                                    <asp:BoundField DataField="DateOfBirth" HeaderText="Date Of Birth" DataFormatString="{0:dd-MM-yyyy}" />
                                    <asp:BoundField DataField="PresAdd" HeaderText="Present Address" />
                                    <asp:BoundField DataField="PerAdd" HeaderText="Permanent Address" />
                                    <asp:BoundField DataField="NID" HeaderText="NID" />
 
                                     <asp:TemplateField HeaderText="Signature" HeaderStyle-Width="60px">
                                        <ItemTemplate> 
                                           <asp:Image ImageUrl='<%# "data:image/png;base64," + Convert.ToBase64String((byte[])Eval("SignPath")) %>' runat="server"  Height ="60" Width ="50"/> 
                                        </ItemTemplate>
                                     </asp:TemplateField> 

                                    <asp:TemplateField HeaderText="CV" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lblCv" runat="server"  >
                                                 Download
                                            </asp:LinkButton>
                                              <asp:Image   ID ="Image3" runat="server" Visible="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

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
            open_menu("PIMS", "Employee Information");
        });
    </script>
</asp:Content>
