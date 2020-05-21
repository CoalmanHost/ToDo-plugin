using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.Text.Tagging;
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
			this.DisplayName = "test bl";
		}



	}
}
