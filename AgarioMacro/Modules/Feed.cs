using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace AgarioMacro.Modules {
	class Feed : Module {
		protected CheckBox cbx_ToggleMode;
		protected Boolean feeding = false;
		protected Label lbl_feedingStatus;
		protected Thread feedThread;
		protected int delay = 40;

		protected Keys activationKey = Keys.F;

		protected override void onLoad() {
			cbx_ToggleMode = new CheckBox();
			cbx_ToggleMode.Name = "feedModule_cbx_toggle";
			cbx_ToggleMode.Text = "Toggle mode";

			lbl_feedingStatus = new Label();
			lbl_feedingStatus.ForeColor = Color.Blue;
			lbl_feedingStatus.Margin = new Padding(7, 7, 7, 7);

			updateLblFeedingStatus();

			panel.Controls.Add(cbx_ToggleMode);
			panel.Controls.Add(lbl_feedingStatus);

			panel.SetFlowBreak(lbl_feedingStatus, true);

			feedThread = new Thread(new ThreadStart(feedThreadFunction));
			feedThread.Start();
		}

		protected override void onExit() {
			if(feedThread != null) {
				if(feedThread.IsAlive) {
					feedThread.Abort();
				}
			}
		}

		public override void onKeyDown(Keys key) {
			if (this.isEnabled()) {
				if (key == activationKey) {
					if (cbx_ToggleMode.Checked) {
						setFeeding(!feeding);
					} else {
						setFeeding(true);
					}
				}
			}
		}

		public override void onKeyUp(Keys key) {
			if (feeding) {
				if (this.isEnabled()) {
					if (key == activationKey) {
						if (!cbx_ToggleMode.Checked) {
							setFeeding(false);
						}
					}
				}
			}
		}

		protected override void onDisable() {
			setFeeding(false);
		}

		private void feedThreadFunction() {
			while (true) {
				if(feeding) {
					//Debug.WriteLine("Feeding");
					Inputs.sendW();
				}
				Thread.Sleep(delay);
			}
		}

		private void updateLblFeedingStatus() {
			lbl_feedingStatus.Text = (feeding ? "Feeding" : "Not feeding");
		}

		private Boolean setFeeding(Boolean feeding) {
			if(this.feeding == feeding) {
				return false;
			}

			this.feeding = feeding;
			updateLblFeedingStatus();

			return true;
		}


		public override string getName() {
			return "Feed";
		}
	}
}
