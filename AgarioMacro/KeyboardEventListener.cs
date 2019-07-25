using System.Diagnostics;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace AgarioMacro {
	class KeyboardEventListener {
		public KeyboardEventListener() {
			Program.hook.KeyDown += OnKeyDown;
			Program.hook.KeyUp += OnKeyUp;
		}

		private void OnKeyDown(object sender, KeyEventArgs e) {
			keyEvent(e.KeyCode, KeyPressType.KEY_DOWN);
		}

		private void OnKeyUp(object sender, KeyEventArgs e) {
			keyEvent(e.KeyCode, KeyPressType.KEY_UP);
		}


		private void keyEvent(Keys key, KeyPressType type) {
			//Debug.WriteLine(type.ToString() + " " + key.ToString());
			Program.moduleManager.handleKeyPress(key, type);
		}
	}
}