using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ToDoPlugin.Settings;

namespace ToDoPlugin.SpanParsers {
	internal class PresetSpanParser : ISpanParser {

		private readonly Regex Checker;

		private readonly Preset Preset;

		public PresetSpanParser(Preset preset) {
			Checker = new Regex(preset.Word + @"\b", RegexOptions.IgnoreCase);
			this.Preset = preset;
		}

		public IEnumerable<ITagSpan<HighlightWordTag>> Parse(SnapshotSpan span) {
			var matches = Checker.Matches(span.GetText());
			if (matches.Count == 0) {
				yield break;
			}
			SettingsContainer.CurrentPreset = this.Preset.Word;
			lock (SettingsContainer.CurrentPreset) {
				SettingsContainer.CurrentPreset = this.Preset.Word;
				foreach (Match match in matches) {
					Span spanPart = new Span(span.Start.Position + match.Index, match.Length);
					SnapshotSpan target = new SnapshotSpan(span.Snapshot, spanPart);
					yield return new TagSpan<HighlightWordTag>(target, new HighlightWordTag());
				}
			}
		}
	}
}
