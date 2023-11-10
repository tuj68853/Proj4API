<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControl.ascx.cs" Inherits="Proj4API.LogIn1" %>

<style>
    
    body, html {
        height: 100%;
        margin: 0;
        display: flex;
        align-items: center;
        justify-content: center;
        font-family: Arial, sans-serif; 
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

<div class="card">
    <h2 class="text-center" style="color: white">Login</h2>
    <div class="form-group">
        <label for="username" style="color: white">Username:</label>
        <input type="text" id="txtUsername" runat="server" class="form-control" />
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
