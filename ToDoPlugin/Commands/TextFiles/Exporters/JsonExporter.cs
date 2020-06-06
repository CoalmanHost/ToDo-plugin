using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using ToDoPlugin.Settings;
using Newtonsoft.Json;
using Microsoft.Win32;

namespace ToDoPlugin.Commands.TextFiles.Exporters
{
    internal class JsonExporter : IExporter
    {
		class LineToSave
        {
			public string FilePath { get; set; }
			public int LineNumber { get; set; }
			public string Line { get; set; }
            public LineToSave(string filePath, int lineNumber, string line)
            {
				FilePath = filePath;
				LineNumber = lineNumber;
				Line = line;
            }
        }
		public string CreateExportFile(IEnumerable<TextFileInfo> textFiles)
		{
			List<LineToSave> saveList = new List<LineToSave>();
			foreach (TextFileInfo file in textFiles)
			{
				string[] lines = file.FileText.Split('\n');
				for (int i = 0; i < lines.Length; ++i)
				{
					if (HasComment(lines[i]) && HasAnyTag(lines[i]))
					{
						LineToSave toSave = new LineToSave(file.FileName, i + 1, lines[i]);
						saveList.Add(toSave);
					}
				}
			}
			string output = (JsonConvert.SerializeObject(saveList.ToArray()));
			string filePath = Path.GetTempFileName();
			File.WriteAllText(filePath, output);
			return filePath;
		}

		private bool HasComment(string singleLine)
		{


			if (!singleLine.Contains(@"//") && !singleLine.Contains(@"/*"))
			{
				return false;
			}

			bool doubleQuotes = false;
			bool singleQuotes = false;
			bool commentBegin = false;
			for (int i = 0; i < singleLine.Length; ++i)
			{
				if (singleLine[i] == '\"' && !singleQuotes)
				{
					doubleQuotes = !doubleQuotes;
				}
				if (singleLine[i] == '\'' && !doubleQuotes)
				{
					singleQuotes = !singleQuotes;
				}
				if (singleLine[i] == '\n')
				{
					doubleQuotes = false;
					singleQuotes = false;
				}
				if (doubleQuotes || singleQuotes)
				{
					commentBegin = false;
					continue;
				}
				if (singleLine[i] == '/')
				{
					if (commentBegin)
					{
						++i;
						int commentBeginIndex = i;
						int commentLength = 0;
						while (i < singleLine.Length && singleLine[i] != '\n')
						{
							++commentLength;
							++i;
						}
						if (commentBeginIndex > singleLine.Length)
						{
							continue;
						}
						return true;
					}
					else
					{
						commentBegin = true;
					}
				}
				else
				{
					commentBegin = false;
				}
			}
			return false;

		}

		private bool HasAnyTag(string singleLine)
		{
			foreach (Preset preset in SettingsContainer.ShownPresets)
			{
				Regex reg = new Regex(preset.Word + @"\b", RegexOptions.IgnoreCase);
				if (reg.IsMatch(singleLine))
				{
					return true;
				}
			}
			return false;
		}
	}
}
