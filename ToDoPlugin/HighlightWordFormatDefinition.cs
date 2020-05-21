using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.Windows.Media;
using System.ComponentModel.Composition;

namespace ToDoPlugin {

	[Export(typeof(EditorFormatDefinition))]
	[Name("MarkerFormatDefinition/HighlightWordFormatDefinition")]
	[UserVisible(true)]
	internal class HighlightWordFormatDefinition : MarkerFormatDefinition {

		public HighlightWordFormatDefinition() {
			this.BackgroundColor = Colors.DarkRed;
			this.ForegroundColor = Colors.Red;
			this.ZOrder = 5;
			this.DisplayName = "Highlight Word";
		}
	}
}
