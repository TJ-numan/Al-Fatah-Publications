<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmEmpPassportVisa.aspx.cs" Inherits="BLL.HrmEmpPassportVisa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Employee Passport Visa
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlInfoStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Info Status</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlInfoStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPassportVisaNo" runat="server" CssClass="control-label col-md-2 no-padding-right">Passport/Visa No</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtPassportVisaNo" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlEmployee" runat="server" CssClass="control-label col-md-2 no-padding-right">Employee</asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlEmployee" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtPassOrVisa" runat="server" CssClass="control-label col-md-2 no-padding-right">Passport/Visa</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtPassOrVisa" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtIssuedBy" runat="server" CssClass="control-label col-md-2 no-padding-right">Issued By</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtIssuedBy" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtIssueDate" CssClass="control-label col-md-2 no-padding-right">Issue Date</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox CssClass="form-control" ID="txtIssueDate" placeholder="yyyy-MM-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="txtIssueDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtExpiredDate" CssClass="control-label col-md-2 no-padding-right">Expired Date</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox CssClass="form-control" ID="txtExpiredDate" placeholder="yyyy-MM-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="txtExpiredDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtEligiRevwDate" CssClass="control-label col-md-2 no-padding-right">Eligible Review Date</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox CssClass="form-control" ID="txtEligiRevwDate" placeholder="yyyy-MM-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="txtEligiRevwDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtEligibleStatus" runat="server" CssClass="control-label col-md-2 no-padding-right">Eligible Status</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtEligibleStatus" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtComments" runat="server" CssClass="control-label col-md-2 no-padding-right">Comments</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtComments" CssClass="form-control" runat="server"></asp:TextBox>
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
                                <asp:GridView ID="gvEmployeePassport" CssClass="table " runat="server" AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />

                                        <asp:BoundField DataField="PaViId" HeaderText="ID" />
                                        <asp:BoundField DataField="IDNo" HeaderText="Employee ID" />
                                        <asp:BoundField DataField="EmpName" HeaderText="Employee Name" />
                                        <asp:BoundField DataField="NickName" HeaderText="NickName" />
                                        <asp:BoundField DataField="DepName" HeaderText="Department" />
                                        <asp:BoundField DataField="DesName" HeaderText="Designation" />
                                        <asp:BoundField DataField="PaViNo" HeaderText="PaViNo" />

                                        <asp:BoundField DataField="PassOrVisa" HeaderText="Issued Country" />
                                        <asp:BoundField DataField="IssueDate" HeaderText="IssueDate" DataFormatString="{0:dd-MM-yyyy}" />
                                        <asp:BoundField DataField="ExpiryDate" HeaderText="ExpiryDate" DataFormatString="{0:dd-MM-yyyy}" />

                                        <asp:BoundField DataField="EligibleReviewDate" HeaderText="EligibleReviewDate" DataFormatString="{0:dd-MM-yyyy}" />
                                        <asp:BoundField DataField="EligibleStatus" HeaderText="EligibleStatus" />
                                        <asp:BoundField DataField="Comments" HeaderText="Comments" />


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
            $('[id*=gvEmployeePassport]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
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
