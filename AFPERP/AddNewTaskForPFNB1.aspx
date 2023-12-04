<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="AddNewTaskForPFNB1.aspx.cs" Inherits="BLL.AddNewTaskForPFNB1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Add New Task in Plan for new Book
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label Text="Name of the Task" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">

                                    <div class="col-md-6">
                                        <asp:TextBox CssClass="form-control" ID="txtTaskName" runat="server" placeholder="Task Name" />
                                    </div>
                                     <div class="col-md-6">
                                          <asp:TextBox CssClass="form-control" ID="txtTaskID" runat="server" ReadOnly="True" />
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label Text="Is Hourly" CssClass="col-md-3 control-label" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <div class="col-md-6">
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtisHourly" placeholder="0 for False, 1 for True" />
                                    </div>
                                </div>
                            </div>

                            <asp:Button ID="AddAnother" Text="Add" CssClass="btn btn-primary" runat="server" OnClick="btn_addanother" />
                              <asp:Button ID="btnTaskUpdate" Text="Update" CssClass="btn btn-success pull-right" runat="server" OnClick="btnTaskUpdate_Click" />

                            



                            <asp:GridView ID="gvwNewTask" CssClass="table" runat="server" Align="Center" AutoGenerateColumns="false" EnableViewState="true" OnSelectedIndexChanged="gvwTaskInfromationSelectedIndexChanged">
                                <PagerSettings Mode="NumericFirstLast" />
                                <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                <Columns>
                                      <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />
                                   
                                        <asp:BoundField DataField="TaskID" HeaderText="TaskID" />
                                    <asp:BoundField DataField="TaskName" HeaderText="Name" />
                                    <asp:BoundField DataField="IsHourly" HeaderText="Is Hourly" />

                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("TaskID") %>' OnClick="lbDelete_Click">
Delete
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <SelectedRowStyle BackColor="#393737" Font-Bold="true" ForeColor="#F7F7F7" />
                            </asp:GridView>
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
