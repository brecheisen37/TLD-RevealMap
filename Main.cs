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
		public override void OnUpdate()
		{
			base.OnUpdate();
			RevealifTrue();
		}

		
		static bool revealnextframe;
		public static void RevealNextFrame() { revealnextframe = true; }

		public static void RevealifTrue()
		{
			if (revealnextframe && InterfaceManager.m_Panel_Map != null && InterfaceManager.m_Panel_Map.IsEnabled()) 
				Reveal();
			revealnextframe = false;
		}
		static void Reveal()
		{
			if (InterfaceManager.m_Panel_Map.m_LastUpdatedLabel.text != Localization.Get("GAMEPLAY_MapLastUpdateJustNow"))
			{
				InterfaceManager.m_Panel_Map.RevealCurrentScene();
				InterfaceManager.m_Panel_Map.Enable(true, true);
			}
			
		}
	}
}





