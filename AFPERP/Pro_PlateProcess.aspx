<%@ Page Title="Plate Process" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_PlateProcess.aspx.cs" Inherits="BLL.Pro_PlateProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Plate Process
                </div>
                <%-- <div id="frmPlateProcess" runat="server" class="form-horizontal clearfix">--%>
                <div class="panel-body">
                    <div class="col-md-12 no-padding clearfix">
                        <div class="col-md-6 clearfix">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtOrderDate" CssClass="col-xs-4 control-label no-padding-right" Text="Order Date"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtOrderDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtOrderDate" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-8 col-xs-offset-4">
                                    <%-- <label runat="server" for="chkPlateProPFStore" class="control-label">Process From Store</label>--%>
                                    <asp:Label runat="server" AssociatedControlID="chkPlateProPFStore" class="control-label chkStore" Text="Process From Store"></asp:Label>
                                    <span class="checkbox col-xs-1">
                                        <%--<input type="checkbox" id="chkPlateProPFStore" name="chkPlateProPFStore" />--%>
                                        <asp:CheckBox runat="server" ID="chkPlateProPFStore" CssClass="chkStore" />
                                    </span>
                                </div>
                                <input type="hidden" id="_ispostback" value="<%=Page.IsPostBack.ToString()%>" />
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtFromDate" CssClass="col-xs-4 control-label no-padding-right" Text="From"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtToDate" CssClass="col-xs-4 control-label no-padding-right" Text="To"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate" />
                                </div>
                            </div>
                            <div class="process-div hidden" style="display:none">
                                <%--hidden--%>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtSelectedRowNo" CssClass="col-xs-8 control-label no-padding-right" Text="Currently Selected Row Number"></asp:Label>
                                    <div class="col-xs-4">
                                        <asp:TextBox ID="txtSelectedRowNo" runat="server" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="table-responsive">
                                    <asp:GridView ID="gvwGodownPlate" runat="server" CssClass="grid-view table" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField DataField="DateField" HeaderText="Select"/>
                                            <asp:BoundField DataField="DateField" HeaderText="Plate Type"/>
                                            <asp:BoundField DataField="DateField" HeaderText="Plate Size"/>
                                            <asp:BoundField DataField="DateField" HeaderText="Qty"/>
                                            <asp:BoundField DataField="DateField" HeaderText="Used Qty"/>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlPlateParty" CssClass="col-xs-4 control-label no-padding-right" Text="Party Name"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlPlateParty" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlPlateParty_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 clearfix" style="display:none">
                            <div class="process-div hidden">
                                <%--hidden--%>
                                <asp:UpdatePanel ID="Updatepanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="ddlCategory" CssClass="col-xs-4 control-label no-padding-right" Text="Category"></asp:Label>
                                            <div class="col-xs-8">
                                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="ddlGroup" CssClass="col-xs-4 control-label no-padding-right" Text="Group"></asp:Label>
                                            <div class="col-xs-8">
                                                <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="ddlClass" CssClass="col-xs-4 control-label no-padding-right" Text="Class"></asp:Label>
                                            <div class="col-xs-8">
                                                <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="ddlType" CssClass="col-xs-4 control-label no-padding-right" Text="Type"></asp:Label>
                                            <div class="col-xs-8">
                                                <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="ddlBookName" CssClass="col-sm-4 control-label no-padding-right" Text="Book Name"></asp:Label>
                                            <div class="col-sm-8">
                                                <asp:DropDownList ID="ddlBookName" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlBookName_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="ddlEdition" CssClass="col-xs-4 control-label no-padding-right" Text="Edition"></asp:Label>
                                            <div class="col-xs-8">
                                                <asp:DropDownList ID="ddlEdition" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="ddlPlateFor" CssClass="col-xs-4 control-label no-padding-right" Text="Plate For"></asp:Label>
                                            <div class="col-xs-8">
                                                <asp:DropDownList ID="ddlPlateFor" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="0">Cover</asp:ListItem>
                                                    <asp:ListItem Value="1">Inner</asp:ListItem>
                                                    <asp:ListItem Value="2">2 No Forma</asp:ListItem>
                                                    <asp:ListItem Value="3">Main Forma</asp:ListItem>
                                                    <asp:ListItem Value="4">Postani</asp:ListItem>
                                                    <asp:ListItem Value="5">Promotional</asp:ListItem>
                                                    <asp:ListItem Value="6">Administrative</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="ddlPlateQty" CssClass="col-xs-4 control-label no-padding-right" Text="Plate Qty"></asp:Label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="ddlPlateQty" runat="server" CssClass="form-control" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-xs-8 col-xs-offset-4">
                                                <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-primary btn-xs" Text="Add" />
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <%--table grid--%>
                    <div class="col-md-12 table-responsive clearfix">
                        <asp:GridView ID="gvwPlateProMain" runat="server" CssClass="grid-view table" AutoGenerateColumns="false" OnRowDataBound="gvwPlateProMain_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="BookAcCode" HeaderText="BookCode"/>
                                <asp:BoundField DataField="Sl" HeaderText="Sl"/>
                                <asp:BoundField DataField="BookName" HeaderText="Book" />
                                <asp:BoundField DataField="ClassName" HeaderText="Class" />
                                <asp:BoundField DataField="TypeName" HeaderText="Type" />
                                <asp:BoundField DataField="Edition" HeaderText="Edition" />
                                <asp:BoundField DataField="bookpart" HeaderText="Plate For" />
                                <asp:BoundField DataField="PlateType" HeaderText="Plate Type" />
                                <asp:BoundField DataField="Size" HeaderText="Plate Size" />
                                <asp:BoundField DataField="Qty" HeaderText="Plate Qty" />
                                <asp:TemplateField HeaderText="Process Press">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlProcess_Press" runat="server"></asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="col-md-12 no-padding clearfix">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtOrderNo" CssClass="col-xs-4 control-label no-padding-right" Text="Order No"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtOrderNo" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtTotalPlateQty" CssClass="col-xs-4 control-label no-padding-right" Text="Plate Qty"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtTotalPlateQty" runat="server" CssClass="form-control calc" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtProcessRate" CssClass="col-xs-4 control-label no-padding-right" Text="Rate"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtProcessRate" runat="server" CssClass="form-control calc" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtTotalBill" CssClass="col-xs-4 control-label no-padding-right" Text="Total Amount"></asp:Label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtTotalBill" runat="server" CssClass="form-control calc-total" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-8 col-xs-offset-4">
                                    <asp:Button ID="btnPlateProSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnPlateProSave_Click" />
                                    <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-primary" runat="server" OnClick="btnPrint_Click" />
                                </div>
                            </div>
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
            open_menu("Plate");

            //hide & seek
            $('span.chkStore input').change(function () {
                if (this.checked) $('.process-div').removeClass('hidden');
                else $('.process-div').addClass('hidden');
            });
            //else $('.process-div').addClass('hidden');
        });

        $(document).ready(function () {
            if (document.getElementById('_ispostback').value == 'True') $('.process-div').removeClass('hidden');
            else $('.process-div').addClass('hidden');
        });

        $(document).ready(function () {

            calculateSum(".calc", ".calc-total");


            $(".calc").on("keyup", function () {
                calculateSum(".calc", ".calc-total");
            });
        });

        function calculateSum(field, total) {
            var multi = 1;

            $(field).each(function () {
                //add only if the value is number
                if (!isNaN(this.value) && this.value.length != 0) {
                    multi *= parseFloat(this.value);
                }
                else multi = 0;

            });
            $(total).val(multi);

        }
    </script>
</asp:Content>
