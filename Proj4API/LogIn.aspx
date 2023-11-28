<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Proj4API.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />

    <%--<asp:ScriptManager ID="ScriptManagerLogIn" runat="server"></asp:ScriptManager>--%>
    <style>
        body, html {
            height: 100%;
            margin: 0;
            display: flex;
            align-items: center;
            justify-content: center;
            font-family: Arial, sans-serif;
            background-image: url('Citiesbg.jpg');
            background-repeat: no-repeat;
            background-attachment: fixed;
            background-size: cover
        }


        .card {
            width: 400px;
            background-color: #BB6E6C;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .text-center {
            gap: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <asp:UpdatePanel runat="server" ID="UpdatePanelLogIn" UpdateMode="Conditional">
                <ContentTemplate>
                    <div>
                        <div class="card">
                            <h2 class="text-center" style="color: white">Login</h2>
                            <div style="text-align: center;">
                                <asp:Label ID="lblAlert" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                            <br />
                            <div class="form-group">
                                <label for="username" style="color: white">Username:</label>

                                <%--<input id="txtUsername" runat="server" class="form-control" />--%>
                                <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="password" style="color: white">Password:</label>

                                <%--<input id="txtPassword" runat="server" class="form-control" />--%>
                                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-check">
                                <label for="userType" style="color: white">Choose user type:</label>
                                <asp:RadioButtonList ID="rblAccountType" runat="server" ForeColor="White"></asp:RadioButtonList>
                            </div>
                            <div class="text-center">
                                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" ForeColor="Black" />
                                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" BackColor="#3C6D8F" ForeColor="White" />
                                <asp:Button ID="btnCreateAccount" runat="server" Text="Create Account" OnClick="btnCreateAccount_Click" BackColor="#3C6D8F" ForeColor="White" />


                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
