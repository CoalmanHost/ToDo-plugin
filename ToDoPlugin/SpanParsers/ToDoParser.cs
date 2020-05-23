using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPlugin.SpanParsers {
	internal class ToDoParser : ISpanParser {

		private readonly IClassificationTypeRegistryService ClassificationTypeRegistryService;

		public ToDoParser(IClassificationTypeRegistryService classificationTypeRegistryService) {
			this.ClassificationTypeRegistryService = classificationTypeRegistryService;
			var idnfClsType = ClassificationTypeRegistryService.GetClassificationType("identifier");
			ClassificationTypeRegistryService.CreateClassificationType(HighlightClassification.FormatName, new IClassificationType[] { idnfClsType });
			//ClassificationTypeRegistryService.
		}

		public IEnumerable<ClassificationSpan> Parse(SnapshotSpan span) {
			string code = span.GetText().ToLower();
			int ind = code.IndexOf("todo");
			if (ind == -1) {
				yield break;
			}
			yield break;
			//IClassificationType type = ClassificationTypeRegistryService.GetClassificationType(HighlightClassification.FormatName);
			//yield return new ClassificationSpan(new SnapshotSpan(span.Snapshot, span.Start.Position + ind, 4), type);
		}
	}
}
