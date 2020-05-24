using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Drawing;
using System.Windows.Forms;
using ToDoPlugin.Classifications;
using ToDoPlugin.Settings.Front;

namespace ToDoPlugin.Settings {
	internal partial class SettingsWindow : Form {

		private readonly IPresetQuickButtonFactory ButtonFactory;

		private Preset SelectedPreset = null;

		private Graphics PresetColorPalette;

		public bool IsClosed { get; private set; }

		private readonly IClassificationTypeProvider ClassificationTypeProvider;

		public SettingsWindow(IClassificationTypeProvider classificationTypeProvider) {
			InitializeComponent();
			this.ClassificationTypeProvider = classificationTypeProvider;
			//this.BackColor = VSColorTheme.GetThemedColor(EnvironmentColors.BrandedUIFillBrushKey);
			LeftBackground.BackColor = VSColorTheme.GetThemedColor(EnvironmentColors.BrandedUIFillBrushKey);
			RightBackground.BackColor = VSColorTheme.GetThemedColor(EnvironmentColors.ToolboxBackgroundBrushKey);
			ButtonFactory = new PresetQuickButtonFactory(RightBackground.BackColor, Color.White);
			RebuildPresetsContainer();
			PresetColorPalette = PresetColor.CreateGraphics();
		}

		private void RebuildPresetsContainer() {
			StgsContainer.Controls.Clear();
			foreach (var preset in SettingsContainer.Presets) {
				StgsContainer.Controls.Add(ButtonFactory.CreateQuickButton(preset.Word, preset, PresetClick));
			}
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
			SelectedPreset = preset;
			PresetName.Text = preset.Word;
			PresetActive.Checked = preset.IsShown;
			PresetName.Visible = true;
			PresetActive.Visible = true;
			PresetChangeColor.Visible = true;
			PresetColor.Visible = true;
			PresetColorPalette.FillRectangle(new SolidBrush(preset.BackgroundColor.ToDrwColor()), new Rectangle(0, 0, PresetColor.Width, PresetColor.Height));
			PresetNameChangeButton.Visible = true;
			PresetNameBox.Visible = false;
			SavePresetNameButton.Visible = false;
		}

		private void PresetActive_CheckedChanged(object sender, EventArgs e) {
			if (SelectedPreset is null) {
				return;
			}
			SelectedPreset.IsShown = PresetActive.Checked;
			SettingsContainer.SaveSettings();
		}

		private void PresetChangeColor_Click(object sender, EventArgs e) {
			if (SelectedPreset is null) {
				return;
			}
			if (PresetColorSelectDialog.ShowDialog() == DialogResult.OK) {
				SelectedPreset.BackgroundColor = PresetColorSelectDialog.Color.ToWinColor();
				PresetColorPalette.FillRectangle(new SolidBrush(PresetColorSelectDialog.Color), new Rectangle(0, 0, PresetColor.Width, PresetColor.Height));
				ClassificationTypeProvider.UpdateClassification(SelectedPreset);
				SettingsContainer.SaveSettings();
			}
		}

		private void SettingsWindow_FormClosing(object sender, FormClosingEventArgs e) {
			IsClosed = true;
		}

		private void SettingsWindow_FormClosed(object sender, FormClosedEventArgs e) {
			IsClosed = true;
		}

		private void CreateNewPresetButton_Click(object sender, EventArgs e) {
			Preset preset = new Preset() { BackgroundColor = System.Windows.Media.Colors.LightGray, IsShown = false, Word = "Новый тэг" };
			SettingsContainer.Presets.Add(preset);
			RebuildPresetsContainer();
			ShowPresetInfo(preset);
		}

		private void PresetNameChangeButton_Click(object sender, EventArgs e) {
			PresetNameBox.Visible = true;
			PresetNameChangeButton.Visible = false;
			PresetNameBox.Text = SelectedPreset?.Word;
			SavePresetNameButton.Visible = true;
		}

		private void SavePresetNameButton_Click(object sender, EventArgs e) {
			PresetNameBox.Visible = false;
			PresetNameChangeButton.Visible = true;
			SelectedPreset.Word = PresetNameBox.Text;
			PresetName.Text = SelectedPreset.Word;
			SavePresetNameButton.Visible = false;
			RebuildPresetsContainer();
			SettingsContainer.SaveSettings();
		}
	}
}
