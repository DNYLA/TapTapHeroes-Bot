using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TapTapHeroesBot.Constants
{
    class ColourConstants
    {

        //Close Button
        public static Color GLOBAL_CLOSE_COLOR = Color.FromArgb(242, 242, 255);
        public static Color GLOBAL_ACCEPT_BUTTON = Color.FromArgb(255, 211, 23);
        public static Color GLOBAL_OK_COLOR = Color.FromArgb(159, 223, 46);
        public static Color GLOBAL_BATTLE_ACTIVE = Color.FromArgb(160, 227, 57);
        public static Color GLOBAL_BATTLE_CONFIRM_YELLOW = Color.FromArgb(255, 211, 23);
        public static Color GLOBAL_BATTLE_VICTORY = Color.FromArgb(182, 36, 63);
        public static Color GLOBAL_BATTLE_LOST = Color.FromArgb(86, 86, 115);


        //Each Red circle isn't the same
        //Red Circle Constants
        //Home Constants
        public static Color REDINFO_CIRCLE_MAINMENU_COLOR = Color.FromArgb(255, 68, 15);
        public static Color REDINFO_CIRCLE_BOSS_BATTLE_COLOR = Color.FromArgb(253, 66, 14);

        //Menu Constants
        public static Color REDINFO_CIRCLE_MENU_QUESTS_COLOR = Color.FromArgb(255, 69, 16);
        public static Color MENU_REDINFO_MAIL_COLOR = Color.FromArgb(255, 68, 14);
        public static Color MENU_OPTIONS_COLOR = Color.FromArgb(0, 199, 255);

        //Home Constants
        public static Color HOME_HEROES_BUTTON_COLOR = Color.FromArgb(68, 62, 83);
        public static Color HOME_NEXT_BATTLE_COLOR = Color.FromArgb(223, 204, 69);

        //Home Bottom
        public static Color HOME_BOTTOM_ACTIVE_BATTLE_COLOR = Color.FromArgb(223, 232, 242);

        //Hero Menu
        public static Color HEROES_HERO_BUTTON_COLOR = Color.FromArgb(254, 224, 50);
        public static Color HEROES_UPGRADE_NORMAL_COLOR = Color.FromArgb(255, 230, 101);

        //DOS
        

        //Mail Menu
        public static Color MAIL_ACCEPT = Color.FromArgb(160, 227, 57); //Change to Global Battle Active
        public static Color MAIL_DELETE = Color.FromArgb(255, 60, 38);

        //QUEST CONSTANTS
        public static Color QUEST_INACTIVE_COLOR = Color.FromArgb(203, 203, 203);
        public static Color QUEST_CLAIM_COLOR = Color.FromArgb(219, 90, 0);

        //Win
        public static Color BATTLE_VICTORY_COLOR = Color.FromArgb(178, 34, 63);

    }
}
