<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="Rnd_DeleteWorkDetails.aspx.cs" Inherits="BLL.Rnd_DeleteWorkDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
<div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Delete Work Entry
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-4 control-label" Text="From" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-4 control-label" Text="To" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                         <asp:Label AssociatedControlID="ddlSection" CssClass="col-md-4 control-label" Text="Section" runat="server"></asp:Label>
                         <div class="col-md-3">
                              <asp:DropDownList CssClass="form-control" ID="ddlSection" runat="server" OnTextChanged="ddlSection_TextChanged" AutoPostBack="True">
                              </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                          <asp:Label AssociatedControlID="ddlEmpName" CssClass="col-md-4 control-label" Text="Name" runat="server"></asp:Label>
                          <div class="col-md-3">
                                <asp:DropDownList CssClass="form-control" ID="ddlEmpName" runat="server">
                                </asp:DropDownList>
                          </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="btnShow" CssClass="col-md-4 control-label" Text="" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:Button ID="btnShow" Text="Show"  CssClass="btn btn-success" runat="server" OnClick="btnShow_Click" />
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="table-responsive table-bordered clearfix ">
                            <asp:GridView ID="gvDateWiseWorkDetails" CssClass="table " runat="server" AutoGenerateColumns="false" OnRowDataBound="gvDateWiseWorkDetails_RowDataBound">
                                <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                <Columns>
                                    <asp:TemplateField>
                                         <ItemTemplate>
                                              <asp:CheckBox ID="chkWorkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="chkWorkSelect_CheckedChanged" />
                                         </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="WorkDetailID" HeaderText="Work ID"/>
                                    <asp:BoundField DataField="WorkDate" HeaderText="Work Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="EmployeeID" HeaderText="Employee" />
                                    <asp:BoundField DataField="WorkTypeID" HeaderText="Work Type" />
                                    <asp:BoundField DataField="BookID" HeaderText="Book" />
                                    <asp:BoundField DataField="WorkStartTime" HeaderText="Start Time" />
                                    <asp:BoundField DataField="WorkEndTime" HeaderText="End Time" />
                                    <asp:BoundField DataField="PageStart" HeaderText="PageStart" />
                                    <asp:BoundField DataField="PageEnd" HeaderText="PageEnd" />
                                    <asp:BoundField DataField="Comments" HeaderText="Comments" />
                                    <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="100px">
                                           <ItemTemplate>
                                                <asp:TextBox ID="txtRemarks" runat="server" Width="120px" ></asp:TextBox>
                                           </ItemTemplate>
                                    </asp:TemplateField> 
                                    <asp:TemplateField HeaderText="">
                                          <ItemTemplate>
                                              <asp:button ID="btnCancel"  text='Delete' OnClick="btnCancel_OnClick" runat="server" CommandArgument='<%#Eval("WorkDetailID") %>' CssClass="btn btn-danger" Width="100px"></asp:button>
                                          </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <SelectedRowStyle BackColor="#393737" Font-Bold="true" ForeColor="#F7F7F7" />


                            </asp:GridView>
                        </div>
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSRandD" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Daily Work Alia");
        });
    </script>
</asp:Content>