using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using MelonLoader;
using ModSettings;
using UnityEngine;

namespace RevealMap
{



    public class RevealMap_Melon : MelonMod
    {
        public override void OnApplicationLateStart()
        {
            MelonDebug.Msg($"[{Info.Name}] Version {Info.Version} loaded!");
        }

        static bool SettingMatchesGamemode;
        public static void UpdateSettingMatchesGamemode()
        {
            SettingMatchesGamemode = settingMatchesGamemode();
        }
        static bool settingMatchesGamemode()
        {
            if (GameManager.IsTrialMode()) { return false; }
            if (Settings.Settings.options.story && GameManager.IsStoryMode()) { return true; }
            if (Settings.Settings.options.survival) { return true; }
            return false;
        }

        bool MapBeingOpened = false;
        bool lastmapenabled = false;
        public override void OnUpdate()
        {
            if(SettingMatchesGamemode)
            {
                /*
                    if (InterfaceManager.m_Panel_Map == null) MelonDebug.Msg("asdftext: m_Panel_Map == null");
                    else
                    if (InterfaceManager.m_Panel_Map.m_LastUpdatedLabel == null) MelonDebug.Msg("m_LastUpdatedLabel = null");
                    else
                    if (InterfaceManager.m_Panel_Map.m_LastUpdatedLabel.text == null) MelonDebug.Msg("asdftext: m_Panel_Map.m_LastUpdatedLabel.text = null");
                    else
                    {
                        if (InterfaceManager.m_Panel_Map.m_LastUpdatedLabel.text != Localization.Get("GAMEPLAY_MapLastUpdateJustNow")) { InterfaceManager.m_Panel_Map.RevealCurrentScene(); }
                    }
                */

                bool mapenabled = InterfaceManager.m_Panel_Map.enabled;
                if(mapenabled && !lastmapenabled) MapBeingOpened = true;
                if (MapBeingOpened)
                {
                    InterfaceManager.m_Panel_Map.RevealCurrentScene();
                    MapBeingOpened=false;
                }
                lastmapenabled = mapenabled;

            }
        }
        
        public override void OnApplicationStart()
        {
            Settings.Settings.OnLoad();
        }

    }
}





