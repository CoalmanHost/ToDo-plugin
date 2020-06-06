using System.Collections.Generic;

namespace ToDoPlugin.Commands.TextFiles.Exporters {
	internal interface IExporter {

		string CreateExportFile(IEnumerable<TextFileInfo> textFiles);

	}
}
