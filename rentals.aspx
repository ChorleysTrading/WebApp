<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rentals.aspx.cs" Inherits="CLDV_POE_Part_3.rentals" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rent a Vehicle - Bookings</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

        .container {
            max-width: 400px;
            margin: 50px auto;
            background-color: #ffffff;
            border-radius: 5px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
            padding: 20px;
        }

        h1 {
            text-align: center;
            color: #333333;
            margin-bottom: 20px;
        }

        h2 {
            margin-bottom: 10px;
        }

        .datepicker {
            width: 95%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            margin-bottom: 10px;
        }

        .rental-fee {
            width: 95%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            margin-bottom: 10px;
        }

        .button-container {
            text-align: center;
            margin-top: 20px;
        }

        .button-container .btn {
            padding: 10px 20px;
            background-color: dodgerblue;
            color: #ffffff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
        }

        .button-container2 {
            text-align: center;
            margin-top: 20px;
        }

        .close-button {
            text-align: right;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Rent a Vehicle - Bookings</h1>

            <h2>From Date:</h2>
            <asp:TextBox ID="tbFromDate" runat="server" CssClass="datepicker" TextMode="Date" AutoPostBack="True"></asp:TextBox>

            <h2>To Date:</h2>
            <asp:TextBox ID="tbToDate" runat="server" CssClass="datepicker" TextMode="Date" OnTextChanged="tbToDate_TextChanged" AutoPostBack="True"></asp:TextBox>

            <h2>Rental Fee:</h2>
            <asp:TextBox ID="tbRentalFee" runat="server" CssClass="rental-fee" TextMode="Number"></asp:TextBox>

            <h2>Select Driver:</h2>
            <asp:DropDownList ID="cbDrivers" runat="server"></asp:DropDownList>

            <h2>Select Vehicle:</h2>
            <asp:DropDownList ID="cbVehicles" runat="server"></asp:DropDownList>

            <div class="button-container">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn" />
            </div>
        </div>

        <div class="container" id="cbVehicle">
            <h2>Select Vehicle Return</h2>
            <asp:Label ID="lblError" runat="server" Text="Select a vehicle:"></asp:Label>
            <asp:DropDownList ID="cbVehicleReturn" runat="server"></asp:DropDownList>
            <div>
                
            </div>

            <div class="button-container">
                <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click" CssClass="btn" ValidationGroup="returnVehicle" />
            </div>
            <div class="close-button">
                <asp:Button ID="Button3" runat="server" Text="Close" OnClick="btnClose_Click" />
            </div>
        </div>
    </form>
</body>
</html>
``
