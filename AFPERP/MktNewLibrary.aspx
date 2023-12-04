<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" EnableViewState="true" AutoEventWireup="true" CodeBehind="MktNewLibrary.aspx.cs" Inherits="BLL.MktNewLibrary" %>

<%@ Import Namespace="Common.Marketing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <link rel="stylesheet" type="text/css" href="assets/bootstrap-fileupload/bootstrap-fileupload.css" />
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-reset.css" rel="stylesheet" />
    <!--external css-->
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="assets/fancybox/source/jquery.fancybox.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="css/gallery.css" />
    <!-- Custom styles for this template -->
    <link href="css/style.css" rel="stylesheet">
    <link href="css/style-responsive.css" rel="stylesheet" />
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Create New Library
                </div>
                <div class="panel-body">



                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group" >
                                <asp:Label AssociatedControlID="txtLibraryID" Text="Library ID" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtLibraryID" runat="server" ReadOnly="True" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtUniqueCode" Text="Unique Code" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtUniqueCode" runat="server" placeholder="Unique Code"/>
                                </div>
                            </div>

                            <div class="form-group" style="margin-top:6px">
                                <asp:Label AssociatedControlID="txtTradeLicense" Text="Trade License" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtTradeLicense" runat="server" placeholder="Trade License"/>
                                </div>
                            </div>

                                                       <div class="form-group" style="margin-top:6px">
                                <asp:Label AssociatedControlID="txtBapusCardNo" Text="BAPUS Card No" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtBapusCardNo" runat="server" placeholder="Bapus Card No"/>
                                </div>
                            </div>
                            <div class="form-group" style="margin-top:6px">
                                <asp:Label AssociatedControlID="txtLibraryName" Text="Library Name" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtLibraryName" runat="server" placeholder="Library Name" />
                                </div>
                            </div>
                                 <div class="form-group" style="margin-top:6px">
                                <asp:Label AssociatedControlID="txtShortAddress" Text="Short Address" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtShortAddress" runat="server" placeholder="Short Address"/>
                                </div>
                            </div>

<div class="form-group" style="margin-top:6px">
    <asp:Label AssociatedControlID="txtLibraryAddress" Text="Details Address" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
    <div class="col-md-6">
        <asp:TextBox CssClass="form-control" ID="txtLibraryAddress" runat="server" placeholder="Details Address"/>
    </div>
</div>

                                                        <div class="form-group" style="margin-top:6px">
                                <asp:Label AssociatedControlID="txtLibraryNameB" CssClass="col-md-3 control-label bangla-font" Text="jvB‡eªixi bvg  " runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control bangla-font" ID="txtLibraryNameB" placeholder="jvB‡eªixi bvg " Font-Names="SutonnyMJ" runat="server" />
                                </div>
                            </div>
                            <div class="form-group" style="margin-top:6px">
                                <asp:Label AssociatedControlID="txtShortAddressB" CssClass="col-md-3 control-label bangla-font" Text="mswÿß wVKvbv " runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control bangla-font" ID="txtShortAddressB" placeholder="mswÿß wVKvbv" Font-Names="SutonnyMJ" runat="server" />
                                </div>
                            </div>
                            <div class="form-group" style="margin-top:6px">
                                <asp:Label AssociatedControlID="txtLibraryAddressB" Text="wemÍvwiZ wVKvbv" CssClass="col-md-3 control-label bangla-font" Font-Names="SutonnyMJ" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control bangla-font" ID="txtLibraryAddressB" Font-Names="SutonnyMJ" placeholder="wemÍvwiZ wVKvbv" runat="server" />
                                </div>
                            </div>


                            <div class="form-group" style="margin-top:6px">
    <asp:Label AssociatedControlID="textBuldingName" Text="Building Name" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
    <div class="col-md-6">
        <asp:TextBox CssClass="form-control" ID="textBuldingName" runat="server" placeholder="Name of the Building"/>
    </div>
</div>

                             <div class="form-group" style="margin-top:6px">
                                <asp:Label AssociatedControlID="textholdingNo" Text="Holding Number" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="textholdingNo" runat="server" placeholder="Holding Number"/>
                                </div>
                            </div>
                            <div class="form-group" style="margin-top:6px">
    <asp:Label AssociatedControlID="txtShopNumber" Text="Shop Number" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
    <div class="col-md-6">
        <asp:TextBox CssClass="form-control" ID="txtshopNumber" runat="server" placeholder="Shop Number"/>
        
        <div class="row" style="margin-top: 10px; margin-bottom: 20px;">
            <div class="col-md-6">
                <asp:Label CssClass="control-label" Text="Own Shop" runat="server" Font-Bold="true"></asp:Label>
               <asp:CheckBox ID="rbtnOwnShop" CssClass="checkbox pull-left" runat="server" />
            </div>
  
        </div>
    </div>
</div>
  <div class="form-group" style="margin-top:6px">
                                <asp:Label AssociatedControlID="txtMarketName" Text="Bazaar" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtMarketName" runat="server" placeholder="Bazaar Name"/>
                                </div>
                            </div>
                            
                                 <div class="form-group" style="margin-top:6px">
                                <asp:Label AssociatedControlID="txtPostOffice" Text="Post Office" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtPostOffice" runat="server" placeholder="Post Office"/>
                                </div>
                            </div>
                                    <div class="form-group" style="margin-top:6px">
                                        <asp:Label AssociatedControlID="ddlDristrict" Text="District" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList CssClass="form-control" ID="ddlDristrict" runat="server" OnSelectedIndexChanged="ddlDristrict_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group" style="margin-top:6px">
                                        <asp:Label AssociatedControlID="ddlThana" Text="Thana" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList CssClass="form-control" ID="ddlThana" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group" style="margin-top:6px">
                                        <asp:Label AssociatedControlID="ddlTerritory" CssClass="col-md-3 control-label" Text="Territory" runat="server" Font-Bold="true"></asp:Label>
                                        <div class="col-md-6">
                                            <asp:DropDownList CssClass="form-control" ID="ddlTerritory" runat="server" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                <div class="form-group" style="margin-top:6px">
                                <asp:Label AssociatedControlID="txtPhoneNo" Text="Phone No" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtPhoneNo" runat="server" placeholder="Phone No"/>
                                </div>
                            </div>

                             <div class="form-group" style="margin-top:6px">
                                 <asp:Label AssociatedControlID="txtEmail" CssClass="col-md-3 control-label" Text="Email" runat="server" Font-Bold="true"></asp:Label>
                                 <div class="col-md-6">
                                      <asp:TextBox CssClass="form-control" ID="txtEmail" placeholder="Email ID" runat="server" />
                                 </div>
                            </div>

                           <div class="form-group" style="margin-top:6px">
                                <asp:Label AssociatedControlID="ddlType" Text="Agent Type" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlType" runat="server">
                                        <asp:ListItem>--Select Nature--</asp:ListItem>
                                        <asp:ListItem Value="1">Whole Seller</asp:ListItem>
                                        <asp:ListItem Value="2">Retailer</asp:ListItem>
                                        <asp:ListItem Value="3">Both</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group" style="margin-top:6px">
    <asp:Label AssociatedControlID="textSustainability" Text="Library Oldness" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
    <div class="col-md-6">
        <asp:TextBox CssClass="form-control" ID="textSustainability" runat="server" placeholder="Enter number of years" />
    </div>
</div>

 <div class="form-group"  style="margin-top:6px">
     <asp:Label AssociatedControlID="chkGodown" Text="Have Godown" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
  <%--  <label class="col-md-3 control-label">Have Godown</label>--%>
    <div class="col-md-6">
        <asp:CheckBox ID="chkGodown" runat="server" AutoPostBack="true" OnCheckedChanged="chkGodown_CheckedChanged" />
    </div>
</div>
<div class="form-group"  style="margin-top:6px">
     <asp:Label AssociatedControlID="textSquirefoot" Text="Square feet" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
    <%--<label class="col-md-3 control-label">Square feet</label>--%>
    <div class="col-md-6">
        <asp:TextBox CssClass="form-control" ID="textSquirefoot" runat="server" placeholder="Godown size" />
    </div>
</div>
                                  <div class="form-group"  style="margin-top:6px">
                                <asp:Label AssociatedControlID="txtAddressforGettingBook" Text="Delivery Address" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtAddressforGettingBook" runat="server" placeholder="Address for reciving Book"/>
                                </div>
                            </div>
                                                       <div class="form-group" style="margin-top:6px">
                                 <asp:Label AssociatedControlID="ddlTransportMain" Text="Transport Name" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                 <div class="col-md-6">
                                      <asp:DropDownList CssClass="form-control" ID="ddlTransportMain" AutoPostBack="false" runat="server" />
                                 </div>
                           </div>
                           <div class="form-group" style="margin-top:6px">
                                 <asp:Label AssociatedControlID="ddlTransportAlter" Text="Alternate Transport" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                 <div class="col-md-6">
                                      <asp:DropDownList CssClass="form-control" ID="ddlTransportAlter" AutoPostBack="false" runat="server" />
                                 </div>
                           </div>
                                                                                   <div class="form-group" style="margin-top:6px">
                                <asp:Label AssociatedControlID="DeliveryType" Text="Delivery Type" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="DeliveryType" runat="server">
                                        <asp:ListItem>--Select Delivery Type--</asp:ListItem>
                                        <asp:ListItem Value="1">Office Delivery</asp:ListItem>
                                        <asp:ListItem Value="2">Home Delivery</asp:ListItem>
                                        <asp:ListItem Value="3">Hand to Hand</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            





                          <%--  added by Numan--%>






                        </div>



                        <div class="col-md-6">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>


                                </ContentTemplate>
                            </asp:UpdatePanel>

                                                                 <div class="form-group" style="margin-top:20px">
                                        <asp:Label AssociatedControlID="ddlOrganization" Text="Agent of Other Organization" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                        <div class="col-md-6">
                                           <asp:DropDownList CssClass="form-control" ID="ddlOrganization" runat="server" OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged" AutoPostBack="true" EnableViewState="true"></asp:DropDownList>

                                             </div>
                                    </div>

 <asp:GridView ID="gvwOrganization" CssClass="table" runat="server" Align="Center" AutoGenerateColumns="false" EnableViewState="true">
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                     
                                      
                                        <asp:BoundField DataField="Organization" HeaderText="Organization" />
                                        <asp:BoundField DataField="ID" HeaderText="ID" />
                                        <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("Serialorg") %>' OnClick="lbDelete_ClickOrganization">
                                                 Delete
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                  
                                    </Columns>
                                    <SelectedRowStyle BackColor="#393737" Font-Bold="true" ForeColor="#F7F7F7" />
                                </asp:GridView>
                                                        <div class="form-group" style="margin-top:20px">
                                <asp:Label AssociatedControlID="txtLibraryOwnerName" Text="Library Owner Name" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtLibraryOwnerName" runat="server"  placeholder="Library Owner Name"/>
                                </div>
                            </div>

                              <div class="form-group" style="margin-top:6px">
                                <asp:Label AssociatedControlID="txtLibraryOwnerPresentAddress" Text="Present Address" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtLibraryOwnerPresentAddress" runat="server"  placeholder="Owner Present Address"/>
                                </div>
                            </div>

                              <div class="form-group" style="margin-top:6px">
                                <asp:Label AssociatedControlID="txtLibraryOwnerPermanentAddress" Text="Permanent Address" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtLibraryOwnerPermanentAddress" runat="server"  placeholder="Owner Permanent Address"/>
                                </div>
                            </div>

                                                          <div class="form-group" style="margin-top:6px">
                                <asp:Label AssociatedControlID="txtEducationalQualification" Text="Educational Qualification" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtEducationalQualification" runat="server"  placeholder="SSC/HSC/MA/BA"/>
                                </div>
                            </div>

                           
                            <div class="form-group" style="margin-top:6px">
                                <asp:Label AssociatedControlID="txtNID" Text="NID" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtNID" runat="server" placeholder="NID"/>
                                </div>
                            </div>

                            
                             <div class="form-group" style="margin-top:6px">
                               <asp:Label AssociatedControlID="Ownership" Text="Ownership Rights" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                               <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="Ownership" runat="server">
                                        <asp:ListItem>--Select Ownership Right--</asp:ListItem>
                                        <asp:ListItem Value="1">Inherited</asp:ListItem>
                                        <asp:ListItem Value="2">Self Stablished</asp:ListItem>
                                        <asp:ListItem Value="3">Purchased</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                                                      <div class="form-group" style="margin-top:20px">
    <asp:Label AssociatedControlID="txtPartnership" Text="Partnership" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
    <div class="col-md-6">
        <asp:TextBox CssClass="form-control" ID="txtPartnership" runat="server" placeholder="input only number" onkeypress="return isNumberKey(event)" />
    </div>
</div>


                            <div class="form-group" style="margin-top:20px">
                                <asp:Label AssociatedControlID="txtresponsiblePersonName" Text="Responsible Person Name" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtresponsiblePersonName" runat="server" placeholder="Responsible person name in absence of owner"/>
                                </div>
                            </div>

         <div class="form-group" style="margin-top:6px">
                                <asp:Label AssociatedControlID="txtRpPhoneNo" Text="Responsible Person Phone" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtRpPhoneNo" runat="server" placeholder="Responsible Person Phone No"/>
                                </div>
                            </div>

<div class="form-group" style="margin-top:20px">
    <div class="col-md-11.5" style="margin-top:20px">
    <asp:Label Text="Associated Person" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
    <div class="col-md-6">
        <div class="row" id="firstSet">
            <div class="col-md-6">
                <asp:TextBox CssClass="form-control" ID="AssociateName" runat="server" placeholder="Name"/>
            </div>
            <div class="col-md-6">
                <asp:TextBox CssClass="form-control" runat="server" ID="AssociateResponisbility" placeholder="Responisibility"/>
            </div>
            <div class="col-md-6" style="margin-top:6px; margin-bottom:8px">
                        
                <asp:TextBox CssClass="form-control" runat="server" ID="AssociatePhone" placeholder="Phone Number"/>
            
                </div>
        </div>
        <asp:Button ID="AddAnother" Text="Add Associate" CssClass="btn btn-primary" runat="server" OnClick="btn_addanother"/>
    </div>
</div>
    </div>
<div class="col-md-12" style="margin-top:10px; margin-bottom:6px">
                                     <asp:GridView ID="gvwAssociate" CssClass="table" runat="server" Align="Center" AutoGenerateColumns="false" EnableViewState="true">
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                     

                                        <asp:BoundField DataField="NameAssociate" HeaderText="Name" />
                                        <asp:BoundField DataField="ResponsiblityAssociate" HeaderText="Responsibility" />
                                        <asp:BoundField DataField="PhoneAssociate" HeaderText="Phone" />
                                        <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                         <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("Serial") %>' OnClick="lbDelete_Click">
                                                 Delete
                                                    </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                  
                                    </Columns>
                                    <SelectedRowStyle BackColor="#393737" Font-Bold="true" ForeColor="#F7F7F7" />
                                </asp:GridView>
    </div>
    <div class="form-group" style="margin-top:20px">
    <asp:Label Text="Deposit on Opening" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
    <div class="col-md-6">
        <div class="row" id="thirdset">
            <div class="col-md-6">
                <asp:TextBox CssClass="form-control" ID="AmountofMoney" runat="server" placeholder="Deposit Amount"/>
            </div>
            <div class="col-md-6">
                <asp:TextBox CssClass="form-control" runat="server" ID="MoneyInWord" placeholder="In Word"/>
            </div>
            <div class="col-md-8" style="margin-top:6px">
                        
                                               
                                    <asp:DropDownList CssClass="form-control" ID="WayofPayment" runat="server">
                                        <asp:ListItem>--Payment Mode--</asp:ListItem>
                                        <asp:ListItem Value="1">Cash</asp:ListItem>
                                        <asp:ListItem Value="2">Online</asp:ListItem>
                                        <asp:ListItem Value="3">Cheque</asp:ListItem>
                                    </asp:DropDownList>
                          
            
                </div>
        </div>
       
    </div>
</div>


<div class="form-group" style="margin-top:20px">
     <div class="col-md-15" style="margin-top:20px">
    <asp:Label Text="Bank Information" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
    <div class="col-md-6">
        <div class="row" id="SecondSet">
            <div class="col-md-6">
                <asp:TextBox CssClass="form-control" ID="BankName" runat="server" placeholder="Bank Name"/>
            </div>
            <div class="col-md-6">
                <asp:TextBox CssClass="form-control" runat="server" ID="BankBranch" placeholder="Branch"/>
            </div>
            <div class="col-md-6" style="margin-top:6px; margin-bottom:8px">
                        
                <asp:TextBox CssClass="form-control" runat="server" ID="BankAccount" placeholder="Account No"/>
            
                </div>
            <div class="col-md-6" style="margin-top:6px; margin-bottom:8px">
                        
                <asp:TextBox CssClass="form-control" runat="server" ID="BankType" placeholder="Account Type"/>
            
                </div>
        </div>
        <asp:Button ID="AddBank" Text="Add Bank" CssClass="btn btn-primary" runat="server" OnClick="btn_AddBank" />
    </div>
</div>
    </div>
                            <div class="col-md-12" style="margin-top:10px; margin-bottom:6px">
                                     <asp:GridView ID="grvwBank" CssClass="table" runat="server" Align="Center" AutoGenerateColumns="false" EnableViewState="true">
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                     

                                        <asp:BoundField DataField="BankName" HeaderText="BankName" />
                                        <asp:BoundField DataField="BankBranch" HeaderText="BankBranch" />
                                        <asp:BoundField DataField="BankAccount" HeaderText="BankAccount" />
                                        <asp:BoundField DataField="BankType" HeaderText="BankType" />
                                        <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("Serialbnk") %>' OnClick="lbDelete_ClickBank">
                                                 Delete
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                  
                                    </Columns>
                                    <SelectedRowStyle BackColor="#393737" Font-Bold="true" ForeColor="#F7F7F7" />
                                </asp:GridView>

                                 </div>
               








                            <div class="form-group" style="margin-top:20px">
                                <asp:Label AssociatedControlID="ddlCategory" Text="Category" CssClass="col-md-3 control-label" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlCategory" runat="server">
                                        <asp:ListItem>--Select Category--</asp:ListItem>
                                        <asp:ListItem>A</asp:ListItem>
                                        <asp:ListItem>B</asp:ListItem>
                                        <asp:ListItem>C</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>



                                                       


                       


                            <div class="form-group" style="margin-top:20px">
                                <asp:Label CssClass="col-md-3 control-label" Text="Qawmi Status" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:CheckBox ID="chkIsQawmi" CssClass="checkbox pull-left" runat="server" />
                                </div>
                            </div>
                            <div class="form-group" style="margin-top:5px">
                                <asp:Label CssClass="col-md-3 control-label" Text="Both Status" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:CheckBox ID="chkIsBoth" CssClass="checkbox pull-left" runat="server" />
                                </div>
                            </div>
                            <div class="form-group" style="margin-top:5px">
                                <asp:Label CssClass="col-md-3 control-label" Text="SMS Status" runat="server" Font-Bold="true"></asp:Label>
                                <div class="col-md-6">
                                    <asp:CheckBox ID="chkIsSMS" CssClass="checkbox pull-left" runat="server" />
                                </div>
                               
                            </div>

                              <div class="form-group" style="margin-top:20px">
                                <div class="col-md-9 col-md-offset-0">
                           

                               </div>
                            </div>

                             <div class="form-group" style="margin-top:20px">
                                <div class="col-md-5 col-md-offset-0">
                           
                               </div>
                            </div>
                  

<div class="form-group" style="margin-top:20px">
    <div class="col-md-2">
        <asp:Button ID="btnLibrarySave" Text="Save" CssClass="btn btn-primary" runat="server" OnClick="btnLibrarySave_Click"/>
    </div>
    <div class="col-md-2">
        <asp:Button ID="btnReport" Text="Go to Report" CssClass="btn-warning" runat="server" OnClick="libraryReport" Height="34px" />
    </div>
    <div class="col-md-2">
        <asp:Button ID="btnLibraryUpdate" Text="Update" CssClass="btn btn-success pull-right" runat="server" OnClick="btnLibraryUpdate_Click" />
    </div>
</div>

                        </div>
                    </div>


                    <div class="panel-body">
                        <div class="form-group" style="margin-top:20px">
                            <div class="col-md-10">
                                <div class="search-input">
                                    <i class="icon-search"></i>
                                    <asp:TextBox CssClass="form-control" ID="txtSearchLibraryName" runat="server" Placeholder="Search" AutoPostBack="True" OnTextChanged="txtSearchLibraryName_TextChanged" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 table table-responsive">
                                <%-- <div class="panel panel-success">
                                    <div class="panel-body">
                                        <% List<LibraryInformation> information = li_LibraryInformationManager.GetALLLibraryInformation(); %>
                                        <table class="table table-advance " id="LibraryTable">
                                            <thead>
                                                <tr class="danger">
                                                    <th>Id</th>
                                                    <th>Library Name</th>
                                                    <th>LibraryAddress</th>
                                                    <th>Phone</th>
                                                    <th>Region</th>
                                                    <th>Division</th>
                                                    <th>Zone</th>
                                                    <th>Teritory</th>
                                                    <th>District</th>
                                                    <th>Thana</th>
                                                    <th>Action</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <%
                                                    foreach (var info in information)
                                                    {%>
                                                <tr>
                                                    <td><%=info.LibraryID %></td>
                                                    <td><%=info.LibraryName %></td>
                                                    <td><%=info.LibraryAddress %></td>
                                                    <td><%= info.Telephone %></td>
                                                    <td><%= info.RegionName %></td>
                                                    <td><%= info.DivName %></td>
                                                    <td><%= info.ZoneName %></td>
                                                    <td><%= info.TerritoryName %></td>
                                                    <td><%= info.DistrictName %></td>
                                                    <td><%= info.ThanaName %></td>
                                                    <td>
                                                        <a href="" class="btn btn-default">Edit</a>
                                                    </td>
                                                </tr>

                                                <%}
                                                
                                                %>
                                            </tbody>
                                            <tfoot>
                                                <tr class="danger">
                                                    <th>Id</th>
                                                    <th>Library Name</th>
                                                    <th>LibraryAddress</th>
                                                    <th>Phone</th>
                                                    <th>Region</th>
                                                    <th>Division</th>
                                                    <th>Zone</th>
                                                    <th>Teritory</th>
                                                    <th>District</th>
                                                    <th>Thana</th>
                                                    <th>Action</th>
                                                </tr>
                                            </tfoot>
                                        </table>
                                    </div>

                                </div>--%>

                                



                                <asp:GridView ID="gvwLibraryInformation" CssClass="table" runat="server" Align="Center" AutoGenerateColumns="false" OnRowDataBound="gvwLibraryInformation_RowDataBound" OnSelectedIndexChanged="gvwLibraryInformation_SelectedIndexChanged" OnPageIndexChanging="gvwLibraryInformation_PageIndexChanging">
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="true" ItemStyle-CssClass="HiddenColumn"
                                            HeaderStyle-CssClass="HiddenColumn" />
                                 <%--       <asp:BoundField DataField="sl" HeaderText="sl" />--%>
                                        <asp:BoundField DataField="Edit" HeaderText="LibraryId" />
                                        <asp:BoundField DataField="LibraryName" HeaderText="LibraryName" />
                                        <asp:BoundField DataField="ShortAddress" HeaderText="ShortAdd" />
                                        <asp:BoundField DataField="LibraryAddress" HeaderText="LibraryAddress" />
                                        <asp:BoundField DataField="ShopNumber" HeaderText="Shop No." />
                                       <%-- <asp:BoundField DataField="NID" HeaderText="NID" />--%>
                                        <asp:BoundField DataField="Telephone" HeaderText="Phone" />
                                        <asp:BoundField DataField="RegionName" HeaderText="Region" />
                                        <asp:BoundField DataField="DivName" HeaderText="DivName" />
                                        <asp:BoundField DataField="ZonName" HeaderText="ZonName" />
                                        <asp:BoundField DataField="TeritoryName" HeaderText="Teritory" />
                                        <asp:BoundField DataField="DistrictName" HeaderText="District" />
                                        <asp:BoundField DataField="ThanaName" HeaderText="Thana" />
                                    </Columns>
                                    <SelectedRowStyle BackColor="#393737" Font-Bold="true" ForeColor="#F7F7F7" />
                                </asp:GridView>
                                  <asp:DropDownList ID="idPageSize" runat="server" OnSelectedIndexChanged="pageSizeChange">
                                  
                                      <asp:ListItem Text="10" Value="10" />
                                        <asp:ListItem Text="15" Value="15" />
                                      <asp:ListItem Text="20" Value="20" />
                                      <asp:ListItem Text="100" Value="100" />
                                  </asp:DropDownList>
                                 <asp:label ID="lblPageNo" runat="server" Text="1"></asp:label>  
                                <asp:label ID="pagetext" runat="server" Text="0"></asp:label>  
                                <asp:label ID="lblTotalData" runat="server" Text="Total Instances :"></asp:label>  
                                <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" />
                                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" />


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

    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;

            // Check if the key pressed is a number (0-9) or not
            if (charCode >= 48 && charCode <= 57) {
                return true;
            } else {
                return false;
            }
        }
</script>




</asp:Content>
