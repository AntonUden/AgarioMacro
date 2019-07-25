using System.Windows.Forms;

namespace AgarioMacro.Modules
{
	class LineSplit : Module {
		public override string getName() {
			return "Line Split";
		}

		public override void onKeyDown(Keys key) {
			if(key == Keys.L) {
				Inputs.centerMouse();
			}
		}
	}
}
