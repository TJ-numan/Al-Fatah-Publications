<%@ Page Title="" Language="C#" MasterPageFile="~/RandDMaster.master" AutoEventWireup="true" CodeBehind="RndEntryWorksQawmi.aspx.cs" Inherits="BLL.RndEntryWorksQawmi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RandDContent" runat="server">
    <div class="form-horizontal clearfix" runat="server">
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Entry Works Qawmi
                </div>
                <div class="panel-body">
                    <div class="row">

                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtDate" CssClass="col-md-3 control-label" Text="Date" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control date" ID="txtDate" placeholder="yyyy-MM-dd" runat="server" />
                                    <ajaxToolkit:CalendarExtender TargetControlID="txtDate" Format="yyyy-MM-dd" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlSection" CssClass="col-md-3 control-label" Text="Section" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlSection" runat="server" OnTextChanged="ddlSection_TextChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <fieldset>
                                    <div class="checkbox col-md-8 col-md-offset-3">
                                        <asp:Label AssociatedControlID="checkboxHireSection" runat="server" Text="Hire Section>>" Visible="false"></asp:Label>
                                        <asp:CheckBox ID="checkboxHireSection" runat="server" OnCheckedChanged="checkboxHireSection_CheckedChanged" AutoPostBack="true" visible="false"/>
                                    </div>
                                </fieldset>
                            </div>
                            <asp:UpdatePanel runat="server" ID="UpdatePortion">
                                <ContentTemplate>
                                    <div class="form-group">
                                        <asp:Label AssociatedControlID="ddlHireSection" ID="lblHireSection" CssClass="col-md-3 control-label" Text="Hire Section" runat="server" Visible="false"></asp:Label>
                                        <div class="col-md-7">
                                            <asp:DropDownList CssClass="form-control" ID="ddlHireSection" runat="server" OnSelectedIndexChanged="ddlHireSection_TextChanged" Visible="false">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="form-group">
                                  <asp:Label AssociatedControlID="ddlEmpName" CssClass="col-md-3 control-label" Text="Name" runat="server"></asp:Label>
                                  <div class="col-md-7">
                                        <asp:DropDownList CssClass="form-control" ID="ddlEmpName" runat="server" AutoPostBack="True" OnTextChanged="ddlEmpName_OnTextChanged">
                                        </asp:DropDownList>
                                  </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlDesignation" CssClass="col-md-3 control-label" Text="Designation" runat="server"></asp:Label>
                                <div class="col-md-7">
                                    <asp:DropDownList CssClass="form-control" ID="ddlDesignation" runat="server" AutoPostBack="True">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtStartTime" CssClass="col-md-3 control-label" Text="Start Time" runat="server" visible="false"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control" ID="txtStartTime" runat="server" visible="false"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtEndTime" CssClass="col-md-3 control-label" Text="End Time" runat="server" visible="false"></asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox CssClass="form-control" ID="txtEndTime" runat="server" visible="false"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlHour" runat="server" CssClass="col-md-3 control-label" Text="Start Time" />
                                <div class="dropdown col-md-2">
                                    <asp:DropDownList ID="ddlHour" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="">--Hour--</asp:ListItem>
                                        <asp:ListItem Value="01">01</asp:ListItem>
                                        <asp:ListItem Value="02">02</asp:ListItem>
                                        <asp:ListItem Value="03">03</asp:ListItem>
                                        <asp:ListItem Value="04">04</asp:ListItem>
                                        <asp:ListItem Value="05">05</asp:ListItem>
                                        <asp:ListItem Value="06">06</asp:ListItem>
                                        <asp:ListItem Value="07">07</asp:ListItem>
                                        <asp:ListItem Value="08">08</asp:ListItem>
                                        <asp:ListItem Value="09" Selected="True">09</asp:ListItem>
                                        <asp:ListItem Value="10">10</asp:ListItem>
                                        <asp:ListItem Value="11">11</asp:ListItem>
                                        <asp:ListItem Value="12">12</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="dropdown col-md-2">
                                    <asp:DropDownList ID="ddlMin" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="">--Min--</asp:ListItem>
                                        <asp:ListItem Value="00" Selected="True">00</asp:ListItem>
                                        <asp:ListItem Value="01">01</asp:ListItem>
                                        <asp:ListItem Value="02">02</asp:ListItem>
                                        <asp:ListItem Value="03">03</asp:ListItem>
                                        <asp:ListItem Value="04">04</asp:ListItem>
                                        <asp:ListItem Value="05">05</asp:ListItem>
                                        <asp:ListItem Value="06">06</asp:ListItem>
                                        <asp:ListItem Value="07">07</asp:ListItem>
                                        <asp:ListItem Value="08">08</asp:ListItem>
                                        <asp:ListItem Value="09">09</asp:ListItem>
                                        <asp:ListItem Value="10">10</asp:ListItem>
                                        <asp:ListItem Value="11">11</asp:ListItem>
                                        <asp:ListItem Value="12">12</asp:ListItem>
                                        <asp:ListItem Value="13">13</asp:ListItem>
                                        <asp:ListItem Value="14">14</asp:ListItem>
                                        <asp:ListItem Value="15">15</asp:ListItem>
                                        <asp:ListItem Value="16">16</asp:ListItem>
                                        <asp:ListItem Value="17">17</asp:ListItem>
                                        <asp:ListItem Value="18">18</asp:ListItem>
                                        <asp:ListItem Value="19">19</asp:ListItem>
                                        <asp:ListItem Value="20">20</asp:ListItem>
                                        <asp:ListItem Value="21">21</asp:ListItem>
                                        <asp:ListItem Value="22">22</asp:ListItem>
                                        <asp:ListItem Value="23">23</asp:ListItem>
                                        <asp:ListItem Value="24">24</asp:ListItem>
                                        <asp:ListItem Value="25">25</asp:ListItem>
                                        <asp:ListItem Value="26">26</asp:ListItem>
                                        <asp:ListItem Value="27">27</asp:ListItem>
                                        <asp:ListItem Value="28">28</asp:ListItem>
                                        <asp:ListItem Value="29">29</asp:ListItem>
                                        <asp:ListItem Value="30">30</asp:ListItem>
                                        <asp:ListItem Value="31">31</asp:ListItem>
                                        <asp:ListItem Value="32">32</asp:ListItem>
                                        <asp:ListItem Value="33">33</asp:ListItem>
                                        <asp:ListItem Value="34">34</asp:ListItem>
                                        <asp:ListItem Value="35">35</asp:ListItem>
                                        <asp:ListItem Value="36">36</asp:ListItem>
                                        <asp:ListItem Value="37">37</asp:ListItem>
                                        <asp:ListItem Value="38">38</asp:ListItem>
                                        <asp:ListItem Value="39">39</asp:ListItem>
                                        <asp:ListItem Value="40">40</asp:ListItem>
                                        <asp:ListItem Value="41">41</asp:ListItem>
                                        <asp:ListItem Value="42">42</asp:ListItem>
                                        <asp:ListItem Value="43">43</asp:ListItem>
                                        <asp:ListItem Value="44">44</asp:ListItem>
                                        <asp:ListItem Value="45">45</asp:ListItem>
                                        <asp:ListItem Value="46">46</asp:ListItem>
                                        <asp:ListItem Value="47">47</asp:ListItem>
                                        <asp:ListItem Value="48">48</asp:ListItem>
                                        <asp:ListItem Value="49">49</asp:ListItem>
                                        <asp:ListItem Value="50">50</asp:ListItem>
                                        <asp:ListItem Value="51">51</asp:ListItem>
                                        <asp:ListItem Value="52">52</asp:ListItem>
                                        <asp:ListItem Value="53">53</asp:ListItem>
                                        <asp:ListItem Value="54">54</asp:ListItem>
                                        <asp:ListItem Value="55">55</asp:ListItem>
                                        <asp:ListItem Value="56">56</asp:ListItem>
                                        <asp:ListItem Value="57">57</asp:ListItem>
                                        <asp:ListItem Value="58">58</asp:ListItem>
                                        <asp:ListItem Value="59">59</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="dropdown col-md-2">
                                    <asp:DropDownList ID="ddlExtend" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="">--AM/PM--</asp:ListItem>
                                        <asp:ListItem Value="AM" Selected="True">AM</asp:ListItem>
                                        <asp:ListItem Value="PM">PM</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="ddlHour2" runat="server" CssClass="col-md-3 control-label" Text="End Time" />
                                <div class="dropdown col-md-2">
                                    <asp:DropDownList ID="ddlHour2" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="">--Hour--</asp:ListItem>
                                        <asp:ListItem Value="01">01</asp:ListItem>
                                        <asp:ListItem Value="02">02</asp:ListItem>
                                        <asp:ListItem Value="03">03</asp:ListItem>
                                        <asp:ListItem Value="04">04</asp:ListItem>
                                        <asp:ListItem Value="05">05</asp:ListItem>
                                        <asp:ListItem Value="06" Selected="True">06</asp:ListItem>
                                        <asp:ListItem Value="07">07</asp:ListItem>
                                        <asp:ListItem Value="08">08</asp:ListItem>
                                        <asp:ListItem Value="09">09</asp:ListItem>
                                        <asp:ListItem Value="10">10</asp:ListItem>
                                        <asp:ListItem Value="11">11</asp:ListItem>
                                        <asp:ListItem Value="12">12</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="dropdown col-md-2">
                                    <asp:DropDownList ID="ddlMin2" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="">--Min--</asp:ListItem>
                                        <asp:ListItem Value="00" Selected="True">00</asp:ListItem>
                                        <asp:ListItem Value="01">01</asp:ListItem>
                                        <asp:ListItem Value="02">02</asp:ListItem>
                                        <asp:ListItem Value="03">03</asp:ListItem>
                                        <asp:ListItem Value="04">04</asp:ListItem>
                                        <asp:ListItem Value="05">05</asp:ListItem>
                                        <asp:ListItem Value="06">06</asp:ListItem>
                                        <asp:ListItem Value="07">07</asp:ListItem>
                                        <asp:ListItem Value="08">08</asp:ListItem>
                                        <asp:ListItem Value="09">09</asp:ListItem>
                                        <asp:ListItem Value="10">10</asp:ListItem>
                                        <asp:ListItem Value="11">11</asp:ListItem>
                                        <asp:ListItem Value="12">12</asp:ListItem>
                                        <asp:ListItem Value="13">13</asp:ListItem>
                                        <asp:ListItem Value="14">14</asp:ListItem>
                                        <asp:ListItem Value="15">15</asp:ListItem>
                                        <asp:ListItem Value="16">16</asp:ListItem>
                                        <asp:ListItem Value="17">17</asp:ListItem>
                                        <asp:ListItem Value="18">18</asp:ListItem>
                                        <asp:ListItem Value="19">19</asp:ListItem>
                                        <asp:ListItem Value="20">20</asp:ListItem>
                                        <asp:ListItem Value="21">21</asp:ListItem>
                                        <asp:ListItem Value="22">22</asp:ListItem>
                                        <asp:ListItem Value="23">23</asp:ListItem>
                                        <asp:ListItem Value="24">24</asp:ListItem>
                                        <asp:ListItem Value="25">25</asp:ListItem>
                                        <asp:ListItem Value="26">26</asp:ListItem>
                                        <asp:ListItem Value="27">27</asp:ListItem>
                                        <asp:ListItem Value="28">28</asp:ListItem>
                                        <asp:ListItem Value="29">29</asp:ListItem>
                                        <asp:ListItem Value="30">30</asp:ListItem>
                                        <asp:ListItem Value="31">31</asp:ListItem>
                                        <asp:ListItem Value="32">32</asp:ListItem>
                                        <asp:ListItem Value="33">33</asp:ListItem>
                                        <asp:ListItem Value="34">34</asp:ListItem>
                                        <asp:ListItem Value="35">35</asp:ListItem>
                                        <asp:ListItem Value="36">36</asp:ListItem>
                                        <asp:ListItem Value="37">37</asp:ListItem>
                                        <asp:ListItem Value="38">38</asp:ListItem>
                                        <asp:ListItem Value="39">39</asp:ListItem>
                                        <asp:ListItem Value="40">40</asp:ListItem>
                                        <asp:ListItem Value="41">41</asp:ListItem>
                                        <asp:ListItem Value="42">42</asp:ListItem>
                                        <asp:ListItem Value="43">43</asp:ListItem>
                                        <asp:ListItem Value="44">44</asp:ListItem>
                                        <asp:ListItem Value="45">45</asp:ListItem>
                                        <asp:ListItem Value="46">46</asp:ListItem>
                                        <asp:ListItem Value="47">47</asp:ListItem>
                                        <asp:ListItem Value="48">48</asp:ListItem>
                                        <asp:ListItem Value="49">49</asp:ListItem>
                                        <asp:ListItem Value="50">50</asp:ListItem>
                                        <asp:ListItem Value="51">51</asp:ListItem>
                                        <asp:ListItem Value="52">52</asp:ListItem>
                                        <asp:ListItem Value="53">53</asp:ListItem>
                                        <asp:ListItem Value="54">54</asp:ListItem>
                                        <asp:ListItem Value="55">55</asp:ListItem>
                                        <asp:ListItem Value="56">56</asp:ListItem>
                                        <asp:ListItem Value="57">57</asp:ListItem>
                                        <asp:ListItem Value="58">58</asp:ListItem>
                                        <asp:ListItem Value="59">59</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="dropdown col-md-2">
                                    <asp:DropDownList ID="ddlExtend2" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="">--AM/PM--</asp:ListItem>
                                        <asp:ListItem Value="AM">AM</asp:ListItem>
                                        <asp:ListItem Value="PM" Selected="True">PM</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlSubject" CssClass="col-md-3 control-label" Text="Subject" runat="server"></asp:Label>
                            <div class="col-md-7">
                                <asp:DropDownList CssClass="form-control" ID="ddlSubject" runat="server" OnTextChanged="ddlSubject_TextChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="ddlTask" CssClass="col-md-3 control-label" Text="Task" runat="server"></asp:Label>
                            <div class="col-md-7">
                                <asp:DropDownList CssClass="form-control" ID="ddlTask" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtStartPage" CssClass="col-md-3 control-label" Text="Start Page" runat="server"></asp:Label>
                            <div class="col-md-7">
                                <asp:TextBox CssClass="form-control" ID="txtStartPage" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtEndPage" CssClass="col-md-3 control-label" Text="End Page" runat="server"></asp:Label>
                            <div class="col-md-7">
                                <asp:TextBox CssClass="form-control" ID="txtEndPage" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtComments" CssClass="col-md-3 control-label" Text="Comments" runat="server"></asp:Label>
                            <div class="col-md-7">
                                <asp:TextBox CssClass="form-control" ID="txtComments" runat="server" TextMode="MultiLine" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-7 col-md-offset-3">
                                <asp:Button ID="btnAdd" Text="Add" CssClass="btn btn-success btn pull-right" runat="server" OnClick="btnAdd_OnClick" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <hr style="border: 1px solid silver" />
                    <asp:GridView ID="gvDailyWorks" runat="server" AutoGenerateColumns="False" CssClass="table">
                        <Columns>
                            <asp:BoundField HeaderStyle-Width="40px" HeaderText="Serial" DataField="Serial" />
                            <asp:BoundField HeaderStyle-Width="200px" HeaderText="Section" DataField="SectionName" />
                            <asp:BoundField HeaderStyle-Width="300px" HeaderText="Employee" DataField="Employee" /> 
                            <asp:BoundField HeaderStyle-Width="300px" HeaderText="Subject" DataField="Subject" />
                            <asp:BoundField HeaderStyle-Width="300px" HeaderText="Work Type" DataField="WorkType" />                           
                            <asp:BoundField HeaderStyle-Width="100px" HeaderText="Work Start" DataField="WorkStart" />
                            <asp:BoundField HeaderStyle-Width="100px" HeaderText="Work End" DataField="WorkEnd" />
                            <asp:BoundField HeaderStyle-Width="100px" HeaderText="Time(Hour)" DataField="Time" />
                            <asp:BoundField HeaderStyle-Width="90px" HeaderText=" Start Page " DataField="StartPage" />
                            <asp:BoundField HeaderStyle-Width="120px" HeaderText="End Page" DataField="EndPage" />
                            <asp:BoundField HeaderStyle-Width="100px" HeaderText="Total Page" DataField="TotalPage" />
                            <asp:BoundField HeaderStyle-Width="200px" HeaderText="Comments" DataField="Comments" />
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
                <div class="form-group">
                    <div class="col-md-11 col-md-offset-0">
                        <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success pull-right" runat="server" OnClick="btnSave_OnClick" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RequiredJSRandD" runat="server">
    <link href="[http://cdn.syncfusion.com/19.1.0.54 /js/web/flat-azure/ej.web.all.min.css](http://cdn.syncfusion.com/13.1.0.21/js/web/flat-azure/ej.web.all.min.css)" rel="stylesheet" />
    <script type="text/javascript">

        $(document).ready(function () {
            open_menu("Daily Work Qawmi");
        });
    </script>
</asp:Content>

