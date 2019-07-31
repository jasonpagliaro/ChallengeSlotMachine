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
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO Display player's current wallet
        }

        protected void LeverPullButton_Click(object sender, EventArgs e)
        {
            int currentBet = 0;

            if (!GetBet(out currentBet))
            {
                SpinResultLabel.Text = "Please enter a valid dollar amount!";
            }


            //TODO Display random images

            //TODO Evaluate images

            //TODO Determine win/loss

            //TODO Find payout modifier

            //TODO Calculate winnings (if applicable)

            //TODO Calculate loss (different method?)

            //TODO Output result of current bet with win/loss amount

            //TODO Update player's wallet value

            TestingLabel.Text = currentBet.ToString();
        }

        private bool GetBet(out int currentBet)
        {
            if (!int.TryParse(BetTextBox.Text, out currentBet))
                return false;

            currentBet = int.Parse(BetTextBox.Text);
            return true;
        }
    }
}