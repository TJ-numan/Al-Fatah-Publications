<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HRM_rptEmployeeInfo.aspx.cs" Inherits="BLL.HRM_rptEmployeeInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Employee Information Report
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlDepartment" runat="server" CssClass="col-md-4 control-label" Text="Department" />
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlSection" runat="server" CssClass="col-md-4 control-label" Text="Section" />
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlSection" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSection_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-4 control-label" Text="Designation" />
                        <div class="col-md-4">
                            <div class="row">

                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control" AutoPostBack="false"></asp:DropDownList>
                                </div>

                                <div class="col-md-2">Functional Designation</div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlFuncDesignation" runat="server" CssClass="form-control" AutoPostBack="false"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlEmploymentStatus" runat="server" CssClass="col-md-4 control-label" Text="Employment Status" />
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlEmploymentStatus" runat="server" CssClass="form-control" AutoPostBack="false">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblServiceAge" runat="server" CssClass="col-md-4 control-label" Text="Service Age" />
                        <div class="col-md-8">
                            <div class="row">
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtServAgeFrom" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                </div>

                                <div class="col-md-7">
                                    <div class="col-md-1">to</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtServAgeTo" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">

                                        <asp:DropDownList ID="ddlDatePart" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="0" Text="Select Any"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Year"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Month"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Day"></asp:ListItem>
                                        </asp:DropDownList>


                                    </div>

                                </div>

                            </div>
                        </div>
                    </div>


                    <div class="form-group">
                        <asp:Label ID="lblSalaryRange" runat="server" CssClass="col-md-4 control-label" Text="Salary Range" />
                        <div class="col-md-8">
                            <div class="row">
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtSalaryRangeFrom" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                </div>
                                <div class="col-md-7">
                                    <div class="col-md-1">to</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtSalaryRangeTo" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>




                </div>
                <div class="form-group">
                    <div class="input-group col-md-4 col-md-offset-4">
                        <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info pull-left" runat="server" OnClick="btnShow_Click" />
                        <asp:Button ID="btnPrint" Text="Print " CssClass="btn btn-info pull-right" runat="server" OnClick="btnPrint_Click"/>

                    </div>
                </div>

                <div class="panel-body">

                    <div class="table table-responsive table-bordered clearfix " style="height: 600px; overflow: auto">
                        <asp:GridView ID="gvEmployeeInfo" CssClass="table " runat="server" AutoGenerateColumns="false" OnRowDataBound="gvEmployeeInfo_RowDataBound" OnSelectedIndexChanged="gvEmployeeInfo_SelectedIndexChanged">
                            <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                            <Columns>

                                <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                    HeaderStyle-CssClass="HiddenColumn" />
                                <asp:BoundField DataField="EmpSl" HeaderText="ID" Visible="false" />
                                <asp:BoundField DataField="IDNo" HeaderText="IDNo" />
                                <asp:BoundField DataField="EmpName" HeaderText="Name" />

                                <asp:TemplateField HeaderText="Photo" HeaderStyle-Width="60px">
                                    <ItemTemplate>
                                        <asp:Image ImageUrl='<%# "data:image/png;base64," + Convert.ToBase64String((byte[])Eval("ImgPath")) %>' runat="server" Height="200" Width="150" />
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
                                        <asp:Image ImageUrl='<%# "data:image/png;base64," + Convert.ToBase64String((byte[])Eval("SignPath")) %>' runat="server" Height="200" Width="150" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="CV" HeaderStyle-Width="60px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lblCv" runat="server">
                                                 Download
                                        </asp:LinkButton>
                                        <asp:Image ID="Image3" runat="server" Visible="true" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSHR" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Reports");
        });
    </script>
</asp:Content>
