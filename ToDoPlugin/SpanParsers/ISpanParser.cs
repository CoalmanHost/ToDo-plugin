using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using System.Collections.Generic;

namespace ToDoPlugin.SpanParsers {

	internal interface ISpanParser {

		IEnumerable<ITagSpan<HighlightWordTag>> Parse(SnapshotSpan span);

	}
}
