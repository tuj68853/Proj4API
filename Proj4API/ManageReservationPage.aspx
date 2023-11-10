<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageReservationPage.aspx.cs" Inherits="Proj4API.ManageReservationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Reservation Page</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body, html {
            font-family: Arial, sans-serif;
            background-image: url('Citiesbg.jpg');
            background-repeat: no-repeat;
            background-size: cover;
            background-attachment: fixed;
            min-height: 100vh;
            height: 100%;
            margin: auto;
            display: flex;
            align-items: center;
        }

        .Form {
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            background-color: #BB6E6C;
            width: 1000px;
            align-items: center;
            display: flex;
            margin: auto;
            flex-direction: column;
        }

        .Grid-View {
            margin: auto;
            width: 100%;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="Form">


            <h2 class="text-center" style="color: white">My Restaurants' Reservations</h2>


            <br />

            <div class="Grid-View">
                <asp:GridView ID="gvManageReservations" runat="server" AutoGenerateColumns="False" ForeColor="#333333" CellPadding="5" CellSpacing="2" HorizontalAlign="Center" OnRowDeleting="gvManageReservations_RowDeleting" DataKeyNames="ReservationName" OnRowCancelingEdit="gvManageReservations_RowCancelingEdit" OnRowEditing="gvManageReservations_RowEditing" OnRowUpdating="gvManageReservations_RowUpdating">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Restaurant" HeaderText="Restaurant" readonly="true"/>
                        <asp:BoundField DataField="ReservationName" HeaderText="Reservation Name" readonly="true"/>

                        <%--<asp:BoundField DataField="Date" HeaderText="Date" />--%>
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:Label runat="server" Text ='<%# Eval("Date")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDate" runat="server" Text ='<%# Bind("Date")%>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="Time" HeaderText="Time" />--%>
                        <asp:TemplateField HeaderText="Time">
                            <ItemTemplate>
                                <asp:Label runat="server" Text ='<%# Eval("Time")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTime" runat="server" Text ='<%# Bind("Time")%>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ContactPhone" HeaderText="ContactPhone" ReadOnly="true" />
                        <asp:BoundField DataField="TotalGuests" HeaderText="Total Guests" ReadOnly="true"/>
                        <asp:CommandField ButtonType="Button" HeaderText="Edit" ShowEditButton="True" />
                         <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="true" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <br />
                <div style="width: 100%; text-align: center; color: forestgreen">
                    <asp:Label ID="lblAlert" runat="server" Text=""></asp:Label>
                </div>
                <br />
            </div>
            <br />
            <div style="text-align: center; gap: 20px">
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
            </div>
        </div>

    </form>
</body>
</html>
