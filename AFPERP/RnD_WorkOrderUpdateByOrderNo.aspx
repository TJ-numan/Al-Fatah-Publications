<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="RnD_WorkOrderUpdateByOrderNo.aspx.cs" Inherits="BLL.RnD_WorkOrderUpdateByOrderNo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
<div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Work Order Update
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtWorkOrder" CssClass="col-md-4 control-label" Text="Work Order No" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox CssClass="form-control" ID="txtWorkOrder" placeholder="Order No" runat="server" />

                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="btnShow" CssClass="col-md-4 control-label" Text="" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:Button ID="btnShow" Text="Show"  CssClass="btn btn-info" runat="server" OnClick="btnShow_Click" />

                        </div>
                    </div>
                    <%--Update Panel Start--%>
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
                    <%-- Update Pannel End --%>
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
                                    <asp:TemplateField HeaderText="EDD" HeaderStyle-Width="120px">
                                            <ItemTemplate>                                              
                                                 <asp:TextBox CssClass="form-control date" ID="EDD" Text='<%# Eval("EDD")%>' runat="server" Width="100px"  />
                                                 <ajaxToolkit:CalendarExtender TargetControlID="EDD" Format="yyyy-MM-dd" runat="server" />
                                            </ItemTemplate>
                                    </asp:TemplateField> 
                                    <asp:TemplateField HeaderText="From Page" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                 <asp:TextBox ID="PageStart" runat="server" Text='<%# Eval("PageStart")%>' CssClass="click pl-rate" data-field="pl-rate" Width="100px" ></asp:TextBox>
                                            </ItemTemplate>
                                    </asp:TemplateField> 

                                    <asp:TemplateField HeaderText="To Page" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="PageEnd" runat="server" Text='<%# Eval("PageEnd")%>' CssClass="click pl-qty" data-field="pl-qty" Width="100px"></asp:TextBox>
                                            </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Page">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TotalPage" CssClass="row-total" Text='<%# Eval("TotalPage")%>' data-field="tot-amount" runat="server" Width="100px"></asp:TextBox>
                                            </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Forma" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                 <asp:TextBox ID="TotalForma" runat="server" Text='<%# Eval("TotalForma")%>' CssClass="click pl-rate" Width="100px"></asp:TextBox>
                                            </ItemTemplate>
                                    </asp:TemplateField> 

                                    <asp:TemplateField HeaderText="Total Char" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TotalCharacter" runat="server" Text='<%# Eval("TotalCharacter")%>' CssClass="click pl-qty" Width="100px"></asp:TextBox>
                                            </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                          <ItemTemplate>
                                              <asp:button ID="btnUpdate"  text='Update' OnClick="btnUpdate_OnClick" runat="server" CommandArgument='<%#Eval("WorkOrderDetID") %>' CssClass="btn btn-success" Width="100px"></asp:button>
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
    <script type="text/javascript">

        $(document).ready(function () {
            $(".click").on("keyup", function () {
                tr = $(this).closest('tr');
                plrate = tr.find('input[data-field=pl-rate]').val();
                plqty = tr.find('input[data-field=pl-qty]').val();
                //prorate = tr.find('input[data-field=pro-rate]').val();
                tot = tr.find('input.row-total');
                //tot.val(((plqty * plrate) + (plqty * prorate)).toFixed(2));
                tot.val(((plqty - plrate) + 1).toFixed(2));
                var totsum = 0, totplq = 0, totplb = 0, totprob = 0;
                $('input.row-total').each(function () {
                    totsum += parseFloat(this.value);
                });
                $('input[data-field=pl-qty]').each(function () {
                    totplq += parseFloat((this.value == '') ? '0' : this.value);
                    v = $(this).closest('tr').find('input[data-field=pl-rate]').val();
                    totplb += parseFloat((this.value == '') ? '0' : this.value) * parseFloat(v == '' ? '0' : v);
                });


                $('input[data-tot=tot-plq]').val(totplq.toFixed(2));
                $('input[data-tot=tot-plb]').val(totplb.toFixed(2));
                $('input[data-tot=tot-amount]').val(totsum.toFixed(2));

            });

        });
    </script>
</asp:Content>
