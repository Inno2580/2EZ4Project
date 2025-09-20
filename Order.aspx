<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="OffTheGrit1.Order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./css/home.css">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="waterSection" runat="server">
        <itemtemplate>
            <section class="products-section">

                <div class="header-box box-row">

                    <div class="box-col">

                        <a href='About.aspx?id=<%# Eval("Product_ID") %>'>
                            <h3><%# Eval("Product_Name") %> </h3>

                            <img src='<%# Eval("Product_Image") %> ' alt="">
                        </a>


                    </div>
            </section>
        </itemtemplate>
    </asp:Repeater>
</asp:Content>
