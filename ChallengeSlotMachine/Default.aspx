<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeSlotMachine.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="SpinImage1" runat="server" Height="150px" />
            <asp:Image ID="SpinImage2" runat="server" Height="150px" />
            <asp:Image ID="SpinImage3" runat="server" Height="150px" />
            <br />
            <br />
            Your Bet: <asp:TextBox ID="BetTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="LeverPullButton" runat="server" OnClick="LeverPullButton_Click" Text="Pull the Lever!" />
            <br />
            <br />
            <asp:Label ID="SpinResultLabel" runat="server"></asp:Label>
            <br />
            <br />
            Player&#39;s Money:
            <asp:Label ID="currentWalletTotalLabel" runat="server"></asp:Label>
            <br />
            <br />
            1 Cherry - 2x Your Bet<br />
            2 Cherries - 3x Your Bet<br />
            3 Cherries - 4x Your Bet<br />
            <br />
            3 7&#39;s - JACKPOT! - 100x Your Bet
            <br />
            <br />
            <span class="auto-style1">If there is even one BAR, you lose!</span></div>
    </form>
</body>
</html>
