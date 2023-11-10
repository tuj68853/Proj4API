<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RegisterForm.ascx.cs" Inherits="Proj4API.RegisterForm" %>


<div class="container p-5 my-5 text-black" style="background-color: rgba(255, 241, 215, 0.9); max-width: 35%">

    <div class="Content" style="display: inline-block">
        <%-- Register Infoo --%>
        <div class="Title" style="text-align: center">
            <h3 style="color: #BB3E00">Register Form</h3>
        </div>
        <div class="Title" style="text-align: center">
            <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
        </div>

        <div class="input-group mb-3">
            <span class="input-group-text">Name: </span>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="input-group mb-3">
            <span class="input-group-text">Phone: </span>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="input-group mb-3">
            <span class="input-group-text">Username: </span>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <asp:Label ID="Label5" runat="server" Text="What account type are you signing up for? "></asp:Label>

        <asp:DropDownList ID="ddlAccountType" runat="server">
            <asp:ListItem>Member</asp:ListItem>
            <asp:ListItem>Represenative</asp:ListItem>
        </asp:DropDownList>
        <br />
        <div class="text-center">
            <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-primary" OnClick="btnBack_Click" ForeColor="Black" />
            <asp:Button ID="btnRegister" runat="server" Text="Register" class="btn btn-primary" OnClick="btnRegister_Click" BackColor="#3C6D8F" ForeColor="White" />
        </div>


        <br />
    </div>
</div>
