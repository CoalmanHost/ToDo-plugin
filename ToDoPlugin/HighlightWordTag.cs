using Microsoft.VisualStudio.Text.Tagging;

namespace ToDoPlugin {
	internal class HighlightWordTag : TextMarkerTag {

		public HighlightWordTag() : base("MarkerFormatDefinition/HighlightWordFormatDefinition") {
			
		}

	}
}
