using EnvDTE;
using System.Collections.Generic;

namespace ToDoPlugin.Commands.TextFiles {
	internal interface ITextFilesProvider {

		IEnumerable<TextFileInfo> GetTextFiles();

	}
}
