﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using ToDoPlugin.Settings.Savers;

namespace ToDoPlugin.Settings {
	internal static class SettingsContainer {

		private const string SettingsFilePath = "todo_settings.json";

		public static ICollection<Preset> Presets { get; private set; }

		public static IEnumerable<Preset> ShownPresets => Presets.Where(x => x.IsShown);

		private static readonly ISettingsSaver SettingsSaver;

		static SettingsContainer() {
			SettingsSaver = new JsonSettingsSaver();
			if (File.Exists(SettingsFilePath)) {
				Presets = SettingsSaver.LoadFromFile(SettingsFilePath).ToList();
			} else {
				CreateDefaultPresets();
				SettingsSaver.SaveToFile(SettingsFilePath, Presets);
			}
		}

		private static void CreateDefaultPresets() {
			Presets = new List<Preset> {
				new Preset() { BackgroundColor = Colors.LightGreen, IsShown = true, Word = "TODO" },
				new Preset() { BackgroundColor = Colors.LightGreen, IsShown = true, Word = "FIXME" }
			};
		}

		public static void SaveSettings() {
			SettingsSaver?.SaveToFile(SettingsFilePath, Presets);
		}

	}
}
