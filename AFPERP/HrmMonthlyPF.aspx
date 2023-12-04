<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.master" AutoEventWireup="true" CodeBehind="HrmMonthlyPF.aspx.cs" Inherits="BLL.HrmMonthlyPF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HRContent" runat="server">
      <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    View Monthly PF Report
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="dtpDateofMonth" CssClass="col-md-4 control-label" Text="Date of Month" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox CssClass="form-control date" ID="dtpDateofMonth" placeholder="yyyy-mm-dd" runat="server" />
                            <ajaxToolkit:CalendarExtender TargetControlID="dtpDateofMonth" Format="yyyy-MM-dd" runat="server" />
                        </div>
                    </div>



                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlYear" CssClass="col-md-4 control-label" Text="Year" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:DropDownList CssClass="form-control date" ID="ddlYear"  runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                 
                            </asp:DropDownList>
                             
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlMonth" CssClass="col-md-4 control-label" Text="Month" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:DropDownList CssClass="form-control date" ID="ddlMonth"  runat="server" >
             
                            </asp:DropDownList>
                             
                        </div>
                    </div>


                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlUnitType" CssClass="col-md-4 control-label" Text="Unit Type" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:DropDownList CssClass="form-control date" ID="ddlUnitType"  runat="server" >
                 
                            </asp:DropDownList>
                             
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">
                            <asp:Button ID="btnShow" Text="Show" CssClass="btn btn-info" runat="server" OnClick="btnShow_Click" />

                            <asp:Button ID="btnConvertXML" Text="Convert XML" CssClass="btn btn-info" runat="server"  OnClick="btnConvertXML_Click"/>

                            <asp:Button ID="DownloadXML" Text="Download XML" CssClass="btn btn-info" runat="server" OnClick="DownloadXML_Click"/>
                        </div>
                    </div>

                    <div class="panel-body">
                        <div class="table-responsive table-bordered clearfix ">
                            <asp:GridView ID="gvwMonthlyPF" CssClass="table " runat="server" AutoGenerateColumns="false">
                                <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                <Columns>

                                    <%--<asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" DataFormatString="{0:yyyy-MM-dd}" />--%>
                                    <asp:BoundField DataField="EmployeeCode" HeaderText="EmployeeID" />
                                    <asp:BoundField DataField="EmployeeName" HeaderText="EmployeeName" />
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" />
                      

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
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSHR" runat="server">
        <script type="text/javascript">
            $(document).ready(function () {
                open_menu("Payroll Management");
            });
    </script>
</asp:Content>
