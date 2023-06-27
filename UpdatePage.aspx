<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePage.aspx.cs" Inherits="CLDV_POE_Part_3.UpdatePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Page</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }

        h1 {
            font-size: 24px;
            margin-bottom: 10px;
        }

        h2 {
            font-size: 18px;
            margin-bottom: 10px;
        }

        label {
            display: inline-block;
            width: 100px;
            margin-right: 10px;
        }

        .button-container {
            margin-top: 20px;
        }

        .button-container button {
            padding: 10px 20px;
            background-color: dodgerblue;
            border: none;
            color: white;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin-right: 10px;
            cursor: pointer;
            border-radius: 5px;
        }

        .button-container button:hover {
            background-color: royalblue;
        }

        table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        th {
            background-color: dodgerblue;
            color: white;
        }

        .button-container #btnDelete, .button-container #btnUpdate {
            background-color: dodgerblue;
            color: white;
            padding: 10px 20px;
            border: none;
            font-size: 16px;
            margin-right: 10px;
            cursor: pointer;
            border-radius: 5px;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Edit Selected</h1>

            <h2>Selected Row Details</h2>
            <table>
                <asp:GridView ID="gridViewDetails" runat="server" AutoGenerateColumns="true" OnSelectedIndexChanged="gridViewDetails_SelectedIndexChanged">
                </asp:GridView>
            </table>

            <div class="button-container">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="update-button" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            </div>
        </div>
    </form>
</body>
</html>