using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPlugin {
	internal class HighlightWordTag : TextMarkerTag {

		public HighlightWordTag() : base("MarkerFormatDefinition/HighlightWordFormatDefinition") {

		}

	}
}
