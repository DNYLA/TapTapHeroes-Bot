using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TapTapHeroesBot.Constants
{
    class LocationConstants
    {

        //Global
        public static Point GLOBAL_BATTLE_ENEMYINFO_CONFIRM_LOCATION = new Point(320, 735);
        public static Point GLOBAL_BATTLE_TEAM_CONFIRM_LOCATION = new Point(315, 880);
        public static Point GLOBAL_BATTLE_SKIP_LOCATION = new Point(514, 861);
        public static Point GLOBAL_BATLE_FINISHED_LOCATION = new Point(314, 860);
        public static Point GLOBAL_BATTLE_WINCHECK_LOCATION = new Point(285, 449);
        public static Point IDLE_CLICK = new Point(352, 757);


        //Home Screen Buttons
        public static Point HOME_MAINMENU_LOCATION = new Point(136, 95);
        public static Point HOME_BOSS_BATTLE_LOCATION = new Point(332, 167);
        public static Point HOME_NEXT_BATTLE_LOCATION = new Point(311, 186);
        public static Point HOME_NEXT_SELECT_BATTLE_LOCATION = new Point(313, 679);

        //Home Bottom Buttons
        public static Point HOME_HEROES_LOCATION = new Point(46, 909);
        public static Point HOME_BOTTOM_CASTLE_LOCATION = new Point(404, 941);

        //Menu Buttons
        public static Point MENU_QUESTS_BUTTON_LOCATION = new Point(60, 424);
        public static Point MENU_MAIL_LOCATION = new Point(60, 763);

        //Quest Constants
        public static Point QUEST_CLAIMAIN_LOCATION = new Point(445, 245);
        public static Point QUEST_BUTTON2_LOCATION = new Point(447, 481);

        //Mail Menu
        public static Point MAIL_RECEIVE = new Point(392, 735);
        public static Point MAIL_RECEIVEALL = new Point(140, 734);

        //HERO BUTTON LOCATIONS
        public static Point HEROES_SIXTH_HERO_LOCATION = new Point(121, 361);
        public static Point HEROES_UPGRADE_NORMAL_LOCATION = new Point(273, 873);
        public static Point HEROES_SELECTED_CLOSE_LOCATION = new Point(508, 110);
        public static Point HEROES_CLOSE_LOCATION = new Point(508, 161);

        public static Point BOSS_BATTLE_SELECT_LOCATION = new Point(321, 735); //Change to GLOBAL_BATTLE_ENEMYINFO_CONFIRM_LOCATION
        public static Point BOSS_BATTLE_CONFIRM_LOCATION = new Point(315, 880); //Change To GLOBAL_BATTLE_TEAM_CONFIRM_LOCATION
        public static Point BOSS_BATTLE_FINISHED_BACK_LOCATION = new Point(274, 431);

        //Castle Buttons
        public static Point CASTLE_DOS_LOCATION = new Point(395, 328);

        //Den Of Secrets
        public static Point DOS_BATTLE_LOCATION = new Point(481, 615);

    }
}
