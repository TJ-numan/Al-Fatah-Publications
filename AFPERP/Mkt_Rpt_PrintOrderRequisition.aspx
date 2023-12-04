<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_Rpt_PrintOrderRequisition.aspx.cs" Inherits="BLL.Mkt_Rpt_RequisitionNo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Print Requisition 
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpFromDate" CssClass="col-md-4 control-label" Text="From" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox CssClass="form-control date" ID="dtpFromDate" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpFromDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpToDate" CssClass="col-md-4 control-label" Text="To" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox CssClass="form-control date" ID="dtpToDate" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpToDate" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="btnShow" CssClass="col-md-4 control-label" Text="" runat="server"></asp:Label>
                        <div class="col-md-3">
                             <asp:Button ID="btnShow" Text="Refresh" CssClass="btn btn-success" runat="server" OnClick="btnShow_Click" />
                             <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-info" runat="server" OnClick="btnPrint_Click" />
                             
                        </div>
                    </div>

                    <div class="panel-body">
                        <div class="table-responsive table-bordered clearfix "  >
                            <asp:GridView ID="gvPrintRequisition" CssClass="table " runat="server" AutoGenerateColumns="false" OnRowDataBound="gvPrintRequisition_RowDataBound" OnSelectedIndexChanged="gvPrintRequisition_SelectedIndexChanged">
                                <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                <Columns>

                                    <asp:BoundField DataField="RqeNo" HeaderText="ID" />
                                    <asp:BoundField DataField="BookName" HeaderText="BookName" />
                                    <asp:BoundField DataField="ClassName" HeaderText="Class" /> 
                                    <asp:BoundField DataField="TypeName" HeaderText="Type" />
                                    <asp:BoundField DataField="Edition" HeaderText="Edition" />
                                    <asp:BoundField DataField="ProposedQty" HeaderText="ProposedQty" />

                                    <asp:CommandField SelectText="Print" ShowSelectButton="true" ItemStyle-CssClass="btn btn-compose"
                                        HeaderStyle-CssClass="HiddenColumn" />
                                </Columns>



                            </asp:GridView>
                        </div>
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
</asp:Content>
