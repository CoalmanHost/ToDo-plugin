using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPlugin.Commands.TextFiles {
	internal struct TextFileInfo {

		public string FileName;

		public string FileText;

		public TextFileInfo(string filename, string filetext) {
			FileName = filename;
			FileText = filetext;
		}

	}
}
