<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OffTheGrit1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
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
                    <div class="heading">
                        <h1>Off the grid
                        </h1>
                        <p>
                            Power your future with clean energy
                        </p>
                    </div>
                    <div class="controls">

                        <input class="username" id="txtusername" type="text" placeholder="Username or email" required>
                        <br />
                        <br />
                        <input class="password" id="txtpassword" type="password" placeholder="Password" required>
                        <br />
                        <br />
                        <a class="forgot" href="#">forgot your password?</a>
                        <br />
                        <br />
                        <asp:Button ID="btnlogin" class="login" runat="server" Text="Login" />
                        <br />
                        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                        <br />
                        <div class="divider">
                            <span>OR</span>
                        </div>
                        <asp:Button ID="btnRegister" runat="server" class="register" Text="Register" />


                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
