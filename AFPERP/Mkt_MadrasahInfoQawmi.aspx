<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_MadrasahInfoQawmi.aspx.cs" Inherits="BLL.Mkt_MadrasahInfoQawmi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="row">
                <div class="col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Employee Selection
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtWorkID" ID="lbltxtWorkID" CssClass="col-md-4 control-label no-padding-right" Text="Order No" runat="server"></asp:Label>
                                <div class="col-md-6">  
                                    <asp:TextBox CssClass="form-control" ID="txtWorkID" runat="server" ReadOnly="false"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlEmplyeeFor" CssClass="col-md-4 control-label no-padding-right" Text="Emplyee For" runat="server"></asp:Label>
                                <div class="col-md-6">   
                                    <asp:DropDownList CssClass="form-control" ID="ddlEmplyeeFor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEmployeeFor_SelectedIndexChanged">
                                          <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                          <asp:ListItem Value="1" Text="InHouse"></asp:ListItem>
                                          <asp:ListItem Value="2" Text="OutSource"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlSection" ID="lblSection" CssClass="col-md-4 control-label no-padding-right" Text="Section" runat="server"></asp:Label>
                                <div class="col-md-6">  
                                   <asp:DropDownList CssClass="form-control" ID="ddlSection" runat="server" OnTextChanged="ddlSection_TextChanged" AutoPostBack="True">
                                   </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlEmpName" CssClass="col-md-4 control-label no-padding-right" Text="Name" runat="server"></asp:Label>
                                <div class="col-md-6">  
                                   <asp:DropDownList CssClass="form-control" ID="ddlEmpName" runat="server" AutoPostBack="True" OnTextChanged="ddlEmpName_OnTextChanged">
                                   </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="dtpWorkorderDate" CssClass="col-md-4 control-label no-padding-right" Text="Work Order Issue Date" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control date" ID="dtpWorkorderDate" placeholder="yyyy-mm-dd" runat="server" />
                                    <ajaxToolkit:CalendarExtender TargetControlID="dtpWorkorderDate" Format="yyyy-MM-dd" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Book Selection
                        </div>
                        <div class="panel-body">                    
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlClass" CssClass="col-md-4 control-label no-padding-right" Text="Class" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlClass" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlBookName" CssClass="col-md-4 control-label no-padding-right" Text="Book Name" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlBookName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBookName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                    <asp:Label AssociatedControlID="ddlBookSize" CssClass="col-md-4 control-label" Text="Size" runat="server"></asp:Label>
                                    <div class="col-md-6">
                                        <asp:DropDownList CssClass="form-control" ID="ddlBookSize" runat="server"></asp:DropDownList>
                                    </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtEdition" CssClass="col-md-4 control-label no-padding-right" Text="Edition" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtEdition" runat="server"/>
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
                            <h4>Task Selection for Employee</h4>
                        </div>
                        <div class="panel-body" style="border: 1px solid #BDC3CA">
                            <div class="row">
                                <div class="col-md-4">
                                        <asp:Label AssociatedControlID="ddlTask" CssClass="control-label no-padding-left" Text="Task" runat="server"></asp:Label>
                                        <asp:DropDownList CssClass="form-control" ID="ddlTask" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTask_SelectedIndexChanged">
                                        </asp:DropDownList>
                                </div>
                              <div class="col-md-2">
                                    <asp:Label AssociatedControlID="dtpWorkDate" CssClass="control-label no-padding-left" Text="EDD" runat="server"></asp:Label>
                                    <asp:TextBox CssClass="form-control date" ID="dtpWorkDate" placeholder="yyyy-mm-dd" runat="server" />
                                    <ajaxToolkit:CalendarExtender TargetControlID="dtpWorkDate" Format="yyyy-MM-dd" runat="server" />
                              </div>                             
                              <div class="col-md-2">
                                    <asp:Label AssociatedControlID="txtFromPage" CssClass="control-label no-padding-left" Text="From Page" runat="server"></asp:Label>
                                    <asp:TextBox CssClass="form-control date" ID="txtFromPage" placeholder="Ex. 10" runat="server" AutoPostBack="True" OnTextChanged="txtTopage_TextChanged"/>
                              </div>
                              <div class="col-md-2">
                                    <asp:Label AssociatedControlID="txtToPage" CssClass="control-label no-padding-left" Text="To Page" runat="server"></asp:Label>
                                    <asp:TextBox CssClass="form-control date" ID="txtToPage" placeholder="Ex. 50" runat="server" AutoPostBack="True" OnTextChanged="txtTopage_TextChanged"/>
                              </div>
                              <div class="col-md-2">
                                    <asp:Label AssociatedControlID="txtTotalForma" ID="lblTotalForma"  CssClass="control-label no-padding-left" Text="Total Forma" runat="server"></asp:Label>
                                    <asp:TextBox CssClass="form-control date" ID="txtTotalForma" placeholder="Ex. 3" runat="server" />
                              </div>
                              <div class="col-md-2">
                                    <asp:Label AssociatedControlID="txtTotalCharacter" ID="lblTotalCharacter" CssClass="control-label no-padding-left" Text="Total Character" runat="server" Visible="false"></asp:Label>
                                    <asp:TextBox CssClass="form-control date" ID="txtTotalCharacter" placeholder="Ex. 5000" runat="server" Visible="false" />
                              </div>
                              <div class="col-md-12">
                                   <asp:Button ID="btnAdd" Text="Add" CssClass="btn btn-success btn pull-right" runat="server" OnClick="btnAdd_OnClick" />
                              </div>
                         </div>
                        <div class="row">
                            <hr style="border: 1px solid silver" />
                            <asp:GridView ID="gvDailyWorks" runat="server" AutoGenerateColumns="False" CssClass="table">
                                <Columns>
                                    <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" DataField="Serial" />
                                    <asp:BoundField HeaderStyle-Width="300px" HeaderText="Subject" DataField="Subject" />
                                    <asp:BoundField HeaderStyle-Width="300px" HeaderText="Class" DataField="Class" />
                                    <asp:BoundField HeaderStyle-Width="100px" HeaderText="Edition" DataField="Edition" />
                                    <asp:BoundField HeaderStyle-Width="300px" HeaderText="Work Type" DataField="WorkType" />
                                    <asp:BoundField HeaderStyle-Width="150px" HeaderText="EDD" DataField="WorkDate" />
                                    <asp:BoundField HeaderStyle-Width="150px" HeaderText="From Page" DataField="FromPage" /> 
                                    <asp:BoundField HeaderStyle-Width="150px" HeaderText="To Page" DataField="ToPage" />
                                    <asp:BoundField HeaderStyle-Width="150px" HeaderText="Total Page" DataField="TotalPage" />
                                    <asp:BoundField HeaderStyle-Width="150px" HeaderText="Total Forma" DataField="TotalForma" />  
                                    <asp:BoundField HeaderStyle-Width="150px" HeaderText="Total Character" DataField="TotalCharacter" />                                   

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
                        <asp:Label AssociatedControlID="txtSubTotalPage" CssClass="col-md-4 control-label" Text="Total Page" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox CssClass="form-control" ID="txtSubTotalPage" runat="server" readonly="true"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtSubTotalForma" CssClass="col-md-4 control-label" Text="Total Forma" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox CssClass="form-control" ID="txtSubTotalForma" runat="server" readonly="true"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtSubTotalCharacter" CssClass="col-md-4 control-label" Text="Total Character" runat="server"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox CssClass="form-control" ID="txtSubTotalCharacter" runat="server" readonly="true"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label AssociatedControlID="btnSave" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                        <div class="col-md-3">
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
            open_menu("");
        });
    </script>
</asp:Content>
