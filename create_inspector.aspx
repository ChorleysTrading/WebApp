<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="create_inspector.aspx.cs" Inherits="CLDV_POE_Part_3.create_inspector" %>

<!DOCTYPE html>
<html>
<head>
    <title>New Inspector</title>
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
        <h1>New Inspector</h1>
        <form id="formCreateInspector" runat="server">
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
        </form>
    </div>
</body>
</html>