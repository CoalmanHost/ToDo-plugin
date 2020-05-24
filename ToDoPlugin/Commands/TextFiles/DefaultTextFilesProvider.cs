using EnvDTE;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.IO;

namespace ToDoPlugin.Commands.TextFiles {
	internal class DefaultTextFilesProvider : ITextFilesProvider {

		public IEnumerable<TextFileInfo> GetTextFiles() {
			ThreadHelper.ThrowIfNotOnUIThread();
			
			IVsSolution solution = (IVsSolution)Package.GetGlobalService(typeof(IVsSolution));
			foreach (var item in SolutionFiles(solution)) {
				string fullname = null;
				string text = null;
				try {
					fullname = item.FileNames[1];
					text = File.ReadAllText(Path.Combine(item.FileNames[1]));
				}
				catch {

				}
				if (text != null) {
					yield return new TextFileInfo(fullname, text);
				}
			}
		}

		private static IEnumerable<ProjectItem> Recurse(ProjectItems i) {
			if (i != null) {
				foreach (ProjectItem j in i) {
					foreach (ProjectItem k in Recurse(j)) {
						yield return k;
					}
				}
			}
		}

		private static IEnumerable<ProjectItem> Recurse(ProjectItem i) {
			yield return i;
#pragma warning disable VSTHRD010
			foreach (ProjectItem j in Recurse(i.ProjectItems)) {
				yield return j;
			}
#pragma warning restore VSTHRD010
		}

		public IEnumerable<ProjectItem> SolutionFiles(IVsSolution solution) {
#pragma warning disable VSTHRD010
			foreach (Project project in GetProjects(solution)) {
				foreach (ProjectItem item in Recurse(project.ProjectItems)) {
					yield return item;
				}
			}
#pragma warning restore VSTHRD010
		}
		
		private static IEnumerable<Project> GetProjects(IVsSolution solution) {
			foreach (IVsHierarchy hierarchy in GetProjectsInSolution(solution)) {
				Project project = GetDTEProject(hierarchy);
				if (project != null) {
					yield return project;
				}
			}
		}

		private static IEnumerable<IVsHierarchy> GetProjectsInSolution(IVsSolution solution) {
			return GetProjectsInSolution(solution, __VSENUMPROJFLAGS.EPF_LOADEDINSOLUTION);
		}

		private static IEnumerable<IVsHierarchy> GetProjectsInSolution(IVsSolution solution, __VSENUMPROJFLAGS flags) {
			if (solution is null) {
				yield break;
			}
			Guid guid = Guid.Empty;
#pragma warning disable VSTHRD010
			solution.GetProjectEnum((uint)flags, ref guid, out IEnumHierarchies enumHierarchies);
			if (enumHierarchies == null) {
				yield break;
			}

			IVsHierarchy[] hierarchy = new IVsHierarchy[1];
			while (enumHierarchies.Next(1, hierarchy, out uint fetched) == VSConstants.S_OK && fetched == 1) {
				if (hierarchy.Length > 0 && hierarchy[0] != null) {
					yield return hierarchy[0];
				}
			}
#pragma warning restore VSTHRD010
		}

		public static Project GetDTEProject(IVsHierarchy hierarchy) {
			if (hierarchy == null) {
				return null;
				//throw new ArgumentNullException("hierarchy");
			}
#pragma warning disable VSTHRD010
			hierarchy.GetProperty(VSConstants.VSITEMID_ROOT, (int)__VSHPROPID.VSHPROPID_ExtObject, out object obj);
			return obj as Project;
#pragma warning restore VSTHRD010
		}

	}
}
