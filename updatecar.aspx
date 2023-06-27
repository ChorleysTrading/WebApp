<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updatecar.aspx.cs" Inherits="CLDV_POE_Part_3.updatecar" %>

<!DOCTYPE html>
<html>
<head>
    <title>Update Car</title>
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
    <form id="formUpdateCar" runat="server">
                <asp:GridView ID="gridViewDetails" runat="server" AutoGenerateColumns="true">
                </asp:GridView>
        <div class="form-container">
            <h1>Update Car</h1>
            
            <h2>Selected Car Details</h2>
            <table>
            </table>
            
            <div class="form-group">
                <label for="txtCarNo">Car Number:</label>
                <input type="text" id="txtCarNo" runat="server" />
            </div>
            <div class="form-group">
                <label for="ddlCarMake">Car Make:</label>
                <select id="ddlCarMake" runat="server">
                    <option value="1">Hyundai</option>
                    <option value="2">BMW</option>
                    <option value="3">Mercedes Benz</option>
                    <option value="4">Toyota</option>
                    <option value="5">Ford</option>
                </select>
            </div>
            <div class="form-group">
                <label for="txtModel">Model:</label>
                <input type="text" id="txtModel" runat="server" />
            </div>
            <div class="form-group">
                <label for="ddlBodyType">Body Type:</label>
                <select id="ddlBodyType" runat="server">
                    <option value="1">Hatchback</option>
                    <option value="2">Sedan</option>
                    <option value="3">Coupe</option>
                    <option value="4">SUV</option>
                </select>
            </div>
            <div class="form-group">
                <label for="txtKilometeresTravelled">Kilometers Travelled:</label>
                <input type="number" id="txtKilometeresTravelled" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtServiceKilometers">Service Kilometers:</label>
                <input type="number" id="txtServiceKilometers" runat="server" />
            </div>
            <div class="form-group">
                <label for="ddlAvailable">Available:</label>
                <select id="ddlAvailable" runat="server">
                    <option value="Yes">Yes</option>
                    <option value="No">No</option>
                </select>
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
