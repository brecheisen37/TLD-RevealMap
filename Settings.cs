using System.IO;
using System.Reflection;
using UnityEngine;
using ModSettings;

namespace Settings
{
    internal class SettingsMain : JsonModSettings
    {

		[Name("Story")]
		[Description("Reveal map during story mode. Cannot be undone once game is saved.")]
		public bool story = false;

		[Name("Survival")]
		[Description("Reveal map during survival mode. Cannot be undone once game is saved.")]
		public bool survival = false;

        

    }

    internal static class Settings
    {
        public static SettingsMain options;

        public static void OnLoad()
        {
            options = new SettingsMain();
            options.AddToModSettings("Reveal Map Settings");
		}
    }
}
