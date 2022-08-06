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
        public override void OnApplicationStart()
        {
            Settings.Settings.OnLoad();
        }	

		public static void Reveal()
		{
			if (InterfaceManager.m_Panel_Map.m_LastUpdatedLabel.text != Localization.Get("GAMEPLAY_MapLastUpdateJustNow"))
			{
				InterfaceManager.m_Panel_Map.RevealCurrentScene();
				InterfaceManager.m_Panel_Map.ForceUpdateRegion();
			}
		}
	}
}





