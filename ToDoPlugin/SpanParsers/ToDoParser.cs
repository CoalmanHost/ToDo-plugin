using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPlugin.SpanParsers {
	internal class ToDoParser : ISpanParser {
		public IEnumerable<ITagSpan<HighlightWordTag>> Parse(SnapshotSpan span) {
			string code = span.GetText();
			if (!code.Contains("TODO")) {
				yield break;
			}
			int startIndex = code.IndexOf("TODO");
			var spanWord = new Span(span.Start.Position + startIndex, 4);
			var targetSpan = new SnapshotSpan(span.Snapshot, spanWord);
			
			yield return new TagSpan<HighlightWordTag>(targetSpan, new HighlightWordTag());
		}
	}
}
