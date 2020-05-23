using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ToDoPlugin.Settings {
	internal static class SettingsContainer {

		public static string CurrentPreset { get; set; }

		public static ICollection<Preset> Presets { get; private set; }

		public static IEnumerable<Preset> ShownPresets => Presets.Where(x => x.IsShown);

		static SettingsContainer() {
			Presets = new List<Preset>();
			Presets.Add(new Preset() { BackgroundColor = Colors.LightGreen, IsShown = true, Word = "TODO" });
			Presets.Add(new Preset() { BackgroundColor = Colors.DarkCyan, IsShown = true, Word = "FIXME" });
			CurrentPreset = Presets.First().Word;
		}

	}
}
