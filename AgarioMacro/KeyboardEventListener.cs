using System.Diagnostics;
using System.Windows.Forms;
using mp.hooks;

namespace AgarioMacro {
	class KeyboardEventListener {
		public KeyboardEventListener() {
			Program.hook.KeyDown += keyDown;
			Program.hook.KeyUp += keyUp;
		}

		private void keyDown(int wParam, KeyboardHookData lParam) {
			keyEvent(wParam, lParam, KeyPressType.KEY_DOWN);
		}

		private void keyUp(int wParam, KeyboardHookData lParam) {
			keyEvent(wParam, lParam, KeyPressType.KEY_UP);
		}

		private void keyEvent(int wParam, KeyboardHookData lParam, KeyPressType type) {
			Keys key = (Keys)lParam.vkCode;
			Debug.WriteLine(type.ToString() + " " + key.ToString());
			Program.moduleManager.handleKeyPress(key, type);
		}
	}
}