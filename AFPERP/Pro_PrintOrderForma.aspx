<%@ Page Title="Forma Print Order" Language="C#" MasterPageFile="~/ProductionMaster.master" AutoEventWireup="true" CodeBehind="Pro_PrintOrderForma.aspx.cs" Inherits="BLL.Pro_PrintOrderForma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProductionContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Forma Print Order
                </div>
                <%-- <div id="frmPrintingFormaOrder" runat="server" class="form-horizontal clearfix">--%>
                <div class="panel-body">
                    <div class="clearfix">
                        <div class="col-md-7">
                            <fieldset>
                                <%--<legend></legend>--%>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtOrderNo" CssClass="col-xs-4 control-label" Text="Order No" runat="server"></asp:Label>
                                    <div class="col-xs-8">
                                        <asp:TextBox CssClass="form-control" ID="txtOrderNo" placeholder="Order No" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="dtpOrderDate" CssClass="col-xs-4 control-label" Text="Order Date" runat="server"></asp:Label>
                                    <div class="col-xs-8">
                                        <asp:TextBox CssClass="form-control" ID="dtpOrderDate" placeholder="yyyy/mm/dd" runat="server" />
                                        <ajaxToolkit:CalendarExtender TargetControlID="dtpOrderDate" Format="yyyy/MM/dd" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlCategory" CssClass="col-xs-4 control-label" Text="Category" runat="server"></asp:Label>
                                    <div class="col-xs-8">
                                        <asp:DropDownList CssClass="form-control" ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlGroup" CssClass="col-xs-4 control-label" Text="Group" runat="server"></asp:Label>
                                    <div class="col-xs-8">
                                        <asp:DropDownList CssClass="form-control" ID="ddlGroup" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlClass" CssClass="col-xs-4 control-label" Text="Class" runat="server"></asp:Label>
                                    <div class="col-xs-8">
                                        <asp:DropDownList CssClass="form-control" ID="ddlClass" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlType" CssClass="col-xs-4 control-label" Text="Type" runat="server"></asp:Label>
                                    <div class="col-xs-8">
                                        <asp:DropDownList CssClass="form-control" ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                     
                    </div>
                    <br />
                    <div class="clearfix">
                        <div class="col-md-7">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlBookName" CssClass="col-md-4 control-label" Text="Book Name" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlBookName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBookName_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-5">
                            <div class="col-xs-6 no-padding">
                                <div class="clearfix">
                                    <asp:DropDownList CssClass="form-control" ID="ddlPestingType" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-xs-6 no-padding padding-left">
                                <div class="clearfix">
                                    <asp:Label AssociatedControlID="ddlEdition" CssClass="col-xs-4 control-label no-padding" Text="Edition" runat="server"></asp:Label>
                                    <div class="col-xs-8 no-padding padding-left">
                                        <asp:DropDownList CssClass="form-control" ID="ddlEdition" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEdition_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                  <br />
                         <div class="col-md-12">
                            <fieldset>
                                <%--<legend></legend>--%>
                                <div class="col-xs-6 no-padding">
                                    <div class="clearfix">
                                        <asp:Label AssociatedControlID="txtTotalPrintQty" CssClass="col-xs-5 control-label no-padding" Text="Print Qty" runat="server"></asp:Label>
                                        <div class="col-xs-7 no-padding padding-left">
                                            <asp:TextBox CssClass="form-control" ID="txtTotalPrintQty" runat="server" AutoPostBack="True" OnTextChanged="txtPrintQty_TextChanged" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-4">
                                    <div class="clearfix">
                                        <asp:Label AssociatedControlID="ddlPrintSl" CssClass="col-xs-3 control-label no-padding" Text="as" runat="server"></asp:Label>
                                        <div class="col-xs-9 no-padding padding-left">
                                            <asp:DropDownList CssClass="form-control" ID="ddlPrintSl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEdition_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-6 col-xs-offset-2 no-padding">
                                    <div class="checkbox">
                                        <asp:Label AssociatedControlID="chkCombindQty" runat="server" Text="Combined Qty"></asp:Label>
                                        <asp:CheckBox ID="chkCombindQty" runat="server" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    


                    <div class="clearfix"></div>
                    <div>
                        <div class="col-md-12">
                            <fieldset>
                                <asp:Panel ID="Panel1" runat="server" GroupingText="Select One">
                                    <%-- <legend>Select One</legend>--%>
                                    <div class="table-responsive">
                                        <table class="table no-head-padding">
                                            <tr>
                                                <th colspan="2"></th>
                                                <th>
                                                    <asp:Label runat="server" Text="5 Color"></asp:Label>
                                                </th>
                                                <th>
                                                    <asp:Label runat="server" Text="4 Color"></asp:Label>
                                                </th>
                                                <th>
                                                    <asp:Label runat="server" Text="3 Color"></asp:Label>
                                                </th>
                                                <th>
                                                    <asp:Label runat="server" Text="2 Color"></asp:Label>
                                                </th>
                                                <th>
                                                    <asp:Label runat="server" Text="1 Color"></asp:Label>
                                                </th>
                                                <th>
                                                    <asp:Label runat="server" Text="Black"></asp:Label>
                                                </th>
                                            </tr>
                                            <tr id="inner" style="background-color: burlywood;">
                                                <td rowspan="3">
                                                    <asp:Label AssociatedControlID="ddlBookSize" runat="server" Text="Book Size"></asp:Label>
                                                    <asp:DropDownList ID="ddlBookSize" CssClass="form-control" runat="server" Enabled="False">
                                                        <asp:ListItem>This is Book No. 1</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <th>
                                                    <asp:Label ID="lbl_PtOrinner" runat="server" Text="Inner" Font-Size="Large"></asp:Label>
                                                </th>
                                                <td>
                                                    <div class="col-xs-1 no-padding">
                                                        <asp:RadioButton ID="chkIn5" runat="server" GroupName="selectOne" data-class="In5" />
                                                    </div>
                                                    <div class="col-xs-11 no-padding padding-left">
                                                        <asp:TextBox ID="txtIn5" CssClass="form-control In5" runat="server"  ContentEditable="false" />
                                                    </div>

                                                </td>
                                                <td>
                                                    <div class="col-xs-1 no-padding">
                                                        <asp:RadioButton ID="chkIn4" runat="server" GroupName="selectOne" data-class="In4" />
                                                    </div>
                                                    <div class="col-xs-11 no-padding padding-left">
                                                        <asp:TextBox ID="txtIn4" CssClass="form-control In4" runat="server"  ContentEditable="false" />
                                                    </div>

                                                </td>
                                                <td>
                                                    <div class="col-xs-1 no-padding">
                                                        <asp:RadioButton ID="chkIn3" runat="server" GroupName="selectOne" data-class="In3" />
                                                    </div>
                                                    <div class="col-xs-11 no-padding padding-left">
                                                        <asp:TextBox ID="txtIn3" CssClass="form-control In3" runat="server"  ContentEditable="false" />
                                                    </div>

                                                </td>
                                                <td>
                                                    <div class="col-xs-1 no-padding">
                                                        <asp:RadioButton ID="chkIn2" runat="server" GroupName="selectOne" data-class="In2" />
                                                    </div>
                                                    <div class="col-xs-11 no-padding padding-left">
                                                        <asp:TextBox ID="txtIn2" CssClass="form-control In2" runat="server" ContentEditable="false" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-xs-1 no-padding ">
                                                        <asp:RadioButton ID="chkIn1" runat="server" GroupName="selectOne" data-class="In1" />
                                                    </div>
                                                    <div class="col-xs-11 no-padding padding-left">
                                                        <asp:TextBox ID="txtIn1" CssClass="form-control In1" runat="server"  ContentEditable="false" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-xs-1 no-padding">
                                                        <asp:RadioButton ID="chkInBw" runat="server" GroupName="selectOne" data-class="InB1" />
                                                    </div>
                                                    <div class="col-xs-11 no-padding padding-left">
                                                        <asp:TextBox ID="txtInBW" CssClass="form-control InB1" runat="server"  ContentEditable="false" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr id="forma" style="background-color: gray;">
                                                <th>
                                                    <asp:Label ID="lbl_PtOrforma" runat="server" Text="Forma" Font-Size="Large"></asp:Label>
                                                </th>
                                                <td>
                                                    <div class="col-xs-1 no-padding">
                                                        <asp:RadioButton ID="chkForma5" runat="server" GroupName="selectOne" data-class="Forma5" />
                                                    </div>
                                                    <div class="col-xs-11 no-padding padding-left">
                                                        <asp:TextBox ID="txtForma5" CssClass="form-control Forma5" runat="server"  ContentEditable="false" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-xs-1 no-padding">
                                                        <asp:RadioButton ID="chkForma4" runat="server" GroupName="selectOne" data-class="Forma4" />
                                                    </div>
                                                    <div class="col-xs-11 no-padding padding-left">
                                                        <asp:TextBox ID="txtForma4" CssClass="form-control Forma4" runat="server"  ContentEditable="false" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-xs-1 no-padding">
                                                        <asp:RadioButton ID="chkForma3" runat="server" GroupName="selectOne" data-class="Forma3" />
                                                    </div>
                                                    <div class="col-xs-11 no-padding padding-left">
                                                        <asp:TextBox ID="txtForma3" CssClass="form-control Forma3" runat="server"  ContentEditable="false" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-xs-1 no-padding">
                                                        <asp:RadioButton ID="chkForma2" runat="server" GroupName="selectOne" data-class="Forma2" />
                                                    </div>
                                                    <div class="col-xs-11 no-padding padding-left">
                                                        <asp:TextBox ID="txtForma2" CssClass="form-control Forma2" runat="server"  ContentEditable="false"/>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-xs-1 no-padding">
                                                        <asp:RadioButton ID="chkForma1" runat="server" GroupName="selectOne" data-class="Forma1" />
                                                    </div>
                                                    <div class="col-xs-11 no-padding padding-left">
                                                        <asp:TextBox ID="txtForma1" CssClass="form-control Forma1" runat="server"  ContentEditable="false" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-xs-1 no-padding">
                                                        <asp:RadioButton ID="chkFormaBW" runat="server" GroupName="selectOne" data-class="FormaB1" />
                                                    </div>
                                                    <div class="col-xs-11 no-padding padding-left">
                                                        <asp:TextBox ID="txtFormaBW" CssClass="form-control FormaB1" runat="server"  ContentEditable="false" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr id="postani" style="background-color: sandybrown">
                                                <th>
                                                    <asp:Label ID="lbl_PtOrpostani" runat="server" Text="Postani" Font-Size="Large"></asp:Label>
                                                </th>
                                                <td>
                                                    <div class="col-xs-1 no-padding">
                                                        <asp:RadioButton ID="chkPostani5" runat="server" GroupName="selectOne" data-class="Postani5" />
                                                    </div>
                                                    <div class="col-xs-11 no-padding padding-left">
                                                        <asp:TextBox ID="txtPostani5" CssClass="form-control Postani5" runat="server"  ContentEditable="false" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-xs-1 no-padding">
                                                        <asp:RadioButton ID="chkPostani4" runat="server" GroupName="selectOne" data-class="Postani4" />
                                                    </div>
                                                    <div class="col-xs-11 no-padding padding-left">
                                                        <asp:TextBox ID="txtPostani4" CssClass="form-control Postani4" runat="server"  ContentEditable="false" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-xs-1 no-padding">
                                                        <asp:RadioButton ID="chkPostani3" runat="server" GroupName="selectOne" data-class="Postani3" />
                                                    </div>
                                                    <div class="col-xs-11 no-padding padding-left">
                                                        <asp:TextBox ID="txtPostani3" CssClass="form-control Postani3" runat="server"  ContentEditable="false" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-xs-1 no-padding">
                                                        <asp:RadioButton ID="chkPostani2" runat="server" GroupName="selectOne" data-class="Postani2" />
                                                    </div>
                                                    <div class="col-xs-11 no-padding padding-left">
                                                        <asp:TextBox ID="txtPostani2" CssClass="form-control Postani2" runat="server"  ContentEditable="false" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-xs-1 no-padding">
                                                        <asp:RadioButton ID="chkPostani1" runat="server" GroupName="selectOne" data-class="Postani1" />
                                                    </div>
                                                    <div class="col-xs-11 no-padding padding-left">
                                                        <asp:TextBox ID="txtPostani1" CssClass="form-control Postani1" runat="server"  ContentEditable="false" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-xs-1 no-padding">
                                                        <asp:RadioButton ID="chkPostaniBW" runat="server" GroupName="selectOne" data-class="PostaniB1" />
                                                    </div>
                                                    <div class="col-xs-11 no-padding padding-left">
                                                        <asp:TextBox ID="txtPostaniBW" CssClass="form-control PostaniB1" runat="server"  ContentEditable="false" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>
                            </fieldset>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="upPayment1" runat="server">
                        <ContentTemplate>
                            <div class="col-md-12 clearfix">
                                <div class="col-md-6 no-padding clearfix">
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlPressName" CssClass="col-sm-3 no-padding-right control-label" Text="Press Name" runat="server"></asp:Label>
                                        <div class="col-sm-9">
                                            <asp:DropDownList CssClass="form-control" ID="ddlPressName" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-12 no-padding clearfix">
                                        <div class="col-xs-6 no-padding clearfix padding-small-right">
                                            <div class="form-group">
                                                <asp:Label AssociatedControlID="ddlPaperType" CssClass="col-sm-6 no-padding-right control-label" Text="Paper Type" runat="server"></asp:Label>
                                                <div class="col-sm-6">
                                                    <asp:DropDownList CssClass="form-control" ID="ddlPaperType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPaperType_SelectedIndexChanged"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-6 no-padding-right clearfix">
                                            <div class="form-group">
                                                <asp:Label AssociatedControlID="ddlPaperSize" CssClass="col-sm-6 no-padding-right control-label" Text="Paper Size" runat="server"></asp:Label>
                                                <div class="col-sm-6">
                                                    <asp:DropDownList CssClass="form-control" ID="ddlPaperSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPaperSize_SelectedIndexChanged"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 no-padding clearfix">
                                        <div class="col-xs-6 no-padding clearfix padding-small-right">
                                            <div class="form-group">
                                                <asp:Label AssociatedControlID="ddlGSM" CssClass="col-sm-6 no-padding-right control-label" Text="GSM" runat="server"></asp:Label>
                                                <div class="col-sm-6">
                                                    <asp:DropDownList CssClass="form-control" ID="ddlGSM" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGSM_SelectedIndexChanged"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-6 no-padding-right clearfix">
                                            <div class="form-group">
                                                <asp:Label AssociatedControlID="ddlBrand" CssClass="col-sm-6 no-padding-right control-label" Text="Brand" runat="server"></asp:Label>
                                                <div class="col-sm-6">
                                                    <asp:DropDownList CssClass="form-control" ID="ddlBrand" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 no-padding clearfix">
                                        <div class="col-xs-6 no-padding clearfix padding-small-right">
                                            <div class="form-group">
                                                <asp:Label AssociatedControlID="txtPressFormQty" CssClass="col-sm-6 no-padding-right control-label" Text="Forma Qty" runat="server"></asp:Label>
                                                <div class="col-sm-6 dfd">
                                                    <asp:TextBox CssClass="form-control" ID="txtPressFormQty" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-6 no-padding-right clearfix">
                                            <div class="form-group">
                                                <asp:Label AssociatedControlID="txtColorNo" CssClass="col-sm-6 no-padding-right control-label" Text="Color No" runat="server"></asp:Label>
                                                <div class="col-sm-6">
                                                    <asp:TextBox CssClass="form-control color" ID="txtColorNo" runat="server"  ContentEditable="false"/>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 no-padding clearfix">
                                        <div class="col-xs-6 no-padding clearfix padding-small-right">
                                            <div class="form-group">
                                                <asp:Label AssociatedControlID="txtPrintQty" CssClass="col-sm-6 no-padding-right control-label" Text="Press Qty" runat="server"></asp:Label>
                                                <div class="col-sm-6">
                                                    <asp:TextBox CssClass="form-control" ID="txtPrintQty" placeholder="0" runat="server" AutoPostBack="True" OnTextChanged="txtPrintQty_TextChanged" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-6 no-padding-right clearfix">
                                            <div class="form-group">
                                                <asp:Label AssociatedControlID="ddlPrintType" CssClass="col-sm-6 no-padding-right control-label" Text="Print Type" runat="server"></asp:Label>
                                                <div class="col-sm-6">
                                                    <asp:DropDownList CssClass="form-control" ID="ddlPrintType" runat="server" OnSelectedIndexChanged="txtPrintQty_TextChanged" AutoPostBack="true">
                                                        <asp:ListItem Value="0"> Back to Back</asp:ListItem>
                                                        <asp:ListItem Value="1">One Sided</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-6 no-padding clearfix">
                                    <div class="col-md-12 no-padding-right clearfix">

                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="txtPaperQty" CssClass="col-xs-4 no-padding-right control-label" Text="App. Paper Qty" runat="server"></asp:Label>
                                            <div class="col-xs-4">
                                                <asp:TextBox CssClass="form-control" ID="txtPaperQty"  ContentEditable="false" placeholder="0" runat="server" />
                                            </div>
                                            <div class="col-xs-4">
                                                <asp:DropDownList CssClass="form-control" ID="ddlPaperUnit" runat="server" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 no-padding-right clearfix">
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="ddlPaperUnit" CssClass="col-xs-4 no-padding-right control-label" Text="Kg/Rim" runat="server" ID="lblDBy" Visible="false"></asp:Label>
                                            <div class="col-xs-4">
                                                <asp:TextBox CssClass="form-control" ID="txtDBy" runat="server" Visible="false" />
                                            </div>
                                        </div>
                                    </div>


                                    <div class="col-md-12 no-padding-right clearfix">
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="txtPrintingFFormaDetail" Font-Names="SutonnyMJ" CssClass="col-xs-4 no-padding-right control-label" Text="dg©vi weeiY" runat="server"></asp:Label>
                                            <div class="col-xs-8 clearfix">
                                                <asp:TextBox ID="txtPrintingFFormaDetail" Font-Names="SutonnyMJ" CssClass="form-control" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 no-padding-right clearfix">
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="txtBillRate" CssClass="col-xs-4 no-padding-right control-label" Text="Price Per Color" runat="server"></asp:Label>
                                            <div class="col-xs-8 clearfix">
                                                <asp:TextBox ID="txtBillRate" CssClass="form-control" runat="server" AutoPostBack="True" OnTextChanged="txtPrintQty_TextChanged" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 no-padding-right clearfix">
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="txtBillAmount" CssClass="col-xs-4 no-padding-right control-label" Text="Bill Amount" runat="server"></asp:Label>
                                            <div class="col-xs-8 clearfix">
                                                <asp:TextBox ID="txtBillAmount" CssClass="form-control" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 no-padding-right clearfix">
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="txtPrintingFNotes" CssClass="col-xs-4 no-padding-right control-label" Text="Notes" runat="server"></asp:Label>
                                            <div class="col-xs-8 clearfix">
                                                <asp:TextBox ID="txtPrintingFNotes" CssClass="form-control" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-8 col-md-offset-3 no-padding-right clearfix">
                                        <div class="form-group">
                                            <asp:Button ID="btnPrintingFAdd" Text="Add" CssClass="btn btn-primary btn-sm pull-right" runat="server" OnClick="btnPrintingFAdd_Click" />
                                        </div>
                                    </div>
                                </div>

                            </div><br/>
                            
                            <%--grid view--%>
                            <div class="table-responsive">
                                <asp:GridView ID="gvwPrintingFShowData" runat="server" CssClass="grid-view table" Align="Center" AutoGenerateColumns="false">
                                     <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" DataField="Serial" />
                                        <asp:BoundField DataField="Press" HeaderText="Press" />
                                        <asp:BoundField DataField="Type" HeaderText="Type" />
                                        <asp:BoundField DataField="Size" HeaderText="Size" />
                                        <asp:BoundField DataField="GSM" HeaderText="GSM" />
                                        <asp:BoundField DataField="Brand" HeaderText="Brand" />
                                        <asp:BoundField DataField="part_Book" HeaderText="Part" />
                                        <asp:BoundField DataField="FormaQty" HeaderText="Forma Qty" />
                                        <asp:BoundField DataField="PaperQty" HeaderText="Paper Qty" />
                                        <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                        <asp:BoundField DataField="ColorNo" HeaderText="Color No" />
                                        <asp:BoundField DataField="ColorBillRate" HeaderText="Rate/Color" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                        <asp:BoundField DataField="FormaDes" HeaderText="FormaDes" ItemStyle-Font-Names="SutonnyMJ" />
                                        <asp:BoundField DataField="PaperNote" HeaderText="PaperNote" />
                                        <asp:BoundField DataField="PressPrintQty" HeaderText="PressPrintQty" />
                                        <asp:BoundField DataField="OneSide" HeaderText="OneSide" />
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
                            <div>&nbsp;</div>
                            <div class="col-md-12 clearfix">
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <asp:RadioButton ID="chkShortForma" GroupName="rdoPrintingFChange" runat="server" />
                                        <asp:Label AssociatedControlID="chkShortForma" runat="server" Text="Short Forma"></asp:Label>
                                        <br />
                                        <asp:RadioButton ID="chkOtherPrint" GroupName="rdoPrintingFChange" runat="server" />
                                        <asp:Label AssociatedControlID="chkOtherPrint" runat="server" Text="Other"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-6 no-padding">
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="txtRemark" CssClass="col-xs-4 no-padding-right control-label" runat="server" Text="Remark"></asp:Label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtRemark" CssClass="form-control" runat="server" placeholder="Remark" TextMode="MultiLine" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4 no-padding-right">
                                    <div>
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="txtPrintingFTotalForma" CssClass="col-xs-4 no-padding-right control-label" runat="server" Text="Total Forma"></asp:Label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtPrintingFTotalForma" CssClass="form-control" runat="server" placeholder="0"  ContentEditable="false" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblFormaQty" runat="server" Font-Bold="true" CssClass="col-xs-4 no-padding-right control-label" />
                                    </div>
                                    <div>
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="txtPrintingFTotalBill" CssClass="col-xs-4 no-padding-right control-label" runat="server" Text="Total Bill"></asp:Label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtPrintingFTotalBill" CssClass="form-control" runat="server" placeholder="0"  ContentEditable="false" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="col-md-12 clearfix">
                        <div class="form-group">
                            <div class="col-md-8 col-md-offset-4 clearfix">                           
                                <asp:Button ID="btnPrintingFSupPlate" Text="Supply Plate" CssClass="btn btn-info" runat="server" OnClick="btnPrintingFSupPlate_Click" />
                                 <asp:Button ID="btnPrintingFSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnPrintingFSave_Click" />
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
            open_menu("Printing");
        });

        $(document).ready(function () {
            $('input[type=radio]').click(function () {
                b = $(this).parent('span').attr("data-class");
                c = $('input[type=text].' + b).val();
                $('.dfd input').val(c);
                color = b.substring(b.length - 1);
                
                $('input.color').val(color);
            });
        });

    </script>
</asp:Content>
