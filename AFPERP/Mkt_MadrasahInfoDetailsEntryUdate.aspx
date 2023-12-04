<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_MadrasahInfoDetailsEntryUdate.aspx.cs" Inherits="BLL.Mkt_MadrasahInfoDetailsEntryUdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
      <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Madrasah Information Details Update
                </div>
                <div class="panel-body"> 
                    <div class="form-group">
                        <asp:Label AssociatedControlID="txteiin" runat="server" CssClass="col-md-2 control-label no-padding-right" Text="Search by EIIN" />
                        <div class=" col-md-3">
                            <asp:Textbox ID="txteiin" runat="server" CssClass="form-control"></asp:Textbox>
                        </div>
                    </div>

                   <%-- <div class="form-group">
                        <div class="col-md-8 col-md-offset-4">--%>
                            <asp:Button ID="btnShow" Text="Show for Update" CssClass="btn btn-info" runat="server" OnClick="btnShow_Click" />
                           
                     <%--   </div>
                    </div>--%>
                </div>
                <!--------Start Of Mr Gridview-------->
                <div class="panel-body">
                        <div class="table-responsive table-bordered clearfix ">
                            <asp:GridView ID="gvMRSheetDetailsUpdate" CssClass="table " runat="server" AutoGenerateColumns="false" OnRowDataBound="gvMRSheetDetailsUpdate_RowDataBound">
                                <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="SL No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="EIIN" HeaderText="EIIN" />
                                    <asp:BoundField DataField="MadName" HeaderText="MadName" />
                                    <asp:BoundField DataField="TeritoryName" HeaderText="Teritory"/>
                                    <asp:BoundField DataField="ThanaID" HeaderText="ThId" Visible="true"/> 
                                    <asp:BoundField DataField="Upazilla" HeaderText="Upazilla" />                                   
                                    <asp:BoundField DataField="DevelopedLevel" HeaderText="DI" />               
                                    
                                    <asp:TemplateField HeaderText="Inst. Level">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlInstLevel" runat="server" OnSelectedIndexChanged="ddlInstLevel_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name of Principal">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPrincipalName" runat="server" data-field="pro-rate" CssClass="click pro-rate" Text='<%# Bind("PrinName") %>' Width="110px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact Number">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtContactNo" runat="server" data-field="pro-rate" CssClass="click pro-rate" Text='<%# Bind("PrinCont") %>' Width="90px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="CL-1">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCL1" runat="server" data-field="pro-rate" CssClass="click pro-rate" Text='<%# Bind("1") %>' Width="30px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CL-2">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCL2" runat="server" data-field="pro-rate" CssClass="click pro-rate" Text='<%# Bind("2") %>' Width="30px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CL-3">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCL3" runat="server" data-field="pro-rate" CssClass="click pro-rate" Text='<%# Bind("3") %>' Width="30px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="CL-4">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCL4" runat="server" data-field="pro-rate" CssClass="click pro-rate" Text='<%# Bind("4") %>' Width="30px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CL-5">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCL5" runat="server" data-field="pro-rate" CssClass="click pro-rate" Text='<%# Bind("5") %>' Width="30px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="CL-6">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCL6" runat="server" data-field="pro-rate" CssClass="click pro-rate" Text='<%# Bind("6") %>' Width="30px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CL-7">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCL7" runat="server" data-field="pro-rate" CssClass="click pro-rate" Text='<%# Bind("7") %>' Width="30px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CL-8">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCL8" runat="server" data-field="pro-rate" CssClass="click pro-rate" Text='<%# Bind("8") %>' Width="30px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CL-9">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCL9" runat="server" data-field="pro-rate" CssClass="click pro-rate" Text='<%# Bind("9") %>' Width="30px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CL-10">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCL10" runat="server" data-field="pro-rate" CssClass="click pro-rate" Text='<%# Bind("10") %>' Width="30px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CL-AL1">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCLAL1" runat="server" data-field="pro-rate" CssClass="click pro-rate" Text='<%# Bind("11") %>' Width="30px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CL-AL2">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCLAL2" runat="server" data-field="pro-rate" CssClass="click pro-rate" Text='<%# Bind("12") %>' Width="30px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FZ(1-3)">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFZ1to3" runat="server" data-field="pro-rate" CssClass="click pro-rate" Text='<%# Bind("13") %>' Width="30px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="KM(1-2)">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtKM1to2" runat="server" data-field="pro-rate" CssClass="click pro-rate" Text='<%# Bind("14") %>' Width="30px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="No.T EB">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNoTEB" runat="server" data-field="pro-rate" CssClass="click pro-rate"  Text='<%# Bind("E") %>'  Width="30px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No.T DH">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNoTDH" runat="server" data-field="pro-rate" CssClass="click pro-rate"  Text='<%# Bind("D") %>'  Width="30px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No.T AL">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNoTAL" runat="server" data-field="pro-rate" CssClass="click pro-rate"  Text='<%# Bind("A") %>'  Width="30px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No.T FZ">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNoTFZ" runat="server" data-field="pro-rate" CssClass="click pro-rate"  Text='<%# Bind("F") %>'  Width="30px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cont. With">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtContactWith" runat="server" data-field="pro-rate" CssClass="click pro-rate"  Text='<%# Bind("AgreementWith") %>'  Width="40px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRemarks" runat="server" data-field="pro-rate" CssClass="click pro-rate"  Text='<%# Bind("Remarks") %>'  Width="60px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <SelectedRowStyle BackColor="#F4B6B6" Font-Bold="true" ForeColor="#110101" />
                            </asp:GridView>
                        </div>
                        <br />
                    </div>



                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="col-md-6">
                            </div>
                            <div class="col-md-6">                      
<%--                                <div class="form-group">
                                    <asp:Label AssociatedControlID="txtRemarks" Text="Remarks" CssClass="col-md-4 control-label no-padding-right" runat="server"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox CssClass="form-control" ID="txtRemarks" runat="server" />
                                    </div>
                                </div>--%>
                                
                                <div class="form-group">
                                    <div class="col-md-6 col-md-offset-4">
                                        <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-success" runat="server" OnClick="btnUpdate_Click"/>
                                        &nbsp;&nbsp;&nbsp; 
                                    </div>
                                </div>
                            </div>
                        </div>
                  </div>
                <!--------End Of Mr Gridview-------->
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
      <script type="text/javascript">
          $(document).ready(function () {
              open_menu("Madrasah");
          });
    </script>
</asp:Content>
