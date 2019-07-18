using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using TapTapHeroesBot.Constants;
using TapTapHeroesBot.Functions;

namespace TapTapHeroesBot
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        public static string BotState = "None";

        public enum MouseEventFlags : uint
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010,
            WHEEL = 0x00000800,
            XDOWN = 0x00000080,
            XUP = 0x00000100
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void MouseClick()
        {
            mouse_event((uint)MouseEventFlags.LEFTDOWN, 0, 0, 0, 0);
            Thread.Sleep((new Random().Next(20, 30)));
            mouse_event((uint)MouseEventFlags.LEFTUP, 0, 0, 0, 0);
        }

        private void MouseWheelUp()
        {
            MouseHandler.MouseWheelUp();
        }

        private void MouseWheelDown()
        {

            MouseHandler.MouseWheelDown();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Bitmap BMP = WindowCapture.CaptureApplication("Nox");
            BMP.Save("Image.bmp", ImageFormat.Bmp);
            this.BackgroundImage = BMP;
            MouseHandler.MoveCursorRealPos(new Point(500, 800));
            MouseWheelUp();

        }


        

        public void ClickQuests()
        {

        }


        public void MoveCursor(Point Location, Color ColourToCheck, Point ProcLocation)
        {
            Bitmap BMP = WindowCapture.CaptureApplication("Nox");
            if (BMP.GetPixel(Location.X, Location.Y) == ColourToCheck)
            {
                Cursor.Position = new Point(Location.X + ProcLocation.X, Location.Y + ProcLocation.Y);
                MouseClick();
            }
            else
            {
                Cursor.Position = new Point(Location.X + ProcLocation.X, Location.Y + ProcLocation.Y);

                //MessageBox.Show("Invalid Position At " + Location.ToString());
                this.BringToFront();
            }
        }

        public void Sleep(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        public void UpgradeHeroes(Point ProcLocation)
        {
            MoveCursor(LocationConstants.HOME_BOTTOM_HEROES_LOCATION, ColourConstants.HOME_HEROES_BUTTON_COLOR, ProcLocation);

            Random Rand = new Random();
            int RanNum = Rand.Next(20);

            if (RanNum == 8)
            {
                for (int i = 1; i < 6; i++)
                {
                    MoveCursor(LocationConstants.HEROES_SIXTH_HERO_LOCATION, ColourConstants.HEROES_HERO_BUTTON_COLOR, ProcLocation);
                    MoveCursor(LocationConstants.HEROES_UPGRADE_NORMAL_LOCATION, ColourConstants.HEROES_UPGRADE_NORMAL_COLOR, ProcLocation);
                    MoveCursor(LocationConstants.HEROES_CLOSE_LOCATION, ColourConstants.GLOBAL_CLOSE_COLOR, ProcLocation);
                }
                MoveCursor(LocationConstants.HEROES_CLOSE_LOCATION, ColourConstants.GLOBAL_CLOSE_COLOR, ProcLocation);
            }

            MoveCursor(LocationConstants.HOME_BOSS_BATTLE_LOCATION, ColourConstants.REDINFO_CIRCLE_BOSS_BATTLE_COLOR, ProcLocation);

            MoveCursor(LocationConstants.BOSS_BATTLE_SELECT_LOCATION, ColourConstants.GLOBAL_ACCEPT_BUTTON, ProcLocation);
            MoveCursor(LocationConstants.BOSS_BATTLE_CONFIRM_LOCATION, ColourConstants.GLOBAL_ACCEPT_BUTTON, ProcLocation);
            Thread.Sleep(30000);
            MoveCursor(LocationConstants.GLOBAL_BATLE_FINISHED_LOCATION, ColourConstants.GLOBAL_OK_COLOR, ProcLocation);
            Thread.Sleep(1000);
            MoveCursor(LocationConstants.HOME_NEXT_BATTLE_LOCATION, ColourConstants.HOME_NEXT_BATTLE_COLOR, ProcLocation);
            MoveCursor(LocationConstants.HOME_NEXT_SELECT_BATTLE_LOCATION, ColourConstants.GLOBAL_ACCEPT_BUTTON, ProcLocation);
        }

        public void IdleCharacters(Point ProcLocation)
        {
            Cursor.Position = new Point(LocationConstants.IDLE_CLICK.X + ProcLocation.X, LocationConstants.IDLE_CLICK.X + ProcLocation.Y);
            MouseClick();

            Random Rand = new Random();
            int RanNum = Rand.Next(20);

            if (RanNum == 8)
            {
                for (int i = 1; i < 6; i++)
                {
                    MoveCursor(LocationConstants.HOME_BOTTOM_HEROES_LOCATION, ColourConstants.HOME_HEROES_BUTTON_COLOR, ProcLocation);
                    MoveCursor(LocationConstants.HEROES_SIXTH_HERO_LOCATION, ColourConstants.HEROES_HERO_BUTTON_COLOR, ProcLocation);
                    for(int x = 1; x < 5; x++)
                    {
                        MoveCursor(LocationConstants.HEROES_UPGRADE_NORMAL_LOCATION, ColourConstants.HEROES_UPGRADE_NORMAL_COLOR, ProcLocation);
                    }
                    MoveCursor(LocationConstants.HEROES_SELECTED_CLOSE_LOCATION, ColourConstants.GLOBAL_CLOSE_COLOR, ProcLocation);
                }
                Sleep(1);
                MoveCursor(LocationConstants.HEROES_CLOSE_LOCATION, ColourConstants.GLOBAL_CLOSE_COLOR, ProcLocation);
            }

            //MoveCursor(LocationConstants.HOME_BOSS_BATTLE_LOCATION, ColourConstants.REDINFO_CIRCLE_BOSS_BATTLE_COLOR, ProcLocation);
            //MoveCursor(LocationConstants.BOSS_BATTLE_SELECT_LOCATION, ColourConstants.GLOBAL_ACCEPT_BUTTON, ProcLocation);
            //MoveCursor(LocationConstants.BOSS_BATTLE_CONFIRM_LOCATION, ColourConstants.GLOBAL_ACCEPT_BUTTON, ProcLocation);
            //Thread.Sleep(30000);
            //MoveCursor(LocationConstants.BOSS_BATLE_FINISHED_LOCATION, ColourConstants.GLOBAL_OK_COLOR, ProcLocation);
            //Thread.Sleep(1000);
            //MoveCursor(LocationConstants.HOME_NEXT_BATTLE_LOCATION, ColourConstants.HOME_NEXT_BATTLE_COLOR, ProcLocation);
            //MoveCursor(LocationConstants.HOME_NEXT_SELECT_BATTLE_LOCATION, ColourConstants.GLOBAL_ACCEPT_BUTTON, ProcLocation);
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            //Takes Screenshot of Process
            Bitmap BMP = WindowCapture.CaptureApplication("Nox");
            BMP.Save("Image.bmp", ImageFormat.Bmp);
            this.BackgroundImage = BMP;

            //Gets X,Y of Process

            Point ProcLocation = WindowCapture.GetProcessPosition("Nox");
            Cursor.Position = new Point(LocationConstants.IDLE_CLICK.X + ProcLocation.X, LocationConstants.IDLE_CLICK.Y + ProcLocation.Y);

            //MouseClick();
            //Thread.Sleep(700);
            MouseWheelUp();
            Thread.Sleep(100);
            MouseWheelDown();

            BotState = "IdleAttack";

            Cursor.Position = new Point(50 + ProcLocation.X, 300 + ProcLocation.Y);
            while (BotState == "IdleAttack")
            {
                //IdleCharacters(ProcLocation);
                BotState = "No";

            }

            //MoveCursor(LocationConstants.HOME_MAINMENU_LOCATION, ColourConstants.REDINFO_CIRCLE_MAINMENU_COLOR, ProcLocation);
            //MoveCursor(LocationConstants.HOME_BOSS_BATTLE_LOCATION, ColourConstants.REDINFO_CIRCLE_BOSS_BATTLE_COLOR, ProcLocation);
            //MoveCursor(LocationConstants.MENU_QUESTS_BUTTON_LOCATION, ColourConstants.REDINFO_CIRCLE_MENU_QUESTS_COLOR, ProcLocation);
            //MoveCursor(LocationConstants.QUEST_BUTTON2_LOCATION, ColourConstants.QUEST_CLAIM_COLOR, ProcLocation);
            //MoveCursor(LocationConstants.QUEST_CLAIMAIN_LOCATION, ColourConstants.QUEST_INACTIVE_COLOR, ProcLocation);
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            //Takes Screenshot of Process
            Bitmap BMP = WindowCapture.CaptureApplication("Nox");
            BMP.Save("Image.bmp", ImageFormat.Bmp);
            this.BackgroundImage = BMP;

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            UpdateInfo.MailEmpty();
        }

        private void Button4_Click(object sender, EventArgs e)
        { 
            UpdateInfo.updateAll();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Bitmap BMP = WindowCapture.CaptureApplication("Nox");
            BMP.Save("Image.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            this.BackgroundImage = BMP;
            MouseHandler.MoveCursorRealPos(new Point(500, 800));
            MouseWheelDown();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Attack.DenOfSecretAttackHandler();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Main.ResetToHome();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            int GoldAmount = ImageToText.GetMoneyAmount();
            int GemAmount = ImageToText.GetGemAmount();
            int PlayerLevel = ImageToText.GetLevel();
            int PurpleSoulAmount = ImageToText.GetPurpleSoulAmount();
            int GoldenSoulAmount = ImageToText.GetGoldenSoulAmount();
            MessageBox.Show($"Gold: {GoldAmount}; Gems: {GemAmount}; Level: {PlayerLevel}; Purple Souls: {PurpleSoulAmount}; Golden Souls: {GoldenSoulAmount}");
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            OpenObject.OpenAltar();
        }
    }

}
