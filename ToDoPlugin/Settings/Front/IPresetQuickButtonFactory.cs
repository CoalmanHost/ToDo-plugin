using System;
using System.Windows.Forms;

namespace ToDoPlugin.Settings.Front {
	internal interface IPresetQuickButtonFactory {

		Control CreateQuickButton(string caption, object tag, EventHandler callback);

	}
}
