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
        public static String ImageText(Point Location, Size SizeOfRec, bool EnhanceContrast = true, bool EnchanceResolution = true, bool Advanced = true, bool RotateStraight = false)
        {
            Rectangle section = new Rectangle(Location, SizeOfRec);

            Bitmap ScreenCap = WindowCapture.CaptureApplication("Nox");
            Bitmap ExtractedPart = new Bitmap(section.Width, section.Height);

            Graphics G = Graphics.FromImage(ExtractedPart);

            G.DrawImage(ScreenCap, 0, 0, section, GraphicsUnit.Pixel);

            AdvancedOcr.OcrStrategy StratType = AdvancedOcr.OcrStrategy.Fast;

            if (Advanced)
            {
                StratType = AdvancedOcr.OcrStrategy.Advanced;
            }

            var Ocr = new AdvancedOcr()
            {
                CleanBackgroundNoise = false,
                EnhanceContrast = EnhanceContrast,
                EnhanceResolution = EnchanceResolution,
                Language = IronOcr.Languages.English.OcrLanguagePack,
                Strategy = StratType,
                ColorSpace = AdvancedOcr.OcrColorSpace.GrayScale,
                DetectWhiteTextOnDarkBackgrounds = true,
                InputImageType = AdvancedOcr.InputTypes.AutoDetect,
                RotateAndStraighten = RotateStraight,
                ReadBarCodes = false,
                ColorDepth = 24
            };
            var Results = Ocr.Read(ExtractedPart);

            ExtractedPart.Save("Test.bmp");

            return Results.Text;
        }

        public static int GetLevel()
        {
            string PlayerLevel = ImageText(TextConstants.LEVEL_START, TextConstants.HOME_LEVEL_SIZE, false, true, false, false);
            if (PlayerLevel.StartsWith("Level "))
            {
                PlayerLevel = PlayerLevel.TrimStart("Level ".ToCharArray());
            }

            try
            {
                return Convert.ToInt32(PlayerLevel.Substring(0, PlayerLevel.Length));
            }
            catch
            {
                return -1;
            }
        }

        public static int GetGemAmount()
        {
            string GemAmount = ImageText(TextConstants.GEM_START, TextConstants.GLOBAL_CURRENCY_SIZE, true, true, false, false);
            try
            {
                return Convert.ToInt32(GemAmount.Substring(0, GemAmount.Length));
            }
            catch
            {
                return -1;
            }
        }

        public static int GetMoneyAmount()
        {
            string MoneyText = ImageText(TextConstants.MONEY_START, TextConstants.GLOBAL_CURRENCY_SIZE, true, true, true, false);
            MoneyText = MoneyText.ToLower();

            MessageBox.Show(MoneyText);

            int MoneyLen = MoneyText.Length;
            int MoneyValue;

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
                MoneyValue = ConvertToString(MoneyText);
            }

            return MoneyValue;
        }


        public static int GetPurpleSoulAmount()
        {
            string PurpleSoulText = ImageText(TextConstants.ALTAR_PURPLE_SOUL_START, TextConstants.ALTAR_SOUL_SIZE, true, true, false, false);
            PurpleSoulText = PurpleSoulText.ToLower();


            int PurpleSoulValue;

            if (PurpleSoulText.EndsWith("k"))
            {
                PurpleSoulValue = MultiplyValue(PurpleSoulText, 1000);
            }
            else if (PurpleSoulText.EndsWith("m"))
            {
                PurpleSoulValue = MultiplyValue(PurpleSoulText, 1000000);
            }
            else
            {

                PurpleSoulValue = ConvertToString(PurpleSoulText);
            }

            return PurpleSoulValue;
        }

        public static int GetGoldenSoulAmount()
        {
            string GoldenSoulText = ImageText(TextConstants.ALTAR_GOLDEN_SOUL_START, TextConstants.ALTAR_SOUL_SIZE, false, false, false, false);
            MessageBox.Show(GoldenSoulText);
            try
            {
                return Convert.ToInt32(GoldenSoulText.Substring(0, GoldenSoulText.Length));
            }
            catch
            {
                return -1;
            }
        }


        public static int ConvertToString(string value)
        {
            try
            {
                return Convert.ToInt32(value.Substring(0, value.Length));
            }
            catch (Exception ex)
            {
                return -1;
            }
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
