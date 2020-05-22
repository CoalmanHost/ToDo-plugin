using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ToDoPlugin.SpanParsers {
	internal class CommentSectionParser : ISpanParser {

		private RegexSpanParser InnerParser = new RegexSpanParser(new Regex(@"TODO\b", RegexOptions.IgnoreCase));

		public IEnumerable<ITagSpan<HighlightWordTag>> Parse(SnapshotSpan span) {
			IEnumerable<ITagSpan<HighlightWordTag>> result = new List<ITagSpan<HighlightWordTag>>();
			foreach (var commentSpan in GetComments(span)) {
				result = result.Union(InnerParser.Parse(commentSpan));
			}
			return result;
		}

		private IEnumerable<SnapshotSpan> GetComments(SnapshotSpan span) {
			
			string codeLine = span.GetText();
			
			if (!codeLine.Contains(@"//") && !codeLine.Contains(@"/*")) {
				yield break;
			}

			bool doubleQuotes = false;
			bool singleQuotes = false;
			bool commentBegin = false;
			for (int i = 0; i < codeLine.Length; ++i) {
				if (codeLine[i] == '\"' && !singleQuotes) {
					doubleQuotes = !doubleQuotes;
				}
				if (codeLine[i] == '\'' && !doubleQuotes) {
					singleQuotes = !singleQuotes;
				}
				if (codeLine[i] == '\n') {
					doubleQuotes = false;
					singleQuotes = false;
				}
				if (doubleQuotes || singleQuotes) {
					commentBegin = false;
					continue;
				}
				if (codeLine[i] == '/') {
					if (commentBegin) {
						++i;
						int commentBeginIndex = i;
						int commentLength = 0;
						while (i < codeLine.Length && codeLine[i] != '\n') {
							++commentLength;
							++i;
						}
						if (commentBeginIndex > codeLine.Length) {
							continue;
						}
						yield return new SnapshotSpan(span.Snapshot, span.Start.Position + commentBeginIndex, commentLength);
						commentBegin = false;
					} else {
						commentBegin = true;
					}
				} else {
					commentBegin = false;
				}
				/*
				if (codeLine[i] == '*' && commentBegin) {
					bool commentEnd = false;
					int commentBeginIndex = i + 1;
					int commentLength = 0;
					while (i < codeLine.Length - 1) {
						++i;
						++commentLength;
						if (codeLine[i] == '/' && commentEnd) {
							yield return new SnapshotSpan(span.Snapshot, span.Start.Position + commentBeginIndex, commentLength - 2);
							break;
						}
						if (codeLine[i] == '*') {
							commentEnd = true;
						} else {
							commentEnd = false;
						}
					}
					commentBegin = false;
				}*/
			}
		}
	}
}
