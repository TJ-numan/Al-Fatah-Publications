<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_SpecimanReturnAdjustment.aspx.cs" Inherits="BLL.Mkt_SpecimanReturnAdjustment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div id="frmChallanNew" runat="server" class="form-horizontal clearfix">
        <div class="col-md-12 clearfix no-padding">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h4>Adjustment Speciman Challan</h4>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6 clearfix">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtMemoNo" CssClass="col-md-4 control-label no-padding-right" Text="Memo No"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="txtMemoNo" CssClass="form-control" TabIndex="100" AutoPostBack="True" OnTextChanged="txtChlNewMemoNo_TextChanged" />

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
                                <asp:Label runat="server" AssociatedControlID="ddlTSOName" CssClass="col-md-4 control-label no-padding-right" Text="TSO Name"></asp:Label>
                                <div class="col-md-8">
                                    <asp:DropDownList runat="server" ID="ddlTSOName" CssClass="form-control" TabIndex="1">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <hr style="border: 1px solid silver" />
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtSlipNo" CssClass="col-md-4 control-label no-padding-right" Text="Slip No"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="txtSlipNo" CssClass="form-control" placeholder="Slip No" />
                                </div>
                            </div>
                           <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtSlipDate" CssClass="col-md-4 control-label no-padding-right" Text="Slip Date"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="txtSlipDate" CssClass="form-control" placeholder="yyyy-mm-dd" AutoPostBack="false" TabIndex="0" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtSlipDate" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label CssClass="col-md-4 control-label no-padding-right" AssociatedControlID="chkIsDonation" Text="Donation" runat="server"></asp:Label>
                                <div class="col-md-8">
                                    <asp:CheckBox ID="chkIsDonation" CssClass="checkbox pull-left" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr style="border: 1px solid silver" />
                    
                        <div class="clearfix table-responsive">
                            <asp:GridView ID="gvwChlNew" runat="server" AutoGenerateColumns="False" CssClass="table">
                                <Columns>
                                    <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" DataField="Serial" />
                                    <%--<asp:BoundField HeaderStyle-Width="100px" HeaderText="Book AC Code" DataField="BookAcCode" />--%>
                                    <asp:BoundField HeaderStyle-Width="100px" HeaderText="Book Code" DataField="BookID"/>
                                    <asp:BoundField HeaderStyle-Width="200px" HeaderText="Book Name" DataField="BookName" />
                                    <asp:BoundField HeaderStyle-Width="100px" HeaderText="Class" DataField="Class" />
                                    <asp:BoundField HeaderStyle-Width="100px" HeaderText="Type" DataField="Type" />
                                    <asp:BoundField HeaderStyle-Width="100px" HeaderText="Edition" DataField="Edition" />
                                    <%--<asp:BoundField HeaderStyle-Width="100px" HeaderText="UnitPrice" DataField="UnitPrice" />--%>
                                    <asp:TemplateField HeaderText="UnitPrice" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                              <asp:TextBox ID="UnitPrice" runat="server" Text='<%# Eval("UnitPrice")%>' CssClass="form-control calc"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField> 

                                    <asp:TemplateField HeaderText="Qty" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                              <asp:TextBox ID="Qty" runat="server" Text='<%# Eval("Qty")%>' CssClass="form-control qcal"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <%--<asp:BoundField HeaderStyle-Width="100px" HeaderText="Qty" DataField="Qty" />--%>
                                    <%--<asp:BoundField HeaderStyle-Width="120px" HeaderText="Amount" DataField="Total"/>--%>
                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                              <asp:TextBox ID="Total" runat="server" Text='<%# Eval("Total")%>' CssClass="form-control calc-total"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                   <asp:TemplateField HeaderText="Action">
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
                                            <asp:TextBox runat="server" ID="txtTotalAmount" CssClass="form-control tot-amount" Text="0" ReadOnly="true" />
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="form-group">
                                <div class="col-md-8 col-md-offset-4">                                   
                                    <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-success" Text="Save Adjustment"   OnClientClick="if (!confirm('Do You Want to Save Adjustment?')) return false;" OnClick="btnCancel_Click"/>
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
<%--      <script type="text/javascript">
          $(document).ready(function () {

              calculateMul(".calc", ".calc-total");

              $(".calc").on("keyup", function () {
                  calculateMul(".calc", ".calc-total");
              });


              open_menu("Speciman");
          });

          //more field summation with textchange
          function calculateMul(field, total) {
              var mul = 1;

              $(field).each(function () {
                  //add only if the value is number
                  if (!isNaN(this.value) && this.value.length != 0) {
                      mul *= parseFloat(this.value);
                  }
              });
              $(total).val(mul.toFixed(0));

          }
    </script>--%>


          <script type="text/javascript">
              $(document).ready(function () {

                  calculateMul(".calc", ".qcal", ".calc-total");

                  $(".calc").on("keyup", function () {
                      calculateMul(".calc", ".qcal", ".calc-total");
                  });

                  $(".qcal").on("keyup", function () {
                      calculateMul(".calc", ".qcal", ".calc-total");
                  });

                  open_menu("Speciman");
              });


   
              //more field summation with textchange
              function calculateMul(calc, qcal, total) {
                  var calc ;
                  var qcal ;
                  var mul = 1;
                  $(calc).each(function () {
                      if (!isNaN(this.value) && this.value.length != 0) {
                          calc = parseFloat(this.value);
                      }
                      
                  });
                  $(qcal).each(function () {
                      if (!isNaN(this.value) && this.value.length != 0) {
                          qcal = parseFloat(this.value);
                      }
                      
                  });
                 
                  mul = calc * qcal;
                  //$(total).val(mul);
              }
        </script>
        <script type="text/javascript">
            $(document).ready(function () {

                calculateTot(".calc-total", ".tot-amount");

                $(".calc-total").on("keyup", function () {
                    calculateTot(".calc-total", ".tot-amount");
                });


                open_menu("Speciman");
            });

            //more field summation with textchange
            function calculateTot(field, total) {
                var sum = 0;

                $(field).each(function () {
                    //add only if the value is number
                    if (!isNaN(this.value) && this.value.length != 0) {
                        sum += parseFloat(this.value);
                    }
                });
                $(total).val(sum.toFixed(0));

            }
    </script>
    <script>
            $(document).ready(function () {
                open_menu("Speciman");
            });
    </script>
</asp:Content>
