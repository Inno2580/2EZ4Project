<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="OffTheGrit1.homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Homepage
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./css/index.css">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Body-->
    <section class="advertisements">
        <div class="image-slider">
            <div class="image-slider-controls">
                <a href="#" class="control_prev">&#129144</a>
                <a href="#" class="control_next">&#129146</a>
            </div>
            <ul>
                <li>
                    <img class="image-slider-img" src="./images/inverter.png" alt=" "></li>
                <li>
                    <img class="image-slider-img" src="#" alt=" "></li>
                <li>
                    <img class="image-slider-img" src="#" alt=" "></li>
            </ul>
        </div>
    </section>

    <section class="solutions">
        <div class="solutions-text">
            <h1>Our</h1>
            <h3>Solutions</h3>
        </div>

        <div class="solutions-box-row box-row">

            <div class="solutions-col">
                <div class="solutions-col-heading">
                    <img class="solutions-col-img" src="./images/water.png" alt=" ">
                </div>

                <div class="solutions-col-text">
                    <h3>Water Purification</h3>
                    <p>Best Solution for</p>
                    <strong>Water Purification</strong>
                </div>
            </div>

            <div class="solutions-col">
                <div class="solutions-col-heading">
                    <img class="solutions-col-img" src="./images/solar.jpeg" alt=" ">
                </div>

                <div class="solutions-col-text">
                    <h3>Solar Solutions</h3>
                    <p>Best Solution for</p>
                    <strong>Water Purification</strong>
                </div>
            </div>
        </div>
    </section>

    <section class="explanations">
        <div class="explanations-solar">
            <h3>Solar Solutions</h3>
            <div class="explanations-solar-par">
                <p>
                    Experience hassle-free solar energy with OFF THE GRID. Our flexible plans offer top-notch solar systems with the commitment of ownership. Enjoy reduced energy bills and a lower carbon footprint. Our expert team ensures optimal performance and seamless service.                    
                </p>
            </div>
            <!-- <asp:Button ID="solar" runat="server" Text="Solar Solutions &#129138" />-->
            <asp:Button ID="Btnsolar" runat="server" Text="Solar solutions" CssClass="myButton" />

        </div>

        <div class="explanations-water">
            <h3>Water Purication</h3>
            <div class="explanations-water-par">
                <p>
                    Experience hassle-free water purification with OFF THE GRID. Our flexible plans offer top-notch water purification systems with the commitment of ownership. Our expert team ensures optimal performance and seamless service.                    
                </p>
            </div>

            <asp:Button ID="water" runat="server" Text="Water Purification" CssClass="myButton" />
        </div>



    </section>

    <section class="aboutus">
        <img class="aboutus-img" src="#" alt="">
        <div class="aboutus-txt">
            <h3>About Us</h3>
            <div class="aboutus-par">
                <p>
                    Welcome to OFF THE GRID, South Africa's premier solar & water purifaction systems distributor since 2025. With centers all over the country we offer cutting-edge renewable energy products and top-tier after-sales support. Our mission is to lead South Africa's solar energy transition by providing excellent products and empowering communities. Join us in shaping a greener future. 
                </p>
            </div>
        </div>
    </section>
</asp:Content>
