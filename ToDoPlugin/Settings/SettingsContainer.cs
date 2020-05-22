using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ToDoPlugin.Settings {
	internal static class SettingsContainer {

		public static ICollection<HighlightingWordSettings> Presets { get; private set; }

		static SettingsContainer() {
			Presets = new List<HighlightingWordSettings>();
			Presets.Add(new HighlightingWordSettings() { BackgroundColor = Color.FromRgb(0, 255, 0), IsShown = true, Word = "TODO" });
		}

	}
}
