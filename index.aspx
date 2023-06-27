<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CLDV_POE_Part_3.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Login Screen</title>
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
            border-radius: 10px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            padding: 30px;
        }

        h2 {
            text-align: center;
            color: #333333;
            margin-bottom: 30px;
        }

        label {
            display: block;
            font-weight: bold;
            margin-bottom: 10px;
        }

        input[type="text"],
        input[type="password"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #cccccc;
            border-radius: 4px;
            margin-bottom: 15px;
        }

        .button-container {
            text-align: center;
        }

        .checkBox-container {
            text-align: left;
        }

        .button-container .btn {
            padding: 10px 25px;
            background-color: dodgerblue;
            color: #ffffff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
        }

            .button-container .btn:hover {
                background-color: #45a049;
            }

        .create-account {
            text-align: center;
            margin-top: 20px;
        }

        #Image1 {
            display: block;
            margin: 0 auto 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            
            <h2>Login<asp:Image ID="Image1" runat="server" Height="87px" Width="170px" ImageUrl="Image\carlogo.png" /></h2>
            <div>
                <label for="tbEmail">Email:</label>
                <label for="tbEmail">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbEmail" Display="Dynamic" ErrorMessage="Email required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </label>
                <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="tbCell" id="lblCell">Cell Number:</label>
                <label for="tbCell">
                    <asp:CustomValidator ID="validateLoginDetail" runat="server" Display="Dynamic" ErrorMessage="Either Email or Cell Number is incorrect" ForeColor="Red" OnServerValidate="validateLoginDetail_ServerValidate"></asp:CustomValidator>
                </label>
                &nbsp;
                <label for="tbCell">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbCell" Display="Dynamic" ErrorMessage="Cell number Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </label>
                <asp:TextBox ID="tbCell" runat="server"></asp:TextBox>
            </div>
            <div class="checkBox-container">
                <strong>Remember Me:</strong>
                <asp:CheckBox ID="cbRememberMe" runat="server" />
            </div>
            <div class="button-container">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn" ValidationGroup="loginGroup" />
            </div>
        </div>
    </form>
</body>
</html>