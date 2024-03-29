﻿using System;
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
            if (ViewState["wallet"] == null)
            {
                ViewState["wallet"] = 100;
            }
            currentWalletTotalLabel.Text = ViewState["wallet"].ToString();
        }

        protected void LeverPullButton_Click(object sender, EventArgs e)
        {
            int wallet = int.Parse(ViewState["wallet"].ToString());

            if (!GetBet(out int currentBet))
            {
                SpinResultLabel.Text = "Please enter a valid dollar amount!";
                return;
            }

            string image1 = GetRandomImageName();
            string image2 = GetRandomImageName();
            string image3 = GetRandomImageName();

            SpinImage1.ImageUrl = "/Images/" + image1 + ".png";
            SpinImage2.ImageUrl = "/Images/" + image2 + ".png";
            SpinImage3.ImageUrl = "/Images/" + image3 + ".png";

            bool win = DetermineIfWin(image1, image2, image3, out string winCondition);

            int modifier = DeterminePayoutModifier(winCondition, image1, image2, image3);

            int winnings = currentBet * modifier;

            DisplayAdjustmentText(win, winnings, currentBet);

            wallet = UpdateWalletTotal(winnings, wallet);

            currentWalletTotalLabel.Text = wallet.ToString();

            ViewState["wallet"] = wallet;
        }

        private bool GetBet(out int currentBet)
        {
            if (!int.TryParse(BetTextBox.Text, out currentBet))
                return false;

            currentBet = int.Parse(BetTextBox.Text);
            return true;
        }

        private int UpdateWalletTotal(int wallet, int winnings)
        {
            wallet += winnings;
            return wallet;
        }

        private string GetRandomImageName()
        {
            string[] imageNames = new string[12] { "Bar", "Bell", "Cherry", "Clover", "Diamond", "HorseShoe", "Lemon", "Orange", "Plum", "Seven", "Strawberry", "Watermellon" };
            return imageNames[random.Next(0, imageNames.Length)];
        }
        private bool DetermineIfWin(string image1, string image2, string image3, out string winCondition)
        {
            if (image1 != "Bar" && image2 != "Bar" && image3 != "Bar")
            {
                if (image1 == "Cherry" || image2 == "Cherry" || image3 == "Cherry")
                {
                    winCondition = "Cherry";
                    return true;
                }
                else if (image1 == "Seven" && image2 == "Seven" && image3 == "Seven")
                {
                    winCondition = "Sevens";
                    return true;
                }
                else
                {
                    winCondition = "LOSS";
                    return false;
                }

            }
            winCondition = "LOSS";
            return false;
        }

        private int DeterminePayoutModifier(string winCondition, string image1, string image2, string image3)
        {
            if (winCondition == "Sevens")
            {
                return 100;
            }

            else if (winCondition == "Cherry")
            {
                int cherryCount = 0;

                if (image1 == "Cherry")
                    cherryCount++;

                if (image2 == "Cherry")
                    cherryCount++;

                if (image3 == "Cherry")
                    cherryCount++;

                return ++cherryCount;
            }

            else
                return -1;
        }

        private void DisplayAdjustmentText(bool win, int winnings, int currentBet)
        {
            if (win)
            {
                SpinResultLabel.Text = String.Format("You won {0:C}. Your bet of {1:C} seems to have been somewhat worth it.", System.Math.Abs(winnings), currentBet);
            }

            if (!win)
            {
                SpinResultLabel.Text = String.Format("You lost {0:C}. Your bet of {1:C} is mine now.", System.Math.Abs(winnings), currentBet);
            }
        }
    }
}