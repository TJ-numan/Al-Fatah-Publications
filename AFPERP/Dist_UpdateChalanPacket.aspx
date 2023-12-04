<%@ Page Title="" Language="C#" MasterPageFile="~/Distribution.master" AutoEventWireup="true" CodeBehind="Dist_UpdateChalanPacket.aspx.cs" Inherits="BLL.Dist_UpdateChalanPacket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DistributionContent" runat="server">
     <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-9">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Update Challan Packet
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlCom" CssClass="col-md-4 control-label no-padding-left" Text=" Select Company"></asp:Label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlCom" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="A" Text="Alia"></asp:ListItem>
                                        <asp:ListItem Value="Q" Text="Qawmi"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtMemoNo" Text="Memo No" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-5">
                                    <asp:TextBox CssClass="form-control" ID="txtMemoNo" runat="server" OnTextChanged="txtMemoNo_OnSelectedTextChanged" AutoPostBack="True" />
                                </div>

                                <div class="col-md-3">
                                    <asp:Button runat="server" ID="btnEnter" Text="Enter" CssClass="btn btn-danger btnBookCodeEnter" OnClick="txtMemoNo_OnSelectedTextChanged"></asp:Button>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtMemoDate" CssClass="col-md-4 control-label no-padding-right" Text=" Memo Date"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtMemoDate" runat="server" CssClass="form-control" placeholder="yyyy-MM-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtMemoDate" />
                                </div>
                            </div>


                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>                        
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlLibraryName" CssClass="col-md-4 control-label no-padding-right" Text="Library Name"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="ddlLibraryName" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <hr />
                            <hr />
                            <div class="form-group">
                                <asp:Label AssociatedControlID="TotalAmount" Text="Sub Total" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control totAmout" ID="TotalAmount" runat="server" readonly="true"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="PacketNo" Text="Packet No" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control calc" ID="PacketNo" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="PerPacketCost" Text="Per Packet Cost" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control calc" ID="PerPacketCost" runat="server" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label AssociatedControlID="ReceivableAmount" Text="Amount Receivable" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">
                                      <asp:TextBox CssClass="form-control calc-total" ID="ReceivableAmount" runat="server"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-4">
                                    <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnUpdate_OnClick" OnClientClick="if (!confirm('Do You Want to Update?')) return false;"/>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSDistribution" runat="server">
    <script type="text/javascript">
            $(document).ready(function () {
                open_menu("Chalan");
            });
    </script>
      <script type="text/javascript">
          $(document).ready(function () {

              calculateSum(".calc", ".totAmout", ".calc-total");

              $(".calc").on("keyup", function () {
                  calculateSum(".calc", ".totAmout", ".calc-total");
              });

          });

          function calculateSum(field, totalSub, total) {
              var multi = 1;
              var TotAmount = 0;
              $(field).each(function () {
                  //add only if the value is number
                  if (!isNaN(this.value) && this.value.length != 0) {
                      multi *= parseFloat(this.value);
                  }
                  else multi = 0;

              });
             // $(total).val(multi);

              $(totalSub).each(function () {
                  
                  if (!isNaN(this.value) && this.value.length != 0) {
                      TotAmount += parseFloat(this.value);
                  }
              });
              var totalAmount = TotAmount + multi;
              $(total).val(totalAmount);


          }

      </script>
</asp:Content>
