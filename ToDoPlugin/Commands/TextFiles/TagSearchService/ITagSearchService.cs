using System.Collections.Generic;

namespace ToDoPlugin.Commands.TextFiles.TagSearchService
	{
	internal interface ITagSearchService {

		string CreateExportFile(IEnumerable<TextFileInfo> textFiles);

	}
}
