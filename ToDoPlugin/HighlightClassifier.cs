using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoPlugin.Classifications;
using ToDoPlugin.SpanParsers;

namespace ToDoPlugin {
	internal class HighlightClassifier : IClassifier {

		public event EventHandler<SnapshotSpanEventArgs> TagsChanged;
		public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;

		private readonly ISpanParser SpanParser;

		private readonly IClassificationTypeRegistryService ClassificationTypeRegistryService;

		private readonly IClassificationFormatMapService ClassificationFormatMapService;

		public static IClassificationTypeProvider ClassificationTypeProvider { get; private set; }

		public HighlightClassifier(IClassificationTypeRegistryService classificationTypeRegistryService, IClassificationFormatMapService classificationFormatMapService) {
			this.ClassificationTypeRegistryService = classificationTypeRegistryService;
			this.ClassificationFormatMapService = classificationFormatMapService;
			ClassificationTypeProvider = new DefaultClassificationTypeProvider(ClassificationTypeRegistryService, ClassificationFormatMapService);
			
			this.SpanParser = new SpanParserCollection { new CommentSectionParser(ClassificationTypeProvider) };
		}

		public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span) {
			IEnumerable<ClassificationSpan> result = SpanParser.Parse(span);
			return result.ToList();
		}
	}
}
