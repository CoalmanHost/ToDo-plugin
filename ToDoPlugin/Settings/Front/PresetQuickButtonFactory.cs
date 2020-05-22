using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoPlugin.Settings.Front {
	internal class PresetQuickButtonFactory : IPresetQuickButtonFactory {

		public PresetQuickButtonFactory(Color backColor, Color textColor) {

		}

		public Control CreateQuickButton(string caption, object tag, EventHandler callback) {
			Panel panel = new Panel();
			panel.Size = new Size(249, 42);
			panel.Click += callback;
			Label label = new Label();
			panel.Controls.Add(label);
			label.Text = caption;
			label.Location = new Point(12, 17);
			panel.Tag = tag;
			return panel;
		}

	}
}
