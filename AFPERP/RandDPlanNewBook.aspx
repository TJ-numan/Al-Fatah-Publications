<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="RandDPlanNewBook.aspx.cs" Inherits="BLL.RandDPlanNewBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
 <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Plan For New Book
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlCategory" CssClass="col-md-4 control-label no-padding-right" Text="Category" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList CssClass="form-control" ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                        <asp:ListItem Value="">--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlGroup" CssClass="col-md-4 control-label no-padding-right" Text="Group" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList CssClass="form-control" ID="ddlGroup" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlClass" CssClass="col-md-4 control-label no-padding-right" Text="Class" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList CssClass="form-control" ID="ddlClass" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlType" CssClass="col-md-4 control-label no-padding-right" Text="Type" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList CssClass="form-control" ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlBookName" CssClass="col-md-4 control-label no-padding-right" Text="Book Name" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList CssClass="form-control" ID="ddlBookName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBookName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtEdition" CssClass="col-md-4 control-label no-padding-right" Text="Edition" runat="server"></asp:Label>
                                <div class="col-md-4">
                               <%-- <asp:DropDownList CssClass="form-control" ID="ddlEdition" runat="server" AutoPostBack="True">
                                    </asp:DropDownList>--%>
                                    <asp:TextBox CssClass="form-control" ID="txtEdition" runat="server"/>
                                </div>
                            </div>
                            <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlBookSize" CssClass="col-md-4 control-label" Text="Size" runat="server"></asp:Label>
                                    <div class="col-md-4">
                                        <asp:DropDownList CssClass="form-control" ID="ddlBookSize" runat="server"></asp:DropDownList>
                                    </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h4>Select Employee for Task</h4>
                        </div>
                        <div class="panel-body" style="border: 1px solid #BDC3CA">
                            <div class="row">
                                <div class="col-md-3">
                                        <asp:Label AssociatedControlID="ddlTask" CssClass="control-label no-padding-left" Text="Task" runat="server"></asp:Label>
                                        <asp:DropDownList CssClass="form-control" ID="ddlTask" runat="server">
                                        </asp:DropDownList>
                                </div>
                                <div class="col-md-1">
                                        <asp:Label AssociatedControlID="ddlEmplyeeFor" CssClass="control-label no-padding-left" Text="Emplyee For" runat="server"></asp:Label>
                                        <asp:DropDownList CssClass="form-control" ID="ddlEmplyeeFor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEmployeeFor_SelectedIndexChanged">
                                                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="InHouse"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="OutSource"></asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label AssociatedControlID="ddlSection" ID="lblSection" CssClass="control-label  no-padding-left" Text="Section" runat="server"></asp:Label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlSection" runat="server" OnTextChanged="ddlSection_TextChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                     <asp:Label AssociatedControlID="ddlEmpName" CssClass="control-label  no-padding-left" Text="Name" runat="server"></asp:Label>
                                     <asp:DropDownList CssClass="form-control" ID="ddlEmpName" runat="server" AutoPostBack="True" OnTextChanged="ddlEmpName_OnTextChanged">
                                     </asp:DropDownList>
                                </div>
                              <div class="col-md-1">
                                    <asp:Label AssociatedControlID="dtpFromDate" CssClass="control-label no-padding-left" Text="From" runat="server"></asp:Label>
                                     <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-mm-dd" runat="server" />
                                     <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                              </div>
                              <div class="col-md-1">
                                    <asp:Label AssociatedControlID="dtpToDate" CssClass="control-label no-padding-left" Text="To" runat="server"></asp:Label>
                                    <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-mm-dd" runat="server" />
                                    <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />
                              </div>
                              <div class="col-md-1">
                                    <asp:Label AssociatedControlID="txtFromPage" CssClass="control-label no-padding-left" Text="From Page" runat="server"></asp:Label>
                                    <asp:TextBox CssClass="form-control date" ID="txtFromPage" placeholder="Ex. 10" runat="server" />
                              </div>
                              <div class="col-md-1">
                                    <asp:Label AssociatedControlID="txtToPage" CssClass="control-label no-padding-left" Text="To Page" runat="server"></asp:Label>
                                    <asp:TextBox CssClass="form-control date" ID="txtToPage" placeholder="Ex. 50" runat="server" />
                              </div>
                              <div class="col-md-12">
                                   <asp:Button ID="btnAdd" Text="Add" CssClass="btn btn-success btn pull-right" runat="server" OnClick="btnAdd_OnClick" />
                              </div>
                         </div>
                        <div class="row">
                            <hr style="border: 1px solid silver" />
                            <asp:GridView ID="gvDailyWorks" runat="server" AutoGenerateColumns="False" CssClass="table" OnSelectedIndexChanged="gvDailyWorks_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" DataField="Serial" />
                                    <asp:BoundField HeaderStyle-Width="300px" HeaderText="Subject" DataField="Subject" />
                                    <asp:BoundField HeaderStyle-Width="300px" HeaderText="Work Type" DataField="WorkType" />
                                    <asp:BoundField HeaderStyle-Width="150px" HeaderText="Employee For" DataField="EmployeeFor" />
                                    <asp:BoundField HeaderStyle-Width="300px" HeaderText="Employee" DataField="Employee" />
                                    <asp:BoundField HeaderStyle-Width="150px" HeaderText="Forma" DataField="TotalForma" />                                   
                                    <asp:BoundField HeaderStyle-Width="150px" HeaderText="From Page" DataField="FromPage" /> 
                                    <asp:BoundField HeaderStyle-Width="150px" HeaderText="To Page" DataField="ToPage" />
                                    <asp:BoundField HeaderStyle-Width="150px" HeaderText="Work Start" DataField="WorkStart" />
                                    <asp:BoundField HeaderStyle-Width="150px" HeaderText="Work End" DataField="WorkEnd" />
                                    <asp:BoundField HeaderStyle-Width="100px" HeaderText="Day" DataField="Day" />
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lblDelete" OnClick="lblDelete_OnClick" runat="server" CommandArgument='<%#Eval("Serial") %>'>
                                                                       Delete
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <hr style="border: 1px solid silver" />
                        </div>
                       </div>
                  </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtSelectedTask" CssClass="col-md-4 control-label" Text="Selected Task(s)" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox CssClass="form-control" ID="txtSelectedTask" runat="server" readonly="true"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtWorkPlanID" CssClass="col-md-4 control-label" Text="Plan ID" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox CssClass="form-control" ID="txtWorkPlanID" runat="server"  readonly="true"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtSelectedDay" CssClass="col-md-4 control-label" Text="Approximate Day(s)" runat="server" Visible="false"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox CssClass="form-control" ID="txtSelectedDay" runat="server" readonly="true" Visible="false"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="btnSave" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_OnClick"/>
                            <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-primary" runat="server" OnClick="btnPrint_OnClick"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSRandD" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Planning");
        });
    </script>
</asp:Content>
