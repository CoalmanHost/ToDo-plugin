using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System.Collections.Generic;
using System.Linq;

namespace ToDoPlugin.SpanParsers {
	internal class SpanParserCollection : List<ISpanParser>, ISpanParser {

		public IEnumerable<ClassificationSpan> Parse(SnapshotSpan span) {
			IEnumerable<ClassificationSpan> result = new List<ClassificationSpan>();
			foreach (ISpanParser parser in this) {
				result = result.Union(parser.Parse(span));
			}
			return result;
		}
	}
}
