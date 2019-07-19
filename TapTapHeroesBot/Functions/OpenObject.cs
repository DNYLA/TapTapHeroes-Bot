using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TapTapHeroesBot.Constants;


namespace TapTapHeroesBot.Functions
{
    class OpenObject
    {


        public static void OpenCastle()
        {
            //Get Attention of screen incase its not ontop
            WindowCapture.CaptureApplication("Nox");

            //Opening up Castle And Resetting it
            MouseHandler.MoveCursorRealPos(LocationConstants.HOME_BOTTOM_CASTLE_LOCATION, true);
            MouseHandler.MoveCursorRealPos(LocationConstants.IDLE_CLICK);
            MouseHandler.ResetCastle();
            Main.Sleep(2);
        }

        public static void OpenBlackSmith()
        {
            OpenCastle();

            if (PixelChecker.CheckPixelValue(LocationConstants.CASTLE_BLACKSMITH_LOCATION, ColourConstants.CASTLE_BLACKSMITH_COLOR))
            {
                MouseHandler.MoveCursorRealPos(LocationConstants.CASTLE_BLACKSMITH_LOCATION, true);
            }
            else
            {
                //TODO: Max 3 Retry for recalling function
                OpenBlackSmith(); //Tries Again Until it is clicked
            }
        }

        public static void OpenHeroChest()
        {
            OpenCastle();

            if (PixelChecker.CheckPixelValue(LocationConstants.CASTLE_HERO_CHEST_CHECK_LOCATION, ColourConstants.CASTLE_HERO_CHEST_CHECK_COLOR))
            {
                MouseHandler.MoveCursorRealPos(LocationConstants.CASTLE_HERO_CHEST_LOCATION, true);
            }
            else
            {
                //TODO: Max 3 Retry for recalling function
                OpenHeroChest(); //Tries Again Until it is clicked
            }
        }

        public static void OpenAltar()
        {
            OpenCastle();

            if (PixelChecker.CheckPixelValue(LocationConstants.CASTLE_ALTAR_LOCATION, ColourConstants.CASTLE_ALTAR_COLOR))
            {
                MouseHandler.MoveCursorRealPos(LocationConstants.CASTLE_ALTAR_LOCATION, true);
            }
            else
            {
                //TODO: Max 3 Retry for recalling function
                OpenAltar(); //Tries Again Until it is clicked
            }
        }

        public static void OpenMarket()
        {
            OpenCastle();

            if (PixelChecker.CheckPixelValue(LocationConstants.CASTLE_MARKET_CHECK_LOCATION, ColourConstants.CASTLE_MARKET_CHECK_COLOR))
            {
                MouseHandler.MoveCursorRealPos(LocationConstants.CASTLE_MARKET_LOCATION, true);
            }
            else
            {
                //TODO: Max 3 Retry for recalling function
                OpenMarket(); //Tries Again Until it is clicked
            }
        }


        public static void OpenCreationBag()
        {
            OpenCastle();

            //Uses same Check as Above since its hard to check for creating bag since its an animation
            if (PixelChecker.CheckPixelValue(LocationConstants.CASTLE_MARKET_CHECK_LOCATION, ColourConstants.CASTLE_MARKET_CHECK_COLOR))
            {
                MouseHandler.MoveCursorRealPos(LocationConstants.CASTLE_CREATION_BAG_LOCATION, true);
            }
            else
            {
                //TODO: Max 3 Retry for recalling function
                OpenMarket(); //Tries Again Until it is clicked
            }
        }

        public static void OpenFortuneWheel()
        {
            OpenCastle();
            MouseHandler.MouseWheelUp();
            Main.Sleep(2);
            MouseHandler.MouseWheelUp();

            Point Location = new Point();

            if (PixelChecker.SearchPixel(ColourConstants.CASTLE_FORTUNE_WHEEL_COLOR, out Location))
            {
                MessageBox.Show("Successfully Found Pixel");
            }

            //Uses same Check as Above since its hard to check for creating bag since its an animation
            //if (PixelChecker.CheckPixelValue(LocationConstants.CASTLE_FORTUNE_WHEEL_LOCATION, ColourConstants.CASTLE_FORTUNE_WHEEL_COLOR))
            //{
            //    MouseHandler.MoveCursorRealPos(LocationConstants.CASTLE_FORTUNE_WHEEL_LOCATION, true);
            //}
            //else
            //{
            //    //TODO: Max 3 Retry for recalling function
            //    OpenFortuneWheel(); //Tries Again Until it is clicked
            //}
        }

    }
}
