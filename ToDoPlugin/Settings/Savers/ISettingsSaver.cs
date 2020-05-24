using System.Collections.Generic;

namespace ToDoPlugin.Settings.Savers {
	internal interface ISettingsSaver {

		void SaveToFile(string fileName, IEnumerable<Preset> presetCollection);

		IEnumerable<Preset> LoadFromFile(string fileName);

	}
}
