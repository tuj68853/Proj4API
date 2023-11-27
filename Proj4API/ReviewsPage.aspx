<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReviewsPage.aspx.cs" Inherits="Proj4API.ReviewsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reviews Page</title>
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
            width: 800px;
        }

        .Grid-View {
            display: flex;
            justify-content: center;
            align-items: center;
            padding: 10px;
            width: 100%;
            flex-direction: column;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Form">

            <h2 class="text-center" style="color: white">Restaurant Reviews</h2>
            <div class="form-group">
                <label for="username" style="color: white">Restaurant Name: </label>
                <asp:Label ID="lblRestaurantName" runat="server" ForeColor="#3C6D8F"></asp:Label>
            </div>

            <div class="Grid-View">
                <asp:GridView ID="gvReviews" runat="server" CellPadding="10" ForeColor="#333333" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Username" HeaderText="Username" />
                        <asp:BoundField DataField="Comment" HeaderText="Comment" />
                        <asp:BoundField DataField="FoodQuality" HeaderText="Food Quality" />
                        <asp:BoundField DataField="Service" HeaderText="Service" />
                        <asp:BoundField DataField="Atmosphere" HeaderText="Atmosphere" />
                        <asp:BoundField DataField="PriceLevel" HeaderText="Price Level" />
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
                <div style="width: 100%; text-align: center; color: red">
                    <asp:Label ID="lblAlert" runat="server" Text=""></asp:Label>
                </div>
                <br />
                <div style="text-align: center; gap: 20px">
                    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
