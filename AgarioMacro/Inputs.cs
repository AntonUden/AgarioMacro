using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace AgarioMacro.Modules {
	class Inputs {
		public static void sendSpace() {
			SendKeys.SendWait("{SPACE}");
		}

		public static void sendW() {
			SendKeys.SendWait("w");
		}

		public static void centerMouse() {
			int x = 0;
			int y = 0;

			foreach (Screen screen in Screen.AllScreens) {
				if(!screen.Primary) {
					continue;
				}

				Debug.WriteLine("Screen bounds: " + screen.Bounds.ToString());

				x = screen.Bounds.X + (screen.WorkingArea.Width / 2);
				y = screen.Bounds.Y + (screen.WorkingArea.Height / 2);
			}

			Debug.WriteLine("x: " + x + " y: " + y);

			Cursor.Position = new Point(x, y);
		}
	}
}
