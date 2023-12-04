<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="TaskWiseBookReport.aspx.cs" Inherits="BLL.TaskWiseBookReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
 <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Task Wise Book Report
                        </div>
                        <div class="panel-body">
                              <div class="form-group">
                                <asp:Label AssociatedControlID="ddlCategory" CssClass="col-md-4 control-label no-padding-right" Text="Category" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList CssClass="form-control" ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                        <asp:ListItem Value="">--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlGroup" CssClass="col-md-4 control-label no-padding-right" Text="Group" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList CssClass="form-control" ID="ddlGroup" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlClass" CssClass="col-md-4 control-label no-padding-right" Text="Class" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList CssClass="form-control" ID="ddlClass" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlType" CssClass="col-md-4 control-label no-padding-right" Text="Type" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList CssClass="form-control" ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlBookName" CssClass="col-md-4 control-label no-padding-right" Text="Book Name" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList CssClass="form-control" ID="ddlBookName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBookName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtEdition" CssClass="col-md-4 control-label no-padding-right" Text="Edition" runat="server"></asp:Label>
                                <div class="col-md-4">
                               <%-- <asp:DropDownList CssClass="form-control" ID="ddlEdition" runat="server" AutoPostBack="True">
                                    </asp:DropDownList>--%>
                                    <asp:TextBox CssClass="form-control" ID="txtEdition" runat="server"/>
                                </div>
                            </div>
                            <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlBookSize" CssClass="col-md-4 control-label" Text="Size" runat="server"></asp:Label>
                                    <div class="col-md-4">
                                        <asp:DropDownList CssClass="form-control" ID="ddlBookSize" runat="server"></asp:DropDownList>
                                    </div>
                            </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="btnShow" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                        <div class="col-md-3">
                        <asp:Button ID="btnShow" Text="Show Book" CssClass="btn btn-success" runat="server" OnClick="btnShow_OnClick"/>
                            
                        </div>
                    </div>


                             <asp:GridView ID="gvwBookInformation" CssClass="table" runat="server" Align="Center" AutoGenerateColumns="false" OnRowDataBound="gvwBookInformation_RowDataBound" OnSelectedIndexChanged="gvwBookInformation_SelectedIndexChanged" OnPageIndexChanging="gvwBookInformation_PageIndexChanging" OnRowCommand="gvwBookInformation_RowCommand">
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                       <Columns>
       
        <asp:BoundField DataField="BookID" HeaderText="Book ID" />
        <asp:BoundField DataField="BookName" HeaderText="Book Name" />
        <asp:BoundField DataField="ClassName" HeaderText="Class Name" />
        <asp:BoundField DataField="Edition" HeaderText="Edition" />
        <asp:BoundField DataField="BookSize" HeaderText="Book Size" />
        <asp:BoundField DataField="WorkPlanID" HeaderText="Work Plan ID" />
        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn" HeaderStyle-CssClass="HiddenColumn" />
        <asp:ButtonField ButtonType="Button" CommandName="Details" HeaderText="Details" Text="Details" />
    </Columns>
                                    <SelectedRowStyle BackColor="#393737" Font-Bold="true" ForeColor="#F7F7F7" />
                                </asp:GridView>
                            <asp:DropDownList ID="idPageSize" runat="server" OnSelectedIndexChanged="pageSizeChange">
    <asp:ListItem Text="5" Value="5" />
    <asp:ListItem Text="10" Value="10" />
    <asp:ListItem Text="20" Value="20" />
    <asp:ListItem Text="100" Value="100" />
</asp:DropDownList>

<asp:label ID="lblPageNo" runat="server" Text="1"></asp:label>  
 <asp:label ID="pagetext" runat="server" Text="0"></asp:label>  
 <asp:label ID="totalText" runat="server" Text=""></asp:label>  
<asp:label ID="lblTotalData" runat="server" Text="Total Instances :"></asp:label>  
<asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" />
<asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" />
                              



                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
<%--            </div>
     </div>--%>



    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSRandD" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Planning");
        });
    </script>
</asp:Content>