<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_TeritoryBudget.aspx.cs" Inherits="BLL.Mkt_TeritoryBudget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div id="frmChallanNew" runat="server" class="form-horizontal clearfix">
        <div class="panel-body " style="border: 1px solid #BDC3CA">
            <div class="col-md-12 clearfix no-padding">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Teritory Budget
                    </div>
                    <div class="panel-body">

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtRefNo" CssClass="col-md-4 control-label no-padding-right" Text="Reference No"></asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtRefNo" CssClass="form-control" ReadOnly="true">
                                </asp:TextBox>
                            </div>
                        </div>
                        
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlAgreementYear" Text="Session" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                        <div class="col-md-4">
                                            <asp:DropDownList CssClass="form-control" ID="ddlAgreementYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDonationType_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="ddlDonationType" CssClass="col-md-4 control-label no-padding-right" Text="Donation Type"></asp:Label>
                                    <div class="col-md-4">
                                        <asp:DropDownList runat="server" ID="ddlDonationType" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlDonationType_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div class="row col-md-12">
                            <div class="col-md-6 clearfix">
                                <div class="panel-heading">
                                    From
                                </div>
                                <div class="panel-body " style="border: 1px solid #BDC3CA">
                                    <asp:UpdatePanel runat="server" ID="UpdateArea1">
                                        <ContentTemplate>
                                            <div class="form-group">
                                                <asp:Label runat="server" AssociatedControlID="ddlTerritoryFrom" CssClass="col-md-4 control-label no-padding-right" Text="Territory"></asp:Label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList runat="server" ID="ddlTerritoryFrom" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlTerritoryFrom_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label runat="server" AssociatedControlID="txtTerBudgetFrom" CssClass="col-md-4 control-label no-padding-right" Text="Budget Amount"></asp:Label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="txtTerBudgetFrom" CssClass="form-control calc-sub">
                                                    </asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <asp:Label runat="server" AssociatedControlID="txtTerBudgetPaidFrom" CssClass="col-md-4 control-label no-padding-right" Text="Budget Paid"></asp:Label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="txtTerBudgetPaidFrom" CssClass="form-control calc-sub">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label runat="server" AssociatedControlID="txtTerBudgetAvaiable" CssClass="col-md-4 control-label no-padding-right" Text="Budget Avaiable"></asp:Label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="txtTerBudgetAvaiable" Text="0.00" CssClass="form-control calc-sub">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <br />
                                <%--                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtDate" CssClass="col-xs-4 control-label no-padding-right" Text="Order Date"></asp:Label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" />
                                        <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate" />
                                    </div>
                                </div>--%>
                            </div>
                            <div class="col-md-6">
                                <div class="panel-heading">
                                    To
                                </div>
                                <div class="panel-body " style="border: 1px solid #BDC3CA">
                                    <asp:UpdatePanel runat="server" ID="UpdateArea2">
                                        <ContentTemplate>
                                            <div class="form-group">
                                                <asp:Label runat="server" AssociatedControlID="ddlTerritoryTo" CssClass="col-md-4 control-label no-padding-right" Text="Territory"></asp:Label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList runat="server" ID="ddlTerritoryTo" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTerritoryTo_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label runat="server" AssociatedControlID="txtTerBudgetTo" CssClass="col-md-4 control-label no-padding-right" Text="Budget Amount"></asp:Label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="txtTerBudgetTo" CssClass="form-control calc-total">
                                                    </asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <asp:Label runat="server" AssociatedControlID="txtTerBudgetPaidTo" CssClass="col-md-4 control-label no-padding-right" Text="Budget Paid"></asp:Label>
                                                <div class="col-md-8">
                                                    <asp:TextBox runat="server" ID="txtTerBudgetPaidTo" CssClass="form-control calc-sub">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <br />

                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtTransferAmount" CssClass="col-md-4 control-label no-padding-right" Text="Transfer Amount"></asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtTransferAmount" runat="server" CssClass="form-control calc" />
                            </div>
                        </div>
                        </br></br>
                            <div class="form-group">
                                <div class="input-group col-md-8 col-md-offset-4">
                                    <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-info"  OnClientClick="if (!confirm('Are you sure to Transfer?')) return false;" runat="server" OnClick="btnSave_Click" />
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
            open_menu("Madrasah");
        });
    </script>
    <%--  <script type="text/javascript">
            $(document).ready(function () {

                calculateSum(".calc", ".calc-total");

                $(".calc").on("keyup", function () {
                    calculateSum(".calc", ".calc-total");
                });

                calculateSub(".calc", ".calc-sub");

                $(".calc").on("keyup", function () {
                    calculateSub(".calc", ".calc-sub");
                });

            });


            //more field summation with textchange
            function calculateSum(field, total) {
                var sum = 0;

                $(field).each(function () {
                    //add only if the value is number
                    if (!isNaN(this.value) && this.value.length != 0) {
                        sum += parseFloat(this.value);
                    }
                });
                $(total).val(sum.toFixed(0));

            }
            //more field substraction with textchange
            function calculateSub(field, total) {
                var sub = 0;

                $(field).each(function () {
                    //add only if the value is number
                    if (!isNaN(this.value) && this.value.length != 0) {
                        sub -= parseFloat(this.value);
                    }
                });
                $(total).val(sub.toFixed(0));

            }
    </script>--%>
</asp:Content>
