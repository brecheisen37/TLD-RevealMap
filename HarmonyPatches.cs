using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using MelonLoader;
using UnityEngine;

namespace TLD_Mod1
{
    internal class HarmonyPatches
    {

        static bool settingMatchesGamemode()
        {
            if (Settings.Settings.options.enable)
            {
                if (Settings.Settings.options.trial && GameManager.IsTrialMode()) { return true; }
                if (Settings.Settings.options.story && GameManager.IsStoryMode()) { return true; }
                if (Settings.Settings.options.survival) { return true; }
            }
            return false;
        }

        [HarmonyPatch(typeof(Panel_Map), "Enable", new Type[] { typeof(bool), typeof(bool) })]
        public class PatchEnable
        {
            public static void Postfix()
            {
                if (settingMatchesGamemode()) { RevealMap.RevealMap_Melon.Reveal(); }
            }
            
        }
    }
}
