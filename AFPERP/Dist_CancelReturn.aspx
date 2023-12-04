<%@ Page Title="" Language="C#" MasterPageFile="~/Distribution.master" AutoEventWireup="true" CodeBehind="Dist_CancelReturn.aspx.cs" Inherits="BLL.Dist_CancelReturn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DistributionContent" runat="server">
     <div id="frmReturnCancelNew" runat="server" class="form-horizontal clearfix">
        <div class="col-md-12 clearfix no-padding">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h4>Cancel Return</h4>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6 clearfix">
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtMemoNo" ErrorMessage="Please enter MR No!" ForeColor="Red" ID="RVforMRno" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlCom" CssClass="col-md-4 control-label no-padding-left" Text=" Select Company"></asp:Label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlCom" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="A" Text="Alia"></asp:ListItem>
                                        <asp:ListItem Value="Q" Text="Qawmi"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtMemoNo" CssClass="col-md-4 control-label no-padding-right" Text="Memo No"></asp:Label>
                                <div class="col-md-5">
                                    <asp:TextBox runat="server" ID="txtMemoNo" CssClass="form-control" TabIndex="100" AutoPostBack="True" OnTextChanged="txtRtnNewMemoNo_TextChanged" />

                                </div>
                                <div class="col-md-3">
                                    <asp:Button runat="server" ID="btnEnter" Text="Enter" CssClass="btn btn-danger btnBookCodeEnter" OnClick="txtRtnNewMemoNo_TextChanged"></asp:Button>
                                </div>
                                <div class="text-success col-md-8 col-md-offset-4">

                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtReturnID" CssClass="col-md-4 control-label no-padding-right" Text="Return ID"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="txtReturnID" CssClass="form-control" ReadOnly="true"/>

                                </div>
                                <div class="text-success col-md-8 col-md-offset-4">

                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtRtnNewDate" CssClass="col-md-4 control-label no-padding-right" Text="Challan Date"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="txtRtnNewDate" CssClass="form-control" placeholder="yyyy-mm-dd" AutoPostBack="false" TabIndex="0" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtRtnNewDate" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlLibraryName" CssClass="col-md-4 control-label no-padding-right" Text="Library Name"></asp:Label>
                                <div class="col-md-8">
                                    <asp:DropDownList runat="server" ID="ddlLibraryName" CssClass="form-control" TabIndex="1">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr style="border: 1px solid silver" />
                    
                        <div class="clearfix table-responsive">
                            <asp:GridView ID="gvwChlNew" runat="server" AutoGenerateColumns="False" CssClass="table">
                                <Columns>
                                    <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" DataField="Serial" />
                                    <asp:BoundField HeaderStyle-Width="100px" HeaderText="Book AC Code" DataField="BookAcCode" />
                                    <asp:BoundField HeaderStyle-Width="100px" HeaderText="Book Code" DataField="BookID"/>
                                    <asp:BoundField HeaderStyle-Width="200px" HeaderText="Book Name" DataField="BookName" />
                                    <asp:BoundField HeaderStyle-Width="100px" HeaderText="Class" DataField="Class" />
                                    <asp:BoundField HeaderStyle-Width="100px" HeaderText="Type" DataField="Type" />
                                    <asp:BoundField HeaderStyle-Width="100px" HeaderText="Edition" DataField="Edition" />
                                    <asp:BoundField HeaderStyle-Width="100px" HeaderText="UnitPrice" DataField="UnitPrice" />
                                    <asp:BoundField HeaderStyle-Width="100px" HeaderText="Qty" DataField="Qty" />
                                    <asp:BoundField HeaderStyle-Width="120px" HeaderText="Amount" DataField="Total" />
                                   <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("Serial") %>'>
                                                 Delete
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                   <hr style="border: 1px solid silver" />
                </div>
                <div class="col-md-12 clearfix no-padding">
                    <div class="panel-body">
                        <div class="col-md-6 clearfix">
                        </div>
                        <div class="col-md-6 clearfix">
                            <asp:UpdatePanel ID="upPayment" runat="server">
                                <ContentTemplate>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtTotalAmount" CssClass="col-md-4 control-label no-padding-right" Text="Total Amount"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" ID="txtTotalAmount" CssClass="form-control" Text="0" ReadOnly="true" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtPacketNo" CssClass="col-md-4 control-label no-padding-right" Text="*Packet No"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" ID="txtPacketNo" CssClass="form-control" Text="0" AutoPostBack="true"  />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtPerPacketCost" CssClass="col-md-4 control-label no-padding-right" Text="*Per Packet Cost"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" ID="txtPerPacketCost" CssClass="form-control" Text="0" AutoPostBack="true"  />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtAmountReceivable" CssClass="col-md-4 control-label no-padding-right" Text="Amount Receivable"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" ID="txtAmountReceivable" CssClass="form-control" Text="0" ReadOnly="true" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtCauseOfDelete" CssClass="col-md-4 control-label no-padding-right" Text="Cause Of Delete"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" ID="txtCauseOfDelete" CssClass="form-control"/>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="form-group">
                                <div class="col-md-8 col-md-offset-4">                                   
                                    <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-success" Text="Cancel Return"   OnClientClick="if (!confirm('Do You Want to Delete?')) return false;" OnClick="btnCancel_Click"/>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-md-12 clearfix no-padding">
                    <div class="panel">
                        <div class="panel-body">
                            <div class="col-md-6 clearfix">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSDistribution" runat="server">
        <script>
            $(document).ready(function () {
                open_menu("Return");
            });
    </script>
</asp:Content>
