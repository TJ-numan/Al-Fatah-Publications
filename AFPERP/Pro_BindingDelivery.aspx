<%@ Page Title="Binding Delivery" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_BindingDelivery.aspx.cs" Inherits="BLL.Pro_BindingDelivery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="form-horizontal clearfix" runat="server">
                <div class="panel-body" style="border: 1px solid #BDC3CA">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                          Book Binding Order
                        </div>

                        <%--<div id="frmPlatePurchaseBill" runat="server" class="form-horizontal clearfix">--%>
                        <div class="panel-body">
                            <div class="col-md-12 no-padding clearfix">
                                <div class="col-md-6 clearfix">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtOrderNo" CssClass="col-xs-4 control-label no-padding-right" Text="Order No"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtOrderNo" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtOrderDate" CssClass="col-xs-4 control-label no-padding-right" Text="Order Date"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtOrderDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                            <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtOrderDate" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlBookCode" CssClass="col-xs-4 control-label no-padding-right" Text="Book Code"></asp:Label>
                                        <div class="col-xs-8">
                                            <%--<asp:TextBox ID="txtSearch" runat="server"
         onkeyup = "FilterItems(this.value)"></asp:TextBox><br />--%>
                                            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox><br />
                                            <asp:DropDownList ID="ddlBookCode" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlBookCode_SelectedIndexChanged" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6 clearfix">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtBookName" CssClass="col-sm-4 control-label no-padding-right" Text="Book Name"></asp:Label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txtBookName" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtClass" CssClass="col-xs-4 control-label no-padding-right" Text="Class"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtClass" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtBookType" CssClass="col-xs-4 control-label no-padding-right" Text="Type"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtBookType" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlEdition" CssClass="col-xs-4 control-label no-padding-right" Text="Edition"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList ID="ddlEdition" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 clearfix">
                                <hr />
                            </div>
                            <div class="col-md-12 clearfix no-padding">
                                <div class="col-md-6 clearfix">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlType" CssClass="col-xs-4 control-label no-padding-right" Text="Type"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                                <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                <asp:ListItem Value="0">Forma</asp:ListItem>
                                                <asp:ListItem Value="1">Cover</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtPrintNo" CssClass="col-xs-4 control-label no-padding-right" Text="Print No"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtPrintNo" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtPrintQty" CssClass="col-xs-4 control-label no-padding-right" Text="Print Qty"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtPrintQty" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="lblFormaQty" CssClass="col-xs-4 control-label no-padding-right" Text="Forma Qty"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:Label ID="lblFormaQty" runat="server" CssClass="form-control" value="0"/>
                                        </div>
                                    </div>
                                    <hr />
                                </div>
                                <div class="col-md-6 clearfix">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtSSerial" CssClass="col-xs-4 control-label no-padding-right" Text="Starting Serial"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtSSerial" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtSSerial_TextChanged" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtESerial" CssClass="col-xs-4 control-label no-padding-right" Text="Ending Serial"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtESerial" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtSSerial_TextChanged" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="ddlBookBinderName" CssClass="col-sm-4 control-label no-padding-right" Text="Binder Name"></asp:Label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="ddlBookBinderName" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtQty" CssClass="col-xs-4 control-label no-padding-right" Text="Quantity"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtQty" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-xs-8 col-xs-offset-4">
                                            <asp:Button ID="btnAdd" Text="Add" CssClass="btn btn-primary btn-sm" runat="server" OnClick="btnAdd_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div><br/>
                            <div class="clearfix"></div>
                            <%--table grid--%>
                            <div class="col-md-12 clearfix table-responsive">
                                <asp:GridView ID="gvwBindingDeli" runat="server" CssClass="table grid-view" AutoGenerateColumns="false">
                                     <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:BoundField DataField="BinderName" HeaderText="Binder Name" />
                                        <asp:BoundField DataField="Type" HeaderText="Type" />
                                        <asp:BoundField DataField="StartingS" HeaderText="Starting No" />
                                        <asp:BoundField DataField="StartingE" HeaderText="Ending No" />
                                        <asp:BoundField DataField="Qty" HeaderText="Qty" />
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
                            <div class="col-md-12 clearfix no-padding">
                                <div class="col-md-6 col-md-offset-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtTotalQty" CssClass="col-xs-4 control-label no-padding-right" Text="Total Qty"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtTotalQty" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-xs-8 col-xs-offset-4">                                           
                                             <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                                             <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-navbar" runat="server" OnClick="btnPrint_Click" /> 
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
            open_menu("Binding");
        });
        // function in site.master page
    </script>


    <%--<script type = "text/javascript">

    var ddlText, ddlValue, ddl;

    function CacheItems() {

        ddlText = new Array();

        ddlValue = new Array();

        ddl = document.getElementById("<%=ddlBookCode.ClientID %>");

        for (var i = 0; i < ddl.options.length; i++) {

            ddlText[ddlText.length] = ddl.options[i].text;

            ddlValue[ddlValue.length] = ddl.options[i].value;

        }

    }

    window.onload = CacheItems;



    function FilterItems(value) {

        ddl.options.length = 0;

        for (var i = 0; i < ddlText.length; i++) {

            if (ddlText[i].toLowerCase().indexOf(value) != -1) {

                AddItem(ddlText[i], ddlValue[i]);

            }

        }

    }



    function AddItem(text, value) {

        var opt = document.createElement("option");

        opt.text = text;

        opt.value = value;

        ddl.options.add(opt);

    }

</script>--%>

    <script type="text/javascript">
        $(function () {
            var $txt = $('input[id$=txtSearch]');
            var $ddl = $('select[id$=ddlBookCode]');
            var $items = $('select[id$=ddlBookCode] option');

            $txt.keyup(function () {
                searchDdl($txt.val());
            });

            function searchDdl(item) {
                $ddl.empty();
                var exp = new RegExp(item, "i");
                var arr = $.grep($items,
                    function (n) {
                        return exp.test($(n).text());
                    });

                if (arr.length > 0) {
                    countItemsFound(arr.length);
                    $.each(arr, function () {
                        $ddl.append(this);
                        $ddl.get(0).selectedIndex = 0;
                    }
                    );
                }
                else {
                    countItemsFound(arr.length);
                    $ddl.append("<option>No Items Found</option>");
                }
            }

            function countItemsFound(num) {
                $("#para").empty();
                if ($txt.val().length) {
                    $("#para").html(num + " items found");
                }

            }
        });
    </script>

</asp:Content>
