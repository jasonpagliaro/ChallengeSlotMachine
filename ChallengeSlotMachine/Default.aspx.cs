using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeSlotMachine
{
    public partial class Default : System.Web.UI.Page
    {
        Random random = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            int walletTotal = 100;
            UpdateWalletTotal(walletTotal);
        }

        protected void LeverPullButton_Click(object sender, EventArgs e)
        {
            int currentBet = 0;

            if (!GetBet(out currentBet))
            {
                SpinResultLabel.Text = "Please enter a valid dollar amount!";
            }
            
            SpinImage1.ImageUrl = GetRandomImageURL();
            SpinImage2.ImageUrl = GetRandomImageURL();
            SpinImage3.ImageUrl = GetRandomImageURL();

            //TODO Evaluate images

            //TODO Determine win/loss

            //TODO Find payout modifier

            //TODO Calculate winnings (if applicable)

            //TODO Calculate loss (different method?)

            //TODO Output result of current bet with win/loss amount

            //TODO Update player's wallet value

            //TODO Display player's updated wallet value

            //TestingLabel.Text = image1URL;

        }

        private bool GetBet(out int currentBet)
        {
            if (!int.TryParse(BetTextBox.Text, out currentBet))
                return false;

            currentBet = int.Parse(BetTextBox.Text);
            return true;
        }

        private void UpdateWalletTotal(int walletTotal)
        {
            currentWalletTotalLabel.Text = walletTotal.ToString();
        }

        private string GetRandomImageURL()
        {
            string[] imageNames = new string[12] { "Bar", "Bell", "Cherry", "Clover", "Diamond", "HorseShoe", "Lemon", "Orange", "Plum", "Seven", "Strawberry", "Watermellon" };
            return "/Images/" + imageNames[random.Next(0, imageNames.Length)] + ".png";
        }

    }
}