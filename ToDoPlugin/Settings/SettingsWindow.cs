using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Drawing;
using System.Windows.Forms;
using ToDoPlugin.Settings.Front;

namespace ToDoPlugin.Settings {
	public partial class SettingsWindow : Form {

		private readonly IPresetQuickButtonFactory ButtonFactory;

		public SettingsWindow() {
			InitializeComponent();
			this.BackColor = VSColorTheme.GetThemedColor(EnvironmentColors.BrandedUIFillBrushKey);
			ButtonFactory = new PresetQuickButtonFactory(this.BackColor, Color.White);
			foreach (var preset in SettingsContainer.Presets) {
				StgsContainer.Controls.Add(ButtonFactory.CreateQuickButton(preset.Word, preset, PresetClick));
			}
		}

		private void CloseWindow_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void PresetClick(object sender, EventArgs e) {
			
		}
	}
}
