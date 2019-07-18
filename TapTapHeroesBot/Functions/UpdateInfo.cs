using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TapTapHeroesBot.Functions;
using TapTapHeroesBot.Constants;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace TapTapHeroesBot.Functions
{
    class UpdateInfo
    {


        public static void updateAll()
        {
            GlobalVariables.QuestsDone = QuestsCompleted();
            MouseHandler.MoveCursorRealPos(LocationConstants.HEROES_SELECTED_CLOSE_LOCATION, true);
            Thread.Sleep(1000);
            MouseHandler.MoveCursorRealPos(LocationConstants.IDLE_CLICK, true);
            GlobalVariables.BossBatle = BossBattleAvailable();
            GlobalVariables.MailEmpty = MailEmpty(); //Will Always be true because if mail isn't empty it will claim all and then return true

            if (GlobalVariables.BossBatle)
            {
                if (Attack.AttackBoss())
                {
                    MouseHandler.MoveCursorRealPos(LocationConstants.HOME_NEXT_BATTLE_LOCATION, true);
                    Thread.Sleep(1000);
                    MouseHandler.MoveCursorRealPos(LocationConstants.HOME_NEXT_SELECT_BATTLE_LOCATION, true);
                }
                else
                {
                    //Add Methods to retry a maximum of two times and then give up
                }
            }
        }

        public static Boolean QuestsCompleted()
        {
            MouseHandler.MoveCursorRealPos(LocationConstants.HOME_MAINMENU_LOCATION, true);
            MouseHandler.MoveCursorRealPos(LocationConstants.MENU_QUESTS_BUTTON_LOCATION, true);
            return !PixelChecker.CheckPixelValue(LocationConstants.QUEST_CLAIMAIN_LOCATION, ColourConstants.QUEST_INACTIVE_COLOR); //If PixelCheck... is true then Quests arent Completed
        }

        public static Boolean EventsCompleted()
        {
            MouseHandler.MoveCursorRealPos(LocationConstants.HOME_MAINMENU_LOCATION, true);
            //MouseHandler.MoveCursor(LocationConstants., true);

            return PixelChecker.CheckPixelValue(LocationConstants.QUEST_CLAIMAIN_LOCATION, ColourConstants.QUEST_INACTIVE_COLOR);
        }

        public static Boolean MailEmpty()
        {

            Thread.Sleep(500);
            MouseHandler.MoveCursorRealPos(LocationConstants.HOME_MAINMENU_LOCATION, true);
            if (PixelChecker.CheckPixelValue(LocationConstants.MENU_MAIL_LOCATION, ColourConstants.MENU_REDINFO_MAIL_COLOR))
            {
                MouseHandler.MoveCursorRealPos(LocationConstants.MENU_MAIL_LOCATION, true);
                Thread.Sleep(700);
                MouseHandler.MoveCursorRealPos(LocationConstants.MAIL_RECEIVEALL, true);

                while (PixelChecker.CheckPixelValue(LocationConstants.MAIL_RECEIVE, ColourConstants.MAIL_DELETE))
                {
                    MouseHandler.MoveCursor(LocationConstants.MAIL_RECEIVE, true);
                }
            }
            else
            {
                MouseHandler.MoveCursorRealPos(LocationConstants.IDLE_CLICK, true);
            }

            return true;
        }

        public static Boolean BossBattleAvailable()
        {
            return PixelChecker.CheckPixelValue(LocationConstants.HOME_BOSS_BATTLE_LOCATION, ColourConstants.REDINFO_CIRCLE_BOSS_BATTLE_COLOR);
        }
    }
}
