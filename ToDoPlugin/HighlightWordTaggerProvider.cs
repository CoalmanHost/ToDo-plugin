using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace ToDoPlugin {

	[Export(typeof(IViewTaggerProvider))]
	[ContentType("text")]
	[TagType(typeof(TextMarkerTag))]
	internal class HighlightWordTaggerProvider : IViewTaggerProvider {

		[Import]
		internal ITextSearchService TextSearchService { get; set; }

		[Import]
		internal ITextStructureNavigatorSelectorService TextStructureNavigatorSelector { get; set; }

		public HighlightWordTaggerProvider() {

			//File.Create(@"C:\Alexandr\ya_ebal_etot_plugin2.txt");
		}

		public ITagger<T> CreateTagger<T>(ITextView textView, ITextBuffer buffer) where T : ITag {

			//throw new Exception("1322");

			//File.Create(@"C:\Alexandr\ya_ebal_etot_plugin.txt");

			if (textView.TextBuffer != buffer)
				return null;

			ITextStructureNavigator textStructureNavigator =
				TextStructureNavigatorSelector.GetTextStructureNavigator(buffer);

			//return new HighlightWordTagger(textView, buffer, TextSearchService, textStructureNavigator) as ITagger<T>;

			return buffer.Properties.GetOrCreateSingletonProperty<HighlightWordTagger>(() => new HighlightWordTagger(textView, buffer, TextSearchService, textStructureNavigator)) as ITagger<T>;

		}
	}
}
