<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_TeacherInfoByMadrasah.aspx.cs" Inherits="BLL.Mkt_TeacherInfoByMadrasah" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                           Qawmi Madrasah Information 
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtEntryNo" ID="lbltxtEntryNo" CssClass="col-md-4 control-label no-padding-right" Text="Entry No" runat="server"></asp:Label>
                                <div class="col-md-4">  
                                    <asp:TextBox CssClass="form-control" ID="txtEntryNo" runat="server" ReadOnly="false"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlTSOName" runat="server" CssClass="col-md-4 control-label no-padding-right" Text="TSO Name" />
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlTSOName" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                 <asp:Label AssociatedControlID="ddlDristrict" Text="Select District" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                 <div class="col-md-4">
                                      <asp:DropDownList CssClass="form-control" ID="ddlDristrict" runat="server" OnSelectedIndexChanged="ddlDristrict_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                 </div>
                             </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlThana" Text="Select Thana" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                <div class="col-md-4">
                                     <asp:DropDownList CssClass="form-control" ID="ddlThana" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtMadrasahName" ID="lbltxtMadrasahName" CssClass="col-md-4 control-label no-padding-right" Text="Madrasah Name" runat="server"></asp:Label>
                                <div class="col-md-6">  
                                    <asp:TextBox CssClass="form-control" ID="txtMadrasahName" runat="server" ReadOnly="false"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtMadrasahAddress" ID="lbltxtMadrasahAddress" CssClass="col-md-4 control-label no-padding-right" Text="Madrasah Address" runat="server"></asp:Label>
                                <div class="col-md-6">  
                                    <asp:TextBox CssClass="form-control" ID="txtMadrasahAddress" runat="server" ReadOnly="false"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h4>Book and Teacher Information</h4>
                        </div>
                        <div class="panel-body" style="border: 1px solid #BDC3CA">
                            <div class="row">
                                <div class="col-md-2">
                                    <asp:Label AssociatedControlID="ddlClass" CssClass="control-label no-padding-left" Text="Class" runat="server"></asp:Label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlClass" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                    </asp:DropDownList>                      
                                </div>
                                <div class="col-md-4">
                                    <asp:Label AssociatedControlID="ddlBookName" CssClass="control-label no-padding-left" Text="Book Name" runat="server"></asp:Label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlBookName" runat="server">
                                    </asp:DropDownList>
                                </div>                             
                              <div class="col-md-4">
                                    <asp:Label AssociatedControlID="txtTeacherName" CssClass="control-label no-padding-left" Text="Teacher Name" runat="server"></asp:Label>
                                    <asp:TextBox CssClass="form-control" ID="txtTeacherName" placeholder="Teacher Name" runat="server" />
                              </div>
                              <div class="col-md-2">
                                    <asp:Label AssociatedControlID="txtMobileNo" CssClass="control-label no-padding-left" Text="Mobile Number" runat="server"></asp:Label>
                                    <asp:TextBox CssClass="form-control" ID="txtMobileNo" placeholder="Mobile" runat="server" />
                              </div>
                              <div class="col-md-12">
                                   <asp:Button ID="btnAdd" Text="Add" CssClass="btn btn-success btn pull-right" runat="server" OnClick="btnAdd_OnClick" />
                              </div>
                         </div>
                        <div class="row">
                            <hr style="border: 1px solid silver" />
                            <asp:GridView ID="gvTeacherInfo" runat="server" AutoGenerateColumns="False" CssClass="table">
                                <Columns>
                                    <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" DataField="Serial" />
                                    <asp:BoundField HeaderStyle-Width="400px" HeaderText="Subject" DataField="Subject" />
                                    <asp:BoundField HeaderStyle-Width="300px" HeaderText="Class" DataField="Class" />
                                    <asp:BoundField HeaderStyle-Width="500px" HeaderText="Teacher Name" DataField="TeacherName" />
                                    <asp:BoundField HeaderStyle-Width="250px" HeaderText="Mobile" DataField="Mobile" />                                
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lblDelete" OnClick="lblDelete_OnClick" runat="server" CommandArgument='<%#Eval("Serial") %>'>
                                                                       Delete
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <hr style="border: 1px solid silver" />
                        </div>
                       </div>
                  </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="btnSave" CssClass="col-md-6 control-label" runat="server"></asp:Label>
                        <div class="col-md-6">
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_OnClick" />
                            <asp:Button ID="btnPrint" Text="Print" CssClass="btn btn-info" runat="server" OnClick="btnPrint_OnClick" />
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

