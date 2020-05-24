using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Newtonsoft.Json.JsonConvert;

namespace ToDoPlugin.Settings.Savers {
	internal class JsonSettingsSaver : ISettingsSaver {
		
		public IEnumerable<Preset> LoadFromFile(string fileName) {
			string dir = Directory.GetCurrentDirectory();
			return DeserializeObject<Preset[]>(File.ReadAllText(fileName));
		}

		public void SaveToFile(string fileName, IEnumerable<Preset> presetCollection) {
			Preset[] savingArray = presetCollection.ToArray();
			string saveString = SerializeObject(savingArray);
			File.WriteAllText(fileName, saveString);
		}
	}
}
