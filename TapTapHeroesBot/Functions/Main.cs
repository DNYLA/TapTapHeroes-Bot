using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TapTapHeroesBot.Constants;
using TapTapHeroesBot.Functions;

namespace TapTapHeroesBot.Functions
{
    class Main
    {
        public static void IdleClick(int ClickAmount)
        {
            for (int i = 0; i < ClickAmount; i++)
            {
                MouseHandler.MoveCursorRealPos(LocationConstants.IDLE_CLICK, true);
            }
        }

        /// <summary>
        /// Function that resets game back to main menu
        /// </summary>
        /// <returns>Returns true if menu is reset to home (Will return true 99% of the time) </returns>
        public static Boolean ResetToHome()
        {
            //Force Back To Main Menu && Collects Any Gold (Thats Why Its ran 10 times)
            for (int i = 0; i < 8; i++)
            {
                MouseHandler.MoveCursorRealPos(LocationConstants.HOME_BOTTOM_BATTLE_LOCATION, true);
            }


            //Check If Menu is Open And Close it if it is
            if (isMenuOpen())
            {
                IdleClick(4); //Idle Click Position Will close menu
                MessageBox.Show("Menu Open");
            }

            //Check If BattleMenu Active And Return True
            if (isHome())
            {
                return true;
            }

            /* Going to Do this bit later since i need to find a place where the above will not return True
             * What i need to check ofr is 
             * If Not At Home check for X Button and Click
             * Multiple Close Button Locations
             */ 
            //Do Comment Above Here


            //ReCheck If Home
            if (isHome())
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sleep Handler
        /// </summary>
        /// <param name="seconds"> Amount of seconds to sleep for </param>
        public static void Sleep(int seconds)
        {
            System.Threading.Thread.Sleep(seconds * 1000);
        }

        public static Boolean isHome()
        {
            if (PixelChecker.CheckPixelValue(LocationConstants.HOME_BOTTOM_ACTIVE_BATTLE_LOCATION, ColourConstants.HOME_BOTTOM_ACTIVE_BATTLE_COLOR))
            {
                return true;
            }
            return false;
        }

        public static Boolean isMenuOpen()
        {
            if (PixelChecker.CheckPixelValue(LocationConstants.MENU_OPTIONS_LOCATION, ColourConstants.MENU_OPTIONS_COLOR))
            {
                return true;
            }

            return false;
        }

    }
}
