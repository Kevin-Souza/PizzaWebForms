<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LoginWebForms.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

    <link rel="shortcut icon" href="img/logo2.png" />

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="style.css" rel="stylesheet" />

    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
</head>
<body>
    <style>
        body {
            background-image: url(img/fundo.png);
        }
    </style>
    <div class="container">
        <div class="wrapper">
            <form name="Login_Form" class="form-signin" runat="server">
                <h3 class="form-signin-heading">Pizzaria</h3>
                <div class="text text-center">
                    <asp:Label ID="lblMsg" runat="server" CssClass="text text-info"></asp:Label>
                </div>
                <hr color="black" />
                <br />

                <asp:TextBox ID="txtUsuario" runat="server" type="text" class="form-control" name="Username"
                    placeholder="Usuário" required="" autofocus="" />

                <asp:TextBox ID="txtSenha" runat="server" type="password" class="form-control" name="Password"
                    placeholder="Senha" required="" />

                <asp:Button ID="btnAcessar" runat="server" class="btn btn-lg btn-primary btn-block" name="Submit" value="Login" type="Submit"
                    Text="Acessar" OnClick="btnAcessar_Click"></asp:Button>
            </form>
        </div>
    </div>
</body>
</html>
