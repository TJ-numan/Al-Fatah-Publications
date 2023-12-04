<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_DatewiseMRSheet.aspx.cs" Inherits="BLL.Mkt_DatewiseMRSheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Datewise MR Sheet 
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
                        <asp:Label AssociatedControlID="chkHeldUp" CssClass="col-md-4 control-label" Text="Held Up" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:CheckBox ID="chkHeldUp"  runat="server" OnCheckedChanged="btnShow_Click" />

                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="btnShow" CssClass="col-md-4 control-label" Text="" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:Button ID="btnShow" Text="Refresh"  CssClass="btn btn-success" runat="server" OnClick="btnShow_Click" />

                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="table-responsive table-bordered clearfix ">
                            <asp:GridView ID="gvDateWiseMRSheet" CssClass="table " runat="server" AutoGenerateColumns="false" OnRowDataBound="gvDateWiseMRSheet_RowDataBound" OnSelectedIndexChanged="gvDateWiseMRSheet_SelectedIndexChanged">
                                <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                <Columns>

                                    <asp:BoundField DataField="MRId" HeaderText="MR ID" />
                                    <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="TotalAmount" HeaderText="TotalAmount" />
                                    <asp:BoundField DataField="AcToMkt" HeaderText="AcToMkt" />
                                    <asp:BoundField DataField="IsSend" HeaderText="IsSend" />
                                    <asp:BoundField DataField="SendDate" HeaderText="SendDate" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="IsReSend" HeaderText="IsReSend" />
                                    <asp:BoundField DataField="ReSendDate" HeaderText="ReSendDate" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="IsLocked" HeaderText="IsLocked" />
                                    <asp:BoundField DataField="LockedDate" HeaderText="LockedDate" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="CreateBy" HeaderText="CreateBy" />
                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" />

                                    <asp:CommandField SelectText="Edit" ShowSelectButton="true" Visible="true" ItemStyle-CssClass="btn btn-compose"
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

    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Collection");
        });
    </script>
</asp:Content>
