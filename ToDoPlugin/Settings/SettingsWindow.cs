using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Drawing;
using System.Windows.Forms;
using ToDoPlugin.Settings.Front;

namespace ToDoPlugin.Settings {
	public partial class SettingsWindow : Form {

		private readonly IPresetQuickButtonFactory ButtonFactory;

		private Preset SelectedPreset = null;

		private Graphics PresetColorPalette;

		public bool IsClosed { get; private set; }

		public SettingsWindow() {
			InitializeComponent();
			//this.BackColor = VSColorTheme.GetThemedColor(EnvironmentColors.BrandedUIFillBrushKey);
			LeftBackground.BackColor = VSColorTheme.GetThemedColor(EnvironmentColors.BrandedUIFillBrushKey);
			RightBackground.BackColor = VSColorTheme.GetThemedColor(EnvironmentColors.ToolboxBackgroundBrushKey);
			ButtonFactory = new PresetQuickButtonFactory(RightBackground.BackColor, Color.White);
			foreach (var preset in SettingsContainer.Presets) {
				StgsContainer.Controls.Add(ButtonFactory.CreateQuickButton(preset.Word, preset, PresetClick));
			}
			PresetColorPalette = PresetColor.CreateGraphics();
		}

		private void CloseWindow_Click(object sender, EventArgs e) {
			this.Close();
			IsClosed = true;
		}

		private void PresetClick(object sender, EventArgs e) {
			ShowPresetInfo((sender as Control).Tag as Preset);
		}

		private void ShowPresetInfo(Preset preset) {
			if (preset is null) {
				return;
			}
			PresetName.Text = preset.Word;
			PresetActive.Checked = preset.IsShown;
			PresetName.Visible = true;
			PresetActive.Visible = true;
			PresetChangeColor.Visible = true;
			PresetColor.Visible = true;
			PresetColorPalette.FillRectangle(new SolidBrush(preset.BackgroundColor.ToDrwColor()), new Rectangle(0, 0, PresetColor.Width, PresetColor.Height));
			SelectedPreset = preset;
		}

		private void PresetActive_CheckedChanged(object sender, EventArgs e) {
			if (SelectedPreset is null) {
				return;
			}
			SelectedPreset.IsShown = PresetActive.Checked;
			SettingsContainer.UpdateSettings();
		}

		private void PresetChangeColor_Click(object sender, EventArgs e) {
			if (SelectedPreset is null) {
				return;
			}
			if (PresetColorSelectDialog.ShowDialog() == DialogResult.OK) {
				SelectedPreset.BackgroundColor = PresetColorSelectDialog.Color.ToWinColor();
				PresetColorPalette.FillRectangle(new SolidBrush(PresetColorSelectDialog.Color), new Rectangle(0, 0, PresetColor.Width, PresetColor.Height));
				SettingsContainer.UpdateSettings();
			}
		}

		private void SettingsWindow_FormClosing(object sender, FormClosingEventArgs e) {
			IsClosed = true;
		}

		private void SettingsWindow_FormClosed(object sender, FormClosedEventArgs e) {
			IsClosed = true;
		}
	}
}
