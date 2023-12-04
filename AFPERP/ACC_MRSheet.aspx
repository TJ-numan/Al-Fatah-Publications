<%@ Page Title="" Language="C#" MasterPageFile="~/AccountingMaster.master" AutoEventWireup="true" CodeBehind="ACC_MRSheet.aspx.cs" Inherits="BLL.ACC_MRSheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">

            <div class="panel panel-primary">
                <div class="panel-heading">
                    MR Sheet
                </div>
            </div>


            <div class="clearfix table-responsive">
                <table class=" table-responsive table no-head-padding ">
                    <tr>
                        <td>
                            <asp:Label runat="server" AssociatedControlID="dtpDepositDate" CssClass="control-label" Text="DepositDate"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" AssociatedControlID="ddlDepositType" CssClass="control-label" Text="Deposit Type"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" AssociatedControlID="txtDDTTRDNo" CssClass="control-label" Text="RD/TT/DD "></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" AssociatedControlID="ddlBank" CssClass="control-label" Text="Bank Name"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" AssociatedControlID="txtBankBranch" CssClass="control-label" Text="Branch"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" AssociatedControlID="txtAmount" CssClass="control-label" Text="Amount"></asp:Label>
                        </td>

                        <td>
                            <asp:Label runat="server" AssociatedControlID="txtAccNo" CssClass="control-label" Text="Acc No"></asp:Label>
                        </td>

                        <td>
                            <asp:Label runat="server" AssociatedControlID="txtRemarkInv" CssClass="control-label" Text="Remark"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:125px">
                            <asp:TextBox runat="server" ID="dtpDepositDate" CssClass="form-control" placeholder="yyyy-MM-dd" />
                            <ajaxToolkit:CalendarExtender ID="Calender1" runat="server" TargetControlID="dtpDepositDate" Format="yyyy-MM-dd" />
                        </td>

                        <td style="width: 125px">
                            <asp:DropDownList runat="server" ID="ddlDepositType" CssClass="form-control"></asp:DropDownList>
                        </td>

                        <td style="width: 125px">
                            <asp:TextBox runat="server" ID="txtDDTTRDNo" CssClass="form-control" />
                        </td>

                        <td style="width: 125px">
                            <asp:DropDownList runat="server" ID="ddlBank" CssClass="form-control"></asp:DropDownList>
                        </td>
                        <td style="width: 100px">
                            <asp:TextBox runat="server" ID="txtBankBranch" CssClass="form-control" />
                        </td>
                        <td style="width: 100px">
                            <asp:TextBox runat="server" ID="txtAmount" CssClass="form-control" />
                        </td>

                        <td style="width: 100px">
                            <asp:TextBox runat="server" ID="txtAccNo" CssClass="form-control" />
                        </td>

                        <td style="width: 100px">
                            <asp:TextBox runat="server" ID="txtRemarkInv" CssClass="form-control" />
                        </td>

                        <td>
                            <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-primary" Text="Add" OnClick="btnAdd_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="col-md-12  no-padding ">
                <div class="clearfix table-responsive">
                    <asp:GridView ID="gvMRSheet" runat="server" AutoGenerateColumns="False" CssClass="table">
                        <Columns> 
                            <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" DataField="Serial" />
                            <asp:BoundField HeaderStyle-Width="300px" HeaderText="DepositDate" DataField="DepositDate"  DataFormatString="{0:yyyy-MM-dd}"  />
                            <asp:BoundField HeaderStyle-Width="100px" HeaderText="DepositType" DataField="DepositType" />
                            <asp:BoundField HeaderStyle-Width="100px" HeaderText="DDTTRDNo" DataField="DDTTRDNo" />
                            <asp:BoundField HeaderStyle-Width="90px" HeaderText=" BankCode " DataField="BankCode" />
                            <asp:BoundField HeaderStyle-Width="100px" HeaderText="BankBranch" DataField="BankBranch" />
                            <asp:BoundField HeaderStyle-Width="100px" HeaderText="Amount" DataField="Amount" />
                            <asp:BoundField HeaderStyle-Width="100px" HeaderText="AccNo" DataField="AccNo" />
                            <asp:BoundField HeaderStyle-Width="100px" HeaderText="Remark" DataField="Remark" />
                            <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="60px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblDelete" runat="server" CommandArgument='<%#Eval("Serial") %>' OnClick="lblDelete_OnClick">
                                                 Delete
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <hr style="border: 1px solid silver" />
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-md-6">
                    </div>
                    <div class="col-md-6">

                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtTotalAmount" Text="Total Amount" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox CssClass="form-control" ID="txtTotalAmount" runat="server" ReadOnly="True" />
                            </div>
                        </div>


                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtSheetNo" Text="SheetNo" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox CssClass="form-control" ID="txtSheetNo" runat="server"  Enabled="false" />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtRemarks" Text="Narration" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox CssClass="form-control" ID="txtRemarks" runat="server"    />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlRegion" Text="Region For" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                            <div class="col-md-8">
                                <asp:DropDownList runat="server" ID="ddlRegion" CssClass="form-control">
                                       <asp:ListItem Value="0" Text="Select Region"></asp:ListItem>
                                       <asp:ListItem Value="1" Text="A"></asp:ListItem>
                                       <asp:ListItem Value="2" Text="B"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-6 col-md-offset-4">                              

                                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click"/> 
                                &nbsp;&nbsp;&nbsp;
                                 <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-danger" runat="server" OnClick ="btnPrint_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSAcc" runat="server">
           <script type="text/javascript">
               $(document).ready(function () {
                   open_menu("Collection", "Deposit");
               });
    </script>
</asp:Content>
