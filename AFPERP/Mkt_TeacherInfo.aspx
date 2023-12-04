<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_TeacherInfo.aspx.cs" Inherits="BLL.Mkt_TeacherInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-7">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Teacher Information
                        </div>
                        <div class="panel-body">

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtPaperSl" CssClass="col-md-3 control-label no-padding-left" Text="Paper Sl"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtPaperSl" runat="server" />
                                </div>
                            </div>
                            
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtVerifyDate" CssClass="col-md-3 control-label no-padding-right" Text="Verify Date"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtVerifyDate" runat="server" CssClass="form-control" placeholder="yyyy-MM-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtVerifyDate" />
                                </div>
                            </div>
                            
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlTerritory" CssClass="col-md-3 control-label no-padding-left" Text="Territory"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlTerritory" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtTeacherName" CssClass="col-md-3 control-label no-padding-right" Text="Teacher Name"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtTeacherName" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                                                        
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlDesignation" CssClass="col-md-3 control-label no-padding-left" Text="Designation"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="">Select Any</asp:ListItem>
                                        <asp:ListItem Value="1">Asst Teacher</asp:ListItem>
                                        <asp:ListItem Value="2">Lecturer</asp:ListItem>
                                        <asp:ListItem Value="3">Asst Super</asp:ListItem>
                                        <asp:ListItem Value="4">Super</asp:ListItem>
                                        <asp:ListItem Value="5">Asst Professor</asp:ListItem>
                                        <asp:ListItem Value="6">Professor</asp:ListItem>
                                        <asp:ListItem Value="7">Principal</asp:ListItem>
                                        <asp:ListItem Value="8">Vice Principal</asp:ListItem>
                                        <asp:ListItem Value="9">Director</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtSubject" Text="Subject" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtSubject" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtClassName" Text="Class Name" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtClassName" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtMadrasahName" Text="Madrasah Name" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtMadrasahName" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtMadrasahAddress" Text="Madrasah Address" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtMadrasahAddress" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtMobileNo" Text="Mobile No" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtMobileNo" runat="server" />
                                </div>
                            </div>



       <%--                     <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtDepositedDate" CssClass="col-md-3 control-label no-padding-right" Text="Deposited Date"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtDepositedDate" runat="server" CssClass="form-control" placeholder="yyyy-MM-dd" />
                                    <ajaxToolkit:CalendarExtender runat="server" Format="yyyy-MM-dd" TargetControlID="txtDepositedDate" />
                                </div>
                            </div>--%>
                            
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtAccountTitle" Text="Account Title" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtAccountTitle" runat="server" TextMode="MultiLine" />
                                </div>
                            </div>
                            
                           
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtAccountNo" Text="Account No" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtAccountNo" runat="server" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlAccountType" CssClass="col-md-3 control-label no-padding-right" Text="Account Type"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlAccountType" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlDepositType" CssClass="col-md-3 control-label no-padding-right" Text="Deposit Type"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlDepositType" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtBankName" Text="Bank Name" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtBankName" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtBankAddress" Text="Bank Address" CssClass="col-md-3 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtBankAddress" runat="server" TextMode="MultiLine" />
                                </div>
                            </div>


                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click"/>
                                </div>
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
            open_menu("Library Information");
        });
    </script>
</asp:Content>
