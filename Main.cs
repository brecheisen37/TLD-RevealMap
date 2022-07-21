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

namespace TLD_Mod1
{



    public class RevealMap_Melon : MelonMod
    {
        public override void OnApplicationLateStart()
        {
            MelonDebug.Msg($"[{Info.Name}] Version {Info.Version} loaded!");

        }
        DetailSurveyPosition dsp = new DetailSurveyPosition();
        public override void OnUpdate()
        {
            if (InterfaceManager.m_Panel_Map == null) MelonDebug.Msg("asdftext: m_Panel_Map == null");
            else
            if (InterfaceManager.m_Panel_Map.m_LastUpdatedLabel == null) MelonDebug.Msg("m_LastUpdatedLabel = null");
            else
            if (InterfaceManager.m_Panel_Map.m_LastUpdatedLabel.text == null) MelonDebug.Msg("asdftext: m_Panel_Map.m_LastUpdatedLabel.text = null");
            else
            {
                if (InterfaceManager.m_Panel_Map.m_LastUpdatedLabel.text != Localization.Get("GAMEPLAY_MapLastUpdateJustNow")) { InterfaceManager.m_Panel_Map.RevealCurrentScene(); }
            }
            
        }
        
        

        public override void OnApplicationStart()
        {
            
        }

    }
}





