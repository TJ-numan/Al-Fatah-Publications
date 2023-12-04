<%@ Page Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="TaskDetail.aspx.cs" Inherits="BLL.TaskDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
 <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Book Wise Task Detail
                        </div>
                        <div class="panel-body" style="margin-left:400px">
                        <div class="form-group" style="margin-top:6px">
                                <asp:Label AssociatedControlID="LitBookID" Text="Book ID:" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-4">
                                     <asp:Literal ID="LitBookID" runat="server"></asp:Literal>
                                </div>
                            </div>

                                <div class="form-group" style="margin-top:6px">
                                <asp:Label AssociatedControlID="litBookName" Text="Book Name:" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-4">
                                    <%--<asp:TextBox CssClass="form-control" ID="txtBookName" runat="server"/>--%>
                                    <asp:Literal ID="litBookName" runat="server"></asp:Literal>
                                </div>
                            </div>

                                                    <div class="form-group" style="margin-top:6px">
                                <asp:Label AssociatedControlID="txtClass" Text="Class:" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-4">
                                    <%--<asp:TextBox CssClass="form-control" ID="txtClass" runat="server"/>--%>
                                     <asp:Label ID="txtClass" CssClass="form-control-static" runat="server"></asp:Label>
                                </div>
                            </div>

                                                    <div class="form-group" style="margin-top:6px">
                                <asp:Label AssociatedControlID="LitEdition" Text="Edition:" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-4">
                                    <asp:Literal ID="LitEdition" runat="server"></asp:Literal>
                                </div>
                            </div>
                             <div class="form-group" style="margin-top:6px">
                                <asp:Label AssociatedControlID="LitBookSize" Text="Book Size:" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-4">
                                     <asp:Literal ID="LitBookSize" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-success">
               
                        <div class="panel-body" style="border: 1px solid #BDC3CA">
      
                        <div class="row">
                            <hr style="border: 1px solid silver" />
                           <asp:GridView ID="gvwTaskList" runat="server" AutoGenerateColumns="False" CssClass="table" OnRowDataBound="gvwTaskList_RowDataBound">
                                <Columns>     
                                    <asp:BoundField HeaderText="Task ID" DataField="WorkPlanID" />      
                                    <asp:BoundField HeaderText="Task Name" DataField="TaskName" />                       
                                    <asp:BoundField HeaderText="Employee Name" DataField="EmployeeName" /> 
                                    <asp:BoundField HeaderText="Employee Type" DataField="EmployeeForID" />
                                    <asp:BoundField HeaderText="Employee ID" DataField="EmployeeID" />
                                    <asp:BoundField HeaderText="Work Start" DataField="WorkStart" />
                                    <asp:BoundField HeaderText="Work End" DataField="WorkEnd" />
                                    <asp:BoundField HeaderText="Total Day" DataField="TotalDay" />
                                    <asp:BoundField HeaderText="PageStart" DataField="PageStart" />
                                    <asp:BoundField HeaderText="PageEnd" DataField="PageEnd" />
                                    <asp:BoundField HeaderText="TotalPage" DataField="TotalPage" />
                                    <asp:BoundField HeaderText="SectionName" DataField="SectionName" />
                                    <asp:BoundField HeaderText="Task Status" DataField="TaskStatus" />
                             

                                    <asp:TemplateField HeaderText="Update Task">
            <ItemTemplate>
                <asp:DropDownList ID="ddlTaskStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTaskStatus_SelectedIndexChanged">
                    <asp:ListItem Text="-select-" Value="select" />
                    <asp:ListItem Text="ToDo" Value="ToDo" />
                    <asp:ListItem Text="In Progress" Value="InProgress" />
                    <asp:ListItem Text="Done" Value="Done" />
                </asp:DropDownList>
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
            
            </div>
        </div>
    </div>
</asp:Content>
