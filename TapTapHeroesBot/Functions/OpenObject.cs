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
            MouseHandler.MoveCursorRealPos(LocationConstants.CASTLE_SCROLL_LOCATION);
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

            //Mouse Wheel Up doesnt always move the same amount upwards so searching for the pixel is used instead of a specific location
            if (PixelChecker.SearchPixel(ColourConstants.CASTLE_FORTUNE_WHEEL_COLOR, out Point Location))
            {
                MouseHandler.MoveCursorRealPos(Location, true);
            }
            else
            {
                //TODO: Max 3 Retries before giving up
                OpenFortuneWheel();
            }
        }
        public static void OpenArena()
        {
            OpenCastle();
            MouseHandler.MouseWheelUp();
            Main.Sleep(1);
            MouseHandler.MouseWheelUp();


            //Mouse Wheel Up doesnt always move the same amount upwards so searching for the pixel is used instead of a specific location
            if (PixelChecker.SearchPixel(ColourConstants.CASTLE_ARENA_COLOR, out Point Location))
            {
                MouseHandler.MoveCursorRealPos(Location, true);
            }
            else
            {
                //TODO: Max 3 Retries before giving up
                OpenArena();
            }
        }

        public static void OpenDoS()
        {
            OpenCastle();
            MouseHandler.MouseWheelUp();
            Main.Sleep(1);
            MouseHandler.MouseWheelUp();
            Main.Sleep(1);
            MouseHandler.MouseWheelUp();


            //Mouse Wheel Up doesnt always move the same amount upwards so searching for the pixel is used instead of a specific location
            if (PixelChecker.SearchPixel(ColourConstants.CASTLE_DOS_COLOR, out Point Location))
            {
                MouseHandler.MoveCursorRealPos(Location, true);
            }
            else
            {
                //TODO: Max 3 Retries before giving up
                OpenDoS();
            }
        }

        public static void OpenMiracleEye()
        {
            OpenCastle();
            MouseHandler.MouseWheelUp();
            Main.Sleep(1);
            MouseHandler.MouseWheelUp();
            Main.Sleep(1);
            MouseHandler.MouseWheelUp();


            //Mouse Wheel Up doesnt always move the same amount upwards so searching for the pixel is used instead of a specific location
            if (PixelChecker.SearchPixel(ColourConstants.CASTLE_MIRACLE_EYE_COLOR, out Point Location))
            {
                MouseHandler.MoveCursorRealPos(Location, true);
            }
            else
            {
                //TODO: Max 3 Retries before giving up
                OpenMiracleEye();
            }
        }

        public static void OpenTavern()
        {
            OpenCastle();
            MouseHandler.MouseWheelUp();
            Main.Sleep(1);
            MouseHandler.MouseWheelUp();
            Main.Sleep(1);
            MouseHandler.MouseWheelUp();


            //Mouse Wheel Up doesnt always move the same amount upwards so searching for the pixel is used instead of a specific location
            if (PixelChecker.SearchPixel(ColourConstants.CASTLE_TAVERN_COLOR, out Point Location))
            {
                MouseHandler.MoveCursorRealPos(Location, true);
            }
            else
            {
                //TODO: Max 3 Retries before giving up
                OpenTavern();
            }
        }

        public static void OpenExpedition()
        {
            //No Need to call OpenCastle Since this is at top of castle

            //Get Attention of screen incase its not ontop
            WindowCapture.CaptureApplication("Nox");

            //Opening up Castle
            MouseHandler.MoveCursorRealPos(LocationConstants.HOME_BOTTOM_CASTLE_LOCATION, true);
            MouseHandler.MoveCursorRealPos(LocationConstants.CASTLE_SCROLL_LOCATION);
            Main.Sleep(2);

            //Scrolling to top of castle
            for (int i = 0; i < 8; i++)
            {
                MouseHandler.MouseWheelUp();
                Main.Sleep(1);
            }


            //Search Pixel Method is better than Specific location Since Expedition is an animation
            if (PixelChecker.SearchPixel(ColourConstants.CASTLE_EXPEDITION_COLOR, out Point Location))
            {
                MouseHandler.MoveCursorRealPos(Location, true);
            }
            else
            {
                //TODO: Max 3 Retries before giving up
                OpenExpedition();
            }
        }

        public static void OpenPlanetTrial()
        {
            //No Need to call OpenCastle Since this is at top of castle

            //Get Attention of screen incase its not ontop
            WindowCapture.CaptureApplication("Nox");

            //Opening up Castle
            MouseHandler.MoveCursorRealPos(LocationConstants.HOME_BOTTOM_CASTLE_LOCATION, true);
            MouseHandler.MoveCursorRealPos(LocationConstants.CASTLE_SCROLL_LOCATION);
            Main.Sleep(2);

            //Scrolling to top of castle
            for (int i = 0; i < 8; i++)
            {
                MouseHandler.MouseWheelUp();
                Main.Sleep(1);
            }


            //Search Pixel Method is better than Specific location Since Expedition is an animation
            if (PixelChecker.SearchPixel(ColourConstants.CASTLE_PLANET_TRIAL_COLOR, out Point Location))
            {
                MouseHandler.MoveCursorRealPos(Location, true);
            }
            else
            {
                //TODO: Max 3 Retries before giving up
                OpenPlanetTrial();
            }
        }


    }
}
