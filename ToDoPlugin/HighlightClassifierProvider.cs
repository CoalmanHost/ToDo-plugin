using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace ToDoPlugin {

	[Export(typeof(IClassifierProvider))]
	[ContentType("text")]
	internal class HighlightClassifierProvider : IClassifierProvider {

		[Import]
		internal IClassificationTypeRegistryService ClassificationTypeRegistryService;

		[Import]
		internal IClassificationFormatMapService ClassificationFormatMapService;

		public HighlightClassifierProvider() {

		}

		public IClassifier GetClassifier(ITextBuffer buffer) {
			return buffer.Properties.GetOrCreateSingletonProperty<HighlightClassifier>(() => new HighlightClassifier(ClassificationTypeRegistryService, ClassificationFormatMapService)) as IClassifier;
		}
	}
}
