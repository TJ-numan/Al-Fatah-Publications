<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_BookingBill.aspx.cs" Inherits="BLL.Mkt_BookingBill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <p>Transport Bill</p>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlBillFor" CssClass="control-label col-md-3 no-padding-right" Text="Bill For"  ></asp:Label>
                                <div class="col-md-4" >
                                      <asp:DropDownList ID="ddlBillFor" runat="server" CssClass="form-control"  OnSelectedIndexChanged="ddlBillFor_SelectedIndexChanged" AutoPostBack="true" >
                                            <asp:ListItem Value="0">--Select Bill For--</asp:ListItem>  
                                            <asp:ListItem Value="1">Agent </asp:ListItem>  
                                            <asp:ListItem Value="2">Promotion</asp:ListItem>  
                                      </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlComID" CssClass="control-label col-md-3 no-padding-right" Text="Company"  ></asp:Label>
                                <div class="col-md-4" >
                                      <asp:DropDownList ID="ddlComID" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="0">--Select Company--</asp:ListItem>  
                                            <asp:ListItem Value="A">Alia </asp:ListItem>  
                                            <asp:ListItem Value="Q">Qawmi</asp:ListItem>  
                                      </asp:DropDownList>
                            </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 no-padding-right">Memo No</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtMemoNo" CssClass="form-control" AutoPostBack ="true" OnTextChanged="txtMemoNo_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlLibraryName" CssClass="control-label col-md-3 no-padding-right" Text="Agent Name" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList CssClass="form-control" ID="ddlLibraryName" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtLibraryAddress" CssClass="control-label col-md-3 no-padding-right" Visible="false" Text="Library Address" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox CssClass="form-control" ID="txtLibraryAddress" runat="server" Visible="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtChallanDate" CssClass="control-label col-md-3 no-padding-right" Visible="false" Text="Challan Date" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox CssClass="form-control" ID="txtChallanDate" runat="server" Visible="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 no-padding-right">Packet Qty</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtPacketQty" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 no-padding-right">Per Packet Cost</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtPerPacCost" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 no-padding-right">Transport Name</label>
                                <div class="col-md-4">
                                    <asp:DropDownList runat="server" ID="ddlTransportName" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 no-padding-right">RR No</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtRRNo" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 no-padding-right">Delivery Date</label>
                                <div class="col-md-4">                                                               
                                    <asp:TextBox CssClass="form-control" placeholder="yyyy-mm-dd" ID="txtDeliveryDate" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender TargetControlID="txtDeliveryDate" Format="yyyy-MM-dd" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 no-padding-right">Is Complete</label>
                                <div class="col-md-1">
                                    <asp:CheckBox runat="server" ID="chkIsComplete" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="panel panel-success">
                                <div class="panel-heading">
                                </div>
                                <div class="table table-responsive clearfix">
                                    <table class="table table-hover" >
                                        <tr>
                                            <td>
                                                <label class="control-label">Booking Pkt Qty</label>
                                            </td>
                                            <td>
                                                <label class="control-label">Others Van</label>
                                            </td>
                                            <td>
                                                <label class="control-label">Own Van</label>
                                            </td>
                                            <td>
                                                <label class="control-label">Labour Load</label>
                                            </td>
                                            <td>
                                                <label class="control-label">Labour Unload</label>
                                            </td>
                                            <td>
                                                <label class="control-label">Others Transport</label>
                                            </td>
                                            <td>
                                                <label class="control-label">Own Transport</label>
                                            </td>
                                            <td>
                                                <label class="control-label">Choat</label>
                                            </td>
                                            <td>
                                                <label class="control-label">Polythin</label>
                                            </td>
                                            <td>
                                                <label class="control-label">Selai-In</label>
                                            </td>
                                            <td>
                                                <label class="control-label">Selai-Out</label>
                                            </td>
                                            <td>
                                                <label class="control-label">Per Pkt Cost</label>
                                            </td>
                                            <td>
                                                <label class="control-label">Total Pkt Cost</label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 130px">
                                                <asp:TextBox runat="server" ID="txtPacDelivry" CssClass="form-control" onkeyup="sumPacketCost();"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtVan" CssClass="form-control" onkeyup="sumPacketCost();"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtVanOwn" CssClass="form-control" onkeyup="sumPacketCost();"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtLabourLoad" CssClass="form-control" onkeyup="sumPacketCost();"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtLabourUnload" CssClass="form-control" onkeyup="sumPacketCost();"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtTransport" CssClass="form-control" onkeyup="sumPacketCost();"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="textTransportOwn" CssClass="form-control" onkeyup="sumPacketCost();"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtChoat" CssClass="form-control" onkeyup="sumPacketCost();"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtPolythin" CssClass="form-control" onkeyup="sumPacketCost();"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtSelaiIn" CssClass="form-control" onkeyup="sumPacketCost();"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtSelaiOut" CssClass="form-control" onkeyup="sumPacketCost();"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtBookingPerPacCost" CssClass="form-control"></asp:TextBox>
                                            </td>
                                            <td style="width: 130px">
                                                <asp:TextBox runat="server" ID="txtBookingTotalpackCost" CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                        <td colspan="13">
                                            <asp:Button runat="server" CssClass="btn btn-primary pull-right" Text="Add" ID="txtAdd" OnClick="txtAdd_Click" />
                                        </td>
                                    </tr>
                                </table>
                              </div>
                           </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gvBookingBill"  AutoGenerateColumns="false" runat="server" CssClass="gridCss" Height="100px">
                                <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                <Columns>
                                    <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" Visible="true" DataField="Serial" />
                                    <asp:BoundField HeaderStyle-Width="80px" HeaderText="Memo No" DataField="Memono" />
                                    <asp:BoundField HeaderStyle-Width="300px" HeaderText="Agent Name" DataField="AgentName" />
                                    <asp:BoundField HeaderStyle-Width="300px" HeaderText="Library Address" DataField="LibraryAddress" Visible="false" />
                                    <asp:BoundField HeaderStyle-Width="70px" HeaderText="Com" DataField="Com" />
                                    <asp:BoundField HeaderStyle-Width="70px" HeaderText="TransportID" DataField="TransportID" />
                                    <asp:BoundField HeaderStyle-Width="300px" HeaderText="Transport Name" DataField="TransportName" />
                                    <asp:BoundField HeaderStyle-Width="120px" HeaderText="RR No" DataField="RRNo" />
                                    <asp:BoundField HeaderStyle-Width="70px" HeaderText="Is Complete" DataField="IsComplete" />
                                    <asp:BoundField HeaderStyle-Width="70px" HeaderText="Packet Qty" DataField="PacketQty" />
                                    <asp:BoundField HeaderStyle-Width="70px" HeaderText="Others Van" DataField="Van" />
                                    <asp:BoundField HeaderStyle-Width="70px" HeaderText="Own Van" DataField="VanOwn" />
                                    <asp:BoundField HeaderStyle-Width="70px" HeaderText="Labour Load" DataField="LabourLoad" />
                                    <asp:BoundField HeaderStyle-Width="70px" HeaderText="Labour Unload" DataField="LabourUnload" />
                                    <asp:BoundField HeaderStyle-Width="70px" HeaderText="Others Transport" DataField="Transport" />
                                    <asp:BoundField HeaderStyle-Width="70px" HeaderText="Own Transport" DataField="TransportOwn" />
                                    <asp:BoundField HeaderStyle-Width="70px" HeaderText="Choat" DataField="Choat" />
                                    <asp:BoundField HeaderStyle-Width="70px" HeaderText="Polythin" DataField="Polithin" />
                                    <asp:BoundField HeaderStyle-Width="70px" HeaderText="Selai In" DataField="SelaiIn" />
                                    <asp:BoundField HeaderStyle-Width="70px" HeaderText="Selai Out" DataField="SelaiOut" />
                                    <asp:BoundField HeaderStyle-Width="100px" HeaderText="Per Pkt Cost" DataField="PerPacketCost" />
                                    <asp:BoundField HeaderStyle-Width="120px" HeaderText="Total Pkt Cost" DataField="TotalPacketCost" />
                                    <asp:BoundField HeaderStyle-Width="120px" HeaderText="Delivery Date" DataField="DeliveryDate" />
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("Serial") %>' OnClick="lbDelete_Click">
                                                Delete
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-8 pull-right">
                                <div class="form-group">
                                    <label class="control-label col-md-4">Packet No</label>
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" ID="txtPacketNo" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-4">Amount Receivable</label>
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" ID="txtAmountReceivable" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-4 col-md-offset-4">
                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click" />                          
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
    <script>
        $(document).ready(function () {
            open_menu("Packet Booking");
        });
    </script>
    <script type="text/javascript">
        function sumPacketCost() {
            var PackQty = document.getElementById('<%=txtPacDelivry.ClientID%>').value;
            var van = document.getElementById('<%=txtVan.ClientID%>').value;
            var vanOwn = document.getElementById('<%=txtVanOwn.ClientID%>').value;
            var labourLoad = document.getElementById('<%=txtLabourLoad.ClientID%>').value;
            var labourUnload = document.getElementById('<%=txtLabourUnload.ClientID%>').value;
            var transport = document.getElementById('<%=txtTransport.ClientID%>').value;
            var transportOwn = document.getElementById('<%=textTransportOwn.ClientID%>').value;
            var Choat = document.getElementById('<%=txtChoat.ClientID%>').value;
            var Poly = document.getElementById('<%=txtPolythin.ClientID%>').value;
            var SelaiIn = document.getElementById('<%=txtSelaiIn.ClientID%>').value;
            var Selaiout = document.getElementById('<%=txtSelaiOut.ClientID%>').value;          
            var PerPacCost = (parseFloat(van) || 0.00) + (parseFloat(vanOwn) || 0.00) + (parseFloat(labourLoad) || 0.00) + (parseFloat(labourUnload) || 0.00) + (parseFloat(transport) || 0.00) + (parseFloat(transportOwn) || 0.00) + (parseFloat(Choat) || 0.00) + (parseFloat(Poly) || 0.00) + (parseFloat(SelaiIn) || 0.00) + (parseFloat(Selaiout) || 0.00);
            document.getElementById('<%=txtBookingPerPacCost.ClientID%>').value = PerPacCost;
              var TotalPacCost = (parseFloat(PerPacCost) || 0) * (parseFloat(PackQty) || 0);

              document.getElementById('<%=txtBookingTotalpackCost.ClientID%>').value = TotalPacCost;
          }

    </script>
</asp:Content>
