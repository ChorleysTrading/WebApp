<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="create_car.aspx.cs" Inherits="CLDV_POE_Part_3.create_car" %>

<!DOCTYPE html>
<html>
<head>
    <title>New Car</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }
        h1 {
            text-align: center;
            color: black;
        }
        .form-container {
            max-width: 400px;
            margin: 0 auto;
        }
        .form-group {
            margin-bottom: 20px;
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
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }
        .error {
            color: red;
        }
        .submit-button {
            background-color: dodgerblue;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <div class="form-container">
        <h1>New Car</h1>
        <form id="formCreateCar" runat="server">
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
                <label for="txtKilometeresTravelled">Kilometeres Travelled:</label>
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
        </form>
    </div>
</body>
</html>