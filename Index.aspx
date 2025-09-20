<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="OffTheGrit1.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    <%# Eval("Product_Category") %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./css/home.css">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="nav-bottom">
        <div>
            <p>ALL</p>
        </div>
        <p>Solar Componentss</p>
        <p>|</p>
        <p>Water Purification</p>
        <p>|</p>
        <p>Security systems</p>
    </div>

    <div class="header-slider" id="slider">
        <!-- <a href="#" class="control_prev">&#129144</a>HTML character entity (unicode character)
        <a href="#" class="control_next">&#129146</a> -->
        <ul>
            <img class="header-img" src="" alt="">
            <img class="header-img" src="" alt="">
            <img class="header-img" src="" alt="">
            <img class="header-img" src="" alt="">
            <img class="header-img" src="" alt="">
            <img class="header-img" src="" alt="">
        </ul>

    </div>

    <asp:Repeater ID="waterSection" runat="server">
        <ItemTemplate>
            <section class="products-section">

                <div class="header-box box-row">

                    <div class="box-col">

                        <a href='About.aspx?id=<%# Eval("Product_ID") %>'>
                            <h3><%# Eval("Product_Name") %> </h3>

                            <img src='<%# Eval("Product_Image") %> ' alt="">
                        </a>


                    </div>
            </section>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
