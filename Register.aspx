<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="OffTheGrit1.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
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
                    <h2>Create an account
                    </h2>
                    <div class="controls">
                        <input class="name" type="text" placeholder="Name" required>
                        <br>
                        <br>
                        <input class="surname" type="text" placeholder="Surname" required>
                        <br>
                        <br>
                        <input class="Mobile" type="text" placeholder="Mobile" required>
                        <br>
                        <br>
                        <input class="Email" type="text" placeholder="Email" required>
                        <br>
                        <br>
                        <input class="Password" type="password" placeholder="Password" required>
                        <br>
                        <br>
                        <input class="rePassword" type="password" placeholder="Confirm password" required>
                        <br>
                        <br />
                    </div>
                    <br />
                    <asp:Button ID="btnRegister" runat="server" class="register" Text="Register" />
                    <br>
                    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
