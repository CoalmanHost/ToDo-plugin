using Microsoft.VisualStudio.Text.Classification;
using System;
using ToDoPlugin.Settings;

namespace ToDoPlugin.Classifications {
	internal class DefaultClassificationTypeProvider : IClassificationTypeProvider {

		private readonly IClassificationTypeRegistryService ClassificationTypeRegistryService;

		private readonly IClassificationFormatMapService ClassificationFormatMapService;

		public DefaultClassificationTypeProvider(IClassificationTypeRegistryService classificationTypeRegistryService, IClassificationFormatMapService classificationFormatMapService) {
			this.ClassificationTypeRegistryService = classificationTypeRegistryService;
			this.ClassificationFormatMapService = classificationFormatMapService;
		}

		public IClassificationType GetClassification(Preset preset) {
			IClassificationType type = ClassificationTypeRegistryService.GetClassificationType(preset.Word);
			if (type != null) {
				return type;
			}
			IClassificationType primaryClassification = ClassificationTypeRegistryService.GetClassificationType("identifier");
			IClassificationType newType = ClassificationTypeRegistryService.CreateClassificationType(preset.Word, new IClassificationType[] { primaryClassification });
			UpdateClassificationInternal(newType, preset);
			return newType;
		}

		public void UpdateClassification(Preset preset) {
			UpdateClassificationInternal(GetClassification(preset), preset);
		}

		private void UpdateClassificationInternal(IClassificationType targetClassification, Preset preset) {
			IClassificationType primaryClassification = ClassificationTypeRegistryService.GetClassificationType("identifier");
			var classificationFormatMap = ClassificationFormatMapService.GetClassificationFormatMap(category: "text");
			var identifierProperties = classificationFormatMap.GetExplicitTextProperties(primaryClassification);
			var newProperties = identifierProperties.SetBackground(preset.BackgroundColor);
			classificationFormatMap.AddExplicitTextProperties(targetClassification, newProperties);
		}
	}
}
