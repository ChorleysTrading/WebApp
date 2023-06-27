<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuccessPage.aspx.cs" Inherits="CLDV_POE_Part_3.SuccessPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Success</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
        }

        .container {
            max-width: 400px;
            margin: 0 auto;
            padding: 40px;
            text-align: center;
            background-color: #ffffff;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 4px;
            margin-top: 100px;
        }

        h1 {
            color: white;
            margin-bottom: 20px;
        }

        p {
            font-size: 18px;
            color: dodgerblue;
        }

        .success-textbox {
            background-color: white;
            color: dodgerblue;
            padding: 10px;
            border-radius: 4px;
            font-weight: 500;
            font-size: 25px;
            margin-top: 20px;
            max-width: 200px;
            position: center;
            margin-left: 90px;
        }

        .image-container {
            margin-bottom: 40px;
            position: relative;
        }

        .image-container img {
            position: absolute;
            top: 0;
            left: 50%;
            transform: translateX(-50%);
            animation: moveImage 10s linear infinite;
        }

        .button-container {
            margin-top: 40px;
        }

        .btn-home {
            background-color: dodgerblue;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
        }

        @keyframes moveImage {
            0% { left: 80%; }
            45% { left: calc(50% - 10px); }
            55% { left: calc(50% - 10px); }
            100% { left: 20%; }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="image-container">
                <img id="movingImage" src="Image/carlogo.png" alt="Success" height="100px" width="200px" />
            </div>
            <h1>.</h1>
            
            <div class="success-textbox">
                Success!
            </div>
            <div class="text-container">
                <p>Your request has been successfully processed.</p>
            </div>
            <div class="button-container">
                <asp:Button ID="btnHome" runat="server" Text="Home" CssClass="btn-home" OnClick="btnHome_Click" />
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
