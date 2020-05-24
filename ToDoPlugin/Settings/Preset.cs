using Newtonsoft.Json;
using System.Windows.Media;

namespace ToDoPlugin.Settings {
	internal class Preset {

		public string Word { get; set; }

		public bool IsShown { get; set; }

		[JsonIgnore]
		public Color BackgroundColor { get; set; }

#pragma warning disable IDE0051
		[JsonProperty]
		private string StrColor {
			get {
				return BackgroundColor.R + ";" + BackgroundColor.G + ";" + BackgroundColor.B;
			}
			set {
				string[] parts = value.Split(';');
				byte r = byte.Parse(parts[0]);
				byte g = byte.Parse(parts[1]);
				byte b = byte.Parse(parts[2]);
				BackgroundColor = Color.FromRgb(r, g, b);
			}
		}
#pragma warning restore IDE0051

	}
}
