<%@ Page Title="Plate Supply" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_PlateSupply.aspx.cs" Inherits="BLL.Pro_PlateSupply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="form-horizontal clearfix" runat="server">
                <div class="panel-body" style="border: 1px solid #BDC3CA">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Plate Supply
                        </div>
                        <%--<div id="frmPlateSupply" runat="server" class="form-horizontal clearfix">--%>
                        <div class="panel-body">
                            <div class="col-md-12 no-padding clearfix">
                                <div class="col-md-6 clearfix">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtOrderNo" CssClass="col-xs-4 control-label no-padding-right" Text="Order No"></asp:Label>
                                        <div class="col-xs-4">
                                            <asp:TextBox ID="txtOrderNo" runat="server" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtOrderNo_TextChanged">
                                            </asp:TextBox>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ID="ddlPlateFor" runat="server" CssClass="form-control" disabled="Enable">
                                                <asp:ListItem Value="C">Cover</asp:ListItem>
                                                <asp:ListItem Value="F">Forma</asp:ListItem>
                                                <asp:ListItem Value="A">Administrative</asp:ListItem>
                                                <asp:ListItem Value="P">Promotional</asp:ListItem>
                                                <asp:ListItem Value="Z">Zinix</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="dtpOrderDate" CssClass="col-xs-4 control-label no-padding-right" Text="Print Order Date"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="dtpOrderDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd">
                                            </asp:TextBox>
                                            <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="dtpOrderDate" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtDate" CssClass="col-xs-4 control-label no-padding-right" Text="Date"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd">
                                            </asp:TextBox>
                                            <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate" />
                                        </div>
                                    </div>
                                    <br />
                                    <div class="form-group">
                                        <div class="col-xs-8 col-xs-offset-4">
                                            <asp:Label runat="server" AssociatedControlID="chkExtra" CssClass="control-label" Text="Extra Plate Supply"></asp:Label>
                                            <asp:CheckBox CssClass="checkbox col-xs-1" runat="server" ID="chkExtra" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtGroup" CssClass="col-xs-4 control-label no-padding-right" Text="Group"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtGroup" runat="server" CssClass="form-control" disabled="" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtClassName" CssClass="col-xs-4 control-label no-padding-right" Text="Class"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtClassName" runat="server" CssClass="form-control" disabled="" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtTypeName" CssClass="col-xs-4 control-label no-padding-right" Text="Type"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtTypeName" runat="server" CssClass="form-control" disabled="" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlBookName" CssClass="col-sm-4 control-label no-padding-right" Text="Book Name"></asp:Label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="ddlBookName" runat="server" CssClass="form-control" disabled="">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlEdition" CssClass="col-xs-4 control-label no-padding-right" Text="Edition"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="ddlEdition" runat="server" CssClass="form-control" disabled="" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <%--table grid view--%>
                            <div class="col-md-12 table-responsive clearfix" style="overflow-x:auto">
                                <asp:GridView ID="gvwPlateSup" runat="server" CssClass="grid-view table" AutoGenerateColumns="False" OnRowDataBound="gvwPlateSup_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect" runat="server"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="DateField" HeaderText="Select"/>--%>
                                        <asp:BoundField DataField="PressID" HeaderText="PressID" />
                                        <asp:BoundField DataField="PressName" HeaderText="Press" />
                                        <asp:BoundField DataField="BookPart" HeaderText="Part" />
                                        <asp:BoundField DataField="ColorNo" HeaderText="Color No" />
                                        <asp:BoundField DataField="FormaQty" HeaderText="Forma Qty" />
                                        <asp:BoundField DataField="PrintQty" HeaderText="Print Qty" />

                                        <asp:TemplateField HeaderText="Plate Type">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlPlateTypeo" runat="server"></asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="PlateSize">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlPlatesize" runat="server"></asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="PlateQty">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtPlateQty" data-field="pl-qty" CssClass="click pl-qty" runat="server" Width="70px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="PlateGivenType">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlPlateGivenType" runat="server">
                                                    <asp:ListItem Value=""></asp:ListItem>
                                                    <asp:ListItem Value="1">Press</asp:ListItem>
                                                    <asp:ListItem Value="2">Al Fatah</asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Plate Rate">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtPlateRate" data-field="pl-rate" CssClass="click pl-rate" runat="server" Width="70px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Process Type">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlProcessType" runat="server">
                                                    <asp:ListItem Value=""></asp:ListItem>
                                                    <asp:ListItem Value="1">Press</asp:ListItem>
                                                    <asp:ListItem Value="2">Al Fatah</asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Process Rate">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtProcessRate" runat="server" data-field="pro-rate" CssClass="click pro-rate" Width="70px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Total">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtGridViewTotall" CssClass="row-total" runat="server" Width="70px" ReadOnly="true" Text="0.00"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="col-md-12 clearfix no-padding">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtPlateSupRemark" CssClass="col-xs-4 control-label no-padding-right" Text="Remarks"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtPlateSupRemark" runat="server" CssClass="form-control" TextMode="MultiLine" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtTotalPlateQty" CssClass="col-xs-4 control-label no-padding-right" Text="Total Plate Qty"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtTotalPlateQty" runat="server" CssClass="form-control" data-tot="tot-plq"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtTotalPlateBill" CssClass="col-xs-4 control-label no-padding-right" Text="Total Plate Bill"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtTotalPlateBill" runat="server" CssClass="form-control" data-tot="tot-plb" ReadOnly="True"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtTotalProcessBill" CssClass="col-xs-4 control-label no-padding-right" Text="Total Process Bill"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtTotalProcessBill" runat="server" CssClass="form-control" data-tot="tot-prob" ReadOnly="True"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtTotalBill" CssClass="col-xs-4 control-label no-padding-right" Text="Total Amount"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtTotalBill" runat="server" CssClass="form-control" data-tot="tot-amount" ReadOnly="True"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-xs-8 col-xs-offset-4">
                                            <asp:Button ID="btnPlateSupSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnPlateSupSave_Click" />
                                            <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-info" runat="server" OnClick="btnPrint_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSPro" runat="server">

    <script type="text/javascript">
       
        $(document).ready(function () {
            $(".click").on("keyup", function () {
                tr = $(this).closest('tr');
                plrate = tr.find('input[data-field=pl-rate]').val();
                plqty = tr.find('input[data-field=pl-qty]').val();
                prorate = tr.find('input[data-field=pro-rate]').val();
                tot = tr.find('input.row-total');
                tot.val(((plqty * plrate) + (plqty * prorate)).toFixed(2));

                var totsum = 0, totplq = 0, totplb = 0, totprob = 0;
                $('input.row-total').each(function () {
                    totsum += parseFloat(this.value);
                });
                $('input[data-field=pl-qty]').each(function () {
                    totplq += parseFloat((this.value == '') ? '0' : this.value);
                    v = $(this).closest('tr').find('input[data-field=pl-rate]').val();
                    totplb += parseFloat((this.value=='') ? '0' : this.value) * parseFloat(v==''?'0':v);
                });
                $('input[data-field=pro-rate]').each(function () {
                    v = $(this).closest('tr').find('input[data-field=pl-qty]').val();
                    totprob += parseFloat((this.value == '') ? '0' : this.value) * parseFloat(v==''?'0':v);
                });

                $('input[data-tot=tot-plq]').val(totplq.toFixed(2));
                $('input[data-tot=tot-plb]').val(totplb.toFixed(2));
                $('input[data-tot=tot-prob]').val(totprob.toFixed(2));
                $('input[data-tot=tot-amount]').val(totsum.toFixed(2));
            });

        });
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Plate");
        });
    </script>
</asp:Content>
