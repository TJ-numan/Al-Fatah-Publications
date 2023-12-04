<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmEmpTraining.aspx.cs" Inherits="BLL.HrmEmpTraining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Employee Training
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
                        <asp:Label AssociatedControlID="txtTrainTitle" runat="server" CssClass="control-label col-md-2 no-padding-right">Training Title</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtTrainTitle" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtTopicsCover" runat="server" CssClass="control-label col-md-2 no-padding-right">Topics Cover</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtTopicsCover" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtInstituteName" runat="server" CssClass="control-label col-md-2 no-padding-right">Institute Name</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtInstituteName" CssClass="form-control" runat="server"></asp:TextBox>
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
                        <asp:Label AssociatedControlID="txtLocation" runat="server" CssClass="control-label col-md-2 no-padding-right">Location</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtLocation" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtCountry" runat="server" CssClass="control-label col-md-2 no-padding-right">Country</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtCountry" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtTrainingYear" runat="server" CssClass="control-label col-md-2 no-padding-right">Training Year</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtTrainingYear" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtDuration" runat="server" CssClass="control-label col-md-2 no-padding-right">Duration</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtDuration" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-2">
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                            <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" />
                        </div>
                    </div>
                    <div class="row">
 
                        <div class="panel-body">
                            <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                                <asp:GridView ID="gvEmpTraning" CssClass="table " runat="server" AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />

                                        <asp:BoundField DataField="EmpSl" HeaderText="EmpSl" />
                                        <asp:BoundField DataField="IDNo" HeaderText="ID No" />
                                        <asp:BoundField DataField="EmpName" HeaderText="Employee Name" />
                                        <asp:BoundField DataField="NickName" HeaderText="NickName" />
                                        <asp:BoundField DataField="DepName" HeaderText="DepName" />
                                        <asp:BoundField DataField="DesName" HeaderText="DesName" />
                                        <asp:BoundField DataField="TranTitle" HeaderText="TranTitle" />

                                        <asp:BoundField DataField="TopicsCov" HeaderText="Covered Topic" />
                                        <asp:BoundField DataField="InstituteName" HeaderText="Institute" />

                                       
                                        <asp:BoundField DataField="Location" HeaderText="Location" />

                                        <asp:BoundField DataField="Country" HeaderText="Country" />
                                        <asp:BoundField DataField="TranYr" HeaderText="Training Year" />
                                        <asp:BoundField DataField="Duration" HeaderText="Duration" />  
                                        <asp:BoundField DataField="CertifPath" HeaderText="Certificate" />
                                               
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
     	                $('[id*=gvEmpTraning]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
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
