using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TapTapHeroesBot.Functions;

namespace TapTapHeroesBot.Functions
{
    class PixelChecker
    {

        /// <summary>
        /// Checks if a Pixel value in the process is the same as paramter passed through
        /// </summary>
        /// <param name="LocationToCheck"> Location of the pixel to check against </param>
        /// <param name="ColourToCheck"> Colour of the pixel to check against </param>
        /// <param name="ClickPixel"> If true pixel will be left clicked </param>
        /// <returns> True/False Depending on weather the pixel value matched.</returns>
        public static Boolean CheckPixelValue(Point LocationToCheck, Color ColourToCheck, Boolean ClickPixel = false)
        {
            Bitmap bmp = WindowCapture.CaptureApplication("Nox");
            Point ProcessLocation = WindowCapture.GetProcessPosition("Nox");
            Point PixelScreenLocation = new Point(LocationToCheck.X + ProcessLocation.X, LocationToCheck.Y + ProcessLocation.Y);

            if (bmp.GetPixel(LocationToCheck.X, LocationToCheck.Y) == ColourToCheck)
            {
                MouseHandler.MoveCursor(PixelScreenLocation);

                if (ClickPixel)
                {
                    MouseHandler.MouseLeftClick();
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Takes a screencap of process and gets the pixel value of location
        /// </summary>
        /// <param name="PixelLocation"> Pixel X & Y that you want the value of </param>
        /// <returns> returns colour of pixel </returns>
        public static Color GetPixelColor(Point PixelLocation)
        {
            Bitmap bmp = WindowCapture.CaptureApplication("Nox");
            Color PixelValue = bmp.GetPixel(PixelLocation.X, PixelLocation.Y);

            return PixelValue;
        }

    }
}
