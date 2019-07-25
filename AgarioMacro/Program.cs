using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using mp.hooks;

namespace AgarioMacro
{
    static class Program
    {
		public static ModuleManager moduleManager;
		public static MainWindow mainWindow;

		public static KeyboardHook hook;

		public static void exit() {
			if (hook.Hooked) {
				hook.unhook();
			}
			moduleManager.onExit();
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]

        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

			hook = new KeyboardHook();

			moduleManager = new ModuleManager();
			moduleManager.loadModules("AgarioMacro.Modules");

			new KeyboardEventListener();
			//hook.hook();

			mainWindow = new MainWindow();
			Application.Run(mainWindow);
        }
    }
}
