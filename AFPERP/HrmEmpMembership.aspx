<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmEmpMembership.aspx.cs" Inherits="BLL.HrmEmpMembership" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel panel-primary">
                <div class="panel-heading">
                    Employee Membership
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
                        <asp:Label AssociatedControlID="txtMembership" runat="server" CssClass="control-label col-md-2 no-padding-right">Membership</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtMembership" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtSubPaidBy" runat="server" CssClass="control-label col-md-2 no-padding-right">Sub PaidBy</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtSubPaidBy" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtSubsFee" runat="server" CssClass="control-label col-md-2 no-padding-right">Subscription Fee</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtSubsFee" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtCurrency" runat="server" CssClass="control-label col-md-2 no-padding-right">Currency</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtCurrency" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="control-label col-md-2 no-padding-right">Subs ReDate</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox CssClass="form-control" ID="txtSubsReDate" placeholder="yyyy-MM-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="txtSubsReDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="control-label col-md-2 no-padding-right">Subs Commence Date</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox CssClass="form-control" ID="txtSubscCommncDate" placeholder="yyyy-MM-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="txtSubscCommncDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtMemberDesc" runat="server" CssClass="control-label col-md-2 no-padding-right">Member Desc.</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtMemberDesc" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>


                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-2">
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" onClick="btnSave_Click"/>
                            <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" />
                        </div>
                    </div>
                    <div class="row">

                        <div class="panel-body">
                            <div class="table-responsive table-bordered clearfix " style="height: 350px; overflow: auto">
                                 <asp:GridView ID="gvEmpMembership" CssClass="table " runat="server" AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />


                                        <asp:BoundField DataField="MemId" HeaderText="ID" />
                                        <asp:BoundField DataField="IDNo" HeaderText="Employee ID" />
                                        <asp:BoundField DataField="EmpName" HeaderText="Employee Name"/>
                                        <asp:BoundField DataField="NickName" HeaderText="NickName" />
                                        <asp:BoundField DataField="DepName" HeaderText="DepName" />
                                        <asp:BoundField DataField="DesName" HeaderText="DesName" />
                                        <asp:BoundField DataField="Membership" HeaderText="Membership" />

                                        <asp:BoundField DataField="SubPaidBy" HeaderText="SubPaidBy" />
                                        <asp:BoundField DataField="SubsFee" HeaderText="SubsFee" />
                                        <asp:BoundField DataField="Currency" HeaderText="Currency" />
                                        <asp:BoundField DataField="SubsCommenceDate" HeaderText="SubsCommenceDate" DataFormatString="{0:dd-MM-yyyy}"  />
                                         <asp:BoundField DataField="SubsReDate" HeaderText="SubsReDate"  DataFormatString="{0:dd-MM-yyyy}" />
                                        <asp:BoundField DataField="MemDes" HeaderText="MemDes" />                                      	 		 	
                                        									
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
    	    $('[id*=gvEmpMembership]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
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
