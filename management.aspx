<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="management.aspx.cs" Inherits="CLDV_POE_Part_3.management" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Management Page</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }

        h1 {
            font-size: 24px;
            margin-bottom: 10px;
        }

        label {
            display: inline-block;
            width: 100px;
            margin-right: 10px;
        }

        input[type="text"],
        select {
            width: 200px;
            padding: 5px;
            margin-bottom: 10px;
        }

        .top-right {
            position: absolute;
            top: 20px;
            right: 20px;
        }

        .create-button,
        .home-button {
            padding: 15px 50px;
            background-color: dodgerblue;
            border: none;
            color: white;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin-top: 10px;
            cursor: pointer;
            border-radius: 10px;
        }

        .create-button {
            margin-right: 10px;
        }

        table {
            border-collapse: collapse;
            width: 100%;
        }

        th,
        td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        th {
            background-color: dodgerblue;
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Management</h1>

            <label for="ddlDatabase">Select Database:</label>
            <asp:DropDownList ID="ddlDatabase" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDatabase_SelectedIndexChanged">
                <asp:ListItem Text="Driver" Value="Driver"></asp:ListItem>
                <asp:ListItem Text="Inspector" Value="Inspector"></asp:ListItem>
                <asp:ListItem Text="Car" Value="Car"></asp:ListItem>
            </asp:DropDownList>

            <br />

            <br />

            <div class="top-right">
                <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" CssClass="create-button" />
                <asp:Button ID="btnHome" runat="server" Text="Home" OnClick="btnHome_Click" CssClass="home-button" />
            </div>

            <br />

            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="true" OnSelectedIndexChanged="gridView_SelectedIndexChanged" AutoGenerateSelectButton="true">
            </asp:GridView>
        </div>
    </form>
</body>
</html>