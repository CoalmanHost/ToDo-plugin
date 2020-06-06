﻿using System;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System.ComponentModel.Design;
using System.IO;
using ToDoPlugin.Commands.TextFiles;
using ToDoPlugin.Commands.TextFiles.Exporters;
using Task = System.Threading.Tasks.Task;

namespace ToDoPlugin.Commands {
	/// <summary>
	/// Command handler
	/// </summary>
	internal sealed class ExportTags {
		/// <summary>
		/// Command ID.
		/// </summary>
		public const int CommandId = 4129;

		/// <summary>
		/// Command menu group (command set GUID).
		/// </summary>
		public static readonly Guid CommandSet = new Guid("0f764687-7725-4636-bcd7-f648fa362fd9");

		/// <summary>
		/// VS Package that provides this command, not null.
		/// </summary>
		private readonly AsyncPackage package;

		private static ITextFilesProvider TextFilesProvider;

		private static IExporter Exporter;

		/// <summary>
		/// Initializes a new instance of the <see cref="ExportTags"/> class.
		/// Adds our command handlers for menu (commands must exist in the command table file)
		/// </summary>
		/// <param name="package">Owner package, not null.</param>
		/// <param name="commandService">Command service to add command to, not null.</param>
		private ExportTags(AsyncPackage package, OleMenuCommandService commandService) {
			this.package = package ?? throw new ArgumentNullException(nameof(package));
			commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

			var menuCommandID = new CommandID(CommandSet, CommandId);
			var menuItem = new MenuCommand(this.Execute, menuCommandID);
			commandService.AddCommand(menuItem);
		}

		/// <summary>
		/// Gets the instance of the command.
		/// </summary>
		public static ExportTags Instance {
			get;
			private set;
		}

		/// <summary>
		/// Gets the service provider from the owner package.
		/// </summary>
		private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider {
			get {
				return this.package;
			}
		}

		/// <summary>
		/// Initializes the singleton instance of the command.
		/// </summary>
		/// <param name="package">Owner package, not null.</param>
		public static async Task InitializeAsync(AsyncPackage package) {
			// Switch to the main thread - the call to AddCommand in ExportTags's constructor requires
			// the UI thread.
			await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

			TextFilesProvider = new DefaultTextFilesProvider();
			Exporter = new JsonExporter();
			// THINK of using custom configurable exporter

			OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
			Instance = new ExportTags(package, commandService);
		}

		/// <summary>
		/// This function is the callback used to execute the command when the menu item is clicked.
		/// See the constructor to see how the menu item is associated with this function using
		/// OleMenuCommandService service and MenuCommand class.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">Event args.</param>
		private void Execute(object sender, EventArgs e) {
			ThreadHelper.ThrowIfNotOnUIThread();

			var files = TextFilesProvider.GetTextFiles();

			string file = Exporter.CreateExportFile(files);
			IVsSolution solution = (IVsSolution)Package.GetGlobalService(typeof(IVsSolution));
			object savePath = "";
			solution.GetProperty(-8000, out savePath);
			string finalPath = (string)savePath + "export";
            if (File.Exists(finalPath))
            {
				File.Delete(finalPath);
            }
			File.Copy(file, finalPath);
			System.Diagnostics.Process.Start("devenv.exe", $"/edit {finalPath}");
			// TODO smth for opening JSON via VIsual Studio...
		}


	}
}
