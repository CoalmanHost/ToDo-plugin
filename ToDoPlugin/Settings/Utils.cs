namespace ToDoPlugin.Settings {
	internal static class Utils {

		public static System.Windows.Media.Color ToWinColor(this System.Drawing.Color c) {
			return System.Windows.Media.Color.FromArgb(c.A, c.R, c.G, c.B);
		}

		public static System.Drawing.Color ToDrwColor(this System.Windows.Media.Color c) {
			return System.Drawing.Color.FromArgb(c.A, c.R, c.G, c.B);
		}

	}
}
