<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmEmpIncrePromoTrans.aspx.cs" Inherits="BLL.HrmEmpIncrePromoTrans" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Employee Increment Promotion Transfer
                </div>
                <div class="panel-body">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-4 no-padding-right">Info Status</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlEmployee" runat="server" CssClass="control-label col-md-4 no-padding-right">Employee</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlEmployee" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            &nbsp;&nbsp;&nbsp;
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlPrevDept" runat="server" CssClass="control-label col-md-4 no-padding-right">Previous Department</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlPrevDept" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlPrevDesig" runat="server" CssClass="control-label col-md-4 no-padding-right">Previous Designation</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlPrevDesig" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlPrevSec" runat="server" CssClass="control-label col-md-4 no-padding-right">Previous Section</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlPrevSec" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlPrevPayGrade" runat="server" CssClass="control-label col-md-4 no-padding-right">Prev Pay Grade</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlPrevPayGrade" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPrevPayGrade_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlPrevPayScale" runat="server" CssClass="control-label col-md-4 no-padding-right">Prev Pay Scale</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlPrevPayScale" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlEmploymentSt" runat="server" CssClass="control-label col-md-4 no-padding-right">Employment Status</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList runat="server" ID="ddlEmploymentSt" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtComments" runat="server" CssClass="control-label col-md-4 no-padding-right">Comments</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtComments" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            &nbsp;&nbsp;&nbsp;
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlPresDept" runat="server" CssClass="control-label col-md-4 no-padding-right">Present Department</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlPresDept" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlPresDesig" runat="server" CssClass="control-label col-md-4 no-padding-right">Present Designation</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlPresDesig" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlPresSec" runat="server" CssClass="control-label col-md-4 no-padding-right">Present Section</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlPresSec" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlPresPayGrade" runat="server" CssClass="control-label col-md-4 no-padding-right">Pres Pay Grade</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlPresPayGrade" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPresPayGrade_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlPresPayScale" runat="server" CssClass="control-label col-md-4 no-padding-right">Pres Pay Scale</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlPresPayScale" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>


                        <div class="form-group">
                            <div class="col-md-4 col-md-offset-2">
                                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                                <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" />
                            </div>
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
                                <asp:GridView ID="gvEmployeePromotion" CssClass="table " runat="server" AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />

                                        <asp:BoundField DataField="EmpSl" HeaderText="ID" />
                                        <asp:BoundField DataField="EmpName" HeaderText="Name" />
                                        <asp:BoundField DataField="IDNo" HeaderText="IDNO" />
                               
                                        <asp:BoundField DataField="NickName" HeaderText="Nick Name" />
                                        <asp:BoundField DataField="DepName" HeaderText="Department" />

                                        <asp:BoundField DataField="DesName" HeaderText="Designation" />
                                        <asp:BoundField DataField="SecName" HeaderText="Section" />

                                        <asp:BoundField DataField="PayGrName" HeaderText="Pay Grade" />
                                        
                                        <asp:BoundField DataField="PSAmt" HeaderText="Paid Amount" />

                                        <asp:BoundField DataField="PreDepName" HeaderText="Pre Department" />

                                        <asp:BoundField DataField="PreDesName" HeaderText="Pre Designation" />
                                    

                                        <asp:BoundField DataField="PreSecName" HeaderText="Pre Section" />
                                        <asp:BoundField DataField="PrePayGrNam" HeaderText="Pre Grade" />
                                        <asp:BoundField DataField="PrePSAmt" HeaderText="Pre Paid" />
                                        <asp:BoundField DataField="EmploymentStName" HeaderText="PreviousPayScale" /> 




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
        $(document).ready(function () {
            open_menu("PIMS");
        });
    </script>
</asp:Content>
