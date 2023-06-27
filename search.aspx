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

        input[type="submit"] {
            padding: 10px;
            background-color: dodgerblue;
            border: none;
            color: white;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin-top: 10px;
            cursor: pointer;
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

        .home-button {
            position: absolute;
            top: 35px;
            right: 100px;
            
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            cursor: pointer;
            border-radius: 5px;
            background-color: dodgerblue;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Search</h1>

            <label for="ddlDatabase">Database:</label>
            <asp:DropDownList ID="ddlDatabase" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDatabase_SelectedIndexChanged">
                <asp:ListItem Text="Driver" Value="Driver"></asp:ListItem>
                <asp:ListItem Text="Inspector" Value="Inspector"></asp:ListItem>
                <asp:ListItem Text="Car" Value="Car"></asp:ListItem>
                <asp:ListItem Text="Car Body Type" Value="Car_Body_Type"></asp:ListItem>
                <asp:ListItem Text="Car Make" Value="Car_Make"></asp:ListItem>
                <asp:ListItem Text="Rental" Value="Rental"></asp:ListItem>
                <asp:ListItem Text="Returns" Value="Returns"></asp:ListItem>
            </asp:DropDownList>

            <br />

            <br />

            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="true" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            </asp:GridView>

            <a href="home.aspx" class="home-button">Home</a>

        </div>
    </form>
</body>
</html>
