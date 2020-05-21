using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using System.Collections.Generic;
using System.Linq;

namespace ToDoPlugin.SpanParsers {
	internal class SpanParserCollection : List<ISpanParser>, ISpanParser {

		public IEnumerable<ITagSpan<HighlightWordTag>> Parse(SnapshotSpan span) {
			IEnumerable<ITagSpan<HighlightWordTag>> result = new List<ITagSpan<HighlightWordTag>>();
			foreach (ISpanParser parser in this) {
				result = result.Union(parser.Parse(span));
			}
			return result;
		}
	}
}
