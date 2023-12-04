<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_UpdateChallanQty.aspx.cs" Inherits="BLL.Mkt_UpdateChallanQty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
     <div id="frmChallanNew" runat="server" class="form-horizontal clearfix">
        <div class="col-md-12 clearfix no-padding">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h4>CancelReturn Book Challan</h4>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6 clearfix">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtMemoNo" CssClass="col-md-4 control-label no-padding-right" Text="Memo No"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="txtMemoNo" placeholder="Enter Memo No" CssClass="form-control" TabIndex="100" AutoPostBack="True" OnTextChanged="txtChlNewMemoNo_TextChanged" />

                                </div>
                                <div class="text-success col-md-8 col-md-offset-4">

                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtChalanID" CssClass="col-md-4 control-label no-padding-right" Text="Chalan ID"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="txtChalanID" CssClass="form-control" ReadOnly="true"/>

                                </div>
                                <div class="text-success col-md-8 col-md-offset-4">

                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtChlNewDate" CssClass="col-md-4 control-label no-padding-right" Text="Challan Date"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="txtChlNewDate" CssClass="form-control" placeholder="yyyy-mm-dd" AutoPostBack="false" TabIndex="0" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtChlNewDate" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlLibName" CssClass="col-md-4 control-label no-padding-right" Text="Library Name"></asp:Label>
                                <div class="col-md-8">
                                    <asp:DropDownList runat="server" ID="ddlLibName" CssClass="form-control" TabIndex="1">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlMemoType" CssClass="col-md-4 control-label no-padding-right" Text="Memo Type"></asp:Label>
                                <div class="col-md-8">
                                    <asp:DropDownList runat="server" ID="ddlMemoType" CssClass="form-control" TabIndex="2">
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
                                    <asp:BoundField HeaderStyle-Width="40px" HeaderText="BookCode" DataField="BookCode"/>
                                    <asp:BoundField HeaderStyle-Width="200px" HeaderText="Book Name" DataField="BookName" />
                                    <asp:BoundField HeaderStyle-Width="100px" HeaderText="Class" DataField="Class" />
                                    <asp:BoundField HeaderStyle-Width="200px" HeaderText="Type" DataField="Type" />
                                    <asp:BoundField HeaderStyle-Width="100px" HeaderText="Edition" DataField="Edition" />
                                    <asp:BoundField HeaderStyle-Width="100px" HeaderText="UnitPrice" DataField="UnitPrice" />
                                    <asp:BoundField HeaderStyle-Width="90px" HeaderText=" Qty " DataField="Qty" />
                                    <asp:BoundField HeaderStyle-Width="120px" HeaderText="Discout %" DataField="DiscountPer" />
                                    <asp:BoundField HeaderStyle-Width="120px" HeaderText="Discount" DataField="TotalDiscount" />
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
                                        <asp:Label runat="server" AssociatedControlID="txtDiscountTotal" CssClass="col-md-4 control-label no-padding-right" Text="Total Discount"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" ID="txtDiscountTotal" CssClass="form-control" Text="0" ReadOnly="true" />
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
                                            <asp:TextBox runat="server" ID="txtCauseOfDelete" CssClass="form-control" placeholder="Cause Of Delete"/>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="form-group">
                                <div class="col-md-8 col-md-offset-4">                                   
                                    <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-success" Text="Cancel Challan"   OnClientClick="if (!confirm('Do You Want to Delete?')) return false;" OnClick="btnCancel_Click"/>
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
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
        <script type="text/javascript">
            $(document).ready(function () {
                open_menu("Challan");
            });
    </script>
</asp:Content>
