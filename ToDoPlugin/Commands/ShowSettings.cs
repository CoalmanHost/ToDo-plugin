using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using ToDoPlugin.Settings;
using Task = System.Threading.Tasks.Task;

namespace ToDoPlugin.Commands {
	/// <summary>
	/// Command handler
	/// </summary>
	internal sealed class ShowSettings {
		/// <summary>
		/// Command ID.
		/// </summary>
		public const int CommandId = 0x0100;

		/// <summary>
		/// Command menu group (command set GUID).
		/// </summary>
		public static readonly Guid CommandSet = new Guid("0f764687-7725-4636-bcd7-f648fa362fd9");

		/// <summary>
		/// VS Package that provides this command, not null.
		/// </summary>
		private readonly AsyncPackage package;

		private SettingsWindow SettingsWindow { get; set; }

		private object Sync = new object();

		/// <summary>
		/// Initializes a new instance of the <see cref="ShowSettings"/> class.
		/// Adds our command handlers for menu (commands must exist in the command table file)
		/// </summary>
		/// <param name="package">Owner package, not null.</param>
		/// <param name="commandService">Command service to add command to, not null.</param>
		private ShowSettings(AsyncPackage package, OleMenuCommandService commandService) {
			this.package = package ?? throw new ArgumentNullException(nameof(package));
			commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

			var menuCommandID = new CommandID(CommandSet, CommandId);
			var menuItem = new MenuCommand(Execute, menuCommandID);
			commandService.AddCommand(menuItem);
		}

		/// <summary>
		/// Gets the instance of the command.
		/// </summary>
		public static ShowSettings Instance {
			get;
			private set;
		}

		/// <summary>
		/// Gets the service provider from the owner package.
		/// </summary>
		private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider {
			get {
				return package;
			}
		}

		/// <summary>
		/// Initializes the singleton instance of the command.
		/// </summary>
		/// <param name="package">Owner package, not null.</param>
		public static async Task InitializeAsync(AsyncPackage package) {
			// Switch to the main thread - the call to AddCommand in ShowSettings's constructor requires
			// the UI thread.
			await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

			OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
			Instance = new ShowSettings(package, commandService);
		}

		/// <summary>
		/// This function is the callback used to execute the command when the menu item is clicked.
		/// See the constructor to see how the menu item is associated with this function using
		/// OleMenuCommandService service and MenuCommand class.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">Event args.</param>
		private void Execute(object sender, EventArgs e) {
			lock (Sync) {
				ThreadHelper.ThrowIfNotOnUIThread();
				try {
					SettingsWindow = SettingsWindow ?? new SettingsWindow();
					if (SettingsWindow.IsClosed) {
						SettingsWindow = new SettingsWindow();
					}
					SettingsWindow.Show();
				}
				catch (Exception ex) {
					VsShellUtilities.ShowMessageBox(package, ex.ToString(), "", OLEMSGICON.OLEMSGICON_CRITICAL, OLEMSGBUTTON.OLEMSGBUTTON_OK, OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
				}
			}
		}
	}
}
