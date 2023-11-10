<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="Proj4API.CreateAccount" %>
<%@ Register Src="~/RegisterForm.ascx" TagPrefix="uc1" TagName="RegisterForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Account Form</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
</head>
<body style="background-image: url('Citiesbg.jpg'); background-repeat: no-repeat; background-attachment: fixed; background-size: cover">
    <form id="form1" runat="server">
        <div>
            <uc1:RegisterForm runat="server" id="RegisterForm" />
        </div>
    </form>
</body>
</html>
