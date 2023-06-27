<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateinspector.aspx.cs" Inherits="CLDV_POE_Part_3.updateinspector" %>

<!DOCTYPE html>
<html>
<head>
    <title>Update Inspector</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
            text-align: center;
        }
        h1 {
            color: dodgerblue;
            text-align: center;
        }
        .form-container {
            max-width: 400px;
            margin: 0 auto;
            text-align: center;
        }
        .form-group {
            margin-bottom: 20px;
            text-align: center; /* Update text alignment to center */
        }
        .form-group label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }
        .form-group input[type="text"],
        .form-group input[type="number"],
        .form-group select {
            width: 100%;
            max-width: 300px; /* Set a maximum width for the input boxes */
            padding: 5px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
            margin: 0 auto; /* Center the input fields */
        }
        .error {
            color: red;
        }
        .submit-button {
            background-color: dodgerblue;
            color: white;
            padding: 10px 70px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
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
    </style>
</head>
<body>
    <form id="formUpdateInspector" runat="server">
        <table>
            <asp:GridView ID="gridViewDetails" runat="server" AutoGenerateColumns="true">
            </asp:GridView>
        </table>
        <div class="form-container">
            <h1>Update Inspector</h1>
            <h2>Selected Inspector Details</h2>
            <div class="form-group">
                <label for="txtInspectorNo">Inspector Number:</label>
                <input type="text" id="txtInspectorNo" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtName">Name:</label>
                <input type="text" id="txtName" runat="server" />
            </div>
            
            <div class="form-group">
                <label for="txtEmail">Email:</label>
                <input type="text" id="txtEmail" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtMobile">Mobile:</label>
                <input type="text" id="txtMobile" runat="server" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="submit-button" OnClick="btnSubmit_Click" />
            </div>
            <div>
                <asp:Label ID="Error" runat="server" CssClass="error" Visible="false"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
