using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ToDoPlugin.Settings;

namespace ToDoPlugin.Commands.TextFiles.Exporters {
	internal class DefaultExporter : IExplorter {

		public string CreateExportFile(IEnumerable<TextFileInfo> textFiles) {
			StringBuilder builder = new StringBuilder();
			foreach (TextFileInfo file in textFiles) {
				string[] lines = file.FileText.Split('\n');
				for (int i = 0; i < lines.Length; ++i) {
					if (HasComment(lines[i]) && HasAnyTag(lines[i])) {
						builder
							.Append(file.FileName)
							.Append(", line ")
							.Append(i + 1)
							.Append(": ")
							.Append(lines[i])
							.Append("\n");
					}
				}
			}
			string filePath = Path.GetTempFileName();
			File.WriteAllText(filePath, builder.ToString());
			return filePath;
		}

		private bool HasComment(string singleLine) {


			if (!singleLine.Contains(@"//") && !singleLine.Contains(@"/*")) {
				return false;
			}

			bool doubleQuotes = false;
			bool singleQuotes = false;
			bool commentBegin = false;
			for (int i = 0; i < singleLine.Length; ++i) {
				if (singleLine[i] == '\"' && !singleQuotes) {
					doubleQuotes = !doubleQuotes;
				}
				if (singleLine[i] == '\'' && !doubleQuotes) {
					singleQuotes = !singleQuotes;
				}
				if (singleLine[i] == '\n') {
					doubleQuotes = false;
					singleQuotes = false;
				}
				if (doubleQuotes || singleQuotes) {
					commentBegin = false;
					continue;
				}
				if (singleLine[i] == '/') {
					if (commentBegin) {
						++i;
						int commentBeginIndex = i;
						int commentLength = 0;
						while (i < singleLine.Length && singleLine[i] != '\n') {
							++commentLength;
							++i;
						}
						if (commentBeginIndex > singleLine.Length) {
							continue;
						}
						return true;
					} else {
						commentBegin = true;
					}
				} else {
					commentBegin = false;
				}
			}
			return false;

		}

		private bool HasAnyTag(string singleLine) {
			foreach (Preset preset in SettingsContainer.ShownPresets) {
				Regex reg = new Regex(preset.Word + @"\b", RegexOptions.IgnoreCase);
				if (reg.IsMatch(singleLine)) {
					return true;
				}
			}
			return false;
		}
	}
}
