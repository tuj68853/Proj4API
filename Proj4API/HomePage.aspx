<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Proj4API.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />


    <style>
        body {
            font-family: Arial, sans-serif;
            background-image: url('Citiesbg.jpg');
            background-repeat: no-repeat;
            background-size: cover;
            background-attachment: fixed;
        }

        /*body::before {
            content: '';
            background-color: rgba(255, 255, 255, 0.5);
            position: absolute;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            z-index: -1;
            height: 100%;
            
        }*/

        .Header {
            background-color: #BB6E6C;
            color: white;
            padding: 20px;
            display: flex;
            justify-content: center;
            gap: 70px;
        }

        .Title {
            width: 100%;
            min-height: 200px;
            height: 200px;
            text-align: center;
        }

        .Mid-Content {
            width: 100%;
        }

        .red-bar {
            background-color: #BB6E6C;
            color: white;
            padding: 20px;
            width: 50%;
            margin: 0 auto;
            display: flex;
            align-items: center;
            gap: 20px;
        }

        .Grid-View {
            display: flex;
            justify-content: center;
            align-items: center;
            padding: 10px;
            width: 100%;
            flex-direction: column;
        }

        .Search-Bar {
            width: 70%;
            background: rgba(255, 255, 255, 0.2);
            align-items: center;
            border-radius: 60px;
            padding: 10px 10px;
            display: flex;
        }
    </style>
</head>
<body style="min-height: 100vh; width: 100%">
    <form id="form1" runat="server">

        <%-- HEADER --%>
        <div class="Header">
            <div>
                <asp:Label ID="Label3" runat="server" Text="Welcome to TableTalks" Font-Bold="True" Font-Names="Broadway"></asp:Label>
            </div>
            <div class="buttons">
                <asp:Button ID="btnSignIn" runat="server" Text="Sign In" BackColor="#3C6D8F" ForeColor="White" OnClick="btnSignIn_Click" />
                <asp:Button ID="btnCreateAccount" runat="server" Text="Create Account" BackColor="#3C6D8F" ForeColor="White" OnClick="btnCreateAccount_Click" />
                <asp:Button ID="btnWriteReview" runat="server" Text="Write Review" BackColor="#3C6D8F" ForeColor="White" OnClick="btnWriteReview_Click" Visible="False" />
                <asp:Button ID="btnManageInfo" runat="server" Text="Manage Info" BackColor="#3C6D8F" ForeColor="White" OnClick="btnManageInfo_Click" Visible="False"/>
                <asp:Button ID="btnManageReservations" runat="server" Text="Manage Reservations" BackColor="#3C6D8F" ForeColor="White" OnClick="btnManageReservations_Click" Visible="False"/>
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" Visible="False" />
                <asp:Label ID="lblSignUpNote" runat="server" Text="<--Sign up to leave a review!" Font-Names="Broadway"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblHello" runat="server" Font-Bold="True" Font-Names="Harlow Solid Italic" Font-Size="X-Large"></asp:Label>
            </div>

        </div>
        <div class="Title">
            <asp:Label ID="Label1" runat="server" Text="How was it?" Font-Bold="True" Font-Size="50px" ForeColor="#3C6D8F" Font-Overline="False" Font-Italic="True" BorderColor="White" Font-Underline="True"></asp:Label>
        </div>
        <%-- MID-CONTENT  --%>
        <div class="Mid-Content">
            <div class="red-bar">
                <div class="Search-Bar">
                    <asp:TextBox ID="txtSearch" runat="server" style="background: transparent; outline: none; flex: 1; border: 0; width: 250px"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                </div>

                <div>
                    <asp:Label ID="Label2" runat="server" Text="Sort By: "></asp:Label>
                    <asp:DropDownList ID="ddlSortBy" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSortBy_SelectedIndexChanged" Height="30px">
                        <asp:ListItem>Name</asp:ListItem>
                        <asp:ListItem>Category</asp:ListItem>
                        <asp:ListItem>AvgFoodQuality</asp:ListItem>
                        <asp:ListItem>AvgService</asp:ListItem>
                        <asp:ListItem>AvgAtmosphere</asp:ListItem>
                        <asp:ListItem>AvgPriceLevel</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>

        <div class="Grid-View">
            <div style="width: 100%; text-align: center">
                <asp:Label ID="lblAlert" runat="server" ForeColor="Green"></asp:Label>
            </div>
            <br />
            <asp:GridView ID="gvVisitor" runat="server" AutoGenerateColumns="False" CellPadding="5" ForeColor="#333333" OnRowCommand="gvVisitor_RowCommand" OnSelectedIndexChanged="gvVisitor_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Restaurant" />
                    <asp:BoundField DataField="Category" HeaderText="Category" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="AvgFoodQuality" HeaderText="Food Quality " />
                    <asp:BoundField DataField="AvgService" HeaderText="Service" />
                    <asp:BoundField DataField="AvgAtmosphere" HeaderText="Atmosphere" />
                    <asp:BoundField DataField="AvgPriceLevel" HeaderText="Price Level" />
                    <asp:BoundField DataField="Represenative" HeaderText="Represenative" />
                    <asp:ButtonField ButtonType="Button" Text="Make Reservation" CommandName="MakeReservation" />
                    <asp:ButtonField ButtonType="Button" Text="Reviews" CommandName="ViewReviews" />
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
        </div>
    </form>
</body>
</html>

