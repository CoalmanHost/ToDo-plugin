using Microsoft.VisualStudio.Text.Classification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPlugin.Settings;

namespace ToDoPlugin.Classifications {
	internal interface IClassificationTypeProvider {

		IClassificationType GetClassification(Preset preset);

		void UpdateClassification(Preset preset);

	}
}
