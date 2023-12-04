<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="RandDPlanForNewEdition.aspx.cs" Inherits="BLL.RandDPlanForNewEdition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-7">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Plan For New Edition
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlCategory" CssClass="col-md-4 control-label no-padding-right" Text="Category" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                        <asp:ListItem Value="">--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlGroup" CssClass="col-md-4 control-label no-padding-right" Text="Group" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlGroup" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlClass" CssClass="col-md-4 control-label no-padding-right" Text="Class" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlClass" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlType" CssClass="col-md-4 control-label no-padding-right" Text="Type" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlBookName" CssClass="col-md-4 control-label no-padding-right" Text="Book Name" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlBookName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBookName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlEdition" CssClass="col-md-4 control-label no-padding-right" Text="Edition" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlEdition" runat="server" AutoPostBack="True">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <h4>Select Related Section With This Book</h4>
                        </div>
                        <div class="panel-body" style="border: 1px solid #BDC3CA">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:DropDownList CssClass="form-control" ID="ddlSection" runat="server" OnTextChanged="ddlSection_TextChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <fieldset>
                                    <div class="checkbox col-md-8 col-md-offset-3">
                                        <asp:Label AssociatedControlID="checkboxHireSection" runat="server" Text="Hire Section>>" Visible="True"></asp:Label>
                                        <asp:CheckBox ID="checkboxHireSection" runat="server" OnCheckedChanged="checkboxHireSection_CheckedChanged" AutoPostBack="true" visible="True"/>
                                    </div>
                                </fieldset>
                            </div>
                            <asp:UpdatePanel runat="server" ID="UpdatePortion">
                                <ContentTemplate>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlHireSection" ID="lblHireSection" CssClass="col-md-3 control-label" Text="Hire Section" runat="server" Visible="false"></asp:Label>
                                        <div class="col-md-7">
                                            <asp:DropDownList CssClass="form-control" ID="ddlHireSection" runat="server" OnSelectedIndexChanged="ddlHireSection_TextChanged" Visible="false">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
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
                                <div class="col-md-4">
                                        <asp:Label AssociatedControlID="ddlEmpName" CssClass="col-md-3 control-label no-padding-left" Text="Name" runat="server"></asp:Label>
                                        <asp:DropDownList CssClass="form-control" ID="ddlEmpName" runat="server" AutoPostBack="True" OnTextChanged="ddlEmpName_OnTextChanged">
                                        </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label AssociatedControlID="ddlDesignation" CssClass="col-md-3 control-label no-padding-left" Text="Designation" runat="server"></asp:Label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlDesignation" runat="server" AutoPostBack="True">
                                    </asp:DropDownList>
                              </div>
                                <div class="col-md-4">
                                        <asp:Label AssociatedControlID="ddlTask" CssClass="col-md-3 control-label no-padding-left" Text="Task" runat="server"></asp:Label>
                                        <asp:DropDownList CssClass="form-control" ID="ddlTask" runat="server">
                                        </asp:DropDownList>
                                </div>
                           </div>
                       </div>
                  </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4">
                    <div class="col-sm-12">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtNote" CssClass="col-sm-3 control-label no-padding-right" Text="Note" runat="server" ></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox CssClass="form-control" ID="txtNote" placeholder=" Write Something.." runat="server" TextMode="MultiLine" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h6>Management Approval</h6>
                        </div>
                         <div class="panel-body" style="border: 1px solid #BDC3CA">
                             <asp:ListBox CssClass="form-control" ID="ListBox2" runat="server" Height="30px"></asp:ListBox>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtSelectedSection" CssClass="col-md-5 control-label" Text="Selected Section(s)" runat="server"></asp:Label>
                        <div class="col-md-7">
                            <asp:TextBox CssClass="form-control" ID="txtSelectedSection" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtSelectedTask" CssClass="col-md-5 control-label" Text="Selected Task(s)" runat="server"></asp:Label>
                        <div class="col-md-7">
                            <asp:TextBox CssClass="form-control" ID="txtSelectedTask" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtSelectedDay" CssClass="col-md-5 control-label" Text="Approximate Day(s)" runat="server"></asp:Label>
                        <div class="col-md-7">
                            <asp:TextBox CssClass="form-control" ID="txtSelectedDay" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-5">
                            <asp:Button ID="btnPreview" Text="Preview" CssClass="btn btn-info" runat="server" />
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" />
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
