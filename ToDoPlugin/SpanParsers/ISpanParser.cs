using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System.Collections.Generic;

namespace ToDoPlugin.SpanParsers {

	internal interface ISpanParser {

		IEnumerable<ClassificationSpan> Parse(SnapshotSpan span);

	}
}
