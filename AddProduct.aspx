<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="OffTheGrit1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Product</title>
    <link rel="stylesheet" href="./css/styleLogin.css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
             
            <div class="centered">
                    <img class="logo" src="./images/OTG-logo.png">
                </div>
                <div class="container">
                    <div class="centered">
                        <h2>Add products to website
                        </h2>
                        <br />
                        <div class="controls">
                            <input class="name" type="text" placeholder="Product name" required>
                            <br>
                            <br>
                            <input class="surname" type="text" placeholder="ImageURL" required>
                            <br>
                            <br>
                            <input class="Mobile" type="text" placeholder="Price" required>
                            <br>
                            <br>
                            <input class="Email" type="text" placeholder="Product description" required>
                            <br>
                            <br>
                            <input class="Email" type="number" placeholder="Quantity" min="0" required>
                            <br>
                            <br>
                            
                            <br>
                         
                        </div>
                        <br>
                        <asp:Button ID="btnAddProduct" runat="server" class="register" Text="Add Product" />
                        <br>
                        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                    </div>
                </div>
        
        </div>
    </form>
</body>
</html>
