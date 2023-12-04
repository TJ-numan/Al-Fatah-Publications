<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_RptTeacherInfoByMadrasah.aspx.cs" Inherits="BLL.Mkt_RptTeacherInfoByMadrasah" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
<div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h4>Qawmi Teacher Information</h4>
                        </div>
                        <div class="panel-body" style="border: 1px solid #BDC3CA">
                            <div class="row">
                                <div class="col-md-3">
                                    <asp:Label AssociatedControlID="ddlTerritoryName" runat="server" CssClass="control-label no-padding-left" Text="Territory" />
                                    <asp:DropDownList ID="ddlTerritoryName" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
<%--                                <div class="col-md-1">
                                     <asp:Label AssociatedControlID="ddlDristrict" Text="Select District" CssClass="control-label no-padding-left" runat="server" Visible="false"></asp:Label>
                                     <asp:DropDownList CssClass="form-control" ID="ddlDristrict" runat="server" OnSelectedIndexChanged="ddlDristrict_SelectedIndexChanged" AutoPostBack="true" Visible="false"></asp:DropDownList>
                                 </div>
                                <div class="col-md-1">
                                    <asp:Label AssociatedControlID="ddlThana" Text="Select Thana" CssClass="control-label no-padding-left" runat="server" Visible="false"></asp:Label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlThana" runat="server" Visible="false"></asp:DropDownList>
                                </div>--%>
                                <div class="col-md-4">
                                    <asp:Label AssociatedControlID="ddlMadrasahName" ID="lblddlMadrasahName" CssClass="control-label no-padding-left" Text="Madrasah Name" runat="server"></asp:Label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlMadrasahName" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label AssociatedControlID="ddlClass" CssClass="control-label no-padding-left" Text="Class" runat="server"></asp:Label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlClass" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                    </asp:DropDownList>                      
                                </div>
                                <div class="col-md-3">
                                    <asp:Label AssociatedControlID="ddlBookName" CssClass="control-label no-padding-left" Text="Book Name" runat="server"></asp:Label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlBookName" runat="server">
                                    </asp:DropDownList>
                                </div> 
                         </div>
                         <div class="row">                    
                              <div class="col-md-6">
                                   <asp:Button ID="btnAdd" Text="Show" CssClass="btn btn-success btn pull-right" runat="server" OnClick="btnShow_OnClick" />
                                   <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-info btn pull-right" runat="server" OnClick="btnPrint_OnClick" />
                              </div>
                         </div>
                        <div class="row">
                            <hr style="border: 1px solid silver" />
                            <asp:GridView ID="gvTeacherInfo" runat="server" AutoGenerateColumns="False" CssClass="table">
                                <Columns>
                                    <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" DataField="Serial" />
                                    <asp:BoundField HeaderStyle-Width="400px" HeaderText="Madrasah Name" DataField="MadrasahName" />
                                    <asp:BoundField HeaderStyle-Width="400px" HeaderText="Subject" DataField="Subject" />
                                    <asp:BoundField HeaderStyle-Width="150px" HeaderText="Class" DataField="Class" />
                                    <asp:BoundField HeaderStyle-Width="400px" HeaderText="Teacher Name" DataField="TeacherName" />
                                    <asp:BoundField HeaderStyle-Width="250px" HeaderText="Mobile" DataField="Mobile" />                                    
                                    <asp:BoundField HeaderStyle-Width="150px" HeaderText="Territory" DataField="Territory" />
                                    <asp:BoundField HeaderStyle-Width="150px" HeaderText="Thana" DataField="Thana" />                                  
                                </Columns>
                            </asp:GridView>
                            <hr style="border: 1px solid silver" />
                        </div>
                       </div>
                  </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Teacher Info");
        });
    </script>
</asp:Content>
