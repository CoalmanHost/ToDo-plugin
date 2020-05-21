using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ToDoPlugin.SpanParsers {
	internal class RegexSpanParser : ISpanParser {

		private readonly Regex Checker;

		public RegexSpanParser(string regex) {
			Checker = new Regex(regex);
		}

		public RegexSpanParser(Regex regex) {
			Checker = regex;
		}

		public IEnumerable<ITagSpan<HighlightWordTag>> Parse(SnapshotSpan span) {
			var matches = Checker.Matches(span.GetText());
			if (matches.Count == 0) {
				yield break;
			}
			foreach (Match match in matches) {
				Span spanPart = new Span(span.Start.Position + match.Index, match.Length);
				SnapshotSpan target = new SnapshotSpan(span.Snapshot, spanPart);
				yield return new TagSpan<HighlightWordTag>(target, new HighlightWordTag());
			}
		}
	}
}
