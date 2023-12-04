<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="Rnd_UpdateWorkDetailsQawmi.aspx.cs" Inherits="BLL.Rnd_UpdateWorkDetailsQawmi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
 <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Update Work Entry Qawmi
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
                    <div class="panel-body" >
                        <div class="table-responsive table-bordered clearfix " ID="UpdatePanel" runat="server" visible="false">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtDetailsID" Text="Work ID" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control" ID="txtDetailsID" runat="server" ReadOnly="True" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtDate" CssClass="col-md-3 control-label" Text="Date" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control date" ID="txtDate" placeholder="yyyy-MM-dd" runat="server" />
                                    <ajaxToolkit:CalendarExtender TargetControlID="txtDate" Format="yyyy-MM-dd" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtStartTime" CssClass="col-md-3 control-label" Text="Start Time" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control" ID="txtStartTime" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtEndTime" CssClass="col-md-3 control-label" Text="End Time" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control" ID="txtEndTime" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlSubject" CssClass="col-md-3 control-label" Text="Subject" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:DropDownList CssClass="form-control" ID="ddlSubject" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlTask" CssClass="col-md-3 control-label" Text="Task" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:DropDownList CssClass="form-control" ID="ddlTask" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtStartPage" CssClass="col-md-3 control-label" Text="Start Page" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:TextBox CssClass="form-control" ID="txtStartPage" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtEndPage" CssClass="col-md-3 control-label" Text="End Page" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:TextBox CssClass="form-control" ID="txtEndPage" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtComments" CssClass="col-md-3 control-label" Text="Comments" runat="server"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:TextBox CssClass="form-control" ID="txtComments" runat="server" TextMode="MultiLine" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-11 col-md-offset-0">
                                        <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-success pull-right" runat="server" OnClick="btnUpdate_OnClick" />
                                    </div>
                                </div>
                         </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="table-responsive table-bordered clearfix ">
                            <asp:GridView ID="gvDateWiseWorkDetails" CssClass="table " runat="server" AutoGenerateColumns="false" OnRowDataBound="gvDateWiseWorkDetails_RowDataBound" OnSelectedIndexChanged="gvDateWiseWorkDetails_SelectedIndexChanged">
                                <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                <Columns>
                                    <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn" HeaderStyle-CssClass="HiddenColumn" visible="false"/>
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
                                <asp:CommandField SelectText="Edit" ShowSelectButton="true" Visible="true" ItemStyle-CssClass="btn btn-compose" HeaderStyle-CssClass="HiddenColumn" />
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
            open_menu("Daily Work Qawmi");
        });
    </script>
</asp:Content>