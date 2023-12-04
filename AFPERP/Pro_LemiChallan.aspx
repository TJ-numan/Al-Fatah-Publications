<%@ Page Title="" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_LemiChallan.aspx.cs" Inherits="BLL.Pro_LemiChallan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Lamination Challan
                </div>
           

                <div class="panel-body">

                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpOrderDate" CssClass="col-md-4 control-label" Text="Date" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="dtpOrderDate" placeholder="yyyy-MM-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="dtpOrderDate" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlPartyName" CssClass="col-md-4 control-label" Text="Party Name" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control" ID="ddlPartyName" runat="server">
                            </asp:DropDownList>

                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtAddress" CssClass="col-md-4 control-label" Text="Address" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtAddress" placeholder="Address" runat="server" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtMemoNo" CssClass="col-md-4 control-label" Text="Memo No" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtMemoNo" placeholder="Memo No" runat="server" />
                        </div>
                    </div>
                    <div class="table-responsive col-md-8 col-md-offset-2 no-padding">
                        <table class="table no-head-padding">
                            <tr>
                                <td>
                                    <asp:Label ID="lblPaperType" runat="server" Text="Type"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaperSize" runat="server" Text="Size"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaperGSM" runat="server" Text="GSM"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaperBrand" runat="server" Text="Brand"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaperOrigin" runat="server" Text="Origin"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlPaperType" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlPaperType_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPaperSize" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlPaperSize_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td>
                                   
                                      <asp:DropDownList ID="ddlPaperGSM" runat="server" CssClass="form-control" AutoPostBack ="true" OnSelectedIndexChanged ="ddlPaperGSM_SelectedIndexChanged"></asp:DropDownList>
                                      <asp:DropDownList ID ="ddlPaperReceipt" runat ="server" Visible ="false" ></asp:DropDownList>
                                    
                                 </td>
                                <td>
                                    <asp:DropDownList ID="ddlPaperBrand" runat="server" CssClass="form-control"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPaperOrigin" runat="server" CssClass="form-control"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>



                    <div>
                        <div class="table-responsive col-md-6 col-md-offset-3 no-padding">
                            <table class="table no-head-padding">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblRollNo" runat="server" Text="Roll No"></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblQty" runat="server" Text="Qty" ></asp:Label>
                                    </td>

                                    <td>
                                          <asp:Label ID="lblMeasureUnit" runat="server" Text="Measure"></asp:Label>
                                    </td>

                                    <td>
                                          <asp:Label ID="lblConSqInch" runat="server" Text="Convert Qty"></asp:Label>
                                    </td>

                                    <td>
                                          <asp:Label ID="lblCMeasureUnit" runat="server" Text="C Measure"></asp:Label>
                                    </td>

                                    <td>
                                          <asp:Label ID="lblRate" runat="server" Text="Rate"></asp:Label>
                                    </td>
                                    <td>
 
                                    </td>

                                </tr>
                                <tr>
                                    <td>
                                         <asp:DropDownList ID="ddlRollNo" runat="server" CssClass="form-control" OnSelectedIndexChanged ="ddlRollNo_SelectedIndexChanged" AutoPostBack="true"  ></asp:DropDownList>
                                    </td>
 
                                    <td>
                                        <asp:TextBox ID="txtQty" runat="server" CssClass="form-control" Enabled="false" />
                                        
                                    </td>

                                    <td>
                                        <asp:TextBox ID="txtMeasure" runat="server" CssClass="form-control" Text="Kg" Enabled="false" />
                                        
                                    </td>

                                    <td>
                                        <asp:TextBox ID="txtCQty" runat="server" CssClass="form-control" Text="" Enabled="false" />                                        
                                    </td>

                                    <td>
                                        <asp:TextBox ID="txtCMeasureUnit" runat="server" CssClass="form-control" Text="Sq Inch"  Enabled="false" />                                        
                                    </td>

                                    <td>
                                        <asp:TextBox ID="txtRate" runat="server" CssClass="form-control" Text="0.0085" Enabled="false" />                                        
                                    </td>

                                    <td>
                                        <asp:Button ID="btnPaperAdd" runat="server" CssClass="btn btn-xs btn-primary" Text="Add" OnClick ="btnPaperAdd_Click" ></asp:Button>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>



                    <%--grid view--%>
                    <div class="table-responsive">
                        <asp:GridView ID="gvwPaperAddedData" CssClass="grid-view table" runat="server" Align="center" AutoGenerateColumns="false">
                             <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                            <Columns>
                                <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" DataField="Serial" />
                                <asp:BoundField DataField="RollNo" HeaderText="RollNo"/> 
                                <asp:BoundField DataField="Qty" HeaderText="Qty"/>
                                <asp:BoundField DataField="Measure" HeaderText="Measure"/> 
                                <asp:BoundField DataField="CQty" HeaderText="CQty"/>
                                <asp:BoundField DataField="CMeasure" HeaderText="C Measure"/>
                                <asp:BoundField DataField="UnitPrice" HeaderText="Price"/>
                                <asp:BoundField DataField="Total" HeaderText="Total"/>                                
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



 
 
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtTotalAmount" CssClass="col-md-4 control-label" Text="Total" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtTotalAmount" placeholder="0" runat="server" />
                        </div>
                    </div>


                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtRemark" CssClass="col-md-4 control-label" Text="Remarks" runat="server"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox CssClass="form-control" ID="txtRemark" placeholder="Remarks" runat="server" TextMode="MultiLine" />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">
                            <asp:Button ID="btnPaperSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnPaperSave_Click" />
                            &nbsp;   &nbsp;   &nbsp;
                             <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-info" runat="server" OnClick="btnPrint_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSPro" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Lamination");
        });
    </script>
</asp:Content>
