<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="CLDV_POE_Part_3.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 20px;
        }

        .page-container {
            max-width: 800px;
            margin: 0 auto;
            background-color: #ffffff;
            border-radius: 5px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
            padding: 20px;
            margin-bottom: 20px;
        }

        h2 {
            text-align: center;
            color: #333333;
            margin-bottom: 20px;
        }

        h3 {
            text-align: left;
            color: white;
            margin-bottom: 20px;
        }

        .logout-button {
            text-align: right;
            margin-bottom: 20px;
        }

        .button-container {
            text-align: center;
        }

        .button-container .btn {
            padding: 10px 20px;
            background-color: dodgerblue;
            color: #ffffff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            margin-bottom: 10px;
        }

        .auto-style1 {
            text-align: right;
            margin-bottom: 20px;
            margin-top: 0px;
        }

        .listbox-container {
            max-width: 668px;
            overflow-x: auto;
        }

        .image-container {
            text-align: center;
            margin-bottom: 20px;
            position: relative;
        }

        .image-container img {
            position: absolute;
            animation: moveImage 10s linear infinite;
        }

        @keyframes moveImage {
            0% { left: 70%; }
            45% { left: calc(50% - 68.5px); }
            55% { left: calc(50% - 68.5px); }
            100% { left: 0; }
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="auto-style1">
            <asp:Button ID="btnLogout" runat="server" Text="Log out" OnClick="btnLogout_Click" />
        </div>
        <div class="page-container">
            <h2><strong>Home Page</strong></h2>
            <div class="image-container">
                <img id="movingImage" src="Image/carlogo.png" alt="Car Logo" height="90px" width="200px" />
            </div>
            <h3>.</h3>
            <div class="button-container">
                <asp:Button ID="btnManagement" runat="server" Text="Management" CssClass="btn" OnClick="btnManage_Click" Style="margin-top: 24px; margin-bottom: 6px" />
                <asp:Button ID="BtnRent" runat="server" Text="Rentals and Returns" CssClass="btn" OnClick="btnRent_Click" Style="margin-top: 24px; margin-bottom: 6px" />
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn" OnClick="btnSearch_Click" Style="margin-top: 24px; margin-bottom: 6px" />
            </div>
            
            <div class="listbox-container">
                
            </div>
        </div>

    </form>

    <script>
        // Wait for the document to load
        document.addEventListener("DOMContentLoaded", function () {
            // Get the image element
            var movingImage = document.getElementById("movingImage");

            // Get the width of the image
            var imageWidth = movingImage.offsetWidth;

            // Set the initial position of the image
            movingImage.style.left = "100%";

            // Pause the image for 5 seconds in the middle of the screen
            setTimeout(function () {
                // Move the image to the left
                movingImage.style.left = "0";

                // Start the animation
                function startAnimation() {
                    // Reset the position to the starting point
                    movingImage.style.left = "0";

                    // Trigger a reflow to restart the animation
                    void movingImage.offsetWidth;

                    // Add the animation class to start the animation
                    movingImage.classList.add("animate");
                }

                // Add an event listener to restart the animation when it ends
                movingImage.addEventListener("animationend", startAnimation);

                // Start the animation initially
                startAnimation();
            }, 5000);
        });
    </script>
</body>
</html>