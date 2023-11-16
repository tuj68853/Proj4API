<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakeReservationForm.aspx.cs" Inherits="Proj4API.MakeReservationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reservation Form</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />

    <%--<asp:ScriptManager ID="ScriptManagerMakeReservation" runat="server"></asp:ScriptManager>--%>
    <style>
        body, html{
            font-family: Arial, sans-serif;
            background-image: url('Citiesbg.jpg');
            background-repeat: no-repeat;
            background-size: cover;
            background-attachment: fixed;
            min-height: 100vh;
            height: 100%;
            margin: 0;
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .Form {
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            background-color: #BB6E6C;
            width: 500px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <%--<asp:UpdatePanel runat="server" ID="UpdatePanelMakeReservation" UpdateMode="Conditional">
                <ContentTemplate>--%>
                    <div>
                        <div class="Form">
                            <div style="text-align: center">
                                <asp:Label ID="Label1" runat="server" Text="Reservation Form" ForeColor="White" Font-Size="X-Large"></asp:Label>
                            </div>
                            <br />
                            <div class="form-group">
                                <asp:Label ID="Label2" runat="server" Text="Restaurant Name: " ForeColor="White"></asp:Label>
                                <asp:Label ID="lblRestaurantName" runat="server" ForeColor="#3C6D8F"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label3" runat="server" Text="Reservation Name: (ex.John Doe)" ForeColor="White"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtReservationName" runat="server" Width="100%"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label4" runat="server" Text="Contact Phone: (ex.123-456-7890)" ForeColor="White"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtContactPhone" runat="server" Width="100%"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label5" runat="server" Text="Reservation Date: (ex.mm/dd/yyyy)" ForeColor="White"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtReservationDate" runat="server" Width="100%"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label6" runat="server" Text="Reservation Time: (ex.6:30pm)" ForeColor="White"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtReservationTime" runat="server" Width="100%"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label7" runat="server" Text="Total Guests: (ex.5)" ForeColor="White"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtTotalGuests" runat="server" Width="100%"></asp:TextBox>
                            </div>
                            <br />
                            <div style="width: 100%; text-align: center">
                                <asp:Label ID="lblAlert" runat="server" Text="" ForeColor="Green"></asp:Label>
                            </div>
                            <br />
                            <div style="text-align: center; gap: 20px">
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                <asp:Button ID="btnConfirm" runat="server" Text="Confirm" BackColor="#3C6D8F" ForeColor="White" OnClick="btnConfirm_Click" />
                            </div>

                        </div>
                    </div>
        <%--    </ContentTemplate>
            </asp:UpdatePanel>--%>
    </form>

    <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="btnCancel_Click">
            <asp:AsyncPostBackTrigger ControlID="btnConfirm" EventName="btnConfirm_Click">
        </Triggers>--%>
</body>
</html>
