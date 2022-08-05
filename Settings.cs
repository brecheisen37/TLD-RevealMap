using System.IO;
using System.Reflection;
using UnityEngine;
using ModSettings;

namespace Settings
{
    internal class SettingsMain : JsonModSettings
    {

        [Name("Enable Mod")]
        [Description("Reveal map during story mode. Cannot be undone once game is saved.")]
        public bool enable = false;

        [Name("Story")]
		[Description("Reveal map during story mode. Cannot be undone once game is saved.")]
		public bool story = false;

		[Name("Survival")]
		[Description("Reveal map during survival mode. Cannot be undone once game is saved.")]
		public bool survival = false;

        [Name("Trials")]
        [Description("Reveal map during trials. Cannot be undone once game is saved.")]
        public bool trial = false;

        protected override void OnConfirm()
        {
            base.OnConfirm();
        }

		protected override void OnChange(FieldInfo field, object oldValue, object newValue)
		{
			if (field.Name == nameof(enable) ||
				field.Name == nameof(story) ||
				field.Name == nameof(survival) ||
				field.Name == nameof(trial))
			{
				RefreshFields();
			}
		}
		public void RefreshFields()
		{
			SetFieldVisible(nameof(story), Settings.options.enable);
			SetFieldVisible(nameof(survival), Settings.options.enable);
			SetFieldVisible(nameof(trial), Settings.options.enable);
		}

	}

    internal static class Settings
    {
        public static SettingsMain options;

        public static void OnLoad()
        {
            options = new SettingsMain();
            options.AddToModSettings("Reveal Map Settings");
			options.RefreshFields();
		}

    }
}
