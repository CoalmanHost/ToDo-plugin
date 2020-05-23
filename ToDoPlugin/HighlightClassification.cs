using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.Windows.Media;
using System.ComponentModel.Composition;
using ToDoPlugin.Settings;
using System.Linq;

namespace ToDoPlugin {

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = FormatName)]
	[Name(FormatName)]
	[UserVisible(true)]
	internal class HighlightClassification : ClassificationFormatDefinition {

		public const string FormatName = "ClassificationFormatDefinition/HighlightClassification";

		private readonly string Id;

		public HighlightClassification() {
			//if (SettingsContainer.CurrentPreset != null) {
			this.Id = SettingsContainer.CurrentPreset;
			this.BackgroundColor = SettingsContainer.Presets.Where(x => x.Word == Id).First().BackgroundColor;
			/*} else {
				System.Console.WriteLine("PReset is null");
			}*/
			//this.ForegroundColor = Colors.DarkGreen;
			BackgroundCustomizable = true;
			ForegroundCustomizable = true;
			this.DisplayName = "Highlight Word";
		}

		public void UpdatedSettings() {
			this.BackgroundColor = SettingsContainer.Presets.Where(x => x.Word == Id).First().BackgroundColor;
		}

	}
}
