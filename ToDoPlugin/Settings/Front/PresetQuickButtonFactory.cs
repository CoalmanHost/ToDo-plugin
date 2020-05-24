using System;
using System.Drawing;
using System.Windows.Forms;

namespace ToDoPlugin.Settings.Front {
	internal class PresetQuickButtonFactory : IPresetQuickButtonFactory {

		private readonly Color BackColor;

		private readonly Color TextColor;

		public PresetQuickButtonFactory(Color backColor, Color textColor) {
			this.BackColor = backColor;
			this.TextColor = textColor;
		}

		public Control CreateQuickButton(string caption, object tag, EventHandler callback) {
			Panel panel = new Panel();
			panel.Size = new Size(249, 42);
			panel.Click += callback;
			Label label = new Label();
			panel.Controls.Add(label);
			label.Text = caption;
			label.ForeColor = this.TextColor;
			label.Location = new Point(12, 17);
			panel.Tag = tag;
			panel.BackColor = this.BackColor;
			return panel;
		}

	}
}
