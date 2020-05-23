using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ToDoPlugin.Classifications;
using ToDoPlugin.Settings;

namespace ToDoPlugin.SpanParsers {
	internal class PresetSpanParser : ISpanParser {

		private readonly Regex Checker;

		private readonly Preset Preset;

		private readonly IClassificationTypeProvider ClassificationTypeProvider;

		public PresetSpanParser(Preset preset, IClassificationTypeProvider classificationTypeProvider) {
			Checker = new Regex(preset.Word + @"\b", RegexOptions.IgnoreCase);
			this.Preset = preset;
			this.ClassificationTypeProvider = classificationTypeProvider;
		}

		IEnumerable<ClassificationSpan> ISpanParser.Parse(SnapshotSpan span) {
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
					IClassificationType type = ClassificationTypeProvider.GetClassification(Preset);
					//ClassificationTypeProvider.UpdateClassification(Preset);
					yield return new ClassificationSpan(target, type);
				}
			}
		}
	}
}
