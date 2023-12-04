<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_MonthlyTargetEntryByTerritory.aspx.cs" Inherits="BLL.Mkt_MonthlyTargetEntryByTerritory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
      <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                   Monthly Distributor Target 
                </div> 
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="ddlCompany" runat="server" CssClass="col-md-4 control-label" Text="Company Name" />
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlCompany" runat="server" CssClass="form-control" AutoPostBack="true">
                                <asp:ListItem Value="0">--Select Company--</asp:ListItem>
                                <asp:ListItem Value="1">Al Fatah Publications</asp:ListItem>
                                <asp:ListItem Value="2">Maktabatul Fatah Bangladesh</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-md-4">Select Year</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlYear" runat="server" Width="377" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                                <asp:ListItem Text="Select Any" Value="0"></asp:ListItem>
                                <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
                                <asp:ListItem Text="2024" Value="2024"></asp:ListItem>
                                <asp:ListItem Text="2025" Value="2025"></asp:ListItem>
                                <asp:ListItem Text="2026" Value="2026"></asp:ListItem>
                                <asp:ListItem Text="2027" Value="2027"></asp:ListItem>
                                <asp:ListItem Text="2028" Value="2028"></asp:ListItem>
                                <asp:ListItem Text="2029" Value="2029"></asp:ListItem>
                                <asp:ListItem Text="2030" Value="2030"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>


                    <div class="form-group">
                        <label class="control-label col-md-4">Select Month</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlMonth" runat="server" Width="377" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                                <asp:ListItem Text="Select Any" Value="0"></asp:ListItem>
                                <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                <asp:ListItem Text="February" Value="2"></asp:ListItem>
                                <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                <asp:ListItem Text="December" Value="12"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>


                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtFromDate" CssClass="col-md-4 control-label" Text="From Date"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtFromDate" runat="server" Text="" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>


                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtToDate" CssClass="col-md-4 control-label" Text="To Date"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtToDate" runat="server" Text="" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <hr />
                    <div class="col-md-12">
                        <div class="row">
                             <div class="form-group">
                                <asp:label runat="server" AssociatedControlID="ddlTerritory" CssClass="col-md-1 control-label" Text="Territory Name"></asp:label>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlTerritory" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlTeritory_SelectedIndexChanged" TabIndex="1"></asp:DropDownList>
                                </div>
                                 <asp:label runat="server" AssociatedControlID="ddlTSO" CssClass="col-md-1 control-label" Text="TSO Name"></asp:label>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlTSO" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlTSO_SelectedIndexChanged" TabIndex="2"></asp:DropDownList>
                                </div>
                                <asp:Label runat="server" AssociatedControlID="txtSalesAmt" CssClass="col-md-1 control-label" Text="Sales Amount"></asp:Label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtSalesAmt" runat="server" CssClass="form-control" Text="" TabIndex="3"></asp:TextBox>
                                </div>
                                 <asp:Label runat="server" AssociatedControlID="txtCollecAmt" CssClass="col-md-1 control-label" Text="Collection Amount"></asp:Label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtCollecAmt" runat="server" CssClass="form-control" Text="" TabIndex="4"></asp:TextBox>
                                </div>
                                 <div class="form-group">
                                        <div class="col-md-4 col-md-offset-9">
                                            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" CssClass="btn btn-primary" TabIndex="5" style="border: 1px solid #ACD7F7"/>
                                        </div>
                                 </div>
                                </div>
                         </div>
                    </div>



                    <hr />
                    <br/>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gvLi_TargetDetail" AutoGenerateColumns="false" runat="server" CssClass="gridCss">
                                <Columns>
                                    <asp:BoundField HeaderStyle-Width="100px" HeaderText="Serial" DataField="Serial" />
                                    <asp:BoundField HeaderStyle-Width="200px" HeaderText="Territory Code" DataField="TeritoryCode" />
                                    <asp:BoundField HeaderStyle-Width="600px" HeaderText=" Territory Name " DataField="TerritoryName"/>
                                    <asp:BoundField HeaderStyle-Width="600px" HeaderText=" TSO Name " DataField="Name" />
                                    <asp:BoundField HeaderStyle-Width="400px" HeaderText=" Sales Target " DataField="SalesTar" />
                                    <asp:BoundField HeaderStyle-Width="400px" HeaderText=" Collection Target " DataField="CollecTar" />
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("Serial") %>' OnClick="lbDelete_Click">
                                              Delete
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <div class="col-md-12 col-md-offset-6">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save" OnClientClick="if (!confirm('Are You sure to save data for this Company?')) return false;" OnClick="btnSave_Click" />
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
           open_menu("Sales Target");
        });
    </script>
</asp:Content>

