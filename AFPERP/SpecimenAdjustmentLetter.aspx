<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="SpecimenAdjustmentLetter.aspx.cs" Inherits="BLL.SpecimenAdjustmentLetter" %>

 

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Specimen Adjustment Letter
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-4 control-label" Text="From Date" runat="server"></asp:Label>
                        <div class="input-group col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-4 control-label" Text="To Date" runat="server"></asp:Label>
                        <div class="input-group col-md-5">
                            <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlRegionMain" runat="server" CssClass="col-md-4 control-label no-padding-right" Text="Region Main" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlRegionMain" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlRegionMain_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlRegion" runat="server" CssClass="col-md-4 control-label" Text="Region" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlDivision" runat="server" CssClass="col-md-4 control-label" Text="Division" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlDivision" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlZone" runat="server" CssClass="col-md-4 control-label" Text="Zone" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlZone" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlTeritory" runat="server" CssClass="col-md-4 control-label" Text="Teritory" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlTeritory" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlTeritory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlTsoName" runat="server" CssClass="col-md-4 control-label" Text="TSO" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlTsoName" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTsoName_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtTotalReturn" runat="server" CssClass="col-md-4 control-label" Text="Total Return" />
                        <div class="dropdown col-md-5">
                            <asp:TextBox ID="txtTotalReturn" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtTotalAdjustment" runat="server" CssClass="col-md-4 control-label" Text="Total Adjustment" />
                        <div class="dropdown col-md-5">
                            <asp:TextBox ID="txtTotalAdjustment" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtLetterNo" runat="server" CssClass="col-md-4 control-label" Text="Letter No" />
                        <div class="dropdown col-md-5">
                            <asp:TextBox ID="txtLetterNo" runat="server" CssClass="form-control"  AutoCompleteType="Disabled"  ></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="input-group col-md-8 col-md-offset-4">                       
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-info" runat="server" OnClick="btnSave_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-default" runat="server" OnClick="btnPrint_Click" />
                        </div>
                    </div>
 


                    <asp:GridView ID="gvSpecimenLetter" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-responsive" >
                        <Columns>
                            <asp:BoundField   DataField="TsoId" HeaderText="TsoId"  />
                            <asp:BoundField   DataField="TranDate" HeaderText="Date"  DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:BoundField   DataField="MemoNo" HeaderText="MemoNo" />
                            <asp:BoundField   DataField="ChallanAmount" HeaderText="ChallanAmount" Visible="false"/>
                            <asp:BoundField   DataField="PacketCost" HeaderText="PacketCost" Visible="false" />
                            <asp:BoundField   DataField="ReturnAmount" HeaderText="ReturnAmount" />
                            <asp:BoundField   DataField ="Adjustment" HeaderText="Adjustment" />
                            <asp:BoundField   DataField="chl" HeaderText="chl"  Visible="false"/>
                            <asp:BoundField   DataField="Ret" HeaderText="Ret" />
                            <asp:BoundField   DataField  ="Adj" HeaderText="Adj" />
                            <asp:BoundField   DataField="IntFrom" HeaderText="IntFrom"  />
                            <asp:BoundField   DataField ="IntTo" HeaderText="IntTo"  Visible="false"/>                            
                        </Columns>
                    </asp:GridView>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Reports", "Specimen");
        });
    </script>

</asp:Content>
