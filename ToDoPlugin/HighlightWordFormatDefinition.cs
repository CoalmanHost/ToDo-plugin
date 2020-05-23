using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.Windows.Media;
using System.ComponentModel.Composition;
using ToDoPlugin.Settings;
using System.Linq;

namespace ToDoPlugin {

	[Export(typeof(EditorFormatDefinition))]
	[Name(FormatName)]
	[UserVisible(true)]
	internal class HighlightWordFormatDefinition : MarkerFormatDefinition {

		public const string FormatName = "MarkerFormatDefinition/HighlightWordFormatDefinition";

		private readonly string Id;


		public HighlightWordFormatDefinition() {
			//if (SettingsContainer.CurrentPreset != null) {
			this.Id = SettingsContainer.CurrentPreset;
			this.BackgroundColor = SettingsContainer.Presets.Where(x => x.Word == Id).First().BackgroundColor;
			SettingsContainer.UpdateSettings += UpdatedSettings;
			/*} else {
				System.Console.WriteLine("PReset is null");
			}*/
			//this.ForegroundColor = Colors.DarkGreen;
			BackgroundCustomizable = true;
			ForegroundCustomizable = true;
			this.ZOrder = 5;
			this.DisplayName = "Highlight Word";
		}

		public void UpdatedSettings() {
			this.BackgroundColor = SettingsContainer.Presets.Where(x => x.Word == Id).First().BackgroundColor;
		}

	}
}
