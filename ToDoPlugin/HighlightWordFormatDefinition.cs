using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.Windows.Media;
using System.ComponentModel.Composition;

namespace ToDoPlugin {

	[Export(typeof(EditorFormatDefinition))]
	[Name(FormatName)]
	[UserVisible(true)]
	internal class HighlightWordFormatDefinition : MarkerFormatDefinition {

		public const string FormatName = "MarkerFormatDefinition/HighlightWordFormatDefinition";

		public HighlightWordFormatDefinition() {
			this.BackgroundColor = Colors.LimeGreen;
			this.ForegroundColor = Colors.DarkGreen;
			this.ZOrder = 5;
			this.DisplayName = "Highlight Word";
		}
	}
}
