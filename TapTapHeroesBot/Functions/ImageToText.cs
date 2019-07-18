using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TapTapHeroesBot.Constants;
using TapTapHeroesBot.Functions;
using IronOcr;

namespace TapTapHeroesBot.Functions
{
    class ImageToText
    {
        public static String ImageText(Point Location, Size SizeOfRec)
        {
            Rectangle section = new Rectangle(Location, SizeOfRec);

            Bitmap ScreenCap = WindowCapture.CaptureApplication("Nox");
            Bitmap ExtractedPart = new Bitmap(section.Width, section.Height);

            Graphics G = Graphics.FromImage(ExtractedPart);

            G.DrawImage(ScreenCap, 0, 0, section, GraphicsUnit.Pixel);

            var Ocr = new AdvancedOcr()
            {
                CleanBackgroundNoise = false,
                EnhanceContrast = true,
                EnhanceResolution = true,
                Language = IronOcr.Languages.English.OcrLanguagePack,
                Strategy = IronOcr.AdvancedOcr.OcrStrategy.Advanced,
                ColorSpace = AdvancedOcr.OcrColorSpace.GrayScale,
                DetectWhiteTextOnDarkBackgrounds = true,
                InputImageType = AdvancedOcr.InputTypes.AutoDetect,
                RotateAndStraighten = false,
                ReadBarCodes = false,
                ColorDepth = 24
            };

            var Results = Ocr.Read(ExtractedPart);

            ExtractedPart.Save("Test.bmp");

            return Results.Text;
        }

        public static int GetGemAmount()
        {

        }

        public static int GetMoneyAmount()
        {
            string MoneyText = ImageText(TextConstants.MONEY_START, TextConstants.MONEY_SIZE);
            MoneyText = MoneyText.ToLower();
            MessageBox.Show(MoneyText.ToString());
            int MoneyLen = MoneyText.Length;
            int MoneyValue = 0;

            if (MoneyText.EndsWith("k"))
            {
                MoneyValue = MultiplyValue(MoneyText, 1000);
            }
            else if (MoneyText.EndsWith("m"))
            {
                MoneyValue = MultiplyValue(MoneyText, 1000000);
            }
            else
            {
                MoneyValue = MultiplyValue(MoneyText, 1);
            }

            MessageBox.Show(MoneyValue.ToString());
            return MoneyValue;
        }

        public static int MultiplyValue(string ValToMultiply, int Amount)
        {
            try
            {
                return Convert.ToInt32(ValToMultiply.Substring(0, ValToMultiply.Length - 1)) * Amount;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
