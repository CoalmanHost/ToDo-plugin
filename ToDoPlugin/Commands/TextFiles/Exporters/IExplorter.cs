using System.Collections.Generic;

namespace ToDoPlugin.Commands.TextFiles.Exporters {
	internal interface IExplorter {

		string CreateExportFile(IEnumerable<TextFileInfo> textFiles);

	}
}
