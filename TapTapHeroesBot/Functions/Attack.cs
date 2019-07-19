using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TapTapHeroesBot.Constants;
using TapTapHeroesBot.Functions;
namespace TapTapHeroesBot.Functions
{
    class Attack
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>True if battle won. False is battle Lost</returns>
        public static Boolean AttackBoss()
        {
            MouseHandler.MoveCursorRealPos(LocationConstants.HOME_BOSS_BATTLE_LOCATION, true);
            Thread.Sleep(1000);
            MouseHandler.MoveCursorRealPos(LocationConstants.BOSS_BATTLE_SELECT_LOCATION, true);
            Thread.Sleep(1000);
            MouseHandler.MoveCursorRealPos(LocationConstants.BOSS_BATTLE_CONFIRM_LOCATION, true);

            bool BattleFinished = false;

            while (!BattleFinished)
            {
                Thread.Sleep(5000);

                if (PixelChecker.CheckPixelValue(LocationConstants.GLOBAL_BATLE_FINISHED_LOCATION, ColourConstants.GLOBAL_OK_COLOR, false))
                {
                    BattleFinished = true;
                }
            }

            bool Victory = false;
            Thread.Sleep(1000);
            if (PixelChecker.CheckPixelValue(LocationConstants.BOSS_BATTLE_FINISHED_BACK_LOCATION, ColourConstants.BATTLE_VICTORY_COLOR))
            {
                Victory = true;
                GlobalVariables.BossBatle = false;
                MessageBox.Show("Victory");
                Thread.Sleep(1000);
            }

            MouseHandler.MoveCursorRealPos(LocationConstants.GLOBAL_BATLE_FINISHED_LOCATION, true);

            return Victory;
        }


        public static void DenOfSecretAttackHandler()
        {
            //Gets Attention of screen incase its not ontop
            WindowCapture.CaptureApplication("Nox");

            //Reseting Screen To Home
            Main.ResetToHome();
            
            //Opening Dos
            OpenObject.OpenDoS();
            AttackMain();
        }

        public static void PlanetTrialAttackHandler()
        {
            //Gets Attention of screen incase its not ontop
            WindowCapture.CaptureApplication("Nox");

            //Reseting Screen To Home
            Main.ResetToHome();

            //Opening Dos
            OpenObject.OpenPlanetTrial();
            AttackMain();
        }

        public static void AttackMain()
        {
            bool AttackingDoS = true;

            while (AttackingDoS)
            {
                for (int CurrentTry = 0; CurrentTry < OtherConstants.ATTACK_RETRY_AMOUNT; CurrentTry++)
                {
                    Thread.Sleep(1000);
                    MouseHandler.MoveCursorRealPos(LocationConstants.DOS_BATTLE_LOCATION, true);
                    MouseHandler.MoveCursorRealPos(LocationConstants.GLOBAL_BATTLE_ENEMYINFO_CONFIRM_LOCATION, true);
                    MouseHandler.MoveCursorRealPos(LocationConstants.GLOBAL_BATTLE_TEAM_CONFIRM_LOCATION, true);
                    Thread.Sleep(2000);
                    MouseHandler.MoveCursorRealPos(LocationConstants.GLOBAL_BATTLE_SKIP_LOCATION, true);
                    MouseHandler.MoveCursorRealPos(LocationConstants.GLOBAL_BATTLE_SKIP_CONFIRM_LOCATION, true);
                    bool BattleFinished = false;

                    while (!BattleFinished)
                    {
                        Thread.Sleep(2000);

                        if (PixelChecker.CheckPixelValue(LocationConstants.GLOBAL_BATLE_FINISHED_LOCATION, ColourConstants.GLOBAL_OK_COLOR, false))
                        {
                            BattleFinished = true;
                        }
                    }

                    if (PixelChecker.CheckPixelValue(LocationConstants.GLOBAL_BATTLE_WINCHECK_LOCATION, ColourConstants.GLOBAL_BATTLE_VICTORY))
                    {
                        Thread.Sleep(1000);
                        MouseHandler.MoveCursorRealPos(LocationConstants.GLOBAL_BATLE_FINISHED_LOCATION, true);
                        break;
                    }
                    else
                    {
                        Thread.Sleep(1000);
                        Thread.Sleep(1000);
                        MouseHandler.MoveCursorRealPos(LocationConstants.GLOBAL_BATLE_FINISHED_LOCATION, true);
                        if (CurrentTry == 2)
                        {
                            AttackingDoS = false;
                        }
                    }

                }
                Thread.Sleep(1000);
            }

            MessageBox.Show("Failed After 3 Attempts on Same Level");
        }

    }
}
