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
            <%--The commented out sections below this are an UpdatePanel. It ensures only the content within the Update Panel is sent to
            the server for processing, while the rest of the page remains unchanged. This enables asynchronous, smoother updates to the page. 
            Just uncomment all the commented lines if you want to try them out.--%>
            <asp:ScriptManager ID="ScriptManagerCreateAccount" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel runat="server" ID="UpdatePanelCreateAccount" UpdateMode="Conditional">
                <ContentTemplate>
                    <uc1:RegisterForm runat="server" id="RegisterForm" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        
        <%--These are triggers. They tie to the asynchronous postback, linking an event function that can hold the usual normal function logic within the .cs file.--%>
    </form>

    <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnCreateAccount" EventName="EventCreateAccount">
        </Triggers>--%>
</body>
</html>
