<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmEmployeeSkills.aspx.cs" Inherits="BLL.HrmEmployeeSkills" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Employee Skills
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
                        <asp:Label AssociatedControlID="txtSkillTitle" runat="server" CssClass="control-label col-md-2 no-padding-right">Skill Title</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtSkillTitle" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtSkillDescription" runat="server" CssClass="control-label col-md-2 no-padding-right">Skill Description</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtSkillDescription" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtExtrActivities" runat="server" CssClass="control-label col-md-2 no-padding-right">Extra Activities</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtExtrActivities" CssClass="form-control" runat="server"></asp:TextBox>
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
                                  <asp:GridView ID="gvEmpSkill" CssClass="table " runat="server" AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />


                                        <asp:BoundField DataField="SkilId" HeaderText="ID" />
                                        <asp:BoundField DataField="IDNo" HeaderText="Employee ID" />
                                        <asp:BoundField DataField="EmpName" HeaderText="Employee Name"/>
                                        <asp:BoundField DataField="NickName" HeaderText="NickName" />
                                        <asp:BoundField DataField="DepName" HeaderText="DepName" />
                                        <asp:BoundField DataField="DesName" HeaderText="DesName" />
                                        <asp:BoundField DataField="Skills" HeaderText="Skills" />
                                        <asp:BoundField DataField="SkilDes" HeaderText="SkilDes" />
                                        <asp:BoundField DataField="ExtraActivities" HeaderText="ExtraActivities" />
                                        
						 	 							

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
    	                $('[id*=gvEmpSkill]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
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
