<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberReviewsPage.aspx.cs" Inherits="Proj4API.MemberReviewsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Reviews</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />

    <%--<asp:ScriptManager ID="ScriptManagerMemberReviewsPage" runat="server"></asp:ScriptManager>--%>
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
            width: 1400px;
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
        <%--<asp:UpdatePanel runat="server" ID="UpdatePanelManageReservation" UpdateMode="Conditional">
                <ContentTemplate>--%>
        <div class="Form">
            <div style="width: 500px">

                <h2 class="text-center" style="color: white">My Reviews</h2>

                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" Text="Username: " ForeColor="White"></asp:Label>
                    <asp:Label ID="lblUsername" runat="server" ForeColor="#3C6D8F"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label4" runat="server" Text="Restaurant Name" ForeColor="White"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtRestaurantName" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label5" runat="server" Text="Comment: " ForeColor="White"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtComment" runat="server" Width="100%"></asp:TextBox>
                    <%--<textarea id="txtComment" cols="50" rows="5"></textarea>--%>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label6" runat="server" Text="Food Quality (0-5)" ForeColor="White"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtFoodQuality" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label7" runat="server" Text="Service (0-5)" ForeColor="White"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtService" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="Atmosphere (0-5)" ForeColor="White"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtAtmosphere" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label8" runat="server" Text="Price Level (0-5 Cheap-Expensive)" ForeColor="White"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtPriceLevel" runat="server" Width="100%"></asp:TextBox>
                </div>
                <br />
                <div style="width: 100%; text-align: center; color: red">
                    <%--                    <asp:Label ID="lblAlert" runat="server" Text=""></asp:Label>--%>
                </div>
                <br />
                <div style="text-align: center">
                    <asp:Button ID="btnAdd" runat="server" Text="Add Review" OnClick="btnAdd_Click" BackColor="#3C6D8F" ForeColor="White" />
                </div>
            </div>
            <br />
            <br />

            <div class="Grid-View">
                <asp:GridView ID="gvMemberReviews" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvMemberReviews_RowCancelingEdit" OnRowEditing="gvMemberReviews_RowEditing" CellPadding="1" OnRowUpdating="gvMemberReviews_RowUpdating" HorizontalAlign="Left" OnRowDeleting="gvMemberReviews_RowDeleting" DataKeyNames="Restaurant">
                    <Columns>
                        <asp:BoundField DataField="Username" HeaderText="Username" ReadOnly="true" />
                        <asp:BoundField DataField="Restaurant" HeaderText="Restaurant" ReadOnly="true" />
                        <%--<asp:BoundField DataField="Comment" HeaderText="Comment" />--%>
                        <asp:TemplateField HeaderText="Comment">
                            <ItemTemplate>
                                <asp:Label runat="server" Text ='<%# Eval("Comment")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtComment" runat="server" Text ='<%# Bind("Comment")%>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="FoodQuality" HeaderText="Food Quality" />--%>
                        <asp:TemplateField HeaderText="Food Quality">
                            <ItemTemplate>
                                <asp:Label runat="server" Text ='<%# Eval("FoodQuality")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtFoodQuality" runat="server" Text ='<%# Bind("FoodQuality")%>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="ServiceRating" HeaderText="Service" />--%>
                        <asp:TemplateField HeaderText="Service">
                            <ItemTemplate>
                                <asp:Label runat="server" Text ='<%# Eval("Service")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtService" runat="server" Text ='<%# Bind("ServiceRating")%>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="Atmosphere" HeaderText="Atmosphere" />--%>
                        <asp:TemplateField HeaderText="Atmosphere">
                            <ItemTemplate>
                                <asp:Label runat="server" Text ='<%# Eval("Atmosphere")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtAtmosphere" runat="server" Text ='<%# Bind("Atmosphere")%>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="PriceLevel" HeaderText="Price Level" />--%>
                        <asp:TemplateField HeaderText="Price Level">
                            <ItemTemplate>
                                <asp:Label runat="server" Text ='<%# Eval("PriceLevel")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPriceLevel" runat="server" Text ='<%# Bind("PriceLevel")%>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:CommandField ButtonType="Button" HeaderText="Edit" ShowEditButton="True" />
                         <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="true" />
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <div style="width: 100%; text-align: center; color: green">
                <asp:Label ID="lblAlert" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <div style="text-align: center; gap: 20px">
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
            </div>
        </div>
        <%--    </ContentTemplate>
            </asp:UpdatePanel>--%>
    </form>

    <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnBack" EventName="btnBack_Click">
            <asp:AsyncPostBackTrigger ControlID="btnAddReview" EventName="btnAddReview_Click">
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="btnAdd_Click">
        </Triggers>--%>
</body>
</html>
