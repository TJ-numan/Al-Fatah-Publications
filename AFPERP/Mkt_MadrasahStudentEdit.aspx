<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingMaster.master" AutoEventWireup="true" CodeBehind="Mkt_MadrasahStudentEdit.aspx.cs" Inherits="BLL.Mkt_MadrasahStudentEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MarketingContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="form-horizontal clearfix" runat="server">
                <div class="panel-body" style="border: 1px solid #BDC3CA">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Madrasha Student Update
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlAgreementYear" Text="Session" CssClass="col-md-4 control-label" runat="server"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList CssClass="form-control" ID="ddlAgreementYear" runat="server" AutoPostBack="false">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtAgrNo" CssClass="col-md-4 control-label no-padding-right" Text="SL No"></asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtAgrNo" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtAgrNo_TextChanged" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlMadrashaName" CssClass="col-md-4 control-label no-padding-right" Text="Madrasha Name"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlMadrashaName" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="ddlMadrashaName_TextChanged" />
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4"></div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:GridView runat="server" CssClass="table table-bordered" DataKeyNames="NoOfStudents" ID="gvwNoOfStudent" AutoGenerateColumns="False">
                                            <HeaderStyle BackColor="#F2DEDE" ForeColor="#2A3542"></HeaderStyle>
                                            <Columns>
                                                <%-- <asp:BoundField DataField="MadId" HeaderText="MId" />--%>
                                                <asp:BoundField DataField="ClassID" HeaderText="CId" />
                                                <asp:BoundField DataField="ClassName" HeaderText="Class" />
                                                <asp:TemplateField HeaderText="No of Student">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtNoOfStudent" runat="server" Text='<%# Eval("NoOfStudents")%>' CssClass="form-control calc"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <%--                                <div class="form-group">
                                                                            <asp:Label runat="server" AssociatedControlID="txtTotalStudent" CssClass="col-md-4 control-label no-padding-right" Text="Total Student"></asp:Label>
                                        <div class="col-md-5">
                                            <asp:TextBox ID="txtTotalStudent" runat="server" CssClass="form-control calc-total"/>
                                        </div>
                                </div>--%>
                                    <div class="form-group">
                                        <%--<asp:Button ID="btnUpdate" runat="server"  OnClick="btnUpdate_Click" />--%>
                                        <div class="col-md-6 col-md-offset-4">
                                            <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-lock pull-right" runat="server" OnClientClick="if (!confirm('Do You Want to Save?')) return false;" OnClick="btnUpdate_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSMarketing" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {

            calculateSum(".calc", ".calc-total");

            $(".calc").on("keyup", function () {
                calculateSum(".calc", ".calc-total");
            });


            open_menu("Madrasah");
        });

        //more field summation with textchange
        function calculateSum(field, total) {
            var sum = 0;

            $(field).each(function () {
                //add only if the value is number
                if (!isNaN(this.value) && this.value.length != 0) {
                    sum += parseFloat(this.value);
                }
            });
            $(total).val(sum.toFixed(0));

        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            open_menu("Madrasah");
        })
    </script>
</asp:Content>
