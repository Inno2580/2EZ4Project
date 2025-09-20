<%@ Page Title="About" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="OffTheGrit1.About" %>

<asp:Content ID="Content3" ContentPlaceHolderID="title" runat="server">
   <%# Eval("Product_Name") %>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./css/products.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="header">
        <div class="centered">
            <p class="text">

                <br>
                <br>
                <br>
                <br>
                <a class="textl" href='Index.aspx?id=<%# Eval("Product_Category") %>'><b>Home > </b></a>
                <a class="textl" href='About.aspx?id=<%# Eval("Product_ID") %>'><b><%# Eval("Product_Name") %></b></a>
                <br>
                <br>
                <br>
                <br>
            </p>
        </div>
    </div>

    <br>
    <br>
    <div class="container">
        <div class="left-side">
            <img src='<%# Eval("Product_Image") %> ' width="500px">
        </div>

        <div class="right-side">
            <div>
                <h1><%# Eval("Product_Name") %> </h1>
                <h2 class="price"><%# Eval("Product_Price") %></h2>
                <hr>
                <i>
                    <%# Eval("Product_Description") %>
                </i>
                <br>
                <br>
                <input class="product-quantity" type="number" min="0" placeholder="Quantity">
                <asp:Button ID="btnAdd" class="Addbtn" runat="server" Text="Add to busket" />

                <br>
                <br>

                <br>
                <br>
                <hr>
            </div>
        </div>
    </div>

    <br>
    <br>
</asp:Content>
