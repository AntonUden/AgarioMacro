using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace AgarioMacro {
    static class Program
    {
		public static ModuleManager moduleManager;
		public static MainWindow mainWindow;

		public static IKeyboardMouseEvents hook;

		public static void exit() {
			moduleManager.onExit();
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

			hook = Hook.GlobalEvents();

			moduleManager = new ModuleManager();
			moduleManager.loadModules("AgarioMacro.Modules");

			new KeyboardEventListener();

			mainWindow = new MainWindow();
			Application.Run(mainWindow);
        }
    }
}
