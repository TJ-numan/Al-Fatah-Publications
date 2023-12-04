<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="RndWorkOrderCancel.aspx.cs" Inherits="BLL.RndWorkOrderCancel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
     <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Work Order Cancel
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtWorkOrder" CssClass="col-md-4 control-label" Text="Order No/ Employee Name" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox CssClass="form-control" ID="txtWorkOrder" placeholder="Order No or Employee Name" runat="server" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="btnShow" CssClass="col-md-4 control-label" Text="" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:Button ID="btnShow" Text="Show"  CssClass="btn btn-info" runat="server" OnClick="btnShow_Click" />

                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="table-responsive table-bordered clearfix ">
                            <asp:GridView ID="gvWorkOderDetails" CssClass="table " runat="server" AutoGenerateColumns="false" OnRowDataBound="gvWorkOderDetails_RowDataBound" OnSelectedIndexChanged="gvWorkOderDetails_SelectedIndexChanged">
                                <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                <Columns>
                                    <asp:TemplateField>
                                         <ItemTemplate>
                                              <asp:CheckBox ID="chkWorkOrderSelect" runat="server" AutoPostBack="true" OnCheckedChanged="chkWorkOrderSelect_CheckedChanged" />
                                         </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="WorkOrderID" HeaderText="Order No"/>
                                    <asp:BoundField DataField="WorkOrderDetID" HeaderText="Details ID" />
                                    <asp:BoundField DataField="WorkIssueDate" HeaderText="Issue Date" DataFormatString="{0:dd/MM/yyyy}"/>
                                    <asp:BoundField DataField="IsHired" HeaderText="Employee For"/>
                                    <asp:BoundField DataField="SectionName" HeaderText="Section"/>
                                    <asp:BoundField DataField="EmployeeID" HeaderText="Name"/>
                                    <asp:BoundField DataField="BookID" HeaderText="Book"/>
                                    <asp:BoundField DataField="ClassName" HeaderText="Class"/>
                                    <asp:BoundField DataField="WorkTypeID" HeaderText="Work Type"/>
                                    <asp:BoundField DataField="EDD" HeaderText="EDD" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="PageStart" HeaderText=" To Page"/>
                                    <asp:BoundField DataField="PageEnd" HeaderText="From Page"/>
                                    <asp:BoundField DataField="TotalPage" HeaderText="Total Page" />
                                    <asp:BoundField DataField="TotalForma" HeaderText="Total Forma" />
                                    <asp:BoundField DataField="TotalCharacter" HeaderText="Total Char" />
                                    <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="100px">
                                           <ItemTemplate>
                                                <asp:TextBox ID="txtRemarks" runat="server" Width="120px" ></asp:TextBox>
                                           </ItemTemplate>
                                    </asp:TemplateField> 
                                    <asp:TemplateField HeaderText="">
                                          <ItemTemplate>
                                              <asp:button ID="btnCancel"  text='Delete' OnClick="btnCancel_OnClick" runat="server" CommandArgument='<%#Eval("WorkOrderDetID") %>' CssClass="btn btn-danger" Width="100px"></asp:button>
                                          </ItemTemplate>
                                    </asp:TemplateField>                                                                                                       
                                </Columns>
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
            open_menu("Work Order Alia");
        });
    </script>
</asp:Content>
