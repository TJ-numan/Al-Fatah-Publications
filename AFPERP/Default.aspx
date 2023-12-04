<%@ Page Title="Home" Language="C#" MasterPageFile="~/DefaultMaster.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BLL.Default" %>

<asp:Content ID="Cotent1" ContentPlaceHolderID="DefaultContent" runat="server">
    <!-- page start-->
    <section class="panel">
        <header class="page-heading">
            Departments Menu         
        </header>
        <div class="panel-body" style="border: 1px solid #BDC3CA">
            <ul class="grid cs-style-3 clearfix">
                <li class="col-xs-6 col-md-4">
                    <figure>
                        <a href="RandDHome.aspx">
                            <img src="img/gallery/Arabic.jpg" alt="R&D" />
                        </a>
                        <figcaption>
                            <h3>R&D</h3>
                            <span>Department</span>
                            <a class="fancybox" rel="group" href="RandDHome.aspx">Take a look</a>
                        </figcaption>
                    </figure>
                </li>
                <li class="col-xs-6 col-md-4">
                    <figure>
                        <a href="ProHome">
                            <img src="img/gallery/production.jpg" alt="Production Landing">
                        </a>
                        <figcaption>
                            <h3>Production</h3>
                            <span>Department</span>
                            <a class="fancybox" rel="group" href="ProHome">Take a look</a>
                        </figcaption>
                    </figure>
                </li>
                <li class="col-xs-6 col-md-4">
                    <figure>
                        <a href="MarketingHome">
                            <img src="img/gallery/marketing.jpg">
                        </a>
                        <figcaption>
                            <h3>Marketing</h3>
                            <span>Department</span>
                            <a class="fancybox" rel="group" href="MarketingHome">Take a look</a>
                        </figcaption>
                    </figure>
                </li>
                <li class="col-xs-6 col-md-4">
                    <figure>
                        <a href="DistributionHome">
                            <img src="img/gallery/Distribution-Department.jpg">
                        </a>
                        <figcaption>
                            <h3>Distribution</h3>
                            <span>Department</span>
                            <a class="fancybox" rel="group" href="DistributionHome.aspx">Take a look</a>
                        </figcaption>
                    </figure>
                </li>


                <li class="col-xs-6 col-md-4">
                    <figure>
                        <a href="HRHome.aspx">
                            <img src="img/gallery/hr.jpg">
                        </a>
                        <figcaption>
                            <h3>HR</h3>
                            <span>Department</span>
                            <a class="fancybox" rel="group" href="HRHome.aspx">Take a look</a>
                        </figcaption>
                    </figure>
                </li>



                <li class="col-xs-6 col-md-4">
                    <figure>
                        <a href="AccountsHome.aspx">
                            <img src="img/gallery/accounts.jpg" alt="Acccounts Landing">
                        </a>
                        <figcaption>
                            <h3>Accounts</h3>
                            <span>Department</span>
                            <a class="fancybox" rel="group" href="AccountsHome.aspx">Take a look</a>
                        </figcaption>
                    </figure>
                </li> 

               <li class="col-xs-6 col-md-4">
                    <figure>
                        <a href="#">
                            <img src="img/gallery/Branding-Department.jpg">
                        </a>
                        <figcaption>
                            <h3>Branding</h3>
                            <span>Department</span>
                            <a class="fancybox" rel="group" href="#">Take a look</a>
                        </figcaption>
                    </figure>
                </li>


                <li class="col-xs-6 col-md-4">
                    <figure>
                        <a href="MISHome.aspx">
                            <img src="img/gallery/mis.jpg">
                        </a>
                        <figcaption>
                            <h3>MIS</h3>
                            <span>Department</span>
                            <a class="fancybox" rel="group" href="MISHome.aspx">Take a look</a>
                        </figcaption>
                    </figure>
                </li> 


                <li class="col-xs-6 col-md-4">
                    <figure>
                        <a href="#">
                            <img src="img/gallery/Admin.jpg">
                        </a>
                        <figcaption>
                            <h3>Management</h3>
                            <span>Department</span>
                            <a class="fancybox" rel="group" href="#">Take a look</a>
                        </figcaption>
                    </figure>
                </li>







            </ul>
        </div>
    </section>

    <!-- page end-->

</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="RequiredJSDepartment">
</asp:Content>
